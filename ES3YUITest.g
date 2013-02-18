/*

Copyrights 2008-2009 Xebic Reasearch BV. All rights reserved (see license.txt).
Original work by Patrick Hulsmeijer.

This ANTLR 3 LL(*) grammar is based on Ecma-262 3rd edition (JavaScript 1.5, JScript 5.5). 
The annotations refer to the "A Grammar Summary" section (e.g. A.1 Lexical Grammar) and the numbers in parenthesis to the paragraph numbers (e.g. (7.8) ).
This document is best viewed with ANTLRWorks (www.antlr.org).


The major challenges faced in defining this grammar were:

-1- Ambiguity surrounding the DIV sign in relation to the multiplicative expression and the regular expression literal.
This is solved with some lexer driven magic: a gated semantical predicate turns the recognition of regular expressions on or off, based on the
value of the RegularExpressionsEnabled property. When regular expressions are enabled they take precedence over division expressions. The decision whether
regular expressions are enabled is based on the heuristics that the previous token can be considered as last token of a left-hand-side operand of a division.

-2- Automatic semicolon insertion.
This is solved within the parser. The semicolons are not physically inserted but the situations in which they should are recognized and treated as if they were.
The physical insertion of semicolons would be undesirable because of several reasons:
- performance degration because of how ANTLR handles tokens in token streams
- the alteration of the input, which we need to have unchanged
- it is superfluous being of no interest to AST construction

-3- Unicode identifiers
Because ANTLR couldn't handle the unicode tables defined in the specification well and for performance reasons unicode identifiers are implemented as an action 
driven alternative to ASCII identifiers. First the ASCII version is tried that is defined in detail in this grammar and then the unicode alternative is tried action driven.
Because of the fact that the ASCII version is defined in detail the mTokens switch generation in the lexer can predict identifiers appropriately.
For details see the identifier rules.


The minor challenges were related to converting the grammar to an ANTLR LL(*) grammar:
- Resolving the ambiguity between functionDeclaration vs functionExpression and block vs objectLiteral stemming from the expressionStatement production.
- Left recursive nature of the left hand side expressions.
- The assignmentExpression production.
- The forStatement production.
The grammar was kept as close as possible to the grammar in the "A Grammar Summary" section of Ecma-262.

*/
/*
This file is based on ES3Instrument.g, which is part of JsTestDriver.
The code in this file has been modified from the original for the purposes
of this project.
*/

grammar ES3YUITest ;

options
{
	output = template ;
	rewrite = true ;
	language = CSharp3 ;
}

tokens
{
// Reserved words
	NULL		= 'null' ;
	TRUE		= 'true' ;
	FALSE		= 'false' ;

// Keywords
	BREAK		= 'break' ;
	CASE		= 'case' ;
	CATCH 		= 'catch' ;
	CONTINUE 	= 'continue' ;
	DEFAULT		= 'default' ;
	DELETE		= 'delete' ;
	DO 		= 'do' ;
	ELSE 		= 'else' ;
	FINALLY 	= 'finally' ;
	FOR 		= 'for' ;
	FUNCTION 	= 'function' ;
	IF 		= 'if' ;
	IN 		= 'in' ;
	INSTANCEOF 	= 'instanceof' ;
	NEW 		= 'new' ;
	RETURN 		= 'return' ;
	SWITCH 		= 'switch' ;
	THIS 		= 'this' ;
	THROW 		= 'throw' ;
	TRY 		= 'try' ;
	TYPEOF 		= 'typeof' ;
	VAR 		= 'var' ;
	VOID 		= 'void' ;
	WHILE 		= 'while' ;
	WITH 		= 'with' ;

// Future reserved words
	ABSTRACT	= 'abstract' ;
	BOOLEAN 	= 'boolean' ;
	BYTE 		= 'byte' ;
	CHAR 		= 'char' ;
	CLASS 		= 'class' ;
	CONST 		= 'const' ;
	DEBUGGER 	= 'debugger' ;
	DOUBLE		= 'double' ;
	ENUM 		= 'enum' ;
	EXPORT 		= 'export' ;
	EXTENDS		= 'extends' ;
	FINAL 		= 'final' ;
	FLOAT 		= 'float' ;
	GOTO 		= 'goto' ;
	IMPLEMENTS 	= 'implements' ;
	IMPORT		= 'import' ;
	INT 		= 'int' ;
	INTERFACE 	= 'interface' ;
	LONG 		= 'long' ;
	NATIVE 		= 'native' ;
	PACKAGE 	= 'package' ;
	PRIVATE 	= 'private' ;
	PROTECTED 	= 'protected' ;
	PUBLIC		= 'public' ;
	SHORT 		= 'short' ;
	STATIC 		= 'static' ;
	SUPER 		= 'super' ;
	SYNCHRONIZED 	= 'synchronized' ;
	THROWS 		= 'throws' ;
	TRANSIENT 	= 'transient' ;
	VOLATILE 	= 'volatile' ;

// Punctuators
	LBRACE		= '{' ;
	RBRACE		= '}' ;
	LPAREN		= '(' ;
	RPAREN		= ')' ;
	LBRACK		= '[' ;
	RBRACK		= ']' ;
	DOT		= '.' ;
	SEMIC		= ';' ;
	COMMA		= ',' ;
	LT		= '<' ;
	GT		= '>' ;
	LTE		= '<=' ;
	GTE		= '>=' ;
	EQ		= '==' ;
	NEQ		= '!=' ;
	SAME		= '===' ;
	NSAME		= '!==' ;
	ADD		= '+' ;
	SUB		= '-' ;
	MUL		= '*' ;
	MOD		= '%' ;
	INC		= '++' ;
	DEC		= '--' ;
	SHL		= '<<' ;
	SHR		= '>>' ;
	SHU		= '>>>' ;
	AND		= '&' ;
	OR		= '|' ;
	XOR		= '^' ;
	NOT		= '!' ;
	INV		= '~' ;
	LAND		= '&&' ;
	LOR		= '||' ;
	QUE		= '?' ;
	COLON		= ':' ;
	ASSIGN		= '=' ;
	ADDASS		= '+=' ;
	SUBASS		= '-=' ;
	MULASS		= '*=' ;
	MODASS		= '%=' ;
	SHLASS		= '<<=' ;
	SHRASS		= '>>=' ;
	SHUASS		= '>>>=' ;
	ANDASS		= '&=' ;
	ORASS		= '|=' ;
	XORASS		= '^=' ;
	DIV		= '/' ;
	DIVASS		= '/=' ;
	
// Imaginary
	ARGS ;
	ARRAY ;
	BLOCK ;
	BYFIELD ;
	BYINDEX ;
	CALL ;
	CEXPR ;
	EXPR ;
	FORITER ;
	FORSTEP ;
	ITEM ;
	LABELLED ;
	NAMEDVALUE ;
	NEG ;
	OBJECT ;
	PAREXPR ;
	PDEC ;
	PINC ;
	POS ;
}

