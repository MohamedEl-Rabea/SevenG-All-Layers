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
                                        CssClass="table table-bordered"
                                        AllowSorting="true"
                                        OnSelectedIndexChanged="GrdOrders_SelectedIndexChanged"
                                        OnRowDataBound="GrdOrders_RowDataBound"
                                        OnPageIndexChanging="GrdOrders_PageIndexChanging"
                                        AllowPaging="true"
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
                                            <asp:TemplateField HeaderText="Addtional">
                                                <ItemTemplate>
                                                    <asp:TextBox
                                                        ID="txtAddtional"
                                                        runat="server"
                                                        CssClass="form-control"
                                                        TextMode="Number"
                                                        AutoCompleteType="Disabled"
                                                        AutoPostBack="true"
                                                        OnTextChanged="txtAddtional_TextChanged"
                                                        Width="70px"
                                                        Text='0'>
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator2"
                                                        runat="server"
                                                        ForeColor="Red"
                                                        SetFocusOnError="True"
                                                        ErrorMessage="This field is required"
                                                        ControlToValidate="txtAddtional">
                                                    </asp:RequiredFieldValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ButtonField Text="delete" CommandName="Select" ItemStyle-Width="25" ItemStyle-ForeColor="Red" />
                                        </Columns>

                                    </asp:GridView>

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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
