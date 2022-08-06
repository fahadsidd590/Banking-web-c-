using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();

    }
    protected void submit_Click(object sender, EventArgs e)
    {
      
        string name = Request.Form.Get("username");
        string pass = Request.Form.Get("pass");
        Session["name"] = name;
     // Response.Redirect("userprofile.aspx");
       // string mycon = "server =localhost; Uid=root; password = ; persistsecurityinfo = True; database =bank; SslMode = none";
        string mycon = "Server=localhost;Database=bank;Uid=root;Password= ;";
        MySqlConnection con = new MySqlConnection(mycon);
        
       MySqlCommand cmd = null;
      
        try
        {
            cmd = new MySqlCommand("select * from client where username=@username and password=@pass", con);
            cmd.Parameters.AddWithValue("@username", Request.Form.Get("username"));
            cmd.Parameters.AddWithValue("@pass", Request.Form.Get("pass"));
            DataTable dt = new DataTable();            
            con.Open();       
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                Session["username"] = name;
                Session["pass"] = pass;
                Response.Redirect("userprofile.aspx");
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

       // Response.Write("<script>alert('Data Saved Successfully')</script>");
       
     //  
        
    }

}