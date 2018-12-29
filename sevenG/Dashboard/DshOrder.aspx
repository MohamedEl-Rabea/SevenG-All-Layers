<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="DshOrder.aspx.cs" Inherits="sevenG.Dashboard.DshOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
    .collapsed-row {
        display:none;
        padding:0px;
        margin:0px;
    }
</style>
<script type="text/javascript">
    function ToggleGridPanel(btn, row) {
        var current = $('#' + row).css('display');
        if (current == 'none') {
            $('#' + row).show();
            $(btn).removeClass('glyphicon-plus')
            $(btn).addClass('glyphicon-minus')
        } else {
            $('#' + row).hide();
            $(btn).removeClass('glyphicon-minus')
            $(btn).addClass('glyphicon-plus')
        }
        return false;
    }
    </script>

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
            <li class="breadcrumb-item active">Dashboard</li>
        </ol>
        
       <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Orders
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">


                    <div class="col-md-6">
                        <label for="ProName">From Date</label> 
                         <asp:TextBox ID="txtFrom" runat="server"  AutoPostBack="true" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" ></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="calender" OnClick="Button1_Click" />
                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" Visible="False">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt"></DayHeaderStyle>

                            <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>

                            <OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>

                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White"></SelectedDayStyle>

                            <SelectorStyle BackColor="#CCCCCC"></SelectorStyle>

                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True"></TitleStyle>

                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black"></TodayDayStyle>

                            <WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
                        </asp:Calendar>
                       
                    </div>
                    <div class="col-md-6">
                        <label for="ProName">To Date</label> 
                         <asp:TextBox ID="txtTo" runat="server" AutoPostBack="true" AutoCompleteType="Disabled"  Class="form-control" aria-describedby="nameHelp">

                         </asp:TextBox>                      
                        <asp:Button ID="Button2" runat="server" Text="calender" OnClick="Button2_Click" />
                        <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" Visible="False">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt"></DayHeaderStyle>

                            <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>

                            <OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>

                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White"></SelectedDayStyle>

                            <SelectorStyle BackColor="#CCCCCC"></SelectorStyle>

                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True"></TitleStyle>

                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black"></TodayDayStyle>

                            <WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
                        </asp:Calendar>
                        
                    </div>
  
                         <div class="col-md-6">
                        <label for="noPaper">Customer Name</label>
                        <asp:TextBox ID="txtCustomer" runat="server"  OnTextChanged="txtCustomer_TextChanged" Class="form-control" AutoPostBack="true"></asp:TextBox>
                     </div>
                    
                </div>
            </div>



            <div class="col-md-40 text-center"> 
                <asp:Button ID="search" class="btn btn-primary" runat="server" Text="Search" OnClick="search_Click" />
             
           
</div>
        
      
       </div>
    
          <div class="form-group text-center">
                                <span>
                                    <asp:Label ID="LBLError" runat="server" Visible="False"  class="margin text-center" ForeColor="#009933"></asp:Label></span>
                            </div>
         
           <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Orders</div>
        <div class="card-body">
          <div class="table-responsive">
              
           <asp:GridView ID="GrdMOrders" runat="server"  width="100%" cellspacing="0"
                                DataKeyNames="MAIN_ORDER_ID,CUSTOMER_ID" CssClass="table table-bordered" AllowSorting="true" AutoGenerateColumns="False" OnRowDataBound="GrdMOrders_RowDataBound" OnPageIndexChanging="GrdMOrders_PageIndexChanging" AllowPaging="true" PageSize="10">
            <Columns>
                                      <asp:TemplateField>
            <ItemTemplate>
                <button class="btn btn-default glyphicon glyphicon-plus" onclick="return ToggleGridPanel(this, 'tr<%# Eval("MAIN_ORDER_ID") %>')" />
            </ItemTemplate>
        </asp:TemplateField>
                                    <asp:BoundField DataField="MAIN_ORDER_ID" HeaderText="M.order#"  />
                                    <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer"  />
                                    <asp:BoundField DataField="PRINT_USER_NAME" HeaderText="Sales" />
                                    <asp:BoundField DataField="MAIN_ORDER_DATE" HeaderText="Date" />
                                    <asp:BoundField DataField="ORDER_PRICE" HeaderText="Cost" />
                                    <asp:BoundField DataField="TAX" HeaderText="VAT" />
                                    <asp:BoundField DataField="ORDER_ADDTION" HeaderText="Addtion" />
                                    <asp:BoundField DataField="ORDER_DISCOUNT" HeaderText="Discount" />
                                    <asp:BoundField DataField="ORDER_TOTAL_PRICE" HeaderText="Price"  />
                                    <asp:BoundField DataField="ORDER_STATUS" HeaderText="Status" />
                                    <asp:BoundField DataField="INVOICE_CODE" HeaderText="Invoic#" />
                                    <asp:BoundField DataField="QUOTATION_CODE" HeaderText="Quotation#"  />
                 <asp:TemplateField >
                          <ItemTemplate>
                              <%# MyNewRow(Eval("MAIN_ORDER_ID")) %>
                          <asp:GridView ID="gvOrders" runat="server"
                        Width="100%"
                        GridLines="None"
                        AutoGenerateColumns="false"
                        DataKeyNames="ORDER_ID"
                              CssClass="table table-bordered" >
                              <Columns>
                                  <asp:BoundField DataField="ORDER_ID" HeaderText="Item#" />
                                  <asp:BoundField DataField="PROD_NAME" HeaderText="Product Name" />
                                  <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                                  <asp:BoundField DataField="TOTAL_PRICE" HeaderText="Price" />
                                  
                              </Columns>
                    </asp:GridView>
                              
                              </ItemTemplate>
                      </asp:TemplateField>
                     
                                    
                                </Columns>
                                
                            </asp:GridView>
          
          </div>
        </div>
      </div>

      
           
         
        </div>
             
      
                 </ContentTemplate>
        </asp:UpdatePanel>
  
   </form>
</asp:Content>
