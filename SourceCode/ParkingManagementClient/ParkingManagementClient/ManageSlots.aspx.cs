using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingManagementClient
{
    public partial class ManageSlots : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["UserName"].ToString() != "admin") {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                SlotService.SlotServiceClient client1 = new SlotService.SlotServiceClient();
                String[] section = client1.available_section();
                DropDownList5.Items.Add("--- Select section ---");
                DropDownList2.Items.Add("--- Available floors ---");
                DropDownList4.Items.Add("--- Type of Vehicles ---");
                foreach (string i in section) { DropDownList5.Items.Add(i); }
            }
            Response.Write("<br /><h1 style='text-align:center; color:#dcdcdc;font-size:35px;'>ADMIN PANEL</h1>");
            SlotService.SlotServiceClient client = new SlotService.SlotServiceClient();
            String[] sections = client.available_section();
            Response.Write("<div style='float:left;margin:1% 8% 0% 12%'><table border='1' style='border-collapse: collapse;background:#dcdcdc;'><th style='text-align:center;font-size:24px;padding:10px;' colspan='2' >SLOT DETAILS</th>");
            foreach (string i in sections)
            {
                int[] floor = client.available_floor(i);
                Response.Write("<tr><td colspan='2' style='text-align:center;font-size:19px;padding:10px;'>SECTION : "+ i +"</td></tr>");
                foreach (int j in floor) {
                    string[] type = client.available_type(i,j);
                    Response.Write("<tr><td rowspan = '"+type.Length+ "' style='font-size:16px;padding:8px 22px'>Floor : " + j + "</td>");
                    foreach (string z in type) {
                        int count = client.showAllSlots(i,j,z);
                        Response.Write("<td style='font-size:16px;padding:8px 22px'>" + z+" : "+count+"</td></tr>");
                    }
                }
            }Response.Write("</table></div>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string section, type;
            int amount, normalcharges, overtimecharges, floor;
            section = TextBox1.Text;
            type = DropDownList3.SelectedValue;
            normalcharges = Int32.Parse(TextBox3.Text);
            overtimecharges = Int32.Parse(TextBox4.Text);
            amount = Int32.Parse(TextBox5.Text);
            floor = Int32.Parse(DropDownList1.SelectedValue);
            SlotService.SlotServiceClient client = new SlotService.SlotServiceClient();
            int count = client.addSlots(section,floor,type,normalcharges,overtimecharges,amount);
            //Response.Write(@"<script langauge='text/javascript'>alert('" + count + " Slots added successfully');</script>");
            Response.Redirect(Request.RawUrl);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string section, type;
            int amount, floor;
            section =DropDownList5.SelectedValue;
            type =DropDownList4.SelectedValue;
            floor = Int32.Parse(DropDownList2.SelectedValue);
            amount =Int32.Parse(TextBox8.Text);
            SlotService.SlotServiceClient client = new SlotService.SlotServiceClient();
            int count = client.removeSlots(section, floor, type, amount);
            //Response.Write(@"<script langauge='text/javascript'>alert('"+ count +" Slots deleted successfully');</script>");
            if (count == -2) { Label1.Text = "Slots are booked cannot be deleted"; } 
            else { Label1.Text = count+" slots deleted successfully"; Response.Redirect(Request.RawUrl); }
           
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Session["UserName"] = null;
            Session["UserId"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("modifyAccount.aspx");
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SlotService.SlotServiceClient client = new SlotService.SlotServiceClient();
            DropDownList4.Items.Clear();
            string[] type = client.available_type(DropDownList5.SelectedValue, Int32.Parse(DropDownList2.SelectedValue));
            DropDownList4.Items.Add("--- Type of Vehicles ---");
            foreach (string z in type) { DropDownList4.Items.Add(z); }
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SlotService.SlotServiceClient client = new SlotService.SlotServiceClient();
            DropDownList2.Items.Clear();
            int[] floor = client.available_floor(DropDownList5.SelectedValue);
            DropDownList2.Items.Add("--- Available floors ---");
            foreach (int j in floor)
            {
                DropDownList2.Items.Add(j + "");
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("managebooking.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewusers.aspx");
        }
    }
}