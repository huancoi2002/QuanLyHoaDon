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
    public partial class Form2 : Form
    {
        Functions functions = new Functions();
        public Form2()
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_LoaiSanPham ORDER BY MaLoaiSanPham DESC", Functions.Con);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                m = dt.Rows[0]["MaLoaiSanPham"].ToString();
                int n = Convert.ToInt32(m.Substring(4)) + 1;
                if (n <= 9)
                    m = "MLSP00" + n;
                else
                    if (n <= 99)
                    m = "MLSP0" + n;
                else
                    m = "MLSP" + n;
            }
            catch
            {
                m = "MLSP001";
            }
            textBoxX1.Text = m;
        }
        private void load_data()
        {
            functions.loaddatagridview(dataGridViewX1, "SELECT * FROM Tbl_LoaiSanPham");
            dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewX1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            load_data();
            textBoxX2.Enabled = false;
            textBoxX1.Enabled = false;
           

            textBoxX2.Text = "";
            textBoxX1.Text = "";
        

            buttonX2.Enabled = false;
            buttonX3.Enabled = false;
            buttonX4.Enabled = false;
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Tanga();
            textBoxX2.Enabled = true;
           

            buttonX2.Enabled = true;
            buttonX3.Enabled = true;
            buttonX4.Enabled = true;
            buttonX5.Enabled = true;
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text == "" || textBoxX2.Text == "")
            {
                MessageBox.Show("Chưa Nhập Thông Tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string insert = "Insert into Tbl_LoaiSanPham values(N'" + textBoxX1.Text + "',N'" + textBoxX2.Text + "')";
                functions.thucthisql(insert);
                MessageBox.Show("Thêm Mới Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
                Form2_Load(sender, e);
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
                string update = "UPDATE Tbl_LoaiSanPham SET TenLoaiSanPham=N'" + textBoxX2.Text + "'WHERE MaLoaiSanPham=N'" + textBoxX1.Text + "'";
                functions.thucthisql(update);
                MessageBox.Show("Cập Nhật Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
                Form2_Load(sender, e);
            }
            
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewX1.Rows[e.RowIndex];
                textBoxX1.Text = row.Cells[0].Value.ToString();
                textBoxX2.Text = row.Cells[1].Value.ToString();
            }
            textBoxX2.Enabled = true;

            buttonX2.Enabled = true;
            buttonX3.Enabled = true;
            buttonX4.Enabled = true;
            buttonX5.Enabled = true;
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
                    sql = "DELETE Tbl_LoaiSanPham WHERE MaLoaiSanPham=N'" + textBoxX1.Text + "'";
                    functions.thucthisql(sql);
                    MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa Không Thành Công Thông Tin Mã Loại Sản Phẩm Này Đã Tồn Tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            load_data();
            Form2_Load(sender, e);
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            Form2_Load(sender, e);
        }

        
    }
}
