using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GUCera
{
    public partial class InstructorPage : System.Web.UI.Page
    {
        static string connStr;
        static SqlConnection conn; 

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
                conn = new SqlConnection(connStr);
            }catch(Exception exc)
            {
                Response.Write("<p style=\"color: red;\">Internal server error, please try again.</p>");
            }
        }

        protected void AddCourse(object sender, EventArgs e)
        {
            if (txt_course_name.Text.Equals("") || txt_credit_hours.Text.Equals("") || txt_price.Text.Equals(""))
            {
                Response.Write("<p style=\"color: red;\">All fields are required. Make sure all boxes are filled.</p>");
            }
            else
            {
                string course_name = txt_course_name.Text;
                Boolean flag = false;
                int credit_hours = -1;
                try
                {
                    credit_hours = Int16.Parse(txt_credit_hours.Text);
                }
                catch (Exception exc)
                {
                    flag = true;
                }

                if (flag)
                {
                    Response.Write("<p style=\"color: red;\">Invalid credit hours.</p>");
                }
                else
                {
                    double course_price = -1;
                    flag = false;
                    try
                    {
                        course_price = double.Parse(txt_price.Text);
                    }catch(Exception exc)
                    {
                        flag = true;
                    }

                    if (flag)
                    {
                        Response.Write("<p style=\"color: red;\">Invalid course price.</p>");
                    }
                    else
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("InstAddCourse", conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add(new SqlParameter("@creditHours", credit_hours));
                            cmd.Parameters.Add(new SqlParameter("@name", course_name));
                            cmd.Parameters.Add(new SqlParameter("@price", course_price));
                            cmd.Parameters.Add(new SqlParameter("@instructorId", Session["user"]));

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            Response.Write("<p style=\"color: green;\">Course added successfully</p>");
                        }catch(Exception exc)
                        {
                            Response.Write("<p style=\"color: red;\">Course name already exists. Please try again.</p>");
                        }
                    }
                }
            }
        }

        protected void AddAssignment(object sender, EventArgs e)
        {
            if (txt_cid.Text.Equals("") ||
                txt_number.Text.Equals("") ||
                txt_full_grade.Text.Equals("") ||
                txt_weight.Text.Equals("") ||
                txt_deadline_day.Text.Equals("") ||
                txt_deadline_month.Text.Equals("") ||
                txt_deadline_year.Text.Equals("") ||
                txt_deadline_hour.Text.Equals("") ||
                txt_deadline_minute.Text.Equals("") ||
                txt_content.Text.Equals(""))
            {

                Response.Write("<p style=\"color: red;\">All fields are required. Make sure all boxes are filled</p>");
            }
            else
            {
                Boolean flag = false;
                int cid = -1;
                try
                {
                    cid = Int16.Parse(txt_cid.Text);
                }catch(Exception exc)
                {
                    flag = true;
                }

                if (flag)
                {
                    Response.Write("<p style=\"color: red;\">Invalid course id.</p>");
                }
                else
                {
                    flag = false;
                    int number = -1;
                    try
                    {
                        number = Int16.Parse(txt_number.Text);
                    }catch(Exception exc)
                    {
                        flag = true;
                    }

                    if (flag)
                    {
                        Response.Write("<p style=\"color: red;\">Invalid number.</p>");
                    }
                    else
                    {
                        string type = rbl_type.SelectedItem.Value;

                        flag = false;
                        int fullGrade = -1;
                        try
                        {
                            fullGrade = Int16.Parse(txt_full_grade.Text);
                        }catch(Exception exc)
                        {
                            flag = true;
                        }

                        if (flag)
                        {
                            Response.Write("<p style=\"color: red;\">Invalid full grade.</p>");
                        }
                        else
                        {
                            flag = false;
                            double weight = -1;
                            try
                            {
                                weight = double.Parse(txt_weight.Text);
                            }catch(Exception exc)
                            {
                                flag = true;
                            }

                            if (flag)
                            {
                                Response.Write("<p style=\"color: red;\">Invalid weight.</p>");
                            }
                            else
                            {

                                string deadline =
                                    txt_deadline_day.Text + "/" +
                                    txt_deadline_month.Text + "/" +
                                    txt_deadline_year.Text + " " +
                                    txt_deadline_hour.Text + ":" +
                                    txt_deadline_minute.Text +
                                    ":00 "+
                                    ddm_am_pm.SelectedItem.Value;
                                string content = txt_content.Text;

                                try
                                {
                                    
                                    SqlCommand cmd = new SqlCommand("SELECT cid, number, type FROM Assignment WHERE cid=\'"+cid+"\' AND type=\'"+type+"\' AND number=\'"+number+"\'", conn);
                                    flag = false;
                                    conn.Open();
                                    SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                                    if (sdr.Read())
                                    {
                                        flag = true;  
                                    }
                                    conn.Close();

                                    if (flag)
                                    {
                                        Response.Write("<p style=\"color: red;\">Assignment already defined for course.</p>");
                                    }
                                    else
                                    {

                                        cmd = new SqlCommand("SELECT cid, insid FROM InstructorTeachCourse WHERE cid=\'" + cid + "\' AND insid=\'" + Session["user"] + "\'", conn);

                                        conn.Open();
                                        sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                                        flag = false;
                                        if (sdr.Read())
                                        {
                                            flag = true;
                                        }
                                        conn.Close();

                                        if (!flag)
                                        {
                                            Response.Write("<p style=\"color: red\">Instructor doesn\'t teach course OR course doesn\'t exist</p>");
                                        }
                                        else
                                        {

                                            cmd = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
                                            cmd.CommandType = CommandType.StoredProcedure;

                                            cmd.Parameters.Add(new SqlParameter("@instId", Session["user"]));
                                            cmd.Parameters.Add(new SqlParameter("@cid", cid));
                                            cmd.Parameters.Add(new SqlParameter("@number", number));
                                            cmd.Parameters.Add(new SqlParameter("@type", type));
                                            cmd.Parameters.Add(new SqlParameter("@fullGrade", fullGrade));
                                            cmd.Parameters.Add(new SqlParameter("@weight", weight));
                                            SqlParameter deadline_param = new SqlParameter("@deadline", SqlDbType.DateTime);
                                            flag = false;
                                            try
                                            {
                                                deadline_param.Value = DateTime.Parse(deadline);
                                            }
                                            catch (Exception exc)
                                            {
                                                flag = true;
                                            }

                                            if (flag)
                                            {
                                                Response.Write("<p style=\"color: red;\">Invalid date format.</p>");
                                            }
                                            else
                                            {
                                                cmd.Parameters.Add(deadline_param);
                                                cmd.Parameters.Add(new SqlParameter("@content", content));

                                                conn.Open();
                                                cmd.ExecuteNonQuery();
                                                conn.Close();

                                                Response.Write("<p style=\"color: green;\">Assignment added successfully</p>");
                                            }
                                        }
                                    }
                                }catch(Exception exc)
                                {
                                    Response.Write("<p style=\"color: red;\">Internal server error. Please try again.</p>");
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void ViewAssignments(object sender, EventArgs e)
        {
            Response.Redirect("ViewAssignments.aspx");
        }

        protected void GradeAssignments(object sender, EventArgs e)
        {
            Response.Redirect("GradeAssignment.aspx");
        }

        protected void IssueCertificate(object sender, EventArgs e)
        {
            Response.Redirect("IssueCertificate.aspx");
        }
        protected void ViewFeedback(object sender, EventArgs e)
        {
            Response.Redirect("ViewFeedback.aspx");
        }

        protected void AddMobileNumber(object sender, EventArgs e)
        {
            Response.Redirect("AddMobileNumbers.aspx");
        }
        
        protected void Logout(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}