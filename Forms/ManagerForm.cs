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
    public partial class ManagerForm : Form
    {
        protected readonly Form parent;
        public ManagerForm(Form p)
        {
            InitializeComponent();
            parent = p;
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = DBController.GetAllFilms();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dict = DBController.GetTotalByFilm(((Film)comboBox1.SelectedItem).id);
            int tickets = (int)dict["Tickets"];
            double total = dict["Total"];
            textBox1.Text = tickets.ToString();
            textBox2.Text = total.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var source = new BindingSource();
            var start = dateTimePicker1.Value;
            var end = dateTimePicker2.Value;
            start.AddHours(-start.Hour);
            start.AddMinutes(-start.Minute);
            start.AddSeconds(-start.Second);

            end.AddHours(-end.Hour + 23);
            end.AddMinutes(-end.Minute + 59);
            end.AddSeconds(-end.Second + 59);

            source.DataSource = DBController.GetInfoByDate(start, end);
            dataGridView1.DataSource = source;
        }
       
    }
}
