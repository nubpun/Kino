using Kino.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.Forms
{
    public partial class HallForm : Form
    {
        protected readonly Form parent;
        public HallForm(Form p)
        {
            InitializeComponent();
            parent = p;
        }
        public HallForm(Schedule sch)
        {
            InitializeComponent();
            List<PlaceInHall> places = DBController.GetAllPlaceInHall(sch.hallId);
            foreach (PlaceInHall place in places)
            {
                Button button = new Button();
                button.Height = 50;
                button.Width = 100;
                
                button.Click += delegate (object sender, EventArgs e)
                {
                    DialogResult result = MessageBox.Show("Подтвердите билет:\n " + place.coordX.ToString() + " ряд\n " + place.coordY.ToString() + " место",
                        "Подтверждение", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            DBController.SailTicket(sch.id, place.placeInHall_id);
                            button.BackColor = Color.DarkSalmon;
                        }
                        catch (Exception ex)
                        {
                            ExceptionListenerForm.Alert(ex);
                        }
                    }
                };
                button.BackColor = Color.Azure;
                button.Text = "Место " + place.coordX.ToString() + ", " + place.coordY.ToString();                
                tableLayoutPanel1.Controls.Add(button, place.coordY - 1, place.coordX - 1);
            }

            List<Ticket> tickets = DBController.GetAllTicketsBySchedule(sch.id);
            foreach (Ticket ticket in tickets)
            {
                Button button = (Button)tableLayoutPanel1.GetControlFromPosition(ticket.y - 1, ticket.x - 1);
                button.BackColor = Color.DarkSalmon;
            }

        }        
        private void HallForm_Load(object sender, EventArgs e)
        {

        }
    }
}
