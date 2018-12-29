using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sevenG_DAL;

namespace sevenG_BL
{
    public class PricesBL
    {
        public static DataSet loadPrice(string strConnStr,int categoryId)
        {
            try
            {
                DataSet dsUserLogin = PricesDAL.loadPrice(strConnStr, "loadPrice" , categoryId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getMaterialPrice(string strConnStr, int materialId)
        {
            try
            {
                DataSet dsUserLogin = PricesDAL.getMaterialPrice(strConnStr, "getMaterialPrice", materialId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getCategoryProfit(string strConnStr, int categoryId)
        {
            try
            {
                DataSet dsUserLogin = PricesDAL.getCategoryProfit(strConnStr, "getCategoryProfit", categoryId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet insertPurchasingPaper(string strConnStr, int paperId, int paperNo, float papersPrice)
        {
            try
            {
                DataSet dsUserLogin = PricesDAL.insertPurchasingPaper(strConnStr, "insertPurchasingPaper", paperId, paperNo, papersPrice);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet getCatProfit(string strConnStr, int CATID)
        {
            try
            {
                DataSet dsUserLogin = PricesDAL.getCatProfit(strConnStr, "getCatProfit", CATID);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
