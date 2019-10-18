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

// Keywords
%token IMPORT
%token CLASS
%token EXTENDS
%token PRIVATE
%token PUBLIC
%token STATIC
%token VOID
%token IF
%token ELSE
%token WHILE
%token LOOP
%token RETURN
%token PRINT
%token NULL
%token NEW
%token INT
%token REAL
// Delimiters

%token LBRACE     //  {
%token RBRACE   //  }
%token LPAREN     //  (
%token RPAREN      //  )
%token LBRACKET    //  [
%token RBRACKET    //  ]
%token COMMA       //  ,
%token DOT         //  .
%token SEMICOLON   //  ;

// Operator signs
%token ASSIGN    //  =
%token LESS       //  <
%token GREATER     //  >
%token EQUAL       //  ==
%token NOT_EQUAL   //  !=
%token PLUS        //  +
%token MINUS       //  -
%token MULTIPLY    //  *
%token DIVIDE      //  /

%start CompilationUnit

%%
CompilationUnit   
       : Imports ClassDeclarations    
       ;

Imports
       :  /* empty */
       | Import Imports
       ;

Import
       : IMPORT IDENTIFIER SEMICOLON {Root.Imports.Add(new Identifier($2.identifier));}
       ;

ClassDeclarations
       : /* empty */
       | ClassDeclaration ClassDeclarations
       ;

ClassDeclaration
       : CLASS CompoundName Extension SEMICOLON ClassBody {ClassDeclaration c = new ClassDeclaration(); c.Id= $2.obj as List<Identifier>; c.Extends = (Identifier) $3.node; Root.Classes.Add(c); c.Scope = 0; c.Body = $5.obj as ClassBody;}
       | PUBLIC CLASS CompoundName Extension SEMICOLON ClassBody {ClassDeclaration c = new ClassDeclaration(); c.Id= $2.obj as List<Identifier>; c.Extends = (Identifier) $3.node; Root.Classes.Add(c); c.Scope = 1; c.Body = $6.obj as ClassBody;}
       ;

Extension
       : /* empty */
       | EXTENDS IDENTIFIER {$$.node = new Identifier($2.identifier);}
       ;

ClassBody
       : LBRACE              RBRACE {$$.obj = new ClassBody();}
       | LBRACE ClassMembers RBRACE {$$.obj = $2.obj;}
       ;

ClassMembers
       :              ClassMember {ClassBody b = new ClassBody(); $$.obj = b; if($1.intNumber == 0){b.Fields.Add($1.obj as FieldDeclaration);}else{b.Methods.Add($1.obj as MethodDeclaration);};}
       | ClassMembers ClassMember {ClassBody b = $$.obj as ClassBody; $$.obj = b; if($2.intNumber == 0){b.Fields.Add($2.obj as FieldDeclaration);}else{b.Methods.Add($2.obj as MethodDeclaration);};}
       ;

ClassMember
       : FieldDeclaration {$$.intNumber = 0; $$.obj = $1.obj;}
       | MethodDeclaration {$$.intNumber = 1; $$.obj = $1.obj;}
       ;

FieldDeclaration
       : Visibility Staticness Type IDENTIFIER SEMICOLON 
       {FieldDeclaration f = new FieldDeclaration(); f.Visibility = $1.intNumber; f.Staticness = $2.intNumber;
       f.Type = $3.obj as CType; f.Id = new Identifier($4.identifier); $$.obj = f;}
       ;

Visibility
       : /* empty */ {$$.intNumber = 0;}
       | PRIVATE {$$.intNumber = 0;}
       | PUBLIC {$$.intNumber = 1;}
       ;

Staticness
       : /* empty */ {$$.intNumber = 0;}
       | STATIC {$$.intNumber = 1;}
       ;

MethodDeclaration
       : Visibility Staticness MethodType IDENTIFIER Parameters Body   {MethodDeclaration m = new MethodDeclaration(); m.Visibility = $1.intNumber; m.Staticness = $2.intNumber;
        m.MethodType= (CType) $3.obj; m.Id = new Identifier($4.identifier); m.Params = $5.obj as List<Parameter>; $$.obj = m; m.Body = $6.obj as MethodBody;}
           
            
       ;