@parser::header {
/*
 * YUI Test Coverage
 * Author: Nicholas C. Zakas <nzakas@yahoo-inc.com>
 * Copyright (c) 2009, Yahoo! Inc. All rights reserved.
 * Code licensed under the BSD License:
 *     http://developer.yahoo.net/yui/license.txt
 *     
 * Ported to C# by Joe Doyle <joe@joedoyle.us>
 * Copyright (c) 2013, Joe Doyle.  All rights reserved.
 * This C# Port is also licensed under the BSD License.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Antlr3.ST;
using Antlr3.ST.Language;
}

@lexer::header {
/*
 * YUI Test Coverage
 * Author: Nicholas C. Zakas <nzakas@yahoo-inc.com>
 * Copyright (c) 2009, Yahoo! Inc. All rights reserved.
 * Code licensed under the BSD License:
 *     http://developer.yahoo.net/yui/license.txt
 *     
 * Ported to C# by Joe Doyle <joe@joedoyle.us>
 * Copyright (c) 2013, Joe Doyle.  All rights reserved.
 * This C# Port is also licensed under the BSD License.
 */

using Antlr.Runtime;
using System.Text.RegularExpressions;
}
@lexer::members
{
private IToken last;

private bool AreRegularExpressionsEnabled()
{
	if (last == null)
	{
		return true;
	}
	switch (last.Type)
	{
	// identifier
		case Identifier:
	// literals
		case NULL:
		case TRUE:
		case FALSE:
		case THIS:
		case OctalIntegerLiteral:
		case DecimalLiteral:
		case HexIntegerLiteral:
		case StringLiteral:
	// member access ending 
		case RBRACK:
	// function call or nested expression ending
		case RPAREN:
			return false;
	// otherwise OK
		default:
			return true;
	}
}	
private void ConsumeIdentifierUnicodeStart()
{
	int ch = input.LA(1);
	if (IsIdentifierStartUnicode(ch))
	{
		MatchAny();
		do
		{
			ch = input.LA(1);
			if (ch == '$' || (ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'Z') || ch == '\\' || ch == '_' || (ch >= 'a' && ch <= 'z') || IsIdentifierPartUnicode(ch))
			{
				mIdentifierPart();
			}
			else
			{
				return;
			}
		}
		while (true);
	}
	else
	{
		throw new NoViableAltException();
	}
}

const string start = @"(\p{Lu}|\p{Ll}|\p{Lt}|\p{Lm}|\p{Lo}|\p{Nl})";
const string extend = @"(\p{Mn}|\p{Mc}|\p{Nd}|\p{Pc}|\p{Cf})";

private bool IsIdentifierPartUnicode(int ch)
{
    return false;
    //return Character.isJavaIdentifierPart(ch);
}

private bool IsIdentifierStartUnicode(int ch)
{
    var ident = new Regex(string.Format("{0}({0}|{1})*", start, extend));
    var s = ((char)ch).ToString().Normalize();
    return ident.IsMatch(s);
    //return Character.isJavaIdentifierStart(ch);
}

public IToken nextToken()
{
	var result = NextToken();
	if (result.Channel == TokenChannels.Default)
	{
		last = result;
	}
	return result;		
}
}

