<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="Operate.aspx.cs" Inherits="sevenG.Operation.Operate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style>
            body
    {
        font-family: Arial;
        font-size: 10pt;
        color: #444;
    }
    .main_menu, .main_menu:hover
    {
        width: 100px;
        background-color: #fff;
        color: #333;
        text-align: center;
        height: 30px;
        line-height: 30px;
        margin-right: 5px;
    }
    .main_menu:hover
    {
        background-color: #ccc;
    }
        
    </style>
   
    <form class="form-horizontal" runat="server">
       
      <div class="container-fluid">
        <!-- Breadcrumbs-->
          
           
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="../views/HomePage.aspx">Home Page</a>
            </li>
            <li class="breadcrumb-item active">Operation</li>
        </ol>


                         <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Process Order
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">

                    <div class="col-md-6">
                        <label for="noPaper">Order Id</label>
                        <asp:TextBox ID="TXTOrderId" runat="server" Class="form-control" aria-describedby="OrderId" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label for="noPaper">Product Name</label>
                        <asp:TextBox ID="TXTProd" runat="server" Class="form-control" TextMode="MultiLine" Rows="2" aria-describedby="ProdName" ReadOnly="True"></asp:TextBox>
                     </div>
                    <div class="col-md-6">
                        <label for="noPaper">Paper Code</label>
                        <asp:TextBox ID="TXTPaperCode" runat="server" Class="form-control" aria-describedby="ProdName" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">Material</label>
                        <asp:TextBox ID="TXTMaterial" runat="server" Class="form-control" aria-describedby="Material" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">Size</label>
                        <asp:TextBox ID="TXTSize" runat="server" Class="form-control" aria-describedby="Size" ReadOnly="True"></asp:TextBox>
                     </div>
                    <div class="col-md-6">
                        <label for="noPaper">Lamination</label>
                        <asp:TextBox ID="TXTLamination" runat="server" Class="form-control" aria-describedby="Lamination" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">No. of Sides</label>
                        <asp:TextBox ID="TXTSide" runat="server" Class="form-control" aria-describedby="Sides" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">Quantity</label>
                        <asp:TextBox ID="TXTQuantity" runat="server" Class="form-control" aria-describedby="Quantity" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">Expectied No. of Sheets(33x48)</label>
                        <asp:TextBox ID="TXTExpSheets" runat="server" Class="form-control" aria-describedby="No.Sheets" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">Expectied No. of Sheets(70x100)</label>
                        <asp:TextBox ID="TXTExpPapers" runat="server" Class="form-control" aria-describedby="No.Sheets" ReadOnly="True"></asp:TextBox>
                     </div>
                     
                    <div class="col-md-6">
                        <label for="noPaper">Printer Counter at start</label>
                        <asp:TextBox ID="TXTPrStart" runat="server" Class="form-control"   aria-describedby="color counter now" placeholder="color counter now"  ></asp:TextBox>
                      
                        <asp:TextBox ID="TXTPrStart2" runat="server" Class="form-control" aria-describedby="No.Sheets"  placeholder="Black&White counter now" ></asp:TextBox>
                       
                        <asp:TextBox ID="TXTPrStart3" runat="server" Class="form-control" aria-describedby="No.Sheets"  placeholder="special effect counter now" ></asp:TextBox>
                       </div>
                       

                   <div class="col-md-6">
                     <label for="noPaper">Printer Type</label>
                        <asp:TextBox ID="TXTPrinter" runat="server" Class="form-control" aria-describedby="Sides" ReadOnly="True"></asp:TextBox>
                     </div>
                </div>
                
               </div>
            <div class="col-md-40 text-center"> 
                <asp:Button ID="Process" class="btn btn-primary" runat="server" Visible="false"  Text="Process"  OnClick="Process_Click"/>
                 </div>
           <div class="col-md-40 text-center"> 
                <asp:Button ID="BtnDownLoad" class="btn btn-primary" runat="server" Visible="false"  Text="DownLoad attatchment"  OnClick="BtnDownLoad_Click"/>
                   <asp:Button ID="BtnPrint" class="btn btn-primary" runat="server" Visible="false"  Text="DownLoad job order"  OnClick="BtnPrint_Click"/>
                
           </div>
           
           
</div>
         
      </div>
              
        
             <div class="card mb-3" id="cover" runat="server" visible="false">
                  
                         <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Cover Details
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">

                  
                     
                     <div class="col-md-6">
                        <label for="noPaper">Book Type</label>
                        <asp:TextBox ID="TxtBookType" runat="server" Class="form-control" aria-describedby="Size" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">Book Binding</label>
                        <asp:TextBox ID="TxtBookBinding" runat="server" Class="form-control" aria-describedby="Size" ReadOnly="True"></asp:TextBox>
                     </div>
                    <div class="col-md-6">
                        <label for="noPaper">Book No. of Pages</label>
                        <asp:TextBox ID="TxtNoPages" runat="server" Class="form-control" aria-describedby="Size" ReadOnly="True"></asp:TextBox>
                     </div>
                    <div class="col-md-6">
                        <label for="noPaper">Book spine in mm</label>
                        <asp:TextBox ID="TxtCoSpine" runat="server" Class="form-control" aria-describedby="Size" ReadOnly="True"></asp:TextBox>
                     </div>
                    <div class="col-md-6">
                        <label for="noPaper">Cover Paper Code</label>
                        <asp:TextBox ID="txtCoPaperCode" runat="server" Class="form-control" aria-describedby="ProdName" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">Cover Material</label>
                        <asp:TextBox ID="txtCoPaper" runat="server" Class="form-control" aria-describedby="Material" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">Cover Size</label>
                        <asp:TextBox ID="txtCoSize" runat="server" Class="form-control" aria-describedby="Size" ReadOnly="True"></asp:TextBox>
                     </div>
                    <div class="col-md-6">
                        <label for="noPaper">Cover Lamination</label>
                        <asp:TextBox ID="txtCoLam" runat="server" Class="form-control" aria-describedby="Lamination" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">Cover No.Sides</label>
                        <asp:TextBox ID="txtCoSide" runat="server" Class="form-control" aria-describedby="Sides" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">Cover Quantity</label>
                        <asp:TextBox ID="txtCoQnt" runat="server" Class="form-control" aria-describedby="Quantity" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">Cover Expectied No. of Sheets(33x48)</label>
                        <asp:TextBox ID="txtCoExpSheet" runat="server" Class="form-control" aria-describedby="No.Sheets" ReadOnly="True"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label for="noPaper">Cover Expectied No. of Sheets(70x100)</label>
                        <asp:TextBox ID="txtCoExpPage" runat="server" Class="form-control" aria-describedby="No.Sheets" ReadOnly="True"></asp:TextBox>
                     </div>
                    
                    
                         <div class="col-md-6">
                        <label for="noPaper">Cover Printer Counter at start</label>
                        <asp:TextBox ID="txtCoStsPrint" runat="server" Class="form-control" ReadOnly="True" aria-describedby="No.Sheets" ></asp:TextBox>
                         <asp:TextBox ID="txtCoStsPrint2" runat="server" Class="form-control" ReadOnly="True" aria-describedby="No.Sheets" ></asp:TextBox>          
                        <asp:TextBox ID="txtCoStsPrint3" runat="server" Class="form-control" ReadOnly="True" aria-describedby="No.Sheets" ></asp:TextBox>
                         </div>
                  
                     <div class="col-md-6">
                        <label for="noPaper">Cover Printer Type</label>
                        <asp:TextBox ID="TXTCoPrinter" runat="server" Class="form-control" aria-describedby="Sides" ReadOnly="True"></asp:TextBox>
                     </div>
                </div>
                
               
                </div>

            <div class="col-md-40 text-center"> 
                <asp:Button ID="coProcess" class="btn btn-primary" runat="server" Visible="false"  Text="Cover Process"  OnClick="coProcess_Click"/>
                 </div>
            
           
</div>
        
      
                             </div>
                 
                      
              
              </div>
      
    
         <div class="form-group text-center">
                                <span>
                                    <asp:Label ID="LBLError" runat="server" Visible="False"  class="margin text-center" ForeColor="#009933"></asp:Label></span>
                            </div>
           
            
            


      
             <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Orders</div>
        <div class="card-body">
          <div class="table-responsive">
              
             <asp:GridView ID="GrdOrders" runat="server"  width="100%" cellspacing="0"
                                DataKeyNames="PAPER_NAME" CssClass="table table-bordered" AllowSorting="true" OnSelectedIndexChanged = "GrdOrders_SelectedIndexChanged" OnRowDataBound="GrdOrders_RowDataBound" OnPageIndexChanging="GrdOrders_PageIndexChanging" AllowPaging="true" PageSize="10" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="ORDER_ID" HeaderText="Order Id" />
                                    <asp:BoundField DataField="PROD_NAME" HeaderText="Product Name" />
                                     <asp:BoundField DataField="PAPER_CODE" HeaderText="Paper Code" />
                                    <asp:BoundField DataField="PAPER_NAME" HeaderText="Material" />
                                    <asp:BoundField DataField="SIZE_NAME" HeaderText="Size" />
                                    <asp:BoundField DataField="LAMINATION_NAME" HeaderText="Lamination" />
                                    <asp:BoundField DataField="NO_SIDES" HeaderText="No. of Sides" />
                                    <asp:BoundField DataField="PRINTER_TYPE" HeaderText="Printer Type" />
                                    <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                                    <asp:BoundField DataField="ORDER_DATE" HeaderText="Order Date"  />
                                    <asp:BoundField DataField="MAIN_ORDER_ID" HeaderText="Main Order Id" />
                                     <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="30"  />
                                    
                                </Columns>
                                
                            </asp:GridView>
          
          </div>
        </div>
        <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
      </div>

       </div>
           
         
        
             
      

   
   </form>
</asp:Content>
