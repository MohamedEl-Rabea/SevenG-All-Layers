using sevenG_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sevenG
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            DataSet ds = SettingBL.CheckUserLogin(Convert.ToString(Application["strDBConn"]),txtEmail.Text.ToString(), txtPassword.Text);

            if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
            {
                LBLError.Visible = true;
                LBLError.Text = "please try again ...خطا بالدخول";

            }
            else
            {
                Session["userName"] = ds.Tables[0].Rows[0]["ret"].ToString();
                //Session["CustomerID"] =ds.Tables[0].Rows[0]["CUSTOMER_ID"].ToString();
                //Response.Redirect("~/views/HomePage.aspx");
                Response.Redirect("~/Dashboard/admin-dashboard.aspx");

            }
        }
    }
}