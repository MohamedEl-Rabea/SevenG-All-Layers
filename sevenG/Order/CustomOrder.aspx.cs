using sevenG_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sevenG.Order
{
    public partial class CustomOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MainOrderID"] != null)
                {
                    loadCategories();
                    loadSuppliers();
                }
                else
                {
                    Response.Redirect("../Order/Order.aspx");
                }
            }
        }

        private void loadSuppliers()
        {
            DataSet ds = SettingBL.loadSupplier((Convert.ToString(Application["strDBConn"])));
            DRLSupplier.DataSource = ds.Tables[0];
            DRLSupplier.DataBind();
        }

        private void loadCategories()
        {
            DataSet ds = ProductsBL.loadCategory((Convert.ToString(Application["strDBConn"])));
            DRLCat.DataSource = ds.Tables[0];
            DRLCat.DataBind();
        }

     
        protected void DRLCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnAddCat_Click(object sender, EventArgs e)
        {

        }

       

        protected void DRLSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LnkSupplier_Click(object sender, EventArgs e)
        {

        }

        protected void DRLSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            float costPrice = float.Parse(TXTQuantity.Text.ToString()) * float.Parse(TXTCostPrice.Text.ToString());
            float totalPrice = float.Parse(TXTQuantity.Text.ToString()) * float.Parse(txtPrice.Text.ToString());
            DataSet ds = OperationBL.insertCustomOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLCat.SelectedValue.ToString()),
              TXTDescription.Text, int.Parse(DRLSupplier.SelectedValue.ToString()), int.Parse(TXTQuantity.Text.ToString()),
               costPrice, totalPrice, int.Parse(Session["MainOrderID"].ToString()), int.Parse(Session["CustomerID"].ToString()));


            if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
            {
                LBLError.Visible = true;
                LBLError.Text = "This order is Added Before";
            }
            else
            {
                LBLError.Visible = true;
                LBLError.Text = "The order is added to cart...";
                Session["attOrderId"] = ds.Tables[0].Rows[0]["ret"].ToString();
                Session["MOrderID"] = Session["MainOrderID"].ToString();
                Session["CustomerNo"] = Session["CustomerID"].ToString();
               Response.Redirect("../Design/LoadAtt.aspx");




            }
        }
    }
}