@parser::members
{

private bool Verbose { get; set; }

private bool IsLeftHandSideAssign(TemplateParserRuleReturnScope<StringTemplate, IToken> lhs, object[] cached)
{
	if (cached[0] != null)
	{
		return (bool)cached[0];
	}
	
	bool result;
	if (IsLeftHandSideExpression(lhs))
	{
		switch (input.LA(1))
		{
			case ASSIGN:
			case MULASS:
			case DIVASS:
			case MODASS:
			case ADDASS:
			case SUBASS:
			case SHLASS:
			case SHRASS:
			case SHUASS:
			case ANDASS:
			case XORASS:
			case ORASS:
				result = true;
				break;
			default:
				result = false;
				break;
		}
	}
	else
	{
		result = false;
	}
	
	cached[0] = result;
	return result;
}

private string WrapInBraces(IToken start, IToken stop, ITokenStream tokens) {
  if (start == null || stop == null)
  {    
    return null;
  }
  
  if ("{" == start.Text)
  {
    return tokens.ToString(start, stop);
  }
  
  if (Verbose)
  {
    Console.WriteLine("\n[INFO] Adding braces around statement at line {0}", start.Line);
  }
  return "{" + tokens.ToString(start, stop) + "}";
}

private string ToObjectLiteral<T>(List<T> list, bool numbers){
    var builder = new StringBuilder();
    builder.Append("{");
    for (int i=0; i < list.Count; i++){

        if (i > 0){
            builder.Append(",");
        }

        if (numbers){
            builder.Append('"');
            builder.Append(list[i]);
            builder.Append("\":0");
        } else {
            builder.Append(list[i]);
            builder.Append(":0");
        }
    }
    builder.Append("}");
    return builder.ToString();
}

private bool IsLeftHandSideExpression(TemplateParserRuleReturnScope<StringTemplate, IToken> lhs)
{
	if (lhs.Tree == null) // e.g. during backtracking
	{
		return true;
	}
	else
	{
		switch (((BaseTree)lhs.Tree).Type)
		{
		// primaryExpression
			case THIS:
			case Identifier:
			case NULL:
			case TRUE:
			case FALSE:
			case DecimalLiteral:
			case OctalIntegerLiteral:
			case HexIntegerLiteral:
			case StringLiteral:
			case RegularExpressionLiteral:
			case ARRAY:
			case OBJECT:
			case PAREXPR:
		// functionExpression
			case FUNCTION:
		// newExpression
			case NEW:
		// leftHandSideExpression
			case CALL:
			case BYFIELD:
			case BYINDEX:
				return true;
			
			default:
				return false;
		}
	}
}
	
private bool IsLeftHandSideIn(TemplateParserRuleReturnScope<StringTemplate, IToken> lhs, object[] cached)
{
	if (cached[0] != null)
	{
		return (bool)cached[0];
	}
	
	var result = IsLeftHandSideExpression(lhs) && (input.LA(1) == IN);
	cached[0] = result;
	return result;
}

private void PromoteEOL(TemplateParserRuleReturnScope<StringTemplate, IToken> rule)
{
	// Get current token and its type (the possibly offending token).
	var lt = input.LT(1);
	var la = lt.Type;
	
	// We only need to promote an EOL when the current token is offending (not a SEMIC, EOF, RBRACE, EOL or MultiLineComment).
	// EOL and MultiLineComment are not offending as they're already promoted in a previous call to this method.
	// Promoting an EOL means switching it from off channel to on channel.
	// A MultiLineComment gets promoted when it contains an EOL.
	if (!(la == SEMIC || la == EOF || la == RBRACE || la == EOL || la == MultiLineComment))
	{
		// Start on the possition before the current token and scan backwards off channel tokens until the previous on channel token.
		for (int ix = lt.TokenIndex - 1; ix > 0; ix--)
		{
			lt = input.Get(ix);
			if (lt.Channel == TokenChannels.Default)
			{
				// On channel token found: stop scanning.
				break;
			}
			
      if (lt.Type == EOL || (lt.Type == MultiLineComment && Regex.IsMatch(lt.Text, "/.*\r\n|\r|\n")))
			{
				// We found our EOL: promote the token to on channel, position the input on it and reset the rule start.
				lt.Channel = TokenChannels.Default;
				input.Seek(lt.TokenIndex);
				if (rule != null)
				{
					rule.Start = lt;
				}
				break;
			}
		}
	}
}	
}

//
// $<	A.1 Lexical Grammar (7)
//

// Added for lexing purposes

fragment BSLASH
	: '\\'
	;
	
fragment DQUOTE
	: '"'
	;
	
fragment SQUOTE
	: '\''
	;

// $<	Whitespace (7.2)

fragment TAB
	: '\u0009'
	;

fragment VT // Vertical TAB
	: '\u000b'
	;

fragment FF // Form Feed
	: '\u000c'
	;

fragment SP // Space
	: '\u0020'
	;

fragment NBSP // Non-Breaking Space
	: '\u00a0'
	;

fragment USP // Unicode Space Separator (rest of Unicode category Zs)
	: '\u1680'  // OGHAM SPACE MARK
	| '\u180E'  // MONGOLIAN VOWEL SEPARATOR
	| '\u2000'  // EN QUAD
	| '\u2001'  // EM QUAD
	| '\u2002'  // EN SPACE
	| '\u2003'  // EM SPACE
	| '\u2004'  // THREE-PER-EM SPACE
	| '\u2005'  // FOUR-PER-EM SPACE
	| '\u2006'  // SIX-PER-EM SPACE
	| '\u2007'  // FIGURE SPACE
	| '\u2008'  // PUNCTUATION SPACE
	| '\u2009'  // THIN SPACE
	| '\u200A'  // HAIR SPACE
	| '\u202F'  // NARROW NO-BREAK SPACE
	| '\u205F'  // MEDIUM MATHEMATICAL SPACE
	| '\u3000'  // IDEOGRAPHIC SPACE
	;

WhiteSpace
	: ( TAB | VT | FF | SP | NBSP | USP )+ { $channel = TokenChannels.Hidden; }
	;

// $>

// $<	Line terminators (7.3)

fragment LF // Line Feed
	: '\n'
	;

fragment CR // Carriage Return
	: '\r'
	;

fragment LS // Line Separator
	: '\u2028'
	;

fragment PS // Paragraph Separator
	: '\u2029'
	;

fragment LineTerminator
	: CR | LF | LS | PS
	;
		
EOL
	: ( ( CR LF? ) | LF | LS | PS ) { $channel = TokenChannels.Hidden; }
	;
// $>

// $<	Comments (7.4)

MultiLineComment
	: '/*' ( options { greedy = false; } : . )* '*/' { $channel = TokenChannels.Hidden; }
	;

SingleLineComment
	: '//' ( ~( LineTerminator ) )* { $channel = TokenChannels.Hidden; }
	;

// $>

// $<	Tokens (7.5)

token
	: reservedWord
	| Identifier
	| punctuator
	| numericLiteral
	| StringLiteral
	;

// $<	Reserved words (7.5.1)

reservedWord
	: keyword
	| futureReservedWord
	| NULL
	| booleanLiteral
	;

// $>
	
// $<	Keywords (7.5.2)

keyword
	: BREAK
	| CASE
	| CATCH
	| CONTINUE
	| DEFAULT
	| DELETE
	| DO
	| ELSE
	| FINALLY
	| FOR
	| FUNCTION
	| IF
	| IN
	| INSTANCEOF
	| NEW
	| RETURN
	| SWITCH
	| THIS
	| THROW
	| TRY
	| TYPEOF
	| VAR
	| VOID
	| WHILE
	| WITH
	;

// $>

// $<	Future reserved words (7.5.3)

futureReservedWord
	: ABSTRACT
	| BOOLEAN
	| BYTE
	| CHAR
	| CLASS
	| CONST
	| DEBUGGER
	| DOUBLE
	| ENUM
	| EXPORT
	| EXTENDS
	| FINAL
	| FLOAT
	| GOTO
	| IMPLEMENTS
	| IMPORT
	| INT
	| INTERFACE
	| LONG
	| NATIVE
	| PACKAGE
	| PRIVATE
	| PROTECTED
	| PUBLIC
	| SHORT
	| STATIC
	| SUPER
	| SYNCHRONIZED
	| THROWS
	| TRANSIENT
	| VOLATILE
	;

