using ParkingManagementClient.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingManagementClient
{
    public partial class viewusers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Response.Write("<br /><div><h1  style='color:#dcdcdc;font-size:35px;text-align:center;'>ADMIN PANEL</h1><br />");

            UserService.UserServiceClient client = new UserService.UserServiceClient();
            string[] users = client.getUsers();
            Response.Write("<center><table style='border:3px solid #fff;background:#dcdcdc;text-align:center;'><tr><th colspan='3' style='padding:12px 10px;font-size:21px;'>END USER DETAILS</th></tr>");
            Response.Write("<tr style='font-size:18px;'><th style='padding:12px 20px;'>User Id</th><th style='padding:12px 20px;'>User Name</th><th style='padding:12px 80px;'>Email Address</th>");
                 
            foreach (string u in users)
            {
                User b = client.viewUser(u);
                Response.Write("<tr style='font-size:18px;'><td style='padding:10px 0px;'>" + b.Id + "</td><td style='padding:10px 0px;'>" + b.UserName + "</td><td style='padding:10px 0px;'>" + b.Email + "</td></tr>");
            }
            
            Response.Write("</table></center></div></br></br>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSlots.aspx");
        }
    }
}