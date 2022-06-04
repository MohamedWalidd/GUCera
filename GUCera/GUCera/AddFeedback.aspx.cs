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
    public partial class AddFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }

        protected void Submit(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);

                string Comment = comment.Text;
                int c_id = -1;
                Boolean flag = false;
                if (c_id.Equals("") || Comment.Equals(""))
                {
                    Response.Write("Make sure all boxes are filled.");
                }
                else
                {
                    try
                    {
                        c_id = Int16.Parse(cid.Text);
                    }
                    catch (Exception exc)
                    {
                        flag = true;
                    }
                    if (flag)
                    {
                        Response.Write("Invalid course ID");
                    }
                    else
                    {

                        SqlCommand cmd = new SqlCommand("Select * FROM StudentTakeCourse WHERE sid=\'"+Session["user"]+"\' AND cid=\'"+c_id+"\'", conn);
                        cmd.CommandType = CommandType.Text;

                        conn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        if (rdr.Read())
                        {
                            flag = true;
                        }
                        conn.Close();
                        if (!flag)
                        {
                            Response.Write("Student not enrolled in course");
                        }
                        else
                        {

                            cmd = new SqlCommand("addFeedback", conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add(new SqlParameter("@sid", Session["user"]));
                            cmd.Parameters.Add(new SqlParameter("@comment", Comment));
                            cmd.Parameters.Add(new SqlParameter("@cid", c_id));

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            Response.Write("Submitted Successfully");
                        }
                     
                    }
                }
            }
            catch (Exception exc)
            {
                //Response.Write(exc);
                Response.Write("Internal server error. Please try again.");
            }

        }
    }
}