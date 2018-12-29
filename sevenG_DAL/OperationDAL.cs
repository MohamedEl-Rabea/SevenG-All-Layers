using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sevenG_DAL
{
    public class OperationDAL
    {
        public static DataSet loadLaminations(string strConnStr, string stordName)
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

        public static DataSet loadMainOrderDesign(string strConnStr, string stordName)
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

        public static DataSet getCatPapers(string strConnStr, string stordName, int catId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommandObj.Parameters.AddWithValue("@CAT_ID", catId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadFolderPrice(string strConnStr, string stordName ,int spot ,int paperId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommandObj.Parameters.AddWithValue("@SPOT", spot);

                sqlCommandObj.Parameters.AddWithValue("@PAPER_ID", paperId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadFlyerMaterial(string strConnStr, string stordName, int prodId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PROD_ID", prodId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet insertCustomOrder(string strConnStr, string stordName, int catId, string description, int supplierId, int quantity, float costPrice, float totalPrice, int mainOrderId, int customerId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PROD_ID", catId);
                sqlCommandObj.Parameters.AddWithValue("@DESCRIPTION", description);
                sqlCommandObj.Parameters.AddWithValue("@SUPPLIER_ID", supplierId);
                sqlCommandObj.Parameters.AddWithValue("@QUANTITY", quantity);
                sqlCommandObj.Parameters.AddWithValue("@COST", costPrice);
                sqlCommandObj.Parameters.AddWithValue("@TOTAL_PRICE", totalPrice);
                sqlCommandObj.Parameters.AddWithValue("@MAIN_ORDER_ID", mainOrderId);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_ID", customerId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadCAT(string strConnStr, string stordName)
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

        public static DataSet getMainOrderCustomer(string strConnStr, string stordName, int mOrderID)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommandObj.Parameters.AddWithValue("@MAIN_ORDER_ID", mOrderID);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadFlyerPrice(string strConnStr, string stordName, int spot, int paperId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommandObj.Parameters.AddWithValue("@SPOT", spot);

                sqlCommandObj.Parameters.AddWithValue("@PAPER_ID", paperId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadBusinessCardPrice(string strConnStr, string stordName, int spot, int paperId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommandObj.Parameters.AddWithValue("@SPOT", spot);

                sqlCommandObj.Parameters.AddWithValue("@PAPER_ID", paperId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadBusinessCardMaterial(string strConnStr, string stordName, int prodId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PROD_ID", prodId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadMaterial(string strConnStr, string stordName, int prodId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PROD_ID", prodId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadMainOrders(string strConnStr, string stordName, string userName)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommandObj.Parameters.AddWithValue("@PRINT_USER_NAME", userName);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

      

        public static DataSet getCartOrders(string strConnStr, string stordName,int customerId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_ID", customerId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet updateOrderDesign(string strConnStr, string stordName, int mainOrderId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@MAIN_ORDER_ID", mainOrderId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadInvRep(string strConnStr, string stordName, int mainOrderId, int customerId)
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
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadQuotations(string strConnStr, string stordName, int customerId)
        {

            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_ID", customerId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet insertReOrder(string strConnStr, string stordName, string mainOrderId, int customerId, int orderId)
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
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadProcessOrders(string strConnStr, string stordName)
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

        public static DataSet insertCost(string strConnStr, string stordName,int orderID, double printCost, double laminationCost, double spotCost, double spin, double cDCost, double pocketCost, double cornerCost, double FoldCost, double Cocost ,double cost)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommandObj.Parameters.AddWithValue("@ORDER_ID", orderID);
                sqlCommandObj.Parameters.AddWithValue("@PRINT_COST", printCost);
                sqlCommandObj.Parameters.AddWithValue("@LAMINATION_COST", laminationCost);
                sqlCommandObj.Parameters.AddWithValue("@SPOT_COST", spotCost);
                sqlCommandObj.Parameters.AddWithValue("@SPIN_COST", spin);
                sqlCommandObj.Parameters.AddWithValue("@CD_COST", cDCost);
                sqlCommandObj.Parameters.AddWithValue("@POCKET_COST", pocketCost);
                sqlCommandObj.Parameters.AddWithValue("@FOLD_COST", FoldCost);
                sqlCommandObj.Parameters.AddWithValue("@CORNER_COST", cornerCost);
                sqlCommandObj.Parameters.AddWithValue("@COVER_COST", Cocost);
                sqlCommandObj.Parameters.AddWithValue("@TOTAL_COST", cost);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet updateQuotation(string strConnStr, string stordName, int customerId, string quotCode, string rejReason, int approveRejCh , int payMethod)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_ID", customerId);
                sqlCommandObj.Parameters.AddWithValue("@QUOTATION_CODE", quotCode);
                sqlCommandObj.Parameters.AddWithValue("@REJECT_REASON", rejReason);
                sqlCommandObj.Parameters.AddWithValue("@APPROVE_REJ_ID", approveRejCh);
                sqlCommandObj.Parameters.AddWithValue("@PAYMENT_METHOD", payMethod);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadUsers(string strConnStr, string stordName)
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

        public static DataSet editOrder(string strConnStr, string stordName, int orderId, int addtional , string type)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@ORDER_ID", orderId);
                sqlCommandObj.Parameters.AddWithValue("@ADDTIONAL", addtional);
                sqlCommandObj.Parameters.AddWithValue("@TYPE", type);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet updateMainOrder(string strConnStr, string stordName, int mainOrder, int customerId, int quot_inv, float orderPrice, float tax, float orderAddtion, int orderDisc, float orderTotal)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@MAIN_ORDER_ID", mainOrder);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_ID", customerId);
                sqlCommandObj.Parameters.AddWithValue("@QUOT_INVOICE_ID", quot_inv);
                sqlCommandObj.Parameters.AddWithValue("@ORDER_PRICE", orderPrice);
                sqlCommandObj.Parameters.AddWithValue("@TAX", tax);
                sqlCommandObj.Parameters.AddWithValue("@ORDER_ADDTION", orderAddtion);
                sqlCommandObj.Parameters.AddWithValue("@ORDER_DISCOUNT", orderDisc);
                sqlCommandObj.Parameters.AddWithValue("@ORDER_TOTAL_PRICE", orderTotal);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadFinishing(string strConnStr, string stordName)
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

        public static DataSet insertMainOrder(string strConnStr, string stordName, int customerId, string userName, int divisionId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_ID", customerId);
                sqlCommandObj.Parameters.AddWithValue("@PRINT_USER_NAME", userName);
                sqlCommandObj.Parameters.AddWithValue("@DIVISION_ID", divisionId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadCorners(string strConnStr, string stordName)
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

        public static DataSet getStockNotification(string strConnStr, string stordName)
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

        public static DataSet loadPrinters(string strConnStr, string stordName)
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

        public static DataSet loadOrders(string strConnStr, string stordName)
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

        public static DataSet loadFolderMaterial(string strConnStr, string stordName , int prodId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PROD_ID", prodId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadCoverMaterial(string strConnStr, string stordName, int prodId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PROD_ID", prodId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet getSubOperation(string strConnStr, string stordName, int orderId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@ORDER_ID", orderId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadMaterialBindng(string strConnStr, string stordName, int paperId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PAPER_ID", paperId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet insertCoverProcessOperation(string strConnStr, string stordName, int orderId, int coStrPrint , int coStrPrint2, int coStrPrint3)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@ORDER_ID", orderId);
                sqlCommandObj.Parameters.AddWithValue("@START_COUNTER", coStrPrint);
                sqlCommandObj.Parameters.AddWithValue("@START_COUNTER2", coStrPrint2);
                sqlCommandObj.Parameters.AddWithValue("@START_COUNTER3", coStrPrint3);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadBookDetails(string strConnStr, string stordName, int orderId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@ORDER_ID", orderId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet insertOperation(string strConnStr, string stordName, int orderId, int draftSheets, int expectedSheets, int endCounter , int endCounter2, int endCounter3)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@ORDER_ID", orderId);
                sqlCommandObj.Parameters.AddWithValue("@DRAFT_S_SHEETS", draftSheets);
                sqlCommandObj.Parameters.AddWithValue("@EXPECTED_S_SHEETS", expectedSheets);
                sqlCommandObj.Parameters.AddWithValue("@END_COUNTER", endCounter);
                sqlCommandObj.Parameters.AddWithValue("@END_COUNTER2", endCounter2);
                sqlCommandObj.Parameters.AddWithValue("@END_COUNTER3", endCounter3);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet insertProcessOperation(string strConnStr, string stordName, int orderId, int strPrint ,int strPrint2 ,int strPrint3)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@ORDER_ID", orderId);
                sqlCommandObj.Parameters.AddWithValue("@START_COUNTER", strPrint);
                sqlCommandObj.Parameters.AddWithValue("@START_COUNTER2", strPrint2);
                sqlCommandObj.Parameters.AddWithValue("@START_COUNTER3", strPrint3);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet insertCoverOperation(string strConnStr, string stordName, int orderId, int coDraftSheets, int coExpectedSheets, int coEndCounter , int coEndCounter2, int coEndCounter3)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@ORDER_ID", orderId);
                sqlCommandObj.Parameters.AddWithValue("@DRAFT_S_SHEETS", coDraftSheets);
                sqlCommandObj.Parameters.AddWithValue("@EXPECTED_S_SHEETS", coExpectedSheets);
                sqlCommandObj.Parameters.AddWithValue("@END_COUNTER", coEndCounter);
                sqlCommandObj.Parameters.AddWithValue("@END_COUNTER2", coEndCounter2);
                sqlCommandObj.Parameters.AddWithValue("@END_COUNTER3", coEndCounter3);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet insertSubOrder(string strConnStr, string stordName,int paperId, string bookType, int bookPages, int bookBinding, int coMatId, int coSizeId, int coLamaintionId, int coSides, int coPrinter, int coPages ,float coverCost)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
            {
                CommandType = CommandType.StoredProcedure
            };
                sqlCommandObj.Parameters.AddWithValue("@PAPER_ID", paperId);
                sqlCommandObj.Parameters.AddWithValue("@BOOK_TYPE", bookType);
            sqlCommandObj.Parameters.AddWithValue("@NO_BOOKPAGES", bookPages);
            sqlCommandObj.Parameters.AddWithValue("@BOOK_BINDING", bookBinding);
            sqlCommandObj.Parameters.AddWithValue("@COVER_MATERIAL_ID", coMatId);
            sqlCommandObj.Parameters.AddWithValue("@COVER_SIZE_ID", coSizeId);
            sqlCommandObj.Parameters.AddWithValue("@COVER_LAMINATION_ID", coLamaintionId);
            sqlCommandObj.Parameters.AddWithValue("@COVER_NO_SIDES", coSides);
                sqlCommandObj.Parameters.AddWithValue("@COVER_PRINTER_ID", coPrinter);
                sqlCommandObj.Parameters.AddWithValue("@NO_COVERPAGES", coPages);
                sqlCommandObj.Parameters.AddWithValue("@COVER_COST", coverCost);
                sqlConnectionObj.Open();
            var adapt = new SqlDataAdapter(sqlCommandObj);
            adapt.Fill(returnResult);

            sqlCommandObj.Dispose();
            sqlConnectionObj.Close();
        }
            return returnResult;
        }

        public static DataSet loadProducts(string strConnStr, string stordName, int categoryId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@Category_ID", categoryId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet getOperation(string strConnStr, string stordName, int orderId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@ORDER_ID", orderId);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet insertOrder(string strConnStr, string stordName, int podId, int paperId, int sizeId, int laminationId,string spot, int noSides, int printer, string cornORfinish, int quantity, float cost, float total, int mainOrder, int customerID)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PROD_ID", podId);
                sqlCommandObj.Parameters.AddWithValue("@PAPER_ID", paperId);
                sqlCommandObj.Parameters.AddWithValue("@SIZE_ID", sizeId);
                sqlCommandObj.Parameters.AddWithValue("@LAMINATION_ID", laminationId);
                sqlCommandObj.Parameters.AddWithValue("@SPOT_UV", spot);
                sqlCommandObj.Parameters.AddWithValue("@NO_SIDES", noSides);
                sqlCommandObj.Parameters.AddWithValue("@PRINTER_ID", printer);
                sqlCommandObj.Parameters.AddWithValue("@CORNER", cornORfinish);
                sqlCommandObj.Parameters.AddWithValue("@QUANTITY", quantity);
                sqlCommandObj.Parameters.AddWithValue("@COST", cost);
                sqlCommandObj.Parameters.AddWithValue("@TOTAL_PRICE", total);
                sqlCommandObj.Parameters.AddWithValue("@MAIN_ORDER_ID", mainOrder);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_ID", customerID);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadSize(string strConnStr, string stordName,int prodId)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@PROD_ID", prodId);
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
