<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="custom-order.aspx.cs" Inherits="sevenG.Order.custom_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-info">
                    <h4 class="card-title"><strong>Orders</strong></h4>
                    <p class="card-category">Add Custom Order</p>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Product name
                                </label>
                                <asp:DropDownList
                                    ID="DRLCat"
                                    runat="server"
                                    CssClass="dropDownStyle"
                                    placeholder="اسم المنتج"
                                    DataTextField="CATEGORY_NAME"
                                    DataValueField="CATEGORY_ID"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="DRLCat_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="material-icons text-info">add_box</i>
                                    <a href="../Setting/product-definition.aspx" class="text-lg-left" title="Add new product if not exists in choices">Add product</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Supplier
                                </label>
                                <asp:DropDownList
                                    ID="DRLSupplier"
                                    runat="server"
                                    CssClass="dropDownStyle"
                                    DataTextField="SUPPLIER_NAME"
                                    DataValueField="SUPPLIER_ID"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="DRLSupplier_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="card-footer">
                                <div class="stats">
                                    <i class="material-icons text-info">add_box</i>
                                    <a href="../Setting/supplier-definition.aspx" class="text-lg-left" title="Add new supplier if not exists in choices">Add supplier</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Quantity
                                </label>
                                <asp:TextBox
                                    ID="TXTQuantity"
                                    runat="server"
                                    AutoCompleteType="Disabled"
                                    Class="form-control"
                                    TextMode="Number"
                                    aria-describedby="No.Sheets">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Price/unit
                                </label>
                                <asp:TextBox
                                    ID="txtPrice"
                                    runat="server"
                                    Class="form-control"
                                    TextMode="Number"
                                    aria-describedby="No.Sheets">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Cost/unit
                                </label>
                                <asp:TextBox
                                    ID="TXTCostPrice"
                                    runat="server"
                                    CssClass="form-control"
                                    TextMode="Number"
                                    aria-describedby="No.Sheets">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Description
                                </label>
                                <asp:TextBox
                                    ID="TXTDescription"
                                    runat="server"
                                    Class="form-control"
                                    TextMode="MultiLine"
                                    Rows="2"
                                    aria-describedby="No.Sheets">
                                </asp:TextBox>
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
