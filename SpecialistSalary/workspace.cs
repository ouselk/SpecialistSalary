using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SpecialistSalary
{
    public partial class workForm : Form
    {
        private BDManager bdmSpec;
        private Form callingFrom;
        private bool admin;
        public workForm(Form parent, bool admin)
        {
            bdmSpec = new BDManager("spec.db", "specialists");
            callingFrom = parent;
            this.admin = admin;
            InitializeComponent();
        }


        private void workForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt = bdmSpec.executeAndReturnDT("SELECT id, full_name, department_name FROM specialists");
            FileManager.WriteStringToBinaryFile(FileManager.dtToString(dt), "specialists.bin");

            dt = bdmSpec.executeAndReturnDT("SELECT specialist_id, month, salary FROM salaries");
            FileManager.WriteStringToBinaryFile(FileManager.dtToString(dt), "salaries.bin");

            dt = bdmSpec.executeAndReturnDT("SELECT id, full_name, department_name, salary FROM specsalaries");
            FileManager.WriteStringToBinaryFile(FileManager.dtToString(dt), "specsalaries.bin");
            callingFrom.Close();

            bdmSpec.executeAndReturnDT("DELETE FROM salaries");
            bdmSpec.executeAndReturnDT("DELETE FROM specsalaries");
            bdmSpec.executeAndReturnDT("DELETE FROM specialists");
        }

        private void workForm_Load(object sender, EventArgs e)
        {
            if (!admin)
                adduserBtn.Visible = false;
            monthenterBox.Visible = false;
            monthenterLB.Visible  = false;
            string query = "CREATE TABLE IF NOT EXISTS specialists( " +
                            "id    INTEGER, " +
                            "full_name TEXT, " +
                            "department_name   TEXT, " +
                            "PRIMARY KEY(id) " +
                            ")";
            bdmSpec.executeAndReturnDT(query);
            DataTable dt;
            try
            {
                dt = FileManager.stringToDt(FileManager.ReadStringFromBinaryFile("specialists.bin"));
            } catch (FileNotFoundException)
            {
                FileManager.WriteStringToBinaryFile("id;full_name;department_name;\n", "specialists.bin");
                dt = FileManager.stringToDt(FileManager.ReadStringFromBinaryFile("specialists.bin"));
            }
            bdmSpec.InsertDataTableToSQLite(dt, "specialists");

            query = "CREATE TABLE IF NOT EXISTS salaries( " +
                    "specialist_id INTEGER, " +
                    "month INTEGER, " +
                    "salary    INTEGER, " +
                    "FOREIGN KEY(specialist_id) REFERENCES specialists(id)" +
                    ")";
            bdmSpec.executeAndReturnDT(query);
            try
                {
                dt = FileManager.stringToDt(FileManager.ReadStringFromBinaryFile("salaries.bin"));
            } catch(FileNotFoundException)
            {
                FileManager.WriteStringToBinaryFile("specialist_id;month;salary\n", "salaries.bin");
                dt = FileManager.stringToDt(FileManager.ReadStringFromBinaryFile("salaries.bin"));
            }
            bdmSpec.InsertDataTableToSQLite(dt, "salaries");

            query = "CREATE TABLE IF NOT EXISTS specsalaries(id INTEGER AUTO_INCREMENT PRIMARY KEY, full_name TEXT, department_name TEXT, salary DECIMAL INTEGER )";
            bdmSpec.executeAndReturnDT(query);
            try
            {
                dt = FileManager.stringToDt(FileManager.ReadStringFromBinaryFile("specsalaries.bin"));
            } catch(FileNotFoundException)
            {
                FileManager.WriteStringToBinaryFile("id;full_name;department_name;salary\n", "specsalaries.bin");
                dt = FileManager.stringToDt(FileManager.ReadStringFromBinaryFile("specsalaries.bin"));
            }
            bdmSpec.InsertDataTableToSQLite(dt, "specsalaries");

            dataGridView1.DataSource = bdmSpec.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string depName = textBox1.Text;
            int month = listBox1.SelectedIndex + 1;

            if (depName == string.Empty || depName == "Введите название отдела" || month == 0)
                return;

            string query = "SELECT s.full_name as 'ФИО' , s.department_name as 'Отдел', sa.salary AS '" + "Зарплата за " + month.ToString() + "-й месяц' " +
                            "FROM specialists s " +
                            "JOIN salaries sa ON sa.specialist_id = s.id " +
                            $"WHERE sa.month = {month} AND s.department_name = '{depName}'";

            DataTable dt = bdmSpec.executeAndReturnDT(query);

            dataGridView1.DataSource = dt;
            int amountPayments = 0;
            foreach (DataRow row in dt.Rows)
            {
                amountPayments += Int32.Parse(row[2].ToString());
            }

            amountpayLabel.Text = $"Выплаты за {month.ToString()}-й месяц для отдела {depName}: {amountPayments.ToString()}";
            try
            {
                averagepayLabel.Text = $"Средняя выплата за {month.ToString()}-й месяц для отдела {depName}: {(amountPayments / dt.Rows.Count).ToString()}";
            } catch (DivideByZeroException)
            {
                averagepayLabel.Text = $"Средняя выплата за {month.ToString()}-й месяц для отдела {depName}: 0";

            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите название отдела")
                textBox1.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string query  = "INSERT INTO specsalaries(id, full_name, department_name, salary) " +
                            "SELECT specialists.id, specialists.full_name as 'ФИО', specialists.department_name as 'Отдел', sum(salaries.salary) as 'Сумма выплат' " +
                            "FROM specialists " +
                            "JOIN salaries ON specialists.id = salaries.specialist_id " +
                            "GROUP by specialist_id;";
            try
            {
                bdmSpec.executeAndReturnDT(query);
            } catch {
                bdmSpec.executeAndReturnDT("DELETE FROM specsalaries");
                bdmSpec.executeAndReturnDT(query);
            }
            query = "SELECT full_name as 'ФИО', department_name as 'Отдел', salary as 'Зарплата' FROM specsalaries";
            DataTable dt = bdmSpec.executeAndReturnDT(query);
            dataGridView1.DataSource = dt;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string fio = fioTb.Text;
            if (fio == "Введите ФИО")
                fio = "";
            string id = "";
            string query = "";
            try
            {
                id = bdmSpec.executeAndReturnDT($"SELECT id FROM specialists WHERE full_name='{fio}'").Rows[0][0].ToString();
                query = "DELETE FROM specsalaries " +
                                $"WHERE full_name = '{fio}'";
            }
            catch { MessageBox.Show("Не удалось совешрить запрос. Проверьте корректность данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            try
            {
                bdmSpec.executeAndReturnDT(query);
            }
            catch{MessageBox.Show("Не удалось совешрить запрос. Проверьте корректность данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);}

            query = $"DELETE FROM specialists WHERE full_name = '{fio}'";
            try
            {
                bdmSpec.executeAndReturnDT(query);
            }
            catch { MessageBox.Show("Не удалось совешрить запрос. Проверьте корректность данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


            query = $"DELETE FROM salaries WHERE specialist_id = '{id}'";
            try
            {
                bdmSpec.executeAndReturnDT(query);
            }
            catch { MessageBox.Show("Не удалось совешрить запрос. Проверьте корректность данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


            query = "SELECT id, full_name as 'ФИО', department_name as 'Отдел' FROM specialists";
            DataTable dt = bdmSpec.executeAndReturnDT(query);
            dataGridView1.DataSource = dt;

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            string fio = fioTb.Text;
            if (fio == "Введите отдел")
                fio = "";
            string dep = depTb.Text;
            string query = "UPDATE specsalaries " +
                           $"SET department_name = '{dep}' " +
                           $"WHERE full_name = '{fio}'";
            try
            {
                bdmSpec.executeAndReturnDT(query);
            }
            catch { MessageBox.Show("Не удалось совешрить запрос. Проверьте корректность данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            query = "UPDATE specialists " +
               $"SET department_name = '{dep}' " +
               $"WHERE full_name = '{fio}'";
            try
            {
                bdmSpec.executeAndReturnDT(query);
            }
            catch { MessageBox.Show("Не удалось совешрить запрос. Проверьте корректность данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


            query = "SELECT id, full_name as 'ФИО', department_name as 'Отдел' FROM specialists";
            DataTable dt = bdmSpec.executeAndReturnDT(query);
            dataGridView1.DataSource = dt;
        }

        private void hidesal_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bdmSpec.SelectAll();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            fioenterTb.Text = "";
            depenterTb.Text = "";
            if (checkBox1.Checked)
            {
                monthenterBox.Visible = true;
                monthenterLB.Visible = true;
                fioenterLB.Text = "Введите id специалиста:";
                depenterLB.Text = "Введите доход за месяц:";
            }
            else
            {
                monthenterBox.Visible = false;
                monthenterLB.Visible = false;
                fioenterLB.Text = "Введите ФИО:";
                depenterLB.Text = "Введите отдел:";
            }

        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    bdmSpec.executeAndReturnDT($"INSERT into salaries (specialist_id, month, salary) values" +
                                    $"({fioenterTb.Text}, {monthenterBox.SelectedIndex + 1}, {depenterTb.Text})");
                }
                catch { MessageBox.Show("Не удалось совешрить запрос. Проверьте корректность данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                DataTable dt = bdmSpec.executeAndReturnDT("SELECT specialist_id as 'ID специалиста', month as 'Месяц', salary as 'Зарплата' FROM salaries");
                dataGridView1.DataSource = dt;
            }
            else
            {
                try
                {
                    bdmSpec.executeAndReturnDT($"Insert into specialists (full_name, department_name) values" +
                                                $"('{fioenterTb.Text}', '{depenterTb.Text}')");
                }
                catch { MessageBox.Show("Не удалось совешрить запрос. Проверьте корректность данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                DataTable dt = bdmSpec.executeAndReturnDT("SELECT id, full_name as 'ФИО', department_name as 'Отдел' FROM specialists");
                dataGridView1.DataSource = dt;
            }
        }




        private void fioTb_Click(object sender, EventArgs e)
        {
            if (fioTb.Text == "Введите ФИО")
                fioTb.Text = "";
        }   

        private void depTb_Click(object sender, EventArgs e)
        {
            if (depTb.Text == "Введите отдел")
                depTb.Text = "";
        }

        private void adduserBtn_Click(object sender, EventArgs e)
        {
            Form adduser = new adduserForm(this);
            adduser.Show();
            this.Hide();
        }
    }
}
