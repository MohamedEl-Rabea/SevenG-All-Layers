using sevenG_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services;

namespace sevenG.Services
{
    /// <summary>
    /// Summary description for NotificationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class NotificationService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> getStockNotification()
        {
            List<string> result = new List<string>();
            DataSet ds = OperationBL.getStockNotification((Convert.ToString(Application["strDBConn"])));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result.Add(row.ItemArray[0].ToString());
            }
            return result;
        }

        [WebMethod(EnableSession = true)]
        public List<string> getCartNotification()
        {
            List<string> result = new List<string>();
            if (HttpContext.Current.Session["CustomerID"] != null)
            {
                DataSet ds = OperationBL.getStockNotification((Convert.ToString(Application["strDBConn"])));
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    result.Add(row.ItemArray[0].ToString());
                }
            }
            return result;
        }
    }
}
