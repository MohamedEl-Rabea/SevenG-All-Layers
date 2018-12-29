using sevenG_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sevenG._7Gsetting
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                loadMainOrders();
            }
        }

        private void loadMainOrders()
        {
            DataSet ds = OperationBL.loadMainOrders((Convert.ToString(Application["strDBConn"])), Session["userName"].ToString());
            if (ds.Tables[0].Rows[0]["ret"].ToString() == "1")
            {
                Session["quotation"] = ds.Tables[0].Rows[0]["QUOTATION_CODE"].ToString();
                GrdOrders.DataSource = ds.Tables[0];
                
            }
            else
            {
                LBLError.Visible = true;
                LBLError.Text = "No orders found";
                GrdOrders.DataSource = null;
            }
            GrdOrders.DataBind();
        }

        protected void GrdOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["InvMainOrderId"] = GrdOrders.SelectedRow.Cells[2].Text;
            Session["invCode"] = GrdOrders.SelectedRow.Cells[3].Text;
            Response.Redirect("../Order/PrintInvoice.aspx");
        }

        public void GrdOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int mainOrderId = int.Parse(GrdOrders.DataKeys[e.Row.RowIndex].Value.ToString());
                var gvOrders = (GridView)e.Row.FindControl("gvOrders");
                DataSet ds = OperationBL.loadInvRep((Convert.ToString(Application["strDBConn"])), mainOrderId, int.Parse(Session["CustomerID"].ToString()));
                gvOrders.DataSource = ds.Tables[0];
                gvOrders.DataBind();
               

            }
        }

        public string MyNewRow(object mainOrderId)
        {
            return String.Format(@"</td></tr><tr id ='tr{0}' class='collapsed-row'>
        <td></td><td colspan='100' style='padding:0px; margin:0px;'>", mainOrderId);
        }

        protected void GrdOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdOrders.PageIndex = e.NewPageIndex;
            loadMainOrders();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
           
        }

        protected void BtnOrder_Click(object sender, EventArgs e)
        {


        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void GrdOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow selectedRow = GrdOrders.Rows[index];


            if (e.CommandName == "reOrder")
            {
                DataSet ds = OperationBL.insertMainOrder((Convert.ToString(Application["strDBConn"])), int.Parse(Session["CustomerID"].ToString()), Session["userName"].ToString(), 100);
                Session["MainOrderID"] = ds.Tables[0].Rows[0]["ret"].ToString();
                
                var gvOrders = (GridView)selectedRow.FindControl("gvOrders");
                foreach (GridViewRow row in gvOrders.Rows)
                {
                    CheckBox chk;
                    chk = (CheckBox)row.FindControl("chkSelect");
                    if (chk != null && chk.Checked)
                    {
                        int orderId = Convert.ToInt32(gvOrders.DataKeys[row.RowIndex].Value);                    
                        DataSet ds2 = OperationBL.insertReOrder((Convert.ToString(Application["strDBConn"])), Session["MainOrderID"].ToString(), int.Parse(Session["CustomerID"].ToString()), orderId);                      
                    }

                }
                Response.Redirect("../Order/Cart.aspx");

            }

           
        }

        protected void Checkbox2_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        protected void chkb1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GrdOrders.Rows)
            {
                var gvOrders = (GridView)row.FindControl("gvOrders");
                CheckBox ChkBoxHeader = (CheckBox)gvOrders.HeaderRow.FindControl("chkb1");
                foreach (GridViewRow row1 in gvOrders.Rows)
                {
                    CheckBox ChkBoxRows = (CheckBox)row1.FindControl("chkSelect");
                    if (ChkBoxHeader.Checked == true)
                    {
                        ChkBoxRows.Checked = true;
                    }
                    else
                    {
                        ChkBoxRows.Checked = false;
                    }
                }
            }
        }
    }
}