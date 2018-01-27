using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_StudentManagement.GUI.MenuThongKe
{
    public partial class frmXemAnhXeVaoRa : Form
    {
        #region Khai bao
        private DAL.ConnectDatabase condb = new DAL.ConnectDatabase();

        #endregion

        public frmXemAnhXeVaoRa()
        {
            InitializeComponent();
        }

        public frmXemAnhXeVaoRa(string _cardeventid)
        {
            try
            {
                InitializeComponent();
                LoadAnhXeVaoRa(_cardeventid);
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
        private void LoadAnhXeVaoRa(string _cardeventid)
        {
            try
            {
                string _sqlLayAnh = "SELECT PicDirIn,PicDirOut FROM [MPARKINGEVENT].[dbo].[tblCardEvent] WHERE Id='" + _cardeventid + "';";
                DataTable _dataAnhXe = condb.GetDataTable_BGX(_sqlLayAnh, 1);
                if (_dataAnhXe != null && _dataAnhXe.Rows.Count > 0)
                {
                    string _pathAnhXeVao = _dataAnhXe.Rows[0]["PicDirIn"].ToString();
                    if (_pathAnhXeVao != null && _pathAnhXeVao != "")
                    {
                        pictureAnhXeVao_PLATEIN.Image = Image.FromFile(_pathAnhXeVao);
                        pictureAnhXeVao_OVERVIEWIN.Image = Image.FromFile(_pathAnhXeVao.Replace("PLATEIN", "OVERVIEWIN"));
                    }
                    string _pathAnhXeRa = _dataAnhXe.Rows[0]["PicDirOut"].ToString();
                    if (_pathAnhXeRa != null && _pathAnhXeRa != "")
                    {
                        pictureAnhXeRa_PLATEOUT.Image = Image.FromFile(_pathAnhXeRa);
                        pictureAnhXeVao_OVERVIEWOUT.Image = Image.FromFile(_pathAnhXeRa.Replace("PLATEOUT", "OVERVIEWOUT"));
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
