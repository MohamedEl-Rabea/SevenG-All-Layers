using sevenG_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sevenG.Design
{
    public partial class ProcessDesign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadMainOrders();
                DRMainOrders_SelectedIndexChanged(sender, e);
                if (Session["attOrderId"] != null)
                {
                    DRMainOrders.SelectedValue=Session["MOrderID"].ToString();
                   
                }

            }
        }

        private void loadMainOrders()
        {
            DataSet ds = OperationBL.loadMainOrderDesign((Convert.ToString(Application["strDBConn"])));
            DRMainOrders.DataSource = ds.Tables[0];
            DRMainOrders.DataBind();
            //if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
            //{
            //    LBLError.Visible = true;
            //    LBLError.Text = "No orders found";
            //    DRMainOrders.DataSource = null;

            //}
            //else
            //{

            //    DRMainOrders.DataSource = ds.Tables[0];
            //}

        }

        protected void DRMainOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            LBLError.Visible = false;
            try
            {
                Session["MOrderID"] = DRMainOrders.SelectedValue.ToString();
                DataSet ds = OperationBL.getMainOrderCustomer((Convert.ToString(Application["strDBConn"])), int.Parse(Session["MOrderID"].ToString()));
                TXTCustomer.Text = ds.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString();
                TxtDate.Text = ds.Tables[0].Rows[0]["MAIN_ORDER_DATE"].ToString();
                Session["CustomerNo"] = ds.Tables[0].Rows[0]["CUSTOMER_ID"].ToString();
                loadItems();
            }
            catch
            {
                LBLError.Text = "No orders found";
            }
        }

        private void loadItems()
        {
            DataSet ds = OperationBL.loadInvRep((Convert.ToString(Application["strDBConn"])), int.Parse(Session["MOrderID"].ToString()), int.Parse(Session["CustomerNo"].ToString()));
            GrdOrders.DataSource = ds.Tables[0];
            GrdOrders.DataBind();
        }

        



        protected void GrdOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow selectedRow = GrdOrders.Rows[index];
            TableCell ordeID = selectedRow.Cells[0];
            Session["attOrderId"] = ordeID.Text.ToString();
            if (e.CommandName == "reLoad")
            {
                Response.Redirect("LoadAtt.aspx");
            }
            if (e.CommandName == "download")
            {
                DataSet dsAtt = ProductsBL.getOrdProAtt((Convert.ToString(Application["strDBConn"])), int.Parse(Session["attOrderId"].ToString()));
                if (dsAtt.Tables[0].Rows[0]["ret"].ToString() == "1")
                {

                    //DOWNLOAD 1 FILE
                    string fileNmae = dsAtt.Tables[0].Rows[0]["ATT_FILE_NAME"].ToString();
                    Response.ContentType = "Application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileNmae);
                    Response.TransmitFile(Server.MapPath("~/ProductsAttachment/Order Id" + Session["attOrderId"].ToString() + "/" + fileNmae));
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    LBLError.Visible = true;
                    LBLError.Text = "No attatchment is found";
                }
            }
        }



        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = OperationBL.updateOrderDesign((Convert.ToString(Application["strDBConn"])), int.Parse(Session["MOrderID"].ToString()));

                if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
                {
                    LBLError.Visible = true;
                    LBLError.Text = "Please try again";

                }
                else
                {
                    LBLError.Visible = true;
                    LBLError.Text = "The Design is Updated Suceesfully ...";


                }
            }
            catch
            {
                LBLError.Visible = true;
                LBLError.Text = "No order is found";
            }

        }

        
    }
     
}