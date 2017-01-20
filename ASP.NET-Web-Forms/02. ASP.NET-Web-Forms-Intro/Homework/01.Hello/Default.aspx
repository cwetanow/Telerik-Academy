<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01.Hello._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <span>Your name is </span>
        <asp:Label runat="server" ID="Name"></asp:Label>
        <hr/>
        <span>Enter name:</span>
        <asp:TextBox runat="server" ID="NameBox"></asp:TextBox>
        <asp:Button runat="server" ID="ChangeName" OnClick="ChangeName_OnClick" Text="Submit" />
    </div>

</asp:Content>
