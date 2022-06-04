<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUCera.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_username" runat="server" Text="ID:"></asp:Label>
            <asp:TextBox ID="uid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbl_password" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>    
            <br />
            <br />
            <asp:Button ID="loginBtn" runat="server" Text="Login" onclick="submit" Width="90px"/>
            <asp:Button ID="registerBtn" runat="server" Text="Register Here" onclick="register" Width="123px"/>
        </div>
    </form>
</body>
</html>
