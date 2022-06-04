using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
        static string connStr;
        static SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
                conn = new SqlConnection(connStr);
            }
            catch (Exception exc)
            {
                Response.Write("Internal server error, please try again.");
            }
            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("viewMyProfile", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@id", Session["user"]));
            //Read row by row
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            //BinaryWriter writer = null;

            while (rdr.Read())
            {
                Console.Out.WriteLine("in");
                String firstname = rdr.GetString(rdr.GetOrdinal("firstName"));
                Label fname = new Label();
                Label fnamelabel = new Label();
                fnamelabel.Text = "First Name: ";
                fname.Text = firstname+" ";
                form1.Controls.Add(fnamelabel);
                form1.Controls.Add(fname);
                String lastname = rdr.GetString(rdr.GetOrdinal("lastName"));
                Label lastnamelabel = new Label();
                lastnamelabel.Text = "Last Name: ";
                Label lname = new Label();
                lname.Text = lastname+" ";
                form1.Controls.Add(lastnamelabel);
                form1.Controls.Add(lname);
                String pass = rdr.GetString(rdr.GetOrdinal("password"));
                Label passlabel = new Label();
                Label passlabel1 = new Label();
                passlabel1.Text = "Password: ";
                passlabel.Text = pass+" ";
                form1.Controls.Add(passlabel1);
                form1.Controls.Add(passlabel);

                Byte[] s_gender = (byte[])rdr.GetSqlBinary(rdr.GetOrdinal("gender"));
                Label genderlabel = new Label();
                Label genderlabel1 = new Label();
                genderlabel1.Text = "Gender: ";

                //System.Data.SqlTypes.SqlBinary ONE = new Sql

                if (s_gender[0]==1)
                    genderlabel.Text = "female" + " ";
                else
                    genderlabel.Text = "male" + " ";
                form1.Controls.Add(genderlabel1);
                form1.Controls.Add(genderlabel);
                String studentemail = rdr.GetString(rdr.GetOrdinal("email"));
                Label emaillabel = new Label();
                Label emaillabel1 = new Label();
                emaillabel1.Text = "Email: ";
                emaillabel.Text = studentemail+" ";
                form1.Controls.Add(emaillabel1);
                form1.Controls.Add(emaillabel);
                String add = rdr.GetString(rdr.GetOrdinal("address"));
                Label addresslabel = new Label();
                addresslabel.Text = add+" ";
                Label addresslabel1 = new Label();
                addresslabel1.Text = "Address: ";
                form1.Controls.Add(addresslabel1);
                form1.Controls.Add(addresslabel);

            }
        }
    }
}