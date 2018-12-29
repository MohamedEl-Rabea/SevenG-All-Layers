<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="Operation-navigation-panel.aspx.cs" Inherits="sevenG.Operation.Operation_navigation_panel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-3 col-md-6 col-sm-6">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">menu</i>
                    </div>
                    <p class="card-category">Operation section #1</p>
                    <h4 class="card-title"><strong>Orders</strong></h4>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <input type="button" value="Enter" class="btn btn-success btn-sm" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-6 col-sm-6">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">autorenew</i>
                    </div>
                    <p class="card-category">Operation section #2</p>
                    <h4 class="card-title"><strong>Process order</strong></h4>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <input type="button" value="Enter" class="btn btn-success btn-sm" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-6 col-sm-6">
            <div class="card card-stats">
                <div class="card-header card-header-info card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">send</i>
                    </div>
                    <p class="card-category">Operation section #3</p>
                    <h4 class="card-title"><strong>Finish order</strong></h4>
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

