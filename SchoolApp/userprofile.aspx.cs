using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace SchoolApp
{
    public partial class userprofile : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSourceID = String.Empty;

            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired, Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserBookData();
                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired, Login Again');</script>");
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)//update button
        {
            updatePersonalDetaild();
        }

        //user defined functions

        /*void uploadUserImage()
        {
            string filepath = "~/book_inventory/books(1).png";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
            filepath = "~/book_inventory/" + filename;

        }*/

        void updatePersonalDetaild()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string password = "";
                if (TextBox9.Text.Trim() == "")
                {
                    password = TextBox5.Text.Trim();
                }
                else
                {
                    password = TextBox9.Text.Trim();
                }
                string filepath = "~/book_inventory/books(1)";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (filename == "" || filename == null)
                {
                    filepath = global_filepath;
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                }

                SqlCommand cmd = new SqlCommand("UPDATE members SET full_name = @full_name, birth_date = @birth_date, contact_num = @contact_num, email = @email, " +
                    "state = @state, city = @city, pincode = @pincode, full_address = @full_address, member_id = @member_id, password = @password," +
                    " account_status = @account_status, profile_img=@profile_img WHERE member_id='" + Session["username"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@birth_date", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_num", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "Pending");
                cmd.Parameters.AddWithValue("@profile_img", filepath);


                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script>alert('Updated Successfully');</script>");
                    getUserBookData();
                    /*uploadUserImage();*/
                    getUserPersonalDetails();

                }
                else
                {
                    Response.Write("<script>alert(' Ivalid Entry');</script>");

                }

                cmd.ExecuteNonQuery();
                con.Close();

                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM members WHERE member_id='" + Session["username"].ToString() + "'", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                TextBox3.Text = dt1.Rows[0]["full_name"].ToString();
                TextBox1.Text = dt1.Rows[0]["birth_date"].ToString();
                TextBox2.Text = dt1.Rows[0]["contact_num"].ToString();
                TextBox4.Text = dt1.Rows[0]["email"].ToString();
                DropDownList1.SelectedValue = dt1.Rows[0]["state"].ToString().Trim();
                TextBox6.Text = dt1.Rows[0]["city"].ToString();
                TextBox8.Text = dt1.Rows[0]["pincode"].ToString();
                TextBox7.Text = dt1.Rows[0]["member_id"].ToString();
                TextBox10.Text = dt1.Rows[0]["full_address"].ToString();
                TextBox5.Text = dt1.Rows[0]["password"].ToString();
                TextBox9.Text = dt1.Rows[0]["password"].ToString();
                global_filepath = dt1.Rows[0]["profile_img"].ToString();

                Label1.Text = dt1.Rows[0]["account_status"].ToString().Trim();
                if (dt1.Rows[0]["account_status"].ToString().Trim() == "Active")
                {
                    Label1.Attributes.Add("class", "badge rounded-pill bg-success");
                }
                else if (dt1.Rows[0]["account_status"].ToString().Trim() == "Pending")
                {
                    Label1.Attributes.Add("class", "badge rounded-pill bg-warning text-dark");
                }
                else if (dt1.Rows[0]["account_status"].ToString().Trim() == "Disabled")
                {
                    Label1.Attributes.Add("class", "badge rounded-pill bg-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge rounded-pill bg-info text-dark");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void getUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issuing WHERE member_id='" + Session["username"].ToString() + "'", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                GridView1.DataSource = dt1;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[4].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                    else
                    {
                        e.Row.BackColor = System.Drawing.Color.LightGray;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }
    }
}