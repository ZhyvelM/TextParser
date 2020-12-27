using System;
using System.IO;
using TextParser.Model;
using TextParser.Service;

namespace TextParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Text text = new Text();
            IService service = new TextParserTasksDelegate();
            Case1(ref text);
            bool IsStillWorking = true;
            while (IsStillWorking)
            {
                ShowMenu();
                string str = Console.ReadLine();
                char c;
                if (str.Length > 1 || str.Length == 0)
                {
                    c = '*';
                }
                else
                {
                    c = str[0];
                }
                switch (c)
                {
                    case ('1'):
                        {
                            Case1(ref text);
                        }
                        break;
                    case ('2'):
                        {
                            Case2(text,service);
                        }
                        break;
                    case ('3'):
                        {
                            Case3(text, service);
                        }
                        break;
                    case ('4'):
                        {
                            Case4(text, service);
                        }
                        break;
                    case ('5'):
                        {
                            Case5(text, service);
                        }
                        break;
                    default:
                        {
                            IsStillWorking = false;
                            break;
                        }
                }
                if (IsStillWorking)
                {
                    Console.ReadLine();
                }
            }
        }

        private static void Case1(ref Text text)
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\..\..\PathToFile.txt"))
                {
                    string pathToFile = sr.ReadToEnd();
                    text = Parser.ParseFile(pathToFile);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(text);
        }

        private static void Case2(Text text, IService service)
        {
            string sent = "";
            service.TextSort(text).ForEach(o => sent += $" [{o.WordsCount}] {o}\n");
            Console.WriteLine(sent);
        }

        private static void Case3(Text text, IService service)
        {
            Console.Write("Enter word length: ");
            int length = int.Parse(Console.ReadLine());
            string words = "";
            service.FindWordsOfSeletedLengthInSenteces(text, length).ForEach(o => words += $"{o} ");
            Console.WriteLine(words);
        }
        private static void Case4(Text text, IService service)
        {
            Console.Write("Enter word length: ");
            int length = int.Parse(Console.ReadLine());
            service.DeleteWordsOfSelectedLength(text, length);
            Console.WriteLine(text);
        }
        private static void Case5(Text text, IService service)
        {
            Console.Write("Enter index of sentence: ");
            int index = int.Parse(Console.ReadLine());
            Console.Write("Enter word length: ");
            int length = int.Parse(Console.ReadLine());
            Console.Write("Enter substring: ");
            string substring = Console.ReadLine();
            service.SwapWordsOfSSelectedLengthWithSubstring(text, index, length, substring);
            Console.WriteLine(text);
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1.Parse text\n" +
                                "2.Sentences in order\n" +
                                "3.Words of selected length in exclamative sentences\n" +
                                "4.Delete words started with consonant\n" +
                                "5.Change word with substring\n" +
                                "Any. Exit");
        }
    }
}
