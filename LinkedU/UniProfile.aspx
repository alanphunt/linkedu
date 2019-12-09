<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UniProfile.aspx.cs" Inherits="LinkedU.UniProfile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>


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
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
         <asp:Image ID="UserPic" class="profilepic" alt="user pic" runat="server" ImageUrl="~/images/user.png" />
                <div id="upload" runat="server">
<p>Upload Picture</p>            
                <br />
            <br />
                 <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" ThrobberID="Image1" OnClientUploadComplete="fileuploaded" OnUploadedComplete="AsyncFileUpload1_UploadedComplete"/>
            <br />
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/uploading.gif" />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
                    </div>
                <br />
              <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="Logout" />

                </div>


            <div id="infodiv">
                <h4 id="welcome"><asp:Label runat="server" ID="h4" Text=""/></h4>
                <br />
                <asp:Label ID="Name" runat="server" Text="" /><br />
                <asp:Label ID="Email" runat="server" Text="" /><br />
                <asp:Label ID="Address" runat="server" Text="" /><br />
                <asp:Label ID="bio" runat="server" Text="" /><br />

                
                <div runat="server" id="unsubscribe">
                   <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                 <asp:Button ID="Button2" runat="server" OnClick="Unsubscribe" Text="" />
                </div>


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

    </form>
            <script type="text/javascript">
		function fileuploaded() {
		    alert("File Uploaded Successfully ");
            document.getElementById("Label3").innerHTML = "File Uploaded Completed ";
		}
	</script>

</body>
</html>
