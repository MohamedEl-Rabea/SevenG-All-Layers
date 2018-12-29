using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sevenG.Order
{
    public partial class PrintQuot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int mainOrderId = int.Parse(Session["MainOrderID"].ToString());
                int CustomerID = int.Parse(Session["CustomerID"].ToString());
                DataTable dt1 = GetData(mainOrderId, CustomerID, "loadQuotOrdersRep");
                DataTable dt2 = GetData(mainOrderId, CustomerID, "loadQuotRep");
                ReportDataSource rds1 = new ReportDataSource("DataSet1", dt1);
                ReportDataSource rds2 = new ReportDataSource("DataSet2", dt2);
                ReportViewer1.LocalReport.DataSources.Add(rds1);
                ReportViewer1.LocalReport.DataSources.Add(rds2);
                //path
                ReportViewer1.LocalReport.ReportPath = "Order/Quotation.rdlc";

                ReportViewer1.LocalReport.Refresh();
                Btndownload_Click(sender, e);
            }
           
        }

        private DataTable GetData(int mainOrderId, int customerID, string procName)
        {
            DataTable dt = new DataTable();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[1].ToString();
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(procName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MAIN_ORDER_ID", SqlDbType.Int).Value = mainOrderId;
                cmd.Parameters.Add("@CUSTOMER_ID", SqlDbType.Int).Value = customerID;

                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                adb.Fill(dt);

            }
            return dt;
        }

        protected void Btndownload_Click(object sender, EventArgs e)

        {
            Session["MainOrderID"] = null;
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            byte[] Bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            DirectoryInfo strUploadPath = new DirectoryInfo(Server.MapPath("~/Order"));
            //int Month = DateTime.Parse(txtDate.Text).Month;

            string RequestFolder = "QuotationReports";
            DirectoryInfo Subdirectory = strUploadPath.CreateSubdirectory(RequestFolder);

            string fileName = Session["quotCode"] + @".pdf";

            Directory.CreateDirectory(Path.GetDirectoryName(@Subdirectory + "/" + fileName));
            string FileFullpath = @Subdirectory + "/" + fileName;

            using (FileStream stream = new FileStream(FileFullpath, FileMode.Create))
            {
                stream.Write(Bytes, 0, Bytes.Length);
            }

            Session["FileFullpath"] = "~/Order/QuotationReports/" + Session["quotCode"] + @".pdf";
            Response.ContentType = "Application/.pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.TransmitFile(Server.MapPath(Session["FileFullpath"].ToString()));
            Response.Flush();
            Response.End();
        }

      
    }
}