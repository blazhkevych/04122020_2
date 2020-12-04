//Регулярні вирази
// https://regex101.com/ 
// дата \d{1,2}\.\d{1,2}\.\d{2,4}

using System;
using static System.Console;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04122020_2
{
    class Program
    {
        static void Task1()
        {
            //  \d{1,2}\.\d{1,2}\.\d{2,4}
            string text = "Іван прийнятий на роботу 04.06.2018 зарплата 12345. " +
                "Звільнений 06.08.2019. Степан прийнятий на роботу 08.06.2018. " +
                "Звільнений 15.08.2019. 12Е 15.08.19  3.5.19  10.05.1";
            string patern = @"\b\d{1,2}\.\d{1,2}\.\d{2,4}";
            Regex regex = new Regex(patern);
            Match match = regex.Match(text);
            // Console.WriteLine($"Value = {match.Value} Index= {match.Index}");
            while (match.Success)
            {
                Console.WriteLine($"Value = {match.Value,11} Index= {match.Index}");
                match = match.NextMatch();
            }
            MatchCollection matches = regex.Matches(text);
            Console.WriteLine($"Count = {matches.Count}");
            foreach (Match mat in matches)
                Console.WriteLine($"Value = {mat.Value,11} Index= {mat.Index}");
            Console.WriteLine($"---------------------------------------------");
            regex
                .Matches(text)
                .ToList()
                .ForEach(m => Console.WriteLine($"Value = {m.Value,11} Index= {m.Index}"));
            //Regex
        }
        static void Task2()
        {
            //  \d{1,2}\.\d{1,2}\.\d{2,4}
            string text = "Іван прийнятий на роботу 04.06.2018 зарплата 12345. " +
                "Звільнений 06.08.2019. Степан прийнятий на роботу 08.06.2018. " +
                "Звільнений 15.08.2019. 12Е 15.08.19  3.5.19  10.05.1";
            WriteLine(text);
            Console.WriteLine($"---------------------------------------------");
            string patern = @"\b\d{1,2}\.\d{1,2}\.\d{2,4}";
            Regex regex = new Regex(patern);
            string newtext = regex.Replace(text, "05.08.2020");
            WriteLine(newtext);
            Console.WriteLine($"---------------------------------------------");
            newtext = Regex.Replace(text, "2019", "2020");
            WriteLine(newtext);
        }
        static void Task3()
        {
            // dd.MM.yyyy -> yyyy-MM-dd
            string text = "Іван прийнятий на роботу 04.06.2018 зарплата 12345. " +
                "Звільнений 06.08.2019. Степан прийнятий на роботу 08.06.2018. " +
                "Звільнений 15.08.2019. 12Е 15.08.19  3.5.19  10.05.1";
            WriteLine(text);
            Console.WriteLine($"---------------------------------------------");
            string patern = @"\b(\d{1,2})\.(\d{1,2})\.(\d{2,4})";
            patern = @"\b(?<day>\d{1,2})\.(?<month>\d{1,2})\.(?<year>\d{2,4})";
            Regex regex = new Regex(patern);
            //string newtext = regex.Replace(text, "$3-$2-$1");
            string newtext = regex.Replace(text, "${year}-${month}-${day}");
            WriteLine(newtext);
            Console.WriteLine($"---------------------------------------------");
            regex.Matches(text);
            regex
               .Matches(text)
               .ToList()
               .ForEach(m => WriteLine($"Value = {m.Value,11} " +
               $"Index= {m.Index,3} " +
               $"dd= {m.Groups[1].Value,3} " +
               $"MM= {m.Groups[2].Value,3} " +
               $"YYYY= {m.Groups[3].Value,5} "
               ));
            regex
              .Matches(text)
              .ToList()
              .ForEach(m => WriteLine($"Value = {m.Value,11} " +
              $"Index= {m.Index,3} " +
              $"dd= {m.Groups["day"],3} " +
              $"MM= {m.Groups["month"].Value,3} " +
              $"YYYY= {m.Groups["year"].Value,5} "
              ));

            WriteLine(newtext);
        }
        static void Task4()
        {
            //^\+\d{2}\(\d{3}\)-\d{3}-\d{2}-\d{2}$
            string text = "+38(086)-2 6-32-69";
            WriteLine(text);
            Console.WriteLine($"---------------------------------------------");
            string patern = @"^\+\d{2}\(\d{3}\)-\d{3}-\d{2}-\d{2}$";
            Regex regex = new Regex(patern);
            if (regex.IsMatch(text))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            //Ання
        }
        static void Task5()
        {
            //^\+\d{2}\(\d{3}\)-\d{3}-\d{2}-\d{2}$
            //Ання 
            string text = "Іван";
            WriteLine(text);
            Console.WriteLine($"---------------------------------------------");
            string patern = @"^[А-ЯІ]{1}[а-яії]{1,}$";
            Regex regex = new Regex(patern);
            if (regex.IsMatch(text))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //  Task1();
            // Task2();
            // Task3();
            // Task4();
            Task5();
        }
    }
}
