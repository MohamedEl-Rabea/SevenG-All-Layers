<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="PrintInvoice.aspx.cs" Inherits="sevenG.Order.PrintInvoice" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form class="form-horizontal" runat="server">
      <div class="container-fluid">
        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="../views/HomePage.aspx">Home Page</a>
            </li>
            <li class="breadcrumb-item active">Print Invoice</li>
        </ol>
        
       <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Invoice
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">


                <div class="col-md-40 text-center"> 
                <asp:Button ID="Btndownload" class="btn btn-primary" runat="server" Text="Download" OnClick="Btndownload_Click" />
             </div>
<div class="form-group text-center">
                                <span>
                                    <asp:Label ID="LBLError" runat="server" class="margin text-center" ForeColor="#009933"></asp:Label></span>
                            </div>

                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="100%" Height="100%" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" >
                      <LocalReport ReportPath="Order\Invoice.rdlc"  ReportEmbeddedResource="SevenG\Order\Invoice.rdlc">
                        <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                   <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                   </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="SevenGTableAdapters.loadInvRepTableAdapter">
            <SelectParameters>
                <asp:SessionParameter Name="MAIN_ORDER_ID" SessionField="InvMainOrderId" Type="Int32" />
                <asp:SessionParameter Name="CUSTOMER_ID" SessionField="CustomerID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

                 <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="SevenGTableAdapters.loadQuotRepTableAdapter">
            <SelectParameters>
                <asp:SessionParameter Name="MAIN_ORDER_ID" SessionField="InvMainOrderId" Type="Int32" />
                <asp:SessionParameter Name="CUSTOMER_ID" SessionField="CustomerID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                </div>
            </div> 
</div>
        </div> 
      
       </div>
    
        
  
   </form>
</asp:Content>
