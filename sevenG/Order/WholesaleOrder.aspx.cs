using sevenG_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sevenG.Order
{
    public partial class Wholesale_Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MainOrderID"] != null)
                {
                    loadCAT();
                    loadPrinters();
                    DRLCat_SelectedIndexChanged(sender, e);
                }
                else
                {
                    Response.Redirect("../Order/Order.aspx");
                }

            }
        }

        private void loadPrinters()
        {
            DataSet ds = OperationBL.loadPrinters((Convert.ToString(Application["strDBConn"])));
            DrpPrint.DataSource = ds.Tables[0];
            DrpPrint.DataBind();
        }

        private void loadPapers()
        {
            DataSet ds = OperationBL.getCatPapers((Convert.ToString(Application["strDBConn"])), int.Parse(Session["prodId"].ToString()));
            DRLMaterials.DataSource = ds.Tables[0];
            Session["FACTOR"] = ds.Tables[0].Rows[0]["FACTOR"].ToString();
            DRLMaterials.DataBind();
        }

        private void loadCAT()
        {
            DataSet ds = OperationBL.loadCAT((Convert.ToString(Application["strDBConn"])));
            DRLCat.DataSource = ds.Tables[0];
            DRLCat.DataBind();
        }

        protected void DRLCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["prodId"] = DRLCat.SelectedValue.ToString();
            loadPapers();
            DRLMaterials_SelectedIndexChanged(sender, e);
            
        }

        protected void DRLMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            DrpPrint_SelectedIndexChanged(sender, e);
        }

        protected void DRLSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int size = int.Parse(DRLSize.SelectedValue.ToString());
            if (size == 101)
            {
                Session["size"] = 1;
            }

            else
            {
                Session["size"] = 0.5;
            }

            DRLSides_SelectedIndexChanged(sender, e);
        }

        protected void DRLSides_SelectedIndexChanged(object sender, EventArgs e)
        {
            int side = int.Parse(DRLSides.SelectedValue.ToString());
            if (side == 1)
            {
                Session["side"] = 0.25;
            }

            else
            {
                Session["side"] = 0.5;
            }
            TXTQuantity_TextChanged(sender, e);
        }

       

        private void clearControl()
        {
            TxtPrice.Text = "";
            TXTQuantity.Text = "";
        }

        protected void DrpPrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            int print = int.Parse(DrpPrint.SelectedValue.ToString());
            if (print == 100)
            {
                Session["print"] = 1;
            }

            else
            {
                Session["print"] = 2;
            }
            DRLSize_SelectedIndexChanged(sender, e);
        }

        

        protected void save_Click(object sender, EventArgs e)
        {
            DataSet ds = OperationBL.insertOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLCat.SelectedValue.ToString()),
              int.Parse(DRLMaterials.SelectedValue.ToString()), int.Parse(DRLSize.SelectedValue.ToString()), 100 , "no-spot UV",
              int.Parse(DRLSides.SelectedValue.ToString()), int.Parse(DrpPrint.SelectedValue.ToString()), null, int.Parse(TXTQuantity.Text.ToString()),
              float.Parse(Session["quantityPrice"].ToString()), float.Parse(TxtPrice.Text.ToString()), int.Parse(Session["MainOrderID"].ToString()), int.Parse(Session["CustomerID"].ToString()));


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
                DataSet ds1 = OperationBL.insertCost((Convert.ToString(Application["strDBConn"])), int.Parse(Session["attOrderId"].ToString()), double.Parse(Session["quantityPrice"].ToString()), 0, 0, 0, 0, 0,0,0,0, double.Parse(Session["cost"].ToString()));

                Response.Redirect("../Design/LoadAtt.aspx");
              
            }
        }

      

        protected void TXTQuantity_TextChanged(object sender, EventArgs e)
        {
            
            double factor = double.Parse(Session["FACTOR"].ToString());
            double quntity = double.Parse(TXTQuantity.Text);
            //if (quntity <= 20)
            //{
            //    factor = 1.8;
            //}
            //else if (quntity <= 50 && quntity > 20)
            //{
            //    factor = 3.5;
            //}
            //else if (quntity <= 80 && quntity >50)
            //{
            //    factor = 3;
            //}
            //else if (quntity <= 100 && quntity > 80)
            //{
            //    factor = 2.6;
            //}
            //else
            //{
            //    factor = 2.5;
            //}

            DataSet ds1 = PricesBL.getCatProfit((Convert.ToString(Application["strDBConn"])), int.Parse(Session["prodId"].ToString()));



            double profit = double.Parse(ds1.Tables[0].Rows[0]["PROFIT"].ToString());
           
            double price = profit + ( double.Parse(Session["side"].ToString()) * double.Parse(Session["size"].ToString())/ double.Parse(Session["print"].ToString()));
            double quantityPrice = price * quntity;
            Session["quantityPrice"] = quantityPrice.ToString();
            double total = quantityPrice * factor;
            total = (int)total;
            Session["cost"] = total;
            TxtPrice.Text = total.ToString();


            //LBLError.Text = price.ToString();
        }
    }
}