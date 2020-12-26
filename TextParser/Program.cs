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
            IService service = new Service.Service();
            bool flag = true;
            while (flag)
            {
                menu();
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
                            try
                            {
                                using (StreamReader sr = new StreamReader(@"..\..\..\..\PathToFile.txt"))
                                {
                                    text = Parser.ParseFile(sr.ReadToEnd());
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            Console.WriteLine(text);
                        }
                        break;
                    case ('2'):
                        {
                            string sent = "";
                            service.TextSort(text).ForEach(o => sent +=$" [{o.WordsCount}] {o}\n");
                            Console.WriteLine(sent);
                        }
                        break;
                    case ('3'):
                        {

                        }
                        break;
                    case ('4'):
                        {

                        }
                        break;
                    case ('5'):
                        {

                        }
                        break;
                    default:
                        {
                            flag = false;
                            break;
                        }
                }
                if (flag)
                {
                    Console.ReadLine();
                }
            }
        }

        private static void menu()
        {
            Console.Clear();
            Console.WriteLine("1.Parse text\n" +
                                "2.Sentences in order\n" +
                                "3.Words of selected length in exclamative sentences\n" +
                                "4.Delete words started with vowel\n" +
                                "5.Change word with substring\n" +
                                "Any. Exit");
        }
    }
}