Parameters
       : LPAREN               RPAREN {$$.obj = new List<Parameter>();}
       | LPAREN ParameterList RPAREN {$$.obj = $2.obj;}
       ;

ParameterList
       :                     Parameter {$$.obj = new List<Parameter>(); ($$.obj as List<Parameter> ).Add($1.obj as Parameter);}
       | ParameterList COMMA Parameter {($$.obj as List<Parameter>).Add($3.obj as Parameter);}
       ;

Parameter
       : Type IDENTIFIER {$$.obj = new Parameter($1.obj as CType, new Identifier($2.identifier)); }
       ;

MethodType
       : Type {$$.obj = $1.obj;}
       | VOID {$$.obj = new CType();}
       ;

Body
       : LBRACE RBRACE {$$.obj = new MethodBody();}
       | LBRACE LocalDeclarations Statements RBRACE { Console.WriteLine("qq");MethodBody mb = new MethodBody(); mb.LocalDeclarations = $2.obj as List<LocalDeclaration>; mb.Statements = $3.obj as List<Statement>; $$.obj = mb;}
       ;

LocalDeclarations
       :                   LocalDeclaration {$$.obj = new List<LocalDeclaration>(); ($$.obj as List<LocalDeclaration> ).Add($1.obj as LocalDeclaration); }
       | LocalDeclarations LocalDeclaration {($$.obj as List<LocalDeclaration> ).Add($2.obj as LocalDeclaration); }
       ;

LocalDeclaration
       : Type IDENTIFIER SEMICOLON { LocalDeclaration ld = new LocalDeclaration(); ld.Type = $1.obj as CType; ld.Id = new Identifier($2.identifier); $$.obj=ld;}
       ;

Statements
       :            Statement {$$.obj = new List<Statement>(); ($$.obj as List<Statement> ).Add($1.obj as Statement);}
       | Statements Statement {($$.obj as List<Statement> ).Add($2.obj as Statement); }
       ;

Statement
       : Assignment {$$.obj = $1.obj;}
       | IfStatement {$$.obj = $1.obj;}
       | WhileStatement {$$.obj = $1.obj;}
       | ReturnStatement {$$.obj = $1.obj;}
       | CallStatement {$$.obj = $1.obj;}
       | PrintStatement {$$.obj = $1.obj;}
       | Block {$$.obj = $1.obj;}
       ;

Assignment
       : LeftPart ASSIGN Expression SEMICOLON {$$.obj = new Assignment($1.obj as Expression, $3.obj as Expression);}
       ;

LeftPart
       : CompoundName {$$.obj = new LeftPart($1.obj as List<Identifier>);}
       | CompoundName LBRACKET Expression RBRACKET {$$.obj = new LeftPart($1.obj as List<Identifier>, $3.obj as Expression);}
       ;

CompoundName
       :                  IDENTIFIER {$$.obj = new List<Identifier>(); ($$.obj as List<Identifier> ).Add(new Identifier($1.identifier)); }
       | CompoundName DOT IDENTIFIER {($$.obj as List<Identifier>).Add(new Identifier($3.identifier));}
       ;

IfStatement
       : IF LPAREN Relation RPAREN Statement {$$.obj = new IfStatement($3.obj as Expression, $5.obj as Statement);}
       | IF LPAREN Relation RPAREN Statement ELSE Statement {$$.obj = new IfStatement($3.obj as Expression, $5.obj as Statement, $7.obj as Statement);}
       ;

WhileStatement
       : WHILE Relation LOOP Statement SEMICOLON {$$.obj = new WhileStatement($2.obj as Expression, $4.obj as Statement);}
       ;

ReturnStatement
       : RETURN            SEMICOLON {$$.obj = new ReturnStatement();}
       | RETURN Expression SEMICOLON {$$.obj = new ReturnStatement($2.obj as Expression);}
       ;

