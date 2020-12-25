using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser
{
    class Punctuation : SentenceItem
    {
        string punct;

        public override bool IsWord() => false;

        public override string ToString() => punct;
    }
}
