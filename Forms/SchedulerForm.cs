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
        public SchedulerForm(Form p)
        {
            InitializeComponent();
            parent = p;

            comboBox1.DataSource = DBController.GetAllHalls();

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "HH:mm";

            comboBox2.DataSource = DBController.GetAllFilms();

            var source = new BindingSource();
            source.DataSource = DBController.GetSchedulersByDate(dateTimePicker1.Value);
            dataGridView1.DataSource = source;
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
            var source = new BindingSource();
            source.DataSource = DBController.GetSchedulersByDate(dateTimePicker1.Value);
            dataGridView1.DataSource = source;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
