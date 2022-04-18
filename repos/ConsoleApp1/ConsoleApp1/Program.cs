using System;
using System.IO;
using System.Collections.Generic;
namespace readwriteapp
{
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            string filename = @"путь к файлу";
            char separator = ';';
            Tuple<string, double, double, double, double>[] students;
            using (StreamReader reader = new StreamReader(filename))
            {//открытие файла для чтения
                string textline = reader.ReadLine();//чтение строки
                while (textline != null)
                {//если строка прочитана
                    if (textline.IndexOf(separator) != -1)
                    {//если в строке есть разделитель
                        textline = reader.ReadLine();//чтение следующей строки
                    }
                }
            }
        }
    }
}