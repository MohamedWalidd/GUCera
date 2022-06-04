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
    public partial class GradeAssignment : System.Web.UI.Page
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
                Response.Write("<p style=\"color: red\">Internal server error. Please try again.</p>");
            }
        }

        protected void Grade(Object sender, EventArgs e)
        {
            if (txt_sid.Text.Equals("") || txt_cid.Text.Equals("") || txt_anumber.Text.Equals("") || txt_grade.Text.Equals(""))
            {
                Response.Write("<p style=\"color: red\">All fields are required. Make sure all boxes are filled</p>");
            }
            else
            {
                int sid = -1;
                Boolean flag = false;
                try
                {
                    sid = Int16.Parse(txt_sid.Text);
                }
                catch (Exception exc)
                {
                    flag = true;
                }

                if (flag)
                {
                    Response.Write("<p style =\"color: red\">Invalid student id</p>");
                }
                else
                {
                    int cid = -1;
                    flag = false;

                    try
                    {
                        cid = Int16.Parse(txt_cid.Text);
                    }catch(Exception exc)
                    {
                        flag = true;
                    }
                    if (flag)
                    {
                        Response.Write("<p style =\"color: red\">Invalid course id</p>");
                    }
                    else
                    {

                        flag = false;
                        string anumber = "";
                        try
                        {
                            anumber = Int16.Parse(txt_anumber.Text).ToString();
                        }
                        catch (Exception exc)
                        {
                            flag = true;
                        }

                        if (flag)
                        {
                            Response.Write("<p style=\"color: red\">Invalid assignment number</p>");
                        }
                        else
                        {
                            string type = rbl_atype.SelectedItem.Text;
                            flag = false;
                            string grade = "";
                            try
                            {
                                grade = double.Parse(txt_grade.Text).ToString();
                            }
                            catch (Exception exc)
                            {
                                flag = true;
                            }

                            if (flag)
                            {
                                Response.Write("<p style=\"color: red\">Invalid grade</p>");
                            }
                            else
                            {
                                try
                                {

                                    SqlCommand cmd = new SqlCommand("select * from StudentTakeAssignment S inner join Course C on C.id = S.cid where cid = \'" + cid + "\' and assignmentNumber = \'" + anumber + "\' and sid = \'" + sid + "\' and instructorId = \'" + Session["user"] + "\' and assignmenttype = \'" + type + "\'", conn);

                                    conn.Open();
                                    SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                                    flag = false;
                                    if (sdr.Read())
                                    {
                                        flag = true;
                                    }
                                    conn.Close();

                                    if (!flag)
                                    {
                                        Response.Write("<p style=\"color: red\">Student doesn't take this assignment</p>");
                                    }
                                    else
                                    {
                                        cmd = new SqlCommand("InstructorgradeAssignmentOfAStudent", conn);
                                        cmd.CommandType = CommandType.StoredProcedure;

                                        cmd.Parameters.Add(new SqlParameter("@instrId", Session["user"]));
                                        cmd.Parameters.Add(new SqlParameter("@sid", sid));
                                        cmd.Parameters.Add(new SqlParameter("@cid", cid));
                                        cmd.Parameters.Add(new SqlParameter("@assignmentNumber", anumber));
                                        cmd.Parameters.Add(new SqlParameter("@type", type));
                                        cmd.Parameters.Add(new SqlParameter("@grade", grade));

                                        conn.Open();
                                        cmd.ExecuteNonQuery();
                                        conn.Close();

                                        Response.Write("<p style=\"color: green\">Assignment graded!</p>");
                                    }
                                }
                                catch (Exception exc)
                                {
                                    Response.Write(exc);
                                    Response.Write("<p style=\"color: red\">Internal server error. Please try again</p>");
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("InstructorPage.aspx");
        }
    }
}