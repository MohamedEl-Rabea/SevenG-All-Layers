using sevenG_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sevenG.Order
{
    public partial class CheckQuot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCustomers();
                DRLCustName_SelectedIndexChanged(sender, e);
            }
               
        
        }

        private void loadCustomers()
        {
            DataSet ds = SettingBL.loadCustomers((Convert.ToString(Application["strDBConn"])), Session["userName"].ToString());
            DRLCustName.DataSource = ds.Tables[0];
            DRLCustName.DataBind();
        }

        protected void DRLCustName_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["CustomerID"] = DRLCustName.SelectedValue.ToString();
            LBLError.Visible = false;
            loadQuotations();
        }

        private void loadQuotations()
        {
            DataSet ds = OperationBL.loadQuotations((Convert.ToString(Application["strDBConn"])), int.Parse(DRLCustName.SelectedValue.ToString()));

            
                GrdQuotation.DataSource = null;
           
                GrdQuotation.DataSource = ds.Tables[0];
            
            GrdQuotation.DataBind();
        }

        protected void radApproveRej_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radApproveRej.Items[1].Selected)           //reject
            {
                divReject.Visible = true;
                divPayment.Visible = false;
            }
            else                                          //approve
            {
                divReject.Visible = false;
                divPayment.Visible = true;
            }
        }
        protected void save_Click(object sender, EventArgs e)
        {
            int payMethod = 3;
            if (radApproveRej.Items[0].Selected)
            {
                payMethod = int.Parse(RdPayment.SelectedValue.ToString());
            }
            else
            {
                payMethod = 3;
            }
                
            DataSet ds = OperationBL.updateQuotation((Convert.ToString(Application["strDBConn"])), int.Parse(DRLCustName.SelectedValue.ToString()), txtQuot.Text, txtResonRej.Text, int.Parse(radApproveRej.SelectedValue.ToString()), payMethod);
            LBLError.Visible = true;
            if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
            {
                LBLError.Text = "This Quotation not updated yet ,please try again";


            }
            else
            {
                LBLError.Text = "The Quotation status is rejected successfully ..";
                if (radApproveRej.Items[0].Selected)            // invoice
                {

                    Session["invCode"] = ds.Tables[0].Rows[0]["invoice"].ToString();
                    Session["quotation"] = ds.Tables[0].Rows[0]["quot"].ToString();
                    Session["InvMainOrderId"] = ds.Tables[0].Rows[0]["invMOID"].ToString();
                    Session["MainOrderID"] = ds.Tables[0].Rows[0]["MainOrder"].ToString();
                    Response.Redirect("PrintInvoice.aspx");
                }
               
            }
        }

        protected void GrdQuotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LBLError.Visible = false;
            txtResonRej.Text = "";
            txtQuot.Text = GrdQuotation.SelectedRow.Cells[0].Text;
            Session["txtQuotCode"] = txtQuot.Text.ToString();
            radApproveRej_SelectedIndexChanged( sender,  e);
        }

        protected void GrdQuotation_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void RdPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

       

        protected void AttachmentFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            string filename = e.FileName;

            DirectoryInfo strUploadPath = new DirectoryInfo(Server.MapPath("~/Order/QuotationsAttachment"));
            string RequestFolder = "Quot Id" + Session["txtQuotCode"].ToString();
            DirectoryInfo Subdirectory = strUploadPath.CreateSubdirectory(RequestFolder);
            AttachmentFileUpload1.SaveAs(@Subdirectory + "/" + filename);
            DataSet dsAtt = ProductsBL.InsertQuotAtt((Convert.ToString(Application["strDBConn"])), Session["txtQuotCode"].ToString(), filename, RequestFolder);

        }
    }

    }
