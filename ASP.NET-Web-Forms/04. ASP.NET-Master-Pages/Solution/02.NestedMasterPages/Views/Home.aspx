<%@ Page Title="Home" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Home.aspx.cs" 
    Inherits="_02.NestedMasterPages.Views.Home" %>

<asp:Content ID="ContentPage" runat="server"
             ContentPlaceHolderID="MainContent">
    <asp:HyperLink runat="server" NavigateUrl="~/Views/Bulgaria/Home.aspx" Text="Bulgaria" CssClass="bg-icon"/>
    <hr/>
    <asp:HyperLink runat="server" NavigateUrl="~/Views/England/Home.aspx" Text="England" CssClass="uk-icon"/>
</asp:Content>