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
    public partial class Form8 : Form
    {
        Functions functions = new Functions();
        public Form8()
        {
            InitializeComponent();
        }
        private void load_data()
        {
            functions.loaddatagridview(dataGridViewX1, "SELECT * FROM Tbl_SanPham WHERE MaSanPham LIKE '%" + textBoxX1.Text.Trim() + "%'");
            dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        private void load_data1()
        {
            functions.loaddatagridview(dataGridViewX1, "SELECT * FROM Tbl_SanPham WHERE TenSanPham LIKE '%" + textBoxX1.Text.Trim() + "%'");
            dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (comboBoxEx1.Text == "" || textBoxX1.Text == "")
            {
                MessageBox.Show("Bạn Chưa Chọn Thông Tin Tìm Kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (comboBoxEx1.Text == "Mã sản phẩm")
            {
                string timkiem = "SELECT * FROM Tbl_SanPham WHERE MaSanPham LIKE '%" + textBoxX1.Text.Trim() + "%'";
                functions.thucthisql(timkiem);
                load_data();

            }
            if (comboBoxEx1.Text == "Tên sản phẩm")
            {
                string timkiem = "SELECT * FROM Tbl_SanPham WHERE TenSanPham LIKE '%" + textBoxX1.Text.Trim() + "%'";
                functions.thucthisql(timkiem);
                load_data1();

            }
        }
    }
}
