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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //system user
            int userStatus = 0;
            if (txtUserName.Text != " ")
            {
                DataSet ds = SettingBL.insertUser((Convert.ToString(Application["strDBConn"])), txtUserName.Text, txtEmail.Text, txtPassword.Text, txtFirstName.Text, txtLastName.Text, TxtMobile.Text, userStatus);
                LBLError.Visible = true;
                
                if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
                {
                    LBLError.Text = "This user is saved before";
                }
                else
                {
                    LBLError.Text = "The user is saved successfully";
                    btnRegister.Visible = false;
                    //BtnAddress.Visible = true;

                }

            }
            else
            {
                LBLError.Visible = true;
                LBLError.Text = "Enter username";
            }
        }

        protected void BtnAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("../views/MapFullAddress.aspx");
        }
    }
}