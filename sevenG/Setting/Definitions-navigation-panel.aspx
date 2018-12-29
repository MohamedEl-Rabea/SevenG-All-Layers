<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="Definitions-navigation-panel.aspx.cs" Inherits="sevenG.Definitions_navigation_panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-4 col-md-6 col-sm-6">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">storage</i>
                    </div>
                    <p class="card-category">Material</p>
                    <h4 class="card-title"><strong>Add material data</strong></h4>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <input type="button" value="Enter" class="btn btn-success btn-sm" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-6">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">people</i>
                    </div>
                    <p class="card-category">Suppliers</p>
                    <h4 class="card-title"><strong>Add suppliers data</strong></h4>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <input type="button" value="Enter" class="btn btn-success btn-sm" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-6">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">people_outline</i>
                    </div>
                    <p class="card-category">Clients</p>
                    <h4 class="card-title"><strong>Add clients data</strong></h4>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <input type="button" value="Enter" class="btn btn-success btn-sm" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
