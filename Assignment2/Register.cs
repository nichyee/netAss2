using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Register : Form
    {
        private const string path = @"login.txt";
        private Login loginForm;

        public Register()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                if(passwordTextBox.Text.Equals(reenterPasswordTextBox.Text))
                {
                    User user = new User(usernameTextBox.Text, passwordTextBox.Text, userTypeComboBox.Text, firstNameTextBox.Text, lastNameTextBox.Text, dobPicker.Text);
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(user.ToString());
                    }
                    closeWindow();
                }
            } 
            else if (!validateForm())
            {
                string message = "Please check that fields are populated";
                string caption = "Register Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        private bool validateForm()
        {
            if (usernameTextBox.Text.Equals("") || passwordTextBox.Text.Equals("") || reenterPasswordTextBox.Text.Equals("") || firstNameTextBox.Text.Equals("") || lastNameTextBox.Text.Equals("") || dobPicker.Equals("") || userTypeComboBox.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            closeWindow();
        }

        private void closeWindow()
        {
            this.Close();
            loginForm = new Login();
            loginForm.Show();
        }

        private void PopulateComboBox()
        {
            userTypeComboBox.Items.Add("View");
            userTypeComboBox.Items.Add("Edit");
            userTypeComboBox.SelectedIndex = 0;
        }
    }
}
