using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class tranctionhistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Session["username"].ToString();
        string pass = Session["pass"].ToString();
        string mycon = "Server=localhost;Database=bank;Uid=root;Password= ;";
        MySqlConnection con = new MySqlConnection(mycon);
        MySqlCommand cmd = null;
        MySqlCommand cmd1 = null;
        Button1.Visible = false;
        try
        {
            cmd = new MySqlCommand("select * from client where username=@username and password=@pass", con);
            
            cmd.Parameters.AddWithValue("@username", name);
            cmd.Parameters.AddWithValue("@pass", pass);
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            con.Open();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                Label2.Text = dt.Rows[0]["accountnum"].ToString();
                Label4.Text = dt.Rows[0]["totalamount"].ToString();
                cmd1 =  new MySqlCommand("select * from transcations where fromacc=@acnum ", con);
                cmd1.Parameters.AddWithValue("@acnum", dt.Rows[0]["accountnum"].ToString());
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

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string mycon = "Server=localhost;Database=bank;Uid=root;Password= ;";
        MySqlConnection con = new MySqlConnection(mycon);
        MySqlCommand cmd = null;
        MySqlCommand cmd1 = null;
        DateTime now = DateTime.Now;
        string date = now.ToString("yyyy-MM-dd");
        
        string acnum = Label2.Text.ToString();
        string sel = DropDownList1.SelectedValue.ToString();
        if(sel=="show all")
        {
            try
            {
                DataTable dt1 = new DataTable();
                con.Open();
                cmd1 = new MySqlCommand("select * from transcations where fromacc=@acnum ", con);
                cmd1.Parameters.AddWithValue("@acnum",acnum);
                dt1.Load(cmd1.ExecuteReader());

                if (dt1.Rows.Count > 0)
                {
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    //Response.Write("<script>alert('Data Saved Successfully' )</script>");
                }
                else
                {
                    Response.Write("<script>alert('no transction found' )</script>");
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
        else if (sel == "weekly")
        {
            string weekdate = now.AddDays(-7).ToString(("yyyy-MM-dd"));
           
            try
            {
                DataTable dt1 = new DataTable();
                con.Open();
                cmd1 = new MySqlCommand("select * from transcations where fromacc=@acnum and (date between @bfdate and @stdate)", con);
                cmd1.Parameters.AddWithValue("@acnum", acnum);
                cmd1.Parameters.AddWithValue("@bfdate", weekdate);
                cmd1.Parameters.AddWithValue("@stdate", date);

                dt1.Load(cmd1.ExecuteReader());

                if (dt1.Rows.Count > 0)
                {
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    //Response.Write("<script>alert('Data Saved Successfully' )</script>");
                }
                else
                {
                    Response.Write("<script>alert('no transction found' )</script>");
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
        else if (sel == "2weeks") {
            string weekdate = now.AddDays(-14).ToString(("yyyy-MM-dd"));

            try
            {
                DataTable dt1 = new DataTable();
                con.Open();
                cmd1 = new MySqlCommand("select * from transcations where fromacc=@acnum and (date between @bfdate and @stdate)", con);
                cmd1.Parameters.AddWithValue("@acnum", acnum);
                cmd1.Parameters.AddWithValue("@bfdate", weekdate);
                cmd1.Parameters.AddWithValue("@stdate", date);

                dt1.Load(cmd1.ExecuteReader());

                if (dt1.Rows.Count > 0)
                {
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    //Response.Write("<script>alert('Data Saved Successfully' )</script>");
                }
                else
                {
                    Response.Write("<script>alert('no transction found' )</script>");
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
        else if (sel == "month")
        {
            string weekdate = now.AddDays(-30).ToString(("yyyy-MM-dd"));

            try
            {
                DataTable dt1 = new DataTable();
                con.Open();
                cmd1 = new MySqlCommand("select * from transcations where fromacc=@acnum and (date between @bfdate and @stdate)", con);
                cmd1.Parameters.AddWithValue("@acnum", acnum);
                cmd1.Parameters.AddWithValue("@bfdate", weekdate);
                cmd1.Parameters.AddWithValue("@stdate", date);

                dt1.Load(cmd1.ExecuteReader());

                if (dt1.Rows.Count > 0)
                {
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    //Response.Write("<script>alert('Data Saved Successfully' )</script>");
                }
                else
                {
                    Response.Write("<script>alert('no transction found' )</script>");
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
        else if (sel == "custom")
        {
            Button1.Visible = true;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string mycon = "Server=localhost;Database=bank;Uid=root;Password= ;";
        MySqlConnection con = new MySqlConnection(mycon);
        MySqlCommand cmd = null;
        MySqlCommand cmd1 = null;
        DateTime now = DateTime.Now;
        string stdate = Request.Form.Get("stadate");
        string date = now.ToString("yyyy-MM-dd");
        string acnum = Label2.Text.ToString();

    }
}