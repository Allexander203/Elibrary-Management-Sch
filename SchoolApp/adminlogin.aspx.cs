using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SchoolApp
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM admin_login WHERE username ='" + TextBox1.Text.Trim() + "'AND password ='" + TextBox2.Text.Trim() + "'", con);

                SqlDataReader dr1 = cmd.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        //Response.Write("<script>alert('" + dr1.GetValue(0).ToString() + "');</script>");
                        Session["username"] = dr1.GetValue(0).ToString();
                        Session["fullname"] = dr1.GetValue(2).ToString();
                        Session["role"] = "admin";
                    }
                    Response.Redirect("homepage.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Credentials Not Valid!');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}