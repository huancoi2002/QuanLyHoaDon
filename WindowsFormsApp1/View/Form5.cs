using DevComponents.DotNetBar.Controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.View
{
    public partial class Form5 : Form
    {
        Functions functions = new Functions();
        public Form5()
        {
            InitializeComponent();
        }
       
        private void load_data()
        {

            functions.loaddatagridview(dataGridViewX1, "SELECT a.MaSanPham, b.TenSanPham, a.Soluong, b.GiaBan,a.Thanhtien FROM Tbl_ChiTietHoaDon AS a,Tbl_SanPham AS b WHERE a.MaDonHang = N'" + textBoxX2.Text + "' AND a.MaSanPham=b.MaSanPham");
            dataGridViewX1.AllowUserToAddRows = false;
            dataGridViewX1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        public void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT TongTien FROM Tbl_HoaDon WHERE MaDonHang = N'" + textBoxX2.Text + "'";
            textBoxX6.Text = Functions.GetFieldValues1(str);
            str = "SELECT NgayDatHang FROM Tbl_HoaDon WHERE MaDonHang = N'" + textBoxX2.Text + "'";
            dateTimeInput1.Text = Functions.ConvertDateTime(Functions.GetFieldValues1(str));
            str = "SELECT NgayGiaoHang FROM Tbl_HoaDon WHERE MaDonHang = N'" + textBoxX2.Text + "'";
            dateTimeInput2.Text = Functions.ConvertDateTime(Functions.GetFieldValues1(str));
            str = "SELECT MaKhachHang FROM Tbl_HoaDon WHERE MaDonHang = N'" + textBoxX2.Text + "'";
            comboBoxEx3.SelectedValue = Functions.GetFieldValues1(str);
            
        }
        void Setnull()
        {
            textBoxX2.Text = "";
            dateTimeInput1.Text = "";
            dateTimeInput2.Text = "";
            comboBoxEx1.Text = "";
            comboBoxEx2.Text = "";
            comboBoxEx3.Text = "";
            comboBoxEx4.Text = "";
            textBoxX3.Text = "";
            textBoxX6.Text = "";
            dataGridViewX1.DataSource = null;
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            dateTimeInput1.Enabled = false;
            dateTimeInput2.Enabled = false;
            comboBoxEx1.Enabled = false;
            comboBoxEx2.Enabled = false;
            comboBoxEx3.Enabled = false;
            comboBoxEx4.Enabled = false;
            textBoxX3.Enabled = false;
            buttonX2.Enabled = false;
            buttonX3.Enabled = false;
            buttonX4.Enabled = false;
            buttonX1.Enabled = true;
            dataGridViewX1.Enabled = false;
            Setnull();

            string sql;
            sql = "SELECT * from Tbl_KhachHang";
            Functions.FillCombo(sql, comboBoxEx3, "MaKhachHang", "HoTen");
            comboBoxEx3.SelectedIndex = -1;
            functions.thucthisql(sql);

            string sql1;
            sql1 = "SELECT * from Tbl_SanPham";
            Functions.FillCombo(sql1, comboBoxEx4, "MaSanPham", "TenSanPham");
            comboBoxEx4.SelectedIndex = -1;
            functions.thucthisql(sql1);

            


        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            textBoxX2.Text = Functions.CreateKey("MDH_");
            dateTimeInput1.Enabled = true;
            dateTimeInput2.Enabled = true;
            comboBoxEx1.Enabled = true;
            comboBoxEx2.Enabled = true;
            comboBoxEx3.Enabled = true;
            comboBoxEx4.Enabled = true;
            textBoxX3.Enabled = true;
            buttonX2.Enabled = true;
            buttonX1.Enabled = false;
            dataGridViewX1.Enabled = true;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dateTimeInput1.Text == "" || dateTimeInput2.Text == "" || comboBoxEx1.Text == "" || comboBoxEx2.Text == "" || comboBoxEx3.Text == ""|| comboBoxEx4.Text==""|| textBoxX3.Text == "")
            {
                MessageBox.Show("Vui lòng xin nhập đầy đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    string sql;
                    double sl, SLcon, tong = 0;
                    sql = "SELECT MaDonHang FROM Tbl_HoaDon WHERE MaDonHang=N'" + textBoxX2.Text + "'";
                    if (!Functions.CheckKey(sql))
                    {
                        sql = "INSERT INTO Tbl_HoaDon(MaDonHang,NgayDatHang,NgayGiaoHang,TinhTrangThanhToan,TinhTrangGiaoHang,MaKhachHang,TongTien) VALUES(N'"+textBoxX2.Text+"',N'"+dateTimeInput1.Value+ "',N'"+dateTimeInput2.Value+"',N'" + comboBoxEx1.Text + "',N'" + comboBoxEx2.Text + "',N'" + comboBoxEx3.SelectedValue.ToString() + "',N'"+textBoxX6.Text+"')";
                        functions.thucthisql(sql);

                    }
                    // Lưu thông tin của các sách
                    sql = "SELECT MaSanPham FROM Tbl_ChiTietHoaDon WHERE MaSanPham=N'" + comboBoxEx4.SelectedValue + "' AND MaDonHang = N'" + textBoxX2.Text.Trim() + "'";
                    if (Functions.CheckKey(sql))
                    {
                        MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxEx3.Focus();
                        return;
                    }
                    // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
                    sl = Convert.ToDouble(Functions.GetFieldValues1("SELECT SoLuongTon FROM Tbl_SanPham WHERE MaSanPham = N'" + comboBoxEx4.SelectedValue + "'"));
                    if (Convert.ToDouble(textBoxX3.Text) > sl)
                    {
                        MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxX3.Text = "";
                        textBoxX3.Focus();
                        return;
                    }
                    sql = "INSERT INTO Tbl_ChiTietHoaDon(MaDonHang,MaSanPham,SoLuong,DonGia,ThanhTien) VALUES(N'" + textBoxX2.Text.Trim() + "',N'" + comboBoxEx4.SelectedValue + "'," + textBoxX3.Text + "," + textBoxX4.Text + "," + textBoxX5.Text + ")";
                    Functions.RunSQL(sql);
                    load_data();
                    // Cập nhật lại số lượng của mặt hàng vào bảng 
                    SLcon = sl - Convert.ToDouble(textBoxX3.Text);
                    sql = "UPDATE Tbl_SanPham SET SoLuongTon =" + SLcon + " WHERE MaSanPham= N'" + comboBoxEx4.SelectedValue + "'";
                    Functions.RunSQL(sql);
                    //Cập nhật lại tổng tiền cho hóa đơn bán
                    tong = Convert.ToDouble(Functions.GetFieldValues1("SELECT sum(ThanhTien) FROM Tbl_ChiTietHoaDon WHERE MaDonHang = N'" + textBoxX2.Text + "'"));
                    textBoxX6.Text = tong.ToString();
                    sql = "UPDATE Tbl_HoaDon SET TongTien =" + textBoxX6.Text + " WHERE MaDonHang = N'" + textBoxX2.Text + "'";
                    functions.thucthisql(sql);

                    
                }
                catch
                {
                    MessageBox.Show("Thêm Mới Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if(comboBoxEx1.Text == "" || comboBoxEx2.Text == "")
            {
                MessageBox.Show(" Chọn lại tình trạng thanh toán , giao hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimeInput2.Enabled = true;
                comboBoxEx1.Enabled = true;
                comboBoxEx2.Enabled = true;
                
            }
            else
            {
                string update = "UPDATE Tbl_HoaDon SET  TinhTrangThanhToan=N'" + comboBoxEx1.Text + "',TinhTrangGiaoHang=N'" + comboBoxEx2.Text + "',NgayGiaoHang=N'"+dateTimeInput2.Value+"' WHERE MaDonHang=N'" + textBoxX2.Text + "'";
                functions.thucthisql(update);
                MessageBox.Show("Cập Nhật Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
                Setnull();


            }
           
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (textBoxX2.Text == "")
            {
                MessageBox.Show("Vui lòng xin nhập đầy đủ thông tin ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    double sl, slcon, slxoa;
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sql = "SELECT MaSanPham,SoLuong FROM Tbl_ChiTietHoaDon WHERE MaDonHang = N'" + textBoxX2.Text + "'";
                        DataTable tblHang = Functions.GetDataToTable(sql);
                        for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                        {
                            // Cập nhật lại số lượng cho các mặt hàng
                            sl = Convert.ToDouble(Functions.GetFieldValues1("SELECT SoLuongTon FROM Tbl_SanPham WHERE MaSanPham = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                            slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                            slcon = sl + slxoa;
                            sql = "UPDATE Tbl_SanPham SET SoLuongTon =" + slcon + " WHERE MaSanPham= N'" + tblHang.Rows[hang][0].ToString() + "'";
                            Functions.RunSQL(sql);
                        }

                        //Xóa chi tiết hóa đơn
                        sql = "DELETE Tbl_ChiTietHoaDon WHERE MaDonHang=N'" + textBoxX2.Text + "'";
                        Functions.RunSQL(sql);
                        //Xóa hóa đơn
                        sql = "DELETE Tbl_HoaDon WHERE MaDonHang=N'" + textBoxX2.Text + "'";
                        Functions.RunSQL(sql);
                        load_data();
                        Form5_Load(sender, e);

                    }
                }
                catch
                {
                    MessageBox.Show("Xóa Không Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dataGridViewX1.Enabled = true;
            }
        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg;
            if (textBoxX3.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(textBoxX3.Text);
            if (textBoxX4.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(textBoxX4.Text);
            tt = sl * dg;
            textBoxX5.Text = tt.ToString();
        }

        private void comboBoxEx4_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboBoxEx4.Text == "")
            {
                textBoxX4.Text = "";
            }
            // Khi chọn mã sách thì các thông tin về hàng hiện ra
            str = "SELECT GiaBan FROM Tbl_SanPham WHERE MaSanPham =N'" + comboBoxEx4.SelectedValue + "'";
            textBoxX4.Text = Functions.GetFieldValues1(str);
        }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            string MaHangxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (dataGridViewX1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dataGridViewX1.CurrentRow.Cells["MaSanPham"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(dataGridViewX1.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dataGridViewX1.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE Tbl_ChiTietHoaDon WHERE MaDonHang=N'" + textBoxX2.Text + "' AND MaSanPham = N'" + MaHangxoa + "'";
                Functions.RunSQL(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(Functions.GetFieldValues1("SELECT SoLuongTon FROM Tbl_SanPham WHERE MaSanPham = N'" + MaHangxoa + "'"));
                slcon = sl + SoLuongxoa;
                sql = "UPDATE Tbl_SanPham SET SoLuongTon =" + slcon + " WHERE MaSanPham= N'" + MaHangxoa + "'";
                Functions.RunSQL(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(Functions.GetFieldValues1("SELECT TongTien FROM Tbl_HoaDon WHERE MaDonHang = N'" + textBoxX2.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE Tbl_HoaDon SET TongTien =" + tongmoi + " WHERE MaDonHang = N'" + textBoxX2.Text + "'";
                Functions.RunSQL(sql);
                textBoxX6.Text = tongmoi.ToString();
                load_data();
                dataGridViewX1.Enabled = true;
            }
        }

        private void comboBoxEx5_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaDonHang FROM Tbl_HoaDon", comboBoxEx5, "MaDonHang", "MaDonHang");
            comboBoxEx3.SelectedIndex = -1;
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (comboBoxEx5.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxEx3.Focus();
                return;
            }
            textBoxX2.Text = comboBoxEx5.Text;
            LoadInfoHoaDon();
            load_data();
            comboBoxEx5.SelectedIndex = -1;
            comboBoxEx3.Enabled = false;
            dateTimeInput1.Enabled = false;
            buttonX1.Enabled = false;
            buttonX3.Enabled = true;
            buttonX4.Enabled = true;
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            Form5_Load(sender, e);
            dataGridViewX1.DataSource = null;
        }
    }
}
