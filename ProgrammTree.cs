using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAss3
{
    class CType
    {
        public bool isArray;
    }

    class IntType : CType
    {
        public IntType(bool arr)
        {
            isArray = arr;
        }
    }

    class RealType : CType
    {
        public RealType(bool arr)
        {
            isArray = arr;
        }
    }

    class CustomType : CType
    {
        public Identifier Id;

        public CustomType(Identifier id, bool arr)
        {
            Id = id;
            isArray = arr;
        }
    }

    class Node
    {

    }

    class Expression : Node
    {
        
    }


    class Statement : Node
    {
        public Statement(){}
    }

    class Assignment : Statement{

    }

    class IfStatement : Statement{

    }

    class WhileStatement : Statement{
        
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
        }
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
        public int Visibility;
        public int Staticness;
        public CType Type;
        public Identifier Id;

        public FieldDeclaration(int visibility, int staticness, CType type, Identifier id){
            Visibility = visibility;
            Staticness = staticness;
            Type = type;
            Id = id;
        }

        public FieldDeclaration() { }

    }

    class Parameter{
        public CType Type;
        public Identifier Id;

        public Parameter(CType type, Identifier id){
            Type = type;
            Id = id;
        }
    }

    class LocalDeclaration{
        public CType Type;
        public Identifier Id;

        public LocalDeclaration(CType type, Identifier id){
            Type = type;
            Id = id;
        }

        public LocalDeclaration(){}
    }

  
    class MethodDeclaration : Statement
    {
        public int Visibility;
        public int Staticness;
        public CType MethodType;
        public Identifier Id;
        public List<Parameter> Params = new List<Parameter>();
        public MethodBody Body;

        public MethodDeclaration(int visibility, int staticness, CType methodtype, Identifier id, List<Parameter> parameters, MethodBody body){
            Visibility = visibility;
            Staticness = staticness;
            MethodType = methodtype;
            Id = id;
            Params = parameters;
            Body = body;
        }

        public MethodDeclaration() { }
    }

    class MethodBody
    {
        public List<LocalDeclaration> LocalDeclarations = new List<LocalDeclaration>();
        public List<Statement> Statements = new List<Statement>();

        public MethodBody(List<LocalDeclaration> localdeclarations, List<Statement> statements){
            LocalDeclarations = localdeclarations;
            Statements = statements;
        }

        public MethodBody(){}
    }

    class ClassDeclaration : Statement
    {
        public int Scope;
        public List<Identifier> Id = new List<Identifier>();
        public Identifier Extends;
        public ClassBody Body;

        public ClassDeclaration(int scope, Identifier id, Identifier extends){
            Scope = scope;
            Extends = extends;
        }

        public ClassDeclaration(int scope, Identifier id){
            Scope = scope;
            Extends = null;
        }

        public ClassDeclaration(){
            Scope = 0;
            Extends = null;
        }
    }

    class ClassBody
    {
        public List<FieldDeclaration> Fields = new List<FieldDeclaration>();
        public List<MethodDeclaration> Methods = new List<MethodDeclaration>();

        public ClassBody(object fields, object methods)
        {
            Fields = (List<FieldDeclaration>) fields;
            Methods = (List<MethodDeclaration>) methods;
        }

        public ClassBody()
        {

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
