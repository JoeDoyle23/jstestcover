// $ANTLR 3.3 Nov 30, 2010 12:50:56 ES3YUITest.g 2013-02-21 21:33:32

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


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


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:50:56")]
[System.CLSCompliant(false)]
public partial class ES3YUITestLexer : Antlr.Runtime.Lexer
{
	public const int EOF=-1;
	public const int NULL=4;
	public const int TRUE=5;
	public const int FALSE=6;
	public const int BREAK=7;
	public const int CASE=8;
	public const int CATCH=9;
	public const int CONTINUE=10;
	public const int DEFAULT=11;
	public const int DELETE=12;
	public const int DO=13;
	public const int ELSE=14;
	public const int FINALLY=15;
	public const int FOR=16;
	public const int FUNCTION=17;
	public const int IF=18;
	public const int IN=19;
	public const int INSTANCEOF=20;
	public const int NEW=21;
	public const int RETURN=22;
	public const int SWITCH=23;
	public const int THIS=24;
	public const int THROW=25;
	public const int TRY=26;
	public const int TYPEOF=27;
	public const int VAR=28;
	public const int VOID=29;
	public const int WHILE=30;
	public const int WITH=31;
	public const int ABSTRACT=32;
	public const int BOOLEAN=33;
	public const int BYTE=34;
	public const int CHAR=35;
	public const int CLASS=36;
	public const int CONST=37;
	public const int DEBUGGER=38;
	public const int DOUBLE=39;
	public const int ENUM=40;
	public const int EXPORT=41;
	public const int EXTENDS=42;
	public const int FINAL=43;
	public const int FLOAT=44;
	public const int GOTO=45;
	public const int IMPLEMENTS=46;
	public const int IMPORT=47;
	public const int INT=48;
	public const int INTERFACE=49;
	public const int LONG=50;
	public const int NATIVE=51;
	public const int PACKAGE=52;
	public const int PRIVATE=53;
	public const int PROTECTED=54;
	public const int PUBLIC=55;
	public const int SHORT=56;
	public const int STATIC=57;
	public const int SUPER=58;
	public const int SYNCHRONIZED=59;
	public const int THROWS=60;
	public const int TRANSIENT=61;
	public const int VOLATILE=62;
	public const int LBRACE=63;
	public const int RBRACE=64;
	public const int LPAREN=65;
	public const int RPAREN=66;
	public const int LBRACK=67;
	public const int RBRACK=68;
	public const int DOT=69;
	public const int SEMIC=70;
	public const int COMMA=71;
	public const int LT=72;
	public const int GT=73;
	public const int LTE=74;
	public const int GTE=75;
	public const int EQ=76;
	public const int NEQ=77;
	public const int SAME=78;
	public const int NSAME=79;
	public const int ADD=80;
	public const int SUB=81;
	public const int MUL=82;
	public const int MOD=83;
	public const int INC=84;
	public const int DEC=85;
	public const int SHL=86;
	public const int SHR=87;
	public const int SHU=88;
	public const int AND=89;
	public const int OR=90;
	public const int XOR=91;
	public const int NOT=92;
	public const int INV=93;
	public const int LAND=94;
	public const int LOR=95;
	public const int QUE=96;
	public const int COLON=97;
	public const int ASSIGN=98;
	public const int ADDASS=99;
	public const int SUBASS=100;
	public const int MULASS=101;
	public const int MODASS=102;
	public const int SHLASS=103;
	public const int SHRASS=104;
	public const int SHUASS=105;
	public const int ANDASS=106;
	public const int ORASS=107;
	public const int XORASS=108;
	public const int DIV=109;
	public const int DIVASS=110;
	public const int ARGS=111;
	public const int ARRAY=112;
	public const int BLOCK=113;
	public const int BYFIELD=114;
	public const int BYINDEX=115;
	public const int CALL=116;
	public const int CEXPR=117;
	public const int EXPR=118;
	public const int FORITER=119;
	public const int FORSTEP=120;
	public const int ITEM=121;
	public const int LABELLED=122;
	public const int NAMEDVALUE=123;
	public const int NEG=124;
	public const int OBJECT=125;
	public const int PAREXPR=126;
	public const int PDEC=127;
	public const int PINC=128;
	public const int POS=129;
	public const int BSLASH=130;
	public const int DQUOTE=131;
	public const int SQUOTE=132;
	public const int TAB=133;
	public const int VT=134;
	public const int FF=135;
	public const int SP=136;
	public const int NBSP=137;
	public const int USP=138;
	public const int WhiteSpace=139;
	public const int LF=140;
	public const int CR=141;
	public const int LS=142;
	public const int PS=143;
	public const int LineTerminator=144;
	public const int EOL=145;
	public const int MultiLineComment=146;
	public const int SingleLineComment=147;
	public const int Identifier=148;
	public const int StringLiteral=149;
	public const int HexDigit=150;
	public const int IdentifierStartASCII=151;
	public const int DecimalDigit=152;
	public const int IdentifierPart=153;
	public const int IdentifierNameASCIIStart=154;
	public const int RegularExpressionLiteral=155;
	public const int OctalDigit=156;
	public const int ExponentPart=157;
	public const int DecimalIntegerLiteral=158;
	public const int DecimalLiteral=159;
	public const int OctalIntegerLiteral=160;
	public const int HexIntegerLiteral=161;
	public const int CharacterEscapeSequence=162;
	public const int ZeroToThree=163;
	public const int OctalEscapeSequence=164;
	public const int HexEscapeSequence=165;
	public const int UnicodeEscapeSequence=166;
	public const int EscapeSequence=167;
	public const int BackslashSequence=168;
	public const int RegularExpressionFirstChar=169;
	public const int RegularExpressionChar=170;

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


    // delegates
    // delegators

	public ES3YUITestLexer()
	{
		OnCreated();
	}

	public ES3YUITestLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public ES3YUITestLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{


		OnCreated();
	}
	public override string GrammarFileName { get { return "ES3YUITest.g"; } }

	private static readonly bool[] decisionCanBacktrack = new bool[0];


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void Enter_NULL();
	partial void Leave_NULL();

