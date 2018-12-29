using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sevenG_DAL
{
    public class PricesDAL
    {
        public static DataSet loadPrice(string strConnStr, string stordName, int categoryId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@CATEGORY_ID", categoryId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet getMaterialPrice(string strConnStr, string stordName, int materialId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PAPER_ID", materialId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet insertPurchasingPaper(string strConnStr, string stordName, int paperId, int paperNo, float papersPrice)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PAPER_ID", paperId);
                sqlCommandObj.Parameters.AddWithValue("@ST_B_SHEETS", paperNo);
                sqlCommandObj.Parameters.AddWithValue("@ROLL_PRICE", papersPrice);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet getCatProfit(string strConnStr, string stordName, int cATID)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@CAT_ID", cATID);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet getCategoryProfit(string strConnStr, string stordName, int categoryId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@CATEGORY_ID", categoryId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }
    }
}
