using System;
using System.Collections.Generic;
using System.Text;
using TextParser.Model;

namespace TextParser.Service
{
    class Service : IService
    {
        public Text DeleteWordsOfSelectedLength(Text text, int length)
        {
            foreach (Article a in text.Articles)
            {
                foreach (Sentence s in a.Sentences)
                {
                    for (int i = 0; i < s.Items.Count; i++)
                    {
                        if (s.Items[i].IsWord())
                        {
                            Word word = s.Items[i] as Word;
                            if(word.IsStartsWithConsonant && word.Letters.Count == length)
                            {
                                s.Items.Remove(s.Items[i]);
                            }
                        }
                    }
                }
            }
            return text;
        }

        public List<Word> FindWordsOfSeletedLengthInSenteces(Text text, int length)
        {
            List<Word> words = new List<Word>();
            HashSet<Word> words_h = new HashSet<Word>(new WordComparer());
            foreach (Article a in text.Articles)
            {
                foreach (Sentence s in a.Sentences)
                {
                    if (s.Type == SentenceType.interrogative)
                    {
                        for(int i = 0; i < s.Items.Count; i++)
                        {
                            if (s.Items[i].IsWord())
                            {
                                Word w = s.Items[i] as Word;
                                if (w.Letters.Count == length)
                                {
                                    if (words_h.Add(w))
                                    {
                                        words.Add(w);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return words;
        }

        public Text SwapWordsOfSSelectedLengthWithSubstring(Text text,int index, int length, string substring)
        {
            List<SentenceItem> substr = new List<SentenceItem>();
            int i = 0;
            char c;
            while (i < substring.Length)
            {
                c = substring[i];
                i++;
                if (c >= 'а' && c <= 'я' || c >= 'А' && c <= 'Я' || c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
                {
                    substr.Add(ReadWord(substring, ref i, ref c));
                }

                if (c != ' ')
                {
                    Punctuation punct = ReadPunctuation(substring, ref i, c);
                    substr.Add(punct);
                }
            }
            int j = 0;
            foreach (Article a in text.Articles)
            {

                foreach (Sentence s in a.Sentences)
                {
                    j++;
                    if (j == index)
                    {
                        for (i = 0; i < s.Items.Count; i++)
                        {
                            if (s.Items[i].IsWord())
                            {
                                Word word = s.Items[i] as Word;
                                if (word.Letters.Count == length)
                                {
                                    s.Items.Remove(s.Items[i]);
                                    foreach (SentenceItem si in substr)
                                    {
                                        s.Items.Insert(i, si);
                                        i++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return text;
        }

        private static Punctuation ReadPunctuation(string substring,ref int i, char c)
        {
            Punctuation punctuation = new Punctuation();
            bool flag = true;
            punctuation.AddPunc(c);
            if (i != substring.Length)
            {
                do
                {
                    c = substring[i];
                    i++;
                    if (c == '.')
                    {
                        punctuation.AddPunc(c);
                    }
                    else
                    {
                        flag = false;
                    }
                } while (flag && i < substring.Length);
            }
            return punctuation;
        }

        private static Word ReadWord(string substring,ref int i, ref char c)
        {
            Word word = new Word();
            bool flag = true;
            Letter l = new Letter(c);
            word.AddSimbol(l);

            if (i != substring.Length)
            {
                do
                {
                    c = substring[i];
                    i++;
                    if (c >= 'а' && c <= 'я' || c >= 'А' && c <= 'Я' || c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c == '-' || c == '\'')
                    {
                        l = new Letter(c);
                        word.AddSimbol(l);
                    }
                    else
                    {
                        flag = false;
                    }
                } while (flag && i < substring.Length);
            }
            c = ' '; 
            return word;
        }

        public List<Sentence> TextSort(Text text)
        {
            List<Sentence> sentences = new List<Sentence>();
            foreach(Article a in text.Articles)
            {
                foreach(Sentence s in a.Sentences)
                {
                    sentences.Add(s);
                }
            }
            sentences.Sort((s1,s2) => s1.WordsCount.CompareTo(s2.WordsCount));
            return sentences;
        }
    }
}
