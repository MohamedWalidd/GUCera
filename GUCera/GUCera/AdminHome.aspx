<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="GUCera.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="listAllCourses" runat="server" Text="View All Courses" OnClick="ListAllCourses" Width="332px" />
        </div>
        <asp:Button ID="listAllNonAcceptedCourses" runat="server" Text="View All Non Accepted Courses" OnClick="ListAllNonAccCourses" Width="332px" />
        <br />
        Accept Course:<br />
        Course ID:<br />
        <asp:TextBox ID="cid" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="accept" runat="server" Text="Accept" onClick="AcceptCourse"/>
        <br />
        <br />
        Create Promocode:<br />
        Code:<br />
        <asp:TextBox ID="code" runat="server"></asp:TextBox>
        <br />
        IssueDate:<br />
        <asp:TextBox ID="issuedate" runat="server"></asp:TextBox>
        <br />
        ExpiryDate:<br />
        <asp:TextBox ID="expiryDate" runat="server"></asp:TextBox>
        <br />
        Discount:<br />
        <asp:TextBox ID="Discount" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="createPromo" runat="server" Text="Create" OnClick="CreatePromo" Width="162px" />
        <br />
        <br />
        Issue Promocode:<br />
        Student ID:<br />
        <asp:TextBox ID="StudentID" runat="server"></asp:TextBox>
        <br />
        Promocode ID:<br />
        <asp:TextBox ID="PromoID" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="issuePromo" runat="server" Text="Issue Promocode" OnClick="IssuePromo" Width="332px" />
        <br />
        <br />
        <asp:Button ID="AddMob" runat="server" Text="Add Mobile Number" OnClick="AddMobile" />
        <br />
        <asp:Button ID="logout" runat="server" Text="Logout" OnClick="Logout" />
        <br />
    </form>
</body>
</html>
