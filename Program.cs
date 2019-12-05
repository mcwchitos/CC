using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LLVMSharp;

namespace CCAss3
{
    class Program
    {
        static void ProcessClassDeclaration(ClassDeclaration declaration)
        {
            var declarationClassName = declaration.ClassName;
            var declarationExtends = declaration.Extends;
            foreach (var classmember in declaration.Members)
            {
                var member = classmember;
            }
        }

        static void Main(string[] args)
        {
            ToyLangParser parser = new ToyLangParser();
            parser.Parse(System.IO.File.ReadAllText(@"C:\Users\hyhy\RiderProjects\CC\Program.Toy"));
            RootNode node = parser.Root;
            foreach (var variable in node.Classes)
            {
                ProcessClassDeclaration(variable);
            }
//            Console.WriteLine("asd");
        }
    }
}

