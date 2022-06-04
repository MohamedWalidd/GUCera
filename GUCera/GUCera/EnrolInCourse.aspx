<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrolInCourse.aspx.cs" Inherits="GUCera.EnrolInCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="Instr_ID" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            Insert Instructor ID</div>
        <div>
            <asp:TextBox ID="C_ID" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            Insert Course ID</div>
        <asp:Button ID="enroll" runat="server" OnClick="Button1_Click" Text="Enroll" />
        <asp:Button ID="back" runat="server" OnClick="Back" Text="Back" />
    </form>
</body>
</html>
