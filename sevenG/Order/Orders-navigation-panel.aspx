<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="Orders-navigation-panel.aspx.cs" Inherits="sevenG.Order.Orders_navigation_panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-3 col-md-6 col-sm-6">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">add_shopping_cart</i>
                    </div>
                    <p class="card-category">Sales section #1</p>
                    <h4 class="card-title"><strong>New order</strong></h4>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <a href="new-order.aspx" class="btn btn-success btn-sm">Enter</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-6 col-sm-6">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">book</i>
                    </div>
                    <p class="card-category">Sales section #1</p>
                    <h4 class="card-title"><strong>New quotation</strong></h4>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <a href="new-order.aspx" class="btn btn-success btn-sm">Enter</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

