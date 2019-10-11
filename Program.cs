using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAss3
{
    class Program
    {
        static void Main(string[] args)
        {
            ToyLangParser parser = new ToyLangParser();
            parser.Parse("CLASS kek;{}");
            RootNode node = parser.Root;
            Console.ReadLine();
        }
    }
}

