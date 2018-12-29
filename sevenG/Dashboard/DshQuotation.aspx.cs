using sevenG_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sevenG.Dashboard
{
    public partial class DshQuotation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                loadQuotations();
            }
        }

        private void loadQuotations()
        {
            DataSet ds = SettingBL.queryQuotations((Convert.ToString(Application["strDBConn"])));
            GrdMOrders.DataSource = ds.Tables[0];
            GrdMOrders.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {
            loadQuotations();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtFrom.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
            Calendar1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtTo.Text = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
            Calendar2.Visible = false;
        }

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {
            loadQuotations();
        }

        protected void search_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFrom.Text) && !String.IsNullOrEmpty(txtTo.Text) && String.IsNullOrEmpty(txtCustomer.Text))
            {
                DataSet ds = SettingBL.searchQueryQuotations((Convert.ToString(Application["strDBConn"])), Convert.ToDateTime(txtFrom.Text.ToString()), Convert.ToDateTime(txtTo.Text.ToString()));
                GrdMOrders.DataSource = ds.Tables[0];
                GrdMOrders.DataBind();
            }
            else if (!String.IsNullOrEmpty(txtCustomer.Text) && !String.IsNullOrEmpty(txtFrom.Text) && !String.IsNullOrEmpty(txtTo.Text))
            {
                DataSet ds = SettingBL.filterQueryQuotations((Convert.ToString(Application["strDBConn"])), Convert.ToDateTime(txtFrom.Text.ToString()), Convert.ToDateTime(txtTo.Text.ToString()), txtCustomer.Text);
                GrdMOrders.DataSource = ds.Tables[0];
                GrdMOrders.DataBind();
            }
            else if (!String.IsNullOrEmpty(txtCustomer.Text) && String.IsNullOrEmpty(txtFrom.Text) && String.IsNullOrEmpty(txtTo.Text))
            {
                DataSet ds = SettingBL.searchQueryQuotationsCustomer((Convert.ToString(Application["strDBConn"])), txtCustomer.Text);
                GrdMOrders.DataSource = ds.Tables[0];
                GrdMOrders.DataBind();
            }
            else
            {
                loadQuotations();

            }
        }

        protected void GrdMOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GrdMOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdMOrders.PageIndex = e.NewPageIndex;
            loadQuotations();
        }

        protected void GrdMOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["MainOrderID"] = GrdMOrders.DataKeys[GrdMOrders.SelectedRow.RowIndex]["MAIN_ORDER_ID"].ToString();
            Session["CustomerID"] = GrdMOrders.DataKeys[GrdMOrders.SelectedRow.RowIndex]["CUSTOMER_ID"].ToString();
            Session["quotCode"] = GrdMOrders.SelectedRow.Cells[2].Text;
            Response.Redirect("../Order/PrintQuot.aspx");
        }

 
    }
}