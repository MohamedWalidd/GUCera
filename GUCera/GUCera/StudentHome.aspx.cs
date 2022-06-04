using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class StudentHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ViewProfile(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }
        protected void ViewCourses(object sender, EventArgs e)
        {
            Response.Redirect("Courses.aspx");
        }
        protected void EnrollCourse(object sender, EventArgs e)
        {
            Response.Redirect("EnrolInCourse.aspx");
        }
        protected void AddCard(object sender, EventArgs e)
        {
            Response.Redirect("AddCreditCard.aspx");

        }
        protected void ViewPromo(object sender, EventArgs e)
        {
            Response.Redirect("ViewPromoCode.aspx");

        }
        protected void ViewAssignments(object sender, EventArgs e)
        {
            Response.Redirect("AssignmentContent.aspx");

        }
        protected void SubmitAssignment(object sender, EventArgs e)
        {
            Response.Redirect("SubmitAssignment.aspx");

        }

        protected void ViewGrade(object sender, EventArgs e)
        {
            Response.Redirect("ViewAssignmentGrades.aspx");

        }

        protected void CourseFeedback(object sender, EventArgs e)
        {
            Response.Redirect("AddFeedback.aspx");

        }
        protected void ViewCertificates(object sender, EventArgs e)
        {
            Response.Redirect("ListCertificates.aspx");

        }
        protected void Logout(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void AddMobileNumbers(object sender, EventArgs e)
        {
            Response.Redirect("AddMobileNumbers.aspx");

        }

    }
}