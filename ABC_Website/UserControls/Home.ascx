<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="ABC_Website.UserControls.Home" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

<asp:DataList ID="dlProducts" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" RepeatColumns="4">
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <ItemTemplate>
        <table cellpadding="0" cellspacing="0" class="auto-style1">
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" Height="250px" ImageUrl='<%# Eval("Image") %>' Width="250px" />
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#">Buy</asp:HyperLink>
                </td>
            </tr>
        </table>
    </ItemTemplate>
    <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
</asp:DataList>

