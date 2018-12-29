using sevenG_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sevenG.Design
{
    public partial class LoadAtt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            string filename = e.FileName;

            DirectoryInfo strUploadPath = new DirectoryInfo(Server.MapPath("~/ProductsAttachment"));
            string path = Server.MapPath("~/ProductsAttachment/Order Id" + Session["attOrderId"].ToString());
            bool folderExists = Directory.Exists(path);
            if (folderExists)
                
            {
                AttachmentFileUpload1.SaveAs(path + "/" + filename);
                DataSet dsAtt = ProductsBL.UpdateOrdProAtt((Convert.ToString(Application["strDBConn"])), int.Parse(Session["attOrderId"].ToString()), filename);
            }
            else
            {
                string RequestFolder = "Order Id" + Session["attOrderId"].ToString();
                DirectoryInfo Subdirectory = strUploadPath.CreateSubdirectory(RequestFolder);
                AttachmentFileUpload1.SaveAs(@Subdirectory + "/" + filename);
                DataSet dsAtt = ProductsBL.InsertOrdProAtt((Convert.ToString(Application["strDBConn"])), int.Parse(Session["MOrderID"].ToString()), int.Parse(Session["CustomerNo"].ToString()), int.Parse(Session["attOrderId"].ToString()), 100, filename, RequestFolder);

            }

        }

        //protected void BtnDesignPage_Click(object sender, EventArgs e)
        //{

        //    Response.Redirect("ProcessDesign.aspx");
        //}

        protected void skip_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Order/Cart.aspx");
        }

        protected void BtnDesignPg_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProcessDesign.aspx");
        }
    }
}