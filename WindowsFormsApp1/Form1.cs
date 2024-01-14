using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.View;

namespace WindowsFormsApp1
{
    public partial class FormHeThong : MetroFramework.Forms.MetroForm
    {
        public FormHeThong()
        {
            InitializeComponent();
        }
        private void DemTongSoHoaDon()
        {
            double tong = 0;
            tong = Convert.ToDouble(Functions.GetFieldValues1("SELECT COUNT(MaDonHang)FROM Tbl_HoaDon"));
            labelX1.Text = tong.ToString();
        }
        private void DemTongSoSanPham()
        {
            double tong = 0;
            tong = Convert.ToDouble(Functions.GetFieldValues1("SELECT COUNT(MaSanPham)FROM Tbl_SanPham"));
            labelX5.Text = tong.ToString();
        }
        private void DemTongSoKhachHang()
        {
            double tong = 0;
            tong = Convert.ToDouble(Functions.GetFieldValues1("SELECT COUNT(MaKhachHang)FROM Tbl_KhachHang"));
            labelX6.Text = tong.ToString();
        }
        public static string quyen;
        public static string tennguoidung;
        private void FormHeThong_Load(object sender, EventArgs e)
        {
            DateTime tn = DateTime.Now;
            labelX10.Text = tn.ToString("dd/MM/yyyy");
            DemTongSoHoaDon();
            DemTongSoSanPham();
            DemTongSoKhachHang();
            if (quyen == "Admin")
            {
                labelX7.Text = tennguoidung;
                MessageBox.Show("Bạn đang đăng nhập dưới quyền: " + quyen);
            }
            if (quyen == "NhanVien")
            {
                labelX7.Text = tennguoidung;
                MessageBox.Show("Bạn đang đăng nhập dưới quyền: " + quyen);
                quảnLýLoạiSảnPhẩmToolStripMenuItem.Enabled = true;
                quảnLýThươngHiệuToolStripMenuItem.Enabled = true;
                quảnLýThươngHiệuToolStripMenuItem.Enabled = true;
                quảnLýSảnPhẩmToolStripMenuItem.Enabled = true;
                quảnLýKháchHàngToolStripMenuItem.Enabled = true;
                quảnLýHóaĐơnToolStripMenuItem1.Enabled = true;
                quảnLýChiTiếtHóaĐơnToolStripMenuItem.Enabled = true;
                tìmKiếmThôngTinToolStripMenuItem.Enabled = true;
                tìmKiếmThôngTinSảnPhẩmToolStripMenuItem.Enabled = true;
                báoCáoThôngKêHóaĐơnToolStripMenuItem.Enabled = true;
                báoCáoThôngKêSảnPhẩmToolStripMenuItem.Enabled = true;
            }
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show(" Bạn có muốn thoát chương trình không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Close();
            }
        }

        private void quảnLýLoạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýThươngHiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýHóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýChiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.MdiParent = this;
            frm.Show();
        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
            FormHeThong_Load(sender, e);
        }

        private void tìmKiếmThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tìmKiếmThôngTinSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 frm = new Form8();
            frm.MdiParent = this;
            frm.Show();
        }
        private void báoCáoThôngKêHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 frm = new Form10();
            frm.MdiParent = this;
            frm.Show();
        }

        private void báoCáoThôngKêSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 frm = new Form9();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
