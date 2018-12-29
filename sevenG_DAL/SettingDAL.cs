using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sevenG_DAL
{
    public class SettingDAL
    {
        public static DataSet insertCustomer(string strConnStr, string stordName, string customerName, string customerNameAR, string compName, string customerAdd, string customerEmail, string customerPhone, string customerMobile, string customerJob, string compRole, string address2, string userName)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_NAME", customerName);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_NAME_A", customerNameAR);
                sqlCommandObj.Parameters.AddWithValue("@COMPANY_NAME", compName);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_ADDRESS", customerAdd);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_EMAIL", customerEmail);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_PHONE", customerPhone);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_MOBILE", customerMobile);
                sqlCommandObj.Parameters.AddWithValue("@JOB_NAME", customerJob);
                sqlCommandObj.Parameters.AddWithValue("@COMPANY_ROLE", compRole);
                sqlCommandObj.Parameters.AddWithValue("@ADDRESS2", address2);
                sqlCommandObj.Parameters.AddWithValue("@PRINT_USER_NAME", userName);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet loadSupplier(string strConnStr, string stordName)
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

        public static DataSet queryQuotations(string strConnStr, string stordName)
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

        public static DataSet filterQueryQuotations(string strConnStr, string stordName, DateTime fromDate, DateTime toDate, string customerName)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@fromDate", fromDate);
                sqlCommandObj.Parameters.AddWithValue("@toDate", toDate);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_NAME", customerName);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet searchQueryQuotationsCustomer(string strConnStr, string stordName, string customerName)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_NAME", customerName);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet searchQueryQuotations(string strConnStr, string stordName, DateTime fromDate, DateTime toDate)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@fromDate", fromDate);
                sqlCommandObj.Parameters.AddWithValue("@toDate", toDate);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet searchQueryMainOrdersCustomer(string strConnStr, string stordName, string customerName)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_NAME", customerName);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet filterQueryMainOrders(string strConnStr, string stordName, DateTime fromDate, DateTime toDate, string customerName)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@fromDate", fromDate);
                sqlCommandObj.Parameters.AddWithValue("@toDate", toDate);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_NAME", customerName);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet searchQueryMainOrders(string strConnStr, string stordName, DateTime fromDate, DateTime toDate)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@fromDate", fromDate);
                sqlCommandObj.Parameters.AddWithValue("@toDate", toDate);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet queryMainOrders(string strConnStr, string stordName)
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

        public static DataSet getProfileInfo(string strConnStr, string stordName, string userName)
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

        public static DataSet editProfileInfo(string strConnStr, string stordName, string customerName, string customerNameAR, string compName, string customerAdd, string customerEmail, string customerPhone, string customerMobile, string customerJob, string compRole, string address2, string userName)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_NAME", customerName);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_NAME_A", customerNameAR);
                sqlCommandObj.Parameters.AddWithValue("@COMPANY_NAME", compName);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_ADDRESS", customerAdd);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_EMAIL", customerEmail);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_PHONE", customerPhone);
                sqlCommandObj.Parameters.AddWithValue("@CUSTOMER_MOBILE", customerMobile);
                sqlCommandObj.Parameters.AddWithValue("@JOB_NAME", customerJob);
                sqlCommandObj.Parameters.AddWithValue("@COMPANY_ROLE", compRole);
                sqlCommandObj.Parameters.AddWithValue("@ADDRESS2", address2);
                sqlCommandObj.Parameters.AddWithValue("@PRINT_USER_NAME", userName);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet CheckUser(string strConnStr, string stordName, string userEmail)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@USER_EMAIL", userEmail);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet updatePassword(string strConnStr, string stordName, string userEmail, string userPassword)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@USER_EMAIL", userEmail);
                sqlCommandObj.Parameters.AddWithValue("@USER_PASSWORD", userPassword);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet insertUser(string strConnStr, string stordName, string userName, string email, string password, string fname, string lname, string mobile, int userStatus)
        {
            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@USER_NAME", userName);
                sqlCommandObj.Parameters.AddWithValue("@USER_EMAIL", email);
                sqlCommandObj.Parameters.AddWithValue("@USER_PASSWORD", password);
                sqlCommandObj.Parameters.AddWithValue("@FIRST_NAME", fname);
                sqlCommandObj.Parameters.AddWithValue("@LAST_NAME", lname);
                sqlCommandObj.Parameters.AddWithValue("@MOBILE_NO", mobile);
                sqlCommandObj.Parameters.AddWithValue("@STATUS", userStatus);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
        }

        public static DataSet CheckUserLogin(string strConnStr, string stordName ,string userEmail, string userPassword)
        {

            var returnResult = new DataSet();

            using (SqlConnection sqlConnectionObj = new SqlConnection(strConnStr))
            {
                var sqlCommandObj = new SqlCommand(stordName, sqlConnectionObj)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommandObj.Parameters.AddWithValue("@USER_EMAIL", userEmail);
                sqlCommandObj.Parameters.AddWithValue("@USER_PASSWORD", userPassword);
                sqlConnectionObj.Open();
                var adapt = new SqlDataAdapter(sqlCommandObj);
                adapt.Fill(returnResult);

                sqlCommandObj.Dispose();
                sqlConnectionObj.Close();
            }
            return returnResult;
    }
        public static DataSet loadDivisions(string strConnStr, string stordName)
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

        public static DataSet loadCustomers(string strConnStr, string stordName ,string userName)
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
    }
}
