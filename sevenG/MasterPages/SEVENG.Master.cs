using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sevenG_BL;

namespace sevenG.MasterPages
{
    public partial class SEVENG : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CustomerID"]!= null)
                {
                    getCartOrders();
                }
            }
        }

        private void getCartOrders()
        {
            DataSet ds = OperationBL.getCartOrders((Convert.ToString(Application["strDBConn"])),int.Parse(Session["CustomerID"].ToString()));
            if (ds.Tables[0] != null)
            {
                //LblChart.Text = ds.Tables[0].Rows.Count.ToString();
            }
        }
    }
}