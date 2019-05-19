<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="ABC_Website.UserControls.Menu" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

<form runat="server">
    <asp:GridView ID="gvwMenu" runat="server" AutoGenerateColumns="False" Width="100%">
    <Columns>
        <asp:HyperLinkField DataNavigateUrlFields="Name" DataTextField="Name" HeaderText="Category" NavigateUrl="#" />
    </Columns>
</asp:GridView>
</form>


