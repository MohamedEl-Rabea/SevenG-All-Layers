using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sevenG_BL;
using System.Data;
using System.Net;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace sevenG.Operation
{
    public partial class Operate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            DataSet ds = OperationBL.loadOrders((Convert.ToString(Application["strDBConn"])));
            
            GrdOrders.DataSource = ds.Tables[0];
            GrdOrders.DataBind();

        }

        protected void GrdOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='Lavender';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void GrdOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GrdOrders.PageIndex = e.NewPageIndex;
            LoadOrders();

        }
       
        protected void GrdOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Process.Visible = true;
            BtnDownLoad.Visible = true;
            BtnPrint.Visible = true;
            LBLError.Visible = false;
            loadOrderDetail();
            DataSet ds = OperationBL.getOperation((Convert.ToString(Application["strDBConn"])), int.Parse(TXTOrderId.Text));
            TXTExpSheets.Text = ds.Tables[0].Rows[0]["EXPECTED_S_SHEETS"].ToString();
            TXTExpPapers.Text = ds.Tables[0].Rows[0]["EXPECTED_B_SHEETS"].ToString();
            TXTPrStart.Text = ds.Tables[0].Rows[0]["STR_COUNTER"].ToString();
            TXTPrStart2.Text = ds.Tables[0].Rows[0]["STR_COUNTER2"].ToString();
            TXTPrStart3.Text = ds.Tables[0].Rows[0]["STR_COUNTER3"].ToString();

            DataSet ds1 = ProductsBL.loadOrderDetails((Convert.ToString(Application["strDBConn"])), int.Parse(TXTOrderId.Text));
            Session["InvMainOrderId"] = GrdOrders.SelectedRow.Cells[10].Text;
            Session["invCode"] = ds1.Tables[0].Rows[0]["INVOICE_CODE"].ToString();
            Session["quotation"] = ds1.Tables[0].Rows[0]["QUOTATION_CODE"].ToString();
            Session["CustomerID"] = ds1.Tables[0].Rows[0]["CUSTOMER_ID"].ToString();

            if (ds.Tables[0].Rows[0]["RET"].ToString() == "1")
            {
                cover.Visible = true;
                //coProcess.Visible = true;
                loadBookDetails();
                DataSet ds2 = OperationBL.getSubOperation((Convert.ToString(Application["strDBConn"])), int.Parse(TXTOrderId.Text));
                txtCoExpSheet.Text = ds2.Tables[0].Rows[0]["EXPECTED_S_SHEETS"].ToString();
                txtCoExpPage.Text = ds2.Tables[0].Rows[0]["EXPECTED_B_SHEETS"].ToString();
                txtCoStsPrint.Text = ds2.Tables[0].Rows[0]["CO_STR_COUNTER"].ToString();
                txtCoStsPrint2.Text = ds2.Tables[0].Rows[0]["CO_STR_COUNTER2"].ToString();
                txtCoStsPrint3.Text = ds2.Tables[0].Rows[0]["CO_STR_COUNTER3"].ToString();
            }
            else
            {
                cover.Visible = false;
                Process.Visible = true;
                
            }
        }

        private void loadOrderDetail()
        {
            TXTOrderId.Text = GrdOrders.SelectedRow.Cells[0].Text;
            TXTProd.Text = GrdOrders.SelectedRow.Cells[1].Text;
            TXTPaperCode.Text = GrdOrders.SelectedRow.Cells[2].Text;
            TXTMaterial.Text = GrdOrders.SelectedRow.Cells[3].Text;
            TXTSize.Text = GrdOrders.SelectedRow.Cells[4].Text;
            TXTLamination.Text = GrdOrders.SelectedRow.Cells[5].Text;
            TXTSide.Text = GrdOrders.SelectedRow.Cells[6].Text;
            TXTPrinter.Text = GrdOrders.SelectedRow.Cells[7].Text;
            TXTQuantity.Text = GrdOrders.SelectedRow.Cells[8].Text;

            
        }

        private void loadBookDetails()
        {
            DataSet ds = OperationBL.loadBookDetails((Convert.ToString(Application["strDBConn"])), int.Parse(GrdOrders.SelectedRow.Cells[0].Text));
            TXTQuantity.Text = ds.Tables[0].Rows[0]["QUANTITY"].ToString();

            TxtBookType.Text = ds.Tables[0].Rows[0]["BOOK_TYPE"].ToString();
            TxtBookBinding.Text = ds.Tables[0].Rows[0]["BOOK_BINDING"].ToString();
            TxtNoPages.Text = ds.Tables[0].Rows[0]["NO_BOOKPAGES"].ToString();
            TxtCoSpine.Text = ds.Tables[0].Rows[0]["BOOK_SPINE"].ToString();
            txtCoPaperCode.Text = ds.Tables[0].Rows[0]["PAPER_CODE"].ToString();
            txtCoPaper.Text = ds.Tables[0].Rows[0]["PAPER_NAME"].ToString();
            txtCoSize.Text = ds.Tables[0].Rows[0]["SIZE_NAME"].ToString();
            txtCoLam.Text = ds.Tables[0].Rows[0]["LAMINATION_NAME"].ToString();
            txtCoSide.Text = ds.Tables[0].Rows[0]["COVER_NO_SIDES"].ToString();
            TXTCoPrinter.Text = ds.Tables[0].Rows[0]["PRINTER_TYPE"].ToString();
            txtCoQnt.Text= ds.Tables[0].Rows[0]["QUANTITY"].ToString();
            if(ds.Tables[0].Rows[0]["ORDER_STATUS"].ToString()=="-1")
            {
                coProcess.Visible = true;
                Process.Visible = false;
            }
            else if(ds.Tables[0].Rows[0]["ORDER_STATUS"].ToString() == "-3")
            {
                coProcess.Visible = true;
                Process.Visible = false;
            }
            else
            {
                coProcess.Visible = false;
                Process.Visible = true;
            }

        }

        protected void DRLPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DrpCoPrinterType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Process_Click(object sender, EventArgs e)
        {
            if (TXTPrStart2.Text == null)
            {
                TXTPrStart2.Text = "0";
            }
            if (TXTPrStart3.Text == null)
            {
                TXTPrStart3.Text = "0";
            }
            DataSet ds = OperationBL.insertProcessOperation((Convert.ToString(Application["strDBConn"])), int.Parse(TXTOrderId.Text), int.Parse(TXTPrStart.Text), int.Parse(TXTPrStart2.Text), int.Parse(TXTPrStart3.Text));
           
            LBLError.Visible = true;
            if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
            {
                LBLError.Text = "This operation is saved before";
                
            }
            else
            {
                LBLError.Text = "The operation is in process now";
                LoadOrders();
            }
            Process.Visible = false;
        }

        protected void DRPPrinterMach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        protected void coProcess_Click(object sender, EventArgs e)

        {
            if(txtCoStsPrint2.Text==null)
            {
                txtCoStsPrint2.Text = "0";
            }
            if (txtCoStsPrint3.Text == null)
            {
                txtCoStsPrint3.Text = "0";
            }
            DataSet ds = OperationBL.insertCoverProcessOperation((Convert.ToString(Application["strDBConn"])), int.Parse(TXTOrderId.Text), int.Parse(txtCoStsPrint.Text), int.Parse(txtCoStsPrint2.Text), int.Parse(txtCoStsPrint3.Text));

            LBLError.Visible = true;
            if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
            {
                LBLError.Text = "This operation is saved before";
                Process.Visible = false;
            }
            else
            {
                LBLError.Text = "The operation is in process now";
                LoadOrders();
            }
            coProcess.Visible = false;
        }

        protected void BtnDownLoad_Click(object sender, EventArgs e)
        {

            DataSet dsAtt = ProductsBL.getOrdProAtt((Convert.ToString(Application["strDBConn"])), int.Parse(TXTOrderId.Text));
            if (dsAtt.Tables[0].Rows[0]["ret"].ToString() == "1")
            {

                //DOWNLOAD 1 FILE
                string fileNmae = dsAtt.Tables[0].Rows[0]["ATT_FILE_NAME"].ToString();
                Response.ContentType = "Application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileNmae);
                Response.TransmitFile(Server.MapPath("~/ProductsAttachment/Order Id" + TXTOrderId.Text + "/" + fileNmae));
                Response.Flush();
                Response.End();
            }
            else
            {
                LBLError.Visible = true;
                LBLError.Text = "No attatchment is found";
            }
        }

        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("../Order/PrintJobOrder.aspx");
        }
    }
}