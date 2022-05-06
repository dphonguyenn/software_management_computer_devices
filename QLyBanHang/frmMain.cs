using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLyBanHang
{
    public partial class frmMain : Form
    {
        protected List<Form> lsForm;

        public List<Form> listForm
        {
           get; set;
        }
        public frmMain(List<Form> list)
        {
            this.lsForm = list;
            InitializeComponent();
        }

        private void mnuTepTin_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.MdiParent = this;
            frm.Show();
            Class.Functions.Connect();

        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect();
            Application.Exit();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            hideCurrentForm();
            frmDMNhanvien frmNhanVien = new frmDMNhanvien();
            this.lsForm.Add(frmNhanVien);
            // this là frmMain _ chỉ định frmHangHoa nhận frmMain là frm chính
            frmNhanVien.MdiParent = this;
            this.Dock = DockStyle.Fill;
            frmNhanVien.Show();
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            hideCurrentForm();
            frmDMHang frmHangHoa = new frmDMHang();
            this.lsForm.Add(frmHangHoa);
            frmHangHoa.MdiParent = this;
            this.Dock = DockStyle.Fill;
            frmHangHoa.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            hideCurrentForm();
            frmDMKhachHang frm = new frmDMKhachHang();
            this.lsForm.Add(frm);
            frm.MdiParent = this;
            this.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void hideCurrentForm()
        {
            if (this.lsForm.Count > 0)
            {
                this.lsForm.ForEach(form =>
                {
                    form.Close();
                });
            }
            else return;
        }

        private void dangNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
