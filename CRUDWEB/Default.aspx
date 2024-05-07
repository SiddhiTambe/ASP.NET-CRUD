<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUDWEB._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <asp:Label ID="ID" runat="server" Text="ID"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Name" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="Insert" runat="server" Text="Insert" OnClick="Insert_Click" />
        <asp:Button ID="Read" runat="server" Text="Read" OnClick="Read_Click" />
        <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
        <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" />
        <asp:Button ID="Clear" runat="server" Text="Clear" OnClick="Clear_Click" />
    </main>

</asp:Content>

