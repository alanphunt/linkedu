<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinkedU.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
        

    <div id="mastercontainer">




    <div id="titles">
        <h1>LINKED U</h1>
        <h2>Your path to <i>success.</i></h2>
    </div><!--#titles-->

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"/>

    <div id="formcontainer"> 
        
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">

      
      <ContentTemplate>
        <asp:MultiView ID="MultiView1" runat="server">

        <asp:View ID="View1" runat="server">
            <h3>Let's get started.</h3>       
            <br />
            <h3>I am a..</h3><br />
            <asp:LinkButton class="choose" ID="LinkButton1" runat="server" OnClick="SetStudentView">Student</asp:LinkButton>           
            <p>or</p>       
            <asp:LinkButton class="choose" ID="LinkButton2" runat="server" OnClick="SetUniversityView">University</asp:LinkButton>
        </asp:View>

        <asp:View ID="View2" runat="server">
            <h3>Do you need to..</h3>
            <br />
            <asp:LinkButton class="choose" ID="LinkButton3" runat="server" OnClick="StuLoginView">Sign In</asp:LinkButton>
            <p>or</p>
            <asp:LinkButton runat="server" class="choose" ID="LinkButton4" OnClick="StudentRegister">Register</asp:LinkButton>

            <asp:LinkButton ID="GoBackStu" class="GoBack" runat="server" OnClick="ViewOne">Go Back</asp:LinkButton>
        </asp:View>        
            
        <asp:View ID="View3" runat="server">
            <h3>Do you need to..</h3>
            <br />
            <asp:LinkButton class="choose" ID="LinkButton5" runat="server" OnClick="UniLoginView">Sign In</asp:LinkButton>
            <p>or</p>
            <asp:LinkButton class="choose" ID="LinkButton6" runat="server" OnClick="UniRegister">Register</asp:LinkButton>

            <asp:LinkButton ID="GoBackUni" class="GoBack" runat="server" OnClick="ViewOne">Go Back</asp:LinkButton>
        </asp:View>

        <asp:View ID="View4" runat="server">
            <h3>Welcome back!</h3>
            <br />
            <p>Username</p>
            <asp:TextBox ID="usernameStu" runat="server" placeholder="Username" />
            <br />
            <p>Password</p>
            <asp:TextBox ID="passwordStu" type="password" runat="server" placeholder="Password" />
            <br />
            <asp:LinkButton ID="LinkButton14" runat="server" OnClick="ForgotPWView">Forgot password?</asp:LinkButton>
            <br /><br />
            <asp:Button ID="submitlogin" runat="server" Text="Login" OnClick="LoginStu"/>
            <asp:Label runat="server" ID="invalidStuCreds" Text=""/>

            <asp:LinkButton ID="LinkButton7" class="GoBack" runat="server" OnClick="ViewOne">Go Back</asp:LinkButton>
        </asp:View>                      
            
        <asp:View ID="View10" runat="server">
            <h3>Welcome back!</h3>
            <br />
            <p>Username</p>
            <asp:TextBox ID="usernameUni" runat="server" placeholder="Username" />
            <br />
            <p>Password</p>
            <asp:TextBox ID="passwordUni" type="password" runat="server" placeholder="Password" />
            <br />
            <asp:LinkButton ID="LinkButton15" runat="server" OnClick="ForgotPWView">Forgot password?</asp:LinkButton>
            <br /><br />
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="LoginUni"/>
            <asp:Label runat="server" ID="invalidUniCreds" Text=""/>

            <asp:LinkButton ID="LinkButton13" class="GoBack" runat="server" OnClick="ViewOne">Go Back</asp:LinkButton>
        </asp:View>                    
            
        <asp:View ID="View5" runat="server">
            <h3>Tell us about yourself</h3>
            <br />
            <p>Choose a username</p>
            <asp:TextBox ID="stuUsername" runat="server"></asp:TextBox>
            <p>Choose a password</p>
            <asp:TextBox ID="stuPassword" type="password" runat="server"></asp:TextBox>
            <p>Confirm password</p>
            <asp:TextBox ID="stuConfirmPassword" type="password" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="stuConfirmPassword" ControlToCompare="stuPassword" ErrorMessage="Passwords do not match"></asp:CompareValidator>
            <p>Email address</p>
            <asp:TextBox ID="stuEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="Next Page" OnClick="StudentRegister2" />

            <asp:LinkButton ID="LinkButton8" class="GoBack" runat="server" OnClick="ViewOne">Go Back</asp:LinkButton>
        </asp:View>

        <asp:View ID="View8" runat="server">
                <p>First name</p>
                <asp:TextBox ID="stuFirstName" runat="server"></asp:TextBox>
                <p>Last name</p>
                <asp:TextBox ID="stuLastName" runat="server"></asp:TextBox>             
                <p>Phone number</p>
                <asp:TextBox ID="stuNumber" runat="server"></asp:TextBox>               
                <p>Address</p>
                <asp:TextBox ID="stuAddress" runat="server"></asp:TextBox>
                <p>Bio</p>
                <asp:TextBox ID="stuBio" runat="server"></asp:TextBox>                
                <p>Profile picture</p>
                <asp:TextBox ID="stuPic" runat="server"></asp:TextBox>
                <br />
                <asp:Button runat="server" Text="Next Page" OnClick="StudentRegister3" />

                <asp:LinkButton ID="LinkButton11" class="GoBack" runat="server" OnClick="StudentRegister">Go Back</asp:LinkButton>
          </asp:View>

          <asp:View ID="View9" runat="server">
                <p>High school</p>
                <asp:TextBox ID="stuSchool" runat="server"></asp:TextBox>               
                <p>Graduation Year</p>
                <asp:TextBox ID="stuGradYear" runat="server"></asp:TextBox>                
                <p>GPA</p>
                <asp:TextBox ID="stuGPA" runat="server"></asp:TextBox>
                <p>Documents</p>
                <asp:TextBox ID="stuDocs" runat="server"></asp:TextBox><br />
                <span>Receive SMS alerts?</span>
                <asp:CheckBox ID="SMS" runat="server" Text="Yes"/>                                    
                <br />
                <asp:Label ID="choosecarrier" runat="server" Text="Choose your carrier"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem  runat="server" Value="T-Mobile">T-Mobile</asp:ListItem>
                    <asp:ListItem  runat="server" Value="Verizon">Verizon</asp:ListItem>
                    <asp:ListItem  runat="server" Value="AT&T">AT&T</asp:ListItem>
                    <asp:ListItem  runat="server" Value="Sprint">Sprint</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <span>Subscribe to emails?</span>
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Subscribe"/>
                <br />
                <asp:Button runat="server" Text="Register" OnClick="StudentProcessing"/>

                <asp:LinkButton ID="LinkButton12" class="GoBack" runat="server" OnClick="StudentRegister2">Go Back</asp:LinkButton>
           </asp:View>

           <asp:View ID="View6" runat="server">
                <h3>Tell us about yourself</h3> 
                <br />
                <p>Choose a username</p>
                <asp:TextBox ID="uniUser" runat="server"></asp:TextBox>
                <p>Choose a password</p>
                <asp:TextBox ID="uniPassword" type="password" runat="server"></asp:TextBox>
                <p>Confirm password</p>
                <asp:TextBox ID="uniConfirmPassword" type="password" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="uniConfirmPassword" ControlToCompare="uniPassword" ErrorMessage="Passwords do not match"></asp:CompareValidator>
                <p>Email address</p>
                <asp:TextBox ID="uniEmail" runat="server"></asp:TextBox>                                  
                <br />
                <asp:Button runat="server" Text="Next Page" OnClick="UniRegister2" />                           
               
                <asp:LinkButton ID="LinkButton9" class="GoBack" runat="server" OnClick="ViewOne">Go Back</asp:LinkButton>
          </asp:View>

          <asp:View ID="View7" runat="server">
                <p>School Name</p>
                <asp:TextBox ID="uniName" runat="server"></asp:TextBox>
                <p>Address</p>
                <asp:TextBox ID="uniAddress" runat="server"></asp:TextBox>
                <p>Bio</p>
                <asp:TextBox ID="uniBio" runat="server"></asp:TextBox>
                <p>Upload a picture</p>
                <asp:TextBox ID="uniPic" runat="server"></asp:TextBox>
                <p>Upload documents</p>
                <asp:TextBox ID="uniDocs" runat="server"></asp:TextBox>
                <br />
                <span>Upgrade to showcase?</span>
                <asp:CheckBox ID="upgrade" runat="server" Text="Upgrade"/>                                    
                <br />               
                <asp:Button runat="server" Text="Register" OnClick="UniversityProcessing" />

                <asp:LinkButton ID="LinkButton10" class="GoBack" runat="server" OnClick="UniRegister">Go Back</asp:LinkButton>
         </asp:View>

         <asp:View ID="View11" runat="server">
                <h4>Hello, <asp:Label ID="UNLabel" runat="server"></asp:Label></h4>
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="">Visit Your Profile</asp:HyperLink><br /><br />
                <asp:Button runat="server" Text="Logout" OnClick="Logout" />           
         </asp:View>
                        
        <asp:View ID="View12" runat="server">
                <p>Enter your email</p>
                <asp:TextBox ID="LostPW" runat="server" Placeholder="Email"></asp:TextBox>
                <asp:Button runat="server" Text="Retrieve" OnClick="ForgotPW" />
                <asp:Label runat="server" ID="status" Text="" />
            <asp:LinkButton ID="LinkButton17" class="GoBack" runat="server" OnClick="ViewOne">Go Back</asp:LinkButton>
        </asp:View>         
            

       </asp:MultiView>
      </ContentTemplate>
     </asp:UpdatePanel>
    </div><!--formcontainer-->



</div><!--#mastercontainer-->
    <div id="footer">
        <p>&copy; LinkedU 2019</p>
    </div>

      </form>
</body>
</html>
