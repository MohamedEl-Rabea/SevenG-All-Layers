using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sevenG;
using System.Data.SqlClient;

namespace sevenG.Order
{
    public partial class PrintInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                ReportViewer1.Reset();
                string invCode = Session["invCode"].ToString();
                string quotCode = Session["quotation"].ToString();
                int mainOrderId= int.Parse(Session["InvMainOrderId"].ToString());
                int CustomerID = int.Parse(Session["CustomerID"].ToString());
                DataTable dt1 = GetData(mainOrderId, CustomerID, "loadInvRep");
                DataTable dt2 = GetData(mainOrderId, CustomerID, "loadQuotRep");
                ReportDataSource rds1 = new ReportDataSource("DataSet1", dt1);
                ReportDataSource rds2 = new ReportDataSource("DataSet2", dt2);
                ReportViewer1.LocalReport.DataSources.Add(rds1);
                ReportViewer1.LocalReport.DataSources.Add(rds2);
                //path
                ReportViewer1.LocalReport.ReportPath = "Order/Invoice.rdlc";
               
                ReportParameter[] rptParms1 = new ReportParameter[] {
                new ReportParameter("invCode",invCode)};
                ReportParameter[] rptParms2 = new ReportParameter[] {
                new ReportParameter("quotCode",quotCode)};
                ReportViewer1.LocalReport.SetParameters(rptParms1);
                ReportViewer1.LocalReport.SetParameters(rptParms2);

                ReportViewer1.LocalReport.Refresh();
                Btndownload_Click(sender, e);
                //Response.Redirect("Cart.aspx");
                //ReportViewer1.LocalReport.Refresh();
            }
        }
        private DataTable GetData(int mainOrderId, int CustomerID, string procName)
        {
            DataTable dt = new DataTable();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[1].ToString();
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(procName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MAIN_ORDER_ID", SqlDbType.Int).Value = mainOrderId;
                cmd.Parameters.Add("@CUSTOMER_ID", SqlDbType.Int).Value = CustomerID;

                SqlDataAdapter adb = new SqlDataAdapter(cmd);
                adb.Fill(dt);

            }
            return dt;
        }
        protected void Btndownload_Click(object sender, EventArgs e)
        {
            Session["MainOrderID"] = null;
            // Variables
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;


           
            byte[] Bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            DirectoryInfo strUploadPath = new DirectoryInfo(Server.MapPath("~/Order"));
            //int Month = DateTime.Parse(txtDate.Text).Month;

            string RequestFolder = "Invoices";
            DirectoryInfo Subdirectory = strUploadPath.CreateSubdirectory(RequestFolder);

            string fileName = Session["invCode"] + @".pdf";

            Directory.CreateDirectory(Path.GetDirectoryName(@Subdirectory + "/" + fileName));
            string FileFullpath = @Subdirectory + "/" + fileName;

            using (FileStream stream = new FileStream(FileFullpath, FileMode.Create))
            {
                stream.Write(Bytes, 0, Bytes.Length);
            }

            Session["FileFullpath"] = "~/Order/Invoices/" + Session["invCode"] + @".pdf";
            Response.ContentType = "Application/.pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.TransmitFile(Server.MapPath(Session["FileFullpath"].ToString()));
            Response.Flush();
            Response.End();
            
        }
    }
}