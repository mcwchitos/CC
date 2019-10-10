%namespace CCAss3
%scannertype ToyLangScanner
%visibility internal
%tokentype Token

%option stack, minimize, parser, verbose, persistbuffer, noembedbuffers 

Eol             (\r\n?|\n)
NotWh           [^ \t\r\n]
Space           [ \t]

%{

%}

%%

/* Scanner body */

{Space}+		/* skip */


[ \t\n]                 ;
"IMPORT"                {return (int)Token.IMPORT;}
"CLASS"                 {return (int)Token.CLASS;}
"EXTENDS"               {return (int)Token.EXTENDS;}
"PRIVATE"               {return (int)Token.PRIVATE;}
"PUBLIC"                {return (int)Token.PUBLIC;}
"STATIC"                {return (int)Token.STATIC;}
"VOID"                  {return (int)Token.VOID;}
"IF"                    {return (int)Token.IF;}
"ELSE"                  {return (int)Token.ELSE;}
"WHILE"                 {return (int)Token.WHILE;}
"LOOP"                  {return (int)Token.LOOP;}
"RETURN"                {return (int)Token.RETURN;}
"PRINT"                 {return (int)Token.PRINT;}
"NULL"                  {return (int)Token.NULL;}
"NEW"                   {return (int)Token.NEW;}
"INT"                   {return (int)Token.INT;}
"REAL"                  {return (int)Token.REAL;}
[a-zA-Z_][a-zA-Z0-9_]*  {GetIdentifier(); return (int)Token.IDENTIFIER;}
[0-9]*	                {GetNumber(); return (int)Token.NUMBER;}
"="                     {return (int)Token.ASSIGN;}
"=="                    {return (int)Token.EQUAL;}
"!="                    {return (int)Token.NOT_EQUAL;}
"<"                     {return (int)Token.LESS;}
">"                     {return (int)Token.GREATER;}
"("                     {return (int)Token.LPAREN;}
")"                     {return (int)Token.RPAREN;}
"["                     {return (int)Token.LBRACKET;}
"]"                     {return (int)Token.RBRACKET;}
"{"                     {return (int)Token.LBRACE;}
"}"                     {return (int)Token.RBRACE;}
"."                     {return (int)Token.DOT;}
","                     {return (int)Token.COMMA;}
"+"                     {return (int)Token.PLUS;}
"-"                     {return (int)Token.MINUS;}
"*"                     {return (int)Token.MULTIPLY;}
"/"                     {return (int)Token.DIVIDE;}
";"                     {return (int)Token.SEMICOLON;}
.                       {Console.WriteLine("error"); yyerror("PIZDEC");}

%%