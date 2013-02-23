lexer grammar ES3YUITest;
options {
  language=CSharp3;

}

@members {
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

public override IToken NextToken()
{
	var result = base.NextToken();
	if (result.Channel == TokenChannels.Default)
	{
		last = result;
	}
	return result;		
}
}
@header {
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

ABSTRACT : 'abstract' ;
ADD : '+' ;
ADDASS : '+=' ;
AND : '&' ;
ANDASS : '&=' ;
ASSIGN : '=' ;
BOOLEAN : 'boolean' ;
BREAK : 'break' ;
BYTE : 'byte' ;
CASE : 'case' ;
CATCH : 'catch' ;
CHAR : 'char' ;
CLASS : 'class' ;
COLON : ':' ;
COMMA : ',' ;
CONST : 'const' ;
CONTINUE : 'continue' ;
DEBUGGER : 'debugger' ;
DEC : '--' ;
DEFAULT : 'default' ;
DELETE : 'delete' ;
DIV : '/' ;
DIVASS : '/=' ;
DO : 'do' ;
DOT : '.' ;
DOUBLE : 'double' ;
ELSE : 'else' ;
ENUM : 'enum' ;
EQ : '==' ;
EXPORT : 'export' ;
EXTENDS : 'extends' ;
FALSE : 'false' ;
FINAL : 'final' ;
FINALLY : 'finally' ;
FLOAT : 'float' ;
FOR : 'for' ;
FUNCTION : 'function' ;
GOTO : 'goto' ;
GT : '>' ;
GTE : '>=' ;
IF : 'if' ;
IMPLEMENTS : 'implements' ;
IMPORT : 'import' ;
IN : 'in' ;
INC : '++' ;
INSTANCEOF : 'instanceof' ;
INT : 'int' ;
INTERFACE : 'interface' ;
INV : '~' ;
LAND : '&&' ;
LBRACE : '{' ;
LBRACK : '[' ;
LONG : 'long' ;
LOR : '||' ;
LPAREN : '(' ;
LT : '<' ;
LTE : '<=' ;
MOD : '%' ;
MODASS : '%=' ;
MUL : '*' ;
MULASS : '*=' ;
NATIVE : 'native' ;
NEQ : '!=' ;
NEW : 'new' ;
NOT : '!' ;
NSAME : '!==' ;
NULL : 'null' ;
OR : '|' ;
ORASS : '|=' ;
PACKAGE : 'package' ;
PRIVATE : 'private' ;
PROTECTED : 'protected' ;
PUBLIC : 'public' ;
QUE : '?' ;
RBRACE : '}' ;
RBRACK : ']' ;
RETURN : 'return' ;
RPAREN : ')' ;
SAME : '===' ;
SEMIC : ';' ;
SHL : '<<' ;
SHLASS : '<<=' ;
SHORT : 'short' ;
SHR : '>>' ;
SHRASS : '>>=' ;
SHU : '>>>' ;
SHUASS : '>>>=' ;
STATIC : 'static' ;
SUB : '-' ;
SUBASS : '-=' ;
SUPER : 'super' ;
SWITCH : 'switch' ;
SYNCHRONIZED : 'synchronized' ;
THIS : 'this' ;
THROW : 'throw' ;
THROWS : 'throws' ;
TRANSIENT : 'transient' ;
TRUE : 'true' ;
TRY : 'try' ;
TYPEOF : 'typeof' ;
VAR : 'var' ;
VOID : 'void' ;
VOLATILE : 'volatile' ;
WHILE : 'while' ;
WITH : 'with' ;
XOR : '^' ;
XORASS : '^=' ;

// $ANTLR src "ES3YUITest.g" 502
fragment BSLASH
	: '\\'
	;// $ANTLR src "ES3YUITest.g" 506
fragment DQUOTE
	: '"'
	;// $ANTLR src "ES3YUITest.g" 510
fragment SQUOTE
	: '\''
	;// $ANTLR src "ES3YUITest.g" 516
fragment TAB
	: '\u0009'
	;// $ANTLR src "ES3YUITest.g" 520
fragment VT // Vertical TAB
	: '\u000b'
	;// $ANTLR src "ES3YUITest.g" 524
fragment FF // Form Feed
	: '\u000c'
	;// $ANTLR src "ES3YUITest.g" 528
fragment SP // Space
	: '\u0020'
	;// $ANTLR src "ES3YUITest.g" 532
fragment NBSP // Non-Breaking Space
	: '\u00a0'
	;// $ANTLR src "ES3YUITest.g" 536
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
	;// $ANTLR src "ES3YUITest.g" 555
WhiteSpace
	: ( TAB | VT | FF | SP | NBSP | USP )+ { $channel = TokenChannels.Hidden; }
	;// $ANTLR src "ES3YUITest.g" 563
fragment LF // Line Feed
	: '\n'
	;// $ANTLR src "ES3YUITest.g" 567
fragment CR // Carriage Return
	: '\r'
	;// $ANTLR src "ES3YUITest.g" 571
fragment LS // Line Separator
	: '\u2028'
	;// $ANTLR src "ES3YUITest.g" 575
fragment PS // Paragraph Separator
	: '\u2029'
	;// $ANTLR src "ES3YUITest.g" 579
fragment LineTerminator
	: CR | LF | LS | PS
	;// $ANTLR src "ES3YUITest.g" 583
EOL
	: ( ( CR LF? ) | LF | LS | PS ) { $channel = TokenChannels.Hidden; }
	;// $ANTLR src "ES3YUITest.g" 590
MultiLineComment
	: '/*' ( options { greedy = false; } : . )* '*/' { $channel = TokenChannels.Hidden; }
	;// $ANTLR src "ES3YUITest.g" 594
SingleLineComment
	: '//' ( ~( LineTerminator ) )* { $channel = TokenChannels.Hidden; }
	;// $ANTLR src "ES3YUITest.g" 695
fragment IdentifierStartASCII
	: 'a'..'z' | 'A'..'Z'
	| '$'
	| '_'
	| BSLASH 'u' HexDigit HexDigit HexDigit HexDigit // UnicodeEscapeSequence
	;// $ANTLR src "ES3YUITest.g" 706
fragment IdentifierPart
	: DecimalDigit
	| IdentifierStartASCII
	| { IsIdentifierPartUnicode(input.LA(1)) }? { MatchAny(); }
	;// $ANTLR src "ES3YUITest.g" 712
fragment IdentifierNameASCIIStart
	: IdentifierStartASCII IdentifierPart*
	;// $ANTLR src "ES3YUITest.g" 724
Identifier
	: IdentifierNameASCIIStart
	| { ConsumeIdentifierUnicodeStart(); }
	;// $ANTLR src "ES3YUITest.g" 808
fragment DecimalDigit
	: '0'..'9'
	;// $ANTLR src "ES3YUITest.g" 812
fragment HexDigit
	: DecimalDigit | 'a'..'f' | 'A'..'F'
	;// $ANTLR src "ES3YUITest.g" 816
fragment OctalDigit
	: '0'..'7'
	;// $ANTLR src "ES3YUITest.g" 820
fragment ExponentPart
	: ( 'e' | 'E' ) ( '+' | '-' )? DecimalDigit+
	;// $ANTLR src "ES3YUITest.g" 824
fragment DecimalIntegerLiteral
	: '0'
	| '1'..'9' DecimalDigit*
	;// $ANTLR src "ES3YUITest.g" 829
DecimalLiteral
	: DecimalIntegerLiteral '.' DecimalDigit* ExponentPart?
	| '.' DecimalDigit+ ExponentPart?
	| DecimalIntegerLiteral ExponentPart?
	;// $ANTLR src "ES3YUITest.g" 835
OctalIntegerLiteral
	: '0' OctalDigit+
	;// $ANTLR src "ES3YUITest.g" 839
HexIntegerLiteral
	: ( '0x' | '0X' ) HexDigit+
	;// $ANTLR src "ES3YUITest.g" 858
fragment CharacterEscapeSequence
	: ~( DecimalDigit | 'x' | 'u' | LineTerminator ) // Concatenation of SingleEscapeCharacter and NonEscapeCharacter
	;// $ANTLR src "ES3YUITest.g" 862
fragment ZeroToThree
	: '0'..'3'
	;// $ANTLR src "ES3YUITest.g" 866
fragment OctalEscapeSequence
	: OctalDigit
	| ZeroToThree OctalDigit
	| '4'..'7' OctalDigit
	| ZeroToThree OctalDigit OctalDigit
	;// $ANTLR src "ES3YUITest.g" 873
fragment HexEscapeSequence
	: 'x' HexDigit HexDigit
	;// $ANTLR src "ES3YUITest.g" 877
fragment UnicodeEscapeSequence
	: 'u' HexDigit HexDigit HexDigit HexDigit
	;// $ANTLR src "ES3YUITest.g" 881
fragment EscapeSequence
	:
	BSLASH 
	(
		CharacterEscapeSequence 
		| OctalEscapeSequence
		| HexEscapeSequence
		| UnicodeEscapeSequence
	)
	;// $ANTLR src "ES3YUITest.g" 892
StringLiteral
	: SQUOTE ( ~( SQUOTE | BSLASH | LineTerminator ) | EscapeSequence )* SQUOTE
	| DQUOTE ( ~( DQUOTE | BSLASH | LineTerminator ) | EscapeSequence )* DQUOTE
	;// $ANTLR src "ES3YUITest.g" 901
fragment BackslashSequence
	: BSLASH ~( LineTerminator )
	;// $ANTLR src "ES3YUITest.g" 905
fragment RegularExpressionFirstChar
	: ~ ( LineTerminator | MUL | BSLASH | DIV )
	| BackslashSequence
	;// $ANTLR src "ES3YUITest.g" 910
fragment RegularExpressionChar
	: ~ ( LineTerminator | BSLASH | DIV )
	| BackslashSequence
	;// $ANTLR src "ES3YUITest.g" 915
RegularExpressionLiteral
	: { AreRegularExpressionsEnabled() }?=> DIV RegularExpressionFirstChar RegularExpressionChar* DIV IdentifierPart*
	;