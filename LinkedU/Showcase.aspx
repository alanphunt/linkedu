<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Showcase.aspx.cs" Inherits="LinkedU.Blog" %>

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
   <div id="profile">
            <div id="picdiv">
                <h4>This week's featured school!</h4>
         <asp:Image ID="UserPic" class="profilepic" alt="user pic" runat="server" ImageUrl="~/images/user.png" />
                </div>


            <div id="infodiv">
                <h4 id="welcome"><asp:Label runat="server" ID="h4" Text=""/></h4>
                <br />
                <asp:Label ID="Name" runat="server" Text="" /><br />
                <asp:Label ID="Email" runat="server" Text="" /><br />
                <asp:Label ID="Address" runat="server" Text="" /><br />
                <asp:Label ID="bio" runat="server" Text="" /><br />


        <asp:Panel ID="info" runat="server">
            
    <h4>Request more information.</h4><br />
                    <asp:Label ID="Label1" runat="server" Text="Enter Email:"/>
                     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter Valid Email Address" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox2"  runat="server" ErrorMessage="Enter an email."></asp:RequiredFieldValidator>

                <p>Select Topic of Interest (Check all that apply)</p>

                    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        <asp:ListItem>Admissions</asp:ListItem>
                        <asp:ListItem>Majors/Minors</asp:ListItem>
                        <asp:ListItem>Housing</asp:ListItem>
                        <asp:ListItem>Financial Aid</asp:ListItem>
                    </asp:CheckBoxList>

                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
     
                    <asp:Label ID="Label2" runat="server"></asp:Label>
            
</asp:Panel><br /><br />
                <h4><a href="Appointment.aspx" target="_blank">Click here to schedule an appointment!</a></h4>
                       <br />
                <h4>
                    <asp:HyperLink ID="HyperLink2" NavigateUrl="" runat="server">Apply directly to this school!</asp:HyperLink>
                </h4>
            </div>



            </div>
        </div>

        <div id="footer">
        <p>&copy; LinkedU 2019</p>
    </div>
    </form>
</body>
</html>
