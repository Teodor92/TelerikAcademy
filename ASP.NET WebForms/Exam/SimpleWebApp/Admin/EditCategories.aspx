<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="SimpleWebApp.EditCategories" %>

<asp:Content ID="EditCategoriesContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Categories</h1>

    <asp:GridView
        AutoGenerateColumns="false"
        ID="CategoriesGridView"
        PageSize="5"
        ItemType="SimpleWebApp.Models.Category"
        DataKeyNames="Id"
        SelectMethod="CategoriesGridView_GetData"
        AllowPaging="true"
        AllowSorting="true"
        CssClass="table table-striped table-bordered table-condensed"
        runat="server">

        <Columns>
            <asp:TemplateField HeaderText="Category Name" SortExpression="Name">
                <ItemTemplate>
                    <%#: Item.Name.Length < 20 ? Item.Name : Item.Name.Substring(0, 20) + "..." %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button CssClass="btn" OnCommand="Edit_Command" CommandArgument="<%# Item.Id %>" Text="Edit" runat="server" />
                    <asp:Button CssClass="btn" OnCommand="Delete_Command" CommandArgument="<%# Item.Id %>" Text="Delete" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button CssClass="btn" ID="AddNewButton" OnCommand="OpendAddWindow_Command" Text="Create New" runat="server" />

    <asp:Panel runat="server" Visible="false" ID="AddNewCategoryForm">
        <h3>Add Category</h3>
        <asp:TextBox ID="AddNewTextBox" runat="server"></asp:TextBox>
        <asp:Button CssClass="btn" OnCommand="AddNew_Command" Text="Add" runat="server" />
        <asp:Button CssClass="btn" OnCommand="Cancel_Command" Text="Cancel" runat="server" />
    </asp:Panel>

    <asp:FormView
        ID="EditCategoryFormView"
        ItemType="SimpleWebApp.Models.Category"
        DataKeyNames="Id"
        runat="server">
        <ItemTemplate>
            <h3>Edit Category</h3>
            <div>
                <asp:TextBox ID="EditNameTextBox" Text="<%#: Item.Name %>" runat="server"></asp:TextBox>
                <asp:Button CssClass="btn" OnCommand="Save_Command" Text="Add" runat="server" />
                <asp:Button CssClass="btn" OnCommand="Cancel_Command" Text="Cancel" runat="server" />
            </div>
        </ItemTemplate>
    </asp:FormView>

    <asp:FormView
        ID="DeleteFormView"
        ItemType="SimpleWebApp.Models.Category"
        DataKeyNames="Id"
        runat="server">
        <ItemTemplate>
            <h3>Confirm Book Deletion?</h3>
            <asp:TextBox ID="ConfurmNameTextBox" Enabled="false" Text="<%#: Item.Name %>" runat="server"></asp:TextBox>
            <asp:Button CssClass="btn" OnCommand="DeleteConfurm_Command" Text="Delete" runat="server" />
            <asp:Button CssClass="btn" OnCommand="Cancel_Command" Text="Cancel" runat="server" />
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
