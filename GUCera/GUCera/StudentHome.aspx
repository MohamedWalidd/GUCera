<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="GUCera.StudentHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="btn_view_profile" runat="server" Text="View My Profile" OnClick="ViewProfile" />
            <br />
            <asp:Button ID="btn_all_courses" runat="server" Text="View All Courses" OnClick="ViewCourses" />
            <br />
            <asp:Button ID="btn_enroll" runat="server" Text="Enroll In Course" OnClick="EnrollCourse" />
            <br />
            <asp:Button ID="btn_add_card" runat="server" Text="Add Credit Card" OnClick="AddCard" />
            <br />
            <asp:Button ID="btn_view_promo" runat="server" Text="View All PromoCodes" OnClick="ViewPromo" />
            <br />
            <asp:Button ID="btn_view_assignments" runat="server" Text="View All Assignments" OnClick="ViewAssignments" />
            <br />
            <asp:Button ID="btn_view_grades" runat="server" Text="View Grades" OnClick="ViewGrade" Width="124px" />
            <br />
            <asp:Button ID="btn_submit_assignment" runat="server" Text="Submit Assignments" OnClick="SubmitAssignment" />
            <br />
            <asp:Button ID="btn_feedback_course" runat="server" Text="Add Course Feedback" OnClick="CourseFeedback" />
            <br />
            <asp:Button ID="btn_certificates" runat="server" Text="View All Certificates" OnClick="ViewCertificates" />
            <br />
            <asp:Button ID="btn_add_mobile" runat="server" Text="Add mobile number(s)" OnClick="AddMobileNumbers" />
            <br />
            <asp:Button ID="btn_logout" runat="server" Text="Logout" OnClick="Logout" />

        </div>
    </form>
</body>
</html>
