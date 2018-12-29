using sevenG_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sevenG.Order
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCustomers();
                loadDivisions();
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

        protected void DRLCustName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void BtnAddCust_Click(object sender, EventArgs e)
        {
            Response.Redirect("../7Gsetting/Customers.aspx");
        }

        protected void DrpUserId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DRLDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            divPrint.Visible = false;
        }

        protected void BtnBusinessCards_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Products/BusinessCards.aspx");
        }

        protected void BtnFlayers_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Products/Flyers.aspx");
        }

        protected void BtnLandScapeBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Products/BooksLandScape.aspx");
        }

        protected void BtnPortraitBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Products/BooksPortrait.aspx");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = OperationBL.insertMainOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLCustName.SelectedValue.ToString()), Session["userName"].ToString(), int.Parse(DRLDivision.SelectedValue.ToString()));
            LBLError.Visible = true;
            if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
            {
                LBLError.Text = "This Order is saved before ,please edit on it";

                
            }
            else
            {
                LBLError.Text = "The order is saved successfully , please continue the order details ..";
                Session["MainOrderID"] = ds.Tables[0].Rows[0]["ret"].ToString();
                Session["CustomerID"] = ds.Tables[0].Rows[0]["cust"].ToString();
                divPrint.Visible = true;


            }

        }

        protected void BtnFolder_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Products/Folders.aspx");
        }
    }
}