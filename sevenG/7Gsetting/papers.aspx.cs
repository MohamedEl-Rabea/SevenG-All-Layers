using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sevenG_BL;
using System.Text;

namespace sevenG.Products
{
    public partial class papers : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
         {
            if (!IsPostBack)
            {
                //LoadPapers();
                loadCAT();
            }
        }

        private void loadCAT()
        {
            DataSet ds = OperationBL.loadCAT((Convert.ToString(Application["strDBConn"])));
            DRLCat.DataSource = ds.Tables[0];
            DRLCat.DataBind();
        }

        //private void LoadPapers()
        //{
        //   DataSet ds = ProductsBL.LoadPapers((Convert.ToString(Application["strDBConn"])));
        //    GrdPapers.DataSource = ds.Tables[0];
        //    GrdPapers.DataBind();
        //}

        protected void Save_Click(object sender, EventArgs e)
        {
            if (paperNametxt.Text != " ")
            {
                DataSet ds = ProductsBL.insertPapers((Convert.ToString(Application["strDBConn"])), paperNametxt.Text, paperNameAr.Text, int.Parse(DRLCat.SelectedValue.ToString()),int.Parse(txtPaperWght.Text.ToString()), noPapertxt.Text,float.Parse(TxtPaperPrice.Text),txtPaperCode.Text);
                LBLError.Visible = true;
                if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
                {
                    LBLError.Text = "This paper name is saved before";
                }
                else
                {
                    LBLError.Text = "The paper is saved successfully";
                    //LoadPapers();
                }
                ClearControl();
            }
            else
            {
                LBLError.Visible = true;
                LBLError.Text = "The paper name can't be space";
            }

        }

     
        //protected void GrdPapers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GrdPapers.PageIndex = e.NewPageIndex;
        //    LoadPapers();
        //}

        //protected void edit_Click(object sender, EventArgs e)
        //{

        //    DataSet ds = ProductsBL.editPapers((Convert.ToString(Application["strDBConn"])), paperNametxt.Text, paperTypetxt.Text, int.Parse(txtPaperWght.Text.ToString()), noPapertxt.Text, txtPaperCode.Text);
            
        //    if (ds.Tables[0].Rows[0]["ret"].ToString() == "-1")
        //    {
        //        LBLError.Text = "This paper name is not saved before";
        //    }
        //    else
        //    {
        //        LBLError.Text = "The paper is updated successfully";
        //        LoadPapers();
        //    }
        //}

        //protected void delete_Click(object sender, EventArgs e)
        //{
        //    DataSet ds = ProductsBL.deletePapers((Convert.ToString(Application["strDBConn"])), paperNametxt.Text);
            
        //    if (ds.Tables[0].Rows[0]["ret"].ToString() == "1")
        //    {
        //        LBLError.Text = "The paper is deleted successfully";
        //        LoadPapers();
        //        ClearControl();
        //    }

        //}

        private void ClearControl()
        {
            paperNametxt.Text = "";
            paperNameAr.Text = "";
            txtPaperWght.Text = "";
            noPapertxt.Text = "";
            TxtPaperPrice.Text = "";
            txtPaperCode.Text = "";
        }

        //protected void GrdPapers_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string paperName = GrdPapers.SelectedRow.Cells[0].Text;
            
        //    DataSet ds = ProductsBL.getPapers((Convert.ToString(Application["strDBConn"])), paperName);
        //    paperNametxt.Text = paperName;

        //    //txtPaperCode.Text = ds.Tables[0].Rows[0]["PAPER_CODE"].ToString();
        //    paperNameAr.Text = ds.Tables[0].Rows[0]["PAPER_TYPE"].ToString();
        //    txtPaperWght.Text = ds.Tables[0].Rows[0]["PAPER_WEIGHT"].ToString();
        //    noPapertxt.Text = ds.Tables[0].Rows[0]["NO_INSIDE_PAPERS"].ToString();

        //    //edit.Visible = true;
        //    //delete.Visible = true;
        //    save.Visible = false;
        //}

        protected void GrdPapers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='Lavender';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void DRLCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}