// $>

// $>
	
// $<	Identifiers (7.6)

fragment IdentifierStartASCII
	: 'a'..'z' | 'A'..'Z'
	| '$'
	| '_'
	| BSLASH 'u' HexDigit HexDigit HexDigit HexDigit // UnicodeEscapeSequence
	;

/*
The first two alternatives define how ANTLR can match ASCII characters which can be considered as part of an identifier.
The last alternative matches other characters in the unicode range that can be sonsidered as part of an identifier.
*/
fragment IdentifierPart
	: DecimalDigit
	| IdentifierStartASCII
	| { IsIdentifierPartUnicode(input.LA(1)) }? { MatchAny(); }
	;

fragment IdentifierNameASCIIStart
	: IdentifierStartASCII IdentifierPart*
	;

/*
The second alternative acts as an action driven fallback to evaluate other characters in the unicode range than the ones in the ASCII subset.
Due to the first alternative this grammar defines enough so that ANTLR can generate a lexer that correctly predicts identifiers with characters in the ASCII range.
In that way keywords, other reserved words and ASCII identifiers are recognized with standard ANTLR driven logic. When the first character for an identifier fails to 
match this ASCII definition, the lexer calls consumeIdentifierUnicodeStart because of the action in the alternative. This method checks whether the character matches 
as first character in ranges other than ASCII and consumes further characters belonging to the identifier with help of mIdentifierPart generated out of the 
IdentifierPart rule above.
*/
Identifier
	: IdentifierNameASCIIStart
	| { ConsumeIdentifierUnicodeStart(); }
	;

// $>

// $<	Punctuators (7.7)

punctuator
	: LBRACE
	| RBRACE
	| LPAREN
	| RPAREN
	| LBRACK
	| RBRACK
	| DOT
	| SEMIC
	| COMMA
	| LT
	| GT
	| LTE
	| GTE
	| EQ
	| NEQ
	| SAME
	| NSAME
	| ADD
	| SUB
	| MUL
	| MOD
	| INC
	| DEC
	| SHL
	| SHR
	| SHU
	| AND
	| OR
	| XOR
	| NOT
	| INV
	| LAND
	| LOR
	| QUE
	| COLON
	| ASSIGN
	| ADDASS
	| SUBASS
	| MULASS
	| MODASS
	| SHLASS
	| SHRASS
	| SHUASS
	| ANDASS
	| ORASS
	| XORASS
	| DIV
	| DIVASS
	;

// $>

// $<	Literals (7.8)

literal
	: NULL
	| booleanLiteral
	| numericLiteral
	| StringLiteral
	| RegularExpressionLiteral
	;

booleanLiteral
	: TRUE
	| FALSE
	;

// $<	Numeric literals (7.8.3)

/*
Note: octal literals are described in the B Compatibility section.
These are removed from the standards but are here for backwards compatibility with earlier ECMAScript definitions.
*/

fragment DecimalDigit
	: '0'..'9'
	;

fragment HexDigit
	: DecimalDigit | 'a'..'f' | 'A'..'F'
	;

fragment OctalDigit
	: '0'..'7'
	;

fragment ExponentPart
	: ( 'e' | 'E' ) ( '+' | '-' )? DecimalDigit+
	;

fragment DecimalIntegerLiteral
	: '0'
	| '1'..'9' DecimalDigit*
	;

DecimalLiteral
	: DecimalIntegerLiteral '.' DecimalDigit* ExponentPart?
	| '.' DecimalDigit+ ExponentPart?
	| DecimalIntegerLiteral ExponentPart?
	;

OctalIntegerLiteral
	: '0' OctalDigit+
	;

HexIntegerLiteral
	: ( '0x' | '0X' ) HexDigit+
	;

numericLiteral
	: DecimalLiteral
	| OctalIntegerLiteral
	| HexIntegerLiteral
	;

// $>

// $<	String literals (7.8.4)

/*
Note: octal escape sequences are described in the B Compatibility section.
These are removed from the standards but are here for backwards compatibility with earlier ECMAScript definitions.
*/
	
fragment CharacterEscapeSequence
	: ~( DecimalDigit | 'x' | 'u' | LineTerminator ) // Concatenation of SingleEscapeCharacter and NonEscapeCharacter
	;

fragment ZeroToThree
	: '0'..'3'
	;
	
fragment OctalEscapeSequence
	: OctalDigit
	| ZeroToThree OctalDigit
	| '4'..'7' OctalDigit
	| ZeroToThree OctalDigit OctalDigit
	;
	
fragment HexEscapeSequence
	: 'x' HexDigit HexDigit
	;
	
fragment UnicodeEscapeSequence
	: 'u' HexDigit HexDigit HexDigit HexDigit
	;

fragment EscapeSequence
	:
	BSLASH 
	(
		CharacterEscapeSequence 
		| OctalEscapeSequence
		| HexEscapeSequence
		| UnicodeEscapeSequence
	)
	;

StringLiteral
	: SQUOTE ( ~( SQUOTE | BSLASH | LineTerminator ) | EscapeSequence )* SQUOTE
	| DQUOTE ( ~( DQUOTE | BSLASH | LineTerminator ) | EscapeSequence )* DQUOTE
	;

// $>

// $<	Regular expression literals (7.8.5)

fragment BackslashSequence
	: BSLASH ~( LineTerminator )
	;

fragment RegularExpressionFirstChar
	: ~ ( LineTerminator | MUL | BSLASH | DIV )
	| BackslashSequence
	;

fragment RegularExpressionChar
	: ~ ( LineTerminator | BSLASH | DIV )
	| BackslashSequence
	;

RegularExpressionLiteral
	: { AreRegularExpressionsEnabled() }?=> DIV RegularExpressionFirstChar RegularExpressionChar* DIV IdentifierPart*
	;

// $>

// $>

// $>

//
// $<	A.3 Expressions (11)
//

// $<Primary expressions (11.1)

primaryExpression
	: THIS
	| Identifier
	| literal
	| arrayLiteral
	| objectLiteral
	| lpar=LPAREN expression RPAREN //-> ^( PAREXPR[$lpar, "PAREXPR"] expression )
	;

