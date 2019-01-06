using sevenG_BL;
using System;
using System.Data;
using System.IO;

namespace sevenG.Design
{
    public partial class load_attachments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AttachmentFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
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

        protected void save_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Order/my-cart.aspx");
        }
    }
}