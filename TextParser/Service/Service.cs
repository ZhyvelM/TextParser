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
            throw new NotImplementedException();
        }

        public Text FindWordsOfSeletedLengthInSenteces(Text text, int length)
        {
            throw new NotImplementedException();
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
