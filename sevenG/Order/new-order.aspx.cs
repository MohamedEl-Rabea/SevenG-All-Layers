using sevenG_BL;
using System;
using System.Data;

namespace sevenG.Order
{
    public partial class new_order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //loadCustomers();
                //loadDivisions();
            }
        }
        private void loadDivisions()
        {
            DataSet ds = SettingBL.loadDivisions((Convert.ToString(Application["strDBConn"])));
            DRLDivision.DataSource = ds.Tables[0];
            DRLDivision.DataBind();
        }

        private void loadCustomers()
        {
            DataSet ds = SettingBL.loadCustomers((Convert.ToString(Application["strDBConn"])), Session["userName"].ToString());
            DRLCustName.DataSource = ds.Tables[0];
            DRLCustName.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = OperationBL.insertMainOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLCustName.SelectedValue.ToString()), Session["userName"].ToString(), int.Parse(DRLDivision.SelectedValue.ToString()));
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
                Response.Redirect("../Products/product-navigation-panel.aspx");
            }
        }
    }
}