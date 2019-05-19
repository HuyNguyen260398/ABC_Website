<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OrderManagement.aspx.cs" Inherits="ABC_Website.OrderManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvwOrder" runat="server" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="Customer" HeaderText="Customer" />
            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="Total_Payment" HeaderText="Total Payment" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="false" OnClick="btnEdit_Click" CommandArgument='<%# Eval("ID") %>'><i class="fa fa-edit"> Edit</i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br />
    <div class="form-group">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
    </div>
    <div class="form-group">
        <label>Customer:</label>
        <asp:TextBox ID="txtCustomer" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblCustomer" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="form-group">
        <label>Date:</label>
        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <asp:Label ID="lblDate" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="form-group">
        <label>Total Payment:</label>
        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblPrice" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="form-group">
        <label>Status:</label>
        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
            <asp:ListItem>Working</asp:ListItem>
            <asp:ListItem>Cancelled</asp:ListItem>
            <asp:ListItem>Done</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-warning" Text="Save" CausesValidation="false" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnClear" runat="server" CssClass="btn btn-info" Text="Cancel" CausesValidation="false" OnClick="btnClear_Click" />
    </div>
</asp:Content>
