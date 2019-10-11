using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAss3
{
    class Node
    {

    }

    class Expression : Node
    {
        
    }

    class Statement : Node
    {
    }

    class IntNode : Expression
    {
        public int Value;

        public IntNode(int value)
        {
            Value = value;
        }
    }

    class RealNode : Expression
    {
        public double Value;

        public RealNode(double value)
        {
            Value = value;
        }
    }

    class Identifier : Expression
    {
        public string Value;

        public Identifier(string value)
        {
            Value = value;
        }
    }

    class BinaryOperation : Expression
    {
        public int OpType;
        public Expression Left;
        public Expression Right;

        public BinaryOperation(int opType, Expression left, Expression right )
        {
            OpType = opType;
            Left = left;
            Right = right;
        }
    }

    class RelateOperation : Expression
    {
        public int OpType;
        public Expression Left;
        public Expression Right;

        public RelateOperation(int opType, Expression left, Expression right )
        {
            OpType = opType;
            Left = left;
            Right = right;
        }
    }

    class FactorOperation : Expression
    {
        public int OpType;
        public Expression Left;
        public Expression Right;

        public FactorOperation(int opType, Expression left, Expression right )
        {
            OpType = opType;
            Left = left;
            Right = right;
        }Field
    }

    class TermOperation : Expression
    {
        public int OpType;
        public Expression Left;
        public Expression Right;

        public TermOperation(int opType, Expression left, Expression right )
        {
            OpType = opType;
            Left = left;
            Right = right;
        }
    }

    class FieldDeclaration : Statement
    {
        int Visibility;
        int Staticness;
        int Type;
        Identifier Id;

        public FieldDeclaration(int visibility, int staticness, int type, Identifier id){
            Visibility = visibility;
            Staticness = staticness;
            Type = type;
            Id = id;
        }

    }

    class MethodDeclaration : Statement
    {
         int Visibility;
        int Staticness;
        int Type;
        int MethodType;
        Identifier Id;

        public MethodDeclaration(int visibility, int staticness, int type, int methodtype, Identifier id){
            Visibility = visibility;
            Staticness = staticness;
            Type = type;
            MethodType = methodtype;
            Id = id;
        }
    }

    class ClassDeclaration : Statement
    {
        int Scope;
        Identifier Id;
        Identifier Extends;
        List<FieldDeclaration> Fields = new List<FieldDeclaration>();
        List<MethodDeclaration> Methods = new List<MethodDeclaration>();

        public ClassDeclaration(int scope, Identifier id, Identifier extends){
            Scope = scope;
            Id = id;
            Extends = extends;
        }

        public ClassDeclaration(int scope, Identifier id){
            Scope = scope;
            Id = id;
            Extends = null;
        }
        
    }

    class RootNode : Node
    {
        public List<Identifier> Imports;
        public List<ClassDeclaration> Classes;

        public RootNode()
        {
            Imports = new List<Identifier>();
            Classes = new List<ClassDeclaration>();
        }
    }
}
