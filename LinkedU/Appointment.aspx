<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="LinkedU.Appointment" %>

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

                            <h4> Schedule Appointment</h4>
                            <p><asp:Label ID="message" runat="server" Visible="false"></asp:Label></p>
                            
                            
Last name&nbsp;<asp:RequiredFieldValidator ID="lastNameValidate" runat="server" ControlToValidate="lastName" Text="**Required field**" /><br />

<asp:TextBox ID="lastName" runat="server" Width="265" /><br />

First name&nbsp;<asp:RequiredFieldValidator ID="firstNameValidate" runat="server" ControlToValidate="firstName" Text="**Required field**" /><br />

<asp:TextBox ID="firstName" runat="server" Width="265" /><br />

Telephone&nbsp;<asp:RequiredFieldValidator ID="telephoneValidate" runat="server" ControlToValidate="telephone" Text="**Required field**" /><br />

<asp:TextBox ID="telephone" runat="server" Width="265" /><br />

E-mail&nbsp;<asp:RequiredFieldValidator ID="emailValidate" runat="server" ControlToValidate="email" Text="**Required field**" /><br />

<asp:TextBox ID="email" runat="server" Width="265" /><br />

Confirm e-mail&nbsp;<asp:RequiredFieldValidator ID="confirmEmailValidate" runat="server" ControlToValidate="confirmEmail" Text="**Required field**" /><br />

<asp:TextBox ID="confirmEmail" runat="server" Width="265" /><br />

<asp:CompareValidator ID="compareEmail" runat="server" ControlToValidate="confirmEmail" Operator="Equal" Display="Dynamic" ControlToCompare="email">**You did not enter the same value in the e-mail and e-mail confirmation fields**</asp:CompareValidator><br />
             
                                Preferred date&nbsp;<asp:CompareValidator ID="compareDate" runat="server" ControlToValidate="date" Operator="DataTypeCheck" Display="Dynamic" Type="Date">**You did not enter a valid date **</asp:CompareValidator>
                                <br />
                                <asp:TextBox ID="date" runat="server" Width="265" />
                                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="dateSelected" EnableViewState="False" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="120px" Width="185px">
                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                </asp:Calendar>
                               
                           
                            <p> Age (18 or older)</p>
                                <asp:TextBox ID="age" runat="server" Width="40" /><br />
                                <asp:Button ID="makeReservation" runat="server" Text="Submit" OnClick="ForgotPW"/>
                                
                            
                                <asp:CompareValidator ID="ageCompare" runat="server" ControlToValidate="age" Operator="GreaterThanEqual" Display="Dynamic" ValueToCompare="18">**You must be 18 or older**
                                </asp:CompareValidator><br />
                            
        <asp:Label ID="status" runat="server" Text=""></asp:Label>

        </div>



    </form>
</body>
</html>
