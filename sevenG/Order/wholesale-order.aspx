<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="wholesale-order.aspx.cs" Inherits="sevenG.Order.wholesale_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-info">
                    <h4 class="card-title"><strong>Orders</strong></h4>
                    <p class="card-category">Add Wholesale Order</p>
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
                                    DataTextField="CAT_NAME_E"
                                    DataValueField="CAT_ID"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="DRLCat_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Paper Name
                                </label>
                                <asp:DropDownList
                                    ID="DRLMaterials"
                                    runat="server"
                                    CssClass="dropDownStyle"
                                    DataTextField="PAPER_NAME"
                                    DataValueField="PAPER_ID"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="DRLMaterials_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Size
                                </label>
                                <asp:DropDownList
                                    ID="DRLSize"
                                    runat="server"
                                    CssClass="dropDownStyle"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="DRLSize_SelectedIndexChanged">
                                    <asp:ListItem Value="101">A3(33*48)</asp:ListItem>
                                    <asp:ListItem Value="102">A4</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Sides
                                </label>
                                <asp:DropDownList
                                    ID="DRLSides"
                                    runat="server"
                                    CssClass="dropDownStyle"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="DRLSides_SelectedIndexChanged">
                                    <asp:ListItem Value="2">2 Sides</asp:ListItem>
                                    <asp:ListItem Value="1">1 Side</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Print Type
                                </label>
                                <asp:DropDownList
                                    ID="DrpPrint"
                                    runat="server"
                                    CssClass="dropDownStyle"
                                    DataTextField="PRINTER_TYPE"
                                    DataValueField="PRINTER_ID"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="DrpPrint_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <br />
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
                                    ID="TxtPrice"
                                    runat="server"
                                    CssClass="form-control"
                                    AutoCompleteType="Disabled"
                                    aria-describedby="Price">
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
                                ID="save"
                                class="btn btn-primary"
                                runat="server"
                                Text="Save"
                                OnClick="save_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
