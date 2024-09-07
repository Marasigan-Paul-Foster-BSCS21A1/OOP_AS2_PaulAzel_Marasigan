using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public class User
        {
            public string Juser { get; set; }
            public string Jpass { get; set; }
        }


        private List<User> users = new List<User>();

        public Form1()
        {
            InitializeComponent();
            LoadUsersFromJson();
        }


        private void LoadUsersFromJson()
        {
            try
            {

                string jsonFilePath = "users.json"; 


                string jsonData = File.ReadAllText(jsonFilePath);
                users = JsonConvert.DeserializeObject<List<User>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }


        private void button_login_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;


            bool isAuthenticated = false;
            foreach (var u in users)
            {
                if (u.Juser == user && u.Jpass == pass)
                {
                    isAuthenticated = true;
                    break;
                }
            }

            if (isAuthenticated)
            {
                MessageBox.Show("Login Successfully");
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
