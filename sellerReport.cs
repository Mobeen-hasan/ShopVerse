using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace dbprojtest
{
    public partial class sellerReport : Form
    {
        public sellerReport()
        {
            InitializeComponent();
        }
        public sellerReport(string a)
        {
            InitializeComponent();
            susn = a;
        }
        string susn;
        SqlConnection con = new SqlConnection("Data Source=MOBEEN\\SQLEXPRESS;Initial Catalog=dbproj;Integrated Security=True");
        

        private void sellerReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbprojDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dbprojDataSet.Product);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            

            con.Open();
            string q = "SELECT SellerID FROM Seller WHERE Email = @e";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@e", susn);
            string sid = cmd.ExecuteScalar().ToString();
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            q = 
@"SELECT  p.ProductName, AVG(r.Rating),
CASE 
WHEN AVG(r.Rating) >= 4 THEN 'Positive'
WHEN AVG(r.Rating) BETWEEN 2 AND 4 THEN 'Neutral'
     ELSE 'Negative'
END AS Sentiment
FROM Reviews r
JOIN Product p ON r.ProductID = p.ProductID
JOIN Seller s ON p.SellerID = s.SellerID
WHERE s.SellerID = '1'
GROUP BY p.ProductName
ORDER BY Sentiment DESC, AVG(r.Rating) DESC
";

                
                DataTable dt = new DataTable();
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@sid", sid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                

                
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\mobee\\source\\repos\\dbprojtest\\dbprojtest\\Report1.rdlc";
                reportViewer1.RefreshReport();
                this.productTableAdapter.Fill(this.dbprojDataSet.Product);
                con.Close();



        }
    }
}
