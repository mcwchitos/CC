using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAss3
{
    class RootNode : Node
    {
        public List<ClassDeclaration> Classes;

        public RootNode()
        {
            Classes = new List<ClassDeclaration>();
        }
    }

    class ClassDeclaration : Statement
    {
        public ClassName ClassName;
        public Identifier Extends;
        public List<MemberDeclaration> Members = new List<MemberDeclaration>();

        public ClassDeclaration(ClassName className, Identifier extends)
        {
            ClassName = className;
            Extends = extends;
        }

        public ClassDeclaration(ClassName className)
        {
            ClassName = className;
        }

        public ClassDeclaration()
        {
        }
    }

    class ClassName
    {
        public Identifier Id;
        public ClassName SecondPart;

        public ClassName(Identifier id)
        {
            Id = id;
        }

        public ClassName(Identifier id, ClassName secondPart)
        {
            Id = id;
            SecondPart = secondPart;
        }
    }


    class MemberDeclaration : Node
    {
        public MemberDeclaration()
        {
        }
    }

    class VariableDeclaration : MemberDeclaration
    {
        public Identifier Id;
        public Expression Expr;

        public VariableDeclaration(Identifier id, Expression expr)
        {
            Expr = expr;
            Id = id;
        }

        public VariableDeclaration()
        {
        }
    }

    class MethodDeclaration : MemberDeclaration
    {
        public Identifier ReturnType;
        public Identifier Id;
        public List<Parameter> Params = new List<Parameter>();
        public Body Body;

        public MethodDeclaration(Identifier id,
            List<Parameter> parameters, Identifier returntype, Body body)
        {
            ReturnType = returntype;
            Id = id;
            Params = parameters;
            Body = body;
        }

        public MethodDeclaration(Identifier id,
            Identifier returntype, Body body)
        {
            ReturnType = returntype;
            Id = id;
            Body = body;
        }

        public MethodDeclaration(Identifier id,
            List<Parameter> parameters, Body body)
        {
            Id = id;
            Params = parameters;
            Body = body;
        }

        public MethodDeclaration()
        {
        }
    }

    class Parameter
    {
        public Identifier Id;
        public ClassName ClassName;

        public Parameter(Identifier id, ClassName className)
        {
            ClassName = className;
            Id = id;
        }
    }


    class Body
    {
        public List<VariableDeclaration> Variables = new List<VariableDeclaration>();
        public List<Statement> Statements = new List<Statement>();

        public Body()
        {
        }
    }

    class ConstructorDeclaration : MemberDeclaration
    {
        public List<Parameter> Parameters = new List<Parameter>();
        public Body Body;

        public ConstructorDeclaration(List<Parameter> parameters, Body body)
        {
            Parameters = parameters;
            Body = body;
        }

        public ConstructorDeclaration(Body body)
        {
            Body = body;
        }

        public ConstructorDeclaration()
        {
        }
    }

    class Statement : Node
    {
        public Statement()
        {
        }
    }

    class Assignment : Statement
    {
        public Identifier LeftPart;
        public Expression RightPart;

        public Assignment(Identifier leftPart, Expression rightPart)
        {
            LeftPart = leftPart;
            RightPart = rightPart;
        }
    }


    class WhileLoop : Statement
    {
        public Expression Condition;
        public Body Body;

        public WhileLoop(Expression condition, Body body)
        {
            Condition = condition;
            Body = body;
        }
    }


    class IfStatement : Statement
    {
        public Expression Condition;
        public Body TrueStatement;
        public Body FalseStatement;

        public IfStatement(Expression condition, Body trueStatement)
        {
            Condition = condition;
            TrueStatement = trueStatement;
        }

        public IfStatement(Expression condition, Body trueStatement, Body falseStatement)
        {
            Condition = condition;
            TrueStatement = trueStatement;
            FalseStatement = falseStatement;
        }
    }


    class ReturnStatement : Statement
    {
        public Expression expression;

        public ReturnStatement(Expression exp)
        {
            expression = exp;
        }

        public ReturnStatement()
        {
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


    class Node
    {
    }

    class Expression
    {
       

        public Expression()
        {
        }
    }

    class Primary : Node
    {
    }

    class IntegerLiteral : Primary
    {
    }

    class RealLiteral : Primary
    {
    }

    class BooleanLiteral : Primary
    {
    }
}