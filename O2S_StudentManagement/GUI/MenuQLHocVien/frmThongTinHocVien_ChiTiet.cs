using O2S_StudentManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2S_StudentManagement.GUI.MenuQLHocVien
{
    public partial class frmThongTinHocVien_ChiTiet : Form
    {
        #region Khai bao
        private long hocvienId { get; set; }
        #endregion

        public frmThongTinHocVien_ChiTiet()
        {
            InitializeComponent();
        }
        public frmThongTinHocVien_ChiTiet(long _hocvienId)
        {
            InitializeComponent();
            this.hocvienId = _hocvienId;
        }

        #region Load
        private void frmThongTinHocVien_ChiTiet_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.hocvienId != 0)
                {

                    using (var db = new DAL.O2S_STUDENTMANAGEMENTEntities())
                    {
                        SM_STUDENT _student = db.SM_STUDENT.Where(o => o.id == this.hocvienId).FirstOrDefault();
                        if (_student == null)
                        {
                            txtstudentcode.Text = _student.studentcode;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }




        #endregion

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }
    }
}
