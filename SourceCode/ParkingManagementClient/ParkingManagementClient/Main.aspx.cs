using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingManagementClient
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack) {
                SlotService.SlotServiceClient client = new SlotService.SlotServiceClient();
                String[] section = client.available_section();
                DropDownList1.Items.Add("--- Select section ---");
                DropDownList2.Items.Add("--- Available floors ---");
                DropDownList3.Items.Add("--- Type of Vehicles ---");
                foreach (string i in section) { DropDownList1.Items.Add(i); }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SlotService.SlotServiceClient slotService = new SlotService.SlotServiceClient();
            //Label1.Text = TextBox5.Text + TextBox6.Text;
            DateTime arrival = DateTime.Parse(TextBox5.Text + " " + TextBox6.Text);
            DateTime exit = DateTime.Parse(TextBox7.Text + " " + TextBox8.Text);
            SlotService.bookingResult booked = slotService.bookSlot(DropDownList1.Text, Convert.ToInt32(DropDownList2.Text), DropDownList3.Text, Convert.ToInt32(Session["UserId"]), TextBox4.Text, arrival, exit);
            if (booked.Booking_Id == -1) {
                Label1.Text = "No slots are available right now for given selection";
            }
            else if (booked.Booking_Id == -2) {
                Label1.Text = "Arrival time and Exit time is Inappropriate";
            }
            else {
                Label1.Text = "Your Booking ID is: " + booked.Booking_Id.ToString() + " Open My Bookings to know more";
            } 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SlotService.SlotServiceClient slotService = new SlotService.SlotServiceClient();
            int result = slotService.cancelBooking(Convert.ToInt32(TextBox9.Text), Convert.ToInt32(Session["UserId"]));
            if (result == -4) {
                Label2.Text = "Cannot Cancel Booking,It is within 30 minutes from now " + result.ToString();
            }
            else if (result == 1)
            {
                Label2.Text = "Cancellation Successful";
            }
            else {
                Label2.Text = "Unknown Error. Error code: " + result.ToString();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44301/modifyAccount.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Session["UserName"] = null;
            Session["UserId"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SlotService.SlotServiceClient client = new SlotService.SlotServiceClient();
            DropDownList2.Items.Clear();
            int[] floor = client.available_floor(DropDownList1.SelectedValue);
            DropDownList2.Items.Add("--- Available floors ---");
            foreach (int j in floor) { DropDownList2.Items.Add(j + ""); }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SlotService.SlotServiceClient client = new SlotService.SlotServiceClient();
            DropDownList3.Items.Clear();
            string[] type = client.available_type(DropDownList1.SelectedValue,Int32.Parse(DropDownList2.SelectedValue));
            DropDownList3.Items.Add("--- Type of Vehicles ---");
            foreach (string z in type) { DropDownList3.Items.Add(z); }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("booking.aspx");
        }
    }
}