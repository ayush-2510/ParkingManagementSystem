using ParkingManagementClient.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ParkingManagementClient
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Email = TextBox3.Text;
            user.Password = TextBox2.Text;
            user.UserName = TextBox1.Text;
            UserService.UserServiceClient client = new UserService.UserServiceClient();
            client.registerUser(user);
            //Response.Write(@"<script langauge='text/javascript'>alert('You are registered successfully. Please login to access your account');</script>");
            User user1 = client.viewUser1(user.Email);
            Session["Email"] = user1.Email;
            Session["UserId"] = user1.Id;
            Session["UserName"] = user1.UserName;
            Response.Redirect("Main.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}