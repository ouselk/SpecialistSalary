using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SpecialistSalary
{
    internal class FileManager
    {
        public static string dtToString(DataTable dt)
        {
            string result = "";
            for (int i = 0; i < dt.Columns.Count; i++)
                result += dt.Columns[i].ColumnName + ";";
            result += "\n";
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    result += dr[i] + ";";
                }
                result += "\n";
            }
            Console.WriteLine(result);
            return result;
        }
        public static DataTable stringToDt(string str)
        {
            DataTable dataTable = new DataTable();
            string[] rows = str.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Разделите первую строку на названия столбцов с помощью разделителя ";"
            string[] columnNames = rows[0].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string columnName in columnNames)
            {
                // Добавьте столбцы в DataTable на основе названий столбцов
                dataTable.Columns.Add(columnName, typeof(string));
            }

            // Пропустите первую строку и начните обработку данных со второй строки
            for (int i = 1; i < rows.Length; i++)
            {
                // Разделите текущую строку на отдельные значения столбцов с помощью разделителя ";"
                string[] values = rows[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (values.Length == columnNames.Length)
                {
                    // Создайте новую строку DataRow и добавьте значения в соответствующие столбцы
                    DataRow dataRow = dataTable.NewRow();
                    for (int j = 0; j < values.Length; j++)
                    {
                        dataRow[j] = values[j];
                    }

                    // Добавьте новую строку в коллекцию строк таблицы
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }
        public static void WriteStringToBinaryFile(string text, string fileName)
        {
            // Конвертируем строку в байты
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            // Записываем байты в бинарный файл
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }
        public static string ReadStringFromBinaryFile(string fileName)
        {
            string text;

            // Читаем содержимое бинарного файла
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, (int)fileStream.Length);
                text = Encoding.UTF8.GetString(bytes);
            }

            return text;
        }


      }
}
