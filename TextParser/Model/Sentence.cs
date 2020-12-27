using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextParser
{
    class Sentence
    {
        public List<SentenceItem> Items { get; }
        public SentenceType Type { get; set; }
        public int WordsCount {
        get{
                return Items.Count(o => o.IsWord());
            }
        }
        public Sentence()
        {
            Items = new List<SentenceItem>();
        }

        public void AddSentenceItem(SentenceItem sentenceItem)
        {
            Items.Add(sentenceItem);
        }

        public void SetSentenceType(SentenceType type)
        {
            Type = type;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].IsWord())
                {
                    str += (Items[i] as Word).ToString();
                    if (Items[i+1].IsWord())
                    {
                        str += " ";
                    }
                }
                else
                {
                    str += (Items[i] as Punctuation).ToString();
                    if (i < Items.Count-1)
                    { 
                        str += " ";
                    }
                }
            }
            return str;
        }
    }
}
