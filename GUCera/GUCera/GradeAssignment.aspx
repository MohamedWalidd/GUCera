<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeAssignment.aspx.cs" Inherits="GUCera.GradeAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_grade_assignment" runat="server" Text="Grade Assignment:"></asp:Label>
            <br />
            <asp:Label ID="lbl_sid" runat="server" Text="student id:"></asp:Label>
            <asp:TextBox ID="txt_sid" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_cid" runat="server" Text="Course id:"></asp:Label>
            <asp:TextBox ID="txt_cid" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_anumber" runat="server" Text="Assignment Number"></asp:Label>
            <asp:TextBox ID="txt_anumber" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_atype" runat="server" Text="Assignment Type"></asp:Label>

            <asp:RadioButtonList ID="rbl_atype" runat="server">
                <asp:ListItem Selected="True">Quiz</asp:ListItem>
                <asp:ListItem>Exam</asp:ListItem>
                <asp:ListItem>Project</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="lbl_grade" runat="server" Text="Grade:"></asp:Label>
            <asp:TextBox ID="txt_grade" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btn_grade" runat="server" Text="Grade" OnClick="Grade" />
            <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="Back" />
            <br />
        </div>
    </form>
</body>
</html>
