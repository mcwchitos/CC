// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  ORISHDESKTOP
// DateTime: 04.12.2019 16:12:19
// UserName: richr
// Input file <ToyLang.Language.grammar.y - 04.12.2019 16:12:13>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;

namespace CCAss3
{
internal enum Token {error=2,EOF=3,IDENTIFIER=4,NUMBER=5,CLASS=6,
    EXTENDS=7,IF=8,ELSE=9,IS=10,END=11,THIS=12,
    THEN=13,WHILE=14,LOOP=15,TRUE=16,FALSE=17,RETURN=18,
    METHOD=19,VAR=20,INTEGER=21,REAL=22,BOOLEAN=23,LBRACE=24,
    RBRACE=25,LPAREN=26,RPAREN=27,LBRACKET=28,RBRACKET=29,COMMA=30,
    DOT=31,COLON=32,ASSIGN=33};

internal partial struct ValueType
{ 
			public int intNumber;
			public int intValue;
			public double realNumber;
			public string identifier; 
			public Node node;
			public object obj;
	   }
// Abstract base class for GPLEX scanners
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
internal abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
internal class ScanObj {
  public int token;
  public ValueType yylval;
  public LexLocation yylloc;
  public ScanObj( int t, ValueType val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
internal partial class ToyLangParser: ShiftReduceParser<ValueType, LexLocation>
{
  // Verbatim content from ToyLang.Language.grammar.y - 04.12.2019 16:12:13
       public RootNode Root = new RootNode();
  // End verbatim content from ToyLang.Language.grammar.y - 04.12.2019 16:12:13

#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[55];
  private static State[] states = new State[93];
  private static string[] nonTerms = new string[] {
      "Program", "$accept", "ClassDeclarations", "ClassDeclaration", "ClassName", 
      "Extension", "MemberDeclarations", "MemberDeclaration", "VariableDeclaration", 
      "MethodDeclaration", "ConstructorDeclaration", "Parameters", "Body", "Expression", 
      "MethodReturn", "ParameterList", "Parameter", "VariableDeclarations", "Statements", 
      "Statement", "Assignment", "IfStatement", "WhileLoop", "ReturnStatement", 
      "Primary", "ExpressionArguments", "ExpressionArgument", "Arguments", "Expressions", 
      };

  static ToyLangParser() {
    states[0] = new State(new int[]{6,6,3,-3},new int[]{-1,1,-3,3,-4,4});
    states[1] = new State(new int[]{3,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(new int[]{6,6,3,-3},new int[]{-3,5,-4,4});
    states[5] = new State(-4);
    states[6] = new State(new int[]{4,31},new int[]{-5,7});
    states[7] = new State(new int[]{7,91,10,-8},new int[]{-6,8});
    states[8] = new State(new int[]{10,9});
    states[9] = new State(new int[]{20,14,19,38,12,85,11,-12},new int[]{-7,10,-8,90,-9,13,-10,37,-11,84});
    states[10] = new State(new int[]{11,11,20,14,19,38,12,85},new int[]{-8,12,-9,13,-10,37,-11,84});
    states[11] = new State(-5);
    states[12] = new State(-11);
    states[13] = new State(-13);
    states[14] = new State(new int[]{4,15});
    states[15] = new State(new int[]{32,16});
    states[16] = new State(new int[]{12,29,4,31},new int[]{-14,17,-25,18,-5,30});
    states[17] = new State(-17);
    states[18] = new State(new int[]{31,21,11,-44,20,-44,19,-44,12,-44,4,-44,8,-44,14,-44,18,-44,9,-44,27,-44,30,-44,13,-44,15,-44},new int[]{-26,19,-27,36});
    states[19] = new State(new int[]{31,21,11,-45,20,-45,19,-45,12,-45,4,-45,8,-45,14,-45,18,-45,9,-45,27,-45,30,-45,13,-45,15,-45},new int[]{-27,20});
    states[20] = new State(-47);
    states[21] = new State(new int[]{4,22});
    states[22] = new State(new int[]{26,24,31,-50,11,-50,20,-50,19,-50,12,-50,4,-50,8,-50,14,-50,18,-50,9,-50,27,-50,30,-50,13,-50,15,-50},new int[]{-28,23});
    states[23] = new State(-48);
    states[24] = new State(new int[]{12,29,4,31},new int[]{-29,25,-14,35,-25,18,-5,30});
    states[25] = new State(new int[]{27,26,30,27});
    states[26] = new State(-49);
    states[27] = new State(new int[]{12,29,4,31},new int[]{-14,28,-25,18,-5,30});
    states[28] = new State(-52);
    states[29] = new State(-53);
    states[30] = new State(-54);
    states[31] = new State(new int[]{28,32,7,-6,10,-6,31,-6,11,-6,20,-6,19,-6,12,-6,4,-6,8,-6,14,-6,18,-6,9,-6,27,-6,30,-6,29,-6,13,-6,15,-6});
    states[32] = new State(new int[]{4,31},new int[]{-5,33});
    states[33] = new State(new int[]{29,34});
    states[34] = new State(-7);
    states[35] = new State(-51);
    states[36] = new State(-46);
    states[37] = new State(-14);
    states[38] = new State(new int[]{4,39});
    states[39] = new State(new int[]{26,75,32,-21,10,-21},new int[]{-12,40});
    states[40] = new State(new int[]{32,73,10,-19},new int[]{-15,41});
    states[41] = new State(new int[]{10,42});
    states[42] = new State(new int[]{20,14,11,-26,4,-30,8,-30,14,-30,18,-30},new int[]{-13,43,-18,45,-9,61});
    states[43] = new State(new int[]{11,44});
    states[44] = new State(-18);
    states[45] = new State(new int[]{4,49,8,53,14,63,18,69,20,14,11,-33,9,-33},new int[]{-19,46,-9,71,-20,72,-21,48,-22,52,-23,62,-24,68});
    states[46] = new State(new int[]{4,49,8,53,14,63,18,69,11,-27,9,-27},new int[]{-20,47,-21,48,-22,52,-23,62,-24,68});
    states[47] = new State(-32);
    states[48] = new State(-34);
    states[49] = new State(new int[]{33,50});
    states[50] = new State(new int[]{12,29,4,31},new int[]{-14,51,-25,18,-5,30});
    states[51] = new State(-38);
    states[52] = new State(-35);
    states[53] = new State(new int[]{12,29,4,31},new int[]{-14,54,-25,18,-5,30});
    states[54] = new State(new int[]{13,55});
    states[55] = new State(new int[]{20,14,11,-26,9,-26,4,-30,8,-30,14,-30,18,-30},new int[]{-13,56,-18,45,-9,61});
    states[56] = new State(new int[]{11,57,9,58});
    states[57] = new State(-39);
    states[58] = new State(new int[]{20,14,11,-26,4,-30,8,-30,14,-30,18,-30},new int[]{-13,59,-18,45,-9,61});
    states[59] = new State(new int[]{11,60});
    states[60] = new State(-40);
    states[61] = new State(-28);
    states[62] = new State(-36);
    states[63] = new State(new int[]{12,29,4,31},new int[]{-14,64,-25,18,-5,30});
    states[64] = new State(new int[]{15,65});
    states[65] = new State(new int[]{20,14,11,-26,4,-30,8,-30,14,-30,18,-30},new int[]{-13,66,-18,45,-9,61});
    states[66] = new State(new int[]{11,67});
    states[67] = new State(-41);
    states[68] = new State(-37);
    states[69] = new State(new int[]{12,29,4,31,8,-42,14,-42,18,-42,11,-42,9,-42},new int[]{-14,70,-25,18,-5,30});
    states[70] = new State(-43);
    states[71] = new State(-29);
    states[72] = new State(-31);
    states[73] = new State(new int[]{4,74});
    states[74] = new State(-20);
    states[75] = new State(new int[]{4,80},new int[]{-16,76,-17,83});
    states[76] = new State(new int[]{27,77,30,78});
    states[77] = new State(-22);
    states[78] = new State(new int[]{4,80},new int[]{-17,79});
    states[79] = new State(-24);
    states[80] = new State(new int[]{32,81});
    states[81] = new State(new int[]{4,31},new int[]{-5,82});
    states[82] = new State(-25);
    states[83] = new State(-23);
    states[84] = new State(-15);
    states[85] = new State(new int[]{26,75,10,-21},new int[]{-12,86});
    states[86] = new State(new int[]{10,87});
    states[87] = new State(new int[]{20,14,11,-26,4,-30,8,-30,14,-30,18,-30},new int[]{-13,88,-18,45,-9,61});
    states[88] = new State(new int[]{11,89});
    states[89] = new State(-16);
    states[90] = new State(-10);
    states[91] = new State(new int[]{4,92});
    states[92] = new State(-9);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-2, new int[]{-1,3});
    rules[2] = new Rule(-1, new int[]{-3});
    rules[3] = new Rule(-3, new int[]{});
    rules[4] = new Rule(-3, new int[]{-4,-3});
    rules[5] = new Rule(-4, new int[]{6,-5,-6,10,-7,11});
    rules[6] = new Rule(-5, new int[]{4});
    rules[7] = new Rule(-5, new int[]{4,28,-5,29});
    rules[8] = new Rule(-6, new int[]{});
    rules[9] = new Rule(-6, new int[]{7,4});
    rules[10] = new Rule(-7, new int[]{-8});
    rules[11] = new Rule(-7, new int[]{-7,-8});
    rules[12] = new Rule(-8, new int[]{});
    rules[13] = new Rule(-8, new int[]{-9});
    rules[14] = new Rule(-8, new int[]{-10});
    rules[15] = new Rule(-8, new int[]{-11});
    rules[16] = new Rule(-11, new int[]{12,-12,10,-13,11});
    rules[17] = new Rule(-9, new int[]{20,4,32,-14});
    rules[18] = new Rule(-10, new int[]{19,4,-12,-15,10,-13,11});
    rules[19] = new Rule(-15, new int[]{});
    rules[20] = new Rule(-15, new int[]{32,4});
    rules[21] = new Rule(-12, new int[]{});
    rules[22] = new Rule(-12, new int[]{26,-16,27});
    rules[23] = new Rule(-16, new int[]{-17});
    rules[24] = new Rule(-16, new int[]{-16,30,-17});
    rules[25] = new Rule(-17, new int[]{4,32,-5});
    rules[26] = new Rule(-13, new int[]{});
    rules[27] = new Rule(-13, new int[]{-18,-19});
    rules[28] = new Rule(-18, new int[]{-9});
    rules[29] = new Rule(-18, new int[]{-18,-9});
    rules[30] = new Rule(-18, new int[]{});
    rules[31] = new Rule(-19, new int[]{-20});
    rules[32] = new Rule(-19, new int[]{-19,-20});
    rules[33] = new Rule(-19, new int[]{});
    rules[34] = new Rule(-20, new int[]{-21});
    rules[35] = new Rule(-20, new int[]{-22});
    rules[36] = new Rule(-20, new int[]{-23});
    rules[37] = new Rule(-20, new int[]{-24});
    rules[38] = new Rule(-21, new int[]{4,33,-14});
    rules[39] = new Rule(-22, new int[]{8,-14,13,-13,11});
    rules[40] = new Rule(-22, new int[]{8,-14,13,-13,9,-13,11});
    rules[41] = new Rule(-23, new int[]{14,-14,15,-13,11});
    rules[42] = new Rule(-24, new int[]{18});
    rules[43] = new Rule(-24, new int[]{18,-14});
    rules[44] = new Rule(-14, new int[]{-25});
    rules[45] = new Rule(-14, new int[]{-25,-26});
    rules[46] = new Rule(-26, new int[]{-27});
    rules[47] = new Rule(-26, new int[]{-26,-27});
    rules[48] = new Rule(-27, new int[]{31,4,-28});
    rules[49] = new Rule(-28, new int[]{26,-29,27});
    rules[50] = new Rule(-28, new int[]{});
    rules[51] = new Rule(-29, new int[]{-14});
    rules[52] = new Rule(-29, new int[]{-29,30,-14});
    rules[53] = new Rule(-25, new int[]{12});
    rules[54] = new Rule(-25, new int[]{-5});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Token.error, (int)Token.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 5: // ClassDeclaration -> CLASS, ClassName, Extension, IS, MemberDeclarations, END
{ClassDeclaration c = new ClassDeclaration(); c.ClassName = ValueStack[ValueStack.Depth-5].obj as ClassName; c.Extends = ValueStack[ValueStack.Depth-4].obj as Identifier; c.Members = ValueStack[ValueStack.Depth-2].obj as List<MemberDeclaration>;  Root.Classes.Add(c);}
        break;
      case 6: // ClassName -> IDENTIFIER
{CurrentSemanticValue.obj = new ClassName(new Identifier(ValueStack[ValueStack.Depth-1].identifier));}
        break;
      case 7: // ClassName -> IDENTIFIER, LBRACKET, ClassName, RBRACKET
{CurrentSemanticValue.obj = new ClassName(new Identifier(ValueStack[ValueStack.Depth-4].identifier), ValueStack[ValueStack.Depth-2].obj as ClassName);}
        break;
      case 9: // Extension -> EXTENDS, IDENTIFIER
{CurrentSemanticValue.obj = new Identifier(ValueStack[ValueStack.Depth-1].identifier);}
        break;
      case 10: // MemberDeclarations -> MemberDeclaration
{CurrentSemanticValue.obj = new List<MemberDeclaration>(); (CurrentSemanticValue.obj as List<MemberDeclaration> ).Add(ValueStack[ValueStack.Depth-1].obj as MemberDeclaration);}
        break;
      case 11: // MemberDeclarations -> MemberDeclarations, MemberDeclaration
{(CurrentSemanticValue.obj as List<MemberDeclaration>).Add(ValueStack[ValueStack.Depth-1].obj as MemberDeclaration);}
        break;
      case 12: // MemberDeclaration -> /* empty */
{CurrentSemanticValue.obj = null;}
        break;
      case 13: // MemberDeclaration -> VariableDeclaration
{CurrentSemanticValue.obj = ValueStack[ValueStack.Depth-1].obj;}
        break;
      case 14: // MemberDeclaration -> MethodDeclaration
{CurrentSemanticValue.obj = ValueStack[ValueStack.Depth-1].obj;}
        break;
      case 15: // MemberDeclaration -> ConstructorDeclaration
{CurrentSemanticValue.obj = ValueStack[ValueStack.Depth-1].obj;}
        break;
      case 16: // ConstructorDeclaration -> THIS, Parameters, IS, Body, END
{CurrentSemanticValue.obj = new ConstructorDeclaration(ValueStack[ValueStack.Depth-4].obj as List<Parameter>, ValueStack[ValueStack.Depth-2].obj as Body);}
        break;
      case 17: // VariableDeclaration -> VAR, IDENTIFIER, COLON, Expression
{CurrentSemanticValue.obj = new VariableDeclaration(new Identifier(ValueStack[ValueStack.Depth-3].identifier), ValueStack[ValueStack.Depth-1].obj as Expression);}
        break;
      case 18: // MethodDeclaration -> METHOD, IDENTIFIER, Parameters, MethodReturn, IS, Body, 
               //                      END
{CurrentSemanticValue.obj = new MethodDeclaration(new Identifier(ValueStack[ValueStack.Depth-6].identifier), ValueStack[ValueStack.Depth-5].obj as List<Parameter>, ValueStack[ValueStack.Depth-4].obj as Identifier, ValueStack[ValueStack.Depth-2].obj as Body);}
        break;
      case 19: // MethodReturn -> /* empty */
{CurrentSemanticValue.obj = null;}
        break;
      case 20: // MethodReturn -> COLON, IDENTIFIER
{CurrentSemanticValue.obj = new Identifier(ValueStack[ValueStack.Depth-1].identifier);}
        break;
      case 21: // Parameters -> /* empty */
{CurrentSemanticValue.obj = new List<Parameter>();}
        break;
      case 22: // Parameters -> LPAREN, ParameterList, RPAREN
{CurrentSemanticValue.obj = ValueStack[ValueStack.Depth-2].obj;}
        break;
      case 23: // ParameterList -> Parameter
{CurrentSemanticValue.obj = new List<Parameter>(); (CurrentSemanticValue.obj as List<Parameter> ).Add(ValueStack[ValueStack.Depth-1].obj as Parameter);}
        break;
      case 24: // ParameterList -> ParameterList, COMMA, Parameter
{(CurrentSemanticValue.obj as List<Parameter>).Add(ValueStack[ValueStack.Depth-1].obj as Parameter);}
        break;
      case 25: // Parameter -> IDENTIFIER, COLON, ClassName
{CurrentSemanticValue.obj = new Parameter(new Identifier(ValueStack[ValueStack.Depth-3].identifier), ValueStack[ValueStack.Depth-1].obj as ClassName); }
        break;
      case 26: // Body -> /* empty */
{CurrentSemanticValue.obj = new Body();}
        break;
      case 27: // Body -> VariableDeclarations, Statements
{Body b = new Body(); b.Variables = ValueStack[ValueStack.Depth-2].obj as List<VariableDeclaration>; b.Statements = ValueStack[ValueStack.Depth-1].obj as List<Statement>; CurrentSemanticValue.obj = b;}
        break;
      case 28: // VariableDeclarations -> VariableDeclaration
{CurrentSemanticValue.obj = new List<VariableDeclaration>(); (CurrentSemanticValue.obj as List<VariableDeclaration> ).Add(ValueStack[ValueStack.Depth-1].obj as VariableDeclaration);}
        break;
      case 29: // VariableDeclarations -> VariableDeclarations, VariableDeclaration
{(CurrentSemanticValue.obj as List<VariableDeclaration>).Add(ValueStack[ValueStack.Depth-1].obj as VariableDeclaration);}
        break;
      case 31: // Statements -> Statement
{CurrentSemanticValue.obj = new List<Statement>(); (CurrentSemanticValue.obj as List<Statement> ).Add(ValueStack[ValueStack.Depth-1].obj as Statement);}
        break;
      case 32: // Statements -> Statements, Statement
{(CurrentSemanticValue.obj as List<Statement>).Add(ValueStack[ValueStack.Depth-1].obj as Statement);}
        break;
      case 34: // Statement -> Assignment
{CurrentSemanticValue.obj = ValueStack[ValueStack.Depth-1].obj;}
        break;
      case 35: // Statement -> IfStatement
{CurrentSemanticValue.obj = ValueStack[ValueStack.Depth-1].obj;}
        break;
      case 36: // Statement -> WhileLoop
{CurrentSemanticValue.obj = ValueStack[ValueStack.Depth-1].obj;}
        break;
      case 37: // Statement -> ReturnStatement
{CurrentSemanticValue.obj = ValueStack[ValueStack.Depth-1].obj;}
        break;
      case 38: // Assignment -> IDENTIFIER, ASSIGN, Expression
{CurrentSemanticValue.obj = new Assignment(new Identifier(ValueStack[ValueStack.Depth-3].identifier), ValueStack[ValueStack.Depth-1].obj as Expression);}
        break;
      case 39: // IfStatement -> IF, Expression, THEN, Body, END
{CurrentSemanticValue.obj = new IfStatement(ValueStack[ValueStack.Depth-4].obj as Expression, ValueStack[ValueStack.Depth-2].obj as Body);}
        break;
      case 40: // IfStatement -> IF, Expression, THEN, Body, ELSE, Body, END
{CurrentSemanticValue.obj = new IfStatement(ValueStack[ValueStack.Depth-6].obj as Expression, ValueStack[ValueStack.Depth-4].obj as Body, ValueStack[ValueStack.Depth-2].obj as Body);}
        break;
      case 41: // WhileLoop -> WHILE, Expression, LOOP, Body, END
{CurrentSemanticValue.obj = new WhileLoop(ValueStack[ValueStack.Depth-4].obj as Expression, ValueStack[ValueStack.Depth-2].obj as Body);}
        break;
      case 42: // ReturnStatement -> RETURN
{CurrentSemanticValue.obj = new ReturnStatement();}
        break;
      case 43: // ReturnStatement -> RETURN, Expression
{CurrentSemanticValue.obj = new ReturnStatement(ValueStack[ValueStack.Depth-1].obj as Expression);}
        break;
      case 44: // Expression -> Primary
{CurrentSemanticValue.obj = new Expression(ValueStack[ValueStack.Depth-1].obj as Primary);}
        break;
      case 45: // Expression -> Primary, ExpressionArguments
{CurrentSemanticValue.obj = new Expression(ValueStack[ValueStack.Depth-2].obj as Primary, ValueStack[ValueStack.Depth-1].obj as List<ExpressionArgument>);}
        break;
      case 46: // ExpressionArguments -> ExpressionArgument
{CurrentSemanticValue.obj = new List<ExpressionArgument>(); (CurrentSemanticValue.obj as List<ExpressionArgument> ).Add(ValueStack[ValueStack.Depth-1].obj as ExpressionArgument);}
        break;
      case 47: // ExpressionArguments -> ExpressionArguments, ExpressionArgument
{(CurrentSemanticValue.obj as List<ExpressionArgument> ).Add(ValueStack[ValueStack.Depth-1].obj as ExpressionArgument);}
        break;
      case 48: // ExpressionArgument -> DOT, IDENTIFIER, Arguments
{CurrentSemanticValue.obj = new ExpressionArgument(new Identifier(ValueStack[ValueStack.Depth-2].identifier), ValueStack[ValueStack.Depth-1].obj as List<Expression>);}
        break;
      case 49: // Arguments -> LPAREN, Expressions, RPAREN
{CurrentSemanticValue.obj = ValueStack[ValueStack.Depth-2].obj as List<Expression>;}
        break;
      case 51: // Expressions -> Expression
{CurrentSemanticValue.obj = new List<Expression>(); (CurrentSemanticValue.obj as List<Expression> ).Add(ValueStack[ValueStack.Depth-1].obj as Expression);}
        break;
      case 52: // Expressions -> Expressions, COMMA, Expression
{(CurrentSemanticValue.obj as List<Expression> ).Add(ValueStack[ValueStack.Depth-1].obj as Expression);}
        break;
      case 53: // Primary -> THIS
{CurrentSemanticValue.obj = new Identifier("this");}
        break;
      case 54: // Primary -> ClassName
{CurrentSemanticValue.obj = ValueStack[ValueStack.Depth-1].obj;}
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((Token)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Token)terminal).ToString();
    else
        return CharToString((char)terminal);
  }


}
}
