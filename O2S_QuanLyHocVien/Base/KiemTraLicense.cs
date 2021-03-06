﻿using O2S_QuanLyHocVien.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using O2S_License.PasswordKey;
using O2S_QuanLyHocVien.BusinessLogic;
using O2S_QuanLyHocVien.DataAccess;


namespace O2S_QuanLyHocVien.Base
{
    internal static class KiemTraLicense
    {
        static DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        internal static void KiemTraLicenseHopLe()
        {
            try
            {
                GlobalSettings.KiemTraLicenseSuDung = false;
                //Load License tu DB ra
                string license_keydb = LicenseLogic.Select(GlobalSettings.MaDatabase).LicenseKey ?? null;
                if (license_keydb != null)
                {
                    //Giai ma
                    string makichhoat_giaima = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(license_keydb, true);
                    //Tach ma kich hoat:
                    string mamay_keykichhoat = "";
                    string mabanquyenkhongthoihan = "";
                    long datetimenow = Convert.ToInt64(DateTime.Now.ToString("yyyyMMdd"));
                    //lay thoi gian may chu database: neu khong lay duoc thi lay thoi gian tren may client
                    try
                    {
                        string sql_dateDB = "SELECT FORMAT(SYSDATETIME(),'yyyyMMdd') as 'yyyyMMdd';";
                        DataView dtdatetime = new DataView(condb.GetDataTable(sql_dateDB));
                        if (dtdatetime != null && dtdatetime.Count > 0)
                        {
                            datetimenow = O2S_Common.TypeConvert.Parse.ToInt64(dtdatetime[0]["yyyyMMdd"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        O2S_Common.Logging.LogSystem.Error(ex);
                    }

                    if (!String.IsNullOrEmpty(makichhoat_giaima))
                    {
                        string[] makichhoat_tach = makichhoat_giaima.Split('$');
                        if (makichhoat_tach.Length == 4)
                        {
                            mamay_keykichhoat = makichhoat_tach[1];
                            //Thoi gian hien tai
                            datetimenow = Convert.ToInt64(DateTime.Now.ToString("yyyyMMdd"));

                            //Kiem tra License hop le
                            if (mamay_keykichhoat == GlobalSettings.MaDatabase && datetimenow <= Convert.ToInt64(makichhoat_tach[3].ToString().Trim() ?? "0"))
                            {
                                GlobalSettings.KiemTraLicenseSuDung = true;
                            }
                        }
                        else if (makichhoat_tach.Length == 3)
                        {
                            mamay_keykichhoat = makichhoat_tach[1];
                            mabanquyenkhongthoihan = makichhoat_tach[2];
                            if (mamay_keykichhoat == GlobalSettings.MaDatabase && mabanquyenkhongthoihan == KeyTrongPhanMem.BanQuyenKhongThoiHan)
                            {
                                GlobalSettings.KiemTraLicenseSuDung = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn("Kiem tra license " + ex.ToString());
            }
        }

        internal static string LayThongTinMaDatabase()
        {
            string MaDatabase = "";
            try
            {
                string serveruser_SM = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(ConfigurationManager.AppSettings["Database"].ToString().Trim(), true);

                string sqlLayMaDatabase = "select service_broker_guid from sys.databases where name='" + serveruser_SM + "';";
                DataView dataMaDB = new DataView(condb.GetDataTable(sqlLayMaDatabase));
                if (dataMaDB != null && dataMaDB.Count > 0)
                {
                    MaDatabase = dataMaDB[0]["service_broker_guid"].ToString().ToUpper();
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn("Lay thong tin ma database " + ex.ToString());
            }
            return MaDatabase;
        }

        internal static string KiemTraThoiHanLicense(string makichhoat_mahoa)
        {
            string thoiGianSuDung = "";
            try
            {
                //Giai ma
                string makichhoat_giaima = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Decrypt(makichhoat_mahoa, true);
                //Tach ma kich hoat:
                string mamay_keykichhoat = "";
                long thoigianTu = 0;
                long thoigianDen = 0;
                string[] makichhoat_tach = makichhoat_giaima.Split('$');
                string mabanquyenkhongthoihan = "";

                if (makichhoat_tach.Length == 4)
                {
                    mamay_keykichhoat = makichhoat_tach[1];
                    thoigianTu = Convert.ToInt64((makichhoat_tach[2].ToString().Trim() ?? "0") + "000000");
                    thoigianDen = Convert.ToInt64((makichhoat_tach[3].ToString().Trim() ?? "0") + "235959");
                    //Thoi gian hien tai
                    long datetime = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    string thoigianTu_text = DateTime.ParseExact(thoigianTu.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString("dd-MM-yyyy");
                    string thoigianDen_text = DateTime.ParseExact(thoigianDen.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString("dd-MM-yyyy");
                    //Kiem tra License hop le
                    if (mamay_keykichhoat == GlobalSettings.MaDatabase && datetime < thoigianDen)
                    {
                        thoiGianSuDung = "Từ: " + thoigianTu_text + " đến: " + thoigianDen_text;
                    }
                    else
                    {
                        thoiGianSuDung = "Mã kích hoạt hết hạn sử dụng";
                    }
                }
                else if (makichhoat_tach.Length == 3)
                {
                    mamay_keykichhoat = makichhoat_tach[1];
                    mabanquyenkhongthoihan = makichhoat_tach[2];
                    if (mamay_keykichhoat == GlobalSettings.MaDatabase && mabanquyenkhongthoihan == KeyTrongPhanMem.BanQuyenKhongThoiHan)
                    {
                        thoiGianSuDung = "License không thời hạn!";
                    }
                    else
                    {
                        thoiGianSuDung = "Mã kích hoạt hết hạn sử dụng";
                    }
                }
                else
                {
                    thoiGianSuDung = "Sai mã kích hoạt";
                }
            }
            catch (Exception ex)
            {
                O2S_Common.Logging.LogSystem.Warn("Kiem tra license " + ex.ToString());
            }
            return thoiGianSuDung;
        }






    }
}
