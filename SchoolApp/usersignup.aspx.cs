using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SchoolApp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // sign up btn click
        protected void Button0_Click(object sender, EventArgs e)
        {
            if (checkIfMemberExists())
            {
                Response.Write("<script>alert('A member with this ID already exist. Try other ID.');</script>");
            }
            else
            {
                signUpNewMember();
            }
        }
        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM members WHERE member_id='" + TextBox7.Text.Trim() + "'", con);
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

                con.Close();
                Response.Write("<script>alert('Sign up successful! Go to user login to log in.');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void signUpNewMember()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO members(full_name,birth_date,contact_num,email,state,city,pincode,full_address,member_id,password,account_status) " +
                    "values(@full_name,@birth_date,@contact_num,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox3.Text.Trim());//  Full Name
                cmd.Parameters.AddWithValue("@birth_date", TextBox1.Text.Trim());//  Date of Birth
                cmd.Parameters.AddWithValue("@contact_num", TextBox2.Text.Trim());//  Contact Number
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());//  Email Address
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);//  State Dropdown List
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());//  City
                cmd.Parameters.AddWithValue("@pincode", TextBox8.Text.Trim());//  Pincode of City
                cmd.Parameters.AddWithValue("@full_address", TextBox9.Text.Trim());//  Full Living Address
                cmd.Parameters.AddWithValue("@member_id", TextBox7.Text.Trim());//  Member ID
                cmd.Parameters.AddWithValue("@password", TextBox5.Text.Trim());//  Password 
                cmd.Parameters.AddWithValue("@account_status", "pending");//  Account Status

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign up successful! Go to user login to log in.');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}