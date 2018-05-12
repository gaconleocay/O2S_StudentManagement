// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2018 OneOne solution co.
// File "CauHinhEmail.cs"
// Writing by NhatHM (hongminhnhat15@gmail.com)

using System.Linq;
using static O2S_QuanLyHocVien.BusinessLogic.GlobalSettings;
using O2S_QuanLyHocVien.DataAccess;
using O2S_QuanLyHocVien.BusinessLogic.Filter;
using System.Collections.Generic;
using O2S_QuanLyHocVien.BusinessLogic.Model;
using System;

namespace O2S_QuanLyHocVien.BusinessLogic
{
    public static class CauHinhEmailLogic
    {
        public static CAUHINHEMAIL SelectSingle(int _cauhinhemailId)
        {
            try
            {
                return (from p in GlobalSettings.Database.CAUHINHEMAILs
                        where p.CauHinhEmailId == _cauhinhemailId
                        select p).Single();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static List<CAUHINHEMAIL> Select(CauHinhEmailFilter _filter)
        {
            try
            {
                var query = (from p in GlobalSettings.Database.CAUHINHEMAILs
                             select p).ToList();
                if (_filter.CoSoId != null && _filter.CoSoId != 0)
                {
                    query = query.Where(o => o.CoSoId == _filter.CoSoId).ToList();
                }
                return query.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Insert(CAUHINHEMAIL _monhoc, ref int _monHocId)
        {
            try
            {
                _monhoc.MatKhau = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Encrypt(_monhoc.MatKhau, true);
                _monhoc.CreatedDate = DateTime.Now;
                _monhoc.CreatedBy = GlobalSettings.UserCode;
                _monhoc.CreatedLog = GlobalSettings.SessionMyIP;
                _monhoc.IsRemove = 0;
                Database.CAUHINHEMAILs.InsertOnSubmit(_monhoc);
                Database.SubmitChanges();
                _monHocId = _monhoc.CauHinhEmailId;
                _monhoc.MaEmail = string.Format("{0}{1:D5}", "EM", _monHocId);
                Database.SubmitChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Update(CAUHINHEMAIL _cauhinhemail)
        {
            try
            {
                var monhoccu = SelectSingle(_cauhinhemail.CauHinhEmailId);

                monhoccu.SMTPServer = _cauhinhemail.SMTPServer;
                monhoccu.Port = _cauhinhemail.Port;
                monhoccu.DiaChiEmail = _cauhinhemail.DiaChiEmail;
                monhoccu.TaiKhoan = _cauhinhemail.TaiKhoan;
                monhoccu.MatKhau = O2S_Common.EncryptAndDecrypt.MD5EncryptAndDecrypt.Encrypt(_cauhinhemail.MatKhau, true);
                monhoccu.XacThucSSL = _cauhinhemail.XacThucSSL;
                monhoccu.XacThucTKKhiGui = _cauhinhemail.XacThucTKKhiGui;

                monhoccu.ModifiedDate = DateTime.Now;
                monhoccu.ModifiedBy = GlobalSettings.UserCode;
                monhoccu.ModifiedLog = GlobalSettings.SessionMyIP;
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }

        public static bool Delete(int _cauhinhemailId)
        {
            try
            {
                var temp = SelectSingle(_cauhinhemailId);
                Database.CAUHINHEMAILs.DeleteOnSubmit(temp);
                Database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                O2S_Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
