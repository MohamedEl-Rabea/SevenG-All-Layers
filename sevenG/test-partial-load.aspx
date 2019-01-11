<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test-partial-load.aspx.cs" Inherits="sevenG.test_partial_load" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <asp:ScriptManager EnablePartialRendering="true"
            ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="lblPartialPostBackTime" runat="server" />
                    <br />
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
                    <asp:DropDownList
                        ID="DropDownList1"
                        runat="server"
                        CssClass="selectpicker"
                        AutoPostBack="True">
                        <asp:ListItem Value="2">Item #1</asp:ListItem>
                        <asp:ListItem Value="3">Item #2</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="btnPartial" runat="server"
                        Text="Partial Postback" OnClick="btnPartial_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Label ID="lblFullPostBackTime" runat="server" />
            <br />
            <asp:Button ID="btnFull" runat="server"
                Text="Full Postback" OnClick="btnFull_Click" />
        </div>
    </form>
</body>
</html>
