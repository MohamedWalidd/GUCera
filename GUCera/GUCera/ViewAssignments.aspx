<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAssignments.aspx.cs" Inherits="GUCera.ViewAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_course_id" runat="server" Text="Course ID:"></asp:Label>
            <asp:TextBox ID="txt_course_id" runat="server"></asp:TextBox>
            <asp:Button ID="btn_show" runat="server" Text="show" OnClick="Show" />
            <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="Back" />
        </div>
    </form>
</body>
</html>
