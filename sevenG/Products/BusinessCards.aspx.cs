using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sevenG_BL; 
using System.IO;

namespace sevenG.Operaion
{
    public partial class Order : System.Web.UI.Page
    {
        float count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { if (Session["MainOrderID"] != null)
                {
                    loadProducts();
                    loadLaminations();
                    loadPrinters();
                    DRLProName_SelectedIndexChanged(sender, e);
                    DRLSize_SelectedIndexChanged(sender, e);
                    Session["roundPrice"] = count;
                }
            else
                {
                    Response.Redirect("../Order/Order.aspx");
                }
            }
        }

       

        private void loadPrice()
        {
            //clearControl();
            //int categoryId = 202;
            //DataSet ds1 = PricesBL.getCategoryProfit((Convert.ToString(Application["strDBConn"])), categoryId);
            //float profit = float.Parse(ds1.Tables[0].Rows[0]["PROFIT"].ToString());
            //DataSet ds = PricesBL.loadPrice((Convert.ToString(Application["strDBConn"])), categoryId);
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_ID"].ToString()) / float.Parse(Session["size"].ToString())).ToString();
            //    ds.Tables[0].Rows[i]["COST"] = ((float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(Session["materialPrice"].ToString()))
            //                                                + (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(Session["laminationPrice"].ToString()))
            //                                                + (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(Session["roundPrice"].ToString()))
            //                                                + (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(Session["printPrice"].ToString()) * float.Parse(Session["sidePrice"].ToString()))).ToString();
            //    ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (float.Parse(ds.Tables[0].Rows[i]["COST"].ToString()) + (float.Parse(ds.Tables[0].Rows[i]["COST"].ToString()) * 0.25)).ToString();
            //    ds.Tables[0].Rows[i]["DISCOUNT_PERC"] = (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) - (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(ds.Tables[0].Rows[i]["DISCOUNT_PERC"].ToString()) / 100)).ToString();
            //    ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (Math.Round(float.Parse(ds.Tables[0].Rows[i]["DISCOUNT_PERC"].ToString()) * profit)).ToString();

            //    if (i ==0)
            //    {
            //        ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = Math.Round(float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * 1.2);
            //    }
            //    if (int.Parse(Session["prodId"].ToString()) == 102)
            //    {
            //        ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = Math.Round(float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) / 2.5);
            //    }


            //}
            //GrdPrices.DataSource = ds.Tables[0];
            //GrdPrices.DataBind();
            DataSet ds = OperationBL.loadBusinessCardPrice((Convert.ToString(Application["strDBConn"])), int.Parse(Session["spot"].ToString()), int.Parse(DRLMaterials.SelectedValue.ToString()));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["PRICE"] = Math.Round((float.Parse(ds.Tables[0].Rows[i]["PRICE"].ToString()) * float.Parse(Session["print"].ToString())) + (((float.Parse(ds.Tables[0].Rows[i]["QUANTITY"].ToString()) * float.Parse(Session["laminationPrice"].ToString())))
                                                            + ((float.Parse(ds.Tables[0].Rows[i]["QUANTITY"].ToString()) * float.Parse(Session["roundPrice"].ToString())))
                                                            + ((float.Parse(ds.Tables[0].Rows[i]["QUANTITY"].ToString()) * float.Parse(Session["side"].ToString()))))).ToString();





            }
            GrdPrices.DataSource = ds.Tables[0];
            GrdPrices.DataBind();

        }

        private void clearControl()
        {
            TxtPrice.Text = "";
            TXTQuantity.Text = "";
        }

        private void loadPrinters()
        {
            DataSet ds = OperationBL.loadPrinters((Convert.ToString(Application["strDBConn"])));
            DrpPrint.DataSource = ds.Tables[0];
            DrpPrint.DataBind();
        }

        private void loadProducts()
        {
            int categoryId = 202;
            DataSet ds = OperationBL.loadProducts((Convert.ToString(Application["strDBConn"])), categoryId);
            DRLProName.DataSource = ds.Tables[0];
            DRLProName.DataBind();

        }

        private void loadSize()
        {
            DataSet ds = OperationBL.loadSize((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()));
            DRLSize.DataSource = ds.Tables[0];
            DRLSize.DataBind();
        }

        private void loadBusinessCardMaterial()
        {
            DataSet ds = OperationBL.loadBusinessCardMaterial((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()));
            DRLMaterials.DataSource = ds.Tables[0];
            DRLMaterials.DataBind();
        }

        private void loadLaminations()
        {
            DataSet ds = OperationBL.loadLaminations((Convert.ToString(Application["strDBConn"])));
            DRLLamination.DataSource = ds.Tables[0];
            DRLLamination.DataBind();
        }

        protected void DRLProName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["prodId"] = DRLProName.SelectedValue.ToString();
            loadBusinessCardMaterial();
            loadSize();
            Session["laminationPrice"] = 0;
            Session["laminationID"] = 0;
            DRLMaterials_SelectedIndexChanged(sender, e);

        }

       

        protected void save_Click(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("d/M/yyyy");

            //string roundItems = String.Join(",",
            // checkRoundCorn.Items.OfType<ListItem>().Where(r => r.Selected)
            //.Select(r => r.Text));

            string roundItems = "Corners : ";
            foreach (ListItem item in checkRoundCorn.Items)
            {
                if (item.Selected)
                {
                    roundItems += item.Text + "  " ;
                }
            }

            Session["sizeCost"] = 1;
            double quntity = double.Parse(TXTQuantity.Text);
            double print = double.Parse(Session["materialPrice"].ToString()) + (double.Parse(Session["sideCost"].ToString()) * double.Parse(Session["sizeCost"].ToString()) * double.Parse(Session["print"].ToString()));
            double PrintCost = print * quntity / double.Parse(Session["size"].ToString()); 
            double laminationCost = double.Parse(Session["laminationPrice"].ToString()) * quntity;
            double SpotCost = double.Parse(Session["spotCost"].ToString()) * quntity / double.Parse(Session["size"].ToString());
            double roundCorner = double.Parse(Session["roundPrice"].ToString()) * quntity;
            Session["cost"] = PrintCost + laminationCost + SpotCost + roundCorner;

            DataSet ds = OperationBL.insertOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()),
             int.Parse(DRLMaterials.SelectedValue.ToString()), int.Parse(DRLSize.SelectedValue.ToString()), int.Parse(Session["laminationID"].ToString()), DrpSecialEffect.Text.ToString(),
             int.Parse(DRLSides.SelectedValue.ToString()), int.Parse(DrpPrint.SelectedValue.ToString()), roundItems, int.Parse(TXTQuantity.Text.ToString()),
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
                DataSet ds1 = OperationBL.insertCost((Convert.ToString(Application["strDBConn"])), int.Parse(Session["attOrderId"].ToString()), PrintCost, laminationCost, SpotCost, 0, 0, 0, roundCorner,0,0, double.Parse(Session["cost"].ToString()));

                Response.Redirect("../Design/LoadAtt.aspx");

            }
            }

        protected void DRLSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sizePric = int.Parse(DRLSize.SelectedValue.ToString());
            if (sizePric == 100)       //business card size
            {
                Session["size"] = 25;
            }
            else if (sizePric == 101)     //A3
            {
                Session["size"] = 1;
            }
            else if (sizePric == 102)      //A4
            {
                Session["size"] = 2;
            }
            else if (sizePric == 103)       //A4 landscape
            {
                Session["size"] = 1;
            }
            else if (sizePric == 104)      //A5
            {
                Session["size"] = 4;
            }
            else if (sizePric == 105)       //A6
            {
                Session["size"] = 8;
            }
            else if (sizePric == 107)        //A5 landscape
            {
                Session["size"] = 2;
            }
            else if (sizePric == 108)       //A6 landscape 
            {
                Session["size"] = 4;
            }
            else
            {
                Session["size"] = 2.6;
            }
            checkRoundCorn_SelectedIndexChanged(sender, e);
        }

        protected void DRLLamination_SelectedIndexChanged(object sender, EventArgs e)
        {
            int laminationPric = int.Parse(DRLLamination.SelectedValue.ToString());
            Session["laminationID"] = laminationPric;
            if (laminationPric == 100)
            {
                Session["laminationPrice"] = -0.15;
            }
            else if (laminationPric == 101 || laminationPric == 102)
            {
                Session["laminationPrice"] = 0.0;
            }
            else
            {
                Session["laminationPrice"] = 0.0;
            }
            DRLSides_SelectedIndexChanged(sender, e);

        }

        protected void DRLSides_SelectedIndexChanged(object sender, EventArgs e)
        {
            int side = int.Parse(DRLSides.SelectedValue.ToString());
            if (side == 1)
            {
                Session["side"] = -0.15;
                Session["sideCost"] = 0.25;
            }

            else
            {
                Session["side"] = 0.0;
                Session["sideCost"] = 0.5;
            }
            DrpPrint_SelectedIndexChanged(sender, e);
        }

        protected void DRLMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = PricesBL.getMaterialPrice((Convert.ToString(Application["strDBConn"])), int.Parse(DRLMaterials.SelectedValue.ToString()));
            Session["materialPrice"] = ds.Tables[0].Rows[0]["PAPER_PRICE"].ToString();

            int proID = int.Parse(Session["prodId"].ToString());
            if (proID == 104 || proID == 103 || proID == 115 || proID == 102 || proID == 116)
            {
                divSpecial.Visible = false;
                divLamin.Visible = false;
                divempty.Visible = false;
                DRLSides_SelectedIndexChanged(sender, e);
                Session["laminationPrice"] = 0;
                Session["laminationID"] = 100;
                Session["spot"] = 1;
            }
            else
            {
                divSpecial.Visible = true;
                divLamin.Visible = true;
                divempty.Visible = false;
                DrpSecialEffect_SelectedIndexChanged(sender, e);
            }

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
            DRLSize_SelectedIndexChanged(sender, e);
        }



        protected void GrdPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            TXTQuantity.ReadOnly = true;
            TxtPrice.ReadOnly = true;
            TXTQuantity.Text = GrdPrices.SelectedRow.Cells[0].Text;
            TxtPrice.Text = GrdPrices.SelectedRow.Cells[1].Text;
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

        protected void checkRoundCorn_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (ListItem lst in checkRoundCorn.Items)
            {
                if (lst.Selected == true)
                {
                    count += 0.03f;
                }

            }
            Session["roundPrice"] = count;
            loadPrice();
        }

        protected void BtnQuantity_Click(object sender, EventArgs e)
        {
            TXTQuantity.ReadOnly = false;
            TXTQuantity.Text = "";
            TxtPrice.Text = "";
        }

        protected void TXTQuantity_TextChanged(object sender, EventArgs e)
        {
            //double discount = 0;
            //int categoryId = 202;
            //double quntity = double.Parse(TXTQuantity.Text);
            //if (quntity < 50)
            //{
            //    discount = 0;
            //}
            //else if (quntity < 75 && quntity >= 50)
            //{
            //    discount = 30;
            //}
            //else if (quntity < 100 && quntity >= 75)
            //{
            //    discount = 25;
            //}
            //else if (quntity < 200 && quntity >= 100)
            //{
            //    discount = 2;
            //}
            //else if (quntity < 300 && quntity >= 200)
            //{
            //    discount = 12;
            //}
            //else if (quntity < 400 && quntity >= 300)
            //{
            //    discount = 15;
            //}
            //else if (quntity < 500 && quntity >= 400)
            //{
            //    discount = 17;
            //}
            //else if (quntity < 800 && quntity >= 500)
            //{
            //    discount = 22;
            //}
            //else if (quntity < 1000 && quntity >= 800)
            //{
            //    discount = 28;
            //}
            //else if (quntity < 2000 && quntity >= 1000)
            //{
            //    discount = 33;
            //}
            //else if (quntity < 3000 && quntity >= 2000)
            //{
            //    discount = 35;
            //}
            //else
            //{
            //    discount = 50;
            //}
            
            //DataSet ds1 = PricesBL.getCategoryProfit((Convert.ToString(Application["strDBConn"])), categoryId);
            //double profit = double.Parse(ds1.Tables[0].Rows[0]["PROFIT"].ToString());
            //double quantityPrice = quntity / double.Parse(Session["size"].ToString());
            //double cost = (quantityPrice * double.Parse(Session["materialPrice"].ToString()))
            //                                            + (quantityPrice * double.Parse(Session["laminationPrice"].ToString()))
            //                                            + (quantityPrice * double.Parse(Session["roundPrice"].ToString()))
            //                                            + (quantityPrice * double.Parse(Session["printPrice"].ToString())* double.Parse(Session["sidePrice"].ToString()));
            //Session["cost"] = cost;
            //quantityPrice = cost + (cost * 0.25);
            //discount = quantityPrice - (quantityPrice * discount / 100);
            //TxtPrice.Text = Math.Round(discount * profit).ToString();
            //if (quntity == 100)
            //{
            //    TxtPrice.Text = Math.Round(discount * profit * 1.2).ToString();
            //}
            //if (int.Parse(Session["prodId"].ToString()) == 102)
            //{
            //    TxtPrice.Text = Math.Round(double.Parse(TxtPrice.Text)/ 2.5).ToString();
            //}
        }

        protected void DrpUserId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DrpSecialEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["spot"] = int.Parse(DrpSecialEffect.SelectedValue.ToString());
            int spot = int.Parse(Session["spot"].ToString());
            if (spot == 1)
            {
                Session["spotCost"] = 0;
            }
            else if(spot == 2)
            {
                Session["spotCost"] = 0.5;
            }
            else 
            {
                Session["spotCost"] = 0.75;
            }


            DRLLamination_SelectedIndexChanged(sender, e);
        }
    }
}