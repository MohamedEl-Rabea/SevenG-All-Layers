using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sevenG_DAL;

namespace sevenG_BL
{
    public class SettingBL
    {
        public static DataSet insertCustomer(string strConnStr, string customerName, string customerNameAR, string compName, string customerAdd, string customerEmail, string customerPhone, string customerMobile,string customerJob,string compRole,string address2,string userName)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.insertCustomer(strConnStr, "insertCustomer", customerName, customerNameAR, compName, customerAdd, customerEmail, customerPhone, customerMobile,customerJob,compRole,address2, userName);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadSupplier(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.loadSupplier(strConnStr, "loadSupplier");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet queryQuotations(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.queryQuotations(strConnStr, "queryQuotations");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet searchQueryMainOrders(string strConnStr, DateTime fromDate, DateTime toDate)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.searchQueryMainOrders(strConnStr, "searchQueryMainOrders", fromDate, toDate);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet filterQueryMainOrders(string strConnStr, DateTime fromDate, DateTime toDate, string customerName)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.filterQueryMainOrders(strConnStr, "filterQueryMainOrders", fromDate, toDate , customerName);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet searchQueryQuotations(string strConnStr, DateTime fromDate, DateTime toDate)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.searchQueryQuotations(strConnStr, "searchQueryQuotations", fromDate, toDate);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet filterQueryQuotations(string strConnStr, DateTime fromDate, DateTime toDate, string customerName)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.filterQueryQuotations(strConnStr, "filterQueryQuotations", fromDate, toDate, customerName);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet searchQueryQuotationsCustomer(string strConnStr, string customerName)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.searchQueryQuotationsCustomer(strConnStr, "searchQueryQuotationsCustomer", customerName);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet searchQueryMainOrdersCustomer(string strConnStr, string customerName)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.searchQueryMainOrdersCustomer(strConnStr, "searchQueryMainOrdersCustomer", customerName);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet queryMainOrders(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.queryMainOrders(strConnStr, "queryMainOrders");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getProfileInfo(string strConnStr, string userName)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.getProfileInfo(strConnStr, "getProfileInfo", userName);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet editProfileInfo(string strConnStr, string customerName, string customerNameAR, string compName, string customerAdd, string customerEmail, string customerPhone, string customerMobile, string customerJob, string compRole, string address2, string userName)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.editProfileInfo(strConnStr, "editProfileInfo", customerName, customerNameAR, compName, customerAdd, customerEmail, customerPhone, customerMobile, customerJob, compRole, address2, userName);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet CheckUser(string strConnStr, string userEmail)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.CheckUser(strConnStr, "CheckUser", userEmail);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet updatePassword(string strConnStr, string userEmail, string userPassword)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.updatePassword(strConnStr, "updatePassword", userEmail, userPassword);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet insertUser(string strConnStr, string userName, string email, string password, string fname, string lname, string mobile, int userStatus)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.insertUser(strConnStr, "insertUser", userName, email, password, fname, lname, mobile, userStatus);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet CheckUserLogin(string strConnStr, string userEmail, string userPassword)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.CheckUserLogin(strConnStr, "CheckUserLogin", userEmail, userPassword);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadDivisions(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.loadDivisions(strConnStr, "loadDivisions");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadCustomers(string strConnStr,string userName)
        {
            try
            {
                DataSet dsUserLogin = SettingDAL.loadCustomers(strConnStr, "loadCustomers",userName);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
