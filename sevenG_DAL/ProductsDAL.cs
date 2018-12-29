using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sevenG_DAL
{
    public class ProductsDAL
    {
        public static DataSet insertPapers(string strConnStr, string stordName, string paperName, string paperNameA, int paperType, int paperWght, string noPaper , float paperPrice, string paperCode)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PAPER_NAME", paperName);
                sqlCommandObj.Parameters.AddWithValue("@PAPER_TYPE", paperNameA);
                sqlCommandObj.Parameters.AddWithValue("@SUB_CAT", paperType);
                sqlCommandObj.Parameters.AddWithValue("@PAPER_WEIGHT", paperWght);
                sqlCommandObj.Parameters.AddWithValue("@NO_INSIDE_PAPERS", noPaper);
                sqlCommandObj.Parameters.AddWithValue("@PAPER_PRICE", paperPrice);
                sqlCommandObj.Parameters.AddWithValue("@PAPER_CODE", paperCode);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;

        }

        public static DataSet loadCatProducts(string strConnStr, string stordName, int catId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@CATEGORY_ID", catId);
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet insertProdPaper(string strConnStr, string stordName, int prodId, int paperId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PROD_ID", prodId);
                sqlCommandObj.Parameters.AddWithValue("@PAPER_ID", paperId);
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet inserPaperPrice(string strConnStr, string stordName, int catId, int paperId, int quantity, int price, int spotUV1Price, int spotUV2Price)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@CATEGORY_ID", catId);
                sqlCommandObj.Parameters.AddWithValue("@TYPE", paperId);
                sqlCommandObj.Parameters.AddWithValue("@QUANTITY", quantity);
                sqlCommandObj.Parameters.AddWithValue("@PRICE", price);
                sqlCommandObj.Parameters.AddWithValue("@SPOTUV1", spotUV1Price);
                sqlCommandObj.Parameters.AddWithValue("@SPOTUV2", spotUV2Price);
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadCategory(string strConnStr, string stordName)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet InsertQuotAtt(string strConnStr, string stordName, string qoutCode, string filename, string requestFolder)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@QUOT_CODE", qoutCode);
                sqlCommandObj.Parameters.AddWithValue("@ATT_FILE_NAME", filename);
                sqlCommandObj.Parameters.AddWithValue("@ERQ_FOLDER", requestFolder);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet deleteOrder(string strConnStr, string stordName, int orderId,  int customerId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@ORDER_ID", orderId);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_ID", customerId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet LoadPapers(string strConnStr, string stordName)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
               
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;

        }

        public static DataSet InsertOrdProAtt(string strConnStr, string stordName, int mainOrderId, int customerId,int orderId, int prodId, string filename, string RequestFolder)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@MAIN_ORDER_ID", mainOrderId);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_ID", customerId);
                sqlCommandObj.Parameters.AddWithValue("@ORDER_ID", orderId);
                sqlCommandObj.Parameters.AddWithValue("@PROD_ID", prodId);
                sqlCommandObj.Parameters.AddWithValue("@ATT_FILE_NAME", filename);
                sqlCommandObj.Parameters.AddWithValue("@ERQ_FOLDER", RequestFolder );
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadOrderDetails(string strConnStr, string stordName, int orderId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("ORDER_ID", orderId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet UpdateOrdProAtt(string strConnStr, string stordName, int attOrderId, string filename)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("ORDER_ID", attOrderId);
                sqlCommandObj.Parameters.AddWithValue("@ATT_FILE_NAME", filename);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet getOrdProAtt(string strConnStr, string stordName, int orderId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("ORDER_ID", orderId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet deletePapers(string strConnStr, string stordName, string paperName)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PAPER_NAME", paperName);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet editPapers(string strConnStr, string stordName, string paperName, string paperType, int paperWght, string noPaper, string paperCode)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PAPER_NAME", paperName);
                sqlCommandObj.Parameters.AddWithValue("@PAPER_TYPE", paperType);
                sqlCommandObj.Parameters.AddWithValue("@PAPER_WEIGHT", paperWght);
                sqlCommandObj.Parameters.AddWithValue("@NO_INSIDE_PAPERS", noPaper);
                sqlCommandObj.Parameters.AddWithValue("@PAPER_CODE", paperCode);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet getPapers(string strConnStr, string stordName , string paperName)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PAPER_NAME", paperName);
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
