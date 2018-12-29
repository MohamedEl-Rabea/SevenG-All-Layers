<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="finishOperation.aspx.cs" Inherits="sevenG.Operation.finishOperation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                     <label for="noPaper">Printer Type</label>
                        <asp:TextBox ID="TXTPrinter" runat="server" Class="form-control" aria-describedby="Sides" ReadOnly="True"></asp:TextBox>
                     </div>

                    <div class="col-md-6">
                        <label for="noPaper">Product</label>
                        <asp:TextBox ID="TXTProd" runat="server" Class="form-control" TextMode="MultiLine" Rows="2" width="940px" aria-describedby="ProdName" ReadOnly="True"></asp:TextBox>
                     </div>
                  <div class="col-md-6">
                        </div>
                     <div class="col-md-6">
                        <label for="noPaper"> No. of Draft Sheets(33x48)</label>
                        <asp:TextBox ID="TXTDraftSheets" runat="server" Class="form-control" AutoCompleteType="Disabled" aria-describedby="No.Sheets" placeholder="Enter number of draft sheets"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="TXTDraftSheets"></asp:RequiredFieldValidator>     
                          </div>

                   
                    <div class="col-md-6">
                        <label for="noPaper">Printer Counter at end</label>
                        <asp:TextBox ID="TXTPrEnd" runat="server" Class="form-control" AutoCompleteType="Disabled" aria-describedby="No.Sheets" placeholder="color counter at end"></asp:TextBox>
                         <asp:TextBox ID="TXTPrEnd2" runat="server" Class="form-control"  aria-describedby="No.Sheets" placeholder="Black&White counter at end" ></asp:TextBox>          
                        <asp:TextBox ID="TXTPrEnd3" runat="server" Class="form-control"  aria-describedby="No.Sheets" placeholder="special effect counter at end" ></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="TXTPrEnd"></asp:RequiredFieldValidator>     
                       
                        <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red" SetFocusOnError="True"
                        ControlToValidate="TXTPrEnd" ErrorMessage="Value must be a number" />
                       
                     </div>

                 
                </div>
                
               </div>
          
            <div class="col-md-40 text-center"> 
                <asp:Button ID="finish" class="btn btn-primary" runat="server" Visible="false" Text="finish"  OnClick="finish_Click"/>
                 </div>
           
</div>
         
      </div>
              
        
         <div class="form-group text-center">
                                <span>
                                    <asp:Label ID="LBLError" runat="server" Visible="False"  class="margin text-center" ForeColor="#009933"></asp:Label></span>
                            </div>
           
          
             <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i>Processing Orders</div>
        <div class="card-body">
          <div class="table-responsive">
              
             <asp:GridView ID="GrdOrders" runat="server"  width="100%" cellspacing="0"
                                DataKeyNames="ORDER_ID" CssClass="table table-bordered" AllowSorting="true" OnSelectedIndexChanged = "GrdOrders_SelectedIndexChanged" OnRowDataBound="GrdOrders_RowDataBound" OnPageIndexChanging="GrdOrders_PageIndexChanging" AllowPaging="true" PageSize="10" AutoGenerateColumns="False">
                                <Columns>
                                    
                                    <asp:BoundField DataField="ORDER_ID" HeaderText="Order Id" />
                                    <asp:BoundField DataField="PROD_NAME" HeaderText="Product" />
                                    <asp:BoundField DataField="PRINTER_TYPE" HeaderText="Printer Type" />
                                    <asp:BoundField DataField="ret" HeaderText="Type" />

                                     <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="30"  />
                                    
                                </Columns>
                                
                            </asp:GridView>
          
          </div>
        </div>
      </div>

      
           
          </div>
        
                         
                 
   </form>
</asp:Content>