CallStatement
       : CompoundName LPAREN              RPAREN SEMICOLON {$$.obj = new CallStatement($1.obj as List<Identifier>);}
       | CompoundName LPAREN ArgumentList RPAREN SEMICOLON {$$.obj = new CallStatement($1.obj as List<Identifier>, $3.obj as List<Expression>);}
       ;

ArgumentList
       :                    Expression {List<Expression> e = new List<Expression>(); e.Add($1.obj as Expression); $$.obj = e;}
       | ArgumentList COMMA Expression {List<Expression> e = $$.obj as List<Expression>; e.Add($3.obj as Expression);}
       ;

PrintStatement
       : PRINT Expression SEMICOLON {$$.obj = new PrintStatement($2.obj as Expression);}
       ;

Block
       : LBRACE            RBRACE {$$.obj = new Block();}
       | LBRACE Statements RBRACE {$$.obj = new Block($2.obj as List<Statement>);}
       ;

Relation
       : Expression {$$.obj = $1.obj;}
       | Expression RelationalOperator Expression {$$.obj = new BinaryRelation($1.obj as Expression, $3.obj as Expression, $2.intValue);}
       ;

RelationalOperator
       : LESS {$$.intValue = 0;}
       | GREATER {$$.intValue = 1;}
       | EQUAL {$$.intValue = 3;}
       | NOT_EQUAL {$$.intValue = 2;}
       ;

Expression
       :         Term Terms {BinaryOperation o = $2.obj as BinaryOperation; if(o != null){ o.Left = $1.obj as Expression; $$.obj = o;}else{$$.obj = $1.obj;}}
       | AddSign Term Terms {$$.obj = new BinaryOperation(null, $2.obj as Expression, $1.intValue); BinaryOperation o = $3.obj as BinaryOperation; if(o != null) o.Left = $2.obj as Expression; }
       ;

AddSign
       : PLUS {$$.intValue = 0;}
       | MINUS {$$.intValue = 1;}
       ;

Terms
       : /* empty */
       | AddSign Term Terms {$$.obj = new BinaryOperation(null, $2.obj as Expression, $1.intValue); BinaryOperation o = $3.obj as BinaryOperation; if(o != null) o.Left = $2.obj as Expression; }
       ;

Term
       : Factor Factors {BinaryOperation o = $2.obj as BinaryOperation; if(o != null){ o.Left = $1.obj as Expression; $$.obj = o;}else{$$.obj = $1.obj;}}
       ;

Factors
       : /* empty */
       | MultSign Factor Factors {$$.obj = new BinaryOperation(null, $2.obj as Expression, $1.intValue); BinaryOperation o = $3.obj as BinaryOperation; if(o != null) o.Left = $2.obj as Expression; }
       ;

MultSign
       : MULTIPLY {$$.intValue = 2;}
       | DIVIDE {$$.intValue =3;}
       ;

Factor
       : NUMBER {$$.obj = new IntExpression($1.intNumber);}
       | LeftPart {$$.obj = $1.obj;}
       | NULL {$$.obj = new Expression();}
       | NEW NewType {$$.obj = new CreateExpression($2.obj as CType);}
       | NEW NewType LBRACKET Expression RBRACKET {$$.obj = new CreateExpression($2.obj as CType, $4.obj as Expression);}
       ;

NewType
       : INT {$$.obj = new IntType(false);}
       | REAL {$$.obj = new RealType(false);}
       | IDENTIFIER {$$.obj = new CustomType(new Identifier($1.identifier), false);}
       ;

Type
       : INT        ArrayTail {$$.obj = new IntType($2.intNumber == 1);}
       | REAL       ArrayTail {$$.obj = new RealType($2.intNumber == 1);}
       | IDENTIFIER ArrayTail {$$.obj = new CustomType(new Identifier($1.identifier), $2.intNumber == 1);}
       ;

ArrayTail
       : /* empty */       {$$.intNumber = 0;}
       | LBRACKET RBRACKET {$$.intNumber = 1;}
       ;

%%

