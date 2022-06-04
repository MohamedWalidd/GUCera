<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAssignmentGrades.aspx.cs" Inherits="GUCera.ViewAssignmentGrade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Assignment Number:"></asp:Label>
            <br />
            <asp:TextBox ID="AssNum" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Assignment Type:"></asp:Label>
            <br />
            <asp:RadioButtonList ID="AssType" runat="server">
                <asp:ListItem Selected="True" Value="Quiz"></asp:ListItem>
                <asp:ListItem Value="Exam"></asp:ListItem>
                <asp:ListItem Value="Project"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Course ID:"></asp:Label>
            <br />
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ViewAssign" runat="server" Text="View" OnClick="submit"/>
            <asp:Button ID="back" runat="server" Text="Back" OnClick="Back"/>
        </div>
    </form>
</body>
</html>
