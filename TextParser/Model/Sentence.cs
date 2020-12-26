using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser
{
    class Sentence
    {
        List<SentenceItem> Items { get; }
        SentenceType Type { get; }
        public Sentence()
        {
            Items = new List<SentenceItem>();
        }

        public override string ToString()
        {
            string str = "";
            Items.ForEach(o => str += o.ToString());
            return str;
        }
    }
}
