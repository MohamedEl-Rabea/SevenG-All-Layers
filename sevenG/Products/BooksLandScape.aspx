<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="BooksLandScape.aspx.cs" Inherits="sevenG.Products.Books" %>
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
              <li class="breadcrumb-item active">Products</li>
          </ol>
        
       <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> LandScape Books & Booklets
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">

                    <div class="col-md-6">
                        <label for="ProName">Product Name</label>
                        <asp:DropDownList ID="DRLProName" runat="server" class="form-control" DataTextField="PROD_NAME" DataValueField="PROD_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLProName_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="col-md-6">
                        <label for="ProName">Material</label>
                        <asp:DropDownList ID="DRLMaterials" runat="server" class="form-control" DataTextField="PAPER_NAME" DataValueField="PAPER_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLMaterials_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="col-md-6">
                        <label for="ProName">Size</label>
                        <asp:DropDownList ID="DRLSize" runat="server" class="form-control" DataTextField="SIZE_NAME" DataValueField="SIZE_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLSize_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="col-md-6">
                        <label for="Lamination">Lamination:</label>
                        <asp:DropDownList ID="DRLLamination" runat="server" class="form-control" DataTextField="LAMINATION_NAME" DataValueField="LAMINATION_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLLamination_SelectedIndexChanged"></asp:DropDownList>
                    </div>

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
                        <label for="noPaper">No. of Pages</label>
                        <asp:TextBox ID="TxtPages" runat="server" AutoCompleteType="Disabled" Text="10" AutoPostBack="true" OnTextChanged="TxtPages_TextChanged" Class="form-control" aria-describedby="Pages Number" placeholder="Enter Number of pages"></asp:TextBox>
                        <asp:CompareValidator ID="ComparePages" runat="server"
                            ControlToValidate="TxtPages" ErrorMessage="Number of pages must be less than 80 with Saddle staple Binding"
                            Operator="LessThan" Type="Integer" ValueToCompare="80" ForeColor="Red" SetFocusOnError="True" Enabled="true" />

                    </div>

                    
                    <div class="col-md-6">
                        <label for="ProName">Binding</label>
                        <asp:RadioButtonList ID="Binding" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Binding_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Table">
                            <asp:ListItem Text="Saddle staple &nbsp &nbsp &nbsp &nbsp " Value="0" Selected="true" />
                            <asp:ListItem Text="Perfect" Value="1" />
                        </asp:RadioButtonList>
                        </div>
                    <div class="col-md-6">
                        <label for="noPaper">Quantity</label>
                        <asp:TextBox ID="TXTQuantity" runat="server" Class="form-control" AutoPostBack="true" OnTextChanged="TXTQuantity_TextChanged" AutoCompleteType="Disabled" aria-describedby="Quantity" ReadOnly="True"></asp:TextBox>
                        
                         <label for="noPaper">Price</label>
                        <asp:TextBox ID="TxtPrice" runat="server" Class="form-control" AutoCompleteType="Disabled" aria-describedby="Price" ReadOnly="True"></asp:TextBox>

                        <asp:LinkButton ID="BtnQuantity" runat="server" OnClick="BtnQuantity_Click">Custom Quantity</asp:LinkButton>

                         <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red" SetFocusOnError="True"
                        ControlToValidate="TXTQuantity" ErrorMessage="Value must be a number" />
                       
                    </div>

                    <div class="col-md-6">

                        <div class="card-body">
                            <div class="table-responsive">

                                <asp:GridView ID="GrdPrices" runat="server" Width="100%"
                                    DataKeyNames="QUANTITY_ID ,COST ,COVER_COST" AllowSorting="true" OnSelectedIndexChanged="GrdPrices_SelectedIndexChanged" OnRowDataBound="GrdPrices_RowDataBound" AutoGenerateColumns="False" Height="25">
                                    <Columns>

                                        <asp:BoundField DataField="QUANTITY_ID" HeaderText="Quantity" />
                                        <asp:BoundField DataField="QUANTITY_PRICE" HeaderText="Price" />
                                        <asp:BoundField DataField="COST" HeaderText="cost" />
                                         <asp:BoundField DataField="COVER_COST" Visible="false" HeaderText="Cover Cost" />
                                        <asp:BoundField DataField="DISCOUNT_PERC" Visible="false" HeaderText="Discount" />
                                        <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="30">

                                            <ItemStyle Width="30px" />
                                        </asp:ButtonField>

                                    </Columns>

                                    <HeaderStyle BackColor="#99CCFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <RowStyle BorderStyle="None" HorizontalAlign="Center" VerticalAlign="Middle" />

                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
              </div>
            </div>
       </div>
          <div class="form-group text-center">
              <span>
                  <asp:Label ID="Lblalert" runat="server" Visible="False" class="margin text-center" ForeColor="Red"></asp:Label></span>
          </div>
        
      </div>
    
           <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i> Cover Details
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">

                    <div class="col-md-6">
                        <label for="ProName">Cover printing type</label>
                        <asp:DropDownList ID="DrpCoPrintType" runat="server" class="form-control" DataTextField="PROD_NAME" DataValueField="PROD_ID" AutoPostBack="True" OnSelectedIndexChanged="DrpCoPrintType_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <label for="ProName">Material</label>
                        <asp:DropDownList ID="DRPCoMaterial" runat="server" class="form-control" DataTextField="PAPER_NAME" DataValueField="PAPER_ID" AutoPostBack="True" OnSelectedIndexChanged="DRPCoMaterial_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-md-6" runat="server" id="divSpecial">
                        <label for="ProName">Special Effect</label>
                        <asp:DropDownList ID="DrpSecialEffect" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DrpSecialEffect_SelectedIndexChanged">
                            <asp:ListItem Value="1">Lamination</asp:ListItem>
                            <asp:ListItem Value="2">Spot UV</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6" runat="server" id="divLamin" visible="false">
                        <label for="Lamination">Lamination:</label>
                        <asp:DropDownList ID="DRPCoLamination" runat="server" class="form-control" DataTextField="LAMINATION_NAME" DataValueField="LAMINATION_ID" AutoPostBack="True" OnSelectedIndexChanged="DRPCoLamination_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <label for="Lamination">Sides</label>
                        <asp:DropDownList ID="DRPCoSides" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DRPCoSides_SelectedIndexChanged">
                            <asp:ListItem Value="1">1 Side</asp:ListItem>
                            <asp:ListItem Value="2">2 Sides</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <label for="ProName">Print Type</label>
                        <asp:DropDownList ID="DrpCoPrint" runat="server" class="form-control" DataTextField="PRINTER_TYPE" DataValueField="PRINTER_ID" AutoPostBack="True" OnSelectedIndexChanged="DrpCoPrint_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                   
                </div>
            </div> 
            <div class="col-md-40 text-center">
                <asp:Button ID="BtnSave" class="btn btn-primary" runat="server" Text="Add to cart" OnClick="BtnSave_Click" />
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
