using sevenG_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sevenG.Products
{
    public partial class Folders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              if (!IsPostBack)
            {
                if (Session["MainOrderID"] != null)
                {

                    loadProducts();
                    loadLaminations();
                    loadPrinters();
                    DrpSecialEffect_SelectedIndexChanged(sender, e);
                }
            else
                {
                    Response.Redirect("../Order/Order.aspx");
                }
            }
        }

        private void loadProducts()
        {
            int categoryId = 206;
            DataSet ds = OperationBL.loadProducts((Convert.ToString(Application["strDBConn"])), categoryId);
            DRLProName.DataSource = ds.Tables[0];
            DRLProName.DataBind();
        }
    
        private void loadFolderMaterial()
        {
            DataSet ds = OperationBL.loadFolderMaterial((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()));
            DRLMaterials.DataSource = ds.Tables[0];
            DRLMaterials.DataBind();
        }
        private void loadPrice()
        {
            DataSet ds = OperationBL.loadFolderPrice((Convert.ToString(Application["strDBConn"])),int.Parse(Session["spot"].ToString()),int.Parse(DRLMaterials.SelectedValue.ToString()));
            GrdPrices.DataSource = ds.Tables[0];
            GrdPrices.DataBind();
        }

        private void loadPrinters()
        {
            DataSet ds = OperationBL.loadPrinters((Convert.ToString(Application["strDBConn"])));
            DrpPrint.DataSource = ds.Tables[0];
            DrpPrint.DataBind();
        }

        private void loadLaminations()
        {
            DataSet ds = OperationBL.loadLaminations((Convert.ToString(Application["strDBConn"])));
            DRLLamination.DataSource = ds.Tables[0];
            DRLLamination.DataBind();
        }

        protected void GrdPrices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='Lavender';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void GrdPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            TXTQuantity.ReadOnly = true;
            TxtPrice.ReadOnly = true;
            TXTQuantity.Text = GrdPrices.SelectedRow.Cells[0].Text;
            TxtPrice.Text = GrdPrices.SelectedRow.Cells[1].Text;
          
        }

        protected void DrpSecialEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["spot"] = int.Parse(DrpSecialEffect.SelectedValue.ToString());
            int spot = int.Parse(Session["spot"].ToString());
            if (spot == 1)
            {
                Session["spotCost"] = 0;
            }
            else
            {
                Session["spotCost"] = 0.5;
            }

            DRLLamination_SelectedIndexChanged(sender, e);
           
        }

        protected void DRLLamination_SelectedIndexChanged(object sender, EventArgs e)
        {
            int laminationPric = int.Parse(DRLLamination.SelectedValue.ToString());
            Session["laminationID"] = laminationPric;
            if (laminationPric == 100)
            {
                Session["laminationPrice"] = 0;
            }
            else if (laminationPric == 101 || laminationPric == 102)
            {
                Session["laminationPrice"] = 0.1;
            }
            else
            {
                Session["laminationPrice"] = 0.2;
            }

            DRLSides_SelectedIndexChanged(sender, e);
        }

        protected void DRLSides_SelectedIndexChanged(object sender, EventArgs e)
        {
            int side = int.Parse(DRLSides.SelectedValue.ToString());
            if (side == 1)
            {
                Session["side"] = 0.0;
                Session["sideCost"] = 0.25;
            }

            else
            {
                Session["side"] = 0.25;
                Session["sideCost"] = 0.5;
            }
            DrpPrint_SelectedIndexChanged(sender, e);
        }

        protected void DrpCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CD = int.Parse(DrpCD.SelectedValue.ToString());
            if (CD == 1)
            {
                Session["CD"] = 0.0;
            }

            else
            {
                Session["CD"] = 0.25;
            }
            DrpSpin_SelectedIndexChanged(sender, e);
        }

        private void updatePrice()
        {
            clearControl();

            DataSet ds = OperationBL.loadFolderPrice((Convert.ToString(Application["strDBConn"])), int.Parse(Session["spot"].ToString()), int.Parse(DRLMaterials.SelectedValue.ToString()));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["PRICE"] = Math.Round((float.Parse(ds.Tables[0].Rows[i]["PRICE"].ToString()) * float.Parse(Session["print"].ToString())) + (( (float.Parse(ds.Tables[0].Rows[i]["QUANTITY"].ToString()) * float.Parse(Session["laminationPrice"].ToString())))
                                                            + ((float.Parse(ds.Tables[0].Rows[i]["QUANTITY"].ToString()) * float.Parse(Session["CD"].ToString())))
                                                            + ((float.Parse(ds.Tables[0].Rows[i]["QUANTITY"].ToString()) * float.Parse(Session["spin"].ToString())))
                                                            + ((float.Parse(ds.Tables[0].Rows[i]["QUANTITY"].ToString()) * float.Parse(Session["side"].ToString())))
                                                            + ((float.Parse(ds.Tables[0].Rows[i]["QUANTITY"].ToString()) * float.Parse(Session["pocket"].ToString()))))).ToString();

             
               


            }
            GrdPrices.DataSource = ds.Tables[0];
            GrdPrices.DataBind();
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
                Session["print"] = 0.5;
            }
            DrpCD_SelectedIndexChanged(sender, e);
        }

        protected void save_Click(object sender, EventArgs e)
        {
            Session["size"] = 1;
            double quntity = double.Parse(TXTQuantity.Text);
            double print = double.Parse(Session["materialPrice"].ToString()) + (double.Parse(Session["sideCost"].ToString()) * double.Parse(Session["size"].ToString()) * double.Parse(Session["print"].ToString()));
            double PrintCost = print * quntity;
            double laminationCost = double.Parse(Session["laminationPrice"].ToString()) * quntity;
            double SpotCost = double.Parse(Session["spotCost"].ToString()) * quntity;
            double spin = double.Parse(Session["spin"].ToString()) * quntity;
            double CDCost = double.Parse(Session["CD"].ToString()) * quntity;
            double pocketCost = double.Parse(Session["pocket"].ToString()) * quntity;
            Session["cost"] = PrintCost + laminationCost + SpotCost + spin + CDCost + pocketCost;

            string finishing= DrpCD.SelectedItem.Text + " " + DrpPockets.SelectedItem.Text + " " + DrpSpin.SelectedItem.Text;
            DataSet ds = OperationBL.insertOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()),
                int.Parse(DRLMaterials.SelectedValue.ToString()), 101, int.Parse(Session["laminationID"].ToString()), DrpSecialEffect.Text.ToString(),
                int.Parse(DRLSides.SelectedValue.ToString()), int.Parse(DrpPrint.SelectedValue.ToString()), finishing, int.Parse(TXTQuantity.Text.ToString()),
                float.Parse(Session["cost"].ToString()), float.Parse(TxtPrice.Text.ToString()), int.Parse(Session["MainOrderID"].ToString()), int.Parse(Session["CustomerID"].ToString()));


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
                DataSet ds1 = OperationBL.insertCost((Convert.ToString(Application["strDBConn"])),int.Parse(Session["attOrderId"].ToString()), PrintCost, laminationCost, SpotCost, spin, CDCost, pocketCost,0,0 ,0,double.Parse(Session["cost"].ToString()));

                Response.Redirect("../Design/LoadAtt.aspx");
               
            }
        }

        protected void DrpSpin_SelectedIndexChanged(object sender, EventArgs e)
        {
            int spin = int.Parse(DrpSpin.SelectedValue.ToString());
            if (spin == 1)
            {
                Session["spin"] = 0.0;
            }

            else if(spin == 2)
            {
                Session["spin"] = 0.15;
            }
            else
                Session["spin"] = 0.25;
            DRLProName_SelectedIndexChanged(sender, e);
          
        }

        protected void DRLProName_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["prodId"] = DRLProName.SelectedValue.ToString();
            loadFolderMaterial();
            DRLMaterials_SelectedIndexChanged(sender, e);
        }

        protected void DRLMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = PricesBL.getMaterialPrice((Convert.ToString(Application["strDBConn"])), int.Parse(DRLMaterials.SelectedValue.ToString()));
            Session["materialPrice"] = ds.Tables[0].Rows[0]["PAPER_PRICE"].ToString();
            DrpPockets_SelectedIndexChanged(sender, e);
           
        }

        protected void DrpPockets_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pockets = int.Parse(DrpPockets.SelectedValue.ToString());
            if (pockets == 1 || pockets == 2)

            {
                Session["pocket"] = 0.0;
            }
            else if (pockets == 3 || pockets == 4)

            {
                Session["pocket"] = 0.2;
            }

            else
            {
                Session["pocket"] = 0.4;
            }
            updatePrice();
        }

        protected void BtnQuantity_Click(object sender, EventArgs e)
        {
            TXTQuantity.ReadOnly = false;
            TXTQuantity.Text = "";
            TxtPrice.Text = "";
        }

        protected void TXTQuantity_TextChanged(object sender, EventArgs e)
        {
            double priceUnit = 0;
            double price = 0;
            double quntity = double.Parse(TXTQuantity.Text);
            if (int.Parse(Session["spot"].ToString()) == 1)
            {
                if (quntity < 25)
                {
                    priceUnit = 5;
                }
               
                else if (quntity < 50 && quntity >= 25)
                {
                    priceUnit = 4.2;
                }
                else if (quntity < 75 && quntity >= 50)
                {
                    priceUnit = 3.2;
                }
                else if (quntity < 100 && quntity >= 75)
                {
                    priceUnit = 3;
                }
                else if (quntity < 200 && quntity >= 100)
                {
                    priceUnit = 2.8;
                }
                else if (quntity < 300 && quntity >= 200)
                {
                    priceUnit = 2.35;
                }
                else if (quntity < 400 && quntity >= 300)
                {
                    priceUnit = 2.08;
                }
                else if (quntity < 500 && quntity >= 400)
                {
                    priceUnit = 1.9;
                }
               
                else
                {
                    priceUnit = 1.8;
                }
            }
            else
            {
                if (quntity < 25)
                {
                    priceUnit = 13.5;
                }
                else if (quntity < 50 && quntity >= 25)
                {
                    priceUnit = 12.4;
                }
                else if (quntity < 75 && quntity >= 50)
                {
                    priceUnit = 9.8;
                }
                else if (quntity < 100 && quntity >= 75)
                {
                    priceUnit = 8.4;
                }
                else if (quntity < 200 && quntity >= 100)
                {
                    priceUnit = 6.6;
                }
                else if (quntity < 300 && quntity >= 200)
                {
                    priceUnit = 4;
                }
                else if (quntity < 400 && quntity >= 300)
                {
                    priceUnit = 3.7;
                }
                else if (quntity < 500 && quntity >= 400)
                {
                    priceUnit = 3.6;
                }
               
                else
                {
                    priceUnit = 3.5;
                }
            }
            price = (priceUnit * quntity * double.Parse(Session["print"].ToString()))
                     + (quntity * double.Parse(Session["laminationPrice"].ToString()))
                     + (quntity * double.Parse(Session["CD"].ToString()))
                     + (quntity * double.Parse(Session["spin"].ToString()))
                     + (quntity * double.Parse(Session["pocket"].ToString()))
                     + (quntity * double.Parse(Session["side"].ToString()));

            TxtPrice.Text = Math.Round(price).ToString();
        }
    }
}