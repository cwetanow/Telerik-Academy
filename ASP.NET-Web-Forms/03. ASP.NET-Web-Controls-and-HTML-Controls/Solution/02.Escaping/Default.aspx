<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02.Escaping._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:TextBox runat="server" ID="Input" ValidateRequestMode="Disabled"></asp:TextBox>
        <br />
        <asp:Button runat="server" OnClick="ButtonSubmitClick" />
        <hr />
        <asp:Label runat="server" ID="ResultLabel"></asp:Label>
        <br />
        <asp:TextBox runat="server" ID="ResultInput"></asp:TextBox>
    </div>

</asp:Content>
