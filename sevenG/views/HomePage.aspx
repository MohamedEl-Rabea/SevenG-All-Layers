<%@ Page Title="" Language="C#" MasterPageFile="/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="sevenG.views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container-fluid">
      <!-- Breadcrumbs-->
      <ol class="breadcrumb">
        <li class="breadcrumb-item">
          <a href="HomePage.aspx">Home Page</a>
        </li>
        
      </ol>
      <div class="row">
        <div class="col-12">
          <h1>Welcome <asp:Label  ID="LBLError" runat="server" class="margin text-center" ForeColor="red"></asp:Label>
                in 7G System</h1>
        </div>
      </div>
    </div>
</asp:Content>