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
    public partial class SubmitAssignment : System.Web.UI.Page
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

                SqlCommand cmd = new SqlCommand("submitAssign", conn);
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
                        c_id = Int16.Parse(Cid.Text);
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
                            try {

                                cmd.Parameters.Add(new SqlParameter("@assignType", ass_type));
                                cmd.Parameters.Add(new SqlParameter("@sid", Session["user"]));
                                cmd.Parameters.Add(new SqlParameter("@assignnumber", ass_num));
                                cmd.Parameters.Add(new SqlParameter("@cid", c_id));
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                Response.Write("Submitted Successfully");

                            }
                            catch (Exception exc)
                            {
                                Response.Write("Assignment already submitted.");
                            }
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