	// $ANTLR start "NULL"
	[GrammarRule("NULL")]
	private void mNULL()
	{
		Enter_NULL();
		EnterRule("NULL", 1);
		TraceIn("NULL", 1);
		try
		{
			int _type = NULL;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:109:6: ( 'null' )
			DebugEnterAlt(1);
			// ES3YUITest.g:109:8: 'null'
			{
			DebugLocation(109, 8);
			Match("null"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NULL", 1);
			LeaveRule("NULL", 1);
			Leave_NULL();
		}
	}
	// $ANTLR end "NULL"

	partial void Enter_TRUE();
	partial void Leave_TRUE();

	// $ANTLR start "TRUE"
	[GrammarRule("TRUE")]
	private void mTRUE()
	{
		Enter_TRUE();
		EnterRule("TRUE", 2);
		TraceIn("TRUE", 2);
		try
		{
			int _type = TRUE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:110:6: ( 'true' )
			DebugEnterAlt(1);
			// ES3YUITest.g:110:8: 'true'
			{
			DebugLocation(110, 8);
			Match("true"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("TRUE", 2);
			LeaveRule("TRUE", 2);
			Leave_TRUE();
		}
	}
	// $ANTLR end "TRUE"

	partial void Enter_FALSE();
	partial void Leave_FALSE();

	// $ANTLR start "FALSE"
	[GrammarRule("FALSE")]
	private void mFALSE()
	{
		Enter_FALSE();
		EnterRule("FALSE", 3);
		TraceIn("FALSE", 3);
		try
		{
			int _type = FALSE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:111:7: ( 'false' )
			DebugEnterAlt(1);
			// ES3YUITest.g:111:9: 'false'
			{
			DebugLocation(111, 9);
			Match("false"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FALSE", 3);
			LeaveRule("FALSE", 3);
			Leave_FALSE();
		}
	}
	// $ANTLR end "FALSE"

	partial void Enter_BREAK();
	partial void Leave_BREAK();

	// $ANTLR start "BREAK"
	[GrammarRule("BREAK")]
	private void mBREAK()
	{
		Enter_BREAK();
		EnterRule("BREAK", 4);
		TraceIn("BREAK", 4);
		try
		{
			int _type = BREAK;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:112:7: ( 'break' )
			DebugEnterAlt(1);
			// ES3YUITest.g:112:9: 'break'
			{
			DebugLocation(112, 9);
			Match("break"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("BREAK", 4);
			LeaveRule("BREAK", 4);
			Leave_BREAK();
		}
	}
	// $ANTLR end "BREAK"

	partial void Enter_CASE();
	partial void Leave_CASE();

	// $ANTLR start "CASE"
	[GrammarRule("CASE")]
	private void mCASE()
	{
		Enter_CASE();
		EnterRule("CASE", 5);
		TraceIn("CASE", 5);
		try
		{
			int _type = CASE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:113:6: ( 'case' )
			DebugEnterAlt(1);
			// ES3YUITest.g:113:8: 'case'
			{
			DebugLocation(113, 8);
			Match("case"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CASE", 5);
			LeaveRule("CASE", 5);
			Leave_CASE();
		}
	}
	// $ANTLR end "CASE"

	partial void Enter_CATCH();
	partial void Leave_CATCH();

	// $ANTLR start "CATCH"
	[GrammarRule("CATCH")]
	private void mCATCH()
	{
		Enter_CATCH();
		EnterRule("CATCH", 6);
		TraceIn("CATCH", 6);
		try
		{
			int _type = CATCH;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:114:7: ( 'catch' )
			DebugEnterAlt(1);
			// ES3YUITest.g:114:9: 'catch'
			{
			DebugLocation(114, 9);
			Match("catch"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CATCH", 6);
			LeaveRule("CATCH", 6);
			Leave_CATCH();
		}
	}
	// $ANTLR end "CATCH"

	partial void Enter_CONTINUE();
	partial void Leave_CONTINUE();

	// $ANTLR start "CONTINUE"
	[GrammarRule("CONTINUE")]
	private void mCONTINUE()
	{
		Enter_CONTINUE();
		EnterRule("CONTINUE", 7);
		TraceIn("CONTINUE", 7);
		try
		{
			int _type = CONTINUE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:115:10: ( 'continue' )
			DebugEnterAlt(1);
			// ES3YUITest.g:115:12: 'continue'
			{
			DebugLocation(115, 12);
			Match("continue"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CONTINUE", 7);
			LeaveRule("CONTINUE", 7);
			Leave_CONTINUE();
		}
	}
	// $ANTLR end "CONTINUE"

	partial void Enter_DEFAULT();
	partial void Leave_DEFAULT();

	// $ANTLR start "DEFAULT"
	[GrammarRule("DEFAULT")]
	private void mDEFAULT()
	{
		Enter_DEFAULT();
		EnterRule("DEFAULT", 8);
		TraceIn("DEFAULT", 8);
		try
		{
			int _type = DEFAULT;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:116:9: ( 'default' )
			DebugEnterAlt(1);
			// ES3YUITest.g:116:11: 'default'
			{
			DebugLocation(116, 11);
			Match("default"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DEFAULT", 8);
			LeaveRule("DEFAULT", 8);
			Leave_DEFAULT();
		}
	}
	// $ANTLR end "DEFAULT"

	partial void Enter_DELETE();
	partial void Leave_DELETE();

	// $ANTLR start "DELETE"
	[GrammarRule("DELETE")]
	private void mDELETE()
	{
		Enter_DELETE();
		EnterRule("DELETE", 9);
		TraceIn("DELETE", 9);
		try
		{
			int _type = DELETE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:117:8: ( 'delete' )
			DebugEnterAlt(1);
			// ES3YUITest.g:117:10: 'delete'
			{
			DebugLocation(117, 10);
			Match("delete"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DELETE", 9);
			LeaveRule("DELETE", 9);
			Leave_DELETE();
		}
	}
	// $ANTLR end "DELETE"

	partial void Enter_DO();
	partial void Leave_DO();

	// $ANTLR start "DO"
	[GrammarRule("DO")]
	private void mDO()
	{
		Enter_DO();
		EnterRule("DO", 10);
		TraceIn("DO", 10);
		try
		{
			int _type = DO;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:118:4: ( 'do' )
			DebugEnterAlt(1);
			// ES3YUITest.g:118:6: 'do'
			{
			DebugLocation(118, 6);
			Match("do"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DO", 10);
			LeaveRule("DO", 10);
			Leave_DO();
		}
	}
	// $ANTLR end "DO"

	partial void Enter_ELSE();
	partial void Leave_ELSE();

	// $ANTLR start "ELSE"
	[GrammarRule("ELSE")]
	private void mELSE()
	{
		Enter_ELSE();
		EnterRule("ELSE", 11);
		TraceIn("ELSE", 11);
		try
		{
			int _type = ELSE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:119:6: ( 'else' )
			DebugEnterAlt(1);
			// ES3YUITest.g:119:8: 'else'
			{
			DebugLocation(119, 8);
			Match("else"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ELSE", 11);
			LeaveRule("ELSE", 11);
			Leave_ELSE();
		}
	}
	// $ANTLR end "ELSE"

	partial void Enter_FINALLY();
	partial void Leave_FINALLY();

	// $ANTLR start "FINALLY"
	[GrammarRule("FINALLY")]
	private void mFINALLY()
	{
		Enter_FINALLY();
		EnterRule("FINALLY", 12);
		TraceIn("FINALLY", 12);
		try
		{
			int _type = FINALLY;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:120:9: ( 'finally' )
			DebugEnterAlt(1);
			// ES3YUITest.g:120:11: 'finally'
			{
			DebugLocation(120, 11);
			Match("finally"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FINALLY", 12);
			LeaveRule("FINALLY", 12);
			Leave_FINALLY();
		}
	}
	// $ANTLR end "FINALLY"

	partial void Enter_FOR();
	partial void Leave_FOR();

	// $ANTLR start "FOR"
	[GrammarRule("FOR")]
	private void mFOR()
	{
		Enter_FOR();
		EnterRule("FOR", 13);
		TraceIn("FOR", 13);
		try
		{
			int _type = FOR;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:121:5: ( 'for' )
			DebugEnterAlt(1);
			// ES3YUITest.g:121:7: 'for'
			{
			DebugLocation(121, 7);
			Match("for"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FOR", 13);
			LeaveRule("FOR", 13);
			Leave_FOR();
		}
	}
	// $ANTLR end "FOR"

	partial void Enter_FUNCTION();
	partial void Leave_FUNCTION();

	// $ANTLR start "FUNCTION"
	[GrammarRule("FUNCTION")]
	private void mFUNCTION()
	{
		Enter_FUNCTION();
		EnterRule("FUNCTION", 14);
		TraceIn("FUNCTION", 14);
		try
		{
			int _type = FUNCTION;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:122:10: ( 'function' )
			DebugEnterAlt(1);
			// ES3YUITest.g:122:12: 'function'
			{
			DebugLocation(122, 12);
			Match("function"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FUNCTION", 14);
			LeaveRule("FUNCTION", 14);
			Leave_FUNCTION();
		}
	}
	// $ANTLR end "FUNCTION"

	partial void Enter_IF();
	partial void Leave_IF();

	// $ANTLR start "IF"
	[GrammarRule("IF")]
	private void mIF()
	{
		Enter_IF();
		EnterRule("IF", 15);
		TraceIn("IF", 15);
		try
		{
			int _type = IF;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:123:4: ( 'if' )
			DebugEnterAlt(1);
			// ES3YUITest.g:123:6: 'if'
			{
			DebugLocation(123, 6);
			Match("if"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IF", 15);
			LeaveRule("IF", 15);
			Leave_IF();
		}
	}
	// $ANTLR end "IF"

	partial void Enter_IN();
	partial void Leave_IN();

	// $ANTLR start "IN"
	[GrammarRule("IN")]
	private void mIN()
	{
		Enter_IN();
		EnterRule("IN", 16);
		TraceIn("IN", 16);
		try
		{
			int _type = IN;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:124:4: ( 'in' )
			DebugEnterAlt(1);
			// ES3YUITest.g:124:6: 'in'
			{
			DebugLocation(124, 6);
			Match("in"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IN", 16);
			LeaveRule("IN", 16);
			Leave_IN();
		}
	}
	// $ANTLR end "IN"

	partial void Enter_INSTANCEOF();
	partial void Leave_INSTANCEOF();

	// $ANTLR start "INSTANCEOF"
	[GrammarRule("INSTANCEOF")]
	private void mINSTANCEOF()
	{
		Enter_INSTANCEOF();
		EnterRule("INSTANCEOF", 17);
		TraceIn("INSTANCEOF", 17);
		try
		{
			int _type = INSTANCEOF;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:125:12: ( 'instanceof' )
			DebugEnterAlt(1);
			// ES3YUITest.g:125:14: 'instanceof'
			{
			DebugLocation(125, 14);
			Match("instanceof"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("INSTANCEOF", 17);
			LeaveRule("INSTANCEOF", 17);
			Leave_INSTANCEOF();
		}
	}
	// $ANTLR end "INSTANCEOF"

	partial void Enter_NEW();
	partial void Leave_NEW();

	// $ANTLR start "NEW"
	[GrammarRule("NEW")]
	private void mNEW()
	{
		Enter_NEW();
		EnterRule("NEW", 18);
		TraceIn("NEW", 18);
		try
		{
			int _type = NEW;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:126:5: ( 'new' )
			DebugEnterAlt(1);
			// ES3YUITest.g:126:7: 'new'
			{
			DebugLocation(126, 7);
			Match("new"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NEW", 18);
			LeaveRule("NEW", 18);
			Leave_NEW();
		}
	}
	// $ANTLR end "NEW"

	partial void Enter_RETURN();
	partial void Leave_RETURN();

	// $ANTLR start "RETURN"
	[GrammarRule("RETURN")]
	private void mRETURN()
	{
		Enter_RETURN();
		EnterRule("RETURN", 19);
		TraceIn("RETURN", 19);
		try
		{
			int _type = RETURN;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:127:8: ( 'return' )
			DebugEnterAlt(1);
			// ES3YUITest.g:127:10: 'return'
			{
			DebugLocation(127, 10);
			Match("return"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RETURN", 19);
			LeaveRule("RETURN", 19);
			Leave_RETURN();
		}
	}
	// $ANTLR end "RETURN"

	partial void Enter_SWITCH();
	partial void Leave_SWITCH();

	// $ANTLR start "SWITCH"
	[GrammarRule("SWITCH")]
	private void mSWITCH()
	{
		Enter_SWITCH();
		EnterRule("SWITCH", 20);
		TraceIn("SWITCH", 20);
		try
		{
			int _type = SWITCH;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:128:8: ( 'switch' )
			DebugEnterAlt(1);
			// ES3YUITest.g:128:10: 'switch'
			{
			DebugLocation(128, 10);
			Match("switch"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SWITCH", 20);
			LeaveRule("SWITCH", 20);
			Leave_SWITCH();
		}
	}
	// $ANTLR end "SWITCH"

	partial void Enter_THIS();
	partial void Leave_THIS();

	// $ANTLR start "THIS"
	[GrammarRule("THIS")]
	private void mTHIS()
	{
		Enter_THIS();
		EnterRule("THIS", 21);
		TraceIn("THIS", 21);
		try
		{
			int _type = THIS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:129:6: ( 'this' )
			DebugEnterAlt(1);
			// ES3YUITest.g:129:8: 'this'
			{
			DebugLocation(129, 8);
			Match("this"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("THIS", 21);
			LeaveRule("THIS", 21);
			Leave_THIS();
		}
	}
	// $ANTLR end "THIS"

	partial void Enter_THROW();
	partial void Leave_THROW();

	// $ANTLR start "THROW"
	[GrammarRule("THROW")]
	private void mTHROW()
	{
		Enter_THROW();
		EnterRule("THROW", 22);
		TraceIn("THROW", 22);
		try
		{
			int _type = THROW;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:130:7: ( 'throw' )
			DebugEnterAlt(1);
			// ES3YUITest.g:130:9: 'throw'
			{
			DebugLocation(130, 9);
			Match("throw"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("THROW", 22);
			LeaveRule("THROW", 22);
			Leave_THROW();
		}
	}
	// $ANTLR end "THROW"

	partial void Enter_TRY();
	partial void Leave_TRY();

	// $ANTLR start "TRY"
	[GrammarRule("TRY")]
	private void mTRY()
	{
		Enter_TRY();
		EnterRule("TRY", 23);
		TraceIn("TRY", 23);
		try
		{
			int _type = TRY;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:131:5: ( 'try' )
			DebugEnterAlt(1);
			// ES3YUITest.g:131:7: 'try'
			{
			DebugLocation(131, 7);
			Match("try"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("TRY", 23);
			LeaveRule("TRY", 23);
			Leave_TRY();
		}
	}
	// $ANTLR end "TRY"

	partial void Enter_TYPEOF();
	partial void Leave_TYPEOF();

	// $ANTLR start "TYPEOF"
	[GrammarRule("TYPEOF")]
	private void mTYPEOF()
	{
		Enter_TYPEOF();
		EnterRule("TYPEOF", 24);
		TraceIn("TYPEOF", 24);
		try
		{
			int _type = TYPEOF;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:132:8: ( 'typeof' )
			DebugEnterAlt(1);
			// ES3YUITest.g:132:10: 'typeof'
			{
			DebugLocation(132, 10);
			Match("typeof"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("TYPEOF", 24);
			LeaveRule("TYPEOF", 24);
			Leave_TYPEOF();
		}
	}
	// $ANTLR end "TYPEOF"

	partial void Enter_VAR();
	partial void Leave_VAR();

	// $ANTLR start "VAR"
	[GrammarRule("VAR")]
	private void mVAR()
	{
		Enter_VAR();
		EnterRule("VAR", 25);
		TraceIn("VAR", 25);
		try
		{
			int _type = VAR;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:133:5: ( 'var' )
			DebugEnterAlt(1);
			// ES3YUITest.g:133:7: 'var'
			{
			DebugLocation(133, 7);
			Match("var"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("VAR", 25);
			LeaveRule("VAR", 25);
			Leave_VAR();
		}
	}
	// $ANTLR end "VAR"

	partial void Enter_VOID();
	partial void Leave_VOID();

	// $ANTLR start "VOID"
	[GrammarRule("VOID")]
	private void mVOID()
	{
		Enter_VOID();
		EnterRule("VOID", 26);
		TraceIn("VOID", 26);
		try
		{
			int _type = VOID;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:134:6: ( 'void' )
			DebugEnterAlt(1);
			// ES3YUITest.g:134:8: 'void'
			{
			DebugLocation(134, 8);
			Match("void"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("VOID", 26);
			LeaveRule("VOID", 26);
			Leave_VOID();
		}
	}
	// $ANTLR end "VOID"

	partial void Enter_WHILE();
	partial void Leave_WHILE();

	// $ANTLR start "WHILE"
	[GrammarRule("WHILE")]
	private void mWHILE()
	{
		Enter_WHILE();
		EnterRule("WHILE", 27);
		TraceIn("WHILE", 27);
		try
		{
			int _type = WHILE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:135:7: ( 'while' )
			DebugEnterAlt(1);
			// ES3YUITest.g:135:9: 'while'
			{
			DebugLocation(135, 9);
			Match("while"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WHILE", 27);
			LeaveRule("WHILE", 27);
			Leave_WHILE();
		}
	}
	// $ANTLR end "WHILE"

	partial void Enter_WITH();
	partial void Leave_WITH();

	// $ANTLR start "WITH"
	[GrammarRule("WITH")]
	private void mWITH()
	{
		Enter_WITH();
		EnterRule("WITH", 28);
		TraceIn("WITH", 28);
		try
		{
			int _type = WITH;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:136:6: ( 'with' )
			DebugEnterAlt(1);
			// ES3YUITest.g:136:8: 'with'
			{
			DebugLocation(136, 8);
			Match("with"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WITH", 28);
			LeaveRule("WITH", 28);
			Leave_WITH();
		}
	}
	// $ANTLR end "WITH"

	partial void Enter_ABSTRACT();
	partial void Leave_ABSTRACT();

	// $ANTLR start "ABSTRACT"
	[GrammarRule("ABSTRACT")]
	private void mABSTRACT()
	{
		Enter_ABSTRACT();
		EnterRule("ABSTRACT", 29);
		TraceIn("ABSTRACT", 29);
		try
		{
			int _type = ABSTRACT;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:137:10: ( 'abstract' )
			DebugEnterAlt(1);
			// ES3YUITest.g:137:12: 'abstract'
			{
			DebugLocation(137, 12);
			Match("abstract"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ABSTRACT", 29);
			LeaveRule("ABSTRACT", 29);
			Leave_ABSTRACT();
		}
	}
	// $ANTLR end "ABSTRACT"

	partial void Enter_BOOLEAN();
	partial void Leave_BOOLEAN();

	// $ANTLR start "BOOLEAN"
	[GrammarRule("BOOLEAN")]
	private void mBOOLEAN()
	{
		Enter_BOOLEAN();
		EnterRule("BOOLEAN", 30);
		TraceIn("BOOLEAN", 30);
		try
		{
			int _type = BOOLEAN;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:138:9: ( 'boolean' )
			DebugEnterAlt(1);
			// ES3YUITest.g:138:11: 'boolean'
			{
			DebugLocation(138, 11);
			Match("boolean"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("BOOLEAN", 30);
			LeaveRule("BOOLEAN", 30);
			Leave_BOOLEAN();
		}
	}
	// $ANTLR end "BOOLEAN"

	partial void Enter_BYTE();
	partial void Leave_BYTE();

	// $ANTLR start "BYTE"
	[GrammarRule("BYTE")]
	private void mBYTE()
	{
		Enter_BYTE();
		EnterRule("BYTE", 31);
		TraceIn("BYTE", 31);
		try
		{
			int _type = BYTE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:139:6: ( 'byte' )
			DebugEnterAlt(1);
			// ES3YUITest.g:139:8: 'byte'
			{
			DebugLocation(139, 8);
			Match("byte"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("BYTE", 31);
			LeaveRule("BYTE", 31);
			Leave_BYTE();
		}
	}
	// $ANTLR end "BYTE"

	partial void Enter_CHAR();
	partial void Leave_CHAR();

	// $ANTLR start "CHAR"
	[GrammarRule("CHAR")]
	private void mCHAR()
	{
		Enter_CHAR();
		EnterRule("CHAR", 32);
		TraceIn("CHAR", 32);
		try
		{
			int _type = CHAR;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:140:6: ( 'char' )
			DebugEnterAlt(1);
			// ES3YUITest.g:140:8: 'char'
			{
			DebugLocation(140, 8);
			Match("char"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CHAR", 32);
			LeaveRule("CHAR", 32);
			Leave_CHAR();
		}
	}
	// $ANTLR end "CHAR"

	partial void Enter_CLASS();
	partial void Leave_CLASS();

	// $ANTLR start "CLASS"
	[GrammarRule("CLASS")]
	private void mCLASS()
	{
		Enter_CLASS();
		EnterRule("CLASS", 33);
		TraceIn("CLASS", 33);
		try
		{
			int _type = CLASS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:141:7: ( 'class' )
			DebugEnterAlt(1);
			// ES3YUITest.g:141:9: 'class'
			{
			DebugLocation(141, 9);
			Match("class"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CLASS", 33);
			LeaveRule("CLASS", 33);
			Leave_CLASS();
		}
	}
	// $ANTLR end "CLASS"

	partial void Enter_CONST();
	partial void Leave_CONST();

	// $ANTLR start "CONST"
	[GrammarRule("CONST")]
	private void mCONST()
	{
		Enter_CONST();
		EnterRule("CONST", 34);
		TraceIn("CONST", 34);
		try
		{
			int _type = CONST;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:142:7: ( 'const' )
			DebugEnterAlt(1);
			// ES3YUITest.g:142:9: 'const'
			{
			DebugLocation(142, 9);
			Match("const"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CONST", 34);
			LeaveRule("CONST", 34);
			Leave_CONST();
		}
	}
	// $ANTLR end "CONST"

	partial void Enter_DEBUGGER();
	partial void Leave_DEBUGGER();

	// $ANTLR start "DEBUGGER"
	[GrammarRule("DEBUGGER")]
	private void mDEBUGGER()
	{
		Enter_DEBUGGER();
		EnterRule("DEBUGGER", 35);
		TraceIn("DEBUGGER", 35);
		try
		{
			int _type = DEBUGGER;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:143:10: ( 'debugger' )
			DebugEnterAlt(1);
			// ES3YUITest.g:143:12: 'debugger'
			{
			DebugLocation(143, 12);
			Match("debugger"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DEBUGGER", 35);
			LeaveRule("DEBUGGER", 35);
			Leave_DEBUGGER();
		}
	}
	// $ANTLR end "DEBUGGER"

	partial void Enter_DOUBLE();
	partial void Leave_DOUBLE();

	// $ANTLR start "DOUBLE"
	[GrammarRule("DOUBLE")]
	private void mDOUBLE()
	{
		Enter_DOUBLE();
		EnterRule("DOUBLE", 36);
		TraceIn("DOUBLE", 36);
		try
		{
			int _type = DOUBLE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:144:8: ( 'double' )
			DebugEnterAlt(1);
			// ES3YUITest.g:144:10: 'double'
			{
			DebugLocation(144, 10);
			Match("double"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DOUBLE", 36);
			LeaveRule("DOUBLE", 36);
			Leave_DOUBLE();
		}
	}
	// $ANTLR end "DOUBLE"

	partial void Enter_ENUM();
	partial void Leave_ENUM();

	// $ANTLR start "ENUM"
	[GrammarRule("ENUM")]
	private void mENUM()
	{
		Enter_ENUM();
		EnterRule("ENUM", 37);
		TraceIn("ENUM", 37);
		try
		{
			int _type = ENUM;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:145:6: ( 'enum' )
			DebugEnterAlt(1);
			// ES3YUITest.g:145:8: 'enum'
			{
			DebugLocation(145, 8);
			Match("enum"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ENUM", 37);
			LeaveRule("ENUM", 37);
			Leave_ENUM();
		}
	}
	// $ANTLR end "ENUM"

	partial void Enter_EXPORT();
	partial void Leave_EXPORT();

	// $ANTLR start "EXPORT"
	[GrammarRule("EXPORT")]
	private void mEXPORT()
	{
		Enter_EXPORT();
		EnterRule("EXPORT", 38);
		TraceIn("EXPORT", 38);
		try
		{
			int _type = EXPORT;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:146:8: ( 'export' )
			DebugEnterAlt(1);
			// ES3YUITest.g:146:10: 'export'
			{
			DebugLocation(146, 10);
			Match("export"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("EXPORT", 38);
			LeaveRule("EXPORT", 38);
			Leave_EXPORT();
		}
	}
	// $ANTLR end "EXPORT"

	partial void Enter_EXTENDS();
	partial void Leave_EXTENDS();

	// $ANTLR start "EXTENDS"
	[GrammarRule("EXTENDS")]
	private void mEXTENDS()
	{
		Enter_EXTENDS();
		EnterRule("EXTENDS", 39);
		TraceIn("EXTENDS", 39);
		try
		{
			int _type = EXTENDS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:147:9: ( 'extends' )
			DebugEnterAlt(1);
			// ES3YUITest.g:147:11: 'extends'
			{
			DebugLocation(147, 11);
			Match("extends"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("EXTENDS", 39);
			LeaveRule("EXTENDS", 39);
			Leave_EXTENDS();
		}
	}
	// $ANTLR end "EXTENDS"

	partial void Enter_FINAL();
	partial void Leave_FINAL();

	// $ANTLR start "FINAL"
	[GrammarRule("FINAL")]
	private void mFINAL()
	{
		Enter_FINAL();
		EnterRule("FINAL", 40);
		TraceIn("FINAL", 40);
		try
		{
			int _type = FINAL;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:148:7: ( 'final' )
			DebugEnterAlt(1);
			// ES3YUITest.g:148:9: 'final'
			{
			DebugLocation(148, 9);
			Match("final"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FINAL", 40);
			LeaveRule("FINAL", 40);
			Leave_FINAL();
		}
	}
	// $ANTLR end "FINAL"

	partial void Enter_FLOAT();
	partial void Leave_FLOAT();

	// $ANTLR start "FLOAT"
	[GrammarRule("FLOAT")]
	private void mFLOAT()
	{
		Enter_FLOAT();
		EnterRule("FLOAT", 41);
		TraceIn("FLOAT", 41);
		try
		{
			int _type = FLOAT;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:149:7: ( 'float' )
			DebugEnterAlt(1);
			// ES3YUITest.g:149:9: 'float'
			{
			DebugLocation(149, 9);
			Match("float"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FLOAT", 41);
			LeaveRule("FLOAT", 41);
			Leave_FLOAT();
		}
	}
	// $ANTLR end "FLOAT"

	partial void Enter_GOTO();
	partial void Leave_GOTO();

	// $ANTLR start "GOTO"
	[GrammarRule("GOTO")]
	private void mGOTO()
	{
		Enter_GOTO();
		EnterRule("GOTO", 42);
		TraceIn("GOTO", 42);
		try
		{
			int _type = GOTO;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:150:6: ( 'goto' )
			DebugEnterAlt(1);
			// ES3YUITest.g:150:8: 'goto'
			{
			DebugLocation(150, 8);
			Match("goto"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("GOTO", 42);
			LeaveRule("GOTO", 42);
			Leave_GOTO();
		}
	}
	// $ANTLR end "GOTO"

	partial void Enter_IMPLEMENTS();
	partial void Leave_IMPLEMENTS();

	// $ANTLR start "IMPLEMENTS"
	[GrammarRule("IMPLEMENTS")]
	private void mIMPLEMENTS()
	{
		Enter_IMPLEMENTS();
		EnterRule("IMPLEMENTS", 43);
		TraceIn("IMPLEMENTS", 43);
		try
		{
			int _type = IMPLEMENTS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:151:12: ( 'implements' )
			DebugEnterAlt(1);
			// ES3YUITest.g:151:14: 'implements'
			{
			DebugLocation(151, 14);
			Match("implements"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IMPLEMENTS", 43);
			LeaveRule("IMPLEMENTS", 43);
			Leave_IMPLEMENTS();
		}
	}
	// $ANTLR end "IMPLEMENTS"

	partial void Enter_IMPORT();
	partial void Leave_IMPORT();

	// $ANTLR start "IMPORT"
	[GrammarRule("IMPORT")]
	private void mIMPORT()
	{
		Enter_IMPORT();
		EnterRule("IMPORT", 44);
		TraceIn("IMPORT", 44);
		try
		{
			int _type = IMPORT;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:152:8: ( 'import' )
			DebugEnterAlt(1);
			// ES3YUITest.g:152:10: 'import'
			{
			DebugLocation(152, 10);
			Match("import"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IMPORT", 44);
			LeaveRule("IMPORT", 44);
			Leave_IMPORT();
		}
	}
	// $ANTLR end "IMPORT"

	partial void Enter_INT();
	partial void Leave_INT();

	// $ANTLR start "INT"
	[GrammarRule("INT")]
	private void mINT()
	{
		Enter_INT();
		EnterRule("INT", 45);
		TraceIn("INT", 45);
		try
		{
			int _type = INT;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:153:5: ( 'int' )
			DebugEnterAlt(1);
			// ES3YUITest.g:153:7: 'int'
			{
			DebugLocation(153, 7);
			Match("int"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("INT", 45);
			LeaveRule("INT", 45);
			Leave_INT();
		}
	}
	// $ANTLR end "INT"

	partial void Enter_INTERFACE();
	partial void Leave_INTERFACE();

	// $ANTLR start "INTERFACE"
	[GrammarRule("INTERFACE")]
	private void mINTERFACE()
	{
		Enter_INTERFACE();
		EnterRule("INTERFACE", 46);
		TraceIn("INTERFACE", 46);
		try
		{
			int _type = INTERFACE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:154:11: ( 'interface' )
			DebugEnterAlt(1);
			// ES3YUITest.g:154:13: 'interface'
			{
			DebugLocation(154, 13);
			Match("interface"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("INTERFACE", 46);
			LeaveRule("INTERFACE", 46);
			Leave_INTERFACE();
		}
	}
	// $ANTLR end "INTERFACE"

	partial void Enter_LONG();
	partial void Leave_LONG();

	// $ANTLR start "LONG"
	[GrammarRule("LONG")]
	private void mLONG()
	{
		Enter_LONG();
		EnterRule("LONG", 47);
		TraceIn("LONG", 47);
		try
		{
			int _type = LONG;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:155:6: ( 'long' )
			DebugEnterAlt(1);
			// ES3YUITest.g:155:8: 'long'
			{
			DebugLocation(155, 8);
			Match("long"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LONG", 47);
			LeaveRule("LONG", 47);
			Leave_LONG();
		}
	}
	// $ANTLR end "LONG"

	partial void Enter_NATIVE();
	partial void Leave_NATIVE();

	// $ANTLR start "NATIVE"
	[GrammarRule("NATIVE")]
	private void mNATIVE()
	{
		Enter_NATIVE();
		EnterRule("NATIVE", 48);
		TraceIn("NATIVE", 48);
		try
		{
			int _type = NATIVE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:156:8: ( 'native' )
			DebugEnterAlt(1);
			// ES3YUITest.g:156:10: 'native'
			{
			DebugLocation(156, 10);
			Match("native"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NATIVE", 48);
			LeaveRule("NATIVE", 48);
			Leave_NATIVE();
		}
	}
	// $ANTLR end "NATIVE"

	partial void Enter_PACKAGE();
	partial void Leave_PACKAGE();

	// $ANTLR start "PACKAGE"
	[GrammarRule("PACKAGE")]
	private void mPACKAGE()
	{
		Enter_PACKAGE();
		EnterRule("PACKAGE", 49);
		TraceIn("PACKAGE", 49);
		try
		{
			int _type = PACKAGE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:157:9: ( 'package' )
			DebugEnterAlt(1);
			// ES3YUITest.g:157:11: 'package'
			{
			DebugLocation(157, 11);
			Match("package"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("PACKAGE", 49);
			LeaveRule("PACKAGE", 49);
			Leave_PACKAGE();
		}
	}
	// $ANTLR end "PACKAGE"

	partial void Enter_PRIVATE();
	partial void Leave_PRIVATE();

	// $ANTLR start "PRIVATE"
	[GrammarRule("PRIVATE")]
	private void mPRIVATE()
	{
		Enter_PRIVATE();
		EnterRule("PRIVATE", 50);
		TraceIn("PRIVATE", 50);
		try
		{
			int _type = PRIVATE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:158:9: ( 'private' )
			DebugEnterAlt(1);
			// ES3YUITest.g:158:11: 'private'
			{
			DebugLocation(158, 11);
			Match("private"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("PRIVATE", 50);
			LeaveRule("PRIVATE", 50);
			Leave_PRIVATE();
		}
	}
	// $ANTLR end "PRIVATE"

	partial void Enter_PROTECTED();
	partial void Leave_PROTECTED();

	// $ANTLR start "PROTECTED"
	[GrammarRule("PROTECTED")]
	private void mPROTECTED()
	{
		Enter_PROTECTED();
		EnterRule("PROTECTED", 51);
		TraceIn("PROTECTED", 51);
		try
		{
			int _type = PROTECTED;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:159:11: ( 'protected' )
			DebugEnterAlt(1);
			// ES3YUITest.g:159:13: 'protected'
			{
			DebugLocation(159, 13);
			Match("protected"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("PROTECTED", 51);
			LeaveRule("PROTECTED", 51);
			Leave_PROTECTED();
		}
	}
	// $ANTLR end "PROTECTED"

	partial void Enter_PUBLIC();
	partial void Leave_PUBLIC();

	// $ANTLR start "PUBLIC"
	[GrammarRule("PUBLIC")]
	private void mPUBLIC()
	{
		Enter_PUBLIC();
		EnterRule("PUBLIC", 52);
		TraceIn("PUBLIC", 52);
		try
		{
			int _type = PUBLIC;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:160:8: ( 'public' )
			DebugEnterAlt(1);
			// ES3YUITest.g:160:10: 'public'
			{
			DebugLocation(160, 10);
			Match("public"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("PUBLIC", 52);
			LeaveRule("PUBLIC", 52);
			Leave_PUBLIC();
		}
	}
	// $ANTLR end "PUBLIC"

	partial void Enter_SHORT();
	partial void Leave_SHORT();

	// $ANTLR start "SHORT"
	[GrammarRule("SHORT")]
	private void mSHORT()
	{
		Enter_SHORT();
		EnterRule("SHORT", 53);
		TraceIn("SHORT", 53);
		try
		{
			int _type = SHORT;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:161:7: ( 'short' )
			DebugEnterAlt(1);
			// ES3YUITest.g:161:9: 'short'
			{
			DebugLocation(161, 9);
			Match("short"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHORT", 53);
			LeaveRule("SHORT", 53);
			Leave_SHORT();
		}
	}
	// $ANTLR end "SHORT"

	partial void Enter_STATIC();
	partial void Leave_STATIC();

	// $ANTLR start "STATIC"
	[GrammarRule("STATIC")]
	private void mSTATIC()
	{
		Enter_STATIC();
		EnterRule("STATIC", 54);
		TraceIn("STATIC", 54);
		try
		{
			int _type = STATIC;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:162:8: ( 'static' )
			DebugEnterAlt(1);
			// ES3YUITest.g:162:10: 'static'
			{
			DebugLocation(162, 10);
			Match("static"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("STATIC", 54);
			LeaveRule("STATIC", 54);
			Leave_STATIC();
		}
	}
	// $ANTLR end "STATIC"

	partial void Enter_SUPER();
	partial void Leave_SUPER();

	// $ANTLR start "SUPER"
	[GrammarRule("SUPER")]
	private void mSUPER()
	{
		Enter_SUPER();
		EnterRule("SUPER", 55);
		TraceIn("SUPER", 55);
		try
		{
			int _type = SUPER;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:163:7: ( 'super' )
			DebugEnterAlt(1);
			// ES3YUITest.g:163:9: 'super'
			{
			DebugLocation(163, 9);
			Match("super"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SUPER", 55);
			LeaveRule("SUPER", 55);
			Leave_SUPER();
		}
	}
	// $ANTLR end "SUPER"

	partial void Enter_SYNCHRONIZED();
	partial void Leave_SYNCHRONIZED();

	// $ANTLR start "SYNCHRONIZED"
	[GrammarRule("SYNCHRONIZED")]
	private void mSYNCHRONIZED()
	{
		Enter_SYNCHRONIZED();
		EnterRule("SYNCHRONIZED", 56);
		TraceIn("SYNCHRONIZED", 56);
		try
		{
			int _type = SYNCHRONIZED;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:164:14: ( 'synchronized' )
			DebugEnterAlt(1);
			// ES3YUITest.g:164:16: 'synchronized'
			{
			DebugLocation(164, 16);
			Match("synchronized"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SYNCHRONIZED", 56);
			LeaveRule("SYNCHRONIZED", 56);
			Leave_SYNCHRONIZED();
		}
	}
	// $ANTLR end "SYNCHRONIZED"

	partial void Enter_THROWS();
	partial void Leave_THROWS();

	// $ANTLR start "THROWS"
	[GrammarRule("THROWS")]
	private void mTHROWS()
	{
		Enter_THROWS();
		EnterRule("THROWS", 57);
		TraceIn("THROWS", 57);
		try
		{
			int _type = THROWS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:165:8: ( 'throws' )
			DebugEnterAlt(1);
			// ES3YUITest.g:165:10: 'throws'
			{
			DebugLocation(165, 10);
			Match("throws"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("THROWS", 57);
			LeaveRule("THROWS", 57);
			Leave_THROWS();
		}
	}
	// $ANTLR end "THROWS"

	partial void Enter_TRANSIENT();
	partial void Leave_TRANSIENT();

	// $ANTLR start "TRANSIENT"
	[GrammarRule("TRANSIENT")]
	private void mTRANSIENT()
	{
		Enter_TRANSIENT();
		EnterRule("TRANSIENT", 58);
		TraceIn("TRANSIENT", 58);
		try
		{
			int _type = TRANSIENT;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:166:11: ( 'transient' )
			DebugEnterAlt(1);
			// ES3YUITest.g:166:13: 'transient'
			{
			DebugLocation(166, 13);
			Match("transient"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("TRANSIENT", 58);
			LeaveRule("TRANSIENT", 58);
			Leave_TRANSIENT();
		}
	}
	// $ANTLR end "TRANSIENT"

	partial void Enter_VOLATILE();
	partial void Leave_VOLATILE();

	// $ANTLR start "VOLATILE"
	[GrammarRule("VOLATILE")]
	private void mVOLATILE()
	{
		Enter_VOLATILE();
		EnterRule("VOLATILE", 59);
		TraceIn("VOLATILE", 59);
		try
		{
			int _type = VOLATILE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:167:10: ( 'volatile' )
			DebugEnterAlt(1);
			// ES3YUITest.g:167:12: 'volatile'
			{
			DebugLocation(167, 12);
			Match("volatile"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("VOLATILE", 59);
			LeaveRule("VOLATILE", 59);
			Leave_VOLATILE();
		}
	}
	// $ANTLR end "VOLATILE"

	partial void Enter_LBRACE();
	partial void Leave_LBRACE();

	// $ANTLR start "LBRACE"
	[GrammarRule("LBRACE")]
	private void mLBRACE()
	{
		Enter_LBRACE();
		EnterRule("LBRACE", 60);
		TraceIn("LBRACE", 60);
		try
		{
			int _type = LBRACE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:168:8: ( '{' )
			DebugEnterAlt(1);
			// ES3YUITest.g:168:10: '{'
			{
			DebugLocation(168, 10);
			Match('{'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LBRACE", 60);
			LeaveRule("LBRACE", 60);
			Leave_LBRACE();
		}
	}
	// $ANTLR end "LBRACE"

	partial void Enter_RBRACE();
	partial void Leave_RBRACE();

	// $ANTLR start "RBRACE"
	[GrammarRule("RBRACE")]
	private void mRBRACE()
	{
		Enter_RBRACE();
		EnterRule("RBRACE", 61);
		TraceIn("RBRACE", 61);
		try
		{
			int _type = RBRACE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:169:8: ( '}' )
			DebugEnterAlt(1);
			// ES3YUITest.g:169:10: '}'
			{
			DebugLocation(169, 10);
			Match('}'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RBRACE", 61);
			LeaveRule("RBRACE", 61);
			Leave_RBRACE();
		}
	}
	// $ANTLR end "RBRACE"

	partial void Enter_LPAREN();
	partial void Leave_LPAREN();

	// $ANTLR start "LPAREN"
	[GrammarRule("LPAREN")]
	private void mLPAREN()
	{
		Enter_LPAREN();
		EnterRule("LPAREN", 62);
		TraceIn("LPAREN", 62);
		try
		{
			int _type = LPAREN;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:170:8: ( '(' )
			DebugEnterAlt(1);
			// ES3YUITest.g:170:10: '('
			{
			DebugLocation(170, 10);
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LPAREN", 62);
			LeaveRule("LPAREN", 62);
			Leave_LPAREN();
		}
	}
	// $ANTLR end "LPAREN"

	partial void Enter_RPAREN();
	partial void Leave_RPAREN();

	// $ANTLR start "RPAREN"
	[GrammarRule("RPAREN")]
	private void mRPAREN()
	{
		Enter_RPAREN();
		EnterRule("RPAREN", 63);
		TraceIn("RPAREN", 63);
		try
		{
			int _type = RPAREN;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:171:8: ( ')' )
			DebugEnterAlt(1);
			// ES3YUITest.g:171:10: ')'
			{
			DebugLocation(171, 10);
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RPAREN", 63);
			LeaveRule("RPAREN", 63);
			Leave_RPAREN();
		}
	}
	// $ANTLR end "RPAREN"

	partial void Enter_LBRACK();
	partial void Leave_LBRACK();

	// $ANTLR start "LBRACK"
	[GrammarRule("LBRACK")]
	private void mLBRACK()
	{
		Enter_LBRACK();
		EnterRule("LBRACK", 64);
		TraceIn("LBRACK", 64);
		try
		{
			int _type = LBRACK;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:172:8: ( '[' )
			DebugEnterAlt(1);
			// ES3YUITest.g:172:10: '['
			{
			DebugLocation(172, 10);
			Match('['); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LBRACK", 64);
			LeaveRule("LBRACK", 64);
			Leave_LBRACK();
		}
	}
	// $ANTLR end "LBRACK"

	partial void Enter_RBRACK();
	partial void Leave_RBRACK();

	// $ANTLR start "RBRACK"
	[GrammarRule("RBRACK")]
	private void mRBRACK()
	{
		Enter_RBRACK();
		EnterRule("RBRACK", 65);
		TraceIn("RBRACK", 65);
		try
		{
			int _type = RBRACK;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:173:8: ( ']' )
			DebugEnterAlt(1);
			// ES3YUITest.g:173:10: ']'
			{
			DebugLocation(173, 10);
			Match(']'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RBRACK", 65);
			LeaveRule("RBRACK", 65);
			Leave_RBRACK();
		}
	}
	// $ANTLR end "RBRACK"

	partial void Enter_DOT();
	partial void Leave_DOT();

	// $ANTLR start "DOT"
	[GrammarRule("DOT")]
	private void mDOT()
	{
		Enter_DOT();
		EnterRule("DOT", 66);
		TraceIn("DOT", 66);
		try
		{
			int _type = DOT;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:174:5: ( '.' )
			DebugEnterAlt(1);
			// ES3YUITest.g:174:7: '.'
			{
			DebugLocation(174, 7);
			Match('.'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DOT", 66);
			LeaveRule("DOT", 66);
			Leave_DOT();
		}
	}
	// $ANTLR end "DOT"

	partial void Enter_SEMIC();
	partial void Leave_SEMIC();

	// $ANTLR start "SEMIC"
	[GrammarRule("SEMIC")]
	private void mSEMIC()
	{
		Enter_SEMIC();
		EnterRule("SEMIC", 67);
		TraceIn("SEMIC", 67);
		try
		{
			int _type = SEMIC;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:175:7: ( ';' )
			DebugEnterAlt(1);
			// ES3YUITest.g:175:9: ';'
			{
			DebugLocation(175, 9);
			Match(';'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SEMIC", 67);
			LeaveRule("SEMIC", 67);
			Leave_SEMIC();
		}
	}
	// $ANTLR end "SEMIC"

	partial void Enter_COMMA();
	partial void Leave_COMMA();

	// $ANTLR start "COMMA"
	[GrammarRule("COMMA")]
	private void mCOMMA()
	{
		Enter_COMMA();
		EnterRule("COMMA", 68);
		TraceIn("COMMA", 68);
		try
		{
			int _type = COMMA;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:176:7: ( ',' )
			DebugEnterAlt(1);
			// ES3YUITest.g:176:9: ','
			{
			DebugLocation(176, 9);
			Match(','); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("COMMA", 68);
			LeaveRule("COMMA", 68);
			Leave_COMMA();
		}
	}
	// $ANTLR end "COMMA"

	partial void Enter_LT();
	partial void Leave_LT();

	// $ANTLR start "LT"
	[GrammarRule("LT")]
	private void mLT()
	{
		Enter_LT();
		EnterRule("LT", 69);
		TraceIn("LT", 69);
		try
		{
			int _type = LT;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:177:4: ( '<' )
			DebugEnterAlt(1);
			// ES3YUITest.g:177:6: '<'
			{
			DebugLocation(177, 6);
			Match('<'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LT", 69);
			LeaveRule("LT", 69);
			Leave_LT();
		}
	}
	// $ANTLR end "LT"

	partial void Enter_GT();
	partial void Leave_GT();

	// $ANTLR start "GT"
	[GrammarRule("GT")]
	private void mGT()
	{
		Enter_GT();
		EnterRule("GT", 70);
		TraceIn("GT", 70);
		try
		{
			int _type = GT;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:178:4: ( '>' )
			DebugEnterAlt(1);
			// ES3YUITest.g:178:6: '>'
			{
			DebugLocation(178, 6);
			Match('>'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("GT", 70);
			LeaveRule("GT", 70);
			Leave_GT();
		}
	}
	// $ANTLR end "GT"

	partial void Enter_LTE();
	partial void Leave_LTE();

	// $ANTLR start "LTE"
	[GrammarRule("LTE")]
	private void mLTE()
	{
		Enter_LTE();
		EnterRule("LTE", 71);
		TraceIn("LTE", 71);
		try
		{
			int _type = LTE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:179:5: ( '<=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:179:7: '<='
			{
			DebugLocation(179, 7);
			Match("<="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LTE", 71);
			LeaveRule("LTE", 71);
			Leave_LTE();
		}
	}
	// $ANTLR end "LTE"

	partial void Enter_GTE();
	partial void Leave_GTE();

	// $ANTLR start "GTE"
	[GrammarRule("GTE")]
	private void mGTE()
	{
		Enter_GTE();
		EnterRule("GTE", 72);
		TraceIn("GTE", 72);
		try
		{
			int _type = GTE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:180:5: ( '>=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:180:7: '>='
			{
			DebugLocation(180, 7);
			Match(">="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("GTE", 72);
			LeaveRule("GTE", 72);
			Leave_GTE();
		}
	}
	// $ANTLR end "GTE"

	partial void Enter_EQ();
	partial void Leave_EQ();

	// $ANTLR start "EQ"
	[GrammarRule("EQ")]
	private void mEQ()
	{
		Enter_EQ();
		EnterRule("EQ", 73);
		TraceIn("EQ", 73);
		try
		{
			int _type = EQ;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:181:4: ( '==' )
			DebugEnterAlt(1);
			// ES3YUITest.g:181:6: '=='
			{
			DebugLocation(181, 6);
			Match("=="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("EQ", 73);
			LeaveRule("EQ", 73);
			Leave_EQ();
		}
	}
	// $ANTLR end "EQ"

	partial void Enter_NEQ();
	partial void Leave_NEQ();

	// $ANTLR start "NEQ"
	[GrammarRule("NEQ")]
	private void mNEQ()
	{
		Enter_NEQ();
		EnterRule("NEQ", 74);
		TraceIn("NEQ", 74);
		try
		{
			int _type = NEQ;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:182:5: ( '!=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:182:7: '!='
			{
			DebugLocation(182, 7);
			Match("!="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NEQ", 74);
			LeaveRule("NEQ", 74);
			Leave_NEQ();
		}
	}
	// $ANTLR end "NEQ"

	partial void Enter_SAME();
	partial void Leave_SAME();

	// $ANTLR start "SAME"
	[GrammarRule("SAME")]
	private void mSAME()
	{
		Enter_SAME();
		EnterRule("SAME", 75);
		TraceIn("SAME", 75);
		try
		{
			int _type = SAME;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:183:6: ( '===' )
			DebugEnterAlt(1);
			// ES3YUITest.g:183:8: '==='
			{
			DebugLocation(183, 8);
			Match("==="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SAME", 75);
			LeaveRule("SAME", 75);
			Leave_SAME();
		}
	}
	// $ANTLR end "SAME"

	partial void Enter_NSAME();
	partial void Leave_NSAME();

	// $ANTLR start "NSAME"
	[GrammarRule("NSAME")]
	private void mNSAME()
	{
		Enter_NSAME();
		EnterRule("NSAME", 76);
		TraceIn("NSAME", 76);
		try
		{
			int _type = NSAME;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:184:7: ( '!==' )
			DebugEnterAlt(1);
			// ES3YUITest.g:184:9: '!=='
			{
			DebugLocation(184, 9);
			Match("!=="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NSAME", 76);
			LeaveRule("NSAME", 76);
			Leave_NSAME();
		}
	}
	// $ANTLR end "NSAME"

	partial void Enter_ADD();
	partial void Leave_ADD();

	// $ANTLR start "ADD"
	[GrammarRule("ADD")]
	private void mADD()
	{
		Enter_ADD();
		EnterRule("ADD", 77);
		TraceIn("ADD", 77);
		try
		{
			int _type = ADD;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:185:5: ( '+' )
			DebugEnterAlt(1);
			// ES3YUITest.g:185:7: '+'
			{
			DebugLocation(185, 7);
			Match('+'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ADD", 77);
			LeaveRule("ADD", 77);
			Leave_ADD();
		}
	}
	// $ANTLR end "ADD"

	partial void Enter_SUB();
	partial void Leave_SUB();

	// $ANTLR start "SUB"
	[GrammarRule("SUB")]
	private void mSUB()
	{
		Enter_SUB();
		EnterRule("SUB", 78);
		TraceIn("SUB", 78);
		try
		{
			int _type = SUB;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:186:5: ( '-' )
			DebugEnterAlt(1);
			// ES3YUITest.g:186:7: '-'
			{
			DebugLocation(186, 7);
			Match('-'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SUB", 78);
			LeaveRule("SUB", 78);
			Leave_SUB();
		}
	}
	// $ANTLR end "SUB"

	partial void Enter_MUL();
	partial void Leave_MUL();

	// $ANTLR start "MUL"
	[GrammarRule("MUL")]
	private void mMUL()
	{
		Enter_MUL();
		EnterRule("MUL", 79);
		TraceIn("MUL", 79);
		try
		{
			int _type = MUL;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:187:5: ( '*' )
			DebugEnterAlt(1);
			// ES3YUITest.g:187:7: '*'
			{
			DebugLocation(187, 7);
			Match('*'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("MUL", 79);
			LeaveRule("MUL", 79);
			Leave_MUL();
		}
	}
	// $ANTLR end "MUL"

	partial void Enter_MOD();
	partial void Leave_MOD();

	// $ANTLR start "MOD"
	[GrammarRule("MOD")]
	private void mMOD()
	{
		Enter_MOD();
		EnterRule("MOD", 80);
		TraceIn("MOD", 80);
		try
		{
			int _type = MOD;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:188:5: ( '%' )
			DebugEnterAlt(1);
			// ES3YUITest.g:188:7: '%'
			{
			DebugLocation(188, 7);
			Match('%'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("MOD", 80);
			LeaveRule("MOD", 80);
			Leave_MOD();
		}
	}
	// $ANTLR end "MOD"

	partial void Enter_INC();
	partial void Leave_INC();

	// $ANTLR start "INC"
	[GrammarRule("INC")]
	private void mINC()
	{
		Enter_INC();
		EnterRule("INC", 81);
		TraceIn("INC", 81);
		try
		{
			int _type = INC;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:189:5: ( '++' )
			DebugEnterAlt(1);
			// ES3YUITest.g:189:7: '++'
			{
			DebugLocation(189, 7);
			Match("++"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("INC", 81);
			LeaveRule("INC", 81);
			Leave_INC();
		}
	}
	// $ANTLR end "INC"

	partial void Enter_DEC();
	partial void Leave_DEC();

	// $ANTLR start "DEC"
	[GrammarRule("DEC")]
	private void mDEC()
	{
		Enter_DEC();
		EnterRule("DEC", 82);
		TraceIn("DEC", 82);
		try
		{
			int _type = DEC;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:190:5: ( '--' )
			DebugEnterAlt(1);
			// ES3YUITest.g:190:7: '--'
			{
			DebugLocation(190, 7);
			Match("--"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DEC", 82);
			LeaveRule("DEC", 82);
			Leave_DEC();
		}
	}
	// $ANTLR end "DEC"

	partial void Enter_SHL();
	partial void Leave_SHL();

	// $ANTLR start "SHL"
	[GrammarRule("SHL")]
	private void mSHL()
	{
		Enter_SHL();
		EnterRule("SHL", 83);
		TraceIn("SHL", 83);
		try
		{
			int _type = SHL;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:191:5: ( '<<' )
			DebugEnterAlt(1);
			// ES3YUITest.g:191:7: '<<'
			{
			DebugLocation(191, 7);
			Match("<<"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHL", 83);
			LeaveRule("SHL", 83);
			Leave_SHL();
		}
	}
	// $ANTLR end "SHL"

	partial void Enter_SHR();
	partial void Leave_SHR();

	// $ANTLR start "SHR"
	[GrammarRule("SHR")]
	private void mSHR()
	{
		Enter_SHR();
		EnterRule("SHR", 84);
		TraceIn("SHR", 84);
		try
		{
			int _type = SHR;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:192:5: ( '>>' )
			DebugEnterAlt(1);
			// ES3YUITest.g:192:7: '>>'
			{
			DebugLocation(192, 7);
			Match(">>"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHR", 84);
			LeaveRule("SHR", 84);
			Leave_SHR();
		}
	}
	// $ANTLR end "SHR"

	partial void Enter_SHU();
	partial void Leave_SHU();

	// $ANTLR start "SHU"
	[GrammarRule("SHU")]
	private void mSHU()
	{
		Enter_SHU();
		EnterRule("SHU", 85);
		TraceIn("SHU", 85);
		try
		{
			int _type = SHU;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:193:5: ( '>>>' )
			DebugEnterAlt(1);
			// ES3YUITest.g:193:7: '>>>'
			{
			DebugLocation(193, 7);
			Match(">>>"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHU", 85);
			LeaveRule("SHU", 85);
			Leave_SHU();
		}
	}
	// $ANTLR end "SHU"

	partial void Enter_AND();
	partial void Leave_AND();

	// $ANTLR start "AND"
	[GrammarRule("AND")]
	private void mAND()
	{
		Enter_AND();
		EnterRule("AND", 86);
		TraceIn("AND", 86);
		try
		{
			int _type = AND;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:194:5: ( '&' )
			DebugEnterAlt(1);
			// ES3YUITest.g:194:7: '&'
			{
			DebugLocation(194, 7);
			Match('&'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("AND", 86);
			LeaveRule("AND", 86);
			Leave_AND();
		}
	}
	// $ANTLR end "AND"

	partial void Enter_OR();
	partial void Leave_OR();

	// $ANTLR start "OR"
	[GrammarRule("OR")]
	private void mOR()
	{
		Enter_OR();
		EnterRule("OR", 87);
		TraceIn("OR", 87);
		try
		{
			int _type = OR;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:195:4: ( '|' )
			DebugEnterAlt(1);
			// ES3YUITest.g:195:6: '|'
			{
			DebugLocation(195, 6);
			Match('|'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("OR", 87);
			LeaveRule("OR", 87);
			Leave_OR();
		}
	}
	// $ANTLR end "OR"

	partial void Enter_XOR();
	partial void Leave_XOR();

	// $ANTLR start "XOR"
	[GrammarRule("XOR")]
	private void mXOR()
	{
		Enter_XOR();
		EnterRule("XOR", 88);
		TraceIn("XOR", 88);
		try
		{
			int _type = XOR;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:196:5: ( '^' )
			DebugEnterAlt(1);
			// ES3YUITest.g:196:7: '^'
			{
			DebugLocation(196, 7);
			Match('^'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("XOR", 88);
			LeaveRule("XOR", 88);
			Leave_XOR();
		}
	}
	// $ANTLR end "XOR"

	partial void Enter_NOT();
	partial void Leave_NOT();

	// $ANTLR start "NOT"
	[GrammarRule("NOT")]
	private void mNOT()
	{
		Enter_NOT();
		EnterRule("NOT", 89);
		TraceIn("NOT", 89);
		try
		{
			int _type = NOT;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:197:5: ( '!' )
			DebugEnterAlt(1);
			// ES3YUITest.g:197:7: '!'
			{
			DebugLocation(197, 7);
			Match('!'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NOT", 89);
			LeaveRule("NOT", 89);
			Leave_NOT();
		}
	}
	// $ANTLR end "NOT"

	partial void Enter_INV();
	partial void Leave_INV();

	// $ANTLR start "INV"
	[GrammarRule("INV")]
	private void mINV()
	{
		Enter_INV();
		EnterRule("INV", 90);
		TraceIn("INV", 90);
		try
		{
			int _type = INV;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:198:5: ( '~' )
			DebugEnterAlt(1);
			// ES3YUITest.g:198:7: '~'
			{
			DebugLocation(198, 7);
			Match('~'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("INV", 90);
			LeaveRule("INV", 90);
			Leave_INV();
		}
	}
	// $ANTLR end "INV"

	partial void Enter_LAND();
	partial void Leave_LAND();

	// $ANTLR start "LAND"
	[GrammarRule("LAND")]
	private void mLAND()
	{
		Enter_LAND();
		EnterRule("LAND", 91);
		TraceIn("LAND", 91);
		try
		{
			int _type = LAND;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:199:6: ( '&&' )
			DebugEnterAlt(1);
			// ES3YUITest.g:199:8: '&&'
			{
			DebugLocation(199, 8);
			Match("&&"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LAND", 91);
			LeaveRule("LAND", 91);
			Leave_LAND();
		}
	}
	// $ANTLR end "LAND"

	partial void Enter_LOR();
	partial void Leave_LOR();

	// $ANTLR start "LOR"
	[GrammarRule("LOR")]
	private void mLOR()
	{
		Enter_LOR();
		EnterRule("LOR", 92);
		TraceIn("LOR", 92);
		try
		{
			int _type = LOR;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:200:5: ( '||' )
			DebugEnterAlt(1);
			// ES3YUITest.g:200:7: '||'
			{
			DebugLocation(200, 7);
			Match("||"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LOR", 92);
			LeaveRule("LOR", 92);
			Leave_LOR();
		}
	}
	// $ANTLR end "LOR"

	partial void Enter_QUE();
	partial void Leave_QUE();

	// $ANTLR start "QUE"
	[GrammarRule("QUE")]
	private void mQUE()
	{
		Enter_QUE();
		EnterRule("QUE", 93);
		TraceIn("QUE", 93);
		try
		{
			int _type = QUE;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:201:5: ( '?' )
			DebugEnterAlt(1);
			// ES3YUITest.g:201:7: '?'
			{
			DebugLocation(201, 7);
			Match('?'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("QUE", 93);
			LeaveRule("QUE", 93);
			Leave_QUE();
		}
	}
	// $ANTLR end "QUE"

	partial void Enter_COLON();
	partial void Leave_COLON();

	// $ANTLR start "COLON"
	[GrammarRule("COLON")]
	private void mCOLON()
	{
		Enter_COLON();
		EnterRule("COLON", 94);
		TraceIn("COLON", 94);
		try
		{
			int _type = COLON;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:202:7: ( ':' )
			DebugEnterAlt(1);
			// ES3YUITest.g:202:9: ':'
			{
			DebugLocation(202, 9);
			Match(':'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("COLON", 94);
			LeaveRule("COLON", 94);
			Leave_COLON();
		}
	}
	// $ANTLR end "COLON"

	partial void Enter_ASSIGN();
	partial void Leave_ASSIGN();

	// $ANTLR start "ASSIGN"
	[GrammarRule("ASSIGN")]
	private void mASSIGN()
	{
		Enter_ASSIGN();
		EnterRule("ASSIGN", 95);
		TraceIn("ASSIGN", 95);
		try
		{
			int _type = ASSIGN;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:203:8: ( '=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:203:10: '='
			{
			DebugLocation(203, 10);
			Match('='); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ASSIGN", 95);
			LeaveRule("ASSIGN", 95);
			Leave_ASSIGN();
		}
	}
	// $ANTLR end "ASSIGN"

	partial void Enter_ADDASS();
	partial void Leave_ADDASS();

	// $ANTLR start "ADDASS"
	[GrammarRule("ADDASS")]
	private void mADDASS()
	{
		Enter_ADDASS();
		EnterRule("ADDASS", 96);
		TraceIn("ADDASS", 96);
		try
		{
			int _type = ADDASS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:204:8: ( '+=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:204:10: '+='
			{
			DebugLocation(204, 10);
			Match("+="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ADDASS", 96);
			LeaveRule("ADDASS", 96);
			Leave_ADDASS();
		}
	}
	// $ANTLR end "ADDASS"

	partial void Enter_SUBASS();
	partial void Leave_SUBASS();

	// $ANTLR start "SUBASS"
	[GrammarRule("SUBASS")]
	private void mSUBASS()
	{
		Enter_SUBASS();
		EnterRule("SUBASS", 97);
		TraceIn("SUBASS", 97);
		try
		{
			int _type = SUBASS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:205:8: ( '-=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:205:10: '-='
			{
			DebugLocation(205, 10);
			Match("-="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SUBASS", 97);
			LeaveRule("SUBASS", 97);
			Leave_SUBASS();
		}
	}
	// $ANTLR end "SUBASS"

	partial void Enter_MULASS();
	partial void Leave_MULASS();

	// $ANTLR start "MULASS"
	[GrammarRule("MULASS")]
	private void mMULASS()
	{
		Enter_MULASS();
		EnterRule("MULASS", 98);
		TraceIn("MULASS", 98);
		try
		{
			int _type = MULASS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:206:8: ( '*=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:206:10: '*='
			{
			DebugLocation(206, 10);
			Match("*="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("MULASS", 98);
			LeaveRule("MULASS", 98);
			Leave_MULASS();
		}
	}
	// $ANTLR end "MULASS"

	partial void Enter_MODASS();
	partial void Leave_MODASS();

	// $ANTLR start "MODASS"
	[GrammarRule("MODASS")]
	private void mMODASS()
	{
		Enter_MODASS();
		EnterRule("MODASS", 99);
		TraceIn("MODASS", 99);
		try
		{
			int _type = MODASS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:207:8: ( '%=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:207:10: '%='
			{
			DebugLocation(207, 10);
			Match("%="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("MODASS", 99);
			LeaveRule("MODASS", 99);
			Leave_MODASS();
		}
	}
	// $ANTLR end "MODASS"

	partial void Enter_SHLASS();
	partial void Leave_SHLASS();

	// $ANTLR start "SHLASS"
	[GrammarRule("SHLASS")]
	private void mSHLASS()
	{
		Enter_SHLASS();
		EnterRule("SHLASS", 100);
		TraceIn("SHLASS", 100);
		try
		{
			int _type = SHLASS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:208:8: ( '<<=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:208:10: '<<='
			{
			DebugLocation(208, 10);
			Match("<<="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHLASS", 100);
			LeaveRule("SHLASS", 100);
			Leave_SHLASS();
		}
	}
	// $ANTLR end "SHLASS"

	partial void Enter_SHRASS();
	partial void Leave_SHRASS();

	// $ANTLR start "SHRASS"
	[GrammarRule("SHRASS")]
	private void mSHRASS()
	{
		Enter_SHRASS();
		EnterRule("SHRASS", 101);
		TraceIn("SHRASS", 101);
		try
		{
			int _type = SHRASS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:209:8: ( '>>=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:209:10: '>>='
			{
			DebugLocation(209, 10);
			Match(">>="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHRASS", 101);
			LeaveRule("SHRASS", 101);
			Leave_SHRASS();
		}
	}
	// $ANTLR end "SHRASS"

	partial void Enter_SHUASS();
	partial void Leave_SHUASS();

	// $ANTLR start "SHUASS"
	[GrammarRule("SHUASS")]
	private void mSHUASS()
	{
		Enter_SHUASS();
		EnterRule("SHUASS", 102);
		TraceIn("SHUASS", 102);
		try
		{
			int _type = SHUASS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:210:8: ( '>>>=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:210:10: '>>>='
			{
			DebugLocation(210, 10);
			Match(">>>="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHUASS", 102);
			LeaveRule("SHUASS", 102);
			Leave_SHUASS();
		}
	}
	// $ANTLR end "SHUASS"

	partial void Enter_ANDASS();
	partial void Leave_ANDASS();

	// $ANTLR start "ANDASS"
	[GrammarRule("ANDASS")]
	private void mANDASS()
	{
		Enter_ANDASS();
		EnterRule("ANDASS", 103);
		TraceIn("ANDASS", 103);
		try
		{
			int _type = ANDASS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:211:8: ( '&=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:211:10: '&='
			{
			DebugLocation(211, 10);
			Match("&="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ANDASS", 103);
			LeaveRule("ANDASS", 103);
			Leave_ANDASS();
		}
	}
	// $ANTLR end "ANDASS"

	partial void Enter_ORASS();
	partial void Leave_ORASS();

	// $ANTLR start "ORASS"
	[GrammarRule("ORASS")]
	private void mORASS()
	{
		Enter_ORASS();
		EnterRule("ORASS", 104);
		TraceIn("ORASS", 104);
		try
		{
			int _type = ORASS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:212:7: ( '|=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:212:9: '|='
			{
			DebugLocation(212, 9);
			Match("|="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ORASS", 104);
			LeaveRule("ORASS", 104);
			Leave_ORASS();
		}
	}
	// $ANTLR end "ORASS"

	partial void Enter_XORASS();
	partial void Leave_XORASS();

	// $ANTLR start "XORASS"
	[GrammarRule("XORASS")]
	private void mXORASS()
	{
		Enter_XORASS();
		EnterRule("XORASS", 105);
		TraceIn("XORASS", 105);
		try
		{
			int _type = XORASS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:213:8: ( '^=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:213:10: '^='
			{
			DebugLocation(213, 10);
			Match("^="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("XORASS", 105);
			LeaveRule("XORASS", 105);
			Leave_XORASS();
		}
	}
	// $ANTLR end "XORASS"

	partial void Enter_DIV();
	partial void Leave_DIV();

	// $ANTLR start "DIV"
	[GrammarRule("DIV")]
	private void mDIV()
	{
		Enter_DIV();
		EnterRule("DIV", 106);
		TraceIn("DIV", 106);
		try
		{
			int _type = DIV;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:214:5: ( '/' )
			DebugEnterAlt(1);
			// ES3YUITest.g:214:7: '/'
			{
			DebugLocation(214, 7);
			Match('/'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DIV", 106);
			LeaveRule("DIV", 106);
			Leave_DIV();
		}
	}
	// $ANTLR end "DIV"

	partial void Enter_DIVASS();
	partial void Leave_DIVASS();

	// $ANTLR start "DIVASS"
	[GrammarRule("DIVASS")]
	private void mDIVASS()
	{
		Enter_DIVASS();
		EnterRule("DIVASS", 107);
		TraceIn("DIVASS", 107);
		try
		{
			int _type = DIVASS;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:215:8: ( '/=' )
			DebugEnterAlt(1);
			// ES3YUITest.g:215:10: '/='
			{
			DebugLocation(215, 10);
			Match("/="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DIVASS", 107);
			LeaveRule("DIVASS", 107);
			Leave_DIVASS();
		}
	}
	// $ANTLR end "DIVASS"

	partial void Enter_BSLASH();
	partial void Leave_BSLASH();

	// $ANTLR start "BSLASH"
	[GrammarRule("BSLASH")]
	private void mBSLASH()
	{
		Enter_BSLASH();
		EnterRule("BSLASH", 108);
		TraceIn("BSLASH", 108);
		try
		{
			// ES3YUITest.g:503:2: ( '\\\\' )
			DebugEnterAlt(1);
			// ES3YUITest.g:503:4: '\\\\'
			{
			DebugLocation(503, 4);
			Match('\\'); 

			}

		}
		finally
		{
			TraceOut("BSLASH", 108);
			LeaveRule("BSLASH", 108);
			Leave_BSLASH();
		}
	}
	// $ANTLR end "BSLASH"

	partial void Enter_DQUOTE();
	partial void Leave_DQUOTE();

	// $ANTLR start "DQUOTE"
	[GrammarRule("DQUOTE")]
	private void mDQUOTE()
	{
		Enter_DQUOTE();
		EnterRule("DQUOTE", 109);
		TraceIn("DQUOTE", 109);
		try
		{
			// ES3YUITest.g:507:2: ( '\"' )
			DebugEnterAlt(1);
			// ES3YUITest.g:507:4: '\"'
			{
			DebugLocation(507, 4);
			Match('\"'); 

			}

		}
		finally
		{
			TraceOut("DQUOTE", 109);
			LeaveRule("DQUOTE", 109);
			Leave_DQUOTE();
		}
	}
	// $ANTLR end "DQUOTE"

	partial void Enter_SQUOTE();
	partial void Leave_SQUOTE();

	// $ANTLR start "SQUOTE"
	[GrammarRule("SQUOTE")]
	private void mSQUOTE()
	{
		Enter_SQUOTE();
		EnterRule("SQUOTE", 110);
		TraceIn("SQUOTE", 110);
		try
		{
			// ES3YUITest.g:511:2: ( '\\'' )
			DebugEnterAlt(1);
			// ES3YUITest.g:511:4: '\\''
			{
			DebugLocation(511, 4);
			Match('\''); 

			}

		}
		finally
		{
			TraceOut("SQUOTE", 110);
			LeaveRule("SQUOTE", 110);
			Leave_SQUOTE();
		}
	}
	// $ANTLR end "SQUOTE"

	partial void Enter_TAB();
	partial void Leave_TAB();

	// $ANTLR start "TAB"
	[GrammarRule("TAB")]
	private void mTAB()
	{
		Enter_TAB();
		EnterRule("TAB", 111);
		TraceIn("TAB", 111);
		try
		{
			// ES3YUITest.g:517:2: ( '\\u0009' )
			DebugEnterAlt(1);
			// ES3YUITest.g:517:4: '\\u0009'
			{
			DebugLocation(517, 4);
			Match('\t'); 

			}

		}
		finally
		{
			TraceOut("TAB", 111);
			LeaveRule("TAB", 111);
			Leave_TAB();
		}
	}
	// $ANTLR end "TAB"

	partial void Enter_VT();
	partial void Leave_VT();

	// $ANTLR start "VT"
	[GrammarRule("VT")]
	private void mVT()
	{
		Enter_VT();
		EnterRule("VT", 112);
		TraceIn("VT", 112);
		try
		{
			// ES3YUITest.g:521:2: ( '\\u000b' )
			DebugEnterAlt(1);
			// ES3YUITest.g:521:4: '\\u000b'
			{
			DebugLocation(521, 4);
			Match('\u000B'); 

			}

		}
		finally
		{
			TraceOut("VT", 112);
			LeaveRule("VT", 112);
			Leave_VT();
		}
	}
	// $ANTLR end "VT"

	partial void Enter_FF();
	partial void Leave_FF();

	// $ANTLR start "FF"
	[GrammarRule("FF")]
	private void mFF()
	{
		Enter_FF();
		EnterRule("FF", 113);
		TraceIn("FF", 113);
		try
		{
			// ES3YUITest.g:525:2: ( '\\u000c' )
			DebugEnterAlt(1);
			// ES3YUITest.g:525:4: '\\u000c'
			{
			DebugLocation(525, 4);
			Match('\f'); 

			}

		}
		finally
		{
			TraceOut("FF", 113);
			LeaveRule("FF", 113);
			Leave_FF();
		}
	}
	// $ANTLR end "FF"

	partial void Enter_SP();
	partial void Leave_SP();

	// $ANTLR start "SP"
	[GrammarRule("SP")]
	private void mSP()
	{
		Enter_SP();
		EnterRule("SP", 114);
		TraceIn("SP", 114);
		try
		{
			// ES3YUITest.g:529:2: ( '\\u0020' )
			DebugEnterAlt(1);
			// ES3YUITest.g:529:4: '\\u0020'
			{
			DebugLocation(529, 4);
			Match(' '); 

			}

		}
		finally
		{
			TraceOut("SP", 114);
			LeaveRule("SP", 114);
			Leave_SP();
		}
	}
	// $ANTLR end "SP"

	partial void Enter_NBSP();
	partial void Leave_NBSP();

	// $ANTLR start "NBSP"
	[GrammarRule("NBSP")]
	private void mNBSP()
	{
		Enter_NBSP();
		EnterRule("NBSP", 115);
		TraceIn("NBSP", 115);
		try
		{
			// ES3YUITest.g:533:2: ( '\\u00a0' )
			DebugEnterAlt(1);
			// ES3YUITest.g:533:4: '\\u00a0'
			{
			DebugLocation(533, 4);
			Match('\u00A0'); 

			}

		}
		finally
		{
			TraceOut("NBSP", 115);
			LeaveRule("NBSP", 115);
			Leave_NBSP();
		}
	}
	// $ANTLR end "NBSP"

	partial void Enter_USP();
	partial void Leave_USP();

	// $ANTLR start "USP"
	[GrammarRule("USP")]
	private void mUSP()
	{
		Enter_USP();
		EnterRule("USP", 116);
		TraceIn("USP", 116);
		try
		{
			// ES3YUITest.g:537:2: ( '\\u1680' | '\\u180E' | '\\u2000' | '\\u2001' | '\\u2002' | '\\u2003' | '\\u2004' | '\\u2005' | '\\u2006' | '\\u2007' | '\\u2008' | '\\u2009' | '\\u200A' | '\\u202F' | '\\u205F' | '\\u3000' )
			DebugEnterAlt(1);
			// ES3YUITest.g:
			{
			DebugLocation(537, 2);
			if (input.LA(1)=='\u1680'||input.LA(1)=='\u180E'||(input.LA(1)>='\u2000' && input.LA(1)<='\u200A')||input.LA(1)=='\u202F'||input.LA(1)=='\u205F'||input.LA(1)=='\u3000')
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("USP", 116);
			LeaveRule("USP", 116);
			Leave_USP();
		}
	}
	// $ANTLR end "USP"

	partial void Enter_WhiteSpace();
	partial void Leave_WhiteSpace();

	// $ANTLR start "WhiteSpace"
	[GrammarRule("WhiteSpace")]
	private void mWhiteSpace()
	{
		Enter_WhiteSpace();
		EnterRule("WhiteSpace", 117);
		TraceIn("WhiteSpace", 117);
		try
		{
			int _type = WhiteSpace;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:556:2: ( ( TAB | VT | FF | SP | NBSP | USP )+ )
			DebugEnterAlt(1);
			// ES3YUITest.g:556:4: ( TAB | VT | FF | SP | NBSP | USP )+
			{
			DebugLocation(556, 4);
			// ES3YUITest.g:556:4: ( TAB | VT | FF | SP | NBSP | USP )+
			int cnt1=0;
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, decisionCanBacktrack[1]);
				int LA1_0 = input.LA(1);

				if ((LA1_0=='\t'||(LA1_0>='\u000B' && LA1_0<='\f')||LA1_0==' '||LA1_0=='\u00A0'||LA1_0=='\u1680'||LA1_0=='\u180E'||(LA1_0>='\u2000' && LA1_0<='\u200A')||LA1_0=='\u202F'||LA1_0=='\u205F'||LA1_0=='\u3000'))
				{
					alt1=1;
				}


				} finally { DebugExitDecision(1); }
				switch (alt1)
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:
					{
					DebugLocation(556, 4);
					if (input.LA(1)=='\t'||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||input.LA(1)==' '||input.LA(1)=='\u00A0'||input.LA(1)=='\u1680'||input.LA(1)=='\u180E'||(input.LA(1)>='\u2000' && input.LA(1)<='\u200A')||input.LA(1)=='\u202F'||input.LA(1)=='\u205F'||input.LA(1)=='\u3000')
					{
						input.Consume();

					}
					else
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						Recover(mse);
						throw mse;}


					}
					break;

				default:
					if (cnt1 >= 1)
						goto loop1;

					EarlyExitException eee1 = new EarlyExitException( 1, input );
					DebugRecognitionException(eee1);
					throw eee1;
				}
				cnt1++;
			}
			loop1:
				;

			} finally { DebugExitSubRule(1); }

			DebugLocation(556, 41);
			 _channel = TokenChannels.Hidden; 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WhiteSpace", 117);
			LeaveRule("WhiteSpace", 117);
			Leave_WhiteSpace();
		}
	}
	// $ANTLR end "WhiteSpace"

	partial void Enter_LF();
	partial void Leave_LF();

	// $ANTLR start "LF"
	[GrammarRule("LF")]
	private void mLF()
	{
		Enter_LF();
		EnterRule("LF", 118);
		TraceIn("LF", 118);
		try
		{
			// ES3YUITest.g:564:2: ( '\\n' )
			DebugEnterAlt(1);
			// ES3YUITest.g:564:4: '\\n'
			{
			DebugLocation(564, 4);
			Match('\n'); 

			}

		}
		finally
		{
			TraceOut("LF", 118);
			LeaveRule("LF", 118);
			Leave_LF();
		}
	}
	// $ANTLR end "LF"

	partial void Enter_CR();
	partial void Leave_CR();

	// $ANTLR start "CR"
	[GrammarRule("CR")]
	private void mCR()
	{
		Enter_CR();
		EnterRule("CR", 119);
		TraceIn("CR", 119);
		try
		{
			// ES3YUITest.g:568:2: ( '\\r' )
			DebugEnterAlt(1);
			// ES3YUITest.g:568:4: '\\r'
			{
			DebugLocation(568, 4);
			Match('\r'); 

			}

		}
		finally
		{
			TraceOut("CR", 119);
			LeaveRule("CR", 119);
			Leave_CR();
		}
	}
	// $ANTLR end "CR"

	partial void Enter_LS();
	partial void Leave_LS();

	// $ANTLR start "LS"
	[GrammarRule("LS")]
	private void mLS()
	{
		Enter_LS();
		EnterRule("LS", 120);
		TraceIn("LS", 120);
		try
		{
			// ES3YUITest.g:572:2: ( '\\u2028' )
			DebugEnterAlt(1);
			// ES3YUITest.g:572:4: '\\u2028'
			{
			DebugLocation(572, 4);
			Match('\u2028'); 

			}

		}
		finally
		{
			TraceOut("LS", 120);
			LeaveRule("LS", 120);
			Leave_LS();
		}
	}
	// $ANTLR end "LS"

	partial void Enter_PS();
	partial void Leave_PS();

	// $ANTLR start "PS"
	[GrammarRule("PS")]
	private void mPS()
	{
		Enter_PS();
		EnterRule("PS", 121);
		TraceIn("PS", 121);
		try
		{
			// ES3YUITest.g:576:2: ( '\\u2029' )
			DebugEnterAlt(1);
			// ES3YUITest.g:576:4: '\\u2029'
			{
			DebugLocation(576, 4);
			Match('\u2029'); 

			}

		}
		finally
		{
			TraceOut("PS", 121);
			LeaveRule("PS", 121);
			Leave_PS();
		}
	}
	// $ANTLR end "PS"

	partial void Enter_LineTerminator();
	partial void Leave_LineTerminator();

	// $ANTLR start "LineTerminator"
	[GrammarRule("LineTerminator")]
	private void mLineTerminator()
	{
		Enter_LineTerminator();
		EnterRule("LineTerminator", 122);
		TraceIn("LineTerminator", 122);
		try
		{
			// ES3YUITest.g:580:2: ( CR | LF | LS | PS )
			DebugEnterAlt(1);
			// ES3YUITest.g:
			{
			DebugLocation(580, 2);
			if (input.LA(1)=='\n'||input.LA(1)=='\r'||(input.LA(1)>='\u2028' && input.LA(1)<='\u2029'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("LineTerminator", 122);
			LeaveRule("LineTerminator", 122);
			Leave_LineTerminator();
		}
	}
	// $ANTLR end "LineTerminator"

	partial void Enter_EOL();
	partial void Leave_EOL();

	// $ANTLR start "EOL"
	[GrammarRule("EOL")]
	private void mEOL()
	{
		Enter_EOL();
		EnterRule("EOL", 123);
		TraceIn("EOL", 123);
		try
		{
			int _type = EOL;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:584:2: ( ( ( CR ( LF )? ) | LF | LS | PS ) )
			DebugEnterAlt(1);
			// ES3YUITest.g:584:4: ( ( CR ( LF )? ) | LF | LS | PS )
			{
			DebugLocation(584, 4);
			// ES3YUITest.g:584:4: ( ( CR ( LF )? ) | LF | LS | PS )
			int alt3=4;
			try { DebugEnterSubRule(3);
			try { DebugEnterDecision(3, decisionCanBacktrack[3]);
			switch (input.LA(1))
			{
			case '\r':
				{
				alt3=1;
				}
				break;
			case '\n':
				{
				alt3=2;
				}
				break;
			case '\u2028':
				{
				alt3=3;
				}
				break;
			case '\u2029':
				{
				alt3=4;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 3, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(3); }
			switch (alt3)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:584:6: ( CR ( LF )? )
				{
				DebugLocation(584, 6);
				// ES3YUITest.g:584:6: ( CR ( LF )? )
				DebugEnterAlt(1);
				// ES3YUITest.g:584:8: CR ( LF )?
				{
				DebugLocation(584, 8);
				mCR(); 
				DebugLocation(584, 11);
				// ES3YUITest.g:584:11: ( LF )?
				int alt2=2;
				try { DebugEnterSubRule(2);
				try { DebugEnterDecision(2, decisionCanBacktrack[2]);
				int LA2_0 = input.LA(1);

				if ((LA2_0=='\n'))
				{
					alt2=1;
				}
				} finally { DebugExitDecision(2); }
				switch (alt2)
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:584:11: LF
					{
					DebugLocation(584, 11);
					mLF(); 

					}
					break;

				}
				} finally { DebugExitSubRule(2); }


				}


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ES3YUITest.g:584:19: LF
				{
				DebugLocation(584, 19);
				mLF(); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// ES3YUITest.g:584:24: LS
				{
				DebugLocation(584, 24);
				mLS(); 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// ES3YUITest.g:584:29: PS
				{
				DebugLocation(584, 29);
				mPS(); 

				}
				break;

			}
			} finally { DebugExitSubRule(3); }

			DebugLocation(584, 34);
			 _channel = TokenChannels.Hidden; 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("EOL", 123);
			LeaveRule("EOL", 123);
			Leave_EOL();
		}
	}
	// $ANTLR end "EOL"

	partial void Enter_MultiLineComment();
	partial void Leave_MultiLineComment();

	// $ANTLR start "MultiLineComment"
	[GrammarRule("MultiLineComment")]
	private void mMultiLineComment()
	{
		Enter_MultiLineComment();
		EnterRule("MultiLineComment", 124);
		TraceIn("MultiLineComment", 124);
		try
		{
			int _type = MultiLineComment;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:591:2: ( '/*' ( options {greedy=false; } : . )* '*/' )
			DebugEnterAlt(1);
			// ES3YUITest.g:591:4: '/*' ( options {greedy=false; } : . )* '*/'
			{
			DebugLocation(591, 4);
			Match("/*"); 

			DebugLocation(591, 9);
			// ES3YUITest.g:591:9: ( options {greedy=false; } : . )*
			try { DebugEnterSubRule(4);
			while (true)
			{
				int alt4=2;
				try { DebugEnterDecision(4, decisionCanBacktrack[4]);
				int LA4_0 = input.LA(1);

				if ((LA4_0=='*'))
				{
					int LA4_1 = input.LA(2);

					if ((LA4_1=='/'))
					{
						alt4=2;
					}
					else if (((LA4_1>='\u0000' && LA4_1<='.')||(LA4_1>='0' && LA4_1<='\uFFFF')))
					{
						alt4=1;
					}


				}
				else if (((LA4_0>='\u0000' && LA4_0<=')')||(LA4_0>='+' && LA4_0<='\uFFFF')))
				{
					alt4=1;
				}


				} finally { DebugExitDecision(4); }
				switch ( alt4 )
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:591:41: .
					{
					DebugLocation(591, 41);
					MatchAny(); 

					}
					break;

				default:
					goto loop4;
				}
			}

			loop4:
				;

			} finally { DebugExitSubRule(4); }

			DebugLocation(591, 46);
			Match("*/"); 

			DebugLocation(591, 51);
			 _channel = TokenChannels.Hidden; 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("MultiLineComment", 124);
			LeaveRule("MultiLineComment", 124);
			Leave_MultiLineComment();
		}
	}
	// $ANTLR end "MultiLineComment"

	partial void Enter_SingleLineComment();
	partial void Leave_SingleLineComment();

	// $ANTLR start "SingleLineComment"
	[GrammarRule("SingleLineComment")]
	private void mSingleLineComment()
	{
		Enter_SingleLineComment();
		EnterRule("SingleLineComment", 125);
		TraceIn("SingleLineComment", 125);
		try
		{
			int _type = SingleLineComment;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:595:2: ( '//' (~ ( LineTerminator ) )* )
			DebugEnterAlt(1);
			// ES3YUITest.g:595:4: '//' (~ ( LineTerminator ) )*
			{
			DebugLocation(595, 4);
			Match("//"); 

			DebugLocation(595, 9);
			// ES3YUITest.g:595:9: (~ ( LineTerminator ) )*
			try { DebugEnterSubRule(5);
			while (true)
			{
				int alt5=2;
				try { DebugEnterDecision(5, decisionCanBacktrack[5]);
				int LA5_0 = input.LA(1);

				if (((LA5_0>='\u0000' && LA5_0<='\t')||(LA5_0>='\u000B' && LA5_0<='\f')||(LA5_0>='\u000E' && LA5_0<='\u2027')||(LA5_0>='\u202A' && LA5_0<='\uFFFF')))
				{
					alt5=1;
				}


				} finally { DebugExitDecision(5); }
				switch ( alt5 )
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:595:11: ~ ( LineTerminator )
					{
					DebugLocation(595, 11);
					if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<='\u2027')||(input.LA(1)>='\u202A' && input.LA(1)<='\uFFFF'))
					{
						input.Consume();

					}
					else
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						Recover(mse);
						throw mse;}


					}
					break;

				default:
					goto loop5;
				}
			}

			loop5:
				;

			} finally { DebugExitSubRule(5); }

			DebugLocation(595, 34);
			 _channel = TokenChannels.Hidden; 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SingleLineComment", 125);
			LeaveRule("SingleLineComment", 125);
			Leave_SingleLineComment();
		}
	}
	// $ANTLR end "SingleLineComment"

	partial void Enter_IdentifierStartASCII();
	partial void Leave_IdentifierStartASCII();

	// $ANTLR start "IdentifierStartASCII"
	[GrammarRule("IdentifierStartASCII")]
	private void mIdentifierStartASCII()
	{
		Enter_IdentifierStartASCII();
		EnterRule("IdentifierStartASCII", 126);
		TraceIn("IdentifierStartASCII", 126);
		try
		{
			// ES3YUITest.g:696:2: ( 'a' .. 'z' | 'A' .. 'Z' | '$' | '_' | BSLASH 'u' HexDigit HexDigit HexDigit HexDigit )
			int alt6=5;
			try { DebugEnterDecision(6, decisionCanBacktrack[6]);
			switch (input.LA(1))
			{
			case 'a':
			case 'b':
			case 'c':
			case 'd':
			case 'e':
			case 'f':
			case 'g':
			case 'h':
			case 'i':
			case 'j':
			case 'k':
			case 'l':
			case 'm':
			case 'n':
			case 'o':
			case 'p':
			case 'q':
			case 'r':
			case 's':
			case 't':
			case 'u':
			case 'v':
			case 'w':
			case 'x':
			case 'y':
			case 'z':
				{
				alt6=1;
				}
				break;
			case 'A':
			case 'B':
			case 'C':
			case 'D':
			case 'E':
			case 'F':
			case 'G':
			case 'H':
			case 'I':
			case 'J':
			case 'K':
			case 'L':
			case 'M':
			case 'N':
			case 'O':
			case 'P':
			case 'Q':
			case 'R':
			case 'S':
			case 'T':
			case 'U':
			case 'V':
			case 'W':
			case 'X':
			case 'Y':
			case 'Z':
				{
				alt6=2;
				}
				break;
			case '$':
				{
				alt6=3;
				}
				break;
			case '_':
				{
				alt6=4;
				}
				break;
			case '\\':
				{
				alt6=5;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 6, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(6); }
			switch (alt6)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:696:4: 'a' .. 'z'
				{
				DebugLocation(696, 4);
				MatchRange('a','z'); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ES3YUITest.g:696:15: 'A' .. 'Z'
				{
				DebugLocation(696, 15);
				MatchRange('A','Z'); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// ES3YUITest.g:697:4: '$'
				{
				DebugLocation(697, 4);
				Match('$'); 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// ES3YUITest.g:698:4: '_'
				{
				DebugLocation(698, 4);
				Match('_'); 

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// ES3YUITest.g:699:4: BSLASH 'u' HexDigit HexDigit HexDigit HexDigit
				{
				DebugLocation(699, 4);
				mBSLASH(); 
				DebugLocation(699, 11);
				Match('u'); 
				DebugLocation(699, 15);
				mHexDigit(); 
				DebugLocation(699, 24);
				mHexDigit(); 
				DebugLocation(699, 33);
				mHexDigit(); 
				DebugLocation(699, 42);
				mHexDigit(); 

				}
				break;

			}
		}
		finally
		{
			TraceOut("IdentifierStartASCII", 126);
			LeaveRule("IdentifierStartASCII", 126);
			Leave_IdentifierStartASCII();
		}
	}
	// $ANTLR end "IdentifierStartASCII"

	partial void Enter_IdentifierPart();
	partial void Leave_IdentifierPart();

	// $ANTLR start "IdentifierPart"
	[GrammarRule("IdentifierPart")]
	private void mIdentifierPart()
	{
		Enter_IdentifierPart();
		EnterRule("IdentifierPart", 127);
		TraceIn("IdentifierPart", 127);
		try
		{
			// ES3YUITest.g:707:2: ( DecimalDigit | IdentifierStartASCII | {...}?)
			int alt7=3;
			try { DebugEnterDecision(7, decisionCanBacktrack[7]);
			switch (input.LA(1))
			{
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				{
				alt7=1;
				}
				break;
			case '$':
			case 'A':
			case 'B':
			case 'C':
			case 'D':
			case 'E':
			case 'F':
			case 'G':
			case 'H':
			case 'I':
			case 'J':
			case 'K':
			case 'L':
			case 'M':
			case 'N':
			case 'O':
			case 'P':
			case 'Q':
			case 'R':
			case 'S':
			case 'T':
			case 'U':
			case 'V':
			case 'W':
			case 'X':
			case 'Y':
			case 'Z':
			case '\\':
			case '_':
			case 'a':
			case 'b':
			case 'c':
			case 'd':
			case 'e':
			case 'f':
			case 'g':
			case 'h':
			case 'i':
			case 'j':
			case 'k':
			case 'l':
			case 'm':
			case 'n':
			case 'o':
			case 'p':
			case 'q':
			case 'r':
			case 's':
			case 't':
			case 'u':
			case 'v':
			case 'w':
			case 'x':
			case 'y':
			case 'z':
				{
				alt7=2;
				}
				break;
			default:
				alt7=3;
				break;
			}

			} finally { DebugExitDecision(7); }
			switch (alt7)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:707:4: DecimalDigit
				{
				DebugLocation(707, 4);
				mDecimalDigit(); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ES3YUITest.g:708:4: IdentifierStartASCII
				{
				DebugLocation(708, 4);
				mIdentifierStartASCII(); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// ES3YUITest.g:709:4: {...}?
				{
				DebugLocation(709, 4);
				if (!(( IsIdentifierPartUnicode(input.LA(1)) )))
				{
					throw new FailedPredicateException(input, "IdentifierPart", " IsIdentifierPartUnicode(input.LA(1)) ");
				}
				DebugLocation(709, 46);
				 MatchAny(); 

				}
				break;

			}
		}
		finally
		{
			TraceOut("IdentifierPart", 127);
			LeaveRule("IdentifierPart", 127);
			Leave_IdentifierPart();
		}
	}
	// $ANTLR end "IdentifierPart"

	partial void Enter_IdentifierNameASCIIStart();
	partial void Leave_IdentifierNameASCIIStart();

	// $ANTLR start "IdentifierNameASCIIStart"
	[GrammarRule("IdentifierNameASCIIStart")]
	private void mIdentifierNameASCIIStart()
	{
		Enter_IdentifierNameASCIIStart();
		EnterRule("IdentifierNameASCIIStart", 128);
		TraceIn("IdentifierNameASCIIStart", 128);
		try
		{
			// ES3YUITest.g:713:2: ( IdentifierStartASCII ( IdentifierPart )* )
			DebugEnterAlt(1);
			// ES3YUITest.g:713:4: IdentifierStartASCII ( IdentifierPart )*
			{
			DebugLocation(713, 4);
			mIdentifierStartASCII(); 
			DebugLocation(713, 25);
			// ES3YUITest.g:713:25: ( IdentifierPart )*
			try { DebugEnterSubRule(8);
			while (true)
			{
				int alt8=2;
				try { DebugEnterDecision(8, decisionCanBacktrack[8]);
				int LA8_0 = input.LA(1);

				if ((LA8_0=='$'||(LA8_0>='0' && LA8_0<='9')||(LA8_0>='A' && LA8_0<='Z')||LA8_0=='\\'||LA8_0=='_'||(LA8_0>='a' && LA8_0<='z')))
				{
					alt8=1;
				}
				else if ((( IsIdentifierPartUnicode(input.LA(1)) )))
				{
					alt8=1;
				}


				} finally { DebugExitDecision(8); }
				switch ( alt8 )
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:713:25: IdentifierPart
					{
					DebugLocation(713, 25);
					mIdentifierPart(); 

					}
					break;

				default:
					goto loop8;
				}
			}

			loop8:
				;

			} finally { DebugExitSubRule(8); }


			}

		}
		finally
		{
			TraceOut("IdentifierNameASCIIStart", 128);
			LeaveRule("IdentifierNameASCIIStart", 128);
			Leave_IdentifierNameASCIIStart();
		}
	}
	// $ANTLR end "IdentifierNameASCIIStart"

	partial void Enter_Identifier();
	partial void Leave_Identifier();

	// $ANTLR start "Identifier"
	[GrammarRule("Identifier")]
	private void mIdentifier()
	{
		Enter_Identifier();
		EnterRule("Identifier", 129);
		TraceIn("Identifier", 129);
		try
		{
			int _type = Identifier;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:725:2: ( IdentifierNameASCIIStart | )
			int alt9=2;
			try { DebugEnterDecision(9, decisionCanBacktrack[9]);
			int LA9_0 = input.LA(1);

			if ((LA9_0=='$'||(LA9_0>='A' && LA9_0<='Z')||LA9_0=='\\'||LA9_0=='_'||(LA9_0>='a' && LA9_0<='z')))
			{
				alt9=1;
			}
			else
			{
				alt9=2;}
			} finally { DebugExitDecision(9); }
			switch (alt9)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:725:4: IdentifierNameASCIIStart
				{
				DebugLocation(725, 4);
				mIdentifierNameASCIIStart(); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ES3YUITest.g:726:4: 
				{
				DebugLocation(726, 4);
				 ConsumeIdentifierUnicodeStart(); 

				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("Identifier", 129);
			LeaveRule("Identifier", 129);
			Leave_Identifier();
		}
	}
	// $ANTLR end "Identifier"

	partial void Enter_DecimalDigit();
	partial void Leave_DecimalDigit();

	// $ANTLR start "DecimalDigit"
	[GrammarRule("DecimalDigit")]
	private void mDecimalDigit()
	{
		Enter_DecimalDigit();
		EnterRule("DecimalDigit", 130);
		TraceIn("DecimalDigit", 130);
		try
		{
			// ES3YUITest.g:809:2: ( '0' .. '9' )
			DebugEnterAlt(1);
			// ES3YUITest.g:809:4: '0' .. '9'
			{
			DebugLocation(809, 4);
			MatchRange('0','9'); 

			}

		}
		finally
		{
			TraceOut("DecimalDigit", 130);
			LeaveRule("DecimalDigit", 130);
			Leave_DecimalDigit();
		}
	}
	// $ANTLR end "DecimalDigit"

	partial void Enter_HexDigit();
	partial void Leave_HexDigit();

	// $ANTLR start "HexDigit"
	[GrammarRule("HexDigit")]
	private void mHexDigit()
	{
		Enter_HexDigit();
		EnterRule("HexDigit", 131);
		TraceIn("HexDigit", 131);
		try
		{
			// ES3YUITest.g:813:2: ( DecimalDigit | 'a' .. 'f' | 'A' .. 'F' )
			DebugEnterAlt(1);
			// ES3YUITest.g:
			{
			DebugLocation(813, 2);
			if ((input.LA(1)>='0' && input.LA(1)<='9')||(input.LA(1)>='A' && input.LA(1)<='F')||(input.LA(1)>='a' && input.LA(1)<='f'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("HexDigit", 131);
			LeaveRule("HexDigit", 131);
			Leave_HexDigit();
		}
	}
	// $ANTLR end "HexDigit"

	partial void Enter_OctalDigit();
	partial void Leave_OctalDigit();

	// $ANTLR start "OctalDigit"
	[GrammarRule("OctalDigit")]
	private void mOctalDigit()
	{
		Enter_OctalDigit();
		EnterRule("OctalDigit", 132);
		TraceIn("OctalDigit", 132);
		try
		{
			// ES3YUITest.g:817:2: ( '0' .. '7' )
			DebugEnterAlt(1);
			// ES3YUITest.g:817:4: '0' .. '7'
			{
			DebugLocation(817, 4);
			MatchRange('0','7'); 

			}

		}
		finally
		{
			TraceOut("OctalDigit", 132);
			LeaveRule("OctalDigit", 132);
			Leave_OctalDigit();
		}
	}
	// $ANTLR end "OctalDigit"

	partial void Enter_ExponentPart();
	partial void Leave_ExponentPart();

	// $ANTLR start "ExponentPart"
	[GrammarRule("ExponentPart")]
	private void mExponentPart()
	{
		Enter_ExponentPart();
		EnterRule("ExponentPart", 133);
		TraceIn("ExponentPart", 133);
		try
		{
			// ES3YUITest.g:821:2: ( ( 'e' | 'E' ) ( '+' | '-' )? ( DecimalDigit )+ )
			DebugEnterAlt(1);
			// ES3YUITest.g:821:4: ( 'e' | 'E' ) ( '+' | '-' )? ( DecimalDigit )+
			{
			DebugLocation(821, 4);
			if (input.LA(1)=='E'||input.LA(1)=='e')
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}

			DebugLocation(821, 18);
			// ES3YUITest.g:821:18: ( '+' | '-' )?
			int alt10=2;
			try { DebugEnterSubRule(10);
			try { DebugEnterDecision(10, decisionCanBacktrack[10]);
			int LA10_0 = input.LA(1);

			if ((LA10_0=='+'||LA10_0=='-'))
			{
				alt10=1;
			}
			} finally { DebugExitDecision(10); }
			switch (alt10)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:
				{
				DebugLocation(821, 18);
				if (input.LA(1)=='+'||input.LA(1)=='-')
				{
					input.Consume();

				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					DebugRecognitionException(mse);
					Recover(mse);
					throw mse;}


				}
				break;

			}
			} finally { DebugExitSubRule(10); }

			DebugLocation(821, 33);
			// ES3YUITest.g:821:33: ( DecimalDigit )+
			int cnt11=0;
			try { DebugEnterSubRule(11);
			while (true)
			{
				int alt11=2;
				try { DebugEnterDecision(11, decisionCanBacktrack[11]);
				int LA11_0 = input.LA(1);

				if (((LA11_0>='0' && LA11_0<='9')))
				{
					alt11=1;
				}


				} finally { DebugExitDecision(11); }
				switch (alt11)
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:821:33: DecimalDigit
					{
					DebugLocation(821, 33);
					mDecimalDigit(); 

					}
					break;

				default:
					if (cnt11 >= 1)
						goto loop11;

					EarlyExitException eee11 = new EarlyExitException( 11, input );
					DebugRecognitionException(eee11);
					throw eee11;
				}
				cnt11++;
			}
			loop11:
				;

			} finally { DebugExitSubRule(11); }


			}

		}
		finally
		{
			TraceOut("ExponentPart", 133);
			LeaveRule("ExponentPart", 133);
			Leave_ExponentPart();
		}
	}
	// $ANTLR end "ExponentPart"

	partial void Enter_DecimalIntegerLiteral();
	partial void Leave_DecimalIntegerLiteral();

	// $ANTLR start "DecimalIntegerLiteral"
	[GrammarRule("DecimalIntegerLiteral")]
	private void mDecimalIntegerLiteral()
	{
		Enter_DecimalIntegerLiteral();
		EnterRule("DecimalIntegerLiteral", 134);
		TraceIn("DecimalIntegerLiteral", 134);
		try
		{
			// ES3YUITest.g:825:2: ( '0' | '1' .. '9' ( DecimalDigit )* )
			int alt13=2;
			try { DebugEnterDecision(13, decisionCanBacktrack[13]);
			int LA13_0 = input.LA(1);

			if ((LA13_0=='0'))
			{
				alt13=1;
			}
			else if (((LA13_0>='1' && LA13_0<='9')))
			{
				alt13=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 13, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(13); }
			switch (alt13)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:825:4: '0'
				{
				DebugLocation(825, 4);
				Match('0'); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ES3YUITest.g:826:4: '1' .. '9' ( DecimalDigit )*
				{
				DebugLocation(826, 4);
				MatchRange('1','9'); 
				DebugLocation(826, 13);
				// ES3YUITest.g:826:13: ( DecimalDigit )*
				try { DebugEnterSubRule(12);
				while (true)
				{
					int alt12=2;
					try { DebugEnterDecision(12, decisionCanBacktrack[12]);
					int LA12_0 = input.LA(1);

					if (((LA12_0>='0' && LA12_0<='9')))
					{
						alt12=1;
					}


					} finally { DebugExitDecision(12); }
					switch ( alt12 )
					{
					case 1:
						DebugEnterAlt(1);
						// ES3YUITest.g:826:13: DecimalDigit
						{
						DebugLocation(826, 13);
						mDecimalDigit(); 

						}
						break;

					default:
						goto loop12;
					}
				}

				loop12:
					;

				} finally { DebugExitSubRule(12); }


				}
				break;

			}
		}
		finally
		{
			TraceOut("DecimalIntegerLiteral", 134);
			LeaveRule("DecimalIntegerLiteral", 134);
			Leave_DecimalIntegerLiteral();
		}
	}
	// $ANTLR end "DecimalIntegerLiteral"

	partial void Enter_DecimalLiteral();
	partial void Leave_DecimalLiteral();

	// $ANTLR start "DecimalLiteral"
	[GrammarRule("DecimalLiteral")]
	private void mDecimalLiteral()
	{
		Enter_DecimalLiteral();
		EnterRule("DecimalLiteral", 135);
		TraceIn("DecimalLiteral", 135);
		try
		{
			int _type = DecimalLiteral;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:830:2: ( DecimalIntegerLiteral '.' ( DecimalDigit )* ( ExponentPart )? | '.' ( DecimalDigit )+ ( ExponentPart )? | DecimalIntegerLiteral ( ExponentPart )? )
			int alt19=3;
			try { DebugEnterDecision(19, decisionCanBacktrack[19]);
			try
			{
				alt19 = dfa19.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(19); }
			switch (alt19)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:830:4: DecimalIntegerLiteral '.' ( DecimalDigit )* ( ExponentPart )?
				{
				DebugLocation(830, 4);
				mDecimalIntegerLiteral(); 
				DebugLocation(830, 26);
				Match('.'); 
				DebugLocation(830, 30);
				// ES3YUITest.g:830:30: ( DecimalDigit )*
				try { DebugEnterSubRule(14);
				while (true)
				{
					int alt14=2;
					try { DebugEnterDecision(14, decisionCanBacktrack[14]);
					int LA14_0 = input.LA(1);

					if (((LA14_0>='0' && LA14_0<='9')))
					{
						alt14=1;
					}


					} finally { DebugExitDecision(14); }
					switch ( alt14 )
					{
					case 1:
						DebugEnterAlt(1);
						// ES3YUITest.g:830:30: DecimalDigit
						{
						DebugLocation(830, 30);
						mDecimalDigit(); 

						}
						break;

					default:
						goto loop14;
					}
				}

				loop14:
					;

				} finally { DebugExitSubRule(14); }

				DebugLocation(830, 44);
				// ES3YUITest.g:830:44: ( ExponentPart )?
				int alt15=2;
				try { DebugEnterSubRule(15);
				try { DebugEnterDecision(15, decisionCanBacktrack[15]);
				int LA15_0 = input.LA(1);

				if ((LA15_0=='E'||LA15_0=='e'))
				{
					alt15=1;
				}
				} finally { DebugExitDecision(15); }
				switch (alt15)
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:830:44: ExponentPart
					{
					DebugLocation(830, 44);
					mExponentPart(); 

					}
					break;

				}
				} finally { DebugExitSubRule(15); }


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ES3YUITest.g:831:4: '.' ( DecimalDigit )+ ( ExponentPart )?
				{
				DebugLocation(831, 4);
				Match('.'); 
				DebugLocation(831, 8);
				// ES3YUITest.g:831:8: ( DecimalDigit )+
				int cnt16=0;
				try { DebugEnterSubRule(16);
				while (true)
				{
					int alt16=2;
					try { DebugEnterDecision(16, decisionCanBacktrack[16]);
					int LA16_0 = input.LA(1);

					if (((LA16_0>='0' && LA16_0<='9')))
					{
						alt16=1;
					}


					} finally { DebugExitDecision(16); }
					switch (alt16)
					{
					case 1:
						DebugEnterAlt(1);
						// ES3YUITest.g:831:8: DecimalDigit
						{
						DebugLocation(831, 8);
						mDecimalDigit(); 

						}
						break;

					default:
						if (cnt16 >= 1)
							goto loop16;

						EarlyExitException eee16 = new EarlyExitException( 16, input );
						DebugRecognitionException(eee16);
						throw eee16;
					}
					cnt16++;
				}
				loop16:
					;

				} finally { DebugExitSubRule(16); }

				DebugLocation(831, 22);
				// ES3YUITest.g:831:22: ( ExponentPart )?
				int alt17=2;
				try { DebugEnterSubRule(17);
				try { DebugEnterDecision(17, decisionCanBacktrack[17]);
				int LA17_0 = input.LA(1);

				if ((LA17_0=='E'||LA17_0=='e'))
				{
					alt17=1;
				}
				} finally { DebugExitDecision(17); }
				switch (alt17)
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:831:22: ExponentPart
					{
					DebugLocation(831, 22);
					mExponentPart(); 

					}
					break;

				}
				} finally { DebugExitSubRule(17); }


				}
				break;
			case 3:
				DebugEnterAlt(3);
				// ES3YUITest.g:832:4: DecimalIntegerLiteral ( ExponentPart )?
				{
				DebugLocation(832, 4);
				mDecimalIntegerLiteral(); 
				DebugLocation(832, 26);
				// ES3YUITest.g:832:26: ( ExponentPart )?
				int alt18=2;
				try { DebugEnterSubRule(18);
				try { DebugEnterDecision(18, decisionCanBacktrack[18]);
				int LA18_0 = input.LA(1);

				if ((LA18_0=='E'||LA18_0=='e'))
				{
					alt18=1;
				}
				} finally { DebugExitDecision(18); }
				switch (alt18)
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:832:26: ExponentPart
					{
					DebugLocation(832, 26);
					mExponentPart(); 

					}
					break;

				}
				} finally { DebugExitSubRule(18); }


				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DecimalLiteral", 135);
			LeaveRule("DecimalLiteral", 135);
			Leave_DecimalLiteral();
		}
	}
	// $ANTLR end "DecimalLiteral"

	partial void Enter_OctalIntegerLiteral();
	partial void Leave_OctalIntegerLiteral();

	// $ANTLR start "OctalIntegerLiteral"
	[GrammarRule("OctalIntegerLiteral")]
	private void mOctalIntegerLiteral()
	{
		Enter_OctalIntegerLiteral();
		EnterRule("OctalIntegerLiteral", 136);
		TraceIn("OctalIntegerLiteral", 136);
		try
		{
			int _type = OctalIntegerLiteral;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:836:2: ( '0' ( OctalDigit )+ )
			DebugEnterAlt(1);
			// ES3YUITest.g:836:4: '0' ( OctalDigit )+
			{
			DebugLocation(836, 4);
			Match('0'); 
			DebugLocation(836, 8);
			// ES3YUITest.g:836:8: ( OctalDigit )+
			int cnt20=0;
			try { DebugEnterSubRule(20);
			while (true)
			{
				int alt20=2;
				try { DebugEnterDecision(20, decisionCanBacktrack[20]);
				int LA20_0 = input.LA(1);

				if (((LA20_0>='0' && LA20_0<='7')))
				{
					alt20=1;
				}


				} finally { DebugExitDecision(20); }
				switch (alt20)
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:836:8: OctalDigit
					{
					DebugLocation(836, 8);
					mOctalDigit(); 

					}
					break;

				default:
					if (cnt20 >= 1)
						goto loop20;

					EarlyExitException eee20 = new EarlyExitException( 20, input );
					DebugRecognitionException(eee20);
					throw eee20;
				}
				cnt20++;
			}
			loop20:
				;

			} finally { DebugExitSubRule(20); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("OctalIntegerLiteral", 136);
			LeaveRule("OctalIntegerLiteral", 136);
			Leave_OctalIntegerLiteral();
		}
	}
	// $ANTLR end "OctalIntegerLiteral"

	partial void Enter_HexIntegerLiteral();
	partial void Leave_HexIntegerLiteral();

	// $ANTLR start "HexIntegerLiteral"
	[GrammarRule("HexIntegerLiteral")]
	private void mHexIntegerLiteral()
	{
		Enter_HexIntegerLiteral();
		EnterRule("HexIntegerLiteral", 137);
		TraceIn("HexIntegerLiteral", 137);
		try
		{
			int _type = HexIntegerLiteral;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:840:2: ( ( '0x' | '0X' ) ( HexDigit )+ )
			DebugEnterAlt(1);
			// ES3YUITest.g:840:4: ( '0x' | '0X' ) ( HexDigit )+
			{
			DebugLocation(840, 4);
			// ES3YUITest.g:840:4: ( '0x' | '0X' )
			int alt21=2;
			try { DebugEnterSubRule(21);
			try { DebugEnterDecision(21, decisionCanBacktrack[21]);
			int LA21_0 = input.LA(1);

			if ((LA21_0=='0'))
			{
				int LA21_1 = input.LA(2);

				if ((LA21_1=='x'))
				{
					alt21=1;
				}
				else if ((LA21_1=='X'))
				{
					alt21=2;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 21, 1, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 21, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(21); }
			switch (alt21)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:840:6: '0x'
				{
				DebugLocation(840, 6);
				Match("0x"); 


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ES3YUITest.g:840:13: '0X'
				{
				DebugLocation(840, 13);
				Match("0X"); 


				}
				break;

			}
			} finally { DebugExitSubRule(21); }

			DebugLocation(840, 20);
			// ES3YUITest.g:840:20: ( HexDigit )+
			int cnt22=0;
			try { DebugEnterSubRule(22);
			while (true)
			{
				int alt22=2;
				try { DebugEnterDecision(22, decisionCanBacktrack[22]);
				int LA22_0 = input.LA(1);

				if (((LA22_0>='0' && LA22_0<='9')||(LA22_0>='A' && LA22_0<='F')||(LA22_0>='a' && LA22_0<='f')))
				{
					alt22=1;
				}


				} finally { DebugExitDecision(22); }
				switch (alt22)
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:840:20: HexDigit
					{
					DebugLocation(840, 20);
					mHexDigit(); 

					}
					break;

				default:
					if (cnt22 >= 1)
						goto loop22;

					EarlyExitException eee22 = new EarlyExitException( 22, input );
					DebugRecognitionException(eee22);
					throw eee22;
				}
				cnt22++;
			}
			loop22:
				;

			} finally { DebugExitSubRule(22); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("HexIntegerLiteral", 137);
			LeaveRule("HexIntegerLiteral", 137);
			Leave_HexIntegerLiteral();
		}
	}
	// $ANTLR end "HexIntegerLiteral"

	partial void Enter_CharacterEscapeSequence();
	partial void Leave_CharacterEscapeSequence();

	// $ANTLR start "CharacterEscapeSequence"
	[GrammarRule("CharacterEscapeSequence")]
	private void mCharacterEscapeSequence()
	{
		Enter_CharacterEscapeSequence();
		EnterRule("CharacterEscapeSequence", 138);
		TraceIn("CharacterEscapeSequence", 138);
		try
		{
			// ES3YUITest.g:859:2: (~ ( DecimalDigit | 'x' | 'u' | LineTerminator ) )
			DebugEnterAlt(1);
			// ES3YUITest.g:859:4: ~ ( DecimalDigit | 'x' | 'u' | LineTerminator )
			{
			DebugLocation(859, 4);
			if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<='/')||(input.LA(1)>=':' && input.LA(1)<='t')||(input.LA(1)>='v' && input.LA(1)<='w')||(input.LA(1)>='y' && input.LA(1)<='\u2027')||(input.LA(1)>='\u202A' && input.LA(1)<='\uFFFF'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("CharacterEscapeSequence", 138);
			LeaveRule("CharacterEscapeSequence", 138);
			Leave_CharacterEscapeSequence();
		}
	}
	// $ANTLR end "CharacterEscapeSequence"

	partial void Enter_ZeroToThree();
	partial void Leave_ZeroToThree();

	// $ANTLR start "ZeroToThree"
	[GrammarRule("ZeroToThree")]
	private void mZeroToThree()
	{
		Enter_ZeroToThree();
		EnterRule("ZeroToThree", 139);
		TraceIn("ZeroToThree", 139);
		try
		{
			// ES3YUITest.g:863:2: ( '0' .. '3' )
			DebugEnterAlt(1);
			// ES3YUITest.g:863:4: '0' .. '3'
			{
			DebugLocation(863, 4);
			MatchRange('0','3'); 

			}

		}
		finally
		{
			TraceOut("ZeroToThree", 139);
			LeaveRule("ZeroToThree", 139);
			Leave_ZeroToThree();
		}
	}
	// $ANTLR end "ZeroToThree"

	partial void Enter_OctalEscapeSequence();
	partial void Leave_OctalEscapeSequence();

	// $ANTLR start "OctalEscapeSequence"
	[GrammarRule("OctalEscapeSequence")]
	private void mOctalEscapeSequence()
	{
		Enter_OctalEscapeSequence();
		EnterRule("OctalEscapeSequence", 140);
		TraceIn("OctalEscapeSequence", 140);
		try
		{
			// ES3YUITest.g:867:2: ( OctalDigit | ZeroToThree OctalDigit | '4' .. '7' OctalDigit | ZeroToThree OctalDigit OctalDigit )
			int alt23=4;
			try { DebugEnterDecision(23, decisionCanBacktrack[23]);
			int LA23_0 = input.LA(1);

			if (((LA23_0>='0' && LA23_0<='3')))
			{
				int LA23_1 = input.LA(2);

				if (((LA23_1>='0' && LA23_1<='7')))
				{
					int LA23_4 = input.LA(3);

					if (((LA23_4>='0' && LA23_4<='7')))
					{
						alt23=4;
					}
					else
					{
						alt23=2;}
				}
				else
				{
					alt23=1;}
			}
			else if (((LA23_0>='4' && LA23_0<='7')))
			{
				int LA23_2 = input.LA(2);

				if (((LA23_2>='0' && LA23_2<='7')))
				{
					alt23=3;
				}
				else
				{
					alt23=1;}
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 23, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(23); }
			switch (alt23)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:867:4: OctalDigit
				{
				DebugLocation(867, 4);
				mOctalDigit(); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ES3YUITest.g:868:4: ZeroToThree OctalDigit
				{
				DebugLocation(868, 4);
				mZeroToThree(); 
				DebugLocation(868, 16);
				mOctalDigit(); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// ES3YUITest.g:869:4: '4' .. '7' OctalDigit
				{
				DebugLocation(869, 4);
				MatchRange('4','7'); 
				DebugLocation(869, 13);
				mOctalDigit(); 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// ES3YUITest.g:870:4: ZeroToThree OctalDigit OctalDigit
				{
				DebugLocation(870, 4);
				mZeroToThree(); 
				DebugLocation(870, 16);
				mOctalDigit(); 
				DebugLocation(870, 27);
				mOctalDigit(); 

				}
				break;

			}
		}
		finally
		{
			TraceOut("OctalEscapeSequence", 140);
			LeaveRule("OctalEscapeSequence", 140);
			Leave_OctalEscapeSequence();
		}
	}
	// $ANTLR end "OctalEscapeSequence"

	partial void Enter_HexEscapeSequence();
	partial void Leave_HexEscapeSequence();

	// $ANTLR start "HexEscapeSequence"
	[GrammarRule("HexEscapeSequence")]
	private void mHexEscapeSequence()
	{
		Enter_HexEscapeSequence();
		EnterRule("HexEscapeSequence", 141);
		TraceIn("HexEscapeSequence", 141);
		try
		{
			// ES3YUITest.g:874:2: ( 'x' HexDigit HexDigit )
			DebugEnterAlt(1);
			// ES3YUITest.g:874:4: 'x' HexDigit HexDigit
			{
			DebugLocation(874, 4);
			Match('x'); 
			DebugLocation(874, 8);
			mHexDigit(); 
			DebugLocation(874, 17);
			mHexDigit(); 

			}

		}
		finally
		{
			TraceOut("HexEscapeSequence", 141);
			LeaveRule("HexEscapeSequence", 141);
			Leave_HexEscapeSequence();
		}
	}
	// $ANTLR end "HexEscapeSequence"

	partial void Enter_UnicodeEscapeSequence();
	partial void Leave_UnicodeEscapeSequence();

	// $ANTLR start "UnicodeEscapeSequence"
	[GrammarRule("UnicodeEscapeSequence")]
	private void mUnicodeEscapeSequence()
	{
		Enter_UnicodeEscapeSequence();
		EnterRule("UnicodeEscapeSequence", 142);
		TraceIn("UnicodeEscapeSequence", 142);
		try
		{
			// ES3YUITest.g:878:2: ( 'u' HexDigit HexDigit HexDigit HexDigit )
			DebugEnterAlt(1);
			// ES3YUITest.g:878:4: 'u' HexDigit HexDigit HexDigit HexDigit
			{
			DebugLocation(878, 4);
			Match('u'); 
			DebugLocation(878, 8);
			mHexDigit(); 
			DebugLocation(878, 17);
			mHexDigit(); 
			DebugLocation(878, 26);
			mHexDigit(); 
			DebugLocation(878, 35);
			mHexDigit(); 

			}

		}
		finally
		{
			TraceOut("UnicodeEscapeSequence", 142);
			LeaveRule("UnicodeEscapeSequence", 142);
			Leave_UnicodeEscapeSequence();
		}
	}
	// $ANTLR end "UnicodeEscapeSequence"

	partial void Enter_EscapeSequence();
	partial void Leave_EscapeSequence();

	// $ANTLR start "EscapeSequence"
	[GrammarRule("EscapeSequence")]
	private void mEscapeSequence()
	{
		Enter_EscapeSequence();
		EnterRule("EscapeSequence", 143);
		TraceIn("EscapeSequence", 143);
		try
		{
			// ES3YUITest.g:882:2: ( BSLASH ( CharacterEscapeSequence | OctalEscapeSequence | HexEscapeSequence | UnicodeEscapeSequence ) )
			DebugEnterAlt(1);
			// ES3YUITest.g:883:2: BSLASH ( CharacterEscapeSequence | OctalEscapeSequence | HexEscapeSequence | UnicodeEscapeSequence )
			{
			DebugLocation(883, 2);
			mBSLASH(); 
			DebugLocation(884, 2);
			// ES3YUITest.g:884:2: ( CharacterEscapeSequence | OctalEscapeSequence | HexEscapeSequence | UnicodeEscapeSequence )
			int alt24=4;
			try { DebugEnterSubRule(24);
			try { DebugEnterDecision(24, decisionCanBacktrack[24]);
			int LA24_0 = input.LA(1);

			if (((LA24_0>='\u0000' && LA24_0<='\t')||(LA24_0>='\u000B' && LA24_0<='\f')||(LA24_0>='\u000E' && LA24_0<='/')||(LA24_0>=':' && LA24_0<='t')||(LA24_0>='v' && LA24_0<='w')||(LA24_0>='y' && LA24_0<='\u2027')||(LA24_0>='\u202A' && LA24_0<='\uFFFF')))
			{
				alt24=1;
			}
			else if (((LA24_0>='0' && LA24_0<='7')))
			{
				alt24=2;
			}
			else if ((LA24_0=='x'))
			{
				alt24=3;
			}
			else if ((LA24_0=='u'))
			{
				alt24=4;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 24, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(24); }
			switch (alt24)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:885:3: CharacterEscapeSequence
				{
				DebugLocation(885, 3);
				mCharacterEscapeSequence(); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ES3YUITest.g:886:5: OctalEscapeSequence
				{
				DebugLocation(886, 5);
				mOctalEscapeSequence(); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// ES3YUITest.g:887:5: HexEscapeSequence
				{
				DebugLocation(887, 5);
				mHexEscapeSequence(); 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// ES3YUITest.g:888:5: UnicodeEscapeSequence
				{
				DebugLocation(888, 5);
				mUnicodeEscapeSequence(); 

				}
				break;

			}
			} finally { DebugExitSubRule(24); }


			}

		}
		finally
		{
			TraceOut("EscapeSequence", 143);
			LeaveRule("EscapeSequence", 143);
			Leave_EscapeSequence();
		}
	}
	// $ANTLR end "EscapeSequence"

	partial void Enter_StringLiteral();
	partial void Leave_StringLiteral();

	// $ANTLR start "StringLiteral"
	[GrammarRule("StringLiteral")]
	private void mStringLiteral()
	{
		Enter_StringLiteral();
		EnterRule("StringLiteral", 144);
		TraceIn("StringLiteral", 144);
		try
		{
			int _type = StringLiteral;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:893:2: ( SQUOTE (~ ( SQUOTE | BSLASH | LineTerminator ) | EscapeSequence )* SQUOTE | DQUOTE (~ ( DQUOTE | BSLASH | LineTerminator ) | EscapeSequence )* DQUOTE )
			int alt27=2;
			try { DebugEnterDecision(27, decisionCanBacktrack[27]);
			int LA27_0 = input.LA(1);

			if ((LA27_0=='\''))
			{
				alt27=1;
			}
			else if ((LA27_0=='\"'))
			{
				alt27=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 27, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(27); }
			switch (alt27)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:893:4: SQUOTE (~ ( SQUOTE | BSLASH | LineTerminator ) | EscapeSequence )* SQUOTE
				{
				DebugLocation(893, 4);
				mSQUOTE(); 
				DebugLocation(893, 11);
				// ES3YUITest.g:893:11: (~ ( SQUOTE | BSLASH | LineTerminator ) | EscapeSequence )*
				try { DebugEnterSubRule(25);
				while (true)
				{
					int alt25=3;
					try { DebugEnterDecision(25, decisionCanBacktrack[25]);
					int LA25_0 = input.LA(1);

					if (((LA25_0>='\u0000' && LA25_0<='\t')||(LA25_0>='\u000B' && LA25_0<='\f')||(LA25_0>='\u000E' && LA25_0<='&')||(LA25_0>='(' && LA25_0<='[')||(LA25_0>=']' && LA25_0<='\u2027')||(LA25_0>='\u202A' && LA25_0<='\uFFFF')))
					{
						alt25=1;
					}
					else if ((LA25_0=='\\'))
					{
						alt25=2;
					}


					} finally { DebugExitDecision(25); }
					switch ( alt25 )
					{
					case 1:
						DebugEnterAlt(1);
						// ES3YUITest.g:893:13: ~ ( SQUOTE | BSLASH | LineTerminator )
						{
						DebugLocation(893, 13);
						if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<='&')||(input.LA(1)>='(' && input.LA(1)<='[')||(input.LA(1)>=']' && input.LA(1)<='\u2027')||(input.LA(1)>='\u202A' && input.LA(1)<='\uFFFF'))
						{
							input.Consume();

						}
						else
						{
							MismatchedSetException mse = new MismatchedSetException(null,input);
							DebugRecognitionException(mse);
							Recover(mse);
							throw mse;}


						}
						break;
					case 2:
						DebugEnterAlt(2);
						// ES3YUITest.g:893:53: EscapeSequence
						{
						DebugLocation(893, 53);
						mEscapeSequence(); 

						}
						break;

					default:
						goto loop25;
					}
				}

				loop25:
					;

				} finally { DebugExitSubRule(25); }

				DebugLocation(893, 71);
				mSQUOTE(); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ES3YUITest.g:894:4: DQUOTE (~ ( DQUOTE | BSLASH | LineTerminator ) | EscapeSequence )* DQUOTE
				{
				DebugLocation(894, 4);
				mDQUOTE(); 
				DebugLocation(894, 11);
				// ES3YUITest.g:894:11: (~ ( DQUOTE | BSLASH | LineTerminator ) | EscapeSequence )*
				try { DebugEnterSubRule(26);
				while (true)
				{
					int alt26=3;
					try { DebugEnterDecision(26, decisionCanBacktrack[26]);
					int LA26_0 = input.LA(1);

					if (((LA26_0>='\u0000' && LA26_0<='\t')||(LA26_0>='\u000B' && LA26_0<='\f')||(LA26_0>='\u000E' && LA26_0<='!')||(LA26_0>='#' && LA26_0<='[')||(LA26_0>=']' && LA26_0<='\u2027')||(LA26_0>='\u202A' && LA26_0<='\uFFFF')))
					{
						alt26=1;
					}
					else if ((LA26_0=='\\'))
					{
						alt26=2;
					}


					} finally { DebugExitDecision(26); }
					switch ( alt26 )
					{
					case 1:
						DebugEnterAlt(1);
						// ES3YUITest.g:894:13: ~ ( DQUOTE | BSLASH | LineTerminator )
						{
						DebugLocation(894, 13);
						if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<='!')||(input.LA(1)>='#' && input.LA(1)<='[')||(input.LA(1)>=']' && input.LA(1)<='\u2027')||(input.LA(1)>='\u202A' && input.LA(1)<='\uFFFF'))
						{
							input.Consume();

						}
						else
						{
							MismatchedSetException mse = new MismatchedSetException(null,input);
							DebugRecognitionException(mse);
							Recover(mse);
							throw mse;}


						}
						break;
					case 2:
						DebugEnterAlt(2);
						// ES3YUITest.g:894:53: EscapeSequence
						{
						DebugLocation(894, 53);
						mEscapeSequence(); 

						}
						break;

					default:
						goto loop26;
					}
				}

				loop26:
					;

				} finally { DebugExitSubRule(26); }

				DebugLocation(894, 71);
				mDQUOTE(); 

				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("StringLiteral", 144);
			LeaveRule("StringLiteral", 144);
			Leave_StringLiteral();
		}
	}
	// $ANTLR end "StringLiteral"

	partial void Enter_BackslashSequence();
	partial void Leave_BackslashSequence();

	// $ANTLR start "BackslashSequence"
	[GrammarRule("BackslashSequence")]
	private void mBackslashSequence()
	{
		Enter_BackslashSequence();
		EnterRule("BackslashSequence", 145);
		TraceIn("BackslashSequence", 145);
		try
		{
			// ES3YUITest.g:902:2: ( BSLASH ~ ( LineTerminator ) )
			DebugEnterAlt(1);
			// ES3YUITest.g:902:4: BSLASH ~ ( LineTerminator )
			{
			DebugLocation(902, 4);
			mBSLASH(); 
			DebugLocation(902, 11);
			if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<='\u2027')||(input.LA(1)>='\u202A' && input.LA(1)<='\uFFFF'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("BackslashSequence", 145);
			LeaveRule("BackslashSequence", 145);
			Leave_BackslashSequence();
		}
	}
	// $ANTLR end "BackslashSequence"

	partial void Enter_RegularExpressionFirstChar();
	partial void Leave_RegularExpressionFirstChar();

	// $ANTLR start "RegularExpressionFirstChar"
	[GrammarRule("RegularExpressionFirstChar")]
	private void mRegularExpressionFirstChar()
	{
		Enter_RegularExpressionFirstChar();
		EnterRule("RegularExpressionFirstChar", 146);
		TraceIn("RegularExpressionFirstChar", 146);
		try
		{
			// ES3YUITest.g:906:2: (~ ( LineTerminator | MUL | BSLASH | DIV ) | BackslashSequence )
			int alt28=2;
			try { DebugEnterDecision(28, decisionCanBacktrack[28]);
			int LA28_0 = input.LA(1);

			if (((LA28_0>='\u0000' && LA28_0<='\t')||(LA28_0>='\u000B' && LA28_0<='\f')||(LA28_0>='\u000E' && LA28_0<=')')||(LA28_0>='+' && LA28_0<='.')||(LA28_0>='0' && LA28_0<='[')||(LA28_0>=']' && LA28_0<='\u2027')||(LA28_0>='\u202A' && LA28_0<='\uFFFF')))
			{
				alt28=1;
			}
			else if ((LA28_0=='\\'))
			{
				alt28=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 28, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(28); }
			switch (alt28)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:906:4: ~ ( LineTerminator | MUL | BSLASH | DIV )
				{
				DebugLocation(906, 4);
				if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<=')')||(input.LA(1)>='+' && input.LA(1)<='.')||(input.LA(1)>='0' && input.LA(1)<='[')||(input.LA(1)>=']' && input.LA(1)<='\u2027')||(input.LA(1)>='\u202A' && input.LA(1)<='\uFFFF'))
				{
					input.Consume();

				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					DebugRecognitionException(mse);
					Recover(mse);
					throw mse;}


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ES3YUITest.g:907:4: BackslashSequence
				{
				DebugLocation(907, 4);
				mBackslashSequence(); 

				}
				break;

			}
		}
		finally
		{
			TraceOut("RegularExpressionFirstChar", 146);
			LeaveRule("RegularExpressionFirstChar", 146);
			Leave_RegularExpressionFirstChar();
		}
	}
	// $ANTLR end "RegularExpressionFirstChar"

	partial void Enter_RegularExpressionChar();
	partial void Leave_RegularExpressionChar();

	// $ANTLR start "RegularExpressionChar"
	[GrammarRule("RegularExpressionChar")]
	private void mRegularExpressionChar()
	{
		Enter_RegularExpressionChar();
		EnterRule("RegularExpressionChar", 147);
		TraceIn("RegularExpressionChar", 147);
		try
		{
			// ES3YUITest.g:911:2: (~ ( LineTerminator | BSLASH | DIV ) | BackslashSequence )
			int alt29=2;
			try { DebugEnterDecision(29, decisionCanBacktrack[29]);
			int LA29_0 = input.LA(1);

			if (((LA29_0>='\u0000' && LA29_0<='\t')||(LA29_0>='\u000B' && LA29_0<='\f')||(LA29_0>='\u000E' && LA29_0<='.')||(LA29_0>='0' && LA29_0<='[')||(LA29_0>=']' && LA29_0<='\u2027')||(LA29_0>='\u202A' && LA29_0<='\uFFFF')))
			{
				alt29=1;
			}
			else if ((LA29_0=='\\'))
			{
				alt29=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 29, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(29); }
			switch (alt29)
			{
			case 1:
				DebugEnterAlt(1);
				// ES3YUITest.g:911:4: ~ ( LineTerminator | BSLASH | DIV )
				{
				DebugLocation(911, 4);
				if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<='.')||(input.LA(1)>='0' && input.LA(1)<='[')||(input.LA(1)>=']' && input.LA(1)<='\u2027')||(input.LA(1)>='\u202A' && input.LA(1)<='\uFFFF'))
				{
					input.Consume();

				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					DebugRecognitionException(mse);
					Recover(mse);
					throw mse;}


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ES3YUITest.g:912:4: BackslashSequence
				{
				DebugLocation(912, 4);
				mBackslashSequence(); 

				}
				break;

			}
		}
		finally
		{
			TraceOut("RegularExpressionChar", 147);
			LeaveRule("RegularExpressionChar", 147);
			Leave_RegularExpressionChar();
		}
	}
	// $ANTLR end "RegularExpressionChar"

	partial void Enter_RegularExpressionLiteral();
	partial void Leave_RegularExpressionLiteral();

	// $ANTLR start "RegularExpressionLiteral"
	[GrammarRule("RegularExpressionLiteral")]
	private void mRegularExpressionLiteral()
	{
		Enter_RegularExpressionLiteral();
		EnterRule("RegularExpressionLiteral", 148);
		TraceIn("RegularExpressionLiteral", 148);
		try
		{
			int _type = RegularExpressionLiteral;
			int _channel = DefaultTokenChannel;
			// ES3YUITest.g:916:2: ({...}? => DIV RegularExpressionFirstChar ( RegularExpressionChar )* DIV ( IdentifierPart )* )
			DebugEnterAlt(1);
			// ES3YUITest.g:916:4: {...}? => DIV RegularExpressionFirstChar ( RegularExpressionChar )* DIV ( IdentifierPart )*
			{
			DebugLocation(916, 4);
			if (!(( AreRegularExpressionsEnabled() )))
			{
				throw new FailedPredicateException(input, "RegularExpressionLiteral", " AreRegularExpressionsEnabled() ");
			}
			DebugLocation(916, 42);
			mDIV(); 
			DebugLocation(916, 46);
			mRegularExpressionFirstChar(); 
			DebugLocation(916, 73);
			// ES3YUITest.g:916:73: ( RegularExpressionChar )*
			try { DebugEnterSubRule(30);
			while (true)
			{
				int alt30=2;
				try { DebugEnterDecision(30, decisionCanBacktrack[30]);
				int LA30_0 = input.LA(1);

				if (((LA30_0>='\u0000' && LA30_0<='\t')||(LA30_0>='\u000B' && LA30_0<='\f')||(LA30_0>='\u000E' && LA30_0<='.')||(LA30_0>='0' && LA30_0<='\u2027')||(LA30_0>='\u202A' && LA30_0<='\uFFFF')))
				{
					alt30=1;
				}


				} finally { DebugExitDecision(30); }
				switch ( alt30 )
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:916:73: RegularExpressionChar
					{
					DebugLocation(916, 73);
					mRegularExpressionChar(); 

					}
					break;

				default:
					goto loop30;
				}
			}

			loop30:
				;

			} finally { DebugExitSubRule(30); }

			DebugLocation(916, 96);
			mDIV(); 
			DebugLocation(916, 100);
			// ES3YUITest.g:916:100: ( IdentifierPart )*
			try { DebugEnterSubRule(31);
			while (true)
			{
				int alt31=2;
				try { DebugEnterDecision(31, decisionCanBacktrack[31]);
				int LA31_0 = input.LA(1);

				if ((LA31_0=='$'||(LA31_0>='0' && LA31_0<='9')||(LA31_0>='A' && LA31_0<='Z')||LA31_0=='\\'||LA31_0=='_'||(LA31_0>='a' && LA31_0<='z')))
				{
					alt31=1;
				}
				else if ((( IsIdentifierPartUnicode(input.LA(1)) )))
				{
					alt31=1;
				}


				} finally { DebugExitDecision(31); }
				switch ( alt31 )
				{
				case 1:
					DebugEnterAlt(1);
					// ES3YUITest.g:916:100: IdentifierPart
					{
					DebugLocation(916, 100);
					mIdentifierPart(); 

					}
					break;

				default:
					goto loop31;
				}
			}

			loop31:
				;

			} finally { DebugExitSubRule(31); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RegularExpressionLiteral", 148);
			LeaveRule("RegularExpressionLiteral", 148);
			Leave_RegularExpressionLiteral();
		}
	}
	// $ANTLR end "RegularExpressionLiteral"

	public override void mTokens()
	{
		// ES3YUITest.g:1:8: ( NULL | TRUE | FALSE | BREAK | CASE | CATCH | CONTINUE | DEFAULT | DELETE | DO | ELSE | FINALLY | FOR | FUNCTION | IF | IN | INSTANCEOF | NEW | RETURN | SWITCH | THIS | THROW | TRY | TYPEOF | VAR | VOID | WHILE | WITH | ABSTRACT | BOOLEAN | BYTE | CHAR | CLASS | CONST | DEBUGGER | DOUBLE | ENUM | EXPORT | EXTENDS | FINAL | FLOAT | GOTO | IMPLEMENTS | IMPORT | INT | INTERFACE | LONG | NATIVE | PACKAGE | PRIVATE | PROTECTED | PUBLIC | SHORT | STATIC | SUPER | SYNCHRONIZED | THROWS | TRANSIENT | VOLATILE | LBRACE | RBRACE | LPAREN | RPAREN | LBRACK | RBRACK | DOT | SEMIC | COMMA | LT | GT | LTE | GTE | EQ | NEQ | SAME | NSAME | ADD | SUB | MUL | MOD | INC | DEC | SHL | SHR | SHU | AND | OR | XOR | NOT | INV | LAND | LOR | QUE | COLON | ASSIGN | ADDASS | SUBASS | MULASS | MODASS | SHLASS | SHRASS | SHUASS | ANDASS | ORASS | XORASS | DIV | DIVASS | WhiteSpace | EOL | MultiLineComment | SingleLineComment | Identifier | DecimalLiteral | OctalIntegerLiteral | HexIntegerLiteral | StringLiteral | RegularExpressionLiteral )
		int alt32=117;
		try { DebugEnterDecision(32, decisionCanBacktrack[32]);
		try
		{
			alt32 = dfa32.Predict(input);
		}
		catch (NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
			throw;
		}
		} finally { DebugExitDecision(32); }
		switch (alt32)
		{
		case 1:
			DebugEnterAlt(1);
			// ES3YUITest.g:1:10: NULL
			{
			DebugLocation(1, 10);
			mNULL(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// ES3YUITest.g:1:15: TRUE
			{
			DebugLocation(1, 15);
			mTRUE(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// ES3YUITest.g:1:20: FALSE
			{
			DebugLocation(1, 20);
			mFALSE(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// ES3YUITest.g:1:26: BREAK
			{
			DebugLocation(1, 26);
			mBREAK(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// ES3YUITest.g:1:32: CASE
			{
			DebugLocation(1, 32);
			mCASE(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// ES3YUITest.g:1:37: CATCH
			{
			DebugLocation(1, 37);
			mCATCH(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// ES3YUITest.g:1:43: CONTINUE
			{
			DebugLocation(1, 43);
			mCONTINUE(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// ES3YUITest.g:1:52: DEFAULT
			{
			DebugLocation(1, 52);
			mDEFAULT(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// ES3YUITest.g:1:60: DELETE
			{
			DebugLocation(1, 60);
			mDELETE(); 

			}
			break;
		case 10:
			DebugEnterAlt(10);
			// ES3YUITest.g:1:67: DO
			{
			DebugLocation(1, 67);
			mDO(); 

			}
			break;
		case 11:
			DebugEnterAlt(11);
			// ES3YUITest.g:1:70: ELSE
			{
			DebugLocation(1, 70);
			mELSE(); 

			}
			break;
		case 12:
			DebugEnterAlt(12);
			// ES3YUITest.g:1:75: FINALLY
			{
			DebugLocation(1, 75);
			mFINALLY(); 

			}
			break;
		case 13:
			DebugEnterAlt(13);
			// ES3YUITest.g:1:83: FOR
			{
			DebugLocation(1, 83);
			mFOR(); 

			}
			break;
		case 14:
			DebugEnterAlt(14);
			// ES3YUITest.g:1:87: FUNCTION
			{
			DebugLocation(1, 87);
			mFUNCTION(); 

			}
			break;
		case 15:
			DebugEnterAlt(15);
			// ES3YUITest.g:1:96: IF
			{
			DebugLocation(1, 96);
			mIF(); 

			}
			break;
		case 16:
			DebugEnterAlt(16);
			// ES3YUITest.g:1:99: IN
			{
			DebugLocation(1, 99);
			mIN(); 

			}
			break;
		case 17:
			DebugEnterAlt(17);
			// ES3YUITest.g:1:102: INSTANCEOF
			{
			DebugLocation(1, 102);
			mINSTANCEOF(); 

			}
			break;
		case 18:
			DebugEnterAlt(18);
			// ES3YUITest.g:1:113: NEW
			{
			DebugLocation(1, 113);
			mNEW(); 

			}
			break;
		case 19:
			DebugEnterAlt(19);
			// ES3YUITest.g:1:117: RETURN
			{
			DebugLocation(1, 117);
			mRETURN(); 

			}
			break;
		case 20:
			DebugEnterAlt(20);
			// ES3YUITest.g:1:124: SWITCH
			{
			DebugLocation(1, 124);
			mSWITCH(); 

			}
			break;
		case 21:
			DebugEnterAlt(21);
			// ES3YUITest.g:1:131: THIS
			{
			DebugLocation(1, 131);
			mTHIS(); 

			}
			break;
		case 22:
			DebugEnterAlt(22);
			// ES3YUITest.g:1:136: THROW
			{
			DebugLocation(1, 136);
			mTHROW(); 

			}
			break;
		case 23:
			DebugEnterAlt(23);
			// ES3YUITest.g:1:142: TRY
			{
			DebugLocation(1, 142);
			mTRY(); 

			}
			break;
		case 24:
			DebugEnterAlt(24);
			// ES3YUITest.g:1:146: TYPEOF
			{
			DebugLocation(1, 146);
			mTYPEOF(); 

			}
			break;
		case 25:
			DebugEnterAlt(25);
			// ES3YUITest.g:1:153: VAR
			{
			DebugLocation(1, 153);
			mVAR(); 

			}
			break;
		case 26:
			DebugEnterAlt(26);
			// ES3YUITest.g:1:157: VOID
			{
			DebugLocation(1, 157);
			mVOID(); 

			}
			break;
		case 27:
			DebugEnterAlt(27);
			// ES3YUITest.g:1:162: WHILE
			{
			DebugLocation(1, 162);
			mWHILE(); 

			}
			break;
		case 28:
			DebugEnterAlt(28);
			// ES3YUITest.g:1:168: WITH
			{
			DebugLocation(1, 168);
			mWITH(); 

			}
			break;
		case 29:
			DebugEnterAlt(29);
			// ES3YUITest.g:1:173: ABSTRACT
			{
			DebugLocation(1, 173);
			mABSTRACT(); 

			}
			break;
		case 30:
			DebugEnterAlt(30);
			// ES3YUITest.g:1:182: BOOLEAN
			{
			DebugLocation(1, 182);
			mBOOLEAN(); 

			}
			break;
		case 31:
			DebugEnterAlt(31);
			// ES3YUITest.g:1:190: BYTE
			{
			DebugLocation(1, 190);
			mBYTE(); 

			}
			break;
		case 32:
			DebugEnterAlt(32);
			// ES3YUITest.g:1:195: CHAR
			{
			DebugLocation(1, 195);
			mCHAR(); 

			}
			break;
		case 33:
			DebugEnterAlt(33);
			// ES3YUITest.g:1:200: CLASS
			{
			DebugLocation(1, 200);
			mCLASS(); 

			}
			break;
		case 34:
			DebugEnterAlt(34);
			// ES3YUITest.g:1:206: CONST
			{
			DebugLocation(1, 206);
			mCONST(); 

			}
			break;
		case 35:
			DebugEnterAlt(35);
			// ES3YUITest.g:1:212: DEBUGGER
			{
			DebugLocation(1, 212);
			mDEBUGGER(); 

			}
			break;
		case 36:
			DebugEnterAlt(36);
			// ES3YUITest.g:1:221: DOUBLE
			{
			DebugLocation(1, 221);
			mDOUBLE(); 

			}
			break;
		case 37:
			DebugEnterAlt(37);
			// ES3YUITest.g:1:228: ENUM
			{
			DebugLocation(1, 228);
			mENUM(); 

			}
			break;
		case 38:
			DebugEnterAlt(38);
			// ES3YUITest.g:1:233: EXPORT
			{
			DebugLocation(1, 233);
			mEXPORT(); 

			}
			break;
		case 39:
			DebugEnterAlt(39);
			// ES3YUITest.g:1:240: EXTENDS
			{
			DebugLocation(1, 240);
			mEXTENDS(); 

			}
			break;
		case 40:
			DebugEnterAlt(40);
			// ES3YUITest.g:1:248: FINAL
			{
			DebugLocation(1, 248);
			mFINAL(); 

			}
			break;
		case 41:
			DebugEnterAlt(41);
			// ES3YUITest.g:1:254: FLOAT
			{
			DebugLocation(1, 254);
			mFLOAT(); 

			}
			break;
		case 42:
			DebugEnterAlt(42);
			// ES3YUITest.g:1:260: GOTO
			{
			DebugLocation(1, 260);
			mGOTO(); 

			}
			break;
		case 43:
			DebugEnterAlt(43);
			// ES3YUITest.g:1:265: IMPLEMENTS
			{
			DebugLocation(1, 265);
			mIMPLEMENTS(); 

			}
			break;
		case 44:
			DebugEnterAlt(44);
			// ES3YUITest.g:1:276: IMPORT
			{
			DebugLocation(1, 276);
			mIMPORT(); 

			}
			break;
		case 45:
			DebugEnterAlt(45);
			// ES3YUITest.g:1:283: INT
			{
			DebugLocation(1, 283);
			mINT(); 

			}
			break;
		case 46:
			DebugEnterAlt(46);
			// ES3YUITest.g:1:287: INTERFACE
			{
			DebugLocation(1, 287);
			mINTERFACE(); 

			}
			break;
		case 47:
			DebugEnterAlt(47);
			// ES3YUITest.g:1:297: LONG
			{
			DebugLocation(1, 297);
			mLONG(); 

			}
			break;
		case 48:
			DebugEnterAlt(48);
			// ES3YUITest.g:1:302: NATIVE
			{
			DebugLocation(1, 302);
			mNATIVE(); 

			}
			break;
		case 49:
			DebugEnterAlt(49);
			// ES3YUITest.g:1:309: PACKAGE
			{
			DebugLocation(1, 309);
			mPACKAGE(); 

			}
			break;
		case 50:
			DebugEnterAlt(50);
			// ES3YUITest.g:1:317: PRIVATE
			{
			DebugLocation(1, 317);
			mPRIVATE(); 

			}
			break;
		case 51:
			DebugEnterAlt(51);
			// ES3YUITest.g:1:325: PROTECTED
			{
			DebugLocation(1, 325);
			mPROTECTED(); 

			}
			break;
		case 52:
			DebugEnterAlt(52);
			// ES3YUITest.g:1:335: PUBLIC
			{
			DebugLocation(1, 335);
			mPUBLIC(); 

			}
			break;
		case 53:
			DebugEnterAlt(53);
			// ES3YUITest.g:1:342: SHORT
			{
			DebugLocation(1, 342);
			mSHORT(); 

			}
			break;
		case 54:
			DebugEnterAlt(54);
			// ES3YUITest.g:1:348: STATIC
			{
			DebugLocation(1, 348);
			mSTATIC(); 

			}
			break;
		case 55:
			DebugEnterAlt(55);
			// ES3YUITest.g:1:355: SUPER
			{
			DebugLocation(1, 355);
			mSUPER(); 

			}
			break;
		case 56:
			DebugEnterAlt(56);
			// ES3YUITest.g:1:361: SYNCHRONIZED
			{
			DebugLocation(1, 361);
			mSYNCHRONIZED(); 

			}
			break;
		case 57:
			DebugEnterAlt(57);
			// ES3YUITest.g:1:374: THROWS
			{
			DebugLocation(1, 374);
			mTHROWS(); 

			}
			break;
		case 58:
			DebugEnterAlt(58);
			// ES3YUITest.g:1:381: TRANSIENT
			{
			DebugLocation(1, 381);
			mTRANSIENT(); 

			}
			break;
		case 59:
			DebugEnterAlt(59);
			// ES3YUITest.g:1:391: VOLATILE
			{
			DebugLocation(1, 391);
			mVOLATILE(); 

			}
			break;
		case 60:
			DebugEnterAlt(60);
			// ES3YUITest.g:1:400: LBRACE
			{
			DebugLocation(1, 400);
			mLBRACE(); 

			}
			break;
		case 61:
			DebugEnterAlt(61);
			// ES3YUITest.g:1:407: RBRACE
			{
			DebugLocation(1, 407);
			mRBRACE(); 

			}
			break;
		case 62:
			DebugEnterAlt(62);
			// ES3YUITest.g:1:414: LPAREN
			{
			DebugLocation(1, 414);
			mLPAREN(); 

			}
			break;
		case 63:
			DebugEnterAlt(63);
			// ES3YUITest.g:1:421: RPAREN
			{
			DebugLocation(1, 421);
			mRPAREN(); 

			}
			break;
		case 64:
			DebugEnterAlt(64);
			// ES3YUITest.g:1:428: LBRACK
			{
			DebugLocation(1, 428);
			mLBRACK(); 

			}
			break;
		case 65:
			DebugEnterAlt(65);
			// ES3YUITest.g:1:435: RBRACK
			{
			DebugLocation(1, 435);
			mRBRACK(); 

			}
			break;
		case 66:
			DebugEnterAlt(66);
			// ES3YUITest.g:1:442: DOT
			{
			DebugLocation(1, 442);
			mDOT(); 

			}
			break;
		case 67:
			DebugEnterAlt(67);
			// ES3YUITest.g:1:446: SEMIC
			{
			DebugLocation(1, 446);
			mSEMIC(); 

			}
			break;
		case 68:
			DebugEnterAlt(68);
			// ES3YUITest.g:1:452: COMMA
			{
			DebugLocation(1, 452);
			mCOMMA(); 

			}
			break;
		case 69:
			DebugEnterAlt(69);
			// ES3YUITest.g:1:458: LT
			{
			DebugLocation(1, 458);
			mLT(); 

			}
			break;
		case 70:
			DebugEnterAlt(70);
			// ES3YUITest.g:1:461: GT
			{
			DebugLocation(1, 461);
			mGT(); 

			}
			break;
		case 71:
			DebugEnterAlt(71);
			// ES3YUITest.g:1:464: LTE
			{
			DebugLocation(1, 464);
			mLTE(); 

			}
			break;
		case 72:
			DebugEnterAlt(72);
			// ES3YUITest.g:1:468: GTE
			{
			DebugLocation(1, 468);
			mGTE(); 

			}
			break;
		case 73:
			DebugEnterAlt(73);
			// ES3YUITest.g:1:472: EQ
			{
			DebugLocation(1, 472);
			mEQ(); 

			}
			break;
		case 74:
			DebugEnterAlt(74);
			// ES3YUITest.g:1:475: NEQ
			{
			DebugLocation(1, 475);
			mNEQ(); 

			}
			break;
		case 75:
			DebugEnterAlt(75);
			// ES3YUITest.g:1:479: SAME
			{
			DebugLocation(1, 479);
			mSAME(); 

			}
			break;
		case 76:
			DebugEnterAlt(76);
			// ES3YUITest.g:1:484: NSAME
			{
			DebugLocation(1, 484);
			mNSAME(); 

			}
			break;
		case 77:
			DebugEnterAlt(77);
			// ES3YUITest.g:1:490: ADD
			{
			DebugLocation(1, 490);
			mADD(); 

			}
			break;
		case 78:
			DebugEnterAlt(78);
			// ES3YUITest.g:1:494: SUB
			{
			DebugLocation(1, 494);
			mSUB(); 

			}
			break;
		case 79:
			DebugEnterAlt(79);
			// ES3YUITest.g:1:498: MUL
			{
			DebugLocation(1, 498);
			mMUL(); 

			}
			break;
		case 80:
			DebugEnterAlt(80);
			// ES3YUITest.g:1:502: MOD
			{
			DebugLocation(1, 502);
			mMOD(); 

			}
			break;
		case 81:
			DebugEnterAlt(81);
			// ES3YUITest.g:1:506: INC
			{
			DebugLocation(1, 506);
			mINC(); 

			}
			break;
		case 82:
			DebugEnterAlt(82);
			// ES3YUITest.g:1:510: DEC
			{
			DebugLocation(1, 510);
			mDEC(); 

			}
			break;
		case 83:
			DebugEnterAlt(83);
			// ES3YUITest.g:1:514: SHL
			{
			DebugLocation(1, 514);
			mSHL(); 

			}
			break;
		case 84:
			DebugEnterAlt(84);
			// ES3YUITest.g:1:518: SHR
			{
			DebugLocation(1, 518);
			mSHR(); 

			}
			break;
		case 85:
			DebugEnterAlt(85);
			// ES3YUITest.g:1:522: SHU
			{
			DebugLocation(1, 522);
			mSHU(); 

			}
			break;
		case 86:
			DebugEnterAlt(86);
			// ES3YUITest.g:1:526: AND
			{
			DebugLocation(1, 526);
			mAND(); 

			}
			break;
		case 87:
			DebugEnterAlt(87);
			// ES3YUITest.g:1:530: OR
			{
			DebugLocation(1, 530);
			mOR(); 

			}
			break;
		case 88:
			DebugEnterAlt(88);
			// ES3YUITest.g:1:533: XOR
			{
			DebugLocation(1, 533);
			mXOR(); 

			}
			break;
		case 89:
			DebugEnterAlt(89);
			// ES3YUITest.g:1:537: NOT
			{
			DebugLocation(1, 537);
			mNOT(); 

			}
			break;
		case 90:
			DebugEnterAlt(90);
			// ES3YUITest.g:1:541: INV
			{
			DebugLocation(1, 541);
			mINV(); 

			}
			break;
		case 91:
			DebugEnterAlt(91);
			// ES3YUITest.g:1:545: LAND
			{
			DebugLocation(1, 545);
			mLAND(); 

			}
			break;
		case 92:
			DebugEnterAlt(92);
			// ES3YUITest.g:1:550: LOR
			{
			DebugLocation(1, 550);
			mLOR(); 

			}
			break;
		case 93:
			DebugEnterAlt(93);
			// ES3YUITest.g:1:554: QUE
			{
			DebugLocation(1, 554);
			mQUE(); 

			}
			break;
		case 94:
			DebugEnterAlt(94);
			// ES3YUITest.g:1:558: COLON
			{
			DebugLocation(1, 558);
			mCOLON(); 

			}
			break;
		case 95:
			DebugEnterAlt(95);
			// ES3YUITest.g:1:564: ASSIGN
			{
			DebugLocation(1, 564);
			mASSIGN(); 

			}
			break;
		case 96:
			DebugEnterAlt(96);
			// ES3YUITest.g:1:571: ADDASS
			{
			DebugLocation(1, 571);
			mADDASS(); 

			}
			break;
		case 97:
			DebugEnterAlt(97);
			// ES3YUITest.g:1:578: SUBASS
			{
			DebugLocation(1, 578);
			mSUBASS(); 

			}
			break;
		case 98:
			DebugEnterAlt(98);
			// ES3YUITest.g:1:585: MULASS
			{
			DebugLocation(1, 585);
			mMULASS(); 

			}
			break;
		case 99:
			DebugEnterAlt(99);
			// ES3YUITest.g:1:592: MODASS
			{
			DebugLocation(1, 592);
			mMODASS(); 

			}
			break;
		case 100:
			DebugEnterAlt(100);
			// ES3YUITest.g:1:599: SHLASS
			{
			DebugLocation(1, 599);
			mSHLASS(); 

			}
			break;
		case 101:
			DebugEnterAlt(101);
			// ES3YUITest.g:1:606: SHRASS
			{
			DebugLocation(1, 606);
			mSHRASS(); 

			}
			break;
		case 102:
			DebugEnterAlt(102);
			// ES3YUITest.g:1:613: SHUASS
			{
			DebugLocation(1, 613);
			mSHUASS(); 

			}
			break;
		case 103:
			DebugEnterAlt(103);
			// ES3YUITest.g:1:620: ANDASS
			{
			DebugLocation(1, 620);
			mANDASS(); 

			}
			break;
		case 104:
			DebugEnterAlt(104);
			// ES3YUITest.g:1:627: ORASS
			{
			DebugLocation(1, 627);
			mORASS(); 

			}
			break;
		case 105:
			DebugEnterAlt(105);
			// ES3YUITest.g:1:633: XORASS
			{
			DebugLocation(1, 633);
			mXORASS(); 

			}
			break;
		case 106:
			DebugEnterAlt(106);
			// ES3YUITest.g:1:640: DIV
			{
			DebugLocation(1, 640);
			mDIV(); 

			}
			break;
		case 107:
			DebugEnterAlt(107);
			// ES3YUITest.g:1:644: DIVASS
			{
			DebugLocation(1, 644);
			mDIVASS(); 

			}
			break;
		case 108:
			DebugEnterAlt(108);
			// ES3YUITest.g:1:651: WhiteSpace
			{
			DebugLocation(1, 651);
			mWhiteSpace(); 

			}
			break;
		case 109:
			DebugEnterAlt(109);
			// ES3YUITest.g:1:662: EOL
			{
			DebugLocation(1, 662);
			mEOL(); 

			}
			break;
		case 110:
			DebugEnterAlt(110);
			// ES3YUITest.g:1:666: MultiLineComment
			{
			DebugLocation(1, 666);
			mMultiLineComment(); 

			}
			break;
		case 111:
			DebugEnterAlt(111);
			// ES3YUITest.g:1:683: SingleLineComment
			{
			DebugLocation(1, 683);
			mSingleLineComment(); 

			}
			break;
		case 112:
			DebugEnterAlt(112);
			// ES3YUITest.g:1:701: Identifier
			{
			DebugLocation(1, 701);
			mIdentifier(); 

			}
			break;
		case 113:
			DebugEnterAlt(113);
			// ES3YUITest.g:1:712: DecimalLiteral
			{
			DebugLocation(1, 712);
			mDecimalLiteral(); 

			}
			break;
		case 114:
			DebugEnterAlt(114);
			// ES3YUITest.g:1:727: OctalIntegerLiteral
			{
			DebugLocation(1, 727);
			mOctalIntegerLiteral(); 

			}
			break;
		case 115:
			DebugEnterAlt(115);
			// ES3YUITest.g:1:747: HexIntegerLiteral
			{
			DebugLocation(1, 747);
			mHexIntegerLiteral(); 

			}
			break;
		case 116:
			DebugEnterAlt(116);
			// ES3YUITest.g:1:765: StringLiteral
			{
			DebugLocation(1, 765);
			mStringLiteral(); 

			}
			break;
		case 117:
			DebugEnterAlt(117);
			// ES3YUITest.g:1:779: RegularExpressionLiteral
			{
			DebugLocation(1, 779);
			mRegularExpressionLiteral(); 

			}
			break;

		}

	}


	#region DFA
	DFA19 dfa19;
	DFA32 dfa32;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa19 = new DFA19(this);
		dfa32 = new DFA32(this, SpecialStateTransition32);
	}

	private class DFA19 : DFA
	{
		private const string DFA19_eotS =
			"\x1\xFFFF\x2\x4\x3\xFFFF\x1\x4";
		private const string DFA19_eofS =
			"\x7\xFFFF";
		private const string DFA19_minS =
			"\x3\x2E\x3\xFFFF\x1\x2E";
		private const string DFA19_maxS =
			"\x1\x39\x1\x2E\x1\x39\x3\xFFFF\x1\x39";
		private const string DFA19_acceptS =
			"\x3\xFFFF\x1\x2\x1\x3\x1\x1\x1\xFFFF";
		private const string DFA19_specialS =
			"\x7\xFFFF}>";
		private static readonly string[] DFA19_transitionS =
			{
				"\x1\x3\x1\xFFFF\x1\x1\x9\x2",
				"\x1\x5",
				"\x1\x5\x1\xFFFF\xA\x6",
				"",
				"",
				"",
				"\x1\x5\x1\xFFFF\xA\x6"
			};

		private static readonly short[] DFA19_eot = DFA.UnpackEncodedString(DFA19_eotS);
		private static readonly short[] DFA19_eof = DFA.UnpackEncodedString(DFA19_eofS);
		private static readonly char[] DFA19_min = DFA.UnpackEncodedStringToUnsignedChars(DFA19_minS);
		private static readonly char[] DFA19_max = DFA.UnpackEncodedStringToUnsignedChars(DFA19_maxS);
		private static readonly short[] DFA19_accept = DFA.UnpackEncodedString(DFA19_acceptS);
		private static readonly short[] DFA19_special = DFA.UnpackEncodedString(DFA19_specialS);
		private static readonly short[][] DFA19_transition;

		static DFA19()
		{
			int numStates = DFA19_transitionS.Length;
			DFA19_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA19_transition[i] = DFA.UnpackEncodedString(DFA19_transitionS[i]);
			}
		}

		public DFA19( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 19;
			this.eot = DFA19_eot;
			this.eof = DFA19_eof;
			this.min = DFA19_min;
			this.max = DFA19_max;
			this.accept = DFA19_accept;
			this.special = DFA19_special;
			this.transition = DFA19_transition;
		}

		public override string Description { get { return "829:1: DecimalLiteral : ( DecimalIntegerLiteral '.' ( DecimalDigit )* ( ExponentPart )? | '.' ( DecimalDigit )+ ( ExponentPart )? | DecimalIntegerLiteral ( ExponentPart )? );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA32 : DFA
	{
		private const string DFA32_eotS =
			"\x11\x2B\x6\xFFFF\x1\x59\x2\xFFFF\x1\x5C\x1\x5F\x1\x61\x1\x63\x1\x66"+
			"\x1\x69\x1\x6B\x1\x6D\x1\x70\x1\x73\x1\x75\x3\xFFFF\x1\x79\x3\xFFFF\x1"+
			"\x2D\x2\xFFFF\x13\x2B\x1\x97\x3\x2B\x1\x9C\x1\x9F\x11\x2B\x2\xFFFF\x1"+
			"\xB4\x2\xFFFF\x1\xB7\x1\xFFFF\x1\xB9\x1\xFFFF\x1\xBB\x13\xFFFF\x1\xBC"+
			"\x6\xFFFF\x1\x2B\x1\xBE\x2\x2B\x1\xC1\x6\x2B\x1\xC8\xE\x2B\x1\xFFFF\x4"+
			"\x2B\x1\xFFFF\x1\x2B\x1\xDE\x1\xFFFF\x7\x2B\x1\xE7\xB\x2B\x2\xFFFF\x1"+
			"\xF4\x7\xFFFF\x1\xF5\x1\xFFFF\x1\x2B\x1\xF7\x1\xFFFF\x1\x2B\x1\xF9\x4"+
			"\x2B\x1\xFFFF\x4\x2B\x1\x102\x1\x103\x3\x2B\x1\x107\x5\x2B\x1\x10D\x1"+
			"\x10E\x4\x2B\x1\xFFFF\x8\x2B\x1\xFFFF\x1\x11B\x2\x2B\x1\x11E\x1\x2B\x1"+
			"\x120\x1\x121\x4\x2B\x3\xFFFF\x1\x2B\x1\xFFFF\x1\x2B\x1\xFFFF\x1\x129"+
			"\x1\x2B\x1\x12B\x1\x12D\x1\x2B\x1\x12F\x1\x130\x1\x2B\x2\xFFFF\x1\x132"+
			"\x1\x2B\x1\x134\x1\xFFFF\x1\x135\x4\x2B\x2\xFFFF\x8\x2B\x1\x142\x1\x2B"+
			"\x1\x144\x1\x2B\x1\xFFFF\x1\x2B\x1\x147\x1\xFFFF\x1\x2B\x2\xFFFF\x4\x2B"+
			"\x1\x14D\x1\x2B\x1\x14F\x1\xFFFF\x1\x150\x1\xFFFF\x1\x2B\x1\xFFFF\x1"+
			"\x2B\x2\xFFFF\x1\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1\x2B\x1\x156\x1\x2B\x1"+
			"\x158\x1\x159\x4\x2B\x1\x15E\x1\x15F\x1\x160\x1\xFFFF\x1\x161\x1\xFFFF"+
			"\x2\x2B\x1\xFFFF\x4\x2B\x1\x168\x1\xFFFF\x1\x2B\x2\xFFFF\x1\x16A\x1\x2B"+
			"\x1\x16C\x1\x2B\x1\x16E\x1\xFFFF\x1\x2B\x2\xFFFF\x1\x170\x3\x2B\x4\xFFFF"+
			"\x3\x2B\x1\x177\x1\x178\x1\x2B\x1\xFFFF\x1\x2B\x1\xFFFF\x1\x17B\x1\xFFFF"+
			"\x1\x17C\x1\xFFFF\x1\x17D\x1\xFFFF\x4\x2B\x1\x182\x1\x183\x2\xFFFF\x1"+
			"\x2B\x1\x185\x3\xFFFF\x1\x2B\x1\x187\x2\x2B\x2\xFFFF\x1\x18A\x1\xFFFF"+
			"\x1\x18B\x1\xFFFF\x1\x18C\x1\x2B\x3\xFFFF\x1\x2B\x1\x18F\x1\xFFFF";
		private const string DFA32_eofS =
			"\x190\xFFFF";
		private const string DFA32_minS =
			"\x1\x9\x1\x61\x1\x68\x1\x61\x1\x6F\x1\x61\x1\x65\x1\x6C\x1\x66\x1\x65"+
			"\x1\x68\x1\x61\x1\x68\x1\x62\x2\x6F\x1\x61\x6\xFFFF\x1\x30\x2\xFFFF\x1"+
			"\x3C\x3\x3D\x1\x2B\x1\x2D\x2\x3D\x1\x26\x2\x3D\x3\xFFFF\x1\x0\x3\xFFFF"+
			"\x1\x30\x2\xFFFF\x1\x6C\x1\x77\x1\x74\x1\x61\x1\x69\x1\x70\x1\x6C\x1"+
			"\x6E\x1\x72\x1\x6E\x1\x6F\x1\x65\x1\x6F\x1\x74\x1\x73\x1\x6E\x2\x61\x1"+
			"\x62\x1\x24\x1\x73\x1\x75\x1\x70\x2\x24\x1\x70\x1\x74\x1\x69\x1\x6F\x1"+
			"\x61\x1\x70\x1\x6E\x1\x72\x2\x69\x1\x74\x1\x73\x1\x74\x1\x6E\x1\x63\x1"+
			"\x69\x1\x62\x2\xFFFF\x1\x3D\x2\xFFFF\x1\x3D\x1\xFFFF\x1\x3D\x1\xFFFF"+
			"\x1\x3D\x13\xFFFF\x1\x0\x6\xFFFF\x1\x6C\x1\x24\x1\x69\x1\x65\x1\x24\x1"+
			"\x6E\x1\x73\x1\x6F\x1\x65\x1\x73\x1\x61\x1\x24\x1\x63\x2\x61\x1\x6C\x2"+
			"\x65\x1\x63\x1\x73\x1\x72\x1\x73\x1\x61\x1\x65\x1\x75\x1\x62\x1\xFFFF"+
			"\x1\x65\x1\x6D\x1\x6F\x1\x65\x1\xFFFF\x1\x74\x1\x24\x1\xFFFF\x1\x6C\x1"+
			"\x75\x1\x74\x1\x72\x1\x74\x1\x65\x1\x63\x1\x24\x1\x64\x1\x61\x1\x6C\x1"+
			"\x68\x1\x74\x1\x6F\x1\x67\x1\x6B\x1\x76\x1\x74\x1\x6C\x2\xFFFF\x1\x3D"+
			"\x7\xFFFF\x1\x24\x1\xFFFF\x1\x76\x1\x24\x1\xFFFF\x1\x73\x1\x24\x1\x77"+
			"\x1\x6F\x1\x65\x1\x6C\x1\xFFFF\x2\x74\x1\x6B\x1\x65\x2\x24\x1\x68\x1"+
			"\x69\x1\x74\x1\x24\x1\x73\x1\x75\x1\x74\x1\x67\x1\x6C\x2\x24\x1\x72\x1"+
			"\x6E\x1\x61\x1\x72\x1\xFFFF\x1\x65\x2\x72\x1\x63\x1\x74\x1\x69\x1\x72"+
			"\x1\x68\x1\xFFFF\x1\x24\x1\x74\x1\x65\x1\x24\x1\x72\x2\x24\x2\x61\x1"+
			"\x65\x1\x69\x3\xFFFF\x1\x65\x1\xFFFF\x1\x69\x1\xFFFF\x1\x24\x1\x66\x2"+
			"\x24\x1\x69\x2\x24\x1\x61\x2\xFFFF\x1\x24\x1\x6E\x1\x24\x1\xFFFF\x1\x24"+
			"\x1\x6C\x1\x65\x1\x67\x1\x65\x2\xFFFF\x1\x74\x1\x64\x1\x6E\x1\x66\x1"+
			"\x6D\x1\x74\x1\x6E\x1\x68\x1\x24\x1\x63\x1\x24\x1\x72\x1\xFFFF\x1\x69"+
			"\x1\x24\x1\xFFFF\x1\x61\x2\xFFFF\x1\x67\x1\x74\x2\x63\x1\x24\x1\x65\x1"+
			"\x24\x1\xFFFF\x1\x24\x1\xFFFF\x1\x79\x1\xFFFF\x1\x6F\x2\xFFFF\x1\x6E"+
			"\x1\xFFFF\x1\x75\x2\xFFFF\x1\x74\x1\x24\x1\x65\x2\x24\x1\x73\x1\x63\x1"+
			"\x61\x1\x65\x3\x24\x1\xFFFF\x1\x24\x1\xFFFF\x1\x6F\x1\x6C\x1\xFFFF\x1"+
			"\x63\x2\x65\x1\x74\x1\x24\x1\xFFFF\x1\x6E\x2\xFFFF\x1\x24\x1\x6E\x1\x24"+
			"\x1\x65\x1\x24\x1\xFFFF\x1\x72\x2\xFFFF\x1\x24\x1\x65\x1\x63\x1\x6E\x4"+
			"\xFFFF\x1\x6E\x1\x65\x1\x74\x2\x24\x1\x65\x1\xFFFF\x1\x74\x1\xFFFF\x1"+
			"\x24\x1\xFFFF\x1\x24\x1\xFFFF\x1\x24\x1\xFFFF\x1\x6F\x1\x65\x1\x74\x1"+
			"\x69\x2\x24\x2\xFFFF\x1\x64\x1\x24\x3\xFFFF\x1\x66\x1\x24\x1\x73\x1\x7A"+
			"\x2\xFFFF\x1\x24\x1\xFFFF\x1\x24\x1\xFFFF\x1\x24\x1\x65\x3\xFFFF\x1\x64"+
			"\x1\x24\x1\xFFFF";
		private const string DFA32_maxS =
			"\x1\x3000\x1\x75\x1\x79\x1\x75\x1\x79\x2\x6F\x1\x78\x1\x6E\x1\x65\x1"+
			"\x79\x1\x6F\x1\x69\x1\x62\x2\x6F\x1\x75\x6\xFFFF\x1\x39\x2\xFFFF\x1\x3D"+
			"\x1\x3E\x7\x3D\x1\x7C\x1\x3D\x3\xFFFF\x1\xFFFF\x3\xFFFF\x1\x78\x2\xFFFF"+
			"\x1\x6C\x1\x77\x1\x74\x1\x79\x1\x72\x1\x70\x1\x6C\x1\x6E\x1\x72\x1\x6E"+
			"\x1\x6F\x1\x65\x1\x6F\x2\x74\x1\x6E\x2\x61\x1\x6C\x1\x7A\x1\x73\x1\x75"+
			"\x1\x74\x2\x7A\x1\x70\x1\x74\x1\x69\x1\x6F\x1\x61\x1\x70\x1\x6E\x1\x72"+
			"\x1\x6C\x1\x69\x1\x74\x1\x73\x1\x74\x1\x6E\x1\x63\x1\x6F\x1\x62\x2\xFFFF"+
			"\x1\x3D\x2\xFFFF\x1\x3E\x1\xFFFF\x1\x3D\x1\xFFFF\x1\x3D\x13\xFFFF\x1"+
			"\xFFFF\x6\xFFFF\x1\x6C\x1\x7A\x1\x69\x1\x65\x1\x7A\x1\x6E\x1\x73\x1\x6F"+
			"\x1\x65\x1\x73\x1\x61\x1\x7A\x1\x63\x2\x61\x1\x6C\x2\x65\x1\x63\x1\x74"+
			"\x1\x72\x1\x73\x1\x61\x1\x65\x1\x75\x1\x62\x1\xFFFF\x1\x65\x1\x6D\x1"+
			"\x6F\x1\x65\x1\xFFFF\x1\x74\x1\x7A\x1\xFFFF\x1\x6F\x1\x75\x1\x74\x1\x72"+
			"\x1\x74\x1\x65\x1\x63\x1\x7A\x1\x64\x1\x61\x1\x6C\x1\x68\x1\x74\x1\x6F"+
			"\x1\x67\x1\x6B\x1\x76\x1\x74\x1\x6C\x2\xFFFF\x1\x3D\x7\xFFFF\x1\x7A\x1"+
			"\xFFFF\x1\x76\x1\x7A\x1\xFFFF\x1\x73\x1\x7A\x1\x77\x1\x6F\x1\x65\x1\x6C"+
			"\x1\xFFFF\x2\x74\x1\x6B\x1\x65\x2\x7A\x1\x68\x1\x69\x1\x74\x1\x7A\x1"+
			"\x73\x1\x75\x1\x74\x1\x67\x1\x6C\x2\x7A\x1\x72\x1\x6E\x1\x61\x1\x72\x1"+
			"\xFFFF\x1\x65\x2\x72\x1\x63\x1\x74\x1\x69\x1\x72\x1\x68\x1\xFFFF\x1\x7A"+
			"\x1\x74\x1\x65\x1\x7A\x1\x72\x2\x7A\x2\x61\x1\x65\x1\x69\x3\xFFFF\x1"+
			"\x65\x1\xFFFF\x1\x69\x1\xFFFF\x1\x7A\x1\x66\x2\x7A\x1\x69\x2\x7A\x1\x61"+
			"\x2\xFFFF\x1\x7A\x1\x6E\x1\x7A\x1\xFFFF\x1\x7A\x1\x6C\x1\x65\x1\x67\x1"+
			"\x65\x2\xFFFF\x1\x74\x1\x64\x1\x6E\x1\x66\x1\x6D\x1\x74\x1\x6E\x1\x68"+
			"\x1\x7A\x1\x63\x1\x7A\x1\x72\x1\xFFFF\x1\x69\x1\x7A\x1\xFFFF\x1\x61\x2"+
			"\xFFFF\x1\x67\x1\x74\x2\x63\x1\x7A\x1\x65\x1\x7A\x1\xFFFF\x1\x7A\x1\xFFFF"+
			"\x1\x79\x1\xFFFF\x1\x6F\x2\xFFFF\x1\x6E\x1\xFFFF\x1\x75\x2\xFFFF\x1\x74"+
			"\x1\x7A\x1\x65\x2\x7A\x1\x73\x1\x63\x1\x61\x1\x65\x3\x7A\x1\xFFFF\x1"+
			"\x7A\x1\xFFFF\x1\x6F\x1\x6C\x1\xFFFF\x1\x63\x2\x65\x1\x74\x1\x7A\x1\xFFFF"+
			"\x1\x6E\x2\xFFFF\x1\x7A\x1\x6E\x1\x7A\x1\x65\x1\x7A\x1\xFFFF\x1\x72\x2"+
			"\xFFFF\x1\x7A\x1\x65\x1\x63\x1\x6E\x4\xFFFF\x1\x6E\x1\x65\x1\x74\x2\x7A"+
			"\x1\x65\x1\xFFFF\x1\x74\x1\xFFFF\x1\x7A\x1\xFFFF\x1\x7A\x1\xFFFF\x1\x7A"+
			"\x1\xFFFF\x1\x6F\x1\x65\x1\x74\x1\x69\x2\x7A\x2\xFFFF\x1\x64\x1\x7A\x3"+
			"\xFFFF\x1\x66\x1\x7A\x1\x73\x1\x7A\x2\xFFFF\x1\x7A\x1\xFFFF\x1\x7A\x1"+
			"\xFFFF\x1\x7A\x1\x65\x3\xFFFF\x1\x64\x1\x7A\x1\xFFFF";
		private const string DFA32_acceptS =
			"\x11\xFFFF\x1\x3C\x1\x3D\x1\x3E\x1\x3F\x1\x40\x1\x41\x1\xFFFF\x1\x43"+
			"\x1\x44\xB\xFFFF\x1\x5A\x1\x5D\x1\x5E\x1\xFFFF\x1\x6C\x1\x6D\x1\x70\x1"+
			"\xFFFF\x1\x71\x1\x74\x2A\xFFFF\x1\x42\x1\x47\x1\xFFFF\x1\x45\x1\x48\x1"+
			"\xFFFF\x1\x46\x1\xFFFF\x1\x5F\x1\xFFFF\x1\x59\x1\x51\x1\x60\x1\x4D\x1"+
			"\x52\x1\x61\x1\x4E\x1\x62\x1\x4F\x1\x63\x1\x50\x1\x5B\x1\x67\x1\x56\x1"+
			"\x5C\x1\x68\x1\x57\x1\x69\x1\x58\x1\xFFFF\x1\x6E\x1\x6F\x1\x6A\x1\x75"+
			"\x1\x73\x1\x72\x1A\xFFFF\x1\xA\x4\xFFFF\x1\xF\x2\xFFFF\x1\x10\x13\xFFFF"+
			"\x1\x64\x1\x53\x1\xFFFF\x1\x65\x1\x54\x1\x4B\x1\x49\x1\x4C\x1\x4A\x1"+
			"\x6B\x1\xFFFF\x1\x12\x2\xFFFF\x1\x17\x6\xFFFF\x1\xD\x15\xFFFF\x1\x2D"+
			"\x8\xFFFF\x1\x19\xB\xFFFF\x1\x66\x1\x55\x1\x1\x1\xFFFF\x1\x2\x1\xFFFF"+
			"\x1\x15\x8\xFFFF\x1\x1F\x1\x5\x3\xFFFF\x1\x20\x5\xFFFF\x1\xB\x1\x25\xC"+
			"\xFFFF\x1\x1A\x2\xFFFF\x1\x1C\x1\xFFFF\x1\x2A\x1\x2F\x7\xFFFF\x1\x16"+
			"\x1\xFFFF\x1\x3\x1\xFFFF\x1\x28\x1\xFFFF\x1\x29\x1\x4\x1\xFFFF\x1\x6"+
			"\x1\xFFFF\x1\x22\x1\x21\xC\xFFFF\x1\x35\x1\xFFFF\x1\x37\x2\xFFFF\x1\x1B"+
			"\x5\xFFFF\x1\x30\x1\xFFFF\x1\x39\x1\x18\x5\xFFFF\x1\x9\x1\xFFFF\x1\x24"+
			"\x1\x26\x4\xFFFF\x1\x2C\x1\x13\x1\x14\x1\x36\x6\xFFFF\x1\x34\x1\xFFFF"+
			"\x1\xC\x1\xFFFF\x1\x1E\x1\xFFFF\x1\x8\x1\xFFFF\x1\x27\x6\xFFFF\x1\x31"+
			"\x1\x32\x2\xFFFF\x1\xE\x1\x7\x1\x23\x4\xFFFF\x1\x3B\x1\x1D\x1\xFFFF\x1"+
			"\x3A\x1\xFFFF\x1\x2E\x2\xFFFF\x1\x33\x1\x11\x1\x2B\x2\xFFFF\x1\x38";
		private const string DFA32_specialS =
			"\x28\xFFFF\x1\x0\x4D\xFFFF\x1\x1\x119\xFFFF}>";
		private static readonly string[] DFA32_transitionS =
			{
				"\x1\x29\x1\x2A\x2\x29\x1\x2A\x12\xFFFF\x1\x29\x1\x1D\x1\x2E\x2\xFFFF"+
				"\x1\x21\x1\x22\x1\x2E\x1\x13\x1\x14\x1\x20\x1\x1E\x1\x19\x1\x1F\x1\x17"+
				"\x1\x28\x1\x2C\x9\x2D\x1\x27\x1\x18\x1\x1A\x1\x1C\x1\x1B\x1\x26\x1B"+
				"\xFFFF\x1\x15\x1\xFFFF\x1\x16\x1\x24\x2\xFFFF\x1\xD\x1\x4\x1\x5\x1\x6"+
				"\x1\x7\x1\x3\x1\xE\x1\xFFFF\x1\x8\x2\xFFFF\x1\xF\x1\xFFFF\x1\x1\x1\xFFFF"+
				"\x1\x10\x1\xFFFF\x1\x9\x1\xA\x1\x2\x1\xFFFF\x1\xB\x1\xC\x3\xFFFF\x1"+
				"\x11\x1\x23\x1\x12\x1\x25\x21\xFFFF\x1\x29\x15DF\xFFFF\x1\x29\x18D\xFFFF"+
				"\x1\x29\x7F1\xFFFF\xB\x29\x1D\xFFFF\x2\x2A\x5\xFFFF\x1\x29\x2F\xFFFF"+
				"\x1\x29\xFA0\xFFFF\x1\x29",
				"\x1\x31\x3\xFFFF\x1\x30\xF\xFFFF\x1\x2F",
				"\x1\x33\x9\xFFFF\x1\x32\x6\xFFFF\x1\x34",
				"\x1\x35\x7\xFFFF\x1\x36\x2\xFFFF\x1\x39\x2\xFFFF\x1\x37\x5\xFFFF\x1"+
				"\x38",
				"\x1\x3B\x2\xFFFF\x1\x3A\x6\xFFFF\x1\x3C",
				"\x1\x3D\x6\xFFFF\x1\x3F\x3\xFFFF\x1\x40\x2\xFFFF\x1\x3E",
				"\x1\x41\x9\xFFFF\x1\x42",
				"\x1\x43\x1\xFFFF\x1\x44\x9\xFFFF\x1\x45",
				"\x1\x46\x6\xFFFF\x1\x48\x1\x47",
				"\x1\x49",
				"\x1\x4B\xB\xFFFF\x1\x4C\x1\x4D\x1\xFFFF\x1\x4A\x1\xFFFF\x1\x4E",
				"\x1\x4F\xD\xFFFF\x1\x50",
				"\x1\x51\x1\x52",
				"\x1\x53",
				"\x1\x54",
				"\x1\x55",
				"\x1\x56\x10\xFFFF\x1\x57\x2\xFFFF\x1\x58",
				"",
				"",
				"",
				"",
				"",
				"",
				"\xA\x2D",
				"",
				"",
				"\x1\x5B\x1\x5A",
				"\x1\x5D\x1\x5E",
				"\x1\x60",
				"\x1\x62",
				"\x1\x64\x11\xFFFF\x1\x65",
				"\x1\x67\xF\xFFFF\x1\x68",
				"\x1\x6A",
				"\x1\x6C",
				"\x1\x6E\x16\xFFFF\x1\x6F",
				"\x1\x72\x3E\xFFFF\x1\x71",
				"\x1\x74",
				"",
				"",
				"",
				"\xA\x7A\x1\xFFFF\x2\x7A\x1\xFFFF\x1C\x7A\x1\x77\x4\x7A\x1\x78\xD\x7A"+
				"\x1\x76\x1FEA\x7A\x2\xFFFF\xDFD6\x7A",
				"",
				"",
				"",
				"\x8\x7C\x20\xFFFF\x1\x7B\x1F\xFFFF\x1\x7B",
				"",
				"",
				"\x1\x7D",
				"\x1\x7E",
				"\x1\x7F",
				"\x1\x82\x13\xFFFF\x1\x80\x3\xFFFF\x1\x81",
				"\x1\x83\x8\xFFFF\x1\x84",
				"\x1\x85",
				"\x1\x86",
				"\x1\x87",
				"\x1\x88",
				"\x1\x89",
				"\x1\x8A",
				"\x1\x8B",
				"\x1\x8C",
				"\x1\x8D",
				"\x1\x8E\x1\x8F",
				"\x1\x90",
				"\x1\x91",
				"\x1\x92",
				"\x1\x95\x3\xFFFF\x1\x93\x5\xFFFF\x1\x94",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x14\x2B\x1\x96\x5\x2B",
				"\x1\x98",
				"\x1\x99",
				"\x1\x9A\x3\xFFFF\x1\x9B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x12\x2B\x1\x9D\x1\x9E\x6\x2B",
				"\x1\xA0",
				"\x1\xA1",
				"\x1\xA2",
				"\x1\xA3",
				"\x1\xA4",
				"\x1\xA5",
				"\x1\xA6",
				"\x1\xA7",
				"\x1\xA8\x2\xFFFF\x1\xA9",
				"\x1\xAA",
				"\x1\xAB",
				"\x1\xAC",
				"\x1\xAD",
				"\x1\xAE",
				"\x1\xAF",
				"\x1\xB0\x5\xFFFF\x1\xB1",
				"\x1\xB2",
				"",
				"",
				"\x1\xB3",
				"",
				"",
				"\x1\xB6\x1\xB5",
				"",
				"\x1\xB8",
				"",
				"\x1\xBA",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\xA\x7A\x1\xFFFF\x2\x7A\x1\xFFFF\x201A\x7A\x2\xFFFF\xDFD6\x7A",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\xBD",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\xBF",
				"\x1\xC0",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\xC2",
				"\x1\xC3",
				"\x1\xC4",
				"\x1\xC5",
				"\x1\xC6",
				"\x1\xC7",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\xC9",
				"\x1\xCA",
				"\x1\xCB",
				"\x1\xCC",
				"\x1\xCD",
				"\x1\xCE",
				"\x1\xCF",
				"\x1\xD1\x1\xD0",
				"\x1\xD2",
				"\x1\xD3",
				"\x1\xD4",
				"\x1\xD5",
				"\x1\xD6",
				"\x1\xD7",
				"",
				"\x1\xD8",
				"\x1\xD9",
				"\x1\xDA",
				"\x1\xDB",
				"",
				"\x1\xDC",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x4\x2B\x1\xDD\x15\x2B",
				"",
				"\x1\xDF\x2\xFFFF\x1\xE0",
				"\x1\xE1",
				"\x1\xE2",
				"\x1\xE3",
				"\x1\xE4",
				"\x1\xE5",
				"\x1\xE6",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\xE8",
				"\x1\xE9",
				"\x1\xEA",
				"\x1\xEB",
				"\x1\xEC",
				"\x1\xED",
				"\x1\xEE",
				"\x1\xEF",
				"\x1\xF0",
				"\x1\xF1",
				"\x1\xF2",
				"",
				"",
				"\x1\xF3",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\xF6",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\xF8",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\xFA",
				"\x1\xFB",
				"\x1\xFC",
				"\x1\xFD",
				"",
				"\x1\xFE",
				"\x1\xFF",
				"\x1\x100",
				"\x1\x101",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x104",
				"\x1\x105",
				"\x1\x106",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x108",
				"\x1\x109",
				"\x1\x10A",
				"\x1\x10B",
				"\x1\x10C",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x10F",
				"\x1\x110",
				"\x1\x111",
				"\x1\x112",
				"",
				"\x1\x113",
				"\x1\x114",
				"\x1\x115",
				"\x1\x116",
				"\x1\x117",
				"\x1\x118",
				"\x1\x119",
				"\x1\x11A",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x11C",
				"\x1\x11D",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x11F",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x122",
				"\x1\x123",
				"\x1\x124",
				"\x1\x125",
				"",
				"",
				"",
				"\x1\x126",
				"",
				"\x1\x127",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x12\x2B\x1\x128\x7\x2B",
				"\x1\x12A",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\xB\x2B\x1\x12C\xE\x2B",
				"\x1\x12E",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x131",
				"",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x133",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x136",
				"\x1\x137",
				"\x1\x138",
				"\x1\x139",
				"",
				"",
				"\x1\x13A",
				"\x1\x13B",
				"\x1\x13C",
				"\x1\x13D",
				"\x1\x13E",
				"\x1\x13F",
				"\x1\x140",
				"\x1\x141",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x143",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x145",
				"",
				"\x1\x146",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x148",
				"",
				"",
				"\x1\x149",
				"\x1\x14A",
				"\x1\x14B",
				"\x1\x14C",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x14E",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x151",
				"",
				"\x1\x152",
				"",
				"",
				"\x1\x153",
				"",
				"\x1\x154",
				"",
				"",
				"\x1\x155",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x157",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x15A",
				"\x1\x15B",
				"\x1\x15C",
				"\x1\x15D",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x162",
				"\x1\x163",
				"",
				"\x1\x164",
				"\x1\x165",
				"\x1\x166",
				"\x1\x167",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x169",
				"",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x16B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x16D",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x16F",
				"",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x171",
				"\x1\x172",
				"\x1\x173",
				"",
				"",
				"",
				"",
				"\x1\x174",
				"\x1\x175",
				"\x1\x176",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x179",
				"",
				"\x1\x17A",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x17E",
				"\x1\x17F",
				"\x1\x180",
				"\x1\x181",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"",
				"\x1\x184",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"",
				"",
				"\x1\x186",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x188",
				"\x1\x189",
				"",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x18D",
				"",
				"",
				"",
				"\x1\x18E",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF"+
				"\x1\x2B\x1\xFFFF\x1A\x2B",
				""
			};

		private static readonly short[] DFA32_eot = DFA.UnpackEncodedString(DFA32_eotS);
		private static readonly short[] DFA32_eof = DFA.UnpackEncodedString(DFA32_eofS);
		private static readonly char[] DFA32_min = DFA.UnpackEncodedStringToUnsignedChars(DFA32_minS);
		private static readonly char[] DFA32_max = DFA.UnpackEncodedStringToUnsignedChars(DFA32_maxS);
		private static readonly short[] DFA32_accept = DFA.UnpackEncodedString(DFA32_acceptS);
		private static readonly short[] DFA32_special = DFA.UnpackEncodedString(DFA32_specialS);
		private static readonly short[][] DFA32_transition;

		static DFA32()
		{
			int numStates = DFA32_transitionS.Length;
			DFA32_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA32_transition[i] = DFA.UnpackEncodedString(DFA32_transitionS[i]);
			}
		}

		public DFA32( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 32;
			this.eot = DFA32_eot;
			this.eof = DFA32_eof;
			this.min = DFA32_min;
			this.max = DFA32_max;
			this.accept = DFA32_accept;
			this.special = DFA32_special;
			this.transition = DFA32_transition;
		}

		public override string Description { get { return "1:1: Tokens : ( NULL | TRUE | FALSE | BREAK | CASE | CATCH | CONTINUE | DEFAULT | DELETE | DO | ELSE | FINALLY | FOR | FUNCTION | IF | IN | INSTANCEOF | NEW | RETURN | SWITCH | THIS | THROW | TRY | TYPEOF | VAR | VOID | WHILE | WITH | ABSTRACT | BOOLEAN | BYTE | CHAR | CLASS | CONST | DEBUGGER | DOUBLE | ENUM | EXPORT | EXTENDS | FINAL | FLOAT | GOTO | IMPLEMENTS | IMPORT | INT | INTERFACE | LONG | NATIVE | PACKAGE | PRIVATE | PROTECTED | PUBLIC | SHORT | STATIC | SUPER | SYNCHRONIZED | THROWS | TRANSIENT | VOLATILE | LBRACE | RBRACE | LPAREN | RPAREN | LBRACK | RBRACK | DOT | SEMIC | COMMA | LT | GT | LTE | GTE | EQ | NEQ | SAME | NSAME | ADD | SUB | MUL | MOD | INC | DEC | SHL | SHR | SHU | AND | OR | XOR | NOT | INV | LAND | LOR | QUE | COLON | ASSIGN | ADDASS | SUBASS | MULASS | MODASS | SHLASS | SHRASS | SHUASS | ANDASS | ORASS | XORASS | DIV | DIVASS | WhiteSpace | EOL | MultiLineComment | SingleLineComment | Identifier | DecimalLiteral | OctalIntegerLiteral | HexIntegerLiteral | StringLiteral | RegularExpressionLiteral );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition32(DFA dfa, int s, IIntStream _input)
	{
		IIntStream input = _input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA32_40 = input.LA(1);


				int index32_40 = input.Index;
				input.Rewind();
				s = -1;
				if ( (LA32_40=='=') ) {s = 118;}

				else if ( (LA32_40=='*') ) {s = 119;}

				else if ( (LA32_40=='/') ) {s = 120;}

				else if ( ((LA32_40>='\u0000' && LA32_40<='\t')||(LA32_40>='\u000B' && LA32_40<='\f')||(LA32_40>='\u000E' && LA32_40<=')')||(LA32_40>='+' && LA32_40<='.')||(LA32_40>='0' && LA32_40<='<')||(LA32_40>='>' && LA32_40<='\u2027')||(LA32_40>='\u202A' && LA32_40<='\uFFFF')) && (( AreRegularExpressionsEnabled() ))) {s = 122;}

				else s = 121;


				input.Seek(index32_40);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA32_118 = input.LA(1);


				int index32_118 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((LA32_118>='\u0000' && LA32_118<='\t')||(LA32_118>='\u000B' && LA32_118<='\f')||(LA32_118>='\u000E' && LA32_118<='\u2027')||(LA32_118>='\u202A' && LA32_118<='\uFFFF')) && (( AreRegularExpressionsEnabled() ))) {s = 122;}

				else s = 188;


				input.Seek(index32_118);
				if ( s>=0 ) return s;
				break;
		}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 32, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
 
	#endregion

}
