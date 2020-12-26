using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser
{
    class Punctuation : SentenceItem
    {
        string Punct { get; set; }

        public Punctuation()
        {
            Punct = "";
        }

        public void AddPunc(char c)
        {
            Punct += c;
        }

        public override bool IsWord() => false;

        public override string ToString() => Punct;
    }
}
