using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TextParser.Model
{
    class WordComparer : EqualityComparer<Word>
    {
        public override bool Equals([AllowNull] Word x, [AllowNull] Word y)
        {
            return x.ToString().Equals(y.ToString());
        }

        public override int GetHashCode([DisallowNull] Word obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
