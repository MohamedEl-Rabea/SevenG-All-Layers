<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="PurchasingPaper.aspx.cs" Inherits="sevenG._7Gsetting.PurchasingPaper" %>
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
            <li class="breadcrumb-item active">Purchasing Paper</li>
        </ol>
        
       <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Papers
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">


                   <div class="col-md-6">
                        <label for="ProName">Paper</label>    
                        <asp:DropDownList ID="DRLMaterials" runat="server" class="form-control" DataTextField="PAPER_NAME" DataValueField="PAPER_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLMaterials_SelectedIndexChanged"></asp:DropDownList>                              
                    </div>
                      <div class="col-md-6">
                        <label for="paperNametxt">No. Papers</label>
                        <asp:TextBox ID="txtPapersNo" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" placeholder="عدد الورق في الماعون"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtPapersNo"></asp:RequiredFieldValidator>
               
                    </div>
                   
                      <div class="col-md-6">
                        <label for="paperNametxt">Papers Price</label>
                        <asp:TextBox ID="txtPapersPrice" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" placeholder="سعر الورق  "></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtPapersPrice"></asp:RequiredFieldValidator>
               
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
         
        </div>
             
      
                 </ContentTemplate>
        </asp:UpdatePanel>
   </form>
</asp:Content>
