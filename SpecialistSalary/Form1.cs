using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SpecialistSalary
{
    public partial class autForm : Form
    {
        private string adminPass = "C7AD44CBAD762A5DA0A452F9E854FDC1E0E7A52A38015F23F3EAB1D80B931DD472634DFAC71CD34EBC35D16AB7FB8A90C81F975113D6C7538DC69DD8DE9077EC";
        public autForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            BDManager bdm = new BDManager("users.db", "users");
            if (nameBox.Text.Trim() == "" || passBox.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string name = nameBox.Text.Trim();
                string pass = passBox.Text.Trim();
                string hashed = CryptManager.SHA512(pass);
                if (name == "admin" && hashed == adminPass)
                {
                    Form ws = new workForm(this, true);
                    ws.Show();
                    this.Hide();
                }
                else
                {
                    DataTable dt = bdm.SelectWhere("name = '" + name + "' AND pass = '" + hashed + "'");
                    if (dt.Rows.Count > 0)
                    {
                        Form ws = new workForm(this, false);
                        ws.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Пользователя с таким логином и паролем не существует.", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            }

    }
}
