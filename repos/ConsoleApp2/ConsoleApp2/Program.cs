using System;
using System.IO;
using System.Globalization;
namespace lab_6
{
    class Program
    {
        static void Main()
        {
            StreamReader sourse = new StreamReader("file.txt");
            string list;
            Console.WriteLine("Вывод студентов из текстового файла:\n");
            while (sourse.EndOfStream != true)
            {
                list = sourse.ReadLine();
                string[] line = list.Split(';');
                Console.WriteLine("ФИО: " + line[0]);
                Console.WriteLine("Пол: " + line[1]);
                Console.WriteLine("Дата рождения: " + line[2]);
                Console.WriteLine("Вес: " + line[3] + " кг");
                Console.WriteLine("Долг по ПП: " + line[4]);
                Console.WriteLine();
            }
            sourse.Close();
            using (StreamReader sourse1 = new StreamReader("file.txt"))
            {
                StreamReader f = new StreamReader("file.txt");
                string check;
                Console.WriteLine("Поиск студентов с долгом! \n");
                while ((check = sourse1.ReadLine()) != null)
                {
                    string search = f.ReadLine();
                    string[] mass = search.Split(';');
                    check = mass[1];
                    if (check == "Юноша")
                    {
                        string dt = mass[2];
                        var date = DateTime.ParseExact(dt, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                        if (((DateTime.Now.Year - date.Year) <= 18) || (DateTime.Now.Month > date.Month) && (DateTime.Now.Day < date.Day))
                        { }
                        else
                        {
                            check = mass[4];
                            if (check == "Да")
                                using (var writer = new StreamWriter("В военкомат.txt", true))
                                {
                                    check = search;
                                    writer.WriteLine(check);
                                    Console.WriteLine("Студент отправлен в военкомат");
                                }
                        }
                    }
                }
            }
        }
    }
}
