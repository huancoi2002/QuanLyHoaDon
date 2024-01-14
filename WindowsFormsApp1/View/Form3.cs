using DevComponents.Editors.DateTimeAdv;
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
    public partial class Form3 : Form
    {
        Functions functions = new Functions();
        public Form3()
        {
            InitializeComponent();
        }
        public void Tanga()
        {
            string m;
            try
            {
                Functions functions = new Functions();
                Functions.Connect();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_SanPham ORDER BY MaSanPham DESC", Functions.Con);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                m = dt.Rows[0]["MaSanPham"].ToString();
                int n = Convert.ToInt32(m.Substring(2)) + 1;
                if (n <= 9)
                    m = "SP00" + n;
                else
                    if (n <= 99)
                    m = "SP0" + n;
                else
                    m = "SP" + n;
            }
            catch
            {
                m = "SP001";
            }
            textBoxX1.Text = m;
        }
        private void load_data()
        {
            functions.loaddatagridview(dataGridViewX1, "SELECT * FROM Tbl_SanPham");
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
        private void Form3_Load(object sender, EventArgs e)
        {
           
            load_data();
            string sql;
            sql = "SELECT * from Tbl_LoaiSanPham";
            Functions.FillCombo(sql, comboBoxEx1, "MaLoaiSanPham", "TenLoaiSanPham");
            comboBoxEx1.SelectedIndex = -1;
            functions.thucthisql(sql);

            string sql1;
            sql1 = "SELECT * from Tbl_ThuongHieu";
            Functions.FillCombo(sql1, comboBoxEx2, "MaThuongHieu", "TenThuongHieu");
            comboBoxEx2.SelectedIndex = -1;
            functions.thucthisql(sql1);

            textBoxX2.Enabled = false;
            textBoxX3.Enabled = false;
            textBox1.Enabled = false;
            textBoxX5.Enabled = false;
            dateTimeInput1.Enabled = false;
            comboBoxEx1.Enabled = false; 
            comboBoxEx2.Enabled=false;

            textBoxX2.Text = "";
            textBoxX3.Text = "";
            textBoxX5.Text = "";
            textBoxX1.Text = "";
            textBox1.Text = "";
            dateTimeInput1.Text = "";
            comboBoxEx1.Text = "";
            comboBoxEx2.Text = "";

            buttonX2.Enabled = false;
            buttonX3.Enabled = false;
            buttonX4.Enabled = false;
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Tanga();
            textBoxX2.Enabled = true;
            textBoxX3.Enabled = true;
            textBoxX5.Enabled = true;
            dateTimeInput1.Enabled = true;
            comboBoxEx1.Enabled = true;
            comboBoxEx2.Enabled = true;
            textBox1.Enabled = true;

            buttonX2.Enabled = true;
            buttonX3.Enabled = true;
            buttonX4.Enabled = true;
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (textBoxX2.Text == "" || textBoxX3.Text == "" || textBoxX5.Text == "" || dateTimeInput1.Text == "" || comboBoxEx1.Text == "" || comboBoxEx2.Text == "" )
            {
                MessageBox.Show("Chưa Nhập Thông Tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string insert = "Insert into Tbl_SanPham values(N'" + textBoxX1.Text + "',N'" + textBoxX2.Text + "',N'" + textBoxX3.Text + "',N'" + textBox1.Text + "',N'" + dateTimeInput1.Value + "',N'" + textBoxX5.Text + "',N'" + comboBoxEx1.SelectedValue.ToString() + "',N'" + comboBoxEx2.SelectedValue.ToString() + "')";
                functions.thucthisql(insert);
                MessageBox.Show("Thêm Mới Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
                Form3_Load(sender, e);
            }
            
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text == "")
            {
                MessageBox.Show("Chưa Chọn Thông Tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string update = "UPDATE Tbl_SanPham SET  TenSanPham=N'" + textBoxX2.Text.Trim().ToString() + "',GiaBan=N'" + textBoxX3.Text.Trim().ToString() + "',MoTa=N'" + textBox1.Text.Trim().ToString() + "',NgayCapNhat=N'" + dateTimeInput1.Value + "',SoLuongTon=N'" + textBoxX5.Text.Trim().ToString() + "',MaLoaiSanPham=N'" + comboBoxEx1.SelectedValue.ToString() + "',MaThuongHieu=N'" + comboBoxEx2.SelectedValue.ToString() + "' WHERE MaSanPham=N'" + textBoxX1.Text + "'";
                functions.thucthisql(update);
                MessageBox.Show("Cập Nhật Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
                Form3_Load(sender, e);
            }
            
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            string sql;
            if (dataGridViewX1.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBoxX1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    sql = "DELETE Tbl_SanPham WHERE MaSanPham=N'" + textBoxX1.Text + "'";
                    functions.thucthisql(sql);
                    MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa Không Thành Công Mã Sản Phẩm Này Đã Tồn Tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            load_data();
            Form3_Load(sender, e);
        }
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaLoaiSanPham, MaThuongHieu;
            string sql;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewX1.Rows[e.RowIndex];
                textBoxX1.Text = row.Cells[0].Value.ToString();
                textBoxX2.Text = row.Cells[1].Value.ToString();
                textBoxX3.Text = row.Cells[2].Value.ToString();
                textBox1.Text = row.Cells[3].Value.ToString();
                dateTimeInput1.Text = row.Cells[4].Value.ToString();
                textBoxX5.Text = row.Cells[5].Value.ToString();
                MaLoaiSanPham = dataGridViewX1.CurrentRow.Cells["MaLoaiSanPham"].Value.ToString();
                sql = "SELECT TenLoaiSanPham FROM Tbl_LoaiSanPham WHERE MaLoaiSanPham=N'" + MaLoaiSanPham + "'";
                comboBoxEx1.Text = Functions.GetFieldValues1(sql);
                MaThuongHieu = dataGridViewX1.CurrentRow.Cells["MaThuongHieu"].Value.ToString();
                sql = "SELECT TenThuongHieu FROM Tbl_ThuongHieu WHERE MaThuongHieu=N'" + MaThuongHieu + "'";
                comboBoxEx2.Text = Functions.GetFieldValues1(sql);
            }
            textBoxX2.Enabled = true;
            textBoxX3.Enabled = true;
            textBoxX5.Enabled = true;
            dateTimeInput1.Enabled = true;
            comboBoxEx1.Enabled = true;
            comboBoxEx2.Enabled = true;
            textBox1.Enabled = true;

            buttonX2.Enabled = true;
            buttonX3.Enabled = true;
            buttonX4.Enabled = true;
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            Form3_Load(sender, e);
        }
    }
}
