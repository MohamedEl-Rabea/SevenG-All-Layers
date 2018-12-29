using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sevenG_BL;

namespace sevenG._7Gsetting
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        

        protected void save_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text != " ")
            {
                DataSet ds = SettingBL.insertCustomer((Convert.ToString(Application["strDBConn"])), txtCustomerName.Text,txtCustAR.Text, Txtcomp.Text, txtCustomerAdd.Text, txtCustomerMail.Text, txtCustomerPhone.Text, txtCustomerMobile.Text,txtJobName.Text,txtCompRole.Text,txtAddress2.Text, Session["userName"].ToString());
                LBLError.Visible = true;
                if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
                {
                    LBLError.Text = "This customer name is saved before";
                }
                else
                {
                    LBLError.Text = "The customer is saved successfully";
                    
                }
             
            }
            else
            {
                LBLError.Visible = true;
                LBLError.Text = "The customer name can't be space";
            }
        }

        private void ClearControl()
        {
            txtCustomerAdd.Text = "";
            txtCustomerMail.Text = "";
            txtCustomerMobile.Text = "";
            txtCustomerName.Text = "";
            txtCustomerPhone.Text = "";
        }
    }
}