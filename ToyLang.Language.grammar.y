%namespace CCAss3
%partial
%parsertype ToyLangParser
%visibility internal
%tokentype Token

%{
       public RootNode Root = new RootNode();
%}

%union { 
			public int intNumber;
			public int intValue;
			public double realNumber;
			public string identifier; 
			public Node node;
			public object obj;
	   }

// Identifiers & numbers
%token IDENTIFIER
%token NUMBER

// New Keywords
%token CLASS
%token EXTENDS
%token IF
%token ELSE
%token IS
%token END
%token THIS
%token THEN
%token WHILE
%token LOOP
%token TRUE
%token FALSE
%token RETURN
%token METHOD
%token VAR



// Keywords

// Delimiters

%token LBRACE     //  {
%token RBRACE   //  }
%token LPAREN     //  (
%token RPAREN      //  )
%token LBRACKET    //  [
%token RBRACKET    //  ]
%token COMMA       //  ,
%token DOT         //  .
%token COLON   //  :

// Operator signs
%token ASSIGN    //  :=


%start Program

%%
Program   
       : ClassDeclarations    
       ;



ClassDeclarations
       : /* empty */
       | ClassDeclaration ClassDeclarations
       ;

ClassDeclaration
       : CLASS ClassName Extension IS MemberDeclarations END {ClassDeclaration c = new ClassDeclaration(); c.ClassName = $2.obj as ClassName; c.Extends = $3.obj as Identifier; c.Members = $5.obj as List<MemberDeclaration>;  Root.Classes.Add(c);}
       ;
       
ClassName
	: IDENTIFIER {$$.obj = new ClassName(new Identifier($1.identifier));}
	| IDENTIFIER LBRACKET ClassName RBRACKET {$$.obj = new ClassName(new Identifier($1.identifier), $3.obj as ClassName);}
	;
	
Extension
       : /* empty */
       | EXTENDS IDENTIFIER {$$.obj = new Identifier($2.identifier);}
       ;

MemberDeclarations
       :                    MemberDeclaration {$$.obj = new List<MemberDeclaration>(); ($$.obj as List<MemberDeclaration> ).Add($1.obj as MemberDeclaration);}
       | MemberDeclarations MemberDeclaration {($$.obj as List<MemberDeclaration>).Add($2.obj as MemberDeclaration);}
       ;

MemberDeclaration
       : /* empty */ {$$.obj = null;}
       | VariableDeclaration {$$.obj = $1.obj;}
       | MethodDeclaration {$$.obj = $1.obj;}
       | ConstructorDeclaration  {$$.obj = $1.obj;}
       ;

ConstructorDeclaration 
	: THIS Parameters IS Body END {$$.obj = new ConstructorDeclaration($2.obj as List<Parameter>, $4.obj as Body);}
	;


VariableDeclaration
	: VAR IDENTIFIER COLON Expression {$$.obj = new VariableDeclaration(new Identifier($2.identifier), $4.obj as Expression);}
	;



MethodDeclaration
	: METHOD IDENTIFIER Parameters MethodReturn IS Body END {$$.obj = new MethodDeclaration(new Identifier($2.identifier), $3.obj as List<Parameter>, $4.obj as Identifier, $6.obj as Body);}
	;


MethodReturn
	: /* empty */ {$$.obj = null;}
	| COLON IDENTIFIER {$$.obj = new Identifier($2.identifier);}
	;

Parameters
       : /* empty */ {$$.obj = new List<Parameter>();}
       | LPAREN ParameterList RPAREN {$$.obj = $2.obj;}
       ;

ParameterList
       :                     Parameter {$$.obj = new List<Parameter>(); ($$.obj as List<Parameter> ).Add($1.obj as Parameter);}
       | ParameterList COMMA Parameter {($$.obj as List<Parameter>).Add($3.obj as Parameter);}
       ;

Parameter
       : IDENTIFIER COLON ClassName {$$.obj = new Parameter(new Identifier($1.identifier), $3.obj as ClassName); }
       ;


Body
       : /* empty */ {$$.obj = new Body();}
       | VariableDeclarations Statements  {Body b = new Body(); b.Variables = $1.obj as List<VariableDeclaration>; b.Statements = $2.obj as List<Statement>; $$.obj = b;}
       ;

VariableDeclarations
	: VariableDeclaration {$$.obj = new List<VariableDeclaration>(); ($$.obj as List<VariableDeclaration> ).Add($1.obj as VariableDeclaration);}
	| VariableDeclarations VariableDeclaration {($$.obj as List<VariableDeclaration>).Add($2.obj as VariableDeclaration);}
	| /* empty */ 
	;

Statements
       :            Statement {$$.obj = new List<Statement>(); ($$.obj as List<Statement> ).Add($1.obj as Statement);}
       | Statements Statement {($$.obj as List<Statement>).Add($2.obj as Statement);}
       | /* empty */ 
       ;

Statement
       : Assignment {$$.obj = $1.obj;}
       | IfStatement {$$.obj = $1.obj;}
       | WhileLoop {$$.obj = $1.obj;}
       | ReturnStatement {$$.obj = $1.obj;}
       ;



Assignment
       : IDENTIFIER ASSIGN Expression {$$.obj = new Assignment(new Identifier($1.identifier), $3.obj as Expression);}
       ;

IfStatement
       : IF Expression THEN Body END 
       | IF Expression THEN Body ELSE Body END 
       ;

WhileLoop
       : WHILE Expression LOOP Body END
       ;

ReturnStatement
       : RETURN             
       | RETURN Expression 
       ;

Expression 
	: Primary ExpressionList {$$.obj = new Expression();}
	;

ExpressionList
	: /* empty */ 
	| DOT IDENTIFIER Arguments
	| ExpressionList DOT IDENTIFIER Arguments 
	;
	
Arguments
	: LPAREN Expressions RPAREN
	| /*empty*/
	;

Expressions 
	: Expression
	| Expressions COMMA Expression
	;


Primary 	

	 : THIS 

	 ;
%%

