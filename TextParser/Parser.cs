using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TextParser.Model;

namespace TextParser
{
    class Parser
    {
        public static Text ParseFile(string path)
        {
            Text text = new Text();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    if (!sr.EndOfStream)
                    {
                        ReadText(sr, text);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return text;
        }

        private static void ReadText(StreamReader sr, Text text)
        {
            while (!sr.EndOfStream)
            {
                text.AddArticle(ReadArticle(sr));
            }
        }

        private static Article ReadArticle(StreamReader sr)
        {
            Article article = new Article();
            while (!sr.EndOfStream)
            {
                article.AddSentence(ReadSentence(sr));
                if((char)sr.Read() == '\n')
                {
                    return article;
                }
            }
            return article;
        }

        private static Sentence ReadSentence(StreamReader sr)
        {
            Sentence sentence = new Sentence();
            while (!sr.EndOfStream)
            {
                char c = (char)sr.Read();
                if (c >= 'а' && c <= 'я' || c >= 'А' && c <= 'Я' || c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
                {
                    sentence.AddSentenceItem(ReadWord(sr,ref c));
                }
                
                if (c != ' ')
                {
                    Punctuation punct = ReadPunctuation(sr, c);
                    sentence.AddSentenceItem(punct);

                    switch (punct.ToString())
                    {
                        case ".":
                            {
                                sentence.SetSentenceType(SentenceType.declarative);
                            }
                            return sentence;
                        case "!":
                            {
                                sentence.SetSentenceType(SentenceType.exclamative);
                            }
                            return sentence;
                        case "?":
                            {
                                sentence.SetSentenceType(SentenceType.interrogative);
                            }
                            return sentence;
                        case "...":
                            {
                                sentence.SetSentenceType(SentenceType.threeDots);
                            }
                            return sentence;
                        default: { break; }
                    }
                }
            }
            return sentence;
        }

        private static Punctuation ReadPunctuation(StreamReader sr, char c)
        {
            Punctuation punctuation = new Punctuation();
            bool flag = true;
            punctuation.AddPunc(c);
            do
            {
                c = (char)sr.Read();
                if (c == '.')
                {
                    punctuation.AddPunc(c);
                }
                else
                {
                    flag = false;
                }
            } while (flag);
            return punctuation;
        }

        private static Word ReadWord(StreamReader sr,ref char c)
        {
            Word word = new Word();
            bool flag = true;
            Letter l = new Letter(c);
            word.AddSimbol(l);
            do
            {
                c = (char)sr.Read();
                if (c >= 'а' && c <= 'я' || c >= 'А' && c <= 'Я' || c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c == '-' || c == '\'')
                {
                    l = new Letter(c);
                    word.AddSimbol(l);
                }
                else
                {
                    
                    flag = false;
                }
            } while (flag);
            return word;
        }
    }
}