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
    public partial class ExceptionListenerForm : Form
    {
        public ExceptionListenerForm()
        {
            InitializeComponent();
        }
        public static void Alert(Exception ex)
        {

            MessageBox.Show(ex.Message + "\n" , "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ExceptionListenerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
