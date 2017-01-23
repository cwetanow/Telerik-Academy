<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01.RandomNumber._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>With HTML controls</h1>
        <input type="number" id="MinNumberInput" runat="server" />
        <input type="number" id="MaxNumberInput" runat="server" />
        <br />
        <input type="button" runat="server" onserverclick="OnButtonRandomClick" value="Generate" />
        <hr />
        <span runat="server" id="Sum"></span>
    </div>
    <div class="jumbotron">
        <h1>With HTML controls</h1>
        <asp:TextBox runat="server" ID="MinInputServer"></asp:TextBox>
        <asp:TextBox runat="server" ID="MaxInputServer"></asp:TextBox>
        <br />
        <asp:Button runat="server" OnClick="OnServerButtonClick" Text="Generate" />
        <hr />
        <asp:Label runat="server" ID="ServerRandomResult"></asp:Label>
    </div>
</asp:Content>
