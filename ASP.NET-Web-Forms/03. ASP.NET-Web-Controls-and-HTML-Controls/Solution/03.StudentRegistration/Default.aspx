<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_03.StudentRegistration._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div runat="server" id="RegisterForm">
            First name:
            <asp:TextBox runat="server" ID="FirstNameInput" />
            <br />
            Second name:
            <asp:TextBox runat="server" ID="LastNameInput" />
            <br />
            Faculty number:
            <asp:TextBox runat="server" ID="FacultyNumberInput" />
            <br />

            University: 
                <asp:DropDownList runat="server" ID="UniversityDropDown">
                    <asp:ListItem Text="Sofia University" />
                    <asp:ListItem Text="Medical University" />
                    <asp:ListItem Text="New Bulgarian University" />
                    <asp:ListItem Text="UNSS" />
                </asp:DropDownList>
            <br />

            Specialty: 
                <asp:DropDownList runat="server" ID="SpecialtyDropDown">
                    <asp:ListItem Text="Programming" />
                    <asp:ListItem Text="Software Engineering" />
                    <asp:ListItem Text="Law" />
                    <asp:ListItem Text="Medicine" />
                    <asp:ListItem Text="Dental Medicine" />
                </asp:DropDownList>
            <br />

            Course: 
                <asp:DropDownList runat="server" ID="CourseDropDown">
                    <asp:ListItem Text="Chemistry" />
                    <asp:ListItem Text="Computer Science" />
                    <asp:ListItem Text="Oriental Studies" />
                    <asp:ListItem Text="Mathematics" />
                </asp:DropDownList>
            <br />
            <hr />

            <asp:Button Text="Register" runat="server" OnClick="OnRegisterStudentButtonClicked" />
        </div>

        <div runat="server" id="RegistrationInfo"></div>
    </div>

</asp:Content>