/*
 * Added ? for arrayItem. Original grammer didn't handle the case of [ foo, ]
 */
arrayLiteral
	: lb=LBRACK ( arrayItem ( COMMA arrayItem? )* )? RBRACK
	//-> ^( ARRAY[$lb, "ARRAY"] arrayItem* )
	;

arrayItem
	: ( expr=assignmentExpression | { input.LA(1) == COMMA }? )
	//-> ^( ITEM $expr? )
	;

objectLiteral
	: lb=LBRACE ( nameValuePair ( COMMA nameValuePair )* )? RBRACE
	//-> ^( OBJECT[$lb, "OBJECT"] nameValuePair* )
	;

/*
 * In order to get the name of a function expression in an object literal,
 * need to keep track of the property name for later usage.
 */	
nameValuePair
	: propertyName COLON assignmentExpression
	//-> ^( NAMEDVALUE propertyName assignmentExpression )
	;

propertyName
	: Identifier
	| StringLiteral
	| numericLiteral
	;

// $>

// $<Left-hand-side expressions (11.2)

/*
Refactored some rules to make them LL(*) compliant:
all the expressions surrounding member selection and calls have been moved to leftHandSideExpression to make them right recursive
*/

memberExpression
	: primaryExpression
	| functionExpression
	| newExpression
	;

newExpression
	: NEW primaryExpression
        | NEW functionExpression   //not per spec, but needed to support old coding patterns
	;

	
arguments
	: LPAREN ( assignmentExpression ( COMMA assignmentExpression )* )? RPAREN
	//-> ^( ARGS assignmentExpression* )
	;
	
leftHandSideExpression
	:
	(
		memberExpression 		//-> memberExpression
	)
	(
		arguments			//-> ^( CALL $leftHandSideExpression arguments )
		| LBRACK expression RBRACK	//-> ^( BYINDEX $leftHandSideExpression expression )
		| DOT Identifier		//-> ^( BYFIELD $leftHandSideExpression Identifier )
	)*
	;

// $>

// $<Postfix expressions (11.3)

/*
The specification states that there are no line terminators allowed before the postfix operators.
This is enforced by the call to promoteEOL in the action before ( INC | DEC ).
We only must promote EOLs when the la is INC or DEC because this production is chained as all expression rules.
In other words: only promote EOL when we are really in a postfix expression. A check on the la will ensure this.
*/
postfixExpression
	: leftHandSideExpression { if (input.LA(1) == INC || input.LA(1) == DEC) PromoteEOL(null); } ( postfixOperator )?
	;
	
postfixOperator
	: op=INC { $op.Type = PINC; }
	| op=DEC { $op.Type = PDEC; }
	;

// $>

// $<Unary operators (11.4)

unaryExpression
	: postfixExpression
	| unaryOperator unaryExpression
	;
	
unaryOperator
	: DELETE
	| VOID
	| TYPEOF
	| INC
	| DEC
	| op=ADD { $op.Type = POS; }
	| op=SUB { $op.Type = NEG; }
	| INV
	| NOT
	;

// $>

// $<Multiplicative operators (11.5)

multiplicativeExpression
	: unaryExpression ( ( MUL | DIV | MOD ) unaryExpression )*
	;

// $>

// $<Additive operators (11.6)

additiveExpression
	: multiplicativeExpression ( ( ADD | SUB ) multiplicativeExpression )*
	;

// $>
	
// $<Bitwise shift operators (11.7)

shiftExpression
	: additiveExpression ( ( SHL | SHR | SHU ) additiveExpression )*
	;

// $>
	
// $<Relational operators (11.8)

relationalExpression
	: shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF | IN ) shiftExpression )*
	;

relationalExpressionNoIn
	: shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF ) shiftExpression )*
	;

// $>
	
// $<Equality operators (11.9)

equalityExpression
	: relationalExpression ( ( EQ | NEQ | SAME | NSAME ) relationalExpression )*
	;

equalityExpressionNoIn
	: relationalExpressionNoIn ( ( EQ | NEQ | SAME | NSAME ) relationalExpressionNoIn )*
	;

// $>
		
// $<Binary bitwise operators (11.10)

bitwiseANDExpression
	: equalityExpression ( AND equalityExpression )*
	;

bitwiseANDExpressionNoIn
	: equalityExpressionNoIn ( AND equalityExpressionNoIn )*
	;
		
bitwiseXORExpression
	: bitwiseANDExpression ( XOR bitwiseANDExpression )*
	;
		
bitwiseXORExpressionNoIn
	: bitwiseANDExpressionNoIn ( XOR bitwiseANDExpressionNoIn )*
	;
	
bitwiseORExpression
	: bitwiseXORExpression ( OR bitwiseXORExpression )*
	;
	
bitwiseORExpressionNoIn
	: bitwiseXORExpressionNoIn ( OR bitwiseXORExpressionNoIn )*
	;

// $>
	
// $<Binary logical operators (11.11)

logicalANDExpression
	: bitwiseORExpression ( LAND bitwiseORExpression )*
	;

logicalANDExpressionNoIn
	: bitwiseORExpressionNoIn ( LAND bitwiseORExpressionNoIn )*
	;
	
logicalORExpression
	: logicalANDExpression ( LOR logicalANDExpression )*
	;
	
logicalORExpressionNoIn
	: logicalANDExpressionNoIn ( LOR logicalANDExpressionNoIn )*
	;

// $>
	
// $<Conditional operator (11.12)

conditionalExpression
	: logicalORExpression ( QUE assignmentExpression COLON assignmentExpression )?
	;

conditionalExpressionNoIn
	: logicalORExpressionNoIn ( QUE assignmentExpressionNoIn COLON assignmentExpressionNoIn )?
	;
	
// $>

// $<Assignment operators (11.13)

