<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignmentContent.aspx.cs" Inherits="GUCera.AssignmentContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_c_id" runat="server" Text="Course ID:"></asp:Label>
        </div>
        <asp:TextBox ID="cid" runat="server" Width="114px"></asp:TextBox>
        <br />
        <asp:Button ID="AssignContent" runat="server" Text="ViewAssignmentContent" OnClick="submit" />
        <asp:Button ID="back" runat="server" Text="Back" OnClick="Back" />
        <br />
    </form>
</body>
</html>
