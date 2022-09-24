using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RMWManagement.employees
{
    public partial class Login : Form
    {

        MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter mda = new MySqlDataAdapter();

        DataTable dtb = new DataTable();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public string combinedString;
        public string status;
        public string connstring = @"C:\RMWManagement\connection.txt";

        public Login()
        {
            InitializeComponent();
            checkconnection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void checkconnection()
        {
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = combinedString;
                con.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Opss.. There was an error with the message: " + ex.Message + "please contact the developer of the program!", "Connection Error", buttons, MessageBoxIcon.Error);
                button1.Enabled = true;
            }
        }

        private void login()
        {
            string query = "select email,password,status from users where email='"+txtUsername.Text+"' password='" + txtPassword.Text + "'";


            con = new MySqlConnection();
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(connstring).ToList();
            string combinedString = string.Join(",", lines);
            con.ConnectionString = combinedString;

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MainPage mp = new MainPage();
                        mp.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Wrong password!", "Error", buttons, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                // MessageBox.Show("Something Went Wrong!", "Error", buttons, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
             }
        } 
    }
}
