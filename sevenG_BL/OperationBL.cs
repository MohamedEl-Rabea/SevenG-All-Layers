using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sevenG_DAL;

namespace sevenG_BL
{
    public class OperationBL
    {

        public static DataSet loadLaminations(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadLaminations(strConnStr, "loadLaminations");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadMainOrderDesign(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadMainOrderDesign(strConnStr, "loadMainOrderDesign");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadFolderPrice(string strConnStr, int spot,int paperId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadFolderPrice(strConnStr, "loadFolderPrice" ,spot , paperId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      

        public static DataSet getCatPapers(string strConnStr, int catId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.getCatPapers(strConnStr, "getCatPapers", catId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadCAT(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadCAT(strConnStr, "loadCAT");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getMainOrderCustomer(string strConnStr, int MOrderID)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.getMainOrderCustomer(strConnStr, "getMainOrderCustomer", MOrderID);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadFlyerMaterial(string strConnStr, int prodId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadFlyerMaterial(strConnStr, "loadFlyerMaterial", prodId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadMainOrders(string strConnStr, string userName)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadMainOrders(strConnStr, "loadMainOrders", userName);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet insertCustomOrder(string strConnStr, int catId, string description, int supplierId, int Quantity, float costPrice, float totalPrice, int mainOrderId, int customerId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.insertCustomOrder(strConnStr, "insertCustomOrder",catId,description,supplierId,Quantity,costPrice,totalPrice, mainOrderId, customerId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getCartOrders(string strConnStr,int customerId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.getCartOrders(strConnStr, "getCartOrders", customerId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadQuotations(string strConnStr, int customerId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadQuotations(strConnStr, "loadQuotations", customerId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadInvRep(string strConnStr, int mainOrderId, int customerId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadInvRep(strConnStr, "loadInvRep", mainOrderId, customerId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadBusinessCardPrice(string strConnStr, int spot ,int paperId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadBusinessCardPrice(strConnStr, "loadBusinessCardPrice",spot,paperId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadProcessOrders(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadProcessOrders(strConnStr, "loadProcessOrders");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadFlyerPrice(string strConnStr, int spot, int paperId)
        {

            try
            {
                DataSet dsUserLogin = OperationDAL.loadFlyerPrice(strConnStr, "loadFlyerPrice", spot, paperId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadUsers(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadUsers(strConnStr, "loadUsers");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet updateOrderDesign(string strConnStr, int mainOrderId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.updateOrderDesign(strConnStr, "updateOrderDesign" , mainOrderId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadBusinessCardMaterial(string strConnStr, int prodId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadBusinessCardMaterial(strConnStr, "loadBusinessCardMaterial", prodId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadFinishing(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadFinishing(strConnStr, "loadFinishing");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet updateQuotation(string strConnStr, int customerId, string quotCode, string rejReason, int ApproveRejCh, int payMethod)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.updateQuotation(strConnStr, "updateQuotation", customerId,quotCode,rejReason,ApproveRejCh ,payMethod);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public static DataSet loadCorners(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadCorners(strConnStr, "loadCorners");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadMaterial(string strConnStr, int prodId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadMaterial(strConnStr, "loadMaterial", prodId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet insertReOrder(string strConnStr, string mainOrderId, int customerId, int orderId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.insertReOrder(strConnStr, "insertReOrder", mainOrderId, customerId, orderId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getStockNotification(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.getStockNotification(strConnStr, "getStockNotification");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet editOrder(string strConnStr, int orderId, int addtional,string type)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.editOrder(strConnStr, "editOrder", orderId, addtional , type);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet updateMainOrder(string strConnStr, int mainOrder, int customerId, int quot_inv, float orderPrice, float tax, float orderAddtion, int orderDisc, float orderTotal)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.updateMainOrder(strConnStr, "updateMainOrder", mainOrder,  customerId,  quot_inv,  orderPrice,  tax,  orderAddtion,  orderDisc,  orderTotal);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadPrinters(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadPrinters(strConnStr, "loadPrinters");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet insertMainOrder(string strConnStr, int customerId, string userName, int divisionId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.insertMainOrder(strConnStr, "insertMainOrder", customerId, userName, divisionId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadOrders(string strConnStr)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadOrders(strConnStr, "loadOrders");
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet loadFolderMaterial(string strConnStr,int prodId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadFolderMaterial(strConnStr, "loadFolderMaterial", prodId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadProducts(string strConnStr,int categoryId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadProducts(strConnStr, "loadProducts", categoryId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet insertCost(string strConnStr,int orderID, double printCost, double laminationCost, double spotCost, double spin, double cDCost, double pocketCost, double cornerCost, double FoldCost, double Cocost ,double cost)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.insertCost(strConnStr, "insertCost", orderID,  printCost,  laminationCost,  spotCost,  spin,  cDCost,  pocketCost,cornerCost,FoldCost, Cocost,  cost);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadLandScapeSize(string strConnStr, int prodId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadSize(strConnStr, "loadLandScapeSize", prodId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet insertOperation(string strConnStr, int orderId, int draftSheets, int expectedSheets, int endCounter , int endCounter2, int endCounter3)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.insertOperation(strConnStr, "insertOperation", orderId, draftSheets, expectedSheets, endCounter , endCounter2 , endCounter3);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadCoverMaterial(string strConnStr, int prodId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadCoverMaterial(strConnStr, "loadCoverMaterial", prodId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getSubOperation(string strConnStr, int orderId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.getSubOperation(strConnStr, "getSubOperation", orderId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadMaterialBindng(string strConnStr, int PaperId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadMaterialBindng(strConnStr, "loadMaterialBindng", PaperId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadSize(string strConnStr,int prodId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.loadSize(strConnStr, "loadSize", prodId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet loadBookDetails(string strConnStr, int orderId)
        {

            try
            {
                DataSet dsUserLogin = OperationDAL.loadBookDetails(strConnStr, "loadBookDetails", orderId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
        public static DataSet insertOrder(string strConnStr, int podId, int paperId, int sizeId, int laminationId, string spot , int noSides, int printer, string cornORfinish ,int quantity,float cost,float total , int mainOrder, int customerID)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.insertOrder(strConnStr, "insertOrder",  podId,  paperId,  sizeId,  laminationId,spot,  noSides, printer, cornORfinish, quantity, cost, total, mainOrder, customerID);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet getOperation(string strConnStr, int orderId)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.getOperation(strConnStr, "getOperation", orderId);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet insertCoverProcessOperation(string strConnStr, int orderId, int coStrPrint, int coStrPrint2, int coStrPrint3)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.insertCoverProcessOperation(strConnStr, "insertCoverProcessOperation", orderId, coStrPrint, coStrPrint2, coStrPrint3);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet insertSubOrder(string strConnStr,int paperId, string bookType, int bookPages, int bookBinding, int coMatId, int coSizeId, int coLamaintionId, int coSides, int coPrinter, int coPages, float coverCost)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.insertSubOrder(strConnStr, "insertSubOrder", paperId, bookType, bookPages, bookBinding, coMatId, coSizeId, coLamaintionId, coSides, coPrinter, coPages, coverCost);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet insertCoverOperation(string strConnStr, int orderId, int coDraftSheets, int coExpectedSheets, int coEndCounter , int coEndCounter2 , int coEndCounter3)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.insertCoverOperation(strConnStr, "insertCoverOperation", orderId, coDraftSheets, coExpectedSheets,  coEndCounter , coEndCounter2 , coEndCounter3);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet insertProcessOperation(string strConnStr, int orderId,int strPrint , int strPrint2 , int strPrint3)
        {
            try
            {
                DataSet dsUserLogin = OperationDAL.insertProcessOperation(strConnStr, "insertProcessOperation", orderId, strPrint , strPrint2 ,strPrint3);
                return dsUserLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    }
