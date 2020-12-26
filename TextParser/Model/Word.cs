using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser
{
    class Word : SentenceItem
    {
        public List<Letter> Letters { get; }
        public override bool IsWord() => true;

        public bool IsStartsWithConsonant => !"аёуеыоэяиюeyiuao".Contains(this.ToString().ToLower()[0]);

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
