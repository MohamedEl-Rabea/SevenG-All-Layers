<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="my-cart.aspx.cs" Inherits="sevenG.Order.my_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="update1" runat="server">
        <ContentTemplate>
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header card-header-info">
                        <h4 class="card-title"><strong>My Cart</strong></h4>
                        <p class="card-category">Manage your cart</p>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <asp:GridView ID="GrdOrders" runat="server" Width="100%"
                                        DataKeyNames="PROD_NAME,ORDER_ID"
                                        CssClass="table text-center"
                                        AllowSorting="true"
                                        OnSelectedIndexChanged="GrdOrders_SelectedIndexChanged"
                                        OnRowDataBound="GrdOrders_RowDataBound"
                                        OnPageIndexChanging="GrdOrders_PageIndexChanging"
                                        AllowPaging="true"
                                        GridLines="None"
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ORDER_ID" HeaderText="Order Id" />
                                            <asp:BoundField DataField="PROD_NAME" HeaderText="Product Name" />
                                            <asp:BoundField DataField="PAPER_NAME" HeaderText="Material" />
                                            <asp:BoundField DataField="SIZE_NAME" HeaderText="Size" />
                                            <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                                            <asp:BoundField DataField="TOTAL_PRICE" HeaderText="Price" />
                                            <asp:TemplateField ItemStyle-CssClass="text-center" ItemStyle-Width="100" HeaderText="Addtional">
                                                <ItemTemplate>
                                                    <asp:TextBox
                                                        ID="txtAddtional"
                                                        runat="server"
                                                        TextMode="Number"
                                                        CssClass="form-control text-center"
                                                        AutoCompleteType="Disabled"
                                                        AutoPostBack="true"
                                                        OnTextChanged="txtAddtional_TextChanged"
                                                        Text='0'>
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator2"
                                                        runat="server"
                                                        ForeColor="Red"
                                                        Display="Dynamic"
                                                        SetFocusOnError="True"
                                                        ErrorMessage="This field is required"
                                                        ControlToValidate="txtAddtional">
                                                    </asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ButtonField Text="delete" ControlStyle-CssClass="btn btn-sm btn-danger" CommandName="Select" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Price
                                    </label>
                                    <asp:TextBox
                                        ID="TxtPrice"
                                        runat="server"
                                        Class="form-control text-center"
                                        AutoCompleteType="Disabled"
                                        aria-describedby="Price"
                                        ReadOnly="True">
                                    </asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Tax 5%
                                    </label>
                                    <asp:TextBox
                                        ID="txtTax"
                                        runat="server"
                                        Class="form-control text-center"
                                        Text="0"
                                        AutoCompleteType="Disabled"
                                        aria-describedby="Price"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Addtional
                                    </label>
                                    <asp:TextBox
                                        ID="txtAdd"
                                        runat="server"
                                        ReadOnly="true"
                                        Class="form-control text-center"
                                        AutoPostBack="true"
                                        OnTextChanged="txtAdd_TextChanged"
                                        TextMode="Number"
                                        AutoCompleteType="Disabled"
                                        aria-describedby="Price"
                                        Text="0">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Discount%
                                    </label>
                                    <asp:TextBox
                                        ID="txtDiscount"
                                        runat="server"
                                        Class="form-control text-center"
                                        TextMode="Number"
                                        AutoPostBack="true"
                                        OnTextChanged="txtDiscount_TextChanged"
                                        AutoCompleteType="Disabled"
                                        aria-describedby="Price"
                                        Text="0">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator2"
                                        runat="server"
                                        ForeColor="Red"
                                        Display="Dynamic"
                                        SetFocusOnError="True"
                                        ErrorMessage="This field is required"
                                        ControlToValidate="txtDiscount">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Total
                                    </label>
                                    <asp:TextBox
                                        ID="TxtTotal"
                                        runat="server"
                                        Class="form-control text-center"
                                        ReadOnly="true"
                                        AutoCompleteType="Disabled"
                                        aria-describedby="Price">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Report Type
                                    </label>
                                    <asp:RadioButtonList
                                        ID="radQuotInv"
                                        Class="form-control text-center"
                                        runat="server"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="radQuotInv_SelectedIndexChanged"
                                        RepeatDirection="Horizontal"
                                        RepeatLayout="Table"
                                        BorderStyle="NotSet">
                                        <asp:ListItem Text="Quotation &nbsp &nbsp &nbsp &nbsp " Value="0" Selected="true" />
                                        <asp:ListItem Text="Invoice" Value="1" />
                                    </asp:RadioButtonList>
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
                                    ID="finish"
                                    class="btn btn-primary"
                                    runat="server"
                                    Text="Save"
                                    OnClick="finish_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
