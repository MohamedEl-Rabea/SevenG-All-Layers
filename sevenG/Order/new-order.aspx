<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="new-order.aspx.cs" Inherits="sevenG.Order.new_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-info">
                    <h4 class="card-title"><strong>Orders</strong></h4>
                    <p class="card-category">Add New Order</p>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Customer name
                                </label>
                                <asp:DropDownList
                                    ID="DRLCustName"
                                    runat="server"
                                    CssClass="selectpicker"
                                    placeholder="اسم المنتج"
                                    DataTextField="CUSTOMER_NAME"
                                    DataValueField="CUSTOMER_ID">
                                    <asp:ListItem Value="0" Text="Select customer" />
                                </asp:DropDownList>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="material-icons text-info" style="height: 100px">add_box</i>
                                    <a href="../Setting/customer-defnition.aspx" class="text-lg-left" title="Add new customer if not exists in choices">Add new customer</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Order Type
                                </label>
                                <asp:DropDownList
                                    ID="DRLOrderType"
                                    runat="server"
                                    CssClass="selectpicker"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="DRLOrderType_SelectedIndexChanged">
                                    <asp:ListItem Value="1">Normal Order</asp:ListItem>
                                    <asp:ListItem Value="2">Custom Order</asp:ListItem>
                                    <asp:ListItem Value="3">Wholesale Order</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row" runat="server" id="divErrMsg" visible="false">
                        <div class="col-md-12">
                            <div class="alert alert-danger text-center">
                                <span>
                                    <b>Error - </b>
                                    <asp:Label
                                        ID="LBLError"
                                        runat="server"
                                        class="margin text-center"
                                        Text="Here will be the error details">
                                    </asp:Label>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <asp:Button
                                ID="BtnSave"
                                class="btn btn-primary"
                                runat="server"
                                Text="Save"
                                OnClick="BtnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
