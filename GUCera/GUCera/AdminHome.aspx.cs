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
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ListAllCourses(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AllCourses.aspx");
            }
            catch(Exception err)
            {
                Response.Write("Internal server error, please try again");
            }

        }

        protected void ListAllNonAccCourses(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AllNonAcceptedCourses.aspx");
            }
            catch(Exception err)
            {
                Response.Write("Internal server error, please try again");
            }
        }

        protected void CreatePromo(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand cmd = new SqlCommand("AdminCreatePromocode", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string Code=code.Text;
                DateTime IssueDate=DateTime.Parse("11/11/2000"); 
                DateTime ExpiryDate= DateTime.Parse("11/11/2000");
                decimal discount=4;

                Boolean flag = false;
                try
                {
       
                     IssueDate = DateTime.Parse(issuedate.Text);
                     ExpiryDate = DateTime.Parse(expiryDate.Text);
                     discount = decimal.Parse(Discount.Text);
                }
                catch(Exception errrr)
                {
                    flag = true;
                }
                if (flag)
                {
                    Response.Write("Invalid Data");
                }
                else
                {
                    try
                    {
                        cmd.Parameters.Add(new SqlParameter("@code", Code));
                        cmd.Parameters.Add(new SqlParameter("@isuueDate", IssueDate));
                        cmd.Parameters.Add(new SqlParameter("@expiryDate", ExpiryDate));
                        cmd.Parameters.Add(new SqlParameter("@discount", discount));
                        cmd.Parameters.Add(new SqlParameter("@adminId", Session["user"]));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Response.Write("Code Created Successfully");
                    }
                    catch(Exception er)
                    {
                        Response.Write("Promocode Already exists");
                    }
                }     
            }
            catch(Exception errr)
            {
                Response.Write("Internal server error, please try again");

            }
        }
        protected void IssuePromo(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand cmd = new SqlCommand("AdminIssuePromocodeToStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                Boolean flag = false;
                string pid = PromoID.Text;
                int sid = 4;
                try
                {
                    sid = Int16.Parse(StudentID.Text);

                }
                catch(Exception err)
                {
                    flag = true;
                }
                
                if (flag)
                {
                    Response.Write("Invalid data ");
                }
                else
                {
                    try
                    {
                        cmd.Parameters.Add(new SqlParameter("@sid", sid));
                        cmd.Parameters.Add(new SqlParameter("@pid", pid));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Response.Write("Code issued successfully");
                    }
                    catch(Exception r)
                    {
                        Response.Write("Code not issued");
                    }
                    
                }
            }
            catch(Exception errr)
            {
                Response.Write("Internal server error, please try again");
            }

        }

        protected void AcceptCourse(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);

                Boolean flag = false;
                int c_id = 1;
                try
                {
                    c_id = Int16.Parse(cid.Text);
                }
                catch (Exception er)
                {
                    flag = true;
                }
                if (flag)
                {
                    Response.Write("Invalid data");
                }
                else
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SELECt * FROM COURSE WHERE id=\'" + c_id + "\'", conn);
                        conn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        if (rdr.Read())
                        {
                            flag = true;
                        }
                        conn.Close();
                        if (!flag)
                        {
                            Response.Write("Course does not exist");
                        }
                        else
                        {
                            cmd = new SqlCommand("AdminAcceptRejectCourse", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@adminId", Session["user"]));
                            cmd.Parameters.Add(new SqlParameter("@courseId", c_id));
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            Response.Write("Course Accepted Successfully");
                        }
                    }
                    catch(Exception r)
                    {
                        Response.Write("Course not Accepted");
                    }
                }
            }
            catch(Exception err)
            {
                Response.Write("Internal server error, please try again");
            }
        }
        protected void AddMobile(object sender, EventArgs e)
        {
            Response.Redirect("AddMobileNumbers.aspx");
        }
        protected void Logout(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }


    }
}