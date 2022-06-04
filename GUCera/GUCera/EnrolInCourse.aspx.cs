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
    public partial class EnrolInCourse : System.Web.UI.Page
    {

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        static string connStr;
        static SqlConnection conn; 
        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean flag = false;
            string i_id= Instr_ID.Text;
            string c_id= C_ID.Text;
            try {
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                if(Instr_ID.Text.Equals("")|| C_ID.Text.Equals(""))
                {
                    Response.Write("Invalid, Please try again");
                }
                else
                {
                   
                    //To read the input from the user
                    try
                    {
                        int tmp1 = Int16.Parse(i_id);
                        int tmp2= Int16.Parse(c_id);
                    }
                    catch(Exception err)
                    {
                        flag = true;
                    }
                    if (flag)
                    {
                        Response.Write("Invalid Course ID or Invalid Instructor ID");
                    }
                    else
                    {

                        //SqlCommand cmd = new SqlCommand("select * from Course where cid=\'" + c_id + "\'", conn);

                        //SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        //if (sdr.Read())
                        //{
                        //    flag = true;
                        //}

                        //conn.Close();
                        //if()

                        SqlCommand cmd = new SqlCommand("enrollInCourse", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@sid", Session["user"]));
                        cmd.Parameters.Add(new SqlParameter("@cid", c_id));
                        cmd.Parameters.Add(new SqlParameter("@instr", i_id));
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            Response.Write("Enrolled Successfully");
                            conn.Close();

                        }
                        catch (Exception _)
                        {
                            Response.Write("Cannot enroll in course.");
                        }
                    }
                    
                    
                }

            }
            catch (Exception _)
            {
                Response.Write("Internal server error. Plase try again.");
            }
        }
       

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }
    }
}