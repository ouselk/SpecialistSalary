using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecialistSalary
{
    public partial class adduserForm : Form
    {
        private Form parent;
        public adduserForm(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nametb.Text != String.Empty && passtb.Text != String.Empty)
            {
                BDManager bdm = new BDManager("users.db", "users");
                bdm.Insert(nametb.Text, CryptManager.SHA512(passtb.Text), "");
                MessageBox.Show("Пользователь успешно добавлен", "Успех!", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void adduser_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }
    }
}
