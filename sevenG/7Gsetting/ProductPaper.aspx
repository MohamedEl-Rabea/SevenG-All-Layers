<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="ProductPaper.aspx.cs" Inherits="sevenG._7Gsetting.ProductPaper" %>
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
            <li class="breadcrumb-item active">Product Papers</li>
        </ol>
        
       <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Product Papers
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">

                      <div class="col-md-6">
                        <label for="ProName">Paper</label>    
                        <asp:DropDownList ID="DRLMaterials" runat="server" class="form-control" DataTextField="PAPER_NAME" DataValueField="PAPER_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLMaterials_SelectedIndexChanged"></asp:DropDownList>                              
                    </div>

                   <div class="col-md-6">
                        <label for="ProName">Category</label>    
                        <asp:DropDownList ID="DRLCategory" runat="server" class="form-control" DataTextField="CATEGORY_NAME" DataValueField="CATEGORY_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLCategory_SelectedIndexChanged"></asp:DropDownList>                              
                    </div>
                      <div class="col-md-6">
                        <label for="ProName">Paper Type</label>    
                        <asp:DropDownList ID="DRLPaperType" runat="server" class="form-control" DataTextField="PROD_NAME" DataValueField="PROD_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLPaperType_SelectedIndexChanged"></asp:DropDownList>                              
                    </div>

          
                </div>
            </div>



            <div class="col-md-40 text-center"> 
                <asp:Button ID="save" class="btn btn-primary" runat="server" Text="Save" OnClick="save_Click" />
             </div>
           
</div>
        
      
       </div>
    
          <div class="form-group text-center">
                                <span>
                                    <asp:Label ID="LBLError" runat="server" Visible="False"  class="margin text-center" ForeColor="#009933"></asp:Label></span>
                            </div>

            <div class="card mb-3" id="price" runat="server" visible="true">

          <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Paper-Price
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">


                       <div class="col-md-6">
                        <label for="paperNametxt">Quantity</label>
                        <asp:TextBox ID="txtQuantity" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" placeholder="الكمية"></asp:TextBox>
                        
                    </div>
                   
                      <div class="col-md-6">
                        <label for="paperNametxt"> Price</label>
                        <asp:TextBox ID="txtPapersPrice" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" placeholder="سعر الكمية"></asp:TextBox>
                       
                    </div>
                         <div class="col-md-6">
                        <label for="paperNametxt">SPOT UV1 Price</label>
                        <asp:TextBox ID="txtSPOTUV1Price" runat="server" AutoCompleteType="Disabled" Text="0" Class="form-control" aria-describedby="nameHelp" placeholder=" SPOT UV1 السعر شامل"></asp:TextBox>
                        
                    </div>
                   
                      <div class="col-md-6">
                        <label for="paperNametxt">SPOT UV2 Price</label>
                        <asp:TextBox ID="txtSPOTUV2Price" runat="server" AutoCompleteType="Disabled" Text="0" Class="form-control" aria-describedby="nameHelp" placeholder=" SPOT UV2 السعر شامل "></asp:TextBox>
                        
                    </div>
          
                </div>
            </div>



            <div class="col-md-40 text-center"> 
                <asp:Button ID="BtnPrice" class="btn btn-primary" runat="server" Text="Save" OnClick="BtnPrice_Click" />
             </div>
           
</div>
        
      
       </div>
           
           </div> 
        </div>
             
       </ContentTemplate>
        </asp:UpdatePanel>

   </form>
</asp:Content>
