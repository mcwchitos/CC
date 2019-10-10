using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CCAss3
{
    internal partial class ToyLangParser
    {
        public ToyLangParser() : base(null) { }

        public void Parse(string s)
        {
            byte[] inputBuffer = System.Text.Encoding.Default.GetBytes(s);
            MemoryStream stream = new MemoryStream(inputBuffer);
            this.Scanner = new ToyLangScanner(stream);
            this.Parse();
        }
    }
}
