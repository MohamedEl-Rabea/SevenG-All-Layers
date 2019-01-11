<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="Folders.aspx.cs" Inherits="sevenG.Products.Folders" %>
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
          <i class="fa fa-table"></i> Folders
           
        </div>
            
      </div>
    
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">
                    <div class="col-md-6">
                                <label for="ProName">Product Name</label>                          
                                    <asp:DropDownList ID="DRLProName" runat="server" class="form-control" DataTextField="PROD_NAME" DataValueField="PROD_ID"  placeholder="اسم المنتج" OnSelectedIndexChanged="DRLProName_SelectedIndexChanged" AutoPostBack="True" >                            
                          
                         </asp:DropDownList>     
                         </div>
                    <div class="col-md-6">
                        <label for="ProName">Material</label>    
                        <asp:DropDownList ID="DRLMaterials" runat="server" class="form-control"  DataTextField="PAPER_NAME" DataValueField="PAPER_ID" OnSelectedIndexChanged="DRLMaterials_SelectedIndexChanged" AutoPostBack="True" >                             
                  </asp:DropDownList> 
                              </div>

                  <div class="col-md-6">
                        <label for="Lamination">CD Holder</label>                          
                                    <asp:DropDownList ID="DrpCD" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DrpCD_SelectedIndexChanged">
                                      
                                        <asp:ListItem Value="1">Without CD</asp:ListItem>
                                          <asp:ListItem Value="2">With CD Holder</asp:ListItem>
                        </asp:DropDownList>                              
                            </div>
                    <div class="col-md-6" runat="server" id="divSpecial">
                                <label for="ProName">Special Effect</label>                          
                                    <asp:DropDownList ID="DrpSecialEffect" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DrpSecialEffect_SelectedIndexChanged">                              
                                        <asp:ListItem Value="1">Without Spot UV</asp:ListItem>
                                        <asp:ListItem Value="2">Spot UV</asp:ListItem>
                                        </asp:DropDownList> 
                    </div>
                    <div class="col-md-6" runat="server" id="divLamin" >
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
                        
                         
                        <label for="Lamination">Pocket:</label> 
                    <asp:DropDownList ID="DrpPockets" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DrpPockets_SelectedIndexChanged">
                                        <asp:ListItem Value="1">White Pocket on left side</asp:ListItem>
                                        <asp:ListItem Value="2">White Pocket on right side</asp:ListItem>
                                        <asp:ListItem Value="3">White Pockets on both sides</asp:ListItem>
                                        <asp:ListItem Value="4">Color Pocket on left side</asp:ListItem>
                                        <asp:ListItem Value="5">Color Pocket on right side</asp:ListItem>
                                        <asp:ListItem Value="6">Color Pockets on both sides</asp:ListItem>
                        </asp:DropDownList> 
                 
                       

                        <label for="noPaper">Quantity</label>
                        <asp:TextBox ID="TXTQuantity" runat="server" Class="form-control" AutoPostBack="true"  AutoCompleteType="Disabled" OnTextChanged="TXTQuantity_TextChanged"  aria-describedby="Quantity" ReadOnly="True"></asp:TextBox>
                       <label for="noPaper">Price</label>
                        <asp:TextBox ID="TxtPrice" runat="server" Class="form-control" AutoCompleteType="Disabled" aria-describedby="Price" ReadOnly="True"></asp:TextBox>
                    <asp:LinkButton ID="BtnQuantity" runat="server" OnClick="BtnQuantity_Click">Custom Quantity</asp:LinkButton>
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red" SetFocusOnError="True"
                        ControlToValidate="TXTQuantity" ErrorMessage="Value must be a number" />
                      
                   
                         
                           </div>
                 
                    <div class="col-md-6">
                        <label for="Lamination">Spin (Kaab):</label> 
                    <asp:DropDownList ID="DrpSpin" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DrpSpin_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Without Spine</asp:ListItem>
                                        <asp:ListItem Value="2">0.5cm Spine</asp:ListItem>
                        
                                        <asp:ListItem Value="3">1cm Spine</asp:ListItem>
                        </asp:DropDownList> 
                       
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
                <asp:Button ID="save" class="btn btn-primary" runat="server" Text="Add to cart"  OnClick="save_Click" />
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
