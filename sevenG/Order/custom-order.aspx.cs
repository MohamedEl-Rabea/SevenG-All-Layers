using sevenG_BL;
using System;
using System.Data;

namespace sevenG.Order
{
    public partial class custom_order : System.Web.UI.Page
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
                    Response.Redirect("../Order/new-order.aspx");
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
            divErrMsg.Visible = false;
            float costPrice = float.Parse(TXTQuantity.Text.ToString()) * float.Parse(TXTCostPrice.Text.ToString());
            float totalPrice = float.Parse(TXTQuantity.Text.ToString()) * float.Parse(txtPrice.Text.ToString());
            DataSet ds = OperationBL.insertCustomOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLCat.SelectedValue.ToString()),
              TXTDescription.Text, int.Parse(DRLSupplier.SelectedValue.ToString()), int.Parse(TXTQuantity.Text.ToString()),
               costPrice, totalPrice, int.Parse(Session["MainOrderID"].ToString()), int.Parse(Session["CustomerID"].ToString()));


            if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
            {
                divErrMsg.Visible = true;
                LBLError.Text = "This order is Added Before";
            }
            else
            {
                Session["attOrderId"] = ds.Tables[0].Rows[0]["ret"].ToString();
                Session["MOrderID"] = Session["MainOrderID"].ToString();
                Session["CustomerNo"] = Session["CustomerID"].ToString();
                Response.Redirect("../Design/load-attachments.aspx");
            }
        }
    }
}