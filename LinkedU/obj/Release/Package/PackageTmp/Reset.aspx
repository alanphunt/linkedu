<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reset.aspx.cs" Inherits="LinkedU.Reset" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Find the perfect student.</title>

        <meta charset="UTF-8" />
        <meta name="description" content="Choose your destination, we'll help you get there." />
        <meta name="keywords" content="Education, social media" />
        <meta name="author" content="Alan, Andrew, Aldo" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link href="styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
                    <div id="header">
        <ul>
            <li><a href="Default.aspx">Home</a></li>
            <li><a href="Students.aspx">Students</a></li>
            <li><a href="Universities.aspx">Universities</a></li>
            <li><p class="navlogo">linked u</p> </li>
            <li><a href="Showcase.aspx">Showcase</a></li>
            <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="">Your Profile</asp:HyperLink></li>
            <li><a href="About.aspx">About Us</a></li>
        </ul>
    </div>
            <div id="content">

                <p>Reset your password</p>
                <asp:TextBox type="password" ID="pwreset" runat="server" Placeholder="New Password"></asp:TextBox>
                <p>Enter your password again</p>
                <asp:TextBox type="password" ID="pwresetmatch" runat="server" Placeholder="Re-enter Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="pwresetmatch" ControlToCompare="pwreset" ErrorMessage="Passwords do not match"/>

                <p>Are you a student or university?</p>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem ID="stu" Value="student" runat="server">Student</asp:ListItem>
                    <asp:ListItem  ID="uni" Value="university" runat="server">University</asp:ListItem>
                <//asp:RadioButtonList><br />

                <asp:Button ID="Button1" runat="server" Text="Reset" /><br />
                <p>You will be re-directed to the homepage upon successful reset.</p>
        </div>
    </form>
</body>
</html>
