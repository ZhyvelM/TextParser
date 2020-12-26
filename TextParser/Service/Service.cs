using System;
using System.Collections.Generic;
using System.Text;
using TextParser.Model;

namespace TextParser.Service
{
    class Service : IService
    {
        public Service()
        { }

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
                            if(word.IsStartsWithVowel && word.Letters.Count == length)
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

        public Text SwapWordsOfSSelectedLengthWithSubstring(Text text, int length, string substring)
        {
            throw new NotImplementedException();

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
