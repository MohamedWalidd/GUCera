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
    public partial class AssignmentContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }

        protected void submit(object sender, EventArgs e)
        {
            try
            {

                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);


                SqlCommand cmd = new SqlCommand("viewAssign", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //To read the input from the user
                int c_id = -1;
               
                if (c_id.Equals(""))
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
                        Response.Write("Invalid Course ID.");
                    }

                    conn.Open();

                    //pass parameters to the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@courseId", c_id));
                    cmd.Parameters.Add(new SqlParameter("@Sid", Session["user"]));

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

                        String AssignmentNumber = rdr.GetInt32(rdr.GetOrdinal("Number")).ToString();
                        Label Numtxt = new Label();
                        Label Num = new Label();
                        Numtxt.Text = "Number:";
                        Num.Text = " " + AssignmentNumber + " ";
                        form1.Controls.Add(Numtxt);
                        form1.Controls.Add(Num);

                        String AssignmentType = rdr.GetString(rdr.GetOrdinal("type"));
                        Label typetxt = new Label();
                        Label type = new Label();
                        typetxt.Text = "type:";
                        type.Text = " " + AssignmentType + " ";
                        form1.Controls.Add(typetxt);
                        form1.Controls.Add(type);

                        String AssignmentFullGrade = rdr.GetInt32(rdr.GetOrdinal("fullGrade")).ToString();
                        Label fullGradetxt = new Label();
                        Label fullGrade = new Label();
                        fullGradetxt.Text = "fullGrade:";
                        fullGrade.Text = " " + AssignmentFullGrade + " ";
                        form1.Controls.Add(fullGradetxt);
                        form1.Controls.Add(fullGrade);

                        String AssignmentWeight = rdr.GetDecimal(rdr.GetOrdinal("weight")).ToString();
                        Label Weighttxt = new Label();
                        Label Weight = new Label();
                        Weighttxt.Text = "weight:";
                        Weight.Text = " " + AssignmentWeight + " ";
                        form1.Controls.Add(Weighttxt);
                        form1.Controls.Add(Weight);

                        String AssignmentDeadline = DateTime.Parse(rdr.GetDateTime(rdr.GetOrdinal("deadline")).ToString()).ToString();
                        Label Deadlinetxt = new Label();
                        Label Deadline = new Label();
                        Deadlinetxt.Text = "Deadline:";
                        Deadline.Text = " " + AssignmentDeadline + " ";
                        form1.Controls.Add(Deadlinetxt);
                        form1.Controls.Add(Deadline);

                        String AssignmentContent = rdr.GetString(rdr.GetOrdinal("content"));
                        Label Contenttxt = new Label();
                        Label Content = new Label();
                        Contenttxt.Text = "Content:";
                        Content.Text = " " + AssignmentContent + " ";
                        form1.Controls.Add(Contenttxt);
                        form1.Controls.Add(Content);
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