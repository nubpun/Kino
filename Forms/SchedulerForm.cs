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
    public partial class SchedulerForm : Form
    {
        protected readonly Form parent;
        private void updateTable()
        {
            var halls = DBController.GetAllHalls();
            comboBox1.Items.Clear();
            foreach (var hall in halls)
            {
                comboBox1.Items.Add(hall);
            }
            comboBox1.Refresh();
            var films = DBController.GetAllFilms();

            comboBox2.Items.Clear();
            foreach (var film in films)
            {
                comboBox2.Items.Add(film);
            }
            comboBox2.Refresh();

            var source = new BindingSource();
            source.DataSource = DBController.GetSchedulersByDate(dateTimePicker1.Value);
            dataGridView1.DataSource = source;

            dataGridView1.Refresh();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        public SchedulerForm(Form p)
        {
            InitializeComponent();
            parent = p;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "HH:mm";

            updateTable();
        }

        private void SchedulerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DBController.AddFilm(textBox1.Text, Int32.Parse(textBox2.Text), richTextBox1.Text);
                MessageBox.Show("Фильм " + textBox1.Text + " успешно добавлен.");
                textBox1.Text = "";
                textBox2.Text = "";
                richTextBox1.Text = "";
            }
            catch (Exception ex)
            {
                ExceptionListenerForm.Alert(ex);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SchedulerForm_Load(object sender, EventArgs e)
        {
            

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            updateTable();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                var date = dateTimePicker1.Value;

                date = date.AddHours(-date.Hour);
                date = date.AddHours(dateTimePicker2.Value.Hour);
                date = date.AddMinutes(-date.Minute);
                date = date.AddMinutes(dateTimePicker2.Value.Minute);
                var film = ((Film)comboBox2.SelectedItem).id;
                var cost = Double.Parse(textBox5.Text);

                var hall = ((Hall)comboBox1.SelectedItem).id;
                
                DBController.AddSchedule(date, film, cost, hall);
            }
            catch (Exception ex)
            {
                ExceptionListenerForm.Alert(ex);
            }
            updateTable();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            updateTable();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            updateTable();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var sp = (SchedulePresent)e.Row.DataBoundItem;
            var id = sp.owner.id;
            DBController.DelSchedule(id);
        }
    }
}
