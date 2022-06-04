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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit(object sender, EventArgs e)
        {
            try { 
                //Get the information of the connection to the database
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);

                /*create a new SQL command which takes as parameters the name of the stored procedure and
                 the SQLconnection name*/

                SqlCommand cmd = new SqlCommand("userLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //To read the input from the user
                string u_id = uid.Text;
                string u_pass = password.Text;

                //check if u_id is only numbers
                Boolean flag = false;
                try
                {
                    int tmp = Int16.Parse(u_id);
                }catch(Exception err)
                {
                    flag = true;
                }

                if (flag) //id cannot be parsed into an integer
                {
                    Response.Write("<p style=\"color: red;\">Invalid ID</p>");
                }
                else
                {

                    //pass parameters to the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@id", u_id));
                    cmd.Parameters.Add(new SqlParameter("@password", u_pass));

                    //Save the output from the procedure
                    SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Int);
                    success.Direction = ParameterDirection.Output;

                    SqlParameter type = cmd.Parameters.Add("@type", SqlDbType.Int);
                    type.Direction = ParameterDirection.Output;

                    //Executing the SQLCommand
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    if (success.Value.ToString() == "1")
                    {
                        Session["user"] = u_id;
                        Session["type"] = type.Value.ToString();
                        if (type.Value.ToString() == "2")
                        {
                            Response.Redirect("StudentHome.aspx");
                        }
                        else if (type.Value.ToString() == "1")
                        {
                            Response.Redirect("AdminHome.aspx");
                        }
                        else if (type.Value.ToString() == "0")
                        {
                            Response.Redirect("InstructorPage.aspx");
                        }
                    }
                    else //unsuccessful login
                    {
                        Response.Write("<p style=\"color: red;\">Username or Password is incorrect</p>");
                    }
                }
            } catch (Exception _) //server error
            {
                Response.Write("<p style=\"color: red;\">Internal server error please try again</p>");
            }
        }
        protected void register (object sender, EventArgs e)
        {
            Response.Redirect("Registeration.aspx");
        }
    }
}