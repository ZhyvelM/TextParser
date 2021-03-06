﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser
{
    class Word : SentenceItem
    {
        public List<Letter> Letters { get; }
        public override bool IsWord() => true;

        public bool IsStartsWithConsonant => !"аёуеыоэяиюeyiuao".Contains(Char.ToLower(this.ToString()[0]));

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
            return String.Join("",Letters);
        }
    }
}
