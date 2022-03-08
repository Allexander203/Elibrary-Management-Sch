using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace SchoolApp
{
    public partial class adminbookissuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)//search button
        {
            if (checkIfMemberExist() && checkIfBookExist())
            {
                getNames();
            }
            else
            {
                if (checkIfBookExist())
                {
                    getNames();
                }
                else
                {
                    Response.Write("<script>alert('Wrong book ID');</script>");
                }
                if (checkIfMemberExist())
                {
                    getNames();
                }
                else
                {
                    Response.Write("<script>alert('Wrong member ID');</script>");
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)//issuie
        {
            if (checkIfIssueEntryExist())
            {

            }
            else
            {
                issueBook();
            }
            if (checkIfBookExist() && checkIfMemberExist())
            {
                issueBook();
            }
            else
            {
                Response.Write("<script>alert('Wrong book or member ID');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)//return
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {
                if (checkIfIssueEntryExist())
                {
                    ReturnBook();
                }
                else
                {
                    Response.Write("<script>alert('This entry does not exist');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong book or member ID');</script>");
            }
        }
        // user defined functions
        void ReturnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_issuing WHERE book_id='" + TextBox3.Text.Trim() + "'AND member_id='" + TextBox1.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    cmd = new SqlCommand("UPDATE book_info SET current_stock = current_stock+1 WHERE book_id='" + TextBox3.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Returned Successfully!');</script>");
                    GridView1.DataBind();
                    con.Close();
                }
                else
                {
                    Response.Write("<script>alert('Error - Invalid details');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void issueBook()
        {
            if (checkIfIssueEntryExist())
            {
                Response.Write("<script>alert('This member already has this Book');</script>");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO book_issuing(member_id,member_name,book_id,book_name,issue_date,due_date) " +
                         "values(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con);

                    cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE book_info SET current_stock = current_stock-1 WHERE book_id='" + TextBox3.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Issued Successfuly!');</script>");
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        bool checkIfIssueEntryExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issuing WHERE member_id = '" + TextBox1.Text.Trim() + "'AND book_id='" + TextBox3.Text.Trim() + "'", con);
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
        bool checkIfBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_info WHERE book_id= '" + TextBox3.Text.Trim() + "'AND current_stock >0", con);
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
        bool checkIfMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT full_name FROM members WHERE member_id = '" + TextBox1.Text.Trim() + "'", con);
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
        void getNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT book_name FROM book_info WHERE book_id= '" + TextBox3.Text.Trim() + "'", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count >= 1)
                {
                    TextBox4.Text = dt1.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }
                SqlCommand cmd1 = new SqlCommand("SELECT full_name FROM members WHERE member_id = '" + TextBox1.Text.Trim() + "'", con);
                da1 = new SqlDataAdapter(cmd1);
                dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count >= 1)
                {
                    TextBox2.Text = dt1.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid User ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.Cells[5].BackColor = System.Drawing.Color.PaleVioletRed;
                        e.Row.Cells[4].BackColor = System.Drawing.Color.PaleVioletRed;
                        e.Row.Cells[3].BackColor = System.Drawing.Color.PaleVioletRed;
                        e.Row.Cells[2].BackColor = System.Drawing.Color.PaleVioletRed;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.PaleVioletRed;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.PaleVioletRed;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}