/*
The specification defines the AssignmentExpression rule as follows:
AssignmentExpression :
	ConditionalExpression 
	LeftHandSideExpression AssignmentOperator AssignmentExpression
This rule has a LL(*) conflict. Resolving this with a syntactical predicate will yield something like this:

assignmentExpression
	: ( leftHandSideExpression assignmentOperator )=> leftHandSideExpression assignmentOperator^ assignmentExpression
	| conditionalExpression
	;
assignmentOperator
	: ASSIGN | MULASS | DIVASS | MODASS | ADDASS | SUBASS | SHLASS | SHRASS | SHUASS | ANDASS | XORASS | ORASS
	;
	
But that didn't seem to work. Terence Par writes in his book that LL(*) conflicts in general can best be solved with auto backtracking. But that would be 
a performance killer for such a heavy used rule.
The solution I came up with is to always invoke the conditionalExpression first and than decide what to do based on the result of that rule.
When the rule results in a Tree that can't be coming from a left hand side expression, then we're done.
When it results in a Tree that is coming from a left hand side expression and the LA(1) is an assignment operator then parse the assignment operator
followed by the right recursive call.
*/
assignmentExpression
@init
{
	object[] isLhs = new object[1];
}
	: lhs=conditionalExpression
	( { IsLeftHandSideAssign(lhs, isLhs) }? assignmentOperator assignmentExpression )?	
	;

assignmentOperator
	: ASSIGN | MULASS | DIVASS | MODASS | ADDASS | SUBASS | SHLASS | SHRASS | SHUASS | ANDASS | XORASS | ORASS
	;

assignmentExpressionNoIn
@init
{
	object[] isLhs = new object[1];
}
	: lhs=conditionalExpressionNoIn
	( { IsLeftHandSideAssign(lhs, isLhs) }? assignmentOperator assignmentExpressionNoIn )?
	;
	
// $>
	
// $<Comma operator (11.14)

expression
	: exprs+=assignmentExpression ( COMMA exprs+=assignmentExpression )*
	//-> { $exprs.size() > 1 }? ^( CEXPR $exprs+ )
	//-> $exprs
	;

expressionNoIn
	: exprs+=assignmentExpressionNoIn ( COMMA exprs+=assignmentExpressionNoIn )*
	//-> { $exprs.size() > 1 }? ^( CEXPR $exprs+ )
	//-> $exprs
	;

// $>

// $>
	
//
// $<	A.4 Statements (12)
//

/*
This rule handles semicolons reported by the lexer and situations where the ECMA 3 specification states there should be semicolons automaticly inserted.
The auto semicolons are not actually inserted but this rule behaves as if they were.

In the following situations an ECMA 3 parser should auto insert absent but grammaticly required semicolons:
- the current token is a right brace
- the current token is the end of file (EOF) token
- there is at least one end of line (EOL) token between the current token and the previous token.

The RBRACE is handled by matching it but not consuming it.
The EOF needs no further handling because it is not consumed by default.
The EOL situation is handled by promoting the EOL or MultiLineComment with an EOL present from off channel to on channel
and thus making it parseable instead of handling it as white space. This promoting is done in the action promoteEOL.
*/
semic
@init
{
	// Mark current position so we can unconsume a RBRACE.
	int marker = input.Mark();
	// Promote EOL if appropriate	
	PromoteEOL(retval);
}
	: SEMIC
	| EOF
	| RBRACE { input.Rewind(marker); }
	| EOL | MultiLineComment // (with EOL in it)
	;

/*
To solve the ambiguity between block and objectLiteral via expressionStatement all but the block alternatives have been moved to statementTail.
Now when k = 1 and a semantical predicate is defined ANTLR generates code that always will prefer block when the LA(1) is a LBRACE.
This will result in the same behaviour that is described in the specification under 12.4 on the expressionStatement rule.
*/
statement
options
{
	k = 1 ;
}
scope {
   bool isBlock;
}
@init{
        bool instrument = false;
       
	if ($start.Line > $program::stopLine) {
	  $program::stopLine = $start.Line;
	  instrument = true;
	}	
}
@after {
        if (instrument && !$statement::isBlock) {
           $program::executableLines.Add($start.Line);
        }
	if (Verbose){
		Console.WriteLine("\n[INFO] Instrumenting statement on line {0}", $start.Line);
	}
}
	: ({ $statement::isBlock = input.LA(1) == LBRACE }? block | statementTail)
	  -> {instrument && !$statement::isBlock}? cover_line(src={$program::name}, code={$text},line={$start.Line})
	  -> ignore(code={$text})
	;
	
statementTail
	: variableStatement
	| emptyStatement
	| expressionStatement
	| ifStatement
	| iterationStatement
	| continueStatement
	| breakStatement
	| returnStatement
	| withStatement
	| labelledStatement
	| switchStatement
	| throwStatement
	| tryStatement
	;

// $<Block (12.1)

block
	: lb=LBRACE statement* RBRACE
	//-> ^( BLOCK[$lb, "BLOCK"] statement* )
	;

// $>
	
// $<Variable statement 12.2)

variableStatement
	: VAR variableDeclaration ( COMMA variableDeclaration )* semic
	//-> ^( VAR variableDeclaration+ )
	;

variableDeclaration
	: Identifier ( ASSIGN assignmentExpression )?
	;
	
variableDeclarationNoIn
	: Identifier ( ASSIGN assignmentExpressionNoIn )?
	;

// $>
	
// $<Empty statement (12.3)

emptyStatement
	: SEMIC
	;

// $>
	
// $<Expression statement (12.4)

/*
The look ahead check on LBRACE and FUNCTION the specification mentions has been left out and its function, resolving the ambiguity between:
- functionExpression and functionDeclarationstatement
- block and objectLiteral
are moved to the statement and sourceElement rules.
*/
expressionStatement
	: expression semic
	;

// $>
	
// $<The if statement (12.5)


ifStatement
// The predicate is there just to get rid of the warning. ANTLR will handle the dangling else just fine.
	: IF LPAREN expression RPAREN statement ( { input.LA(1) == ELSE }? elseStatement)?
	//push the block wrap to the statement?
	->  template(p = {input.ToString($start.TokenIndex, $statement.start.TokenIndex - 1)},
	             body = {WrapInBraces($statement.start, $statement.stop, input)},
	             elseClause = {
	             $elseStatement.stop != null ? input.ToString($statement.stop.TokenIndex+1, $elseStatement.stop.TokenIndex ) : null}) "<p><body><elseClause>"
	;

