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
    public partial class OperatorForm : Form
    {
        protected readonly Form parent;
        public OperatorForm(Form p)
        {
            InitializeComponent();
            parent = p;
        }

        private void OperatorForm_Load(object sender, EventArgs e)
        {
            var source = new BindingSource();            
            source.DataSource = DBController.GetSchedulersByDate(dateTimePicker1.Value);
            dataGridView1.DataSource = source;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var source = new BindingSource();
            source.DataSource = DBController.GetSchedulersByDate(dateTimePicker1.Value);
            dataGridView1.DataSource = source;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            BindingSource bs = (BindingSource)dgv.DataSource;
            List<SchedulePresent> schPresent = (List<SchedulePresent>)bs.List;
            int selectId = dgv.CurrentRow.Index;

            new HallForm(schPresent[selectId].owner).ShowDialog(this);
        }

        private void OperatorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Close();
        }
    }
}
