using System;
using System.Collections.Generic;
using System.Text;

namespace CCAss3
{
    internal partial class ToyLangScanner
    {

        void GetNumber()
        {
            yylval.intNumber = int.Parse(yytext);
        }

        void GetIdentifier()
        {
            yylval.identifier = yytext;
        }

		public override void yyerror(string format, params object[] args)
		{
			base.yyerror(format, args);
			Console.WriteLine(format, args);
			Console.WriteLine();
		}
    }
}
