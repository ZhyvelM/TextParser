using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser
{
    class Word : SentenceItem
    {
        List<Letter> word;
        public override bool IsWord() => true;

        public override string ToString()
        {
            string str = "";
            word.ForEach(o => str += o.ToString());
            return str;
        }
    }
}
