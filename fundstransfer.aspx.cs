using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class fundstransfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Session["username"].ToString();
        string pass = Session["pass"].ToString();
        string mycon = "Server=localhost;Database=bank;Uid=root;Password= ;";
        MySqlConnection con = new MySqlConnection(mycon);
        MySqlCommand cmd = null;
        try
        {
            // string query = "select * from client where username="+name+" and password="+pass;
            cmd = new MySqlCommand("select * from client where username=@username and password=@pass", con);
            cmd.Parameters.AddWithValue("@username", name);
            cmd.Parameters.AddWithValue("@pass", pass);
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                Label1.Text = Session["username"].ToString();
                Label2.Text = dt.Rows[0]["accountnum"].ToString();
                Label3.Text = dt.Rows[0]["accounttype"].ToString();
                Label4.Text = dt.Rows[0]["totalamount"].ToString();
                if (dt.Rows[0]["accounttype"].ToString() == "current account")
                {
                    submit0.Text = "Transfeer to saving account";
                }
                else
                {
                    submit0.Text = "Transfeer to current account";
                }
                    
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
    protected void submit_Click(object sender, EventArgs e)
    {
        string mycon = "Server=localhost;Database=bank;Uid=root;Password= ;";
        MySqlConnection con = new MySqlConnection(mycon);
        MySqlCommand cmd = null;
        MySqlCommand cmd1 = null;
        MySqlCommand cmd2 = null;
        MySqlCommand cmd3 = null;


        string accnum = Label2.Text.ToString();
        DateTime now = DateTime.Now;
        string currentamount = Label4.Text.ToString();
        double totamount = Convert.ToDouble(currentamount); 
        string date = now.ToString("yyyy-MM-dd");
        string accountto = Request.Form.Get("accnum");
        string amount = Request.Form.Get("Amount");
        double am = Convert.ToDouble(amount);
        double demo,demo2;
        string currency = Request.Form.Get("user_age");
        if (!this.checkaccount(accountto))
        {
            Response.Write("<script>alert('incorrect account to transfer')</script>");
        }
        else
        {
            if (currency == "GBP")
            {
                if (am > totamount)
                {
                    Response.Write("<script>alert('fund cannot transfer insufficent balance')</script>");
                }
                else
                {
                    demo = totamount - am;
                    demo2 = am;
                    try
                    {
                        cmd = new MySqlCommand("INSERT INTO transcations(fromacc, toacc, date, amount, currency)VALUES (@fromacc,@toacc,@date,@amount,@currency)", con);
                        cmd.Parameters.AddWithValue("@fromacc", accnum);
                        cmd.Parameters.AddWithValue("@toacc", accountto);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@currency", currency);
                        cmd1 = new MySqlCommand("UPDATE client SET totalamount=@amo WHERE accountnum=@acc", con);
                        cmd1.Parameters.AddWithValue("@amo", demo);
                        cmd1.Parameters.AddWithValue("@acc", accnum);
                        cmd3 = new MySqlCommand("SELECT * FROM client WHERE accountnum=@accunt", con);
                        cmd3.Parameters.AddWithValue("@accunt", accountto);
                        DataTable dt = new DataTable();
                        con.Open();
                        dt.Load(cmd3.ExecuteReader());
                        string am1 = dt.Rows[0]["totalamount"].ToString();
                        double plsam = Convert.ToDouble(am1);
                        demo2 = plsam + demo2;
                        con.Close();
                        
                        cmd2 = new MySqlCommand("UPDATE client SET totalamount=@amo WHERE accountnum=@acc", con);
                        cmd2.Parameters.AddWithValue("@amo", demo2);
                        cmd2.Parameters.AddWithValue("@acc", accountto);

                        Response.Write("<script>alert('fund transfer successfully')</script>");
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        

                        cmd2.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('fund transfer successfully')</script>");
                        
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert(' " + ex.Message + "')</script>");
                        con.Close();
                        return;
                    }
                }
            }
            else if (currency == "USdollar")
            {
                double gbp = am * 0.800;
                if (gbp > totamount)
                {
                    Response.Write("<script>alert('fund cannot transfer insufficent balance')</script>");
                }
                else
                {
                    demo = totamount - gbp;
                    try
                    {
                        cmd = new MySqlCommand("INSERT INTO transcations(fromacc, toacc, date, amount, currency)VALUES (@fromacc,@toacc,@date,@amount,@currency)", con);
                        cmd.Parameters.AddWithValue("@fromacc", accnum);
                        cmd.Parameters.AddWithValue("@toacc", accountto);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@currency", currency);
                        cmd1 = new MySqlCommand("UPDATE client SET totalamount=@amo WHERE accountnum=@acc", con);
                        cmd1.Parameters.AddWithValue("@amo", demo);
                        cmd1.Parameters.AddWithValue("@acc", accnum);
                        cmd3 = new MySqlCommand("SELECT * FROM client WHERE accountnum=@accunt", con);
                        cmd3.Parameters.AddWithValue("@accunt", accountto);
                        DataTable dt = new DataTable();
                        con.Open();
                        dt.Load(cmd3.ExecuteReader());
                        string am1 = dt.Rows[0]["totalamount"].ToString();
                        double plsam = Convert.ToDouble(am1);
                        demo2 = plsam + gbp;
                        con.Close();
                        cmd2 = new MySqlCommand("UPDATE client SET totalamount=@amo WHERE accountnum=@acc", con);
                        cmd2.Parameters.AddWithValue("@amo", demo2);
                        cmd2.Parameters.AddWithValue("@acc", accountto);
                        Response.Write("<script>alert('fund transfer successfully')</script>");
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('fund transfer successfully')</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert(' " + ex.Message + "')</script>");
                        con.Close();
                        return;
                    }
                }

            }
            else if (currency == "EURO")
            {
                double gbp = am * 0.8425;
                if (gbp > totamount)
                {
                    Response.Write("<script>alert('fund cannot transfer insufficent balance')</script>");
                }
                else
                {
                    demo = totamount - gbp;
                    try
                    {
                        cmd = new MySqlCommand("INSERT INTO transcations(fromacc, toacc, date, amount, currency)VALUES (@fromacc,@toacc,@date,@amount,@currency)", con);
                        cmd.Parameters.AddWithValue("@fromacc", accnum);
                        cmd.Parameters.AddWithValue("@toacc", accountto);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@currency", currency);
                        cmd1 = new MySqlCommand("UPDATE client SET totalamount=@amo WHERE accountnum=@acc", con);
                        cmd1.Parameters.AddWithValue("@amo", demo);
                        cmd1.Parameters.AddWithValue("@acc", accnum);
                        cmd3 = new MySqlCommand("SELECT * FROM client WHERE accountnum=@accunt", con);
                        cmd3.Parameters.AddWithValue("@accunt", accountto);
                        DataTable dt = new DataTable();
                        con.Open();
                        dt.Load(cmd3.ExecuteReader());
                        string am1 = dt.Rows[0]["totalamount"].ToString();
                        double plsam = Convert.ToDouble(am1);
                        demo2 = plsam + gbp;
                        con.Close();
                        cmd2 = new MySqlCommand("UPDATE client SET totalamount=@amo WHERE accountnum=@acc", con);
                        cmd2.Parameters.AddWithValue("@amo",demo2);
                        cmd2.Parameters.AddWithValue("@acc", accountto);
                        Response.Write("<script>alert('fund transfer successfully')</script>");
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('fund transfer successfully')</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert(' " + ex.Message + "')</script>");
                        con.Close();
                        return;
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('please select proper currency')</script>");
            }
        }
    }

    protected void submit0_Click(object sender, EventArgs e)
    {
        string mycon = "Server=localhost;Database=bank;Uid=root;Password= ;";
        MySqlConnection con = new MySqlConnection(mycon);
        MySqlCommand cmd = null;
        MySqlCommand cmd1 = null;
        MySqlCommand cmd2 = null;
        MySqlCommand cmd3 = null;

        string accnum = Label2.Text.ToString();
        string uname = Label1.Text.ToString();
        DateTime now = DateTime.Now;
        string currentamount = Label4.Text.ToString();
        double totamount = Convert.ToDouble(currentamount);
        string date = now.ToString("yyyy-MM-dd");
        string accountto = Request.Form.Get("accnum");
        string amount = Request.Form.Get("Amount");
        double am = Convert.ToDouble(amount);
        double demo, demo2;
        string currency = Request.Form.Get("user_age");
        string name = Label1.Text.ToString();
        string type = Label3.Text.ToString();
        if(type == "current account")
        {
            type = "saving account";
        }
        else
        {
            type = "current account";
        }
       
            if (currency == "GBP")
            {
                if (am > totamount)
                {
                    Response.Write("<script>alert('fund cannot transfer insufficent balance')</script>");
                }
                else
                {
                    demo = totamount - am;
                    demo2 = am;
                    try
                    {
                        cmd = new MySqlCommand("INSERT INTO transcations(fromacc, toacc, date, amount, currency)VALUES (@fromacc,@toacc,@date,@amount,@currency)", con);
                        cmd.Parameters.AddWithValue("@fromacc", accnum);
                        cmd.Parameters.AddWithValue("@toacc", type);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@currency", currency);
                        cmd1 = new MySqlCommand("UPDATE client SET totalamount=@amo WHERE accountnum=@acc", con);
                        cmd1.Parameters.AddWithValue("@amo", demo);
                        cmd1.Parameters.AddWithValue("@acc", accnum);
                        cmd3 = new MySqlCommand("SELECT * FROM client WHERE accounttype=@accunt and username=@usname", con);
                    cmd3.Parameters.AddWithValue("@accunt", type);

                    cmd3.Parameters.AddWithValue("@usname",uname);
                        DataTable dt = new DataTable();
                        con.Open();
                        dt.Load(cmd3.ExecuteReader());
                        string am1 = dt.Rows[0]["totalamount"].ToString();
                        double plsam = Convert.ToDouble(am1);
                        demo2 = plsam + demo2;
                        con.Close();
                        cmd2 = new MySqlCommand("UPDATE client SET totalamount=@amo WHERE accounttype=@acc and username=@usern", con);
                        cmd2.Parameters.AddWithValue("@usern", uname);
                        cmd2.Parameters.AddWithValue("@amo", demo2);
                        cmd2.Parameters.AddWithValue("@acc",type);
                        Response.Write("<script>alert('fund transfer successfully')</script>");
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('fund transfer successfully')</script>");

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert(' " + ex.Message + "')</script>");
                        con.Close();
                        return;
                    }
                }
            }
            else if (currency == "USdollar")
            {
                double gbp = am * 0.800;
                if (gbp > totamount)
                {
                    Response.Write("<script>alert('fund cannot transfer insufficent balance')</script>");
                }
                else
                {
                    demo = totamount - gbp;
                    try
                    {
                        cmd = new MySqlCommand("INSERT INTO transcations(fromacc, toacc, date, amount, currency)VALUES (@fromacc,@toacc,@date,@amount,@currency)", con);
                        cmd.Parameters.AddWithValue("@fromacc", accnum);
                        cmd.Parameters.AddWithValue("@toacc", accountto);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@currency", currency);
                        cmd1 = new MySqlCommand("UPDATE client SET totalamount=@amo WHERE accountnum=@acc", con);
                        cmd1.Parameters.AddWithValue("@amo", demo);
                        cmd1.Parameters.AddWithValue("@acc", accnum);
                        cmd3 = new MySqlCommand("SELECT * FROM client WHERE accounttype=@accunt and username=@usanme", con);
                        cmd3.Parameters.AddWithValue("@accunt", type);
                    cmd3.Parameters.AddWithValue("@usanme", uname);

                    DataTable dt = new DataTable();
                        con.Open();
                        dt.Load(cmd3.ExecuteReader());
                        string am1 = dt.Rows[0]["totalamount"].ToString();
                        double plsam = Convert.ToDouble(am1);
                        demo2 = plsam + gbp;
                        con.Close();
                        cmd2 = new MySqlCommand("UPDATE client SET totalamount=@amo WHERE accounttype=@accunt and username=@usanme", con);
                        cmd2.Parameters.AddWithValue("@amo", demo2);
                        cmd2.Parameters.AddWithValue("@accunt", type);
                    cmd2.Parameters.AddWithValue("@usanme", uname);

                    Response.Write("<script>alert('fund transfer successfully')</script>");
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('fund transfer successfully')</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert(' " + ex.Message + "')</script>");
                        con.Close();
                        return;
                    }
                }

            }
            else if (currency == "EURO")
            {
                double gbp = am * 0.8425;
                if (gbp > totamount)
                {
                    Response.Write("<script>alert('fund cannot transfer insufficent balance')</script>");
                }
                else
                {
                    demo = totamount - gbp;
                    try
                    {
                        cmd = new MySqlCommand("INSERT INTO transcations(fromacc, toacc, date, amount, currency)VALUES (@fromacc,@toacc,@date,@amount,@currency)", con);
                        cmd.Parameters.AddWithValue("@fromacc", accnum);
                        cmd.Parameters.AddWithValue("@toacc", accountto);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@currency", currency);
                        cmd1 = new MySqlCommand("UPDATE client SET totalamount=@amo WHERE accountnum=@acc", con);
                        cmd1.Parameters.AddWithValue("@amo", demo);
                        cmd1.Parameters.AddWithValue("@acc", accnum);
                        cmd3 = new MySqlCommand("SELECT * FROM client WHERE ccounttype=@accunt and username=@usanme", con);
                        cmd3.Parameters.AddWithValue("@accunt", type);

                    cmd3.Parameters.AddWithValue("@usanme", uname);
                        DataTable dt = new DataTable();
                        con.Open();
                        dt.Load(cmd3.ExecuteReader());
                        string am1 = dt.Rows[0]["totalamount"].ToString();
                        double plsam = Convert.ToDouble(am1);
                        demo2 = plsam + gbp;
                        con.Close();
                        cmd2 = new MySqlCommand("UPDATE client SET totalamount=@amo WHERE accountnum=@acc", con);
                        cmd2.Parameters.AddWithValue("@amo", demo2);
                        cmd2.Parameters.AddWithValue("@acc", accountto);
                        Response.Write("<script>alert('fund transfer successfully')</script>");
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('fund transfer successfully')</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert(' " + ex.Message + "')</script>");
                        con.Close();
                        return;
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('please select proper currency')</script>");
            }
        

    }
     Boolean checkaccount(string num)
    {
        string mycon = "Server=localhost;Database=bank;Uid=root;Password= ;";
        MySqlConnection con = new MySqlConnection(mycon);
        MySqlCommand cmd = null;
        try
        {
            cmd = new MySqlCommand("SELECT * FROM client WHERE accountnum=@accunt", con);
            cmd.Parameters.AddWithValue("@accunt", num);
            DataTable dt = new DataTable();
           
            con.Open();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                return true;
                con.Close();
            }
            else
            {
                con.Close();
                return false;
            }
            
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert(' " + ex.Message + "')</script>");
            con.Close();
            return false;
        }

        
    }
}