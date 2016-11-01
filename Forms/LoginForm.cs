using Kino.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino { 
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string curUser = ConnectionMaster.GetInstance().ReLogin(textBoxLogin.Text, textBoxPass.Text);
                switch (curUser)
                {
                    case "Менеджер":
                        new ManagerForm(this).Show();
                        Hide();
                        break;
                    case "Оператор":
                        new OperatorForm(this).Show();
                        break;
                    case "Диспетчер":
                        new SchedulerForm(this).Show();
                        Hide();
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                ExceptionListenerForm.Alert(ex);
            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
