<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="ABC_Website.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


            <table cellpadding="0" cellspacing="0" class="w-100" style="width: 114%; height: 219px">
                <tr>
                    <td class="auto-style2" rowspan="5" style="width: 300px; height: 300px;">
                        <asp:Image ID="imgProduct" runat="server" Height="256px" ImageUrl='<%# Eval("Image") %>' Width="256px" />
                    </td>
                    <td colspan="2">Name:
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Status:
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Details:
                        <asp:Label ID="lblDetail" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Price:
                        <asp:Label ID="lblPrice" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <a href="/AddCart.aspx" class="btn btn-primary">Add To Cart</a>
                    </td>
                    <td>
                        <a href="/Home.aspx" class="btn btn-primary">Continue Shopping</a>
                    </td>
                </tr>
            </table>

</asp:Content>
