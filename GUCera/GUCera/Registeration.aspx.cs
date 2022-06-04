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
    public partial class Registeration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nothing
        }

        protected void Submit(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);

                int registerType = Int16.Parse(registeras.SelectedItem.Value);

                string spname = registerType == 0 ? "studentRegister" : "InstructorRegister";

                SqlCommand cmd = new SqlCommand(spname, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //To read the input from the user
                String fname = firstname.Text.ToString();
                String lname = lastname.Text.ToString();
                String u_email = email.Text.ToString();
                String u_pass = password.Text.ToString();
                int u_gender = gender.SelectedItem.Value == "0" ? 0x0 : 0x1;
                String u_add = address.Text.ToString();

                if (fname.Equals("") || lname.Equals("") || u_email.Equals("") || u_pass.Equals("") || u_add.Equals(""))
                {
                    Response.Write("<p style=\"color: red;\">All fields are required. Make sure all boxes are filled.</p>");
                }
                else
                {
                    try
                    {
                        //pass parameters to the stored procedure
                        cmd.Parameters.Add(new SqlParameter("@first_name", fname));
                        cmd.Parameters.Add(new SqlParameter("@last_name", lname));
                        cmd.Parameters.Add(new SqlParameter("@password", u_pass));
                        cmd.Parameters.Add(new SqlParameter("@email", u_email));
                        cmd.Parameters.Add(new SqlParameter("@gender", u_gender));
                        cmd.Parameters.Add(new SqlParameter("@address", u_add));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        cmd = new SqlCommand("SELECT id FROM Users WHERE email=\'" + u_email + "\'", conn);
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (rdr.Read())
                        {
                            int id = rdr.GetInt32(rdr.GetOrdinal("id"));
                            Response.Write("Your id is " + id + " ");
                        }
                        Response.Write("<p style=\"color: green;\">Registered Successfully</p>");
                    }
                    catch (Exception _)
                    {
                        Response.Write("<p style=\"color: red;\">Email already registered, please try another email.</p>");
                    }
                }
            } catch(Exception _)
            {
                Response.Write("<p style=\"color: red;\">Internal server error please try again</p>");
            }

        }
        protected void Login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}