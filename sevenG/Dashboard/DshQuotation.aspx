<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="DshQuotation.aspx.cs" Inherits="sevenG.Dashboard.DshQuotation" %>
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
            <li class="breadcrumb-item active">Dashboard</li>
        </ol>
        
       <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Quotations
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">


                    <div class="col-md-6">
                        <label for="ProName">From Date</label> 
                         <asp:TextBox ID="txtFrom" runat="server" OnTextChanged="txtFrom_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" ></asp:TextBox>
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
                         <asp:TextBox ID="txtTo" runat="server" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtTo_TextChanged" Class="form-control" aria-describedby="nameHelp">

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
                        <asp:TextBox ID="txtCustomer" runat="server" Class="form-control" AutoPostBack="true"></asp:TextBox>
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
                                DataKeyNames="MAIN_ORDER_ID,CUSTOMER_ID" CssClass="table table-bordered" AllowSorting="true" AutoGenerateColumns="False" OnRowDataBound="GrdMOrders_RowDataBound" OnSelectedIndexChanged= "GrdMOrders_SelectedIndexChanged"  OnPageIndexChanging="GrdMOrders_PageIndexChanging" AllowPaging="true" PageSize="10">
            <Columns>
                                 
                                    <asp:BoundField DataField="MAIN_ORDER_ID" HeaderText="M.order#"  />
                                    <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer"  />
                                    <asp:BoundField DataField="QUOTATION_CODE" HeaderText="Quotation#" />
                                    <asp:BoundField DataField="ORDER_TOTAL_PRICE" HeaderText="Price" />
                                    <asp:BoundField DataField="MAIN_ORDER_DATE" HeaderText="st Date" />
                                    <asp:BoundField DataField="QUOTATION_DATE" HeaderText="end Date" />
                                    <asp:BoundField DataField="QUOT_STATUS" HeaderText="Status" />
                                    <asp:BoundField DataField="PAYMENT_METHOD" HeaderText="Payment method" />
                                    <asp:BoundField DataField="PRINT_USER_NAME" HeaderText="Sales" />
                                    <asp:ButtonField CommandName="Select" ItemStyle-Width="25" Text="Download" ButtonType="Button" ShowHeader="True" HeaderText="Qoutation"></asp:ButtonField>
                     
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
