using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sevenG_DAL;
namespace sevenG_BL
{
    public class ProductsBL
    {
        public static DataSet insertPapers(string strConnStr, string paperName, string paperNameA,int paperType, int paperWght, string noPaper,float paperPrice, string paperCode)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.insertPapers(strConnStr, "insertPapers", paperName, paperNameA, paperType, paperWght, noPaper , paperPrice, paperCode);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadCategory(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.loadCategory(strConnStr, "loadCategory");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadCatProducts(string strConnStr, int catId)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.loadCatProducts(strConnStr, "loadCatProducts", catId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet LoadPapers(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.LoadPapers(strConnStr, "loadPapers");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet insertProdPaper(string strConnStr, int prodId, int paperId)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.insertProdPaper(strConnStr, "insertProdPaper", prodId, paperId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet deleteOrder(string strConnStr, int orderId,  int customerId)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.deleteOrder(strConnStr, "deleteOrder",orderId,customerId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet inserPaperPrice(string strConnStr, int catId, int paperId, int Quantity, int Price, int SpotUV1Price, int SpotUV2Price)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.inserPaperPrice(strConnStr, "inserPaperPrice",catId,paperId,Quantity,Price, SpotUV1Price, SpotUV2Price);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getPapers(string strConnStr, string paperName)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.getPapers(strConnStr, "getPapers", paperName);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet editPapers(string strConnStr, string paperName, string paperType, int paperWght, string noPaper, string paperCode)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.editPapers(strConnStr, "editPapers", paperName, paperType, paperWght, noPaper, paperCode);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet deletePapers(string strConnStr, string paperName)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.deletePapers(strConnStr, "deletePapers", paperName);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet InsertOrdProAtt(string strConnStr, int mainOrderId, int customerId,int orderId, int prodId, string filename, string RequestFolder)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.InsertOrdProAtt(strConnStr, "InsertOrdProAtt", mainOrderId, customerId,orderId, prodId, filename ,RequestFolder);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet InsertQuotAtt(string strConnStr, string qoutCode, string filename, string RequestFolder)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.InsertQuotAtt(strConnStr, "InsertQuotAtt", qoutCode, filename, RequestFolder);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet UpdateOrdProAtt(string strConnStr, int attOrderId, string filename)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.UpdateOrdProAtt(strConnStr, "UpdateOrdProAtt", attOrderId, filename);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getOrdProAtt(string strConnStr, int orderId)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.getOrdProAtt(strConnStr, "getOrdProAtt", orderId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadOrderDetails(string strConnStr, int orderId)
        {
            try
            {
                DataSet dsUserLogin = ProductsDAL.loadOrderDetails(strConnStr, "loadOrderDetails", orderId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
