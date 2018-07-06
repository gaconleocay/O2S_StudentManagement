using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace O2S_QuanLyHocVienLauncher
{
    static class Program
    {
        private static string tempDirectory = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //if (!GlobalSettings.ConnectToDatabase())
                //{
                //    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (CheckVersionUpdate()) //update - co ban cap nhat moi
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn cập nhật lên phiên bản mới? \nHãy tắt phần mềm đang chạy trước khi cập nhật.", "Thông báo có phiên bản mới.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (dialogResult == DialogResult.Yes)
                    {
                        KillProcess_QuanLyHocVien();
                        CopyFolder_CheckSum(tempDirectory, Environment.CurrentDirectory);
                    }
                }
                else //khong co ban cap nhat moi thi cung checksum file de tu dong cap nhat
                {
                    CopyFolder_CheckSum(tempDirectory, Environment.CurrentDirectory);
                }

                System.Diagnostics.Process.Start(@"O2S_QuanLyHocVien.exe");
                Application.Exit();
            }
            catch (Exception ex)
            {
               // O2S_Common.Logging.LogSystem.Error(ex);
                System.Diagnostics.Process.Start(@"O2S_QuanLyHocVien.exe");
                Application.Exit();
            }
        }

        private static bool CheckVersionUpdate()
        {
            bool result = false;
            try
            {
                ConnectDatabase condb = new ConnectDatabase();
                DataView dataVer = new DataView(condb.GetDataTable("SELECT top 1 AppVersion,AppLink from VERSION where AppType=0;"));
                if (dataVer != null && dataVer.Count > 0)
                {
                    //versionDatabase = dataVer[0]["appversion"].ToString();
                    tempDirectory = dataVer[0]["AppLink"].ToString();
                }
                //lấy thông tin version của phần mềm O2S_QuanLyHocVien.exe hien tai
                FileVersionInfo.GetVersionInfo(Path.Combine(Environment.CurrentDirectory, "O2S_QuanLyHocVien.exe"));
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Environment.CurrentDirectory + "\\O2S_QuanLyHocVien.exe");
                //thong tin version tren server
                FileVersionInfo.GetVersionInfo(Path.Combine(tempDirectory, "O2S_QuanLyHocVien.exe"));
                FileVersionInfo myFileVersionInfo_Server = FileVersionInfo.GetVersionInfo(tempDirectory + "\\O2S_QuanLyHocVien.exe");

                if (myFileVersionInfo.FileVersion.ToString() != myFileVersionInfo_Server.FileVersion.ToString())
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = true;
               // O2S_Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }
        private static void KillProcess_QuanLyHocVien()
        {
            try
            {
                Process[] pProcess = System.Diagnostics.Process.GetProcessesByName("O2S_QuanLyHocVien");
                foreach (Process p in pProcess)
                {
                    p.Kill();
                }
            }
            catch (Exception ex)
            {
               // O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
        private static void CopyFolder_CheckSum(string SourceFolder, string DestFolder)
        {
            Directory.CreateDirectory(DestFolder); //Tao folder moi
            string[] files = Directory.GetFiles(SourceFolder);
            //Neu co file thy phai copy file
            foreach (string file in files)
            {
                try
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(DestFolder, name);

                    //Check file
                    if (Checksum.GetFileCheckSum.GetMD5HashFromFile(file) != Checksum.GetFileCheckSum.GetMD5HashFromFile(dest))
                    {
                        File.Copy(file, dest, true);
                    }
                }
                catch (Exception ex)
                {
                    //File.Copy(file, dest, true);
                   // O2S_Common.Logging.LogSystem.Error("Loi copy file "+ ex.ToString());
                    continue;
                }
            }

            string[] folders = Directory.GetDirectories(SourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(DestFolder, name);
                CopyFolder_CheckSum(folder, dest);
            }
        }



    }
}
