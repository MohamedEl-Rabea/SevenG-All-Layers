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
    public partial class PurchasingPaper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadPapers();
                DRLMaterials_SelectedIndexChanged(sender, e);
            }
        }

        private void loadPapers()
        {
            DataSet ds = ProductsBL.LoadPapers((Convert.ToString(Application["strDBConn"])));
            DRLMaterials.DataSource = ds.Tables[0];
            DRLMaterials.DataBind();
        }

        protected void DRLMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void save_Click(object sender, EventArgs e)
        {
            DataSet ds = PricesBL.insertPurchasingPaper((Convert.ToString(Application["strDBConn"])), int.Parse(DRLMaterials.SelectedValue.ToString()), int.Parse(txtPapersNo.Text),float.Parse(txtPapersPrice.Text));
            LBLError.Visible = true;
            if (ds.Tables[0].Rows[0]["ret"].ToString() == "1")
            {
                LBLError.Text = "The data is saved successfully ..";


            }
            else
            {

                LBLError.Text = "This data saved before";

            }
        }
    }
}