elseStatement
	: ELSE statement
	-> template(prefix = {input.ToString($start.TokenIndex, $statement.start.TokenIndex - 1)}, stmt = {WrapInBraces($statement.start, $statement.stop, input)}) "<prefix><stmt>"
	;

// $>
	
// $<Iteration statements (12.6)

iterationStatement
	: doStatement
	| whileStatement
	| forStatement
	;
	
doStatement
	: DO statement WHILE LPAREN expression RPAREN semic
	-> template(pre = {input.ToString($start.TokenIndex, $statement.start.TokenIndex - 1)},
	            stmt = {WrapInBraces($statement.start, $statement.stop, input)},
	            post = {input.ToString($WHILE, $RPAREN)},
	            end = {$semic.text}) "<pre><stmt><post><end>"
	;
	
whileStatement
	: WHILE LPAREN expression RPAREN statement
	-> template(pre = {input.ToString($start.TokenIndex, $statement.start.TokenIndex - 1)},
	            stmt = {WrapInBraces($statement.start, $statement.stop, input)}
	            ) "<pre><stmt>"
	;

/*
The forStatement production is refactored considerably as the specification contains a very none LL(*) compliant definition.
The initial version was like this:	

forStatement
	: FOR^ LPAREN! forControl RPAREN! statement
	;
forControl
options
{
	backtrack = true ;
	//k = 3 ;
}
	: stepClause
	| iterationClause
	;
stepClause
options
{
	memoize = true ;
}
	: ( ex1=expressionNoIn | var=VAR variableDeclarationNoIn ( COMMA variableDeclarationNoIn )* )? SEMIC ex2=expression? SEMIC ex3=expression?
	-> { $var != null }? ^( FORSTEP ^( VAR[$var] variableDeclarationNoIn+ ) ^( EXPR $ex2? ) ^( EXPR $ex3? ) )
	-> ^( FORSTEP ^( EXPR $ex1? ) ^( EXPR $ex2? ) ^( EXPR $ex3? ) )
	;
iterationClause
options
{
	memoize = true ;
}
	: ( leftHandSideExpression | var=VAR variableDeclarationNoIn ) IN expression
	-> { $var != null }? ^( FORITER ^( VAR[$var] variableDeclarationNoIn ) ^( EXPR expression ) )
	-> ^( FORITER ^( EXPR leftHandSideExpression ) ^( EXPR expression ) )
	;
	
But this completely relies on the backtrack feature and capabilities of ANTLR. 
Furthermore backtracking seemed to have 3 major drawbacks:
- the performance cost of backtracking is considerably
- didn't seem to work well with ANTLRWorks
- when introducing a k value to optimize the backtracking away, ANTLR runs out of heap space
*/
forStatement
	: FOR LPAREN forControl RPAREN statement
	-> template(pre = {input.ToString($start.TokenIndex, $statement.start.TokenIndex - 1)},
	            stmt = {WrapInBraces($statement.start, $statement.stop, input)}
	            ) "<pre><stmt>"
	;

forControl
	: forControlVar
	| forControlExpression
	| forControlSemic
	;

forControlVar
	: VAR variableDeclarationNoIn
	(
		(
			IN expression
			//-> ^( FORITER ^( VAR variableDeclarationNoIn ) ^( EXPR expression ) )
		)
		|
		(
			( COMMA variableDeclarationNoIn )* SEMIC ex1=expression? SEMIC ex2=expression?
			//-> ^( FORSTEP ^( VAR variableDeclarationNoIn+ ) ^( EXPR $ex1? ) ^( EXPR $ex2? ) )
		)
	)
	;

forControlExpression
@init
{
	Object[] isLhs = new Object[1];
}
	: ex1=expressionNoIn
	( 
		{ IsLeftHandSideIn(ex1, isLhs) }? (
			IN ex2=expression
			//-> ^( FORITER ^( EXPR $ex1 ) ^( EXPR $ex2 ) )
		)
		|
		(
			SEMIC ex2=expression? SEMIC ex3=expression?
			//-> ^( FORSTEP ^( EXPR $ex1 ) ^( EXPR $ex2? ) ^( EXPR $ex3? ) )
		)
	)
	;

forControlSemic
	: SEMIC ex1=expression? SEMIC ex2=expression?
	//-> ^( FORSTEP ^( EXPR ) ^( EXPR $ex1? ) ^( EXPR $ex2? ) )
	;

// $>
	
// $<The continue statement (12.7)

/*
The action with the call to promoteEOL after CONTINUE is to enforce the semicolon insertion rule of the specification that there are
no line terminators allowed beween CONTINUE and the optional identifier.
As an optimization we check the la first to decide whether there is an identier following.
*/
continueStatement
	: CONTINUE { if (input.LA(1) == Identifier) PromoteEOL(null); } Identifier? semic
	;

// $>
	
// $<The break statement (12.8)

/*
The action with the call to promoteEOL after BREAK is to enforce the semicolon insertion rule of the specification that there are
no line terminators allowed beween BREAK and the optional identifier.
As an optimization we check the la first to decide whether there is an identier following.
*/
breakStatement
	: BREAK { if (input.LA(1) == Identifier) PromoteEOL(null); } Identifier? semic
	;

// $>
	
// $<The return statement (12.9)

/*
The action calling promoteEOL after RETURN ensures that there are no line terminators between RETURN and the optional expression as the specification states.
When there are these get promoted to on channel and thus virtual semicolon wannabees.
So the folowing code:

return
1

will be parsed as:

return;
1;
*/
returnStatement
	: RETURN { PromoteEOL(null); } expression? semic
	;

// $>
	
// $<The with statement (12.10)

withStatement
	: WITH LPAREN expression RPAREN statement
	-> template(pre = {input.ToString($start.TokenIndex, $statement.start.TokenIndex - 1)},
	            stmt = {WrapInBraces($statement.start, $statement.stop, input)}
	            ) "<pre><stmt>"
	;

// $>
	
// $<The switch statement (12.11)

