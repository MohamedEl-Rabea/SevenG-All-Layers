<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="CheckQuot.aspx.cs" Inherits="sevenG.Order.CheckQuot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
      
    <form class="form-horizontal" runat="server">
        <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
       
      <div class="container-fluid">
        <!-- Breadcrumbs-->
          
           
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="../views/HomePage.aspx">Home Page</a>
            </li>
            <li class="breadcrumb-item active">Check Quotation</li>
        </ol>

          <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i>Customer-Quotations
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">


                    <div class="col-md-6">
                        <label for="paperNametxt">Costomer name</label>
                          <asp:DropDownList ID="DRLCustName" runat="server" class="form-control" placeholder="اسم العميل" DataTextField="CUSTOMER_NAME" DataValueField="CUSTOMER_ID" AutoPostBack="True" OnSelectedIndexChanged="DRLCustName_SelectedIndexChanged"></asp:DropDownList>
                        
                           
                        <label for="noPaper">Quotation Code</label>
                        <asp:TextBox ID="txtQuot" runat="server" Class="form-control" aria-describedby="ProdName" ReadOnly="True"></asp:TextBox>
                  

                         <label for="paperNametxt">Choose one</label>
                         <asp:RadioButtonList id="radApproveRej"  Class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radApproveRej_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Table" BorderStyle="NotSet">
                    <asp:ListItem Text="Approve &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp" Value="0" Selected="true" />
                    <asp:ListItem Text="Reject" Value="1" />
                    </asp:RadioButtonList>
                        </div>  

                    <div class="col-md-6" runat="server" id="divPayment" visible="false" >
                         <label for="paperNametxt">Payment Method </label>
                         <asp:RadioButtonList id="RdPayment"  Class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RdPayment_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Table" BorderStyle="NotSet">
                    <asp:ListItem Text="Cash Now &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp" Value="0"  />
                    <asp:ListItem Text="On Delivery" Value="1" Selected="true" />
                    </asp:RadioButtonList>

                         </div>  
                    
                      <div class="col-md-6" runat="server" id="divReject" visible="false" >
                        <label for="paperTypetxt">Reason Of Reject</label>
                        <asp:TextBox ID="txtResonRej" runat="server" TextMode="MultiLine" AutoCompleteType="Disabled" Rows="4" Class="form-control" aria-describedby="typeHelp" placeholder="سبب الرفض"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtResonRej"></asp:RequiredFieldValidator>
                   
                    </div>
                   <div class="form-group"  >
                                 <label id="lblAttchmect" for="inputcontact" runat="server">Attatchment</label>
                         <div class="col-sm-6">
                         <ajaxToolkit:AjaxFileUpload ID="AttachmentFileUpload1" align="center" Width="500" runat="server"  AllowedFileTypes="jpeg,jpg,zip,png,gif,pdf" MaximumNumberOfFiles="5" OnUploadComplete="AttachmentFileUpload1_UploadComplete" />
                        </div>
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
         
             <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Quotations</div>
        <div class="card-body">
          <div class="table-responsive">
              
             <asp:GridView ID="GrdQuotation" runat="server"  width="100%" cellspacing="0"
                                DataKeyNames="QUOTATION_CODE" CssClass="table table-bordered" AllowSorting="true" OnSelectedIndexChanged = "GrdQuotation_SelectedIndexChanged" OnRowDataBound="GrdQuotation_RowDataBound" AutoGenerateColumns="False">
                                <Columns>
                                    
                                    <asp:BoundField DataField="QUOTATION_CODE" HeaderText="Quotation Code" />
                                    <asp:BoundField DataField="ORDER_TOTAL_PRICE" HeaderText="Quotation Price" />
                                    <asp:BoundField DataField="MAIN_ORDER_DATE" HeaderText="Quotation Date" />
                                     <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="30"  />
                                    
                                </Columns>
                                
                            </asp:GridView>
          
          </div>
        </div>
      </div>

      
           
         
        </div>
             
      
   </form>
</asp:Content>
