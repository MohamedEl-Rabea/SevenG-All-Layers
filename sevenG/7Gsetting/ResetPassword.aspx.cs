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
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                DataSet ds = SettingBL.updatePassword((Convert.ToString(Application["strDBConn"])), Session["userName"].ToString(), txtPassword.Text);
                LBLError.Visible = true;
                if (ds.Tables[0].Rows[0]["ret"].ToString() == "1")
                {
                    LBLError.Text = "The Password is changed";
                }
                else
                {
                    LBLError.Text = "Enter Password";

                }

            }
            else
            {
                LBLError.Visible = true;
                LBLError.Text = "The Password not match";
            }

            txtConfirmPassword.Text = "";
            txtPassword.Text = "";
        
        }

        protected void linkBack_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["View"] == "1")
                  Response.Redirect("../views/HomePage.aspx");
            else
                  Response.Redirect("../Login.aspx");
            //if (Session["userName"].ToString() != null)
            //    Response.Redirect("../views/HomePage.aspx");
            //else
            //    Response.Redirect("../Login.aspx");
        }
    }
}