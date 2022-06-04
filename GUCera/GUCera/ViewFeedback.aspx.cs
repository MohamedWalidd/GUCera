using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class ViewFeedback : System.Web.UI.Page
    {

        static string connStr;
        static SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();
                conn = new SqlConnection(connStr);
            }catch(Exception exc)
            {
                Response.Write("<p style=\"color: red\">Internal server error. Please try again.</p>");
            }

        }

        protected void Show(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                int cid = -1;
                Boolean flag = false;
                try
                {
                    cid = Int16.Parse(txt_course_id.Text);
                }catch(Exception exc)
                {
                    flag = true;
                }

                if (flag)
                {
                    Response.Write("<p style =\"color: red\">Invalid course id.</p>");
                }

                cmd.Parameters.Add(new SqlParameter("@instrId", Session["user"]));
                cmd.Parameters.Add(new SqlParameter("@cid", cid));


                conn.Open();

                // number,comment ,numberOfLikes

                SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable table = new DataTable();
                table.Load(sdr);
                string html = ExportDatatableToHtml(table);
                Response.Write(html);

                //while (sdr.Read())
                //{
                //    string number = sdr.GetInt32(sdr.GetOrdinal("number")).ToString();
                //    Label lbl_number = new Label();
                //    lbl_number.Text = number;
                //    form1.Controls.Add(lbl_number);

                //    string comment = sdr.GetString(sdr.GetOrdinal("comment"));
                //    Label lbl_comment = new Label();
                //    lbl_comment.Text = comment;
                //    form1.Controls.Add(lbl_comment);

                //    string number_of_likes = sdr.GetInt32(sdr.GetOrdinal("numberOfLikes")).ToString();
                //    Label lbl_nlikes = new Label();
                //    lbl_nlikes.Text = number_of_likes;
                //    form1.Controls.Add(lbl_nlikes);
                //
                //}
            }catch(Exception exc)
            {
                Response.Write("<p style=\"color: red\">Internal server error. Please try again.</p>");
            }
        }

        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("InstructorPage.aspx");
        }

        protected string ExportDatatableToHtml(DataTable dt)
        {
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<html >");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<table style='margin-left: auto; margin-right: auto' border='1px' cellpadding='1' cellspacing='1' bgcolor='lightyellow' style='font-family:Garamond; font-size:smaller'>");

            strHTMLBuilder.Append("<tr style='background-color: green'>");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");

            }
            strHTMLBuilder.Append("</tr>");


            foreach (DataRow myRow in dt.Rows)
            {

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }

            //Close tags.  
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");

            string Htmltext = strHTMLBuilder.ToString();

            return Htmltext;

        }

    }
}