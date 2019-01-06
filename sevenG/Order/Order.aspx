<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="sevenG.Order.Order" %>
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
            <li class="breadcrumb-item active">Orders</li>
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
                        <label for="ProName">Customer Name</label>
                        <asp:DropDownList ID="DRLCustName" runat="server" class="form-control" placeholder="اسم العميل" 
                            DataTextField="CUSTOMER_NAME" DataValueField="CUSTOMER_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLCustName_SelectedIndexChanged"></asp:DropDownList>
                        <asp:LinkButton ID="BtnAddCust" runat="server" OnClick="BtnAddCust_Click">Add customer</asp:LinkButton>
                    </div>
                   

                    <div class="col-md-6">
                        <label for="ProName">Divisions</label>
                        <asp:DropDownList ID="DRLDivision" runat="server" class="form-control" DataTextField="DIVISION_NAME" DataValueField="DIVISION_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLDivision_SelectedIndexChanged"></asp:DropDownList>
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
             
       <div class="form-group text-center" runat="server" id="divPrint" visible="false">
                        <asp:LinkButton ID="BtnBusinessCards" runat="server" OnClick="BtnBusinessCards_Click" Text="Business Cards &nbsp &nbsp "></asp:LinkButton>
                        
                          <asp:LinkButton ID="BtnFlayers" runat="server" OnClick="BtnFlayers_Click">Flayers</asp:LinkButton>
                           <div class="col-md-6"></div>
                       <%-- <asp:LinkButton ID="BtnLandScapeBooks" runat="server" OnClick="BtnLandScapeBooks_Click" Text="LandScapeBooks &nbsp &nbsp"> </asp:LinkButton>
                       --%>
                          <asp:LinkButton ID="BtnPortraitBooks" runat="server" OnClick="BtnPortraitBooks_Click">PortraitBooks</asp:LinkButton>
          
             <div class="col-md-6"></div>
                        <asp:LinkButton ID="BtnFolder" runat="server" OnClick="BtnFolder_Click" Text="Folders &nbsp &nbsp"> </asp:LinkButton>
                       
                          <%--<asp:LinkButton ID="LinkButton2" runat="server" OnClick="BtnPortraitBooks_Click">PortraitBooks</asp:LinkButton>--%>
          
                    </div>
                
                  
   
          </ContentTemplate>
        </asp:UpdatePanel>
   </form>

</asp:Content>
