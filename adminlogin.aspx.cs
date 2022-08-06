using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class adminlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string name = Request.Form.Get("username");
        string pass = Request.Form.Get("pass"); 
        string mycon = "Server=localhost;Database=bank;Uid=root;Password= ;";
        MySqlConnection con = new MySqlConnection(mycon);
        MySqlCommand cmd = null;
        try
        {
            cmd = new MySqlCommand("select * from admin where adminname=@adminname and password=@pass", con);
            cmd.Parameters.AddWithValue("@adminname", Request.Form.Get("username"));
            cmd.Parameters.AddWithValue("@pass", Request.Form.Get("pass"));
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                Session["username"] = name;
                Session["pass"] = pass;
                Response.Redirect("adminprofile.aspx");
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