<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMobileNumbers.aspx.cs" Inherits="GUCera.AddMobileNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Add Mobile Number<br />
            <asp:TextBox ID="mobilenumber" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="addmobilenumber" runat="server" Text="Add" OnClick="AddMobileNumber" />
            <asp:Button ID="back" runat="server" Text="Back" OnClick="Back" />
        </div>
    </form>
</body>
</html>
