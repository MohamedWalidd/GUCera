<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorPage.aspx.cs" Inherits="GUCera.InstructorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form_add_new_course" runat="server">
        <div>

            <asp:Label ID="lbl_add_new_course" runat="server" Text="Add a new course:"></asp:Label>

            <br />
            <asp:Label ID="lbl_course_name" runat="server" Text="Course Name:"></asp:Label>
            <asp:TextBox ID="txt_course_name" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_credit_hours" runat="server" Text="Course Credit Hours:"></asp:Label>
            <asp:TextBox ID="txt_credit_hours" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_price" runat="server" Text="Course Price:"></asp:Label>
            <asp:TextBox ID="txt_price" runat="server"></asp:TextBox>

            <br />
            <br />
            <asp:Button ID="btn_add_course" runat="server" Text="Add Course" OnClick="AddCourse"/>

            <br />
            <br />
            <asp:Label ID="lbl_define_new_assignment" runat="server" Text="Define New Assignment:"></asp:Label>
            <br />
            <asp:Label ID="lbl_cid" runat="server" Text="Course ID:"></asp:Label>
            <asp:TextBox ID="txt_cid" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_number" runat="server" Text="Number:"></asp:Label>
            <asp:TextBox ID="txt_number" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_type" runat="server" Text="Type:"></asp:Label>
            <asp:RadioButtonList ID="rbl_type" runat="server">
                <asp:ListItem Selected="True">Quiz</asp:ListItem>
                <asp:ListItem>Exam</asp:ListItem>
                <asp:ListItem>Project</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="lbl_full_grade" runat="server" Text="Full Grade:"></asp:Label>
            <asp:TextBox ID="txt_full_grade" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_weight" runat="server" Text="Weight:"></asp:Label>
            <asp:TextBox ID="txt_weight" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_deadline" runat="server" Text="Deadline:"></asp:Label>
            <asp:TextBox ID="txt_deadline_day" runat="server" Columns="2"></asp:TextBox>
            <asp:TextBox ID="txt_deadline_month" runat="server" Columns="2"></asp:TextBox>
            <asp:TextBox ID="txt_deadline_year" runat="server" Columns="4"></asp:TextBox>
            <asp:Label ID="lbl_date_format" runat="server" Text="dd MM yyyy" ForeColor="Gray"></asp:Label>
            <asp:TextBox ID="txt_deadline_hour" runat="server" Columns="2"></asp:TextBox>
            <asp:TextBox ID="txt_deadline_minute" runat="server" Columns="2"></asp:TextBox> 
            <asp:Label ID="lbl_time_format" runat="server" Text="hh:mm" ForeColor="Gray"></asp:Label>
            <asp:DropDownList ID="ddm_am_pm" runat="server">
                <asp:ListItem Selected="True">AM</asp:ListItem>
                <asp:ListItem>PM</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lbl_content" runat="server" Text="Content:"></asp:Label>
            <asp:TextBox ID="txt_content" runat="server"></asp:TextBox>

            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Add Assignment" OnClick="AddAssignment"/>



            <br />
            <br />
            <asp:Button ID="btn_view_ass" runat="server" Text="View Students' Assignments" OnClick ="ViewAssignments"></asp:Button>
            <asp:Button ID="btn_grade_ass" runat="server" Text="Grade Students' Assignments" OnClick ="GradeAssignments"></asp:Button>
            <asp:Button ID="btn_issue_cert" runat="server" Text="Issue Certificate" OnClick ="IssueCertificate"></asp:Button>
            <asp:Button ID="btn_view_fb" runat="server" Text="View Feedback" OnClick ="ViewFeedback"></asp:Button>
            <asp:Button ID="btn_add_mob" runat="server" Text="Add Mobile Number(s)" OnClick ="AddMobileNumber"></asp:Button>
            <asp:Button ID="btn_logout" runat="server" Text="Logout" OnClick ="Logout"></asp:Button>
        </div>
    </form>
</body>
</html>
