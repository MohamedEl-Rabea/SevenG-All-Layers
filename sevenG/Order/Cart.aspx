<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="sevenG.Order.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
   
     <form class="form-horizontal" runat="server">
        <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="update1" runat="server">
            <ContentTemplate> 
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
          <i class="fa fa-table"></i> Orders</div>
        <div class="card-body">
          <div class="table-responsive">
              
              <asp:GridView ID="GrdOrders" runat="server" Width="100%"
                  DataKeyNames="PROD_NAME,ORDER_ID" CssClass="table table-bordered" AllowSorting="true" OnSelectedIndexChanged="GrdOrders_SelectedIndexChanged" OnRowDataBound="GrdOrders_RowDataBound" OnPageIndexChanging="GrdOrders_PageIndexChanging" AllowPaging="true" AutoGenerateColumns="False">
                  <Columns>
                      <asp:TemplateField>
                          <ItemTemplate>
                              <%# Container.DataItemIndex + 1 %>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="ORDER_ID" HeaderText="Order Id" />
                      <asp:BoundField DataField="PROD_NAME" HeaderText="Product Name" />
                      <asp:BoundField DataField="PAPER_NAME" HeaderText="Material" />
                      <asp:BoundField DataField="SIZE_NAME" HeaderText="Size" />
                      <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                      <asp:BoundField DataField="TOTAL_PRICE" HeaderText="Price" />
                      <asp:TemplateField HeaderText="Addtional">

                            <ItemTemplate>

                                <asp:TextBox ID="txtAddtional" runat="server" Class="form-control" TextMode="Number" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txtAddtional_TextChanged" Width="70px" Text='0'></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtAddtional"></asp:RequiredFieldValidator>     
                       
                            </ItemTemplate>

                            </asp:TemplateField>
                      <asp:ButtonField Text="delete" CommandName="Select" ItemStyle-Width="25" ItemStyle-ForeColor="Red" />
                      
                  </Columns>

              </asp:GridView>
              
          </div> 
                   
               <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">


                    <div class="col-md-8">
                    </div>
             
              
                    <div class="col-md-3">
                        <td colspan="2">
                            <div style="float: left; width: 10px">
                                <label for="noPaper">Price</label>
                            </div>

                            <div style="float: right; width: 100px">
                                <asp:TextBox ID="TxtPrice" runat="server" Class="form-control" AutoCompleteType="Disabled" aria-describedby="Price" ReadOnly="True"></asp:TextBox>
                            </div>

                            <div style="clear: both"></div>

                        </td>
                    </div>  
              
                    <div class="col-md-8">
                        <div class="col-md-6">
                         <asp:RadioButtonList id="radQuotInv"  Class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radQuotInv_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Table" BorderStyle="NotSet">
                    <asp:ListItem Text="Quotation &nbsp &nbsp &nbsp &nbsp " Value="0" Selected="true" />
                    <asp:ListItem Text="Invoice" Value="1" />
                    </asp:RadioButtonList>
                         </div>   
                       </div> 
                    
                    
                    <div class="col-md-3">
                        <td colspan="2">
                            <div style="float: left; width: 100px">
                                <label for="noPaper">Tax 5%</label>
                            </div>

                            <div style="float: right; width: 100px">
                                <asp:TextBox ID="txtTax" runat="server" Class="form-control" Text="0" AutoCompleteType="Disabled" aria-describedby="Price" ReadOnly="true"></asp:TextBox>
                            </div>

                            <div style="clear: both"></div>

                        </td>
                    </div> 
               <div class="col-md-8">
                    </div>
               
              <div class="col-md-3">
                        <td colspan="2">
                            <div style="float: left; width: 10px">
                                <label for="noPaper">Addtional</label>
                            </div>

                            <div style="float: right; width: 100px">
                                <asp:TextBox ID="txtAdd" runat="server" ReadOnly="true" Class="form-control" AutoPostBack="true" OnTextChanged="txtAdd_TextChanged" TextMode="Number" AutoCompleteType="Disabled" aria-describedby="Price" Text="0"></asp:TextBox>
                            </div>

                            <div style="clear: both"></div>

                        </td>
                    </div> 
                    
                    <div class="col-md-8">
                    </div>
               
                    
                    
              <div class="col-md-3">
                        <td colspan="2">
                            <div style="float: left; width: 10px">
                                <label for="noPaper">Discount%</label>
                            </div>

                            <div style="float: right; width: 100px">
                                <asp:TextBox ID="txtDiscount" runat="server" Class="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtDiscount_TextChanged" AutoCompleteType="Disabled" aria-describedby="Price" Text="0"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtDiscount"></asp:RequiredFieldValidator>     
                       
                            </div>

                            <div style="clear: both"></div>

                        </td>
                    </div> 
                    
                     <div class="col-md-8">
                    </div>
               
              <div class="col-md-3">
                        <td colspan="2">
                            <div style="float: left; width: 100px">
                                <label for="noPaper">Total</label>
                            </div>

                            <div style="float: right; width: 100px">
                                <asp:TextBox ID="TxtTotal" runat="server" Class="form-control"  ReadOnly="true" AutoCompleteType="Disabled" aria-describedby="Price"></asp:TextBox>
                            </div>

                            <div style="clear: both"></div>

                        </td>
                    </div> 
                    

                     </div>
                
               </div>
          
            <div class="col-md-40 text-center"> 
                <asp:Button ID="finish" class="btn btn-primary" runat="server" Text="Save"  OnClick="finish_Click"/>
                 </div>

         

        </div>
                  <div class="form-group text-center">
                                <span>
                                    <asp:Label ID="LBLError" runat="server" Visible="False"  class="margin text-center" ForeColor="#009933"></asp:Label></span>
                            </div>
      </div>

       </div>
     
    
                 </ContentTemplate>
        </asp:UpdatePanel> 
   </form>
</asp:Content>