switchStatement
@init
{
	int defaultClauseCount = 0;
}
	: SWITCH LPAREN expression RPAREN LBRACE ( { defaultClauseCount == 0 }?=> defaultClause { defaultClauseCount++; } | caseClause )* RBRACE
	//-> ^( SWITCH expression defaultClause? caseClause* )
	;

caseClause
	: CASE expression COLON statement*
	;
	
defaultClause
	: DEFAULT COLON statement*
	;

// $>
	
// $<Labelled statements (12.12)

labelledStatement
	: Identifier COLON statement
	//-> ^( LABELLED Identifier statement )
	;

// $>
	
// $<The throw statement (12.13)

/*
The action calling promoteEOL after THROW ensures that there are no line terminators between THROW and the expression as the specification states.
When there are line terminators these get promoted to on channel and thus to virtual semicolon wannabees.
So the folowing code:

throw
new Error()

will be parsed as:

throw;
new Error();

which will yield a recognition exception!
*/
throwStatement
	: THROW { PromoteEOL(null); } expression semic
	;

// $>
	
// $<The try statement (12.14)

tryStatement
	: TRY block ( catchClause finallyClause? | finallyClause )
	;
	
catchClause
	: CATCH LPAREN Identifier RPAREN block
	;
	
finallyClause
	: FINALLY block
	;

// $>

// $>

//
// $<	A.5 Functions and Programs (13, 14)
//

// $<	Function Definition (13)


functionDeclaration
scope {
  string funcName;
  int funcLine;
}
@init{
	
        bool instrument = false;
	if ($start.Line > $program::stopLine) {
	  $program::executableLines.Add($start.Line);
	  $program::stopLine = $start.Line;
	  instrument = true;
	}
	$functionDeclaration::funcLine = $start.Line;		
}
@after { 
	$program::functions.Add("\"" + $functionDeclaration::funcName + ":" + $start.Line + "\"");
  	if (Verbose){
    		Console.WriteLine("\n[INFO] Instrumenting function " + $functionDeclaration::funcName + " on line " +  $start.Line);
  	}
}

	: FUNCTION name=Identifier {$functionDeclaration::funcName=$Identifier.text;} formalParameterList functionDeclarationBody
	  -> {instrument}? cover_line(src={$program::name}, code={$text}, line={$start.Line})
	  -> ignore(code={$text})
	;

functionExpression
scope{
    string funcName;
    int funcLine;
}
@init {
    $functionExpression::funcLine=$start.Line;

    /*
     * The function expression might have an identifier, and if so, use that as
     * the name.
     *
     * This might be a function that's a method in an object literal. If so,
     * the previous token will be a colon and the one prior to that will be the
     * identifier.
     *
     * Function may also be assigned to a variable. In that case, the previous
     * token will be the equals sign (=) and the token prior to that is the
     * variable/property.
     *
     * Even after all that, the function expression might have a declared name
     * as if it were a function declaration. If so, the declared function name
     * takes precendence over any object literal or variable assignment.
     */
    int lastTT = input.LA(-1);   //look for = or :
    int nextTT = input.LA(2);    //look for an identifer

    if (nextTT == Identifier){
        $functionExpression::funcName = input.LT(2).Text;
    } else if (lastTT == COLON || lastTT == ASSIGN) {
        $functionExpression::funcName = input.LT(-2).Text.Replace("\"", "\\\"").Replace("'", "\\'");

        //TODO: Continue walking back in case the identifier is object.name
        //right now, I end up just with name.
    } else {
        $functionExpression::funcName = "(anonymous " +  (++$program::anonymousFunctionCount) + ")";
    }

}
	: FUNCTION Identifier? formalParameterList functionExpressionBody
	;

formalParameterList
	: LPAREN ( Identifier ( COMMA Identifier )* )? RPAREN
	;

functionDeclarationBody
	: lb=LBRACE functionDeclarationBodyWithoutBraces? RBRACE
	;

functionExpressionBody
	: lb=LBRACE functionExpressionBodyWithoutBraces? RBRACE
	;

//Jumping through hoops to get the function body without braces. There's gotta be an easier way.
functionExpressionBodyWithoutBraces
@after { 
	//favor the function expression's declared name, otherwise assign an anonymous function name
	$program::functions.Add("\"" + $functionExpression::funcName + ":" + $functionExpression::funcLine + "\"");
	
	if (Verbose)
  {
			Console.WriteLine("\n[INFO] Instrumenting function expression '" + $functionExpression::funcName + "' on line " + $functionExpression::funcLine);
	}		
}
	: sourceElement sourceElement*
	{
	
	}
	-> {$functionExpression::funcName!=null}? cover_func(src={$program::name}, code={$text}, name={$functionExpression::funcName}, line={$functionExpression::funcLine})
	-> cover_func(src={$program::name}, code={$text}, name={$functionDeclaration::funcName}, line={$functionDeclaration::funcLine})
	;

functionDeclarationBodyWithoutBraces
	: sourceElement sourceElement*
	-> cover_func(src={$program::name}, code={$text}, name={$functionDeclaration::funcName}, line={$functionDeclaration::funcLine})
	;

// $>
	
// $<	Program (14)

program
scope {
  List<int> executableLines;
  List<string> functions;  
  int stopLine;
  string name;
  int anonymousFunctionCount;
}
@init {
  $program::executableLines = new List<int>();
  $program::functions = new List<string>();
  $program::stopLine = 0;
  $program::name = SourceName;
  $program::anonymousFunctionCount = 0;
}
	: (sourceElement*) { $program::executableLines.Sort();}
	-> cover_file(src={$program::name}, code = {$text}, lines = {ToObjectLiteral($program::executableLines, true)}, funcs={ToObjectLiteral($program::functions, false)}, lineCount={$program::executableLines.Count}, funcCount={$program::functions.Count})
	;

/*
By setting k  to 1 for this rule and adding the semantical predicate ANTRL will generate code that will always prefer functionDeclararion over functionExpression
here and therefor remove the ambiguity between these to production.
This will result in the same behaviour that is described in the specification under 12.4 on the expressionStatement rule.
*/
sourceElement
options
{
	k = 1 ;
}
	: { input.LA(1) == FUNCTION }? functionDeclaration
	| statement
	;

