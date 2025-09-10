using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Users"] == null)
        {
            Session["Users"] = new Dictionary<string, User>();
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Dictionary<string, User> users = (Dictionary<string, User>)Session["Users"];
        string username = regUsername.Text.Trim();
        if (users.ContainsKey(username))
        {
            lblRegisterMessage.Text = "Username already exists!";
        }
        else
        {
            users.Add(username, new User
            {
                Username = username,
                Password = regPassword.Text,
                Email = regEmail.Text,
                FullName = regFullName.Text
            });
            Session["Users"] = users;
            lblRegisterMessage.Text = "Registration successful! You can now login.";
            regUsername.Text = "";
            regPassword.Text = "";
            regEmail.Text = "";
            regFullName.Text = "";
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Dictionary<string, User> users = (Dictionary<string, User>)Session["Users"];
        string username = loginUsername.Text.Trim();
        string password = loginPassword.Text;
        if (users.ContainsKey(username) && users[username].Password == password)
        {
            Session["CurrentUser"] = username;
            Response.Redirect("Products.aspx");
        }
        else
        {
            lblLoginMessage.Text = "Invalid username or password!";
        }
    }
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
}
