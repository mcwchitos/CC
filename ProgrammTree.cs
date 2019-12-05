using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LLVM;
using LLVM.NativeLibrary;
using LLVMSharp;

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

    class ClassName : Primary
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

        public void assign(Identifier leftPart, Expression RightPart)
        {
            leftPart.Equals(RightPart);
            return;
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


    class Identifier: Primary
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
        public Primary Primary;
        public List<ExpressionArgument> RightPart = new List<ExpressionArgument>();

        public Expression(Primary primary, List<ExpressionArgument> rightPart)
        {
            Primary = primary;
            RightPart = rightPart;
            
        }

        
        public Expression(Primary primary)
        {
            Primary = primary;
        }

        
    }

    class ExpressionArgument
    {
        public Identifier Id;
        public List<Expression> Args = new List<Expression>();

        public ExpressionArgument(Identifier id, List<Expression> args)
        {
            Id = id;
            Args = args;
        }

        public ExpressionArgument()
        {
        }
    }

    class Primary 
    {
    }

    class Integer : Primary
    {
        public int Value;

        public Integer(int value)
        {
            Value = value;
        }
    }

    class Real : Primary
    {
        public int Value;

        public Real(int value)
        {
            Value = value;
        }
    }

    class Boolean : Primary
    {
        public string Value;

        public Boolean(string value)
        {
            Value = value;
        }
    }
    
     public class AST_Node
    {
        public string name;
        public AST_Node[] children;
        public bool is_token;
        public string return_type = null;
        public int ival = 0;
        public double dval = 0.0;
        public string identifier_string;

        private static string filepath = "llvm_input.llvm";

        public AST_Node(string name, bool is_token, params AST_Node[] children)
        {
            this.name = name;
            this.children = children;
            this.is_token = is_token;
            this.return_type = null;
            this.identifier_string = null;
        }
        public void to_LLVM()
        {
            string llvm_bitcode_string = LLVM_Translator.callbacks[this.name](this);
            byte[] llvm_bitcode_to_file = Encoding.UTF8.GetBytes(llvm_bitcode_string);
            FileStream llvm_input_fd = File.Create(AST_Node.filepath);
            llvm_input_fd.Write(llvm_bitcode_to_file, 0, llvm_bitcode_to_file.Length);
            llvm_input_fd.Close();
        }
        public void print_self(int spaces)
        {
            string spaces_string = string.Concat(Enumerable.Repeat(" ", spaces));
            Console.Write("{0}", spaces_string);
            if (this.is_token) {

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (this.name == "INTEGER") {
                    Console.Write("<{0}:{1}> ", this.return_type, this.ival);
                }
                if (this.name == "REAL") {
                    Console.Write("<{0}:{1}> ", this.return_type, this.dval);
                }
                if (this.name == "KEYWORD") {
                    Console.Write("{0}", this.identifier_string);
                }
                if (this.name == "IDENTIFIER") {
                    Console.Write("{0}", this.identifier_string);
                }
                if (this.name == "OPERATION") {
                    Console.Write("{0}", this.identifier_string);
                }
                Console.ResetColor();
                Console.WriteLine(" [{0}] ", this.name);
            }
            else {
                Console.WriteLine("NODE: [{0}]", this.name);
                // Console.WriteLine("|");
                foreach (AST_Node child in this.children)
                {
                    if (child != null) {
                        child.print_self(spaces + 1);
                    }
                }
            }
        }
    }

    public static class LLVM_Translator
    {
        public static readonly Dictionary<string, Func<AST_Node, string>> callbacks = new Dictionary<string, Func<AST_Node, string>>
    {
        { "KEYWORD", translate_expression }, // +TRUE, FALSE
        { "INTEGER", translate_integer }, //100, 120
        { "REAL", translate_real }, //110.01023
        { "OPERATION", translate_operation }, // all op + brackets
    };

        private static string translate_expression(AST_Node node)
        {
            if (node.is_token) {
                return "kek";
            } else {
                AST_Node node_child_1 = node.children[0];
                return "kek-before" + translate_expression(node_child_1) + "kek-after";
            }
        }

        private static string translate_integer(AST_Node node)
        {
            if (node.is_token) {
                return "kek";
            } else {
                AST_Node node_child_1 = node.children[0];
                return "kek-before" + translate_expression(node_child_1) + "kek-after";
            }
        }

        private static string translate_real(AST_Node node)
        {
            if (node.is_token) {
                return "kek";
            } else {
                AST_Node node_child_1 = node.children[0];
                return "kek-before" + translate_expression(node_child_1) + "kek-after";
            }
        }

        private static string translate_operation(AST_Node node)
        {
            if (node.is_token) {
                return "kek";
            } else {
                AST_Node node_child_1 = node.children[0];
                return "kek-before" + translate_expression(node_child_1) + "kek-after";
            }
        }
    }
}