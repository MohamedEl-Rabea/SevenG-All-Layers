using sevenG_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sevenG.Operation
{
    public partial class finishOperation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadProcessOrders();
            }
        }

        private void LoadProcessOrders()
        {
            DataSet ds = OperationBL.loadProcessOrders((Convert.ToString(Application["strDBConn"])));
            GrdOrders.DataSource = ds.Tables[0];
            GrdOrders.DataBind();
        }

        protected void GrdOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='Lavender';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void GrdOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GrdOrders.PageIndex = e.NewPageIndex;
            LoadProcessOrders();

        }


        protected void finish_Click(object sender, EventArgs e)
        {
            if (TXTPrEnd2.Text == null)
            {
                TXTPrEnd2.Text = "0";
            }
            if (TXTPrEnd3.Text == null)
            {
                TXTPrEnd3.Text = "0";
            }
            LBLError.Visible = true;
            if (Session["orderType"].ToString() == "Cover")
            {
              
                   DataSet dsCo = OperationBL.insertCoverOperation((Convert.ToString(Application["strDBConn"])), int.Parse(TXTOrderId.Text), int.Parse(TXTDraftSheets.Text), int.Parse(Session["ExpSheets"].ToString()), int.Parse(TXTPrEnd.Text), int.Parse(TXTPrEnd2.Text), int.Parse(TXTPrEnd3.Text));

                if (dsCo.Tables[0].Rows[0]["ret"].ToString() == "-1")
                {
                    LBLError.Text = "This operation is saved before";
                }
                else
                {
                    LBLError.Text = "The operation is saved successfully";
                    LoadProcessOrders();
                }
               
            }

            else
            {
                DataSet ds = OperationBL.insertOperation((Convert.ToString(Application["strDBConn"])), int.Parse(TXTOrderId.Text), int.Parse(TXTDraftSheets.Text),int.Parse(Session["ExpSheets"].ToString()), int.Parse(TXTPrEnd.Text), int.Parse(TXTPrEnd2.Text), int.Parse(TXTPrEnd3.Text));

                if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
                {
                    LBLError.Text = "This operation is saved before";
                }
                else
                {
                    LBLError.Text = "The operation is saved successfully";
                    LoadProcessOrders();
                }

            }

          
        }

        private void ClearControl()
        {

            TXTDraftSheets.Text = "";
            TXTPrEnd.Text = "";
        }

        protected void GrdOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            finish.Visible = true;
            ClearControl();
            loadOrderDetail();
            LBLError.Visible = false;
            if (Session["orderType"].ToString() == "Cover")
            {
                DataSet ds2 = OperationBL.getSubOperation((Convert.ToString(Application["strDBConn"])), int.Parse(TXTOrderId.Text));
                Session["ExpSheets"]  = ds2.Tables[0].Rows[0]["EXPECTED_S_SHEETS"].ToString();
            }
            else
            {
                DataSet ds1 = OperationBL.getOperation((Convert.ToString(Application["strDBConn"])), int.Parse(TXTOrderId.Text));
                Session["ExpSheets"] = ds1.Tables[0].Rows[0]["EXPECTED_S_SHEETS"].ToString();
            }
            
            
        }

        private void loadOrderDetail()
        {
            TXTOrderId.Text = GrdOrders.SelectedRow.Cells[0].Text;
            TXTProd.Text = GrdOrders.SelectedRow.Cells[1].Text;
            TXTPrinter.Text = GrdOrders.SelectedRow.Cells[2].Text;
            Session["orderType"] = GrdOrders.SelectedRow.Cells[3].Text;
            
        }

      

        


    }
}