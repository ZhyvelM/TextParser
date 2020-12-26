using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser
{
    class Word : SentenceItem
    {
        List<Letter> Letters { get; }
        public override bool IsWord() => true;

        public Word()
        {
            Letters = new List<Letter>();
        }

        public void AddSimbol(Letter l)
        {
            Letters.Add(l);
        }

        public override string ToString()
        {
            string str = "";
            Letters.ForEach(o => str += o.ToString());
            return str;
        }
    }
}
