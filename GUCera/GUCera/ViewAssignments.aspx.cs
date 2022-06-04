using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace GUCera
{
    public partial class ViewAssignments : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("InstructorViewAssignmentsStudents", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                int cid = -1;
                Boolean flag = false;
                try
                {
                    cid = Int16.Parse(txt_course_id.Text);
                }
                catch (Exception exc)
                {
                    flag = true;
                }

                if (flag)
                {
                    Response.Write("<p style=\"color: red\">Invalid course id.</p>");
                }
                else
                {

                    cmd.Parameters.Add(new SqlParameter("@cid", cid));
                    cmd.Parameters.Add(new SqlParameter("@instrId", Session["user"]));

                    conn.Open();

                    SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable table = new DataTable();
                    table.Load(sdr);
                    string html = ExportDatatableToHtml(table);
                    Response.Write(html);

                    //while (sdr.Read())
                    //{
                    //string sid = sdr.GetInt32(sdr.GetOrdinal("sid")).ToString();
                    //Label lbl_sid = new Label();
                    //lbl_sid.Text = sid;
                    //form1.Controls.Add(lbl_sid);

                    //Label lbl_cid = new Label();
                    //lbl_cid.Text = cid.ToString();
                    //form1.Controls.Add(lbl_cid);

                    //string anumber = sdr.GetInt32(sdr.GetOrdinal("assignmentNumber")).ToString();
                    //Label lbl_anumber = new Label();
                    //lbl_anumber.Text = anumber;
                    //form1.Controls.Add(lbl_anumber);

                    //string atype = sdr.GetString(sdr.GetOrdinal("assignmenttype"));
                    //Label lbl_atype = new Label();
                    //lbl_atype.Text = atype;
                    //form1.Controls.Add(lbl_atype);

                    //string grade;
                    //if (sdr.IsDBNull(sdr.GetOrdinal("grade")))
                    //{
                    //    grade = "Not yet graded";
                    //}
                    //else
                    //{
                    //    grade = sdr.GetDecimal(sdr.GetOrdinal("grade")).ToString();
                    //}
                    //Label lbl_grade = new Label();
                    //lbl_grade.Text = grade;
                    //form1.Controls.Add(lbl_grade);
                    //}
                }
            }
            catch (Exception)
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