using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyDonHang;Integrated Security=True");
            try
            {
                Con.Open();
                string tk = textBoxX1.Text;
                string mk = textBoxX2.Text;
                string sql = "Select * From Tbl_TaiKhoan Where TenDangNhap ='" + tk + "' and MatKhau ='" + mk + "'";
                string name = Convert.ToString(Functions.GetFieldValues1("Select TenDangNhap from Tbl_TaiKhoan where MatKhau =N'" + mk + "' "));
                string Quyen = Convert.ToString(Functions.GetFieldValues1("Select Quyen from Tbl_TaiKhoan where MatKhau =N'" + mk + "' "));
                string ten = Convert.ToString(Functions.GetFieldValues1("Select HoTen from Tbl_TaiKhoan where MatKhau =N'" + mk + "' "));
                SqlCommand cmd = new SqlCommand(sql, Con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (Convert.ToString(tk) == name)
                    {
                        FormHeThong.quyen = Quyen;
                        FormHeThong.tennguoidung = ten;
                        MessageBox.Show("Đăng nhập thành công", "Thông Báo");
                        FormHeThong f = new FormHeThong();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập không đúng");
                    }
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công", "Thông Báo");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show(" Bạn có muốn thoát chương trình không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
