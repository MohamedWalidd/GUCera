<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCertificates.aspx.cs" Inherits="GUCera.ListCertificates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Course ID:"></asp:Label>
            <br />
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="List Certificates" OnClick="List" />
            <asp:Button ID="back" runat="server" Text="Back" OnClick="Back" />
        </div>
    </form>
</body>
</html>
