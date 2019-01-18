using sevenG_BL;
using System;
using System.Data;

namespace sevenG.Order
{
    public partial class new_order : System.Web.UI.Page
    {
        int orderType = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //loadCustomers();
            }
        }

        private void loadCustomers()
        {
            DataSet ds = SettingBL.loadCustomers((Convert.ToString(Application["strDBConn"])), Session["userName"].ToString());
            DRLCustName.DataSource = ds.Tables[0];
            DRLCustName.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = OperationBL.insertMainOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLCustName.SelectedValue.ToString()), Session["userName"].ToString(), 100);
            LBLError.Visible = true;
            if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
            {
                divErrMsg.Visible = true;
                LBLError.Text = "This Order is saved before ,please edit on it";
            }
            else
            {
                LBLError.Text = "The order is saved successfully , please continue the order details ..";
                Session["MainOrderID"] = ds.Tables[0].Rows[0]["ret"].ToString();
                Session["CustomerID"] = ds.Tables[0].Rows[0]["cust"].ToString();

                if (orderType == 1)
                {

                    Response.Redirect("../Products/product-navigation-panel.aspx");

                }

                else if (orderType == 2)
                {
                    Response.Redirect("../Order/custom-order.aspx");

                }
                else
                {
                    Response.Redirect("../Order/wholesale-order.aspx");
                }


            }
        }

        protected void DRLOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderType = int.Parse(DRLOrderType.SelectedValue);
        }
    }
}