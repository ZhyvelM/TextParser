﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser.Model
{
    class Text
    {
        public List<Article> Articles { get; }

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
            return String.Join('\n',Articles);
        }
    }
}
