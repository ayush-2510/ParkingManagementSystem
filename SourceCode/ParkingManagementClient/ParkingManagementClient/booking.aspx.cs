using ParkingManagementClient.SlotService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingManagementClient
{
    public partial class booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            SlotService.SlotServiceClient client = new SlotService.SlotServiceClient();
            Booking[] bookings = client.showBookings(Convert.ToInt32(Session["UserId"]));
            Response.Write("<br /><div><h1  style='color:#dcdcdc;font-size:35px;text-align:center;'>MY BOOKINGS</h1><br />");
            Response.Write("</br><center><table style='border:3px solid #fff;background:#dcdcdc;text-align:center;'><tr><th colspan='5' style='padding:12px 10px;font-size:21px;'>Currently Active Bookings</th></tr>");
            Response.Write("<tr style='font-size:18px;'><th style='padding:10px 15px;'>Booking Id</th><th style='padding:10px 15px;'>Slot Id</th><th style='padding:10px 15px;'>Plate Number</th><th style='padding:10px 75px;'>Arrival Time</th><th style='padding:10px 75px;'>Exit Time</th></tr>");
            if (bookings == null) { Response.Write("<tr colspan='4'>You Haven't booked any slots yet</tr>"); }
            else
            {
                foreach (Booking b in bookings)
                {
                    Response.Write("<tr style='font-size:18px;'><td style='padding:10px 0px;'>" + b.BookingId + "</td><td style='padding:10px 0px;'>" + b.SlotId + "</td><td style='padding:10px 0px;'>" + b.PlateNumber + "</td><td style='padding:10px 0px;'>"
                        + b.Arrival + "</td><td style='padding:10px 0px;'>" + b.Exit + "</td></tr>");
                }
            }
            Response.Write("</table></center></div></br></br>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}