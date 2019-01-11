using System;

namespace sevenG
{
    public partial class test_partial_load : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFullPostBackTime.Text = DateTime.Now.ToLongTimeString();
            lblPartialPostBackTime.Text = DateTime.Now.ToLongTimeString();
        }

        protected void btnFull_Click(object sender, EventArgs e)
        {

        }

        protected void btnPartial_Click(object sender, EventArgs e)
        {
            lblPartialPostBackTime.Text = DateTime.Now.ToLongTimeString();
        }

        protected void DrpSecialEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPartialPostBackTime.Text = DateTime.Now.ToLongTimeString();
            DropDownList1.Items.Clear();
        }
    }
}