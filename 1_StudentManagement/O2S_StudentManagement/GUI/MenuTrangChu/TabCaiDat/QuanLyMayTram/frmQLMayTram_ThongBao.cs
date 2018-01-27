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

namespace O2S_StudentManagement.GUI.MenuTrangChu.TabCaiDat
{
    public partial class frmQLMayTram_ThongBao : Form
    {
        ConnectDatabase condb = new ConnectDatabase();

        public frmQLMayTram_ThongBao()
        {
            InitializeComponent();
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            try
            {
                string _sqlupdate = "UPDATE ie_clientmachine SET softstatus='3', thongbao='" + txtNoiDung.Text.Replace("'", "''") + "' ;";
                if (condb.ExecuteNonQuery(_sqlupdate))
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THANH_CONG);
                    frmthongbao.Show();
                }
                else
                {
                    Utilities.ThongBao.frmThongBao frmthongbao = new Utilities.ThongBao.frmThongBao(Base.ThongBaoLable.THAO_TAC_THAT_BAI);
                    frmthongbao.Show();
                }
            }
            catch (Exception ex)
            {
                Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
