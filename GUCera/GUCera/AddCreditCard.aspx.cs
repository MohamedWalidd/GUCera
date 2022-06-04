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
    public partial class AddCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);

                string credit_number = CreditNumber.Text;
                int day = Int16.Parse(Exp_Date_Day.Text);
                int month = Int16.Parse(Exp_Date_Month.Text);
                int year = Int16.Parse(Exp_Date_Year.Text);
                if (CreditNumber.Text.Equals("") || HolderName.Text.Equals("") || C.Text.Equals("") || Exp_Date_Day.Text.Equals("") || Exp_Date_Month.Text.Equals("") ||
                    Exp_Date_Year.Text.Equals(""))
                {
                    Response.Write("Invalid, please try again.");
                }
                else if (day >= 32 || day <= 0)
                {
                    Response.Write("Please enter valid day");
                }
                else if (year <= 0)
                {
                    Response.Write("Please enter valid Year");
                }
                else if(month > 12 || month <= 0)
                {
                    Response.Write("Please enter valid Month");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("addCreditCard", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    String credit = CreditNumber.Text;
                    String name = HolderName.Text;
                    String cv = C.Text;
                    string exp =
                        Exp_Date_Day.Text + "/" +
                        Exp_Date_Month.Text + "/" +
                        Exp_Date_Year.Text + " "
                        ;
                    // SqlParameter deadline_param = new SqlParameter("@deadline", SqlDbType.DateTime);

                    SqlParameter exp_param = new SqlParameter("@expiryDate", SqlDbType.DateTime);
                    exp_param.Value = DateTime.Parse(exp);
                    cmd.Parameters.Add(exp_param);

                    // exp_param.Value = DateTime.Parse(exp);
                    //  cmd.Parameters.Add(deadline_param);
                    cmd.Parameters.Add(new SqlParameter("@sid", Session["user"]));
                    cmd.Parameters.Add(new SqlParameter("@number", credit));
                    cmd.Parameters.Add(new SqlParameter("@cardHolderName", name));
                    //    cmd.Parameters.Add(new SqlParameter("@expiryDate", exp_param));
                    cmd.Parameters.Add(new SqlParameter("@cvv", cv));


                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Response.Write("Credit card added successfully.");
                    }
                    catch (Exception _)
                    {
                        Response.Write("This Credit number is already added for this user.");
                    }
                }
            }
            catch (Exception _)
            {
                Response.Write("Internal server error. Plase try again.");
            }
        }
    }
}