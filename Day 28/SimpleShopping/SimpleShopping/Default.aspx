<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShopNow - Login/Register</title>
    <style>
        body { font-family: Arial; margin: 40px; background-color: #f5f5f5; }
        .container { width: 400px; margin: auto; background: white; padding: 20px; border-radius: 10px; box-shadow: 0 0 10px rgba(0,0,0,0.1); }
        h2 { color: #4CAF50; text-align: center; }
        .tab { overflow: hidden; border: 1px solid #ccc; background-color: #f1f1f1; border-radius: 5px; }
        .tab button { background-color: inherit; float: left; border: none; outline: none; cursor: pointer; padding: 14px 16px; transition: 0.3s; width: 50%; }
        .tab button:hover { background-color: #ddd; }
        .tab button.active { background-color: #4CAF50; color: white; }
        .tabcontent { display: none; padding: 20px; border: 1px solid #ccc; border-top: none; border-radius: 0 0 5px 5px; }
        .form-group { margin-bottom: 15px; }
        label { display: block; margin-bottom: 5px; font-weight: bold; }
        input[type="text"], input[type="password"], input[type="email"] { width: 100%; padding: 8px; box-sizing: border-box; border: 1px solid #ccc; border-radius: 4px; }
        .btn { background-color: #4CAF50; color: white; padding: 10px 15px; border: none; cursor: pointer; width: 100%; border-radius: 4px; font-size: 16px; }
        .message { color: red; margin-top: 10px; text-align: center; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Welcome to ShopNow</h2>
            
            <div class="tab">
                <button type="button" id="loginTab" class="tablinks active" onclick="openTab('login')">Login</button>
                <button type="button" id="registerTab" class="tablinks" onclick="openTab('register')">Register</button>
            </div>
            
            <div id="login" class="tabcontent" style="display:block;">
                <h3>Login to Your Account</h3>
                <div class="form-group">
                    <label for="loginUsername">Username:</label>
                    <asp:TextBox ID="loginUsername" runat="server" placeholder="Enter your username"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="loginPassword">Password:</label>
                    <asp:TextBox ID="loginPassword" runat="server" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
                </div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
                <asp:Label ID="lblLoginMessage" runat="server" CssClass="message"></asp:Label>
            </div>
            
            <div id="register" class="tabcontent">
                <h3>Create New Account</h3>
                <div class="form-group">
                    <label for="regUsername">Username:</label>
                    <asp:TextBox ID="regUsername" runat="server" placeholder="Choose a username"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="regPassword">Password:</label>
                    <asp:TextBox ID="regPassword" runat="server" TextMode="Password" placeholder="Create a password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="regEmail">Email:</label>
                    <asp:TextBox ID="regEmail" runat="server" TextMode="Email" placeholder="Enter your email"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="regFullName">Full Name:</label>
                    <asp:TextBox ID="regFullName" runat="server" placeholder="Enter your full name"></asp:TextBox>
                </div>
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />
                <asp:Label ID="lblRegisterMessage" runat="server" CssClass="message"></asp:Label>
            </div>
        </div>

        <script>
            function openTab(tabName) {
                var i, tabcontent, tablinks;
                tabcontent = document.getElementsByClassName("tabcontent");
                for (i = 0; i < tabcontent.length; i++) {
                    tabcontent[i].style.display = "none";
                }
                tablinks = document.getElementsByClassName("tablinks");
                for (i = 0; i < tablinks.length; i++) {
                    tablinks[i].className = tablinks[i].className.replace(" active", "");
                }
                document.getElementById(tabName).style.display = "block";
                event.currentTarget.className += " active";
            }
        </script>
    </form>
</body>
</html>