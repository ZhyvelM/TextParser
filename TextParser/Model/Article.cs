using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser
{
    class Article
    {
        public List<Sentence> Sentences { get; set; }

        public Article()
        {
            Sentences = new List<Sentence>();
        }

        public void AddSentence(Sentence sentence)
        {
            Sentences.Add(sentence);
        }

        public override string ToString()
        {
            return String.Join(' ',Sentences);
        }
    }
}
