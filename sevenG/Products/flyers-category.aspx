<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="flyers-category.aspx.cs" Inherits="sevenG.Products.flyers_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="card">
                    <div class="card-header card-header-info">
                        <h4 class="card-title"><strong>Flyers</strong></h4>
                        <p class="card-category">Design Your Flyer</p>
                    </div>
                    <div class="card-body">
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
                                        Special Effect
                                    </label>
                                    <asp:DropDownList
                                        ID="DrpSecialEffect"
                                        runat="server"
                                        CssClass="selectpicker"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DrpSecialEffect_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="Select effect" />
                                        <asp:ListItem Value="1">Without Spot UV</asp:ListItem>
                                        <asp:ListItem Value="2">Spot UV1</asp:ListItem>
                                        <asp:ListItem Value="3">Spot UV2</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
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
                                        <asp:ListItem Text="Select sides" />
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
                                        CssClass="selectpicker"
                                        DataTextField="PRINTER_TYPE"
                                        DataValueField="PRINTER_ID"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DrpPrint_SelectedIndexChanged">
                                        <asp:ListItem Text="Select print type" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="bmd-label-floating">
                                        Finishing
                                    </label>
                                    <asp:DropDownList
                                        ID="DrpFinishing"
                                        runat="server"
                                        CssClass="selectpicker"
                                        DataTextField="FINISHING_TYPE"
                                        DataValueField="FINISHING_ID"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="DrpFinishing_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Flyer summary <small>(Auto generated content)</small></label>
                                    <div class="form-group">
                                        <textarea class="form-control" disabled="disabled" rows="3">
Product type - material type - selected size - special effect - lamination type - Finishing type - print sides - print type.
                                        </textarea>
                                    </div>
                                </div>
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
                        <div class="table-responsive">
                            <asp:GridView
                                ID="GrdPrices"
                                runat="server"
                                DataKeyNames="ID"
                                OnSelectedIndexChanged="GrdPrices_SelectedIndexChanged"
                                OnRowDataBound="GrdPrices_RowDataBound"
                                AutoGenerateColumns="False"
                                GridLines="None"
                                CssClass="table"
                                ShowFooter="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label
                                                ID="lblAmount"
                                                runat="server"
                                                Text='<%# Bind("QUANTITY") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox
                                                ID="txtCustomeAmount"
                                                CssClass="form-control"
                                                runat="server"
                                                placeholder="Custom amount">
                                            </asp:TextBox>
                                        </FooterTemplate>
                                        <FooterStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" CssClass="text-primary" Text='<%# Bind("PRICE", "{0:c}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox
                                                ID="txtCustomePrice"
                                                CssClass="form-control"
                                                runat="server"
                                                placeholder="Custom price"></asp:TextBox>
                                        </FooterTemplate>
                                        <FooterStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price">
                                        <ItemTemplate>
                                            <asp:Button
                                                ID="btnAddToCart"
                                                runat="server"
                                                CommandName="Select"
                                                CssClass="btn btn-sm btn-success"
                                                Text='Add to cart'></asp:Button>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button
                                                ID="btnAddToCartFooter"
                                                runat="server"
                                                CssClass="btn btn-sm btn-success"
                                                CommandName="Select"
                                                Text="Add to cart"></asp:Button>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
