<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="product-navigation-panel.aspx.cs" Inherits="sevenG.Products.product_navigation_panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-3 col-md-6 col-sm-6">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">aspect_ratio</i>
                    </div>
                    <p class="card-category">Store section #1</p>
                    <h4 class="card-title"><strong>Business cards</strong></h4>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <a href="business-cards-category.aspx" class="btn btn-success btn-sm">Enter</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-6 col-sm-6">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">description</i>
                    </div>
                    <p class="card-category">Store section #2</p>
                    <h4 class="card-title"><strong>Flyers</strong></h4>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <a href="flyers-category.aspx" class="btn btn-success btn-sm">Enter</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-6 col-sm-6">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">folder</i>
                    </div>
                    <p class="card-category">Store section #3</p>
                    <h4 class="card-title"><strong>Folders</strong></h4>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <a href="folders-category.aspx" class="btn btn-success btn-sm">Enter</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-6 col-sm-6">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">library_books</i>
                    </div>
                    <p class="card-category">Store section #4</p>
                    <h4 class="card-title"><strong>Books & Booklets</strong></h4>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <a href="books-booklets-category.aspx" class="btn btn-success btn-sm">Enter</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
