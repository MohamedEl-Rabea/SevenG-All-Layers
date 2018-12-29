<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="sevenG._7Gsetting.MyOrders" %>
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
    function SelectAllCheckboxes(chk) {
      
            var ck = chk;

            var count = 0;

            var GrdOrders = document.getElementById('GrdOrders');
            for (var i = 1; i < gvcheck.rows.length; i++)
                        {
                             //get all the input elements
                var gvcheck = gvcheck.rows[i].getElementById("gvOrders");
                var headerchk = gvOrders.getElementById(header);

                var rowcount = gvcheck.rows.length;
                            for(var  j = 1; j< GridView2.rows.length; j++)
                            {
                                if (chk.checked) {
                                    GridView2.rows[j].getElementById("chkSelect").checked = true;
                                }

                            }

                        }

            var headerchk = document.getElementById(header);

            var rowcount = gvcheck.rows.length;

            //By using this for loop we will count how many checkboxes has checked

            for (i = 1; i < gvcheck.rows.length; i++)

            {

                var inputs = gvcheck.rows[i].getElementsByTagName('input');

                if (inputs[0].checked)

                {

                    count++;

                }

            }

            //Condition to check all the checkboxes selected or not

            if (count == rowcount - 1) {

                headerchk.checked = true;

            }

            else

            {

                headerchk.checked = false;

            }

        }

    //function checkAll(chk) {
    //    var table = document.getElementById("GrdOrders");
          
    //  //loop the gridview table
    //        for (var i = 1; i < table.rows.length; i++)
    //        {
    //            //get all the input elements
    //            var GridView2 = table.rows[i].getElementById("gvOrders");
    //            for(var  j = 1; j< GridView2.rows.length; j++)
    //            {
    //                if (chk.checked) {
    //                    GridView2.rows[j].getElementById("chkSelect").checked = true;
    //                }
                    
    //            }
                 
    //        }
    //    }  
    
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
            <li class="breadcrumb-item active">My Orders</li>
        </ol>
        
          <div class="card mb-3">
              <div class="card-header">
                  <i class="fa fa-table"></i>طلباتي
           
              </div>

          </div>
    
        <div class="card-body">
        
            <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Orders</div>
        <div class="card-body">
          <div class="table-responsive">
              
              <asp:GridView ID="GrdOrders" runat="server" Width="100%"
                  DataKeyNames="MAIN_ORDER_ID"  AllowSorting="true" CssClass="table table-bordered" OnRowCommand="GrdOrders_RowCommand" OnSelectedIndexChanged="GrdOrders_SelectedIndexChanged" OnRowDataBound="GrdOrders_RowDataBound" OnPageIndexChanging="GrdOrders_PageIndexChanging" AllowPaging="true" AutoGenerateColumns="False" gridlines="None">
                
                    <Columns>
                       <asp:TemplateField>
            <ItemTemplate>
                <button class="btn btn-default glyphicon glyphicon-plus" onclick="return ToggleGridPanel(this, 'tr<%# Eval("MAIN_ORDER_ID") %>')" />
            </ItemTemplate>
        </asp:TemplateField>
 
                        
                       <asp:ButtonField CommandName="Select" ItemStyle-Width="25" Text="Download" ButtonType="Button" ShowHeader="True" HeaderText="Invoice"></asp:ButtonField>
                     
                      <asp:BoundField DataField="MAIN_ORDER_ID" HeaderText="Order#" />
                      <asp:BoundField DataField="INVOICE_CODE" HeaderText="Invoice#" />
                      <asp:BoundField DataField="ORDER_TOTAL_PRICE" HeaderText="Price" />
                      <asp:BoundField DataField="ORDER_STATUS" HeaderText="Status " />
                       <asp:BoundField DataField="MAIN_ORDER_DATE" HeaderText="Date" />

                      <asp:ButtonField Text="Re-Order" CommandName="reOrder" ItemStyle-Width="30" />
                      <%--<asp:ButtonField CommandName="Edit" ItemStyle-Width="25" Text="Re-Order" ButtonType="Button" ShowHeader="True" HeaderText="Re-Order"></asp:ButtonField>--%>
                     
                      <asp:TemplateField >
                          <ItemTemplate>
                              <%# MyNewRow(Eval("MAIN_ORDER_ID")) %>
                          <asp:GridView ID="gvOrders" runat="server"
                        Width="100%"
                        GridLines="None"
                        AutoGenerateColumns="false"
                        DataKeyNames="ORDER_ID"
                              CssClass="table table-bordered" OnRowDataBound="gvOrders_RowDataBound"
                            
                        >
                              <Columns>
                                  <asp:BoundField DataField="ORDER_ID" HeaderText="Item#" />
                                  <asp:BoundField DataField="PROD_NAME" HeaderText="Product Name" />
                                  <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                                  <asp:BoundField DataField="TOTAL_PRICE" HeaderText="Price" />
                                  <asp:TemplateField>
                                    
                                      <HeaderTemplate>
                                          <asp:CheckBox ID="chkSelectAll" runat="server" onclick="javascript:SelectAllCheckboxes(this);" />
                                      </HeaderTemplate>
                    
                                      <ItemTemplate>
                                          <asp:CheckBox ID="chkSelect" runat="server"  />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                              </Columns>
                    </asp:GridView>
                              
                              </ItemTemplate>
                      </asp:TemplateField>
                     
                  </Columns>
                                
                            </asp:GridView>
          
          </div>
       
          
          
          
          
           </div>
      </div> 
            <div class="col-md-40 text-center">
                <asp:Button ID="BtnSave" class="btn btn-primary" runat="server" Text="Save" OnClick="BtnSave_Click" />
            </div>   
      
                  <div class="form-group text-center">
                                <span>
                                    <asp:Label ID="LBLError" runat="server" class="margin text-center" ForeColor="#009933"></asp:Label></span>
                            </div>
                 </div>   
      </div>
              
                
                  
   
          </ContentTemplate>
        </asp:UpdatePanel>
   </form>

</asp:Content>
