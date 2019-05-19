<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductManagement.aspx.cs" Inherits="ABC_Website.ProductManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvwProduct" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999"
        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%" 
        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvwProduct_PageIndexChanging">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="Category_ID" HeaderText="Category ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Detail" HeaderText="Detail" />
            <asp:ImageField DataImageUrlField="Image" HeaderText="Image" ControlStyle-Width="128px" ControlStyle-Height="128px">
<ControlStyle Height="128px" Width="128px"></ControlStyle>
            </asp:ImageField>
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:BoundField DataField="Price" HeaderText="Price"/>
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
        <label>Category:</label>
        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" CssClass="form-control"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:myConStrDB %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
    </div>
    <div class="form-group">
        <label>Name:</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblName" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="form-group">
        <label>Detail:</label>
        <asp:TextBox ID="txtDetail" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblDetail" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="form-group">
        <label>Image:</label>
        <asp:FileUpload ID="FileUpload" runat="server" />
    </div>
    <div class="form-group">
        <asp:Button ID="btnUpload" runat="server" CausesValidation="false" OnClick="btnUpload_Click" Text="Upload" CssClass="btn btn-primary"/>
        <asp:Image ID="imgUpload" runat="server" Height="128px" Width="128px" />
        <asp:Label ID="lblImage" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="form-group">
        <label>Status:</label>
        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
            <asp:ListItem>New</asp:ListItem>
            <asp:ListItem>Hot</asp:ListItem>
            <asp:ListItem>Out of sale</asp:ListItem>
            <asp:ListItem>Available soon</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label>Price:</label>
        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblPrice" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div class="form-group">
        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" CausesValidation="false" Text="Add" OnClick="btnAdd_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-warning" Text="Update" CausesValidation="false" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" CausesValidation="false" OnClick="btnDelete_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnClear" runat="server" CssClass="btn btn-info" Text="Clear" CausesValidation="false" OnClick="btnClear_Click" />
    </div>
</asp:Content>
