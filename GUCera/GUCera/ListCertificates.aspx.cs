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
    public partial class ListCertificates : System.Web.UI.Page
    {
        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void List(object sender, EventArgs e)

        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                SqlConnection conn = new SqlConnection(connStr);


                SqlCommand cmd = new SqlCommand("viewCertificate", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                //To read the input from the user
                int c_id = -1;
                if (c_id.Equals(""))
                {
                    Response.Write("Please fill the box.");
                }
                else
                {
                    try
                    {

                        c_id = Int16.Parse(cid.Text);
                    }
                    catch (Exception exc)
                    {
                        Response.Write("Invalid Course ID.");
                    }

                    conn.Open();

                    //pass parameters to the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@sid", Session["user"]));
                    cmd.Parameters.Add(new SqlParameter("@cid", c_id));

                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rdr.Read())
                    {
                        String CourseID = rdr.GetInt32(rdr.GetOrdinal("cid")).ToString();
                        Label cidtxt = new Label();
                        Label cid = new Label();
                        cidtxt.Text = "Course ID:";
                        cid.Text = " " + CourseID + " ";
                        form1.Controls.Add(cidtxt);
                        form1.Controls.Add(cid);

                        String IssueDate = rdr.GetDateTime(rdr.GetOrdinal("IssueDate")).ToString();
                        Label Datetxt = new Label();
                        Label Date = new Label();
                        Datetxt.Text = "Issue Date:";
                        Date.Text = " " + IssueDate + " ";
                        form1.Controls.Add(Datetxt);
                        form1.Controls.Add(Date);

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
