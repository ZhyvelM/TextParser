using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser.Model
{
    class Text
    {
        List<Article> Articles { get; }

        public Text ()
        {
            Articles = new List<Article>();
        }

        public void AddArticle(Article article)
        {
            Articles.Add(article);
        }

        public override string ToString()
        {
            string str = "";
            Articles.ForEach(o => str += o.ToString());
            return str;
        }
    }
}
