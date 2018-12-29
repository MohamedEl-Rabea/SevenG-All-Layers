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
    public partial class PersonalInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPersonalInfo();
            }
        }

        private void LoadPersonalInfo()
        {
            DataSet ds = SettingBL.getProfileInfo((Convert.ToString(Application["strDBConn"])), Session["userName"].ToString());
            txtCustomerName.Text = ds.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString();
            txtCustAR.Text = ds.Tables[0].Rows[0]["CUSTOMER_NAME_A"].ToString();
            Txtcomp.Text = ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
            txtCustomerAdd.Text = ds.Tables[0].Rows[0]["CUSTOMER_ADDRESS"].ToString();
            txtCustomerMail.Text = ds.Tables[0].Rows[0]["CUSTOMER_EMAIL"].ToString();
            txtCustomerPhone.Text = ds.Tables[0].Rows[0]["CUSTOMER_PHONE"].ToString();
            txtCustomerMobile.Text = ds.Tables[0].Rows[0]["CUSTOMER_MOBILE"].ToString();
            txtJobName.Text = ds.Tables[0].Rows[0]["JOB_NAME"].ToString();
            txtCompRole.Text = ds.Tables[0].Rows[0]["COMPANY_ROLE"].ToString();
            txtAddress2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();

        }

        protected void save_Click(object sender, EventArgs e)
        {
          
                DataSet ds = SettingBL.editProfileInfo((Convert.ToString(Application["strDBConn"])), txtCustomerName.Text, txtCustAR.Text, Txtcomp.Text, txtCustomerAdd.Text, txtCustomerMail.Text, txtCustomerPhone.Text, txtCustomerMobile.Text, txtJobName.Text, txtCompRole.Text, txtAddress2.Text, Session["userName"].ToString());
                LBLError.Visible = true;
                if (ds.Tables[0].Rows[0]["ret"].ToString() == "1")
                {
                LBLError.Text = "The Profile is saved successfully";
                }
                else
                {
                    LBLError.Text = "Please, enter all informations";

                }

          
        }

       
    }
}