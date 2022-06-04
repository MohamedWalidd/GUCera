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
    public partial class ViewAssignmentGrade : System.Web.UI.Page
    {
        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                SqlConnection conn = new SqlConnection(connStr);


                SqlCommand cmd = new SqlCommand("viewAssignGrades", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //To read the input from the user
                string ass_type = AssType.SelectedItem.Value;
                int ass_num = -1;
                int c_id = -1;
                Boolean flag = false;
                if (c_id.Equals("") || ass_num.Equals(""))
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
                        Response.Write("Invalid course id.");
                    }
                    else
                    {
                        flag = false;

                        try
                        {
                            ass_num = Int16.Parse(AssNum.Text);
                        }
                        catch (Exception exc)
                        {
                            flag = true;
                        }
                        if (flag)
                        {
                            Response.Write("Invalid assignment number.");
                        }
                        else
                        {

                            //pass parameters to the stored procedure
                            cmd.Parameters.Add(new SqlParameter("@assignType", ass_type));
                            cmd.Parameters.Add(new SqlParameter("@sid", Session["user"]));
                            cmd.Parameters.Add(new SqlParameter("@assignnumber", ass_num));
                            cmd.Parameters.Add(new SqlParameter("@cid", c_id));

                            //Save the output from the procedure
                            SqlParameter grade = cmd.Parameters.Add("@assignGrade", SqlDbType.Decimal);
                            grade.Direction = ParameterDirection.Output;

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();


                            Response.Write("Grade: " + grade.Value);
                        }
                    }

                }
            }
            catch (Exception exc)
            {
                Response.Write("Internal server error. Please try again.");
            }
        }
    }
}