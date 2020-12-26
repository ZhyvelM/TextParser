using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser
{
    class Letter
    {
        char Simbol { get; }

        public Letter(char c)
        {
            Simbol = c;
        }
        public override string ToString() => Simbol.ToString();
    }
}
