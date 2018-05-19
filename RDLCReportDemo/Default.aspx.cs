using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //set Processing Mode of Report as Local  
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //set path of the Local report  
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc");
            //creating object of DataSet dsEmployee and filling the DataSet using SQLDataAdapter  
            EmployeeDataSet employeeDbSet = new EmployeeDataSet();
            string connectionString = "Data Source=DESKTOP-U8DC7F3;Initial Catalog=schoolDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Employee", con);
            adapt.Fill(employeeDbSet, "DataTable1");
            con.Close();
            //Providing DataSource for the Report  
            ReportDataSource rds = new ReportDataSource("EmployeeDataSet", employeeDbSet.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            //Add ReportDataSource  
            ReportViewer1.LocalReport.DataSources.Add(rds);
        }
    }
}