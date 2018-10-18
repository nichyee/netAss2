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
    public partial class Login : Form
    {

        private const string path = @"login.txt";
        private List<User> userList;
        private TextEditor editorForm;
        private Register registerForm;

        public Login()
        {
            InitializeComponent();
            setupLogins();
        }

        private void setupLogins()
        {
            userList = new List<User>();
            string[] fileLines = new string[File.ReadAllLines(path).Length];
            fileLines = File.ReadAllLines(path);
            foreach (string line in fileLines)
            {
                string[] temp = new string[5];
                temp = line.Split(',');

                User user = new User(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5]);
                userList.Add(user);
            }

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int index = checkUserName();

            if (index >= 0 && checkPassword(index))
            {

                User user = userList[index];
                this.Hide();
                editorForm = new TextEditor(user);
                editorForm.Show();

            }
            else
            {
                string message = "Incorrect Username / Password";
                string caption = "Login Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        private bool checkPassword(int index)
        {
            string passwordString = passwordTextBox.Text.ToString();
            if (passwordString.Equals(userList[index].password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int checkUserName()
        {
            string userInput = userNameTextBox.Text.ToString();
            int index = -1;

            foreach (User user in userList)
            {
                if (userInput.Equals(user.userName))
                {
                    index = userList.IndexOf(user);
                }
            }
            return index;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerForm = new Register();
            registerForm.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
