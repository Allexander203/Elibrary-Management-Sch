using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SchoolApp
{
    public partial class adminauthormanagment : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)//add button
        {
            if (checkIfAuthorExist())
            {
                Response.Write("<script>alert('Author with this ID already exists. Try other ID.');</script>");
            }
            else
            {
                addNewAuthor();
            }
        }

        // update button click

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExist())
            {
                updateAuthor();
            }
            else
            {
                Response.Write("<script>alert('This Author does not exist');</script>");
            }
        }

        //

        protected void Button1_Click(object sender, EventArgs e)//delete button
        {
            if (checkIfAuthorExist())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('This Author does not exist');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)//search button
        {
            getAuthorbyId();
        }
        //user defined function

        void getAuthorbyId()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM author WHERE author_id='" + TextBox3.Text.Trim() + "'", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                if (dt1.Rows.Count >= 1)
                {
                    TextBox1.Text = dt1.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid author ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM  author WHERE author_id='" + TextBox3.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('You have Deleted this Author Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE author SET author_name=@author_name WHERE author_id='" + TextBox3.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@author_name", TextBox1.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('This Author is Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //
        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO author(author_id,author_name) " +
                     "values(@author_id,@author_name)", con);

                cmd.Parameters.AddWithValue("@author_id", TextBox3.Text.Trim());//  Full Name
                cmd.Parameters.AddWithValue("@author_name", TextBox1.Text.Trim());//  ID of author

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Added Successfuly!');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfAuthorExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM author WHERE author_id='" + TextBox3.Text.Trim() + "'", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                if (dt1.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void clearForm()
        {
            TextBox3.Text = "";
            TextBox1.Text = "";
        }

    }
}