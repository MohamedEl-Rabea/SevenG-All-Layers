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
    public partial class Books : System.Web.UI.Page
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
                    Response.Redirect("../Order/Order.aspx");
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
                ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_ID"].ToString()) * (float.Parse(Session["pagesNo"].ToString()) / 2) / float.Parse(Session["size"].ToString())).ToString();
                //Paper Cost
                ds.Tables[0].Rows[i]["COST"] = ((float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(Session["materialPrice"].ToString()))
                                                            + (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(Session["laminationPrice"].ToString()))
                                                            + (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_ID"].ToString())/float.Parse(Session["size"].ToString()) * float.Parse(Session["bindingPrice"].ToString()))
                                                            + (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(Session["printPrice"].ToString())
                                                            * float.Parse(Session["SaddlePrice"].ToString()) * float.Parse(Session["sidePrice"].ToString()))).ToString();
                // Cover Cost
                ds.Tables[0].Rows[i]["COVER_COST"] = ((float.Parse(ds.Tables[0].Rows[i]["QUANTITY_ID"].ToString())/ float.Parse(Session["size"].ToString()) * float.Parse(Session["CoMaterialPrice"].ToString()))
                                                     + (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_ID"].ToString())/ float.Parse(Session["size"].ToString()) * float.Parse(Session["CoLaminationPrice"].ToString()))
                                                     + (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_ID"].ToString())/ float.Parse(Session["size"].ToString()) * float.Parse(Session["CoPrintPrice"].ToString()) * float.Parse(Session["CoSidePrice"].ToString()))).ToString();
                // Paper+Cover Cost
                ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (float.Parse(ds.Tables[0].Rows[i]["COST"].ToString()) + float.Parse(ds.Tables[0].Rows[i]["COVER_COST"].ToString())).ToString();
                // Office fees
                ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) + (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * 0.25)).ToString();
                //Quantity discount
                ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) - (float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * float.Parse(ds.Tables[0].Rows[i]["DISCOUNT_PERC"].ToString()) / 100)).ToString();
                ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = (Math.Round(float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * profit)).ToString();

                if (i <= 4)
                {
                    ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = Math.Round(float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * 1.5);
                }
                if (float.Parse(Session["SaddlePrice"].ToString()) == 1.5)
                {
                    ds.Tables[0].Rows[i]["QUANTITY_PRICE"] = Math.Round(float.Parse(ds.Tables[0].Rows[i]["QUANTITY_PRICE"].ToString()) * 0.6);
                }
            }
                GrdPrices.DataSource = ds.Tables[0];
                GrdPrices.DataBind();
            
        }

        private void clearControl()
        {
            TxtPrice.Text = "";
            TXTQuantity.Text = "";
        }

        //protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        //{

        //    string filename = e.FileName;

        //    DirectoryInfo strUploadPath = new DirectoryInfo(Server.MapPath("~/ProductsAttachment"));
        //    string RequestFolder = "Order Id" + Session["MainOrderID"].ToString() + Session["CustomerID"].ToString();
        //    DirectoryInfo Subdirectory = strUploadPath.CreateSubdirectory(RequestFolder);
        //    AttachmentFileUpload1.SaveAs(@Subdirectory + "/" + filename);
        //    DataSet dsAtt = ProductsBL.InsertOrdProAtt((Convert.ToString(Application["strDBConn"])), int.Parse(Session["MainOrderID"].ToString()), int.Parse(Session["CustomerID"].ToString()), int.Parse(DRLProName.SelectedValue.ToString()), filename, RequestFolder);
            


        //}
        protected void DRLProName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMaterial();
            loadSize();
            loadCoverMaterial();
            Session["prodId"] = DRLProName.SelectedValue.ToString();
            DRLMaterials_SelectedIndexChanged(sender, e);
        }

        private void loadSize()
        {
            DataSet ds = OperationBL.loadSize((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()));
            DRLSize.DataSource = ds.Tables[0];
            DRLSize.DataBind();
        }
        private void loadLandScapeSize()
        {
            DataSet ds = OperationBL.loadLandScapeSize((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()));
            DRLSize.DataSource = ds.Tables[0];
            DRLSize.DataBind();
        }

        private void loadMaterial()
        {
            DataSet ds = OperationBL.loadFolderMaterial((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()));
            DRLMaterials.DataSource = ds.Tables[0];
            DRLMaterials.DataBind();

        }

        private void loadPrinterMaterial()
        {
            DataSet ds = OperationBL.loadFolderMaterial((Convert.ToString(Application["strDBConn"])), int.Parse(DrpCoPrintType.SelectedValue.ToString()));
            DRPCoMaterial.DataSource = ds.Tables[0];
            DRPCoMaterial.DataBind();
        }
        private void loadMaterialBindng()
        {
            Lblalert.Enabled = false;
            DataSet ds = OperationBL.loadMaterialBindng((Convert.ToString(Application["strDBConn"])), int.Parse(DRLMaterials.SelectedValue.ToString()));
            Session["PAPER_BINDING"] = ds.Tables[0].Rows[0]["PAPER_BINDING"].ToString();
            int paperBinding = int.Parse(Session["PAPER_BINDING"].ToString());
            if (paperBinding == 0)
            {
                Binding.Items[0].Enabled = false;
                Binding.Items[1].Selected = true;
                Lblalert.Enabled = true;
                Lblalert.Text = "Note:The material must be less than 135gm with saddle option";
            }
            else
            {
                Binding.Items[0].Enabled = true;
            }

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
            if (Session["SaddlePrice"] == null)
            {
                Session["SaddlePrice"] = 1;
            }
            Session["sizeId"] = DRLSize.SelectedValue.ToString();
            int sizePric = int.Parse(Session["sizeId"].ToString());
            if (float.Parse(Session["SaddlePrice"].ToString()) == 1.5)
            {
                if (sizePric == 102)
                {
                    Session["sizeId"] = 103;
                }
                else if (sizePric == 104)
                {
                    Session["sizeId"] = 107;
                }
                else if (sizePric == 105)
                {
                    Session["sizeId"] = 108;
                }
            }
             sizePric = int.Parse(Session["sizeId"].ToString());

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
            int sidePric = int.Parse(DRLSides.SelectedValue.ToString());
            if (sidePric == 1)
            {
                Session["sidePrice"] = 1;
            }
            else
            {
                Session["sidePrice"] = 2;
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
            //if (SpecialEffect == 1)
            //{
            //      divLamin.Visible = true;
            //    DRPCoLamination_SelectedIndexChanged(sender, e);
            //}
            //else
            //{
            //    divLamin.Visible = false;
            //    Session["CoLaminationPrice"] = 0.5;
            //    Session["CoLaminationID"] = 1;
            //    DRPCoSides_SelectedIndexChanged(sender, e);

            //}
            if (SpecialEffect == 2)
            {
                Session["SPOTPrice"] = 0;
            }
            else
            {
                Session["SPOTPrice"] = 0.5;
            }

            DRLLamination_SelectedIndexChanged(sender, e);
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
                Session["CoLaminationPrice"] = 0.1;
            }
            else
            {
                Session["CoLaminationPrice"] = 0.2;
            }
            DRPCoSides_SelectedIndexChanged(sender, e);

        }

        protected void DRPCoSides_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sidePric = int.Parse(DRPCoSides.SelectedValue.ToString());
            if (sidePric == 1)
            {
                Session["CoSidePrice"] = 1;
            }
            else
            {
                Session["CoSidePrice"] = 2;
            }
            Binding_SelectedIndexChanged(sender, e);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string bookType = "LandScape";
            Lblalert.Visible = false;
            try
            {
                //all quantity based on no.pages
                int allQuantity = (int.Parse(TXTQuantity.Text.ToString()) * int.Parse(TxtPages.Text.ToString()) / 2);

                if (int.Parse(Session["sidePrice"].ToString()) == 1)
                {
                    allQuantity = allQuantity * 2;
                }
                //insert order for paper
                DataSet ds = OperationBL.insertOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLProName.SelectedValue.ToString()),
                    int.Parse(DRLMaterials.SelectedValue.ToString()), int.Parse(Session["sizeId"].ToString()),
                    int.Parse(DRLLamination.SelectedValue.ToString()), DrpSecialEffect.Text.ToString(), int.Parse(DRLSides.SelectedValue.ToString()), int.Parse(DrpPrint.SelectedValue.ToString()),
                    null, allQuantity, float.Parse(Session["cost"].ToString()), float.Parse(Session["totalPrice"].ToString()), int.Parse(Session["MainOrderID"].ToString()),
                    int.Parse(Session["CustomerID"].ToString()));


                //insert order for covers
                DataSet dsc = OperationBL.insertSubOrder((Convert.ToString(Application["strDBConn"])), int.Parse(DRLMaterials.SelectedValue.ToString()), bookType,
                  int.Parse(TxtPages.Text.ToString()), int.Parse(Binding.SelectedValue.ToString()),
                    int.Parse(DRPCoMaterial.SelectedValue.ToString()), int.Parse(Session["sizeId"].ToString()),
                      int.Parse(Session["CoLaminationID"].ToString()), int.Parse(DRPCoSides.SelectedValue.ToString()),
                   int.Parse(DrpCoPrint.SelectedValue.ToString()), int.Parse(TXTQuantity.Text.ToString()) ,float.Parse(Session["CoCost"].ToString()));

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
                    //try
                    //{
                    //    //rename att folder to orderid
                    //    string orderId =ds.Tables[0].Rows[0]["ret"].ToString();
                    //string folder1 = "Order Id" + Session["MainOrderID"].ToString() + Session["CustomerID"].ToString();
                    //string folder2 = "Order Id" + orderId;
                    //string path = Server.MapPath("~/ProductsAttachment");
                    //string Fromfol = "\\" + folder1 + "\\";
                    //string Tofol = "\\" + folder2 + "\\";
                    //Directory.Move(path + Fromfol, path + Tofol);


                    //Response.Redirect("../Order/Cart.aspx");
                    //}
                    //catch
                    //{
                    //    LBLError.Visible = true;
                    //    LBLError.Text = " Please insert the attatchment ...";
                    //}
                }
            }
            catch
            {
                Lblalert.Visible = true;
                Lblalert.Text = "Please ,fill all fields ..";
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
            //items[0] is for material can bes saddle 
            if (Binding.Items[1].Selected)
            {
                ComparePages.Enabled = false;
                Session["SaddlePrice"] = 1;
                Session["bindingPrice"] = 0.5;
                Session["sizeId"] = DRLSize.SelectedValue.ToString();
                int sizePric = int.Parse(Session["sizeId"].ToString());
                if (sizePric == 102)
                {
                    Session["size"] = 2;
                }
                else if (sizePric == 104)
                {
                    Session["size"] = 4;
                }
                else if (sizePric == 105)
                {
                    Session["size"] = 8;
                }

            }
            else
            {
              
                int sizePric = int.Parse(Session["sizeId"].ToString());
                if (sizePric == 102)
                {
                    Session["sizeId"] = 103;
                    Session["size"] = 1;
                }
                else if (sizePric == 104)
                {
                    Session["sizeId"] = 107;
                    Session["size"] = 2;
                }
                else if (sizePric == 105)
                {
                    Session["sizeId"] = 108;
                    Session["size"] = 4;
                }

                ComparePages.Enabled = true;
                if (TxtPages.Text == null)
                {
                    TxtPages.Text = "10";
                }

                Session["SaddlePrice"] = 1.5;

                Session["bindingPrice"] = 0.5;
            }
            DrpCoPrint_SelectedIndexChanged(sender, e);
        }

        protected void DrpPrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            int printPric = int.Parse(DrpPrint.SelectedValue.ToString());
            if (printPric == 100)
            {
                Session["printPrice"] = 0.25;
            }

            else
            {
                Session["printPrice"] = 0.5;
            }
            DRLSize_SelectedIndexChanged(sender, e);
        }

        protected void DrpCoPrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            int printPric = int.Parse(DrpCoPrint.SelectedValue.ToString());
            if (printPric == 100)
            {
                Session["CoPrintPrice"] = 0.25;
            }

            else
            {
                Session["CoPrintPrice"] = 0.5;
            }

            loadPrice();
        }

     
        protected void TXTQuantity_TextChanged(object sender, EventArgs e)
        {
            double discount = 0;
            int categoryId = 204;
            double quntity = double.Parse(TXTQuantity.Text);
            if (quntity < 50)
            {
                discount = 0;
            }

            else if (quntity < 75 && quntity >= 50)
            {
                discount = 30;
            }
            else if (quntity < 100 && quntity >= 75)
            {
                discount = 25;
            }

            else if (quntity < 200 && quntity >= 100)
            {
                discount = 2;
            }
            else if (quntity < 300 && quntity >= 200)
            {
                discount = 12;
            }
            else if (quntity < 400 && quntity >= 300)
            {
                discount = 15;
            }
            else if (quntity < 500 && quntity >= 400)
            {
                discount = 17;
            }
            else if (quntity < 800 && quntity >= 500)
            {
                discount = 22;
            }
            else if (quntity < 1000 && quntity >= 800)
            {
                discount = 28;
            }
            else if (quntity < 2000 && quntity >= 1000)
            {
                discount = 33;
            }
            else if (quntity < 3000 && quntity >= 2000)
            {
                discount = 35;
            }
            else if (quntity < 4000 && quntity >= 3000)
            {
                discount = 40;
            }
            else if (quntity < 5000 && quntity >= 4000)
            {
                discount = 45;
            }
            else
            {
                discount = 50;
            }
          
            DataSet ds1 = PricesBL.getCategoryProfit((Convert.ToString(Application["strDBConn"])), categoryId);
            double profit = double.Parse(ds1.Tables[0].Rows[0]["PROFIT"].ToString());

            double quantityPrice = (quntity * double.Parse(Session["pagesNo"].ToString()) / 2) / double.Parse(Session["size"].ToString());
            int coverQuantitiy = int.Parse(TXTQuantity.Text.ToString()) / int.Parse(Session["size"].ToString());
            //Paper Cost
            double cost = (quantityPrice * double.Parse(Session["materialPrice"].ToString()))
                        + (quantityPrice * double.Parse(Session["laminationPrice"].ToString()))
                        + (coverQuantitiy * double.Parse(Session["bindingPrice"].ToString()))
                        + (quantityPrice * double.Parse(Session["printPrice"].ToString()) * double.Parse(Session["SaddlePrice"].ToString()) * double.Parse(Session["sidePrice"].ToString()));
            // Cover Cost
            double coverCost = (coverQuantitiy * double.Parse(Session["CoMaterialPrice"].ToString()))
                       + (coverQuantitiy * double.Parse(Session["CoLaminationPrice"].ToString()))
                       + (coverQuantitiy * double.Parse(Session["CoPrintPrice"].ToString()) * double.Parse(Session["CoSidePrice"].ToString()));

            Session["cost"] = cost;
            Session["CoCost"] = coverCost;
            // Paper+Cover Cost
            quantityPrice = cost + coverCost;
            // Office fees
            quantityPrice = quantityPrice + (quantityPrice * 0.25);
            //Quantity discount
            quantityPrice = quantityPrice - (quantityPrice * discount / 100);
            TxtPrice.Text = Math.Round(quantityPrice * profit).ToString();
            if (quntity <= 100)
            {
                TxtPrice.Text = Math.Round(double.Parse(TxtPrice.Text) * 1.5).ToString();
            }
            if (float.Parse(Session["SaddlePrice"].ToString()) == 1.5)
            {
                TxtPrice.Text = Math.Round(double.Parse(TxtPrice.Text) * 0.6).ToString();
            }

            Session["totalPrice"] = float.Parse(TxtPrice.Text) - float.Parse(Session["CoCost"].ToString());
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
            Session["totalPrice"] = float.Parse(TxtPrice.Text) - float.Parse(Session["CoCost"].ToString());
        }

        protected void DrpCoPrintType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPrinterMaterial();
            Session["ColaminationPrice"] = 0;
            Session["CoLaminationID"] = 0;
            Session["printTypeId"] = DrpCoPrintType.SelectedValue.ToString();
            if (int.Parse(Session["printTypeId"].ToString())==119)
            {
                loadCoverMaterial();
            }

            DRPCoMaterial_SelectedIndexChanged(sender, e);
        }

        protected void TxtPages_TextChanged(object sender, EventArgs e)
        {
           Session["pagesNo"]= TxtPages.Text;
            DrpCoPrintType_SelectedIndexChanged(sender, e);
        }

       

       
    }
}