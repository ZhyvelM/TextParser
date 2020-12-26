using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser
{
    class Sentence
    {
        List<SentenceItem> Items { get; }
        SentenceType Type { get; set; }
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
                    str += " ";
                }
            }
            return str;
        }
    }
}
