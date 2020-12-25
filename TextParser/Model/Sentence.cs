using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser
{
    class Sentence
    {
        List<SentenceItem> sentence;

        public Sentence()
        {
            sentence = new List<SentenceItem>();
        }

        public override string ToString()
        {
            string str = "";
            sentence.ForEach(o => str += o.ToString());
            return str;
        }
    }
}
