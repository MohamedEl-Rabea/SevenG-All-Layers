<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="business-cards-category.aspx.cs" Inherits="sevenG.Products.business_cards_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-7">
            <div class="row">
                <div class="card">
                    <div class="card-header card-header-info">
                        <h4 class="card-title"><strong>Business Cards</strong></h4>
                        <p class="card-category">Design your card</p>
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
                                        <asp:ListItem Value="1">Without Spot UV</asp:ListItem>
                                        <asp:ListItem Value="2">Spot UV1</asp:ListItem>
                                        <asp:ListItem Value="3">Spot UV2</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6" runat="server" id="divLamin" visible="false">
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
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Round Corner</label>
                                    <asp:CheckBoxList
                                        ID="checkRoundCorn"
                                        AutoPostBack="true"
                                        TextAlign="Right"
                                        runat="server"
                                        Width="100%"
                                        RepeatDirection="Horizontal"
                                        OnSelectedIndexChanged="checkRoundCorn_SelectedIndexChanged">
                                        <asp:ListItem Value="1">
                                                    <small>Upper right</small>
                                                    <img data-name="img-corner" src="../assets/img/rounded_corners.png" width="85" height="85" />
                                        </asp:ListItem>
                                        <asp:ListItem Value="2">
                                                    <small>Upper Left</small>
                                                    <img data-name="img-corner" src="../assets/img/rounded_corners.png" width="85" height="85" />
                                        </asp:ListItem>
                                        <asp:ListItem Text="Lower Right" Value="3">
                                                    <small>Lower Right</small>
                                                    <img data-name="img-corner" src="../assets/img/rounded_corners.png" width="85" height="85" />
                                        </asp:ListItem>
                                        <asp:ListItem Value="4">
                                                    <small>Lower Left</small>
                                                    <img data-name="img-corner" src="../assets/img/rounded_corners.png" width="85" height="85" />
                                        </asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Card summary <small>(Auto generated content)</small></label>
                                    <div class="form-group">
                                        <textarea class="form-control" runat="server" id="txtAreaCardSummary" disabled="disabled" rows="3">
Card type - material type - selected size - special effect - lamination type - rounding type - print sides - print type.
                                        </textarea>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 text-center">
                                <asp:Button
                                    ID="save"
                                    class="btn btn-primary"
                                    runat="server"
                                    Text="Add to cart"
                                    OnClick="save_Click" />
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
                                            <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                                            <asp:BoundField DataField="PRICE" HeaderText="Price" />
                                            <asp:ButtonField Text="Select" ControlStyle-CssClass="btn btn-sm btn-success" CommandName="Select" ItemStyle-Width="30" />
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
