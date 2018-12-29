<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="BusinessCards.aspx.cs" Inherits="sevenG.Operaion.Order" %>    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    
     <style type="text/css">
    ​.Checkboxlist1-tr{
    display:inline-block;
    margin-right:20px;

    }
</style>
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
          <i class="fa fa-table"></i> Business Cards
           
        </div>
            
      </div>
    
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">
                    <div class="col-md-6">
                                <label for="ProName">Product Name</label>                          
                                    <asp:DropDownList ID="DRLProName" runat="server" class="form-control" placeholder="اسم المنتج" DataTextField="PROD_NAME" DataValueField="PROD_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLProName_SelectedIndexChanged"></asp:DropDownList>                              
                                </div>
                    <div class="col-md-6">
                        <label for="ProName">Material</label>    
                        <asp:DropDownList ID="DRLMaterials" runat="server" class="form-control" DataTextField="PAPER_NAME" DataValueField="PAPER_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLMaterials_SelectedIndexChanged"></asp:DropDownList>                              
                    </div>

                   <div class="col-md-6">
                                <label for="ProName">Size</label>                          
                                    <asp:DropDownList ID="DRLSize" runat="server" class="form-control" DataTextField="SIZE_NAME" DataValueField="SIZE_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLSize_SelectedIndexChanged"></asp:DropDownList>                              
                            </div>
                    <div class="col-md-6" runat="server" id="divSpecial">
                                <label for="ProName">Special Effect</label>                          
                                    <asp:DropDownList ID="DrpSecialEffect" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DrpSecialEffect_SelectedIndexChanged">                              
                                        <asp:ListItem Value="1">Without Spot UV</asp:ListItem>
                                        <asp:ListItem Value="2">Spot UV1</asp:ListItem>
                                        <asp:ListItem Value="3">Spot UV2</asp:ListItem>
                                        </asp:DropDownList> 
                    </div>
                    <div class="col-md-6" runat="server" id="divLamin" visible="false">
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
                        <label for="Lamination">Round Corner:</label> 
                    <asp:CheckBoxList ID="checkRoundCorn" AutoPostBack="true" Width="450"  TextAlign="Right" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="checkRoundCorn_SelectedIndexChanged">
                        <asp:ListItem Text="Upper Right " Value="1"></asp:ListItem>
                        <asp:ListItem Text="Upper Left " Value="2"></asp:ListItem>
                        <asp:ListItem Text="Lower Right " Value="3"></asp:ListItem>
                        <asp:ListItem Text="Lower Left " Value="4"></asp:ListItem>
                    </asp:CheckBoxList>
                     </div>
                    <div class="col-md-6" runat="server" id="divempty" visible="false">
                     </div>
                    <div class="col-md-6">

                        <label for="noPaper">Quantity</label>
                        <asp:TextBox ID="TXTQuantity" runat="server" Class="form-control" AutoPostBack="true" OnTextChanged="TXTQuantity_TextChanged" AutoCompleteType="Disabled"  aria-describedby="Quantity" ReadOnly="True"></asp:TextBox>
                       <label for="noPaper">Price</label>
                        <asp:TextBox ID="TxtPrice" runat="server" Class="form-control" AutoCompleteType="Disabled" aria-describedby="Price" ReadOnly="True"></asp:TextBox>
                    
                      <%--  <asp:LinkButton ID="BtnQuantity" runat="server" OnClick="BtnQuantity_Click">Custom Quantity</asp:LinkButton>
                    --%> <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red" SetFocusOnError="True"
                        ControlToValidate="TXTQuantity" ErrorMessage="Value must be a number" />
                   
                    </div>
                    

                     <div class="col-md-6">
                        
           <div class="card-body">
          <div class="table-responsive">
              
             <asp:GridView ID="GrdPrices" runat="server"  width="100%" 
                                DataKeyNames="ID" AllowSorting="true" OnSelectedIndexChanged = "GrdPrices_SelectedIndexChanged"
                  OnRowDataBound="GrdPrices_RowDataBound" AutoGenerateColumns="False"  Height="25">
                                <Columns>
                                    
                                     <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                                    <asp:BoundField DataField="PRICE" HeaderText="Price" />
                                     <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="30"  >
                                    
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
            <div class="col-md-40 text-center"> 
                <asp:Button ID="save" class="btn btn-primary" runat="server" Text="Add to cart" OnClick="save_Click" />
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
