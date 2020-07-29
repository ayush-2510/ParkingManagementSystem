using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingManagementClient
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null) {
                Response.Redirect("Main.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            string pass = TextBox2.Text;
            if (email == "admin@gmail.com" && pass == "admin") {
                Session["UserId"] = "1004";
                Session["UserName"] = "admin";
                Session["Email"] = "admin@gmail.com";
                Response.Redirect("ManageSlots.aspx");
            }
            UserService.UserServiceClient userService = new UserService.UserServiceClient();
            UserService.User user = userService.loginUser(email, pass);
            if (user.Id == -1)
            {
                Label1.Text = "Incorrect Credentials";
            }
            else
            {
                Session["UserId"] = user.Id.ToString();
                Session["UserName"] = user.UserName;
                Session["Email"] = user.Email;
                Response.Redirect("Main.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }
    }
}