<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Universities.aspx.cs" Inherits="LinkedU.Universities" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Find the perfect University.</title>

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

               <h4>Select a Criteria to search by:</h4> <br />
            <asp:DropDownList  ID="searchoptions" runat="server">
                <asp:ListItem  Text="University Search Criteria" Value="0"></asp:ListItem>
                <asp:ListItem  Text="University Name" Value="1"></asp:ListItem>
                <asp:ListItem  Text="Location" Value="2"></asp:ListItem>
            </asp:DropDownList><br /><br />
            <h4>Input Text to Search: </h4><br />
        <asp:TextBox ID="SearchText" runat="server" placeholder="Show All"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="UniSearch" ></asp:Button><br /><br />
            <asp:Literal ID="results" runat="server" /> 

    </div>


        <div id="footer">
        <p>&copy; LinkedU 2019</p>
    </div>
    </form>
</body>
</html>
