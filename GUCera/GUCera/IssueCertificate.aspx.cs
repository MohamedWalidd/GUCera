using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class IssueCertificate : System.Web.UI.Page
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
                Response.Write("<p style=\"color: red\">Internal server error</p>");
            }

        }

        protected void Issue(object sender, EventArgs e)
        {

            int cid = -1;
            Boolean flag = false;
            try
            {
                cid = Int16.Parse(txt_cid.Text);
            }catch(Exception exc)
            {
                flag = true;
            }

            if (flag)
            {
                Response.Write("<p style=\"color: red\">Invalid course id</p>");
            }
            else
            {
                int sid = -1;
                flag = false;
                try
                {
                    sid = Int16.Parse(txt_sid.Text);
                }catch(Exception exc)
                {
                    flag = true;
                }

                if (flag)
                {
                    Response.Write("<p style=\"color: red\">Invalid student id.</p>");
                }
                else
                {
                    string deadline =
                        txt_issue_day.Text + "/" +
                        txt_issue_month.Text + "/" +
                        txt_issue_year.Text + " " +
                        txt_issue_hour.Text + ":" +
                        txt_issue_minute.Text +
                        ":00 "+
                        ddm_pm_am.SelectedItem.Value;

                    SqlCommand cmd = new SqlCommand("select * from StudentTakeCourse where sid=\'"+sid+"\' and grade >2.0 and cid=\'"+cid+"\'", conn);
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
                        Response.Write("<p style=\"color: red\">Cannot issue certificate</p>");
                        conn.Close();
                    }
                    else
                    {

                        cmd = new SqlCommand("InstructorIssueCertificateToStudent", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@cid", cid));
                        cmd.Parameters.Add(new SqlParameter("@sid", sid));
                        cmd.Parameters.Add(new SqlParameter("@insId", Session["user"]));
                        SqlParameter issue_param = new SqlParameter("@issueDate", SqlDbType.DateTime);
                        flag = false;
                        try
                        {
                            issue_param.Value = DateTime.Parse(deadline);
                        }catch(Exception exc)
                        {
                            flag = true;
                        }

                        if (flag)
                        {
                            Response.Write("<p style=\"color: red\">Invalid date format</p>");
                        }
                        else
                        {
                            cmd.Parameters.Add(issue_param);

                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();

                                Response.Write("<p style=\"color: green\">Certificate added successfully</p>");
                            }catch(Exception exc)
                            {
                                Response.Write("<p style=\"color: red\">Student already certified");
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