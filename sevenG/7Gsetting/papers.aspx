<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="papers.aspx.cs" Inherits="sevenG.Products.papers" %>
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
            <li class="breadcrumb-item active">Products Setting</li>
        </ol>
        
       <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Papers
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">


                    <div class="col-md-6">
                        <label for="paperNametxt">Paper name E</label>
                        <asp:TextBox ID="paperNametxt" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" placeholder="اسم الورق انجليزي"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="paperNametxt"></asp:RequiredFieldValidator>
               
                    </div>
                    <div class="col-md-6">
                        <label for="paperNametxt">Paper name A</label>
                        <asp:TextBox ID="paperNameAr" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" placeholder=" اسم الورق عربي"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="paperNametxt"></asp:RequiredFieldValidator>
               
                    </div>
                   
                    <div class="col-md-6">
                                <label for="ProName">Paper Type</label>                          
                                    <asp:DropDownList ID="DRLCat" runat="server" class="form-control" DataTextField="CAT_NAME_E" DataValueField="CAT_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLCat_SelectedIndexChanged"></asp:DropDownList>                              
                                </div>
                       <div class="col-md-6">
                <label for="descriptiontxt">Paper Code</label>
                <asp:TextBox ID="txtPaperCode" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="descriptionHelp" placeholder="كود الورق"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtPaperCode"></asp:RequiredFieldValidator>
                       
                 </div>
             <div class="col-md-6">
                        <label for="noPaper">Number of papers</label>
                        <asp:TextBox ID="noPapertxt" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="Number of papers" placeholder="عدد الورق في الباكيت"></asp:TextBox>
                
                    </div>  
                    <div class="col-md-6">
                        <label for="noPaper">Price of A3 paper</label>
                        <asp:TextBox ID="TxtPaperPrice" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="Price of paper" placeholder="سعر الورقة A3"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="TxtPaperPrice"></asp:RequiredFieldValidator>
               
                    </div>    
            <div class="col-md-6">
                <label for="descriptiontxt">Paper Weight</label>
                <asp:TextBox ID="txtPaperWght" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="descriptionHelp" placeholder="وزن الورقة"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtPaperWght"></asp:RequiredFieldValidator>
                       
                 </div>
         
           
                      
                </div>
            </div>



            <div class="col-md-40 text-center"> 
                <asp:Button ID="save" class="btn btn-primary" runat="server" Text="Save" OnClick="Save_Click" />
              <%--  <asp:Button ID="edit" class="btn btn-primary" runat="server" Text="Edit" OnClick="edit_Click" Visible="false" />
                <asp:Button ID="delete" class="btn btn-primary" runat="server" Text="Delete" OnClick="delete_Click" Visible="false" />
            --%> </div>
           
</div>
        
      
       </div>
    
          <div class="form-group text-center">
                                <span>
                                    <asp:Label ID="LBLError" runat="server" Visible="False"  class="margin text-center" ForeColor="#009933"></asp:Label></span>
                            </div>
         
          <%--   <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Papers</div>
        <div class="card-body">
          <div class="table-responsive">
              
             <asp:GridView ID="GrdPapers" runat="server"  width="100%" cellspacing="0"
                                DataKeyNames="PAPER_NAME" CssClass="table table-bordered" AllowSorting="true" OnSelectedIndexChanged = "GrdPapers_SelectedIndexChanged" OnRowDataBound="GrdPapers_RowDataBound" OnPageIndexChanging="GrdPapers_PageIndexChanging" AllowPaging="true" PageSize="10" AutoGenerateColumns="False">
                                <Columns>
                                    
                                    <asp:BoundField DataField="PAPER_NAME" HeaderText="Paper name" />
                                    <asp:BoundField DataField="PAPER_CODE" HeaderText="Paper code" />
                                    <asp:BoundField DataField="PAPER_TYPE" HeaderText="Paper type" />
                                    <asp:BoundField DataField="PAPER_WEIGHT" HeaderText="Paper Weight" />
                                    <asp:BoundField DataField="NO_INSIDE_PAPERS" HeaderText="Number of papers" />
                                     <asp:ButtonField Text="Edit\Delete" CommandName="Select" ItemStyle-Width="30"  />
                                    
                                </Columns>
                                
                            </asp:GridView>
          
          </div>
        </div>
      </div>--%>

      
           
         
        </div>
             
      
                 </ContentTemplate>
        </asp:UpdatePanel>
  
   </form>
</asp:Content>
