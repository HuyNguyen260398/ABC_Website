<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ABC_Website.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="dlProducts" runat="server" RepeatColumns="3" CssClass="d-flex justify-content-center" BorderWidth="0">
        <ItemTemplate>
            <div class="card">
                <div class="card-img-top">
                    <asp:Image ID="Image2" Height="190px" Width="254px" runat="server" ImageUrl='<%# Eval("Image") %>' />
                </div>
                <div class="card-body pt-2 pb-0 bg-dark">
                    <p>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>' ForeColor="White"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Price") %>' ForeColor="White"></asp:Label>
                        <span style="color:white"> $</span>
                    </p>
                    <p>
                        <a href="/ProductDetail.aspx?id=<%#: Eval("ID") %>" class="btn btn-primary" style="color:white">Detail</a>
                        <a href="/AddCart.aspx?id=<%#: Eval("ID") %>" class="btn btn-primary" style="color:white">Add To Cart</a>
                    </p>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
