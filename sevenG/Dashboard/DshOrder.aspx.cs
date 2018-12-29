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
    public partial class DshOrder : System.Web.UI.Page
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
            DataSet ds = SettingBL.queryMainOrders((Convert.ToString(Application["strDBConn"])));
            GrdMOrders.DataSource = ds.Tables[0];
            GrdMOrders.DataBind();
        }

        protected void search_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFrom.Text ) && !String.IsNullOrEmpty( txtTo.Text) && String.IsNullOrEmpty(txtCustomer.Text) )
            {
                DataSet ds = SettingBL.searchQueryMainOrders((Convert.ToString(Application["strDBConn"])), Convert.ToDateTime(txtFrom.Text.ToString()), Convert.ToDateTime(txtTo.Text.ToString()));
                GrdMOrders.DataSource = ds.Tables[0];
                GrdMOrders.DataBind();
            }
          else if (!String.IsNullOrEmpty(txtCustomer.Text ) && !String.IsNullOrEmpty(txtFrom.Text ) && !String.IsNullOrEmpty( txtTo.Text ))
            {
                DataSet ds = SettingBL.filterQueryMainOrders((Convert.ToString(Application["strDBConn"])), Convert.ToDateTime(txtFrom.Text.ToString()), Convert.ToDateTime(txtTo.Text.ToString()),txtCustomer.Text);
                GrdMOrders.DataSource = ds.Tables[0];
                GrdMOrders.DataBind();
            }
         else if (!String.IsNullOrEmpty(txtCustomer.Text ) && String.IsNullOrEmpty(txtFrom.Text) && String.IsNullOrEmpty(txtTo.Text))
            {
                DataSet ds = SettingBL.searchQueryMainOrdersCustomer((Convert.ToString(Application["strDBConn"])), txtCustomer.Text);
                GrdMOrders.DataSource = ds.Tables[0];
                GrdMOrders.DataBind();
            }
            else
            {
                loadMainOrders();
            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtFrom.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
            Calendar1.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtTo.Text = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
            Calendar2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = true;
        }

        public string MyNewRow(object mainOrderId)
        {
            return String.Format(@"</td></tr><tr id ='tr{0}' class='collapsed-row'>
        <td></td><td colspan='100' style='padding:0px; margin:0px;'>", mainOrderId);
        }
        protected void GrdMOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int mainOrderId = int.Parse(GrdMOrders.DataKeys[e.Row.RowIndex]["MAIN_ORDER_ID"].ToString());

                int customerId = int.Parse(GrdMOrders.DataKeys[e.Row.RowIndex]["CUSTOMER_ID"].ToString());
                var gvOrders = (GridView)e.Row.FindControl("gvOrders");
                DataSet ds = OperationBL.loadInvRep((Convert.ToString(Application["strDBConn"])), mainOrderId, customerId);
                gvOrders.DataSource = ds.Tables[0];
                gvOrders.DataBind();


            }
        }

        protected void GrdMOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdMOrders.PageIndex = e.NewPageIndex;
            loadMainOrders();
        }

       

        protected void txtCustomer_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}