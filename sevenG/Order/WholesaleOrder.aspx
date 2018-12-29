<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="WholesaleOrder.aspx.cs" Inherits="sevenG.Order.Wholesale_Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
            <li class="breadcrumb-item active">Orders</li>
        </ol>
        
       <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Wholesale Order
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">

                     <div class="col-md-6">
                                <label for="ProName">Paper Type</label>                          
                                    <asp:DropDownList ID="DRLCat" runat="server" class="form-control" DataTextField="CAT_NAME_E" DataValueField="CAT_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLCat_SelectedIndexChanged"></asp:DropDownList>                              
                                </div>
                    <div class="col-md-6">
                        <label for="ProName">Paper Name</label>    
                        <asp:DropDownList ID="DRLMaterials" runat="server" class="form-control" DataTextField="PAPER_NAME" DataValueField="PAPER_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLMaterials_SelectedIndexChanged"></asp:DropDownList>                              
                    </div>

                   <div class="col-md-6">
                                <label for="ProName">Size</label>                          
                                    <asp:DropDownList ID="DRLSize" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DRLSize_SelectedIndexChanged">
                                         <asp:ListItem Value="101">A3(33*48)</asp:ListItem>
                                        <asp:ListItem Value="102">A4</asp:ListItem>
                                    </asp:DropDownList>                              
                            </div>
                 <%--   <div class="col-md-6" runat="server" id="divSpecial">
                                <label for="ProName">Special Effect</label>                          
                                    <asp:DropDownList ID="DrpSecialEffect" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DrpSecialEffect_SelectedIndexChanged">                              
                                        <asp:ListItem Value="1">Lamination</asp:ListItem>
                                        <asp:ListItem Value="2">Spot UV</asp:ListItem>
                                        </asp:DropDownList> 
                    </div>--%>
                   <%--  <div class="col-md-6" runat="server" id="divLamin" visible="false">
                   
                        <label for="Lamination">Lamination:</label>                          
                                    <asp:DropDownList ID="DRLLamination" runat="server" class="form-control" DataTextField="LAMINATION_NAME" DataValueField="LAMINATION_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLLamination_SelectedIndexChanged"></asp:DropDownList>                              
                            </div>
               --%>
                    <div class="col-md-6">
                        <label for="Lamination">Sides</label>                          
                                    <asp:DropDownList ID="DRLSides" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DRLSides_SelectedIndexChanged">
                                      
                                        <asp:ListItem Value="2">2 Sides</asp:ListItem>
                                          <asp:ListItem Value="1">1 Side</asp:ListItem>
                        </asp:DropDownList>                              
                            </div>
                    <div class="col-md-6">
                     <label for="ProName">Print Type</label>                          
                                    <asp:DropDownList ID="DrpPrint" runat="server" class="form-control" DataTextField="PRINTER_TYPE" DataValueField="PRINTER_ID" AutoPostBack="True" OnSelectedIndexChanged="DrpPrint_SelectedIndexChanged"></asp:DropDownList>                              
                        </div>
                    <div class="col-md-6">
                         <label for="noPaper">Quantity</label>
                        <asp:TextBox ID="TXTQuantity" runat="server" Text="0" Class="form-control" AutoPostBack="true" AutoCompleteType="Disabled"  aria-describedby="Quantity" OnTextChanged="TXTQuantity_TextChanged"></asp:TextBox>
                     <label for="noPaper">Price</label>
                        <asp:TextBox ID="TxtPrice" runat="server" Class="form-control" AutoCompleteType="Disabled" aria-describedby="Price" ReadOnly="True"></asp:TextBox>
                           
                          </div>
                      

                     
                     <%-- <div class="col-md-6" runat="server" id="divempty" >
                     </div>--%>
                        <%--   <div class="col-md-6">
                        <label for="noPaper">Quantity</label>
                        <asp:TextBox ID="TXTQuantity" runat="server" Class="form-control" AutoPostBack="true" AutoCompleteType="Disabled"  aria-describedby="Quantity" ReadOnly="True"></asp:TextBox>
                     <label for="noPaper">Price</label>
                        <asp:TextBox ID="TxtPrice" runat="server" Class="form-control" AutoCompleteType="Disabled" aria-describedby="Price" ReadOnly="True"></asp:TextBox>
                     </div>--%>
                       <%-- <asp:LinkButton ID="BtnQuantity" runat="server" OnClick="BtnQuantity_Click">Custom Quantity</asp:LinkButton>
                  --%>

                
                </div>
            </div>
         



            <div class="col-md-40 text-center"> 
                <asp:Button ID="save" class="btn btn-primary" runat="server" Text="Add to cart" OnClick="save_Click" />
                 </div>
           
</div>
        
      </div>
    
          <div class="form-group text-center">
                                <span>
                                    <asp:Label ID="LBLError" runat="server" Visible="False"  class="margin text-center" ForeColor="#009933"></asp:Label></span>
                            </div>
     
         
        </div>
             
  
                
                 </ContentTemplate>
        </asp:UpdatePanel>
   </form>
</asp:Content>
