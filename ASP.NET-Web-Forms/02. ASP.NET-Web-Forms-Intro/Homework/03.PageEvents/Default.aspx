<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_03.PageEvents._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Button ID="mainButton"
            runat="server"
            OnInit="OnButtonInit"
            OnLoad="OnButtonLoad"
            OnClick="OnButtonClicked"
            OnPreRender="OnButtonPreRender"
            Text="Click" />
        <br />
    </div>

</asp:Content>
