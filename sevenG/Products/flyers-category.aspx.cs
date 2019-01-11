using sevenG_BL;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace sevenG.Products
{
    public partial class flyers_category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MainOrderID"] != null)
                {
                    loadPrinters();
                    loadProducts();
                    loadLaminations();
                    loadFinishing();
                    DRLProName_SelectedIndexChanged(sender, e);
                    DRLSize_SelectedIndexChanged(sender, e);
                }
                else
                {
                    Response.Redirect("../Order/new-order.aspx");
                }
            }
        }


        private void loadFinishing()
        {
            DataSet ds = OperationBL.loadFinishing((Convert.ToString(Application["strDBConn"])));
            DrpFinishing.DataSource = ds.Tables[0];
            DrpFinishing.DataBind();
        }

        private void loadPrinters()
        {
            DataSet ds = OperationBL.loadPrinters((Convert.ToString(Application["strDBConn"])));
            DrpPrint.DataSource = ds.Tables[0];
            DrpPrint.DataBind();
        }

        private void loadProducts()
        {
            int categoryId = 203;
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

        private void loadFlyerMaterial()
        {
            DataSet ds = OperationBL.loadFlyerMaterial((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()));
            DRLMaterials.DataSource = ds.Tables[0];
            DRLMaterials.DataBind();
        }

        private void loadLaminations()
        {
            DataSet ds = OperationBL.loadLaminations((Convert.ToString(Application["strDBConn"])));
            DRLLamination.DataSource = ds.Tables[0];
            DRLLamination.DataBind();
        }

        private void loadPrice()
        {
            clearControl();
            //int categoryId = 203;
            //DataSet ds1 = PricesBL.getCategoryProfit((Convert.ToString(Application["strDBConn"])), categoryId);
            //float profit = float.Parse(ds1.Tables[0].Rows[0]["PROFIT"].ToString());
            //DataSet ds = PricesBL.loadPrice((Convert.ToString(Application["strDBConn"])), categoryId);
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_ID"].ToString()) / float.Parse(Session["size"].ToString())).ToString();
            //    ds.Tables[0].Rows[i]["COST"] = ((float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(Session["materialPrice"].ToString()))
            //                                                + (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(Session["laminationPrice"].ToString()))
            //                                                + (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(Session["finishingPrice"].ToString()))
            //                                                + (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(Session["printPrice"].ToString()) * float.Parse(Session["sidePrice"].ToString()))).ToString();
            //    ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (float.Parse(ds.Tables[0].Rows[i]["COST"].ToString()) + (float.Parse(ds.Tables[0].Rows[i]["COST"].ToString()) * 0.25)).ToString();
            //    ds.Tables[0].Rows[i]["DISCOUNT_PERC"] = (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) - (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(ds.Tables[0].Rows[i]["DISCOUNT_PERC"].ToString()) / 100)).ToString();

            //     if(i>=4)
            //    {
            //        ds.Tables[0].Rows[i]["DISCOUNT_PERC"] = float.Parse(ds.Tables[0].Rows[i]["DISCOUNT_PERC"].ToString()) * 0.5;
            //    }

            //    ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (Math.Round(float.Parse(ds.Tables[0].Rows[i]["DISCOUNT_PERC"].ToString()) * profit)).ToString();
            //    if (int.Parse(Session["prodId"].ToString()) == 111)
            //    {
            //        ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = Math.Round(float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) / 2.5);
            //    }
            //}
            //GrdPrices.DataSource = ds.Tables[0];
            //GrdPrices.DataBind();
            DataSet ds = OperationBL.loadFlyerPrice((Convert.ToString(Application["strDBConn"])), int.Parse(Session["spot"].ToString()), int.Parse(DRLMaterials.SelectedValue.ToString()));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["PRICE"] = Math.Round((float.Parse(ds.Tables[0].Rows[i]["PRICE"].ToString()) * float.Parse(Session["print"].ToString()) * float.Parse(Session["sizeCost"].ToString())) + (((float.Parse(ds.Tables[0].Rows[i]["QUANTITY"].ToString()) * float.Parse(Session["laminationPrice"].ToString())))
                                                            + ((float.Parse(ds.Tables[0].Rows[i]["QUANTITY"].ToString()) * float.Parse(Session["finishingPrice"].ToString())))
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



        protected void DRLProName_SelectedIndexChanged(object sender, EventArgs e)
        {

            loadFlyerMaterial();
            loadSize();
            Session["laminationPrice"] = 0;
            Session["laminationID"] = 0;
            Session["prodId"] = DRLProName.SelectedValue.ToString();
            DRLMaterials_SelectedIndexChanged(sender, e);
        }

        protected void DRLMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = PricesBL.getMaterialPrice((Convert.ToString(Application["strDBConn"])), int.Parse(DRLMaterials.SelectedValue.ToString()));
            Session["materialPrice"] = ds.Tables[0].Rows[0]["PAPER_PRICE"].ToString();

            int proID = int.Parse(Session["prodId"].ToString());
            if (proID == 105)
            {

                divSpecial.Visible = true;
                divLamin.Visible = true;
                DrpSecialEffect_SelectedIndexChanged(sender, e);
            }
            else
            {
                divSpecial.Visible = false;
                divLamin.Visible = false;
                DRLSides_SelectedIndexChanged(sender, e);
                Session["laminationPrice"] = 0;
                Session["laminationID"] = 100;
                Session["spot"] = 1;

            }
        }

        protected void DRLSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sizePric = int.Parse(DRLSize.SelectedValue.ToString());
            if (sizePric == 100)       //business card size
            {
                Session["size"] = 25;
                Session["sizeCost"] = 0.001;
            }
            else if (sizePric == 101)     //A3
            {
                Session["size"] = 1;
                Session["sizeCost"] = 1.3;
            }
            else if (sizePric == 102)      //A4
            {
                Session["size"] = 1.5;
                Session["sizeCost"] = 1;
            }
            else if (sizePric == 103)       //A4 landscape
            {
                Session["size"] = 1;
                Session["sizeCost"] = 1;
            }
            else if (sizePric == 104)      //A5
            {
                Session["size"] = 4;
                Session["sizeCost"] = 0.5;
            }
            else if (sizePric == 105)       //A6
            {
                Session["size"] = 8;
                Session["sizeCost"] = 0.25;
            }
            else if (sizePric == 107)        //A5 landscape
            {
                Session["size"] = 2;
                Session["sizeCost"] = 0.5;
            }
            else if (sizePric == 108)       //A6 landscape 
            {
                Session["size"] = 4;

                Session["sizeCost"] = 0.25;
            }
            else
            {
                Session["size"] = 2.6;

                Session["sizeCost"] = 0.125;
            }
            DrpFinishing_SelectedIndexChanged(sender, e);
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
                Session["laminationPrice"] = 0.01;
            }
            else
            {
                Session["laminationPrice"] = 0.02;
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
                Session["side"] = 0.15;
                Session["sideCost"] = 0.5;
            }
            DrpPrint_SelectedIndexChanged(sender, e);
        }

        protected void save_Click(object sender, EventArgs e)
        {
            double quntity = double.Parse(TXTQuantity.Text);
            double print = double.Parse(Session["materialPrice"].ToString()) + (double.Parse(Session["sideCost"].ToString()) * double.Parse(Session["print"].ToString()));
            double PrintCost = print * quntity / double.Parse(Session["size"].ToString());
            double laminationCost = double.Parse(Session["laminationPrice"].ToString()) * quntity;
            double SpotCost = double.Parse(Session["spotCost"].ToString()) * quntity / double.Parse(Session["size"].ToString());
            double foldPrice = double.Parse(Session["finishingPrice"].ToString()) * quntity;
            Session["cost"] = PrintCost + laminationCost + SpotCost + foldPrice;


            DataSet ds = OperationBL.insertOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()),
                int.Parse(DRLMaterials.SelectedValue.ToString()), int.Parse(DRLSize.SelectedValue.ToString()), int.Parse(Session["laminationID"].ToString()), DrpSecialEffect.Text.ToString(),
                int.Parse(DRLSides.SelectedValue.ToString()), int.Parse(DrpPrint.SelectedValue.ToString()), DrpFinishing.SelectedItem.Text, int.Parse(TXTQuantity.Text.ToString()),
                float.Parse(Session["cost"].ToString()), float.Parse(TxtPrice.Text.ToString()), int.Parse(Session["MainOrderID"].ToString()), int.Parse(Session["CustomerID"].ToString()));


            if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
            {
                divErrMsg.Visible = true;
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
                DataSet ds1 = OperationBL.insertCost((Convert.ToString(Application["strDBConn"])), int.Parse(Session["attOrderId"].ToString()), PrintCost, laminationCost, SpotCost, 0, 0, 0, 0, foldPrice, 0, double.Parse(Session["cost"].ToString()));
                Response.Redirect("../Design/LoadAtt.aspx");


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

        protected void DrpFinishing_SelectedIndexChanged(object sender, EventArgs e)
        {
            int finishingPric = int.Parse(DrpFinishing.SelectedValue.ToString());
            if (finishingPric == 100)
            {
                Session["finishingPrice"] = 0.0;
            }
            else if (finishingPric == 101)
            {
                Session["finishingPrice"] = 0.01;
            }
            else if (finishingPric == 102)
            {
                Session["finishingPrice"] = 0.01;
            }
            else if (finishingPric == 103)
            {
                Session["finishingPrice"] = 0.02;
            }
            else if (finishingPric == 104)
            {
                Session["finishingPrice"] = 0.02;
            }
            else
            {
                Session["finishingPrice"] = 0.03;
            }
            loadPrice();
        }

        protected void DrpUserId_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                if (quntity < 10)
                {
                    priceUnit = 3;
                }
                else if (quntity < 25 && quntity >= 10)
                {
                    priceUnit = 3;
                }
                else if (quntity < 50 && quntity >= 25)
                {
                    priceUnit = 2.8;
                }
                else if (quntity < 75 && quntity >= 50)
                {
                    priceUnit = 2.4;
                }
                else if (quntity < 100 && quntity >= 75)
                {
                    priceUnit = 2.1;
                }
                else if (quntity < 200 && quntity >= 100)
                {
                    priceUnit = 1.65;
                }
                else if (quntity < 300 && quntity >= 200)
                {
                    priceUnit = 1.4;
                }
                else if (quntity < 400 && quntity >= 300)
                {
                    priceUnit = 1.18;
                }
                else if (quntity < 500 && quntity >= 400)
                {
                    priceUnit = 1.1;
                }
                else if (quntity < 800 && quntity >= 500)
                {
                    priceUnit = 1;
                }
                else if (quntity < 1000 && quntity >= 800)
                {
                    priceUnit = 0.9;
                }

                else
                {
                    priceUnit = 0.8;
                }
            }
            else
            {
                if (quntity < 10)
                {
                    priceUnit = 11;
                }
                else if (quntity < 25 && quntity >= 10)
                {
                    priceUnit = 11;
                }
                else if (quntity < 50 && quntity >= 25)
                {
                    priceUnit = 7.4;
                }
                else if (quntity < 75 && quntity >= 50)
                {
                    priceUnit = 6.5;
                }
                else if (quntity < 100 && quntity >= 75)
                {
                    priceUnit = 6;
                }
                else if (quntity < 200 && quntity >= 100)
                {
                    priceUnit = 4.95;
                }
                else if (quntity < 300 && quntity >= 200)
                {
                    priceUnit = 3.325;
                }
                else if (quntity < 400 && quntity >= 300)
                {
                    priceUnit = 2.55;
                }
                else if (quntity < 500 && quntity >= 400)
                {
                    priceUnit = 1.92;
                }
                else if (quntity < 800 && quntity >= 500)
                {
                    priceUnit = 1.85;
                }
                else if (quntity < 1000 && quntity >= 800)
                {
                    priceUnit = 1.7;
                }

                else
                {
                    priceUnit = 1.6;
                }
            }
            price = (priceUnit * quntity * double.Parse(Session["print"].ToString()) * double.Parse(Session["sizeCost"].ToString()))
                     + (quntity * double.Parse(Session["laminationPrice"].ToString()))
                     + (quntity * double.Parse(Session["finishingPrice"].ToString()))
                     + (quntity * double.Parse(Session["side"].ToString()));

            TxtPrice.Text = Math.Round(price).ToString();


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
            else if (spot == 2)
            {
                Session["spotCost"] = 0.5;
            }
            else
            {
                Session["spotCost"] = 0.75;
            }
            DRLLamination_SelectedIndexChanged(sender, e);

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
    }
}