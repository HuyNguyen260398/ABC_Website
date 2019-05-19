<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ABC_Website.Default" %>

<%@ Register src="UserControls/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 123px;
        }
        .auto-style4 {
            width: 35%;
        }
        .auto-style5 {
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style4">
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearch" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Product Category:</td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" Width="200px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ABCShopConnectionString %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Product Name:</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Product Price:</td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Product Image:</td>
                    <td>
                        <asp:FileUpload ID="FileUpload" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
                    </td>
                    <td>
                        <asp:Image ID="imgUpload" runat="server" Height="129px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Product Status</td>
                    <td>
                        <asp:TextBox ID="txtStatus" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Product Detail:</td>
                    <td>
                        <asp:TextBox ID="txtDetail" runat="server" Height="150px" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Font-Italic="true" ForeColor="#3333FF" Text="Message" Width="365px"></asp:Label>
            <br />
            <asp:GridView ID="gvwProduct" runat="server" AutoGenerateColumns="False" CssClass="auto-style5">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Category_ID" HeaderText="Category" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Detail" HeaderText="Detail" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:ImageField DataImageUrlField="Image" HeaderText="Image">
                    </asp:ImageField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSelect" runat="server" OnClick="lnkSelect_Click" CommandArgument='<%# Eval("ID") %>'>Select</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="/AddCart.aspx?id=<%#: Eval("ID") %>">Add To Cart</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
