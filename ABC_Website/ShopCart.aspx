<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShopCart.aspx.cs" Inherits="ABC_Website.ShopCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <% if (Session["shoppingcart"] == null || ((List<ABC_Website.Models.CartItem>)Session["shoppingcart"]).Count == 0)
            { %>
        <p>
            Cart is empty!
        </p>
        <% } %>
        <% else
            { %>
        <table style="width: 100%;" class="table table-bordered">
            <thead>
                <tr>
                    <th>Image</th>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th>Subtotal</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>

            </thead>
            <% foreach (var cardItem in Session["shoppingcart"] as List<ABC_Website.Models.CartItem>)
                { %>
            <tr>
                <td>
                    <img src="<%= cardItem.pro_image %>" width="70" height="70" /></td>
                <td><%= cardItem.pro_name %></td>
                <td><%= cardItem.pro_price.ToString("#,##0") %> $</td>
                <td><%= cardItem.quantity %></td>
                <td><%= cardItem.total.ToString("#,##0") %> $</td>
                <td><a title="Increase" href="/EditCart.aspx?id=<%= cardItem.pro_id %>&change=plus" style="text-decoration: none" class="btn btn-default"><span class="fa fa-plus"></span></a></td>
                <td><a title="Decrease" href="/EditCart.aspx?id=<%= cardItem.pro_id %>&change=minus" style="text-decoration: none" class="btn btn-default"><span class="fa fa-minus"></span></a></td>
                <td><a title="Remove" onclick="return confirm('Are you sure to remove this item?');" href="/DeleteCart.aspx?id=<%= cardItem.pro_id %>" style="text-decoration: none" class="btn btn-default"><span class="fa fa-trash-o"></span></a></td>
            </tr>
            <% } %>
            <tr>
                <td></td>
                <td></td>
                <td>Total Amount: </td>
                <td><%= ((List<ABC_Website.Models.CartItem>)Session["shoppingcart"]).Sum(m => m.quantity) %> items</td>
                <td>Total Purchase: </td>
                <td><%= ((List<ABC_Website.Models.CartItem>)Session["shoppingcart"]).Sum(m => m.total).ToString("#,##0") %> $</td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <% } %>
    </div>
    <a href="Home.aspx" class="btn btn-primary">Continue Shopping</a>
    <button type="button" class="btn btn-primary" data-toggle="collapse" data-target="#order">Order</button>
    <div id="order" class="collapse">
        <h2>Register Form</h2>
        <div class="form-group">
            <label for="Name">Name:</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" SkinID="Name"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" ErrorMessage="Name is required!" ForeColor="Red"></asp:RequiredFieldValidator>
        <div class="form-group">
            <label for="Phone">Phone:</label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" TextMode="Phone" SkinID="Phone"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPhone" ErrorMessage="Password is required!" ForeColor="Red"></asp:RequiredFieldValidator>
        <div class="form-group">
            <label for="Email">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" SkinID="Email"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required!" ForeColor="Red"></asp:RequiredFieldValidator>
        <div class="form-group">
            <label for="Address">Address:</label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" SkinID="Address"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required!" ForeColor="Red"></asp:RequiredFieldValidator>
        <div class="form-group">
            <asp:Button ID="btnOrder" runat="server" CssClass="btn btn-primary" Text="Order" CausesValidation="false" OnClick="btnOrder_Click" />
        </div>
        <div class="form-group">
            <asp:Label ID="lblMessage" runat="server" CssClass="alert-success"></asp:Label>
        </div>
    </div>
</asp:Content>
