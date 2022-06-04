<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registeration.aspx.cs" Inherits="GUCera.Registeration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please register<br />
            First Name:
            <asp:TextBox ID="firstname" runat="server"></asp:TextBox>
            <br />
            Last Name:&nbsp;
            <asp:TextBox ID="lastname" runat="server"></asp:TextBox>
            <br />
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="email" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            Password:&nbsp;&nbsp;
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            Gender:<asp:RadioButtonList ID="gender" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem Value="0" Selected="True">Male</asp:ListItem>
                <asp:ListItem Value="1">Female</asp:ListItem>
            </asp:RadioButtonList>
            Address:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="address" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            Register as a<br />
            <asp:RadioButtonList ID="registeras" runat="server">
                <asp:ListItem Value="0" Selected="True">Student</asp:ListItem>
                <asp:ListItem Value="1">Instructor</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Button ID="submit" runat="server" onclick="Submit" Text="Submit" />
            <br />
            <asp:Button ID="login" runat="server" onclick="Login" Text="Back to Login" />
        </div>
    </form>
</body>
</html>
