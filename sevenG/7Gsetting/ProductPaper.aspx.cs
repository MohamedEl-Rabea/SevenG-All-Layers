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
    public partial class ProductPaper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPapers();
                loadCategory();
                DRLCategory_SelectedIndexChanged(sender, e);
            }
        }

        private void LoadPapers()
        {
            DataSet ds = ProductsBL.LoadPapers((Convert.ToString(Application["strDBConn"])));
            DRLMaterials.DataSource = ds.Tables[0];
            DRLMaterials.DataBind();
        }

        private void loadCategory()
        {
            DataSet ds = ProductsBL.loadCategory((Convert.ToString(Application["strDBConn"])));
            DRLCategory.DataSource = ds.Tables[0];
            DRLCategory.DataBind();
        }

        protected void DRLCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["catId"] = DRLCategory.SelectedValue.ToString();
            loadCatProducts();
        }

        private void loadCatProducts()
        {
            DataSet ds = ProductsBL.loadCatProducts((Convert.ToString(Application["strDBConn"])),int.Parse(Session["catId"].ToString()));
            DRLPaperType.DataSource = ds.Tables[0];
            DRLPaperType.DataBind();
        }

        protected void DRLPaperType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DRLMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void save_Click(object sender, EventArgs e)
        {
                DataSet ds = ProductsBL.insertProdPaper((Convert.ToString(Application["strDBConn"])), int.Parse(DRLPaperType.SelectedValue.ToString()), int.Parse(DRLMaterials.SelectedValue.ToString()));
                LBLError.Visible = true;
                if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
                {
                    LBLError.Text = "This paper  is saved before";
                }
                else
                {
                    LBLError.Text = "The paper is saved successfully";
                  
                
                }
               
         
        }

        protected void BtnPrice_Click(object sender, EventArgs e)
        {
            DataSet ds = ProductsBL.inserPaperPrice((Convert.ToString(Application["strDBConn"])), int.Parse(DRLCategory.SelectedValue.ToString()), int.Parse(DRLMaterials.SelectedValue.ToString()),int.Parse(txtQuantity.Text), int.Parse(txtPapersPrice.Text), int.Parse(txtSPOTUV1Price.Text), int.Parse(txtSPOTUV2Price.Text));
            LBLError.Visible = true;
            if (ds.Tables[0].Rows[0]["ret"].ToString() == "-2")
            {
                LBLError.Text = "This paper price  is saved before";
            }
            else if(ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
            {
                LBLError.Text = "you can't insert price in this category";
            }
            else
            {
                LBLError.Text = "The paper price is saved successfully";
                price.Visible = true;

            }

        }
    }
}