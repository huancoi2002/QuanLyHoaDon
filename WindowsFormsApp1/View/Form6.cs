using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View
{
    public partial class Form6 : Form
    {
        Functions functions = new Functions();
        DataTable tblCTHDB;
        public Form6()
        {
            InitializeComponent();
        }
        private void DemTongTienHoaDon()
        {
            double tong = 0;
            tong = Convert.ToDouble(Functions.GetFieldValues1("SELECT Sum(TongTien) FROM Tbl_HoaDon"));
            textBoxX1.Text = tong.ToString();

        }
        private void DemTongSoHoaDon()
        {
            double tong = 0;
            tong = Convert.ToDouble(Functions.GetFieldValues1("SELECT COUNT(MaDonHang)FROM Tbl_HoaDon"));
            textBoxX2.Text = tong.ToString();
        }
        private void load_data()
        {
            functions.loaddatagridview(dataGridViewX1, 
            "SELECT a.MaDonHang,a.NgayDatHang,a.NgayGiaoHang,a.TinhTrangGiaoHang,a.TinhTrangThanhToan,b.HoTen, a.TongTien  FROM Tbl_HoaDon AS a, Tbl_KhachHang AS b WHERE a.MaDonHang = MaDonHang AND a.MaKhachHang=b.MaKhachHang");
            dataGridViewX1.AllowUserToAddRows = false;
            dataGridViewX1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void load_data1()
        {
            string MaDonHang;
            MaDonHang = dataGridViewX1.CurrentRow.Cells["MaDonHang"].Value.ToString();
            string sql;
            sql = "SELECT a.MaSanPham, b.TenSanPham, a.Soluong, b.GiaBan,a.Thanhtien FROM Tbl_ChiTietHoaDon AS a,Tbl_SanPham AS b WHERE a.MaDonHang =N'" + MaDonHang + "' AND a.MaSanPham=b.MaSanPham";
            tblCTHDB = Functions.GetDataToTable(sql);
            dataGridViewX2.DataSource = tblCTHDB;
            dataGridViewX2.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridViewX2.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridViewX2.Columns[2].HeaderText = "Số lượng";
            dataGridViewX2.Columns[3].HeaderText = "Đơn giá";
            dataGridViewX2.Columns[4].HeaderText = "Thành tiền";


            dataGridViewX2.AllowUserToAddRows = false;
            dataGridViewX2.EditMode = DataGridViewEditMode.EditProgrammatically;

            dataGridViewX2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            
           
        }
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaDonHang;
            MaDonHang = dataGridViewX1.CurrentRow.Cells["MaDonHang"].Value.ToString();
            string sql;
            if (dataGridViewX1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                sql = "SELECT * FROM Tbl_ChiTietHoaDon WHERE MaDonHang=N'" + MaDonHang + "'";
                functions.thucthisql(sql);
                load_data1();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                load_data();
                DemTongTienHoaDon();
                DemTongSoHoaDon();
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
           
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(textBoxX2.Text, System.Globalization.NumberStyles.AllowThousands);
            textBoxX2.Text = String.Format(culture, "{0:N0}", value);
            textBoxX2.Select(textBoxX2.Text.Length, 0);
        }

        private void textBoxX1_TextChanged_1(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(textBoxX1.Text, System.Globalization.NumberStyles.AllowThousands);
            textBoxX1.Text = String.Format(culture, "{0:N0}", value);
            textBoxX1.Select(textBoxX1.Text.Length, 0);
        }
    }
}
