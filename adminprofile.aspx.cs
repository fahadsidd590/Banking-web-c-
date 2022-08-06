using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class adminprofile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Session["username"].ToString();
        string pass = Session["pass"].ToString();
        string mycon = "Server=localhost;Database=bank;Uid=root;Password= ;";
        MySqlConnection con = new MySqlConnection(mycon);
        MySqlCommand cmd = null;
        MySqlCommand cmd1 = null;

        try
        {
            // string query = "select * from client where username="+name+" and password="+pass;
            cmd = new MySqlCommand("select * from admin where adminname=@username and password=@pass", con);
            cmd.Parameters.AddWithValue("@username", name);
            cmd.Parameters.AddWithValue("@pass", pass);
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {

                Label2.Text = Session["username"].ToString();
                cmd1 = new MySqlCommand("SELECT id, firstname, lastname, username, accounttype, accountnum, totalamount FROM client", con);
                DataTable dt1 = new DataTable();
                dt1.Load(cmd1.ExecuteReader());
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                //Response.Write("<script>alert('Data Saved Successfully' )</script>");
            }
            else
            {
                Response.Write("<script>alert('user name or password is worng' )</script>");
            }


            con.Close();


        }
        catch (Exception ex)
        {
            Response.Write("<script>alert(' 33" + ex.Message + "')</script>");
            con.Close();
            return;
        }
    }
}