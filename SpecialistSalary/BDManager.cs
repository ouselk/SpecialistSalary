using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Data;

namespace SpecialistSalary
{
    internal class BDManager
    {
     
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        private string tableName;
        public BDManager(string pathToBase, string tn)
        {
            conn = new SQLiteConnection("DataSource = " + pathToBase);
            conn.Open();
            cmd = conn.CreateCommand();
            tableName = tn;
        }

        public void Insert(string ft, string sc, string thd)
        {
            if (tableName == "specialists")
            {
                cmd.CommandText = "insert into Specialists(full_name, department_name, DP) values('" +
                    ft + "'," + sc + ",'" + thd + "')";
            }
            else if (tableName == "users")
            {
                cmd.CommandText = "insert into users(name, pass) values('" +
                    ft + "','" + sc+"')";
            }
            else
            {
                throw new Exception("DBManager can't work with this table");
            }
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public DataTable SelectWhere(string condition)
        {
            if (tableName == "specialists")
            {
                return new DataTable();
            }
            else if (tableName == "users")
            {
                cmd.CommandText = "select * from users where " + condition;
                Console.WriteLine(cmd.CommandText);
                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                return dt;
            }
            return new DataTable();
        }
        public DataTable SelectAll()
        {
            if (tableName == "specialists")
            {
                cmd.CommandText = "select id as 'ID специалиста', full_name as ФИО, department_name as Отдел from specialists";
                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                return dt;
            }
            else if (tableName == "users")
            {
                cmd.CommandText = "select name, pass, rights from users";
                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                return dt;
            }
            return new DataTable();
        }
        public DataTable executeAndReturnDT(string query)
        {
            cmd.CommandText = query;
            SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public void InsertDataTableToSQLite(DataTable dataTable, string tableName)
        {
            SQLiteConnection connection = conn;

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    // Создаем таблицу в базе данных SQLite, если она отсутствует
                    StringBuilder createTableSql = new StringBuilder();
                    createTableSql.AppendFormat("CREATE TABLE IF NOT EXISTS {0} (", tableName);

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        createTableSql.AppendFormat("{0} {1}, ", column.ColumnName, GetSqlType(column.DataType));
                    }

                    createTableSql.Length -= 2; // Удаляем последнюю запятую и пробел
                    createTableSql.Append(")");

                    command.CommandText = createTableSql.ToString();
                    command.ExecuteNonQuery();

                    // Вставляем данные в таблицу
                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            StringBuilder insertSql = new StringBuilder();
                            StringBuilder valuesSql = new StringBuilder();

                            insertSql.AppendFormat("INSERT INTO {0} (", tableName);
                            valuesSql.Append("VALUES (");

                            foreach (DataColumn column in dataTable.Columns)
                            {
                                insertSql.AppendFormat("{0}, ", column.ColumnName);
                                valuesSql.AppendFormat("@{0}, ", column.ColumnName);

                                command.Parameters.AddWithValue("@" + column.ColumnName, row[column]);
                            }

                            insertSql.Length -= 2; // Удаляем последнюю запятую и пробел
                            insertSql.Append(")");

                            valuesSql.Length -= 2; // Удаляем последнюю запятую и пробел
                            valuesSql.Append(")");

                            command.CommandText = insertSql.ToString() + " " + valuesSql.ToString();
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }

            }
        }

        private string GetSqlType(Type dataType)
        {
            if (dataType == typeof(int))
            {
                return "INTEGER";
            }
            else if (dataType == typeof(string))
            {
                return "TEXT";
            }
            else if (dataType == typeof(double))
            {
                return "REAL";
            }
            else if (dataType == typeof(bool))
            {
                return "INTEGER";
            }
            else if (dataType == typeof(DateTime))
            {
                return "TEXT";
            }
            else
            {
                return "BLOB";
            }
        }
    }

}
