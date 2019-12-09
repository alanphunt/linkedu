<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="LinkedU.Students" %>

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
     <script defer>
        function compare() {

            var boxes = document.getElementsByClassName("cb");
            var count = 0;
            var selected1;
            var selected2;
            var obj1 = document.getElementsByTagName("tr");

            for (var i = 0; i < boxes.length; i++){
                if (boxes[i].checked && count == 0) {
                    count++;
                    selected1 = obj1[i+1];
                } else if (boxes[i].checked && count == 1) {
                    count++;
                    selected2 = obj1[i+1];
                }
            }

            if (count > 2) {
                alert("Please only select 2 students to compare.");
                for (var box in boxes) {
                    box.checked = false;
                }
            } else {
                document.getElementById("comparecontainer").style.display = "flex";
                var stu1 = document.getElementById("stu1");
                var stu2 = document.getElementById("stu2");

                stu1.appendChild(selected1);
                stu2.appendChild(selected2);



            }
        }
    </script>
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

            <h4>Select a Criteria to search by:</h4><br />
            <asp:DropDownList  ID="studentdropdownlist" runat="server">
                <asp:ListItem  Text="Student Search Criteria" Value="0"></asp:ListItem>
                <asp:ListItem  Text="Student First Name" Value="1"></asp:ListItem>
                <asp:ListItem  Text="High School" Value="2"></asp:ListItem>
                <asp:ListItem  Text="GPA" Value="3"></asp:ListItem>
                <asp:ListItem  Text="Gratuation Date" Value="4"></asp:ListItem>
            </asp:DropDownList><br />
        <br />
           <h4>Input Text to Search: </h4> <br />
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Leave Blank to Show All"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="StuSearch" ></asp:Button>
        <br /><br />



                                <asp:Literal ID="result" runat="server" />

<br /><br />
        <button type="button" onclick="compare()">Compare!</button>
    </div>
        
        <div id="comparecontainer" style="display: none;">
            <div id="stu1">

            </div>
            <div id="stu2">

            </div>
        </div>
        <div id="footer">
        <p>&copy; LinkedU 2019</p>
    </div>
    </form>
   
</body>
</html>
