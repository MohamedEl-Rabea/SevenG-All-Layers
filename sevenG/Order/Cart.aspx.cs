using sevenG_BL;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace sevenG.Order
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CustomerID"] != null)
                {
                    getCartOrders();
                }
                txtAddtional_TextChanged(sender, e);
            }
        }

        private void getCartOrders()
        {
            int total = 0;
            DataSet ds = OperationBL.getCartOrders((Convert.ToString(Application["strDBConn"])), int.Parse(Session["CustomerID"].ToString()));
            GrdOrders.DataSource = ds.Tables[0];
            GrdOrders.DataBind();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                total = int.Parse(ds.Tables[0].Rows[i]["TOTAL_PRICE"].ToString()) + total;
            }
            TxtPrice.Text = total.ToString();

        }
        protected void GrdOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["orderId"] = GrdOrders.DataKeys[GrdOrders.SelectedRow.RowIndex]["ORDER_ID"].ToString();
            DataSet ds = ProductsBL.deleteOrder((Convert.ToString(Application["strDBConn"])), int.Parse(Session["orderId"].ToString()),
                                                int.Parse(Session["CustomerID"].ToString()));

            if (ds.Tables[0].Rows[0]["ret"].ToString() == "1")
            {
                getCartOrders();
                Response.Redirect("../Order/Cart.aspx");
            }
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
            getCartOrders();
        }

        protected void finish_Click(object sender, EventArgs e)
        {
            //int sum = 0;
            foreach (GridViewRow row in GrdOrders.Rows)

            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    int addtional = int.Parse((row.Cells[7].FindControl("txtAddtional") as TextBox).Text);
                    int orderId = int.Parse(row.Cells[1].Text);
                   string type =row.Cells[2].Text;
                  
                        DataSet ds1 = OperationBL.editOrder((Convert.ToString(Application["strDBConn"])), orderId, addtional ,type);
                    
                    //sum = sum + int.Parse((row.Cells[7].FindControl("txtAddtional") as TextBox).Text);
                }
            }
            //txtAdd.Text = sum.ToString();
            DataSet ds = OperationBL.updateMainOrder((Convert.ToString(Application["strDBConn"])), int.Parse(Session["MainOrderID"].ToString()), int.Parse(Session["CustomerID"].ToString()),
                 int.Parse(radQuotInv.SelectedValue.ToString()), float.Parse(TxtPrice.Text), float.Parse(txtTax.Text), float.Parse(txtAdd.Text), int.Parse(txtDiscount.Text), float.Parse(TxtTotal.Text));

            if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
            {
                LBLError.Visible = true;
                LBLError.Text = "This order is Added Before";

            }
            else
            {
                LBLError.Visible = true;
                LBLError.Text = "The order is saved ...";

                if (radQuotInv.Items[0].Selected)           //quotation
                {
                    Session["quotCode"] = ds.Tables[0].Rows[0]["quot"].ToString();
                    Response.Redirect("PrintQuot.aspx");
                }
                else                                      // invoice
                {
                    
                    Session["invCode"] = ds.Tables[0].Rows[0]["invoice"].ToString();
                    Session["quotation"] = ds.Tables[0].Rows[0]["quot"].ToString();
                    Session["InvMainOrderId"] = ds.Tables[0].Rows[0]["invMOID"].ToString();
                  
                    Response.Redirect("PrintInvoice.aspx");
                }
            }
        }

        protected void radQuotInv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {

            txtAdd_TextChanged(sender, e);
        }

        protected void txtAdd_TextChanged(object sender, EventArgs e)
        {
            TxtTotal.Text = (int.Parse(TxtPrice.Text) + int.Parse(txtTax.Text) + int.Parse(txtAdd.Text) - (int.Parse(txtDiscount.Text) * (int.Parse(TxtPrice.Text)+ int.Parse(txtAdd.Text)) / 100)).ToString();
        }

        protected void txtAddtional_TextChanged(object sender, EventArgs e)
        {
            

            int sum= 0;
            foreach (GridViewRow row in GrdOrders.Rows)

            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                   
                    int addtional = 0;
                    //int sumRows = 0;
                    bool res1 = int.TryParse((row.Cells[7].FindControl("txtAddtional") as TextBox).Text,out addtional);
                  
                    //int orderId = int.Parse(row.Cells[1].Text);
                    //DataSet ds1 = OperationBL.editOrder((Convert.ToString(Application["strDBConn"])), orderId, addtional);

                    //bool res2= int.TryParse((row.Cells[7].FindControl("txtAddtional") as TextBox).Text,out sumRows);
                    sum += addtional;
                }
            }
            txtAdd.Text = sum.ToString();
            txtDiscount_TextChanged(sender, e);
        }
    }
}