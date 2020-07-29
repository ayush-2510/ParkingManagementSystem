using ParkingManagementClient.SlotService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingManagementClient
{
    public partial class managebooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            SlotService.SlotServiceClient client = new SlotService.SlotServiceClient();
            Booking1[] bookings = client.showAllBookings();
            Response.Write("<br /><div><h1  style='color:#dcdcdc;font-size:35px;text-align:center;'>BOOKINGS HISTORY</h1><br />");
            Response.Write("<center><table style='border:3px solid #fff;background:#dcdcdc;text-align:center;'>");
            Response.Write("<tr style='font-size:18px;'><th style='padding:10px 15px;'>Booking Id</th><th style='padding:10px 15px;'>User Id</th><th style='padding:10px 15px;'>Slot Id</th><th style='padding:10px 15px;'>Plate Number</th><th style='padding:10px 75px;'>Arrival Time</th><th style='padding:10px 75px;'>Exit Time</th></tr>");
            if (bookings == null) { Response.Write("<tr colspan='4'>You Haven't booked any slots yet</tr>"); }
            else
            {
                foreach (Booking1 b in bookings)
                {
                    Response.Write("<tr style='font-size:18px;'><td style='padding:10px 0px;'>" + b.BookingId + "</td><td style='padding:10px 0px;'>" +b.UserId+ "</td><td style='padding:10px 0px;'>" + b.SlotId + "</td><td style='padding:10px 0px;'>" + b.PlateNumber + "</td><td style='padding:10px 0px;'>"
                        + b.Arrival + "</td><td style='padding:10px 0px;'>" + b.Exit + "</td></tr>");
                }
            }
            Response.Write("</table></center></div></br>");
            Response.Write("<div><h1  style='color:#dcdcdc;font-size:35px;text-align:center;'>ACTIVE BOOKINGS</h1><br />");
            Response.Write("<center><table style='border:3px solid #fff;background:#dcdcdc;text-align:center;'>");
            Response.Write("<tr style='font-size:18px;'><th style='padding:10px 15px;'>Booking Id</th><th style='padding:10px 15px;'>User Id</th><th style='padding:10px 15px;'>Slot Id</th><th style='padding:10px 15px;'>Plate Number</th><th style='padding:10px 75px;'>Arrival Time</th><th style='padding:10px 75px;'>Exit Time</th></tr>");
            UserService.UserServiceClient client2 = new UserService.UserServiceClient();
            String[] users = client2.getUsers();
            foreach (string u in users) {
                
                Booking[] bookings1 = client.showBookings(Int32.Parse(u));
                if (bookings1 == null) { Response.Write("<tr colspan='4'>You Haven't booked any slots yet</tr>"); }
                else
                {
                    foreach (Booking b in bookings1)
                    {
                        Response.Write("<tr style='font-size:18px;'><td style='padding:10px 0px;'>" + b.BookingId + "</td><td style='padding:10px 0px;'>"+u+"</td><td style='padding:10px 0px;'>" + b.SlotId + "</td><td style='padding:10px 0px;'>" + b.PlateNumber + "</td><td style='padding:10px 0px;'>"
                            + b.Arrival + "</td><td style='padding:10px 0px;'>" + b.Exit + "</td></tr>");
                    }
                }
            }
            Response.Write("</table></center></div></br>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSlots.aspx");
        }
    }
}