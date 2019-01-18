<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="books-booklets-category.aspx.cs" Inherits="sevenG.Products.books_bocklets_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-7">
            <div class="row">
                <div class="card">
                    <div class="card-header card-header-info">
                        <h4 class="card-title"><strong>Portrait Books & Booklets</strong></h4>
                        <p class="card-category">Design Your Book</p>
                    </div>
                    <div class="card-body">
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
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Product name
                                    </label>
                                    <asp:DropDownList
                                        ID="DRLProName"
                                        runat="server"
                                        CssClass="selectpicker"
                                        placeholder="اسم المنتج"
                                        DataTextField="PROD_NAME"
                                        DataValueField="PROD_ID"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DRLProName_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="Select product" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Material
                                    </label>
                                    <asp:DropDownList
                                        ID="DRLMaterials"
                                        runat="server"
                                        CssClass="selectpicker"
                                        DataTextField="PAPER_NAME"
                                        DataValueField="PAPER_ID"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DRLMaterials_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="Select material" />
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
                                        CssClass="selectpicker"
                                        DataTextField="SIZE_NAME"
                                        DataValueField="SIZE_ID"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DRLSize_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="Select size" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Lamination
                                    </label>
                                    <asp:DropDownList
                                        ID="DRLLamination"
                                        runat="server"
                                        CssClass="selectpicker"
                                        DataTextField="LAMINATION_NAME"
                                        DataValueField="LAMINATION_ID"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DRLLamination_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="Select lamination type" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Sides
                                    </label>
                                    <asp:DropDownList
                                        ID="DRLSides"
                                        runat="server"
                                        CssClass="selectpicker"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DRLSides_SelectedIndexChanged">
                                        <asp:ListItem Value="2">2 Sides</asp:ListItem>
                                        <asp:ListItem Value="1">1 Side</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Print Type
                                    </label>
                                    <asp:DropDownList
                                        ID="DrpPrint"
                                        runat="server"
                                        CssClass="selectpicker"
                                        DataTextField="PRINTER_TYPE"
                                        DataValueField="PRINTER_ID"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DrpPrint_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="Select print type" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        NO, Of Pages
                                    </label>
                                    <asp:TextBox
                                        ID="TxtPages"
                                        runat="server"
                                        AutoCompleteType="Disabled"
                                        AutoPostBack="true"
                                        Text="4"
                                        OnTextChanged="TxtPages_TextChanged"
                                        CssClass="form-control"
                                        aria-describedby="Pages Number"
                                        placeholder="عدد الصفحات مضاعفات 4 مثل : 4,8,12,16">
                                    </asp:TextBox>
                                    <asp:CompareValidator
                                        ID="ComparePages"
                                        runat="server"
                                        ControlToValidate="TxtPages"
                                        ErrorMessage="Number of pages must be less than 80 with Saddle staple Binding"
                                        Operator="LessThan"
                                        Type="Integer"
                                        ValueToCompare="80"
                                        ForeColor="Red"
                                        SetFocusOnError="True"
                                        Enabled="true" />
                                    <%-- <asp:RequiredFieldValidator 
                                                ID="RequiredFieldValidator1" 
                                                runat="server" 
                                                ForeColor="Red" 
                                                SetFocusOnError="True" 
                                                ErrorMessage="This field is required" ControlToValidate="TxtPages">
                                                </asp:RequiredFieldValidator>
                                    --%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Binding
                                    </label>
                                    <asp:RadioButtonList
                                        ID="Binding"
                                        Class="form-control"
                                        runat="server"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="Binding_SelectedIndexChanged"
                                        RepeatDirection="Horizontal"
                                        RepeatLayout="Table">
                                        <asp:ListItem Text="Saddle staple" Value="0" Selected="true" />
                                        <asp:ListItem Text="Perfect" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="alert alert-info text-center">
                                    <h4><strong>Cover Details</strong></h4>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Cover printing type
                                    </label>
                                    <asp:DropDownList
                                        ID="DrpCoPrintType"
                                        runat="server"
                                        CssClass="selectpicker"
                                        DataTextField="PROD_NAME"
                                        DataValueField="PROD_ID"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DrpCoPrintType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Material
                                    </label>
                                    <asp:DropDownList
                                        ID="DRPCoMaterial"
                                        runat="server"
                                        CssClass="selectpicker"
                                        DataTextField="PAPER_NAME"
                                        DataValueField="PAPER_ID"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DRPCoMaterial_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6" runat="server" id="divSpecial">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Special Effect
                                    </label>
                                    <asp:DropDownList
                                        ID="DrpSecialEffect"
                                        runat="server"
                                        CssClass="selectpicker"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DrpSecialEffect_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Lamination</asp:ListItem>
                                        <asp:ListItem Value="2">Spot UV</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6" runat="server" id="divLamin" visible="false">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Lamination
                                    </label>
                                    <asp:DropDownList
                                        ID="DRPCoLamination"
                                        runat="server"
                                        CssClass="selectpicker"
                                        DataTextField="LAMINATION_NAME"
                                        DataValueField="LAMINATION_ID"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DRPCoLamination_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Sides
                                    </label>
                                    <asp:DropDownList
                                        ID="DRPCoSides"
                                        runat="server"
                                        class="selectpicker"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DRPCoSides_SelectedIndexChanged">
                                        <asp:ListItem Value="2">2 Sides</asp:ListItem>
                                        <asp:ListItem Value="1">1 Side</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Print Type
                                    </label>
                                    <asp:DropDownList
                                        ID="DrpCoPrint"
                                        runat="server"
                                        class="selectpicker"
                                        DataTextField="PRINTER_TYPE"
                                        DataValueField="PRINTER_ID"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DrpCoPrint_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Select Print Type</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Book summary <small>(Auto generated content)</small></label>
                                    <div class="form-group">
                                        <textarea class="form-control" runat="server" id="txtAreaBookSummary" disabled="disabled" rows="3">
                                                    Auto geenrated selected book options summary
                                                </textarea>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 text-center">
                                <asp:Button
                                    ID="BtnSave"
                                    class="btn btn-primary"
                                    runat="server"
                                    Text="Add to cart"
                                    OnClick="BtnSave_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
        <div class="col-md-1">
        </div>
        <div class="col-md-4">
            <div class="row">
                <div class="card">
                    <div class="card-header card-header-info">
                        <h4 class="card-title "><strong>Prices list</strong></h4>
                        <p class="card-category">Choose your offer from list below</p>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <asp:GridView
                                        ID="GrdPrices"
                                        runat="server"
                                        DataKeyNames="ID"
                                        OnSelectedIndexChanged="GrdPrices_SelectedIndexChanged"
                                        OnRowDataBound="GrdPrices_RowDataBound"
                                        AutoGenerateColumns="False"
                                        GridLines="None"
                                        CssClass="table">
                                        <Columns>
                                            <asp:BoundField DataField="QUANTITY_ID" HeaderText="Quantity" />
                                            <asp:BoundField DataField="QUANTITY_PRICE" HeaderText="Price" />
                                            <asp:BoundField DataField="COST" HeaderText="Paper cost" Visible="false" />
                                            <asp:BoundField DataField="COVER_COST" HeaderText="Total Cost" Visible="false" />
                                            <asp:BoundField DataField="DISCOUNT_PERC" Visible="false" HeaderText="total cost" />
                                            <asp:ButtonField
                                                Text="Select"
                                                ControlStyle-CssClass="btn btn-sm btn-success"
                                                CommandName="Select"
                                                ItemStyle-Width="30" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Amount
                                    </label>
                                    <asp:TextBox
                                        ID="TXTQuantity"
                                        runat="server"
                                        CssClass="form-control"
                                        AutoCompleteType="Disabled"
                                        aria-describedby="Quantity">
                                    </asp:TextBox>
                                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ForeColor="Red" SetFocusOnError="True"
                                        ControlToValidate="TXTQuantity" ErrorMessage="Value must be a number" />
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Price
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
