using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManagementGateKeeper
{
    public partial class Form1 : Form
    {
        int paymentId;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SlotService.SlotServiceClient slotService = new SlotService.SlotServiceClient();
            SlotService.exitResult exit =  slotService.exitVehicle(Convert.ToInt32(textBox1.Text), DateTime.Now);
            if (exit.paymentId == -1)
            {
                label8.Text = "Error in Searching Booking ID";
            }
            else if (exit.paymentId == -2) {
                label8.Text = "Booking Id does not exist";
            }
            else
            {
                label7.Text = exit.Cost.ToString();
                paymentId = Convert.ToInt32(exit.paymentId);
                button1.Enabled = false;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SlotService.SlotServiceClient slotService = new SlotService.SlotServiceClient();
            slotService.makePayment(paymentId, comboBox1.SelectedItem.ToString());
            label10.Text = "Booking Ended for Id: "+textBox1.Text;
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            label7.Text = "";
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
