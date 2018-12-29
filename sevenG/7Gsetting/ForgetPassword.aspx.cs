using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using sevenG_BL;

namespace sevenG._7Gsetting
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text != " ")
            {
                DataSet ds = SettingBL.CheckUser(Convert.ToString(Application["strDBConn"]), txtUserName.Text);

                if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
                {
                    LBLError.Visible = true;
                    LBLError.Text = "User not found ...لا يوجد مستخدم";

                }
                else
                {
                    Session["userName"] = ds.Tables[0].Rows[0]["ret"].ToString();
                    Response.Redirect("~/7Gsetting/ResetPassword.aspx?view=0");
                }
            }
            else
            {
                LBLError.Visible = true;
                LBLError.Text = "Enter username or email";
            }
        }
    }
}