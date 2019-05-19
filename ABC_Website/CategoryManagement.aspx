<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CategoryManagement.aspx.cs" Inherits="ABC_Website.CategoryManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvwCategory" runat="server" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Category Name" />
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
        <asp:Label ID="lblMessage" runat="server" CssClass="alert-success"></asp:Label>
    </div>
    <div class="form-group">
        <label>Category Name:</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblName" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="form-group">
        <label>Category Status:</label>
        <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="form-group">
        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" CausesValidation="false" Text="Add" OnClick="btnAdd_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-warning" Text="Update" CausesValidation="false" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" CausesValidation="false" OnClick="btnDelete_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-info" Text="Clear" CausesValidation="false" OnClick="btnClear_Click" />
    </div>
</asp:Content>
