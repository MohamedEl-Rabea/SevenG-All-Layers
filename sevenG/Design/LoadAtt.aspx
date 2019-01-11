<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="LoadAtt.aspx.cs" Inherits="sevenG.Design.LoadAtt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
        <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
        
      <div class="container-fluid">
        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="../views/HomePage.aspx">Home Page</a>
            </li>
            <li class="breadcrumb-item active">Designs</li>
        </ol>
       
          <div class="card mb-3">
              <div class="card-header">

                  <i class="fa fa-table">
                    </i>Edit Attatchment
                <%-- <div runat="server" style="position: absolute;right:20px;top:5px">
                <asp:Button ID="save"  class="btn btn-primary" runat="server" Text="Go to Cart" OnClick="skip_Click" />
              </div>
                  --%>
          
              </div>

          </div>
    
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">
                   <div class="form-group" >
                                 <label id="lblAttchmect" for="inputcontact" runat="server">Attatchment</label>
                         <div class="col-sm-6">
                         <ajaxToolkit:AjaxFileUpload ID="AttachmentFileUpload1" align="center" Width="500" runat="server"  AllowedFileTypes="jpeg,jpg,zip,png,gif,pdf" MaximumNumberOfFiles="5" OnUploadComplete="AjaxFileUpload1_UploadComplete" />
                        </div>
                </div>
            </div> 
           
       </div>  
                         <div class="col-md-40 text-center"> 
              <asp:Button ID="save"  class="btn btn-primary" runat="server" Text="Go to Cart" OnClick="skip_Click" />
             
</div>
             <div class="col-md-40 text-center"> 
                <asp:Button ID="BtnDesignPg" class="btn btn-primary" runat="server" Text="return to Design Page" OnClick="BtnDesignPg_Click" />
                 </div>
  <%--    <div class="form-group text-center" runat="server" id="divPrint" >
                      
            <asp:LinkButton ID="BtnDesignPage" runat="server" OnClick="BtnDesignPage_Click" Text="return to Design Page"></asp:LinkButton>
                        
                   
                    </div>--%>
                
            
            
          
          
          
           </div>
         
    </div>
</asp:Content>
