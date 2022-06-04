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
    public partial class AllNonAcceptedCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);

                /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
                SqlCommand cmd = new SqlCommand("AdminViewNonAcceptedCourses", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    String CourseName = rdr.GetString(rdr.GetOrdinal("name"));
                    Label ctxt = new Label();
                    Label c = new Label();
                    ctxt.Text = "Course Name:";
                    c.Text = " " + CourseName + " ";
                    form1.Controls.Add(ctxt);
                    form1.Controls.Add(c);

                    String CreditHours = rdr.GetInt32(rdr.GetOrdinal("creditHours")).ToString();
                    Label chtxt = new Label();
                    Label ch = new Label();
                    chtxt.Text = "Credit Hours:";
                    ch.Text = " " + CreditHours + " ";
                    form1.Controls.Add(chtxt);
                    form1.Controls.Add(ch);

                    String Price = rdr.GetDecimal(rdr.GetOrdinal("price")).ToString();
                    Label ptxt = new Label();
                    Label p = new Label();
                    ptxt.Text = "Price: ";
                    p.Text = " " + Price + " ";
                    form1.Controls.Add(ptxt);
                    form1.Controls.Add(p);

                    String Content;
                    if (rdr.IsDBNull(rdr.GetOrdinal("content")))
                        Content = "Not defined yet";
                    else
                        Content = rdr.GetString(rdr.GetOrdinal("content"));
                    Label contxt = new Label();
                    Label con = new Label();
                    contxt.Text = "Content:";
                    con.Text = " " + Content + " ";
                    form1.Controls.Add(contxt);
                    form1.Controls.Add(con);

                }
            }
            catch(Exception err)
            {
                Response.Write("Internal server error, please try again");
            }
         }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }

    }
}