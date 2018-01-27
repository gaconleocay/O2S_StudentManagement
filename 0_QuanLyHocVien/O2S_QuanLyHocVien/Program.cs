// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "Program.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace O2S_QuanLyHocVien
{
    static class Program
    {
        private static readonly ILog logFile = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Common.Logging.LogSystem.Info("Application_Start. Time=" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"));
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Error(ex);
            }
            Application.Run(new frmMain());
        }
    }
}
