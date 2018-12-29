<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="CustomOrder.aspx.cs" Inherits="sevenG.Order.CustomOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <li class="breadcrumb-item active">Custom Orders</li>
        </ol>
        
          <div class="card mb-3">
              <div class="card-header">
                  <i class="fa fa-table"></i>New Order
           
              </div>

          </div>
    
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">
                    <div class="col-md-6">
                        <label for="ProName">Product Name</label>
                        <asp:DropDownList ID="DRLCat" runat="server" class="form-control" placeholder="اسم المنتج" DataTextField="CATEGORY_NAME" DataValueField="CATEGORY_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLCat_SelectedIndexChanged"></asp:DropDownList>
                        <asp:LinkButton ID="BtnAddCat" runat="server" OnClick="BtnAddCat_Click">Add Product</asp:LinkButton>
                    </div>
                   
                  <div class="col-md-6">
                        <label for="noPaper">Description</label>
                        <asp:TextBox ID="TXTDescription" runat="server" Class="form-control" TextMode="MultiLine" Rows="2" placeholder="المواصفات" aria-describedby="No.Sheets" ></asp:TextBox>
                     </div>
                  <div class="col-md-6">
                        <label for="noPaper">Quantity</label>
                        <asp:TextBox ID="TXTQuantity" runat="server" AutoCompleteType="Disabled" Class="form-control" TextMode="Number" placeholder="الكمية" aria-describedby="No.Sheets" ></asp:TextBox>
                     </div>

                <div class="col-md-6">
                        <label for="noPaper">Price/unit</label>
                        <asp:TextBox ID="txtPrice" runat="server" Class="form-control" TextMode="Number" placeholder="سعر البيع" aria-describedby="No.Sheets" ></asp:TextBox>
                     </div>
                
                  <div class="col-md-6">
                        <label for="noPaper">Cost/unit</label>
                        <asp:TextBox ID="TXTCostPrice" runat="server" Class="form-control" TextMode="Number" placeholder="سعر التكلفة" aria-describedby="No.Sheets" ></asp:TextBox>
                     </div>

                    <div class="col-md-6" >
                        <label for="ProName">Supplier</label>
                        <asp:DropDownList ID="DRLSupplier" runat="server" class="form-control" DataTextField="SUPPLIER_NAME" DataValueField="SUPPLIER_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLSupplier_SelectedIndexChanged"></asp:DropDownList>
                       <asp:LinkButton ID="LnkSupplier" runat="server" OnClick="LnkSupplier_Click">Add Supplier</asp:LinkButton>
                   
                         </div>
                   
                </div>
            </div> 
            <div class="col-md-40 text-center">
                <asp:Button ID="BtnSave" class="btn btn-primary" runat="server" Text="Save" OnClick="BtnSave_Click" />
            </div>   
       </div>   
      </div>
                <div class="form-group text-center">
                    <span>
                        <asp:Label ID="LBLError" runat="server" Visible="False" class="margin text-center" ForeColor="#009933"></asp:Label></span>
                </div>
             
               
   
          </ContentTemplate>
        </asp:UpdatePanel>
   </form>
</asp:Content>
