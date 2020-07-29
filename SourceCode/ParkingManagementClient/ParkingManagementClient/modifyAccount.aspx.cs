using ParkingManagementClient.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingManagementClient
{
    public partial class modifyAccount : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Email"] = "ravan@gmail.com";
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack) { 
            UserService.UserServiceClient client = new UserService.UserServiceClient();
            User user = client.viewUser(Session["UserId"].ToString());
            TextBox1.Text = user.UserName;
            TextBox2.Text = user.Email;
            TextBox3.Text = user.Password;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UserService.UserServiceClient client = new UserService.UserServiceClient();
            client.deleteUser(Session["Email"].ToString());
            Session["UserId"] = null;
            Session["UserName"] = null;
            Session["Email"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User user1 = new User();
            user1.Email = TextBox2.Text;
            user1.Password = TextBox3.Text;
            user1.UserName = TextBox1.Text;
            //Response.Write(@"<script langauge='text/javascript'>alert('" +Session["Email"].ToString()+" " 
                                     //   + user1.UserName + " " + 
                                     //   user1.Password + " " + user1.Email +" ');</script>");
            UserService.UserServiceClient client = new UserService.UserServiceClient();
            client.updateUser(user1, Session["Email"].ToString());
            Session["UserName"] = user1.UserName;
            Session["Email"] = user1.Email;
            Response.Redirect(Request.RawUrl);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("Main.aspx");
        }
    }
}