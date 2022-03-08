using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SchoolApp
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)// search button - magnifying glass
        {
            getMemberByID();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)// green button - account status 
        {
            updateMemberStatusByID("Active");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)// yellow button - account status 
        {
            updateMemberStatusByID("Pending");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)// red button - account status 
        {
            updateMemberStatusByID("Disabled");
        }
        protected void LinkButton5_Click(object sender, EventArgs e)// Delete Button !
        {
            deleteMemberByID();
        }

        //user defined functions

        bool checkIfMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM members WHERE member_id='" + TextBox3.Text.Trim() + "'", con);
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


        void deleteMemberByID()
        {
            if (checkIfMemberExist())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM  members WHERE member_id='" + TextBox3.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    clearForm();
                    Response.Write("<script>alert('You have Deleted this Member Permanently and Successfully');</script>");
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Mmeber ID!');</script>");
            }
        }

        void updateMemberStatusByID(String status)
        {
            if (checkIfMemberExist())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE members SET account_status ='" + status + "' WHERE member_id = '" + TextBox3.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated');</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Mmeber ID!');</script>");

            }
        }

        void getMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM members WHERE member_id ='" + TextBox3.Text.Trim() + "'", con);

                SqlDataReader dr1 = cmd.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        TextBox1.Text = dr1.GetValue(0).ToString();
                        TextBox3.Text = dr1.GetValue(8).ToString();
                        TextBox7.Text = dr1.GetValue(10).ToString();
                        TextBox2.Text = dr1.GetValue(2).ToString();//contact number
                        TextBox8.Text = dr1.GetValue(1).ToString();//dob
                        TextBox4.Text = dr1.GetValue(3).ToString();//email
                        TextBox9.Text = dr1.GetValue(4).ToString();
                        TextBox10.Text = dr1.GetValue(5).ToString();
                        TextBox11.Text = dr1.GetValue(6).ToString();
                        TextBox14.Text = dr1.GetValue(7).ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Mmeber ID!');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox7.Text = "";
            TextBox2.Text = "";//contact number
            TextBox8.Text = ""; ;//dob
            TextBox4.Text = "";//email
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox14.Text = "";
        }
    }
}