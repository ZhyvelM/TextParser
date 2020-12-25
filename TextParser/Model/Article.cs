using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser
{
    class Article
    {
        List<Sentence> article;

        public override string ToString()
        {
            string str = "";
            article.ForEach(o => str += o.ToString());
            return str;
        }
    }
}
