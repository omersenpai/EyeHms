using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeHMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Eksik Veri");
            }
            else if (UNameTb.Text == "Admin" || PasswordTb.Text == "Password")
            {
                Form1 Obj = new Form1();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı adı veya şifre");
            }
        }
    }
}
