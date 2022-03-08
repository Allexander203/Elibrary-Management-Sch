using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SchoolApp
{
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)//add
        {
            if (checkIfPublisherExist())
            {
                Response.Write("<script>alert('Author with this ID already exists. Try other ID.');</script>");
            }
            else
            {
                addNewPublisher();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)//update
        {
            if (checkIfPublisherExist())
            {
                updatePublisher();
            }
            else
            {
                Response.Write("<script>alert('This Author does not exist');</script>");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)//delete
        {
            if (checkIfPublisherExist())
            {
                deletePublisher();
            }
            else
            {
                Response.Write("<script>alert('This Publisher does not exist');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)//search
        {
            getPublisherById();
        }
        //user defined functions

        void getPublisherById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher WHERE publisher_id='" + TextBox3.Text.Trim() + "'", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                if (dt1.Rows.Count >= 1)
                {
                    TextBox1.Text = dt1.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid publisher ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }


        }
        void clearForm()
        {
            TextBox3.Text = "";
            TextBox1.Text = "";
        }
        bool checkIfPublisherExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher WHERE publisher_id='" + TextBox3.Text.Trim() + "'", con);
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
        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher(publisher_id,publisher_name) " +
                     "values(@publisher_id,@publisher_name)", con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox3.Text.Trim());//  Full Name
                cmd.Parameters.AddWithValue("@publisher_name", TextBox1.Text.Trim());//  ID of publisher

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Added Successfuly!');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE publisher SET publisher_name=@publisher_name WHERE publisher_id='" + TextBox3.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@publisher_name", TextBox1.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('This Publisher is Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM  publisher WHERE publisher_id='" + TextBox3.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('You have Deleted this Publisher of Books Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}