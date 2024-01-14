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
    public partial class Form10 : Form
    {
        Functions functions = new Functions();
        public Form10()
        {
            InitializeComponent();
        }
        public SqlConnection getcon()
        {
            return new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyDonHang;Integrated Security=True");
        }
        private void Form10_Load(object sender, EventArgs e)
        {
           
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            string s = " SELECT * FROM Tbl_HoaDon Where  NgayDatHang='" + dateTimeInput1.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, getcon());

            DataSet ds = new DataSet();
            da.Fill(ds);
            reportViewer1.Reset();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.Report.Report2.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            Microsoft.Reporting.WinForms.ReportDataSource newDataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dt);
            reportViewer1.LocalReport.DataSources.Add(newDataSource);
            reportViewer1.RefreshReport();
        }
    }
}
