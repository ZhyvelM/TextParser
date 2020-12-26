using System;
using System.Collections.Generic;
using System.Text;
using TextParser.Model;

namespace TextParser.Service
{
    interface IService
    {
        public List<Sentence> TextSort(Text text);
        public List<Word> FindWordsOfSeletedLengthInSenteces(Text text, int length);
        public Text DeleteWordsOfSelectedLength(Text text, int length);
        public Text SwapWordsOfSSelectedLengthWithSubstring(Text text, int index, int length, string substring);
    }
}
