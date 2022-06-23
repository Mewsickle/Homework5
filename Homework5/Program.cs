using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework5
{
    /*
        1. Создать программу, которая будет проверять корректность ввода логина.Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой.
        2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
        а) Вывести только те слова сообщения, которые содержат не более n букв.
        б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        в) Найти самое длинное слово сообщения.
        г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        д) ***Создать метод, который производит частотный анализ текста.В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.Здесь требуется использовать класс Dictionary.

        3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
        Например: badc являются перестановкой abcd.

        4. *Задача ЕГЭ.
        На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:

        <Фамилия> <Имя> <оценки>,
        где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. <Фамилия> и<Имя>, а также <Имя> и<оценки> разделены одним пробелом. Пример входной строки:

        Иванов Петр 4 5 3
        Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.

        Студент Ким Алексей

        */
    internal class Program
    {

        public static class Message
        {
            private static string[] separators = { ",", ".", "!", "?", ";", ":", " ", "-" };

            public static void PrintWords(string message)
            {
                int n = 9;
                string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length < n)
                    {
                        Console.WriteLine(words[i]);
                    }
                }

            }
            public static void ExcludeWords(string message)
            {
                ;
                string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > 0 && words[i][words[i].Length - 1] == 'а')
                    {
                        Console.WriteLine(words[i]);
                    }
                }

            }
            public static void LongestWord(string message)
            {
               
                string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                int max = 0;
                int index = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > max )
                    {
                        max = words[i].Length;
                        
                        index = i;

                    }
                }
                Console.WriteLine($"Самое длинное слово в тексте: {words[index]}");
                Console.ReadLine();

            }

            public static void StrBuild(string message)
            {
                StringBuilder a = new StringBuilder(10000);

                string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                int max = 0;
                
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > max - 2)
                    {
                        max = words[i].Length;
                        //Console.WriteLine(words[i]);
                        a.Append($"{words[i]}");


                    }
                }
                Console.WriteLine($"{a}");
                Console.ReadLine();

            }





        }

        




        static void Main(string[] args)
        {
            Console.Title = "Домашнее задание 5";
            Console.WriteLine("Здравствуйте, Юзер! Добро пожаловать в меню выбора программ!");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
            Menu();
            static void Menu()
            {

                Console.WriteLine("Пожалуйста введите номер программы!");
                Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("1:Программа проверки логина");
                Console.WriteLine("2:Считыватель слов короче n символов (n=9) (задача 2а)");
                Console.WriteLine("3:Считыватель слов заканчивающихся на русскую а (задача 2б)");
                Console.WriteLine("4:Поиск самого длинного слова в тексте(задача 2в)");
                Console.WriteLine("5:StringBuilder из длинных слов в тексте(задача 2г)");
                Console.WriteLine("6:Метод проверящий является ли строка перестановкой другой (задача 3)");




                Console.WriteLine("//////////////////////////////////////////////////////////////////////////");

                string menuSwitch = (Console.ReadLine());
                bool result = int.TryParse(menuSwitch, out var number);
                if (result == true)
                {
                    switch (number)
                    {
                        case 1:
                            Login();
                            break;
                        case 2:
                            Reciever();
                            break;
                        case 3:
                            LastLetterCheck();
                            break;
                        case 4:
                            MaxLetterChk();
                            break;
                        case 5:
                            StrBuildTest();
                            break;
                        case 6:
                            StrCheck();
                            break;


                    }
                }

                else
                    Console.WriteLine($"Ошибка! Пожалуйста введите числовое значение!");

            }
            //Задача 1 Сделал по Вашему примеру через свич.

            static void Login()
            {
                //пришлось читерить так как не знал как иначе сделать проверку на латиницу
                Regex myReg = new
                Regex(@"^[a-zA-Z][a-zA-Z0-9]{2,10}$");



                Console.WriteLine($"Введите Ваш Логин!");
                string login = Console.ReadLine();

                if (myReg.IsMatch(login))
                {
                    char[] symbols = login.ToCharArray();

                    int uCount = 0;
                    int dCount = 0;


                    for (int i = 0; i < symbols.Length; i++)
                    {
                        

                        UnicodeCategory category = char.GetUnicodeCategory(symbols[i]);
                        switch (category)
                        {

                            case UnicodeCategory.UppercaseLetter:
                                uCount++;
                                break;
                            case UnicodeCategory.LowercaseLetter:
                                
                                break;
                            case UnicodeCategory.DecimalDigitNumber:
                                dCount++;
                                break;
                            default:
                                Console.WriteLine($"{symbols[i]} - другая категория ...");
                                break;

                        }


                        

                    }
                    if (uCount > 0 && dCount > 0)
                    {
                        Console.WriteLine($"Логин в пределах допустимых параметров!");
                    }
                    else if (uCount == 0 || dCount == 0)
                    {
                        Console.WriteLine($"Логин должен содержать хотя бы одну заглавную букву и цифру");
                        Login();

                    }

                    else if (symbols.Length < 2 || symbols.Length > 10)
                    {
                        Console.WriteLine($"Логин должен быть от 2 до 10 символов");
                        Login();
                    }

                }


                else
                {
                    Console.WriteLine($"Логин может содержать только латинские буквы и быть от 2 до 10 символов");
                    Login();
                }

                

                Console.ReadKey();


            }
            static void Reciever()
            {
                Console.WriteLine($"Введите текст");
                string message = Console.ReadLine();
                Message.PrintWords(message);
            }
            static void LastLetterCheck()
            {
                Console.WriteLine($"Введите текст");
                string message = Console.ReadLine();
                Message.ExcludeWords(message);
            }

            static void MaxLetterChk()
            {
                Console.WriteLine($"Введите текст");
                string message = Console.ReadLine();
                Message.LongestWord(message);
            }
            static void StrBuildTest()
            {
                Console.WriteLine($"Введите текст");
                string message = Console.ReadLine();
                Message.StrBuild(message);
            }

            static void StrCheck()
            {
                Console.WriteLine($"Введите 1 строку");
                string s1 = Convert.ToString(Console.ReadLine());
                Console.WriteLine($"Введите 2 строку");
                string s2 = Convert.ToString(Console.ReadLine());
                
                s1.Select(Char.ToUpper).OrderBy(x => x).SequenceEqual(s2.Select(Char.ToUpper).OrderBy(x => x));

                if (s1.Select(Char.ToUpper).OrderBy(x => x).SequenceEqual(s2.Select(Char.ToUpper).OrderBy(x => x)))
                    
                    Console.WriteLine($"Строка 1 является перстановкой строки 2");
                else
                    Console.WriteLine($"Строка 1 не является перстановкой строки 2");


                Console.ReadLine();
            }
        }

       
           
    }
                    
}
