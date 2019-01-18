using sevenG_BL;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace sevenG.Products
{
    public partial class books_bocklets_category : System.Web.UI.Page
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
                    loadCoversPrintType();
                    DRLProName_SelectedIndexChanged(sender, e);
                    DRLSize_SelectedIndexChanged(sender, e);
                    DrpCoPrintType_SelectedIndexChanged(sender, e);
                }
                else
                {
                    Response.Redirect("../Order/new-order.aspx");
                }
            }
        }

        private void loadCoversPrintType()
        {
            int categoryId = 205;
            DataSet ds = OperationBL.loadProducts((Convert.ToString(Application["strDBConn"])), categoryId);
            DrpCoPrintType.DataSource = ds.Tables[0];
            DrpCoPrintType.DataBind();
        }


        private void loadPrinters()
        {
            DataSet ds = OperationBL.loadPrinters((Convert.ToString(Application["strDBConn"])));
            DrpPrint.DataSource = ds.Tables[0];
            DrpPrint.DataBind();
            DrpCoPrint.DataSource = ds.Tables[0];
            DrpCoPrint.DataBind();
        }
        private void loadLaminations()
        {
            DataSet ds = OperationBL.loadLaminations((Convert.ToString(Application["strDBConn"])));
            DRLLamination.DataSource = ds.Tables[0];
            DRLLamination.DataBind();
            DRPCoLamination.DataSource = ds.Tables[0];
            DRPCoLamination.DataBind();
        }

        private void loadProducts()
        {
            int categoryId = 204;
            DataSet ds = OperationBL.loadProducts((Convert.ToString(Application["strDBConn"])), categoryId);
            DRLProName.DataSource = ds.Tables[0];
            DRLProName.DataBind();
        }

        private void loadPrice()
        {
            clearControl();
            int categoryId = 204;
            DataSet ds1 = PricesBL.getCategoryProfit((Convert.ToString(Application["strDBConn"])), categoryId);
            float profit = float.Parse(ds1.Tables[0].Rows[0]["PROFIT"].ToString());
            DataSet ds = PricesBL.loadPrice((Convert.ToString(Application["strDBConn"])), categoryId);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                ds.Tables[0].Rows[i]["COVER_COST"] = float.Parse(ds.Tables[0].Rows[i]["QUANTITY_ID"].ToString()) * 10;


                // Paper+Cover Cost
                ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (float.Parse(Session["printPrice"].ToString()) * float.Parse(ds.Tables[0].Rows[i]["QUANTITY_ID"].ToString()) * (float.Parse(Session["pagesNo"].ToString()))).ToString();


                //Quantity discount
                ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) - (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(ds.Tables[0].Rows[i]["DISCOUNT_PERC"].ToString()) / 100)).ToString();

                ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (Math.Round(float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) + float.Parse(ds.Tables[0].Rows[i]["COVER_COST"].ToString()))).ToString();
                ds.Tables[0].Rows[i]["COST"] = float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) - float.Parse(ds.Tables[0].Rows[i]["COVER_COST"].ToString());
            }
            GrdPrices.DataSource = ds.Tables[0];
            GrdPrices.DataBind();

        }

        protected void DRLProName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMaterial();
            loadSize();
            loadCoverMaterial();
            DRLMaterials_SelectedIndexChanged(sender, e);
        }

        private void loadSize()
        {
            DataSet ds = OperationBL.loadSize((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()));
            DRLSize.DataSource = ds.Tables[0];
            DRLSize.DataBind();
        }

        private void loadMaterial()
        {
            DataSet ds = OperationBL.loadMaterial((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()));
            DRLMaterials.DataSource = ds.Tables[0];
            DRLMaterials.DataBind();

        }

        private void loadMaterialBindng()
        {
            divErrMsg.Visible = false;
            DataSet ds = OperationBL.loadMaterialBindng((Convert.ToString(Application["strDBConn"])), int.Parse(DRLMaterials.SelectedValue.ToString()));
            Session["PAPER_BINDING"] = ds.Tables[0].Rows[0]["PAPER_BINDING"].ToString();
            int paperBinding = int.Parse(Session["PAPER_BINDING"].ToString());
            // BINDING 0 SADDLE  , 1 Perfect
            if (paperBinding == 0)
            {
                Binding.Items[0].Enabled = false;
                Binding.Items[1].Selected = true;
                divErrMsg.Visible = true;
                LBLError.Text = "The material must be less than 135gm with saddle option";
            }
            else
            {
                Binding.Items[0].Enabled = true;
            }

        }
        private void loadPrinterMaterial()
        {
            DataSet ds = OperationBL.loadMaterial((Convert.ToString(Application["strDBConn"])), int.Parse(DrpCoPrintType.SelectedValue.ToString()));
            DRPCoMaterial.DataSource = ds.Tables[0];
            DRPCoMaterial.DataBind();
        }
        private void loadCoverMaterial()
        {
            DataSet ds = OperationBL.loadCoverMaterial((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()));
            DRPCoMaterial.DataSource = ds.Tables[0];
            DRPCoMaterial.DataBind();
        }
        protected void DRLMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMaterialBindng();
            DataSet ds = PricesBL.getMaterialPrice((Convert.ToString(Application["strDBConn"])), int.Parse(DRLMaterials.SelectedValue.ToString()));
            Session["materialPrice"] = ds.Tables[0].Rows[0]["PAPER_PRICE"].ToString();
            DRLLamination_SelectedIndexChanged(sender, e);
        }

        protected void DRLSize_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["sizeId"] = DRLSize.SelectedValue.ToString();
            int sizePric = int.Parse(DRLSize.SelectedValue.ToString());

            if (sizePric == 100)       //business card size
            {
                Session["size"] = 25;
            }
            else if (sizePric == 101)     //A3
            {
                Session["size"] = 2;
            }
            else if (sizePric == 102)      //A4
            {
                Session["size"] = 1;
            }
            else if (sizePric == 103)       //A4 landscape
            {
                Session["size"] = 2;
            }
            else if (sizePric == 104)      //A5
            {
                Session["size"] = 2;
            }
            else if (sizePric == 105)       //A6
            {
                Session["size"] = 4;
            }
            else if (sizePric == 109)       //A6
            {
                Session["size"] = 2;
            }
            else if (sizePric == 107)        //A5 landscape
            {
                Session["size"] = 1;
            }
            else if (sizePric == 108)       //A6 landscape 
            {
                Session["size"] = 2;
            }
            else
            {
                Session["size"] = 1.3;
            }
            TxtPages_TextChanged(sender, e);
        }

        protected void DRLLamination_SelectedIndexChanged(object sender, EventArgs e)
        {
            int laminationPric = int.Parse(DRLLamination.SelectedValue.ToString());
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
            int sidePric = int.Parse(DRLSides.SelectedValue.ToString());
            if (sidePric == 1)
            {
                Session["sidePrice"] = 0.5;
            }
            else
            {
                Session["sidePrice"] = 1;
            }
            DrpPrint_SelectedIndexChanged(sender, e);
        }

        protected void DRPCoMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = PricesBL.getMaterialPrice((Convert.ToString(Application["strDBConn"])), int.Parse(DRPCoMaterial.SelectedValue.ToString()));
            Session["CoMaterialPrice"] = ds.Tables[0].Rows[0]["PAPER_PRICE"].ToString();

            int proID = int.Parse(Session["printTypeId"].ToString());
            if (proID == 120 || proID == 122)
            {
                divSpecial.Visible = false;
                divLamin.Visible = false;
                DRPCoSides_SelectedIndexChanged(sender, e);
                Session["CoLaminationPrice"] = 0;
                Session["CoLaminationID"] = 0;
            }
            else
            {
                divSpecial.Visible = true;
                divLamin.Visible = true;

                DrpSecialEffect_SelectedIndexChanged(sender, e);
            }
        }

        protected void DrpSecialEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SpecialEffect = int.Parse(DrpSecialEffect.SelectedValue.ToString());
            Session["spot"] = SpecialEffect.ToString();
            if (SpecialEffect == 1)
            {
                divLamin.Visible = true;

                Session["spotCost"] = 0;
                DRPCoLamination_SelectedIndexChanged(sender, e);
            }
            else
            {
                divLamin.Visible = false;
                Session["spotCost"] = 0.5;
                Session["CoLaminationPrice"] = 0.5;
                Session["CoLaminationID"] = 1;
                DRPCoSides_SelectedIndexChanged(sender, e);

            }



            DRPCoLamination_SelectedIndexChanged(sender, e);

        }
        protected void DRPCoLamination_SelectedIndexChanged(object sender, EventArgs e)
        {
            int laminationPric = int.Parse(DRPCoLamination.SelectedValue.ToString());
            Session["CoLaminationID"] = laminationPric;
            if (laminationPric == 100)
            {
                Session["CoLaminationPrice"] = 0;
            }
            else if (laminationPric == 101 || laminationPric == 102)
            {
                Session["CoLaminationPrice"] = 0.01;
            }
            else
            {
                Session["CoLaminationPrice"] = 0.02;
            }
            DRPCoSides_SelectedIndexChanged(sender, e);
        }

        protected void DRPCoSides_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sidePric = int.Parse(DRPCoSides.SelectedValue.ToString());
            if (sidePric == 1)
            {
                Session["CoSidePrice"] = 0.5;
            }
            else
            {
                Session["CoSidePrice"] = 1;
            }
            Binding_SelectedIndexChanged(sender, e);
        }

        public void clearControl()
        {
            TxtPrice.Text = "";
            TXTQuantity.Text = "";
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string bookType = "Portrait";
            divErrMsg.Visible = false;
            try
            {
                //all quantity based on no.pages
                int allQuantity = (int.Parse(TXTQuantity.Text.ToString()) * int.Parse(TxtPages.Text.ToString()) / 2);

                if (float.Parse(Session["sidePrice"].ToString()) == 0.5)
                {
                    allQuantity = allQuantity * 2;
                }

                //insert order for paper
                DataSet ds = OperationBL.insertOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()),
                int.Parse(DRLMaterials.SelectedValue.ToString()), int.Parse(Session["sizeId"].ToString()), int.Parse(DRLLamination.SelectedValue.ToString()), DrpSecialEffect.Text.ToString(),
                int.Parse(DRLSides.SelectedValue.ToString()), int.Parse(DrpPrint.SelectedValue.ToString()), null, allQuantity,
                float.Parse(Session["cost"].ToString()), float.Parse(Session["cost"].ToString()), int.Parse(Session["MainOrderID"].ToString()), int.Parse(Session["CustomerID"].ToString()));

                //insert order for covers
                DataSet dsc = OperationBL.insertSubOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLMaterials.SelectedValue.ToString()), bookType,
                  int.Parse(TxtPages.Text.ToString()), int.Parse(Binding.SelectedValue.ToString()),
                    int.Parse(DRPCoMaterial.SelectedValue.ToString()), int.Parse(Session["sizeId"].ToString()),
                      int.Parse(Session["CoLaminationID"].ToString()), int.Parse(DRPCoSides.SelectedValue.ToString()),
                   int.Parse(DrpCoPrint.SelectedValue.ToString()), int.Parse(TXTQuantity.Text.ToString()), float.Parse(Session["CoCost"].ToString()));



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



                    double quntity = (double.Parse(TXTQuantity.Text) / double.Parse(Session["size"].ToString())) / 2;
                    double print = double.Parse(Session["materialPrice"].ToString()) + (double.Parse(Session["SidePrice"].ToString()) * double.Parse(Session["printPrice"].ToString()));
                    double PrintCost = print * quntity;
                    if (Binding.Items[1].Selected)
                    {
                        PrintCost = PrintCost * 2;
                    }
                    double laminationCost = double.Parse(Session["laminationPrice"].ToString()) * quntity;
                    double cost = PrintCost + laminationCost;

                    double coprint = double.Parse(Session["CoMaterialPrice"].ToString()) + (double.Parse(Session["CoSidePrice"].ToString()) * double.Parse(Session["CoPrintPrice"].ToString()));
                    double coPrintCost = coprint * quntity;
                    if (Binding.Items[1].Selected)
                    {
                        coPrintCost = coPrintCost * 2;
                    }
                    double colaminationCost = double.Parse(Session["ColaminationPrice"].ToString()) * quntity;
                    double Covercost = coPrintCost + colaminationCost;

                    Session["cost"] = cost + Covercost;

                    DataSet ds1 = OperationBL.insertCost((Convert.ToString(Application["strDBConn"])), int.Parse(Session["attOrderId"].ToString()), PrintCost, laminationCost, 0, 0, 0, 0, 0, 0, Covercost, double.Parse(Session["cost"].ToString()));

                    Response.Redirect("../Design/load-attachments.aspx");

                }
            }
            catch
            {
                divErrMsg.Visible = true;
                LBLError.Text = "Please ,fill all fields ..";
            }


        }

        protected void BtnQuantity_Click(object sender, EventArgs e)
        {
            TXTQuantity.ReadOnly = false;
            TXTQuantity.Text = "";
            TxtPrice.Text = "";
        }
        protected void Binding_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 0 is for material can bes saddle 

            Session["sizeId"] = DRLSize.SelectedValue.ToString();
            int sizePric = int.Parse(Session["sizeId"].ToString());
            if (Binding.Items[1].Selected)
            {
                ComparePages.Enabled = false;
                Session["SaddlePrice"] = 0.25;
                Session["bindingPrice"] = 0.5;


            }
            else
            {

                ComparePages.Enabled = true;
                if (TxtPages.Text == null)
                {
                    TxtPages.Text = "4";
                }
                Session["SaddlePrice"] = 0.25;

                Session["bindingPrice"] = 0.5;
            }

            DrpCoPrint_SelectedIndexChanged(sender, e);
        }

        protected void DrpCoPrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            int printPric = int.Parse(DrpCoPrint.SelectedValue.ToString());
            if (printPric == 100)
            {
                Session["CoPrintPrice"] = 0.5;
            }

            else
            {
                Session["CoPrintPrice"] = 0.25;
            }

            loadPrice();
        }


        protected void DrpPrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            int printPric = int.Parse(DrpPrint.SelectedValue.ToString());
            if (printPric == 100)
            {
                Session["printPrice"] = 1;
            }

            else
            {
                Session["printPrice"] = 0.5;
            }
            DRLSize_SelectedIndexChanged(sender, e);
        }

        protected void TXTQuantity_TextChanged(object sender, EventArgs e)
        {
            double discount = 0;
            //int categoryId = 204;
            double quntity = double.Parse(TXTQuantity.Text);
            if (quntity < 3)
            {
                discount = 0;
            }

            else if (quntity < 7 && quntity >= 4)
            {
                discount = 8;
            }
            else if (quntity < 25 && quntity >= 7)
            {
                discount = 10;
            }

            else if (quntity < 50 && quntity >= 25)
            {
                discount = 20;
            }
            else if (quntity < 75 && quntity >= 50)
            {
                discount = 30;
            }
            else if (quntity < 300 && quntity >= 75)
            {
                discount = 40;
            }
            else
            {
                discount = 50;
            }


            //DataSet ds1 = PricesBL.getCategoryProfit((Convert.ToString(Application["strDBConn"])), categoryId);
            //double profit = double.Parse(ds1.Tables[0].Rows[0]["PROFIT"].ToString());



            //double cost = ( double.Parse(Session["materialPrice"].ToString()))
            //           +  (double.Parse(Session["laminationPrice"].ToString()))
            //            + ( double.Parse(Session["printPrice"].ToString()) * double.Parse(Session["sidePrice"].ToString()));

            //cost = cost * quantityPrice;

            //double totalCost = (cost)     //intrnal paper
            //           + (quntity * 3)    //cover
            //           + (quntity * double.Parse(Session["bindingPrice"].ToString()));    //binding



            //totalCost = totalCost * profit;

            //totalCost = totalCost - (totalCost * discount / 100);

            //Paper Cost
            double paperPrice = double.Parse(Session["pagesNo"].ToString()) * double.Parse(Session["printPrice"].ToString());
            paperPrice = paperPrice - (paperPrice * discount / 100);
            //total
            double totalCost = quntity * (paperPrice + 10);

            TxtPrice.Text = Math.Round(totalCost).ToString();

            Session["CoCost"] = quntity * 10;
            Session["cost"] = totalCost - double.Parse(Session["CoCost"].ToString());
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
            Session["cost"] = GrdPrices.DataKeys[GrdPrices.SelectedRow.RowIndex]["COST"].ToString();
            Session["CoCost"] = GrdPrices.DataKeys[GrdPrices.SelectedRow.RowIndex]["COVER_COST"].ToString();

        }

        protected void DrpCoPrintType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPrinterMaterial();
            Session["ColaminationPrice"] = 0;
            Session["CoLaminationID"] = 0;
            Session["printTypeId"] = DrpCoPrintType.SelectedValue.ToString();
            if (int.Parse(Session["printTypeId"].ToString()) == 119)
            {
                loadCoverMaterial();
            }

            DRPCoMaterial_SelectedIndexChanged(sender, e);
        }

        protected void TxtPages_TextChanged(object sender, EventArgs e)
        {
            Session["pagesNo"] = TxtPages.Text;
            DrpCoPrintType_SelectedIndexChanged(sender, e);
        }

    }
}