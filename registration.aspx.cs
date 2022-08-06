using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string fname = Request.Form.Get("firstname");
        string lname = Request.Form.Get("lastname");
        string username = Request.Form.Get("user_name1");
        string amount  = Request.Form.Get("Amount");
        int am = Int16.Parse(amount);
        string pass = Request.Form.Get("user_password1");
        string acctype = Request.Form.Get("user_account");
        string accnum = Request.Form.Get("accnum");
        string mycon = "Server=localhost;Database=bank;Uid=root;Password= ;";
        MySqlConnection con = new MySqlConnection(mycon);
        MySqlCommand cmd = null;
        try
        {
            cmd = new MySqlCommand("INSERT INTO client(firstname, lastname, username, password, accounttype, accountnum, totalamount)VALUES (@fname,@lname,@username,@password,@acctype,@accnum,@totalamount)", con);
            cmd.Parameters.AddWithValue("@fname",fname);
            cmd.Parameters.AddWithValue("@lname",lname);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", pass);
            cmd.Parameters.AddWithValue("@acctype",acctype);
            cmd.Parameters.AddWithValue("@accnum", accnum);
            cmd.Parameters.AddWithValue("@totalamount",am);
            con.Open();
          
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Data Saved Successfully')</script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert(' 33" + ex.Message + "')</script>");
            con.Close();
            return;
        }       
    }
}