<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="ProcessDesign.aspx.cs" Inherits="sevenG.Design.ProcessDesign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
  
     <form class="form-horizontal" runat="server">
        <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
  =
      <div class="container-fluid">
        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="../views/HomePage.aspx">Home Page</a>
            </li>
            <li class="breadcrumb-item active">Designs</li>
        </ol>
        
          <div class="card mb-3">
              <div class="card-header">
                  <i class="fa fa-table"></i>Orders
           
              </div>

          </div>
    
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">
                    <div class="col-md-6">
                        <label for="ProName">Order#</label>
                        <asp:DropDownList ID="DRMainOrders" runat="server" class="form-control"  DataTextField="MAIN_ORDER_ID" DataValueField="MAIN_ORDER_ID" AutoPostBack="True" OnSelectedIndexChanged="DRMainOrders_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                   

                    <div class="col-md-6">
                       <label for="noPaper">Customer Name</label>
                        <asp:TextBox ID="TXTCustomer" runat="server" Class="form-control"  ReadOnly="True"></asp:TextBox>
                      </div>
                          <div class="col-md-6">
                        <label for="noPaper">Order Date</label>
                        <asp:TextBox ID="TxtDate" runat="server" Class="form-control"  ReadOnly="True"></asp:TextBox>
                    </div>
               
                </div>

            </div> 
            <div class="col-md-40 text-center">
                <asp:Button ID="BtnSave" class="btn btn-primary" runat="server" Text="Save" OnClick="BtnSave_Click" />
            </div>   
       </div>  
     <div class="form-group text-center">
                                <span>
                                    <asp:Label ID="LBLError" runat="server"   class="margin text-center" ForeColor="#009933"></asp:Label></span>
                            </div>
           
            
            
          
          
             <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i>Items</div>
        <div class="card-body">
          <div class="table-responsive">
              
             <asp:GridView ID="GrdOrders" runat="server"  width="100%" cellspacing="0"
                                DataKeyNames="ORDER_ID" CssClass="table table-bordered" AllowSorting="true" OnRowCommand="GrdOrders_RowCommand" AutoGenerateColumns="False">
                                <Columns>
                                    
                                       <asp:BoundField DataField="ORDER_ID" HeaderText="Item#" />
                                  <asp:BoundField DataField="PROD_NAME" HeaderText="Product Name" />
                                  <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                                     <asp:ButtonField CommandName="download" ItemStyle-Width="25" Text="Download" ShowHeader="True" HeaderText="Attatchment"></asp:ButtonField>
                     
                                    <asp:ButtonField CommandName="reLoad" ItemStyle-Width="25" Text="Edit" ButtonType="Button" ShowHeader="True" HeaderText="Edit Attat."></asp:ButtonField>
                     
                 
                                     
                                </Columns>
                                
                            </asp:GridView>
          
          </div>
        </div>
      </div>



          


           </div>
         
    

   </form>
</asp:Content>
