using RMWManagement.admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMWManagement.employees
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            openChildForm(new Projects());
        }

        private void btnReview_Click_1(object sender, EventArgs e)
        {
            openChildForm(new WorkReview());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnHours_Click(object sender, EventArgs e)
        {
            openChildForm(new WorkingHours());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            openChildForm(new Settings());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            openChildForm(new AddUser());
        }
    }
}
