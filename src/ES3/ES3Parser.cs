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

namespace ncoverjs.ES3
{
    public class ES3Parser : Parser
    {
        public override string[] TokenNames
        {
            get
            {
                return new[]
                    {
                        "<invalid>",
                        "<EOR>",
                        "<DOWN>",
                        "<UP>",
                        "NULL",
                        "TRUE",
                        "FALSE",
                        "BREAK",
                        "CASE",
                        "CATCH",
                        "CONTINUE",
                        "DEFAULT",
                        "DELETE",
                        "DO",
                        "ELSE",
                        "FINALLY",
                        "FOR",
                        "FUNCTION",
                        "IF",
                        "IN",
                        "INSTANCEOF",
                        "NEW",
                        "RETURN",
                        "SWITCH",
                        "THIS",
                        "THROW",
                        "TRY",
                        "TYPEOF",
                        "VAR",
                        "VOID",
                        "WHILE",
                        "WITH",
                        "ABSTRACT",
                        "BOOLEAN",
                        "BYTE",
                        "CHAR",
                        "CLASS",
                        "CONST",
                        "DEBUGGER",
                        "DOUBLE",
                        "ENUM",
                        "EXPORT",
                        "EXTENDS",
                        "FINAL",
                        "FLOAT",
                        "GOTO",
                        "IMPLEMENTS",
                        "IMPORT",
                        "INT",
                        "INTERFACE",
                        "LONG",
                        "NATIVE",
                        "PACKAGE",
                        "PRIVATE",
                        "PROTECTED",
                        "PUBLIC",
                        "SHORT",
                        "STATIC",
                        "SUPER",
                        "SYNCHRONIZED",
                        "THROWS",
                        "TRANSIENT",
                        "VOLATILE",
                        "LBRACE",
                        "RBRACE",
                        "LPAREN",
                        "RPAREN",
                        "LBRACK",
                        "RBRACK",
                        "DOT",
                        "SEMIC",
                        "COMMA",
                        "LT",
                        "GT",
                        "LTE",
                        "GTE",
                        "EQ",
                        "NEQ",
                        "SAME",
                        "NSAME",
                        "ADD",
                        "SUB",
                        "MUL",
                        "MOD",
                        "INC",
                        "DEC",
                        "SHL",
                        "SHR",
                        "SHU",
                        "AND",
                        "OR",
                        "XOR",
                        "NOT",
                        "INV",
                        "LAND",
                        "LOR",
                        "QUE",
                        "COLON",
                        "ASSIGN",
                        "ADDASS",
                        "SUBASS",
                        "MULASS",
                        "MODASS",
                        "SHLASS",
                        "SHRASS",
                        "SHUASS",
                        "ANDASS",
                        "ORASS",
                        "XORASS",
                        "DIV",
                        "DIVASS",
                        "ARGS",
                        "ARRAY",
                        "BLOCK",
                        "BYFIELD",
                        "BYINDEX",
                        "CALL",
                        "CEXPR",
                        "EXPR",
                        "FORITER",
                        "FORSTEP",
                        "ITEM",
                        "LABELLED",
                        "NAMEDVALUE",
                        "NEG",
                        "OBJECT",
                        "PAREXPR",
                        "PDEC",
                        "PINC",
                        "POS",
                        "BSLASH",
                        "DQUOTE",
                        "SQUOTE",
                        "TAB",
                        "VT",
                        "FF",
                        "SP",
                        "NBSP",
                        "USP",
                        "WhiteSpace",
                        "LF",
                        "CR",
                        "LS",
                        "PS",
                        "LineTerminator",
                        "EOL",
                        "MultiLineComment",
                        "SingleLineComment",
                        "Identifier",
                        "StringLiteral",
                        "HexDigit",
                        "IdentifierStartASCII",
                        "DecimalDigit",
                        "IdentifierPart",
                        "IdentifierNameASCIIStart",
                        "RegularExpressionLiteral",
                        "OctalDigit",
                        "ExponentPart",
                        "DecimalIntegerLiteral",
                        "DecimalLiteral",
                        "OctalIntegerLiteral",
                        "HexIntegerLiteral",
                        "CharacterEscapeSequence",
                        "ZeroToThree",
                        "OctalEscapeSequence",
                        "HexEscapeSequence",
                        "UnicodeEscapeSequence",
                        "EscapeSequence",
                        "BackslashSequence",
                        "RegularExpressionFirstChar",
                        "RegularExpressionChar"
                    };
            }
        }

        public const int VT = 134;
        public const int LOR = 95;
        public const int FUNCTION = 17;
        public const int PACKAGE = 52;
        public const int SHR = 87;
        public const int RegularExpressionChar = 170;
        public const int LT = 72;
        public const int WHILE = 30;
        public const int MOD = 83;
        public const int SHL = 86;
        public const int CONST = 37;
        public const int BackslashSequence = 168;
        public const int LS = 142;
        public const int CASE = 8;
        public const int CHAR = 35;
        public const int NEW = 21;
        public const int DQUOTE = 131;
        public const int DO = 13;
        public const int NOT = 92;
        public const int DecimalDigit = 152;
        public const int BYFIELD = 114;
        public const int EOF = -1;
        public const int CEXPR = 117;
        public const int BREAK = 7;
        public const int Identifier = 148;
        public const int DIVASS = 110;
        public const int BYINDEX = 115;
        public const int FORSTEP = 120;
        public const int FINAL = 43;
        public const int RPAREN = 66;
        public const int INC = 84;
        public const int IMPORT = 47;
        public const int EOL = 145;
        public const int POS = 129;
        public const int OctalDigit = 156;
        public const int THIS = 24;
        public const int RETURN = 22;
        public const int ExponentPart = 157;
        public const int ARGS = 111;
        public const int DOUBLE = 39;
        public const int WhiteSpace = 139;
        public const int VAR = 28;
        public const int EXPORT = 41;
        public const int VOID = 29;
        public const int LABELLED = 122;
        public const int SUPER = 58;
        public const int GOTO = 45;
        public const int EQ = 76;
        public const int XORASS = 108;
        public const int ADDASS = 99;
        public const int ARRAY = 112;
        public const int SHU = 88;
        public const int RBRACK = 68;
        public const int RBRACE = 64;
        public const int PRIVATE = 53;
        public const int STATIC = 57;
        public const int INV = 93;
        public const int SWITCH = 23;
        public const int NULL = 4;
        public const int ELSE = 14;
        public const int NATIVE = 51;
        public const int THROWS = 60;
        public const int INT = 48;
        public const int DELETE = 12;
        public const int MUL = 82;
        public const int IdentifierStartASCII = 151;
        public const int TRY = 26;
        public const int FF = 135;
        public const int SHLASS = 103;
        public const int OctalEscapeSequence = 164;
        public const int USP = 138;
        public const int RegularExpressionFirstChar = 169;
        public const int ANDASS = 106;
        public const int TYPEOF = 27;
        public const int IdentifierNameASCIIStart = 154;
        public const int QUE = 96;
        public const int OR = 90;
        public const int DEBUGGER = 38;
        public const int GT = 73;
        public const int PDEC = 127;
        public const int CALL = 116;
        public const int CharacterEscapeSequence = 162;
        public const int CATCH = 9;
        public const int FALSE = 6;
        public const int EscapeSequence = 167;
        public const int LAND = 94;
        public const int MULASS = 101;
        public const int THROW = 25;
        public const int PINC = 128;
        public const int OctalIntegerLiteral = 160;
        public const int PROTECTED = 54;
        public const int DEC = 85;
        public const int CLASS = 36;
        public const int LBRACK = 67;
        public const int HexEscapeSequence = 165;
        public const int ORASS = 107;
        public const int SingleLineComment = 147;
        public const int NAMEDVALUE = 123;
        public const int LBRACE = 63;
        public const int GTE = 75;
        public const int FOR = 16;
        public const int RegularExpressionLiteral = 155;
        public const int SUB = 81;
        public const int FLOAT = 44;
        public const int ABSTRACT = 32;
        public const int AND = 89;
        public const int DecimalIntegerLiteral = 158;
        public const int HexDigit = 150;
        public const int LTE = 74;
        public const int LPAREN = 65;
        public const int IF = 18;
        public const int SUBASS = 100;
        public const int EXPR = 118;
        public const int BOOLEAN = 33;
        public const int SYNCHRONIZED = 59;
        public const int IN = 19;
        public const int IMPLEMENTS = 46;
        public const int OBJECT = 125;
        public const int CONTINUE = 10;
        public const int COMMA = 71;
        public const int FORITER = 119;
        public const int TRANSIENT = 61;
        public const int SHRASS = 104;
        public const int MODASS = 102;
        public const int PS = 143;
        public const int DOT = 69;
        public const int IdentifierPart = 153;
        public const int MultiLineComment = 146;
        public const int WITH = 31;
        public const int ADD = 80;
        public const int BYTE = 34;
        public const int XOR = 91;
        public const int ZeroToThree = 163;
        public const int ITEM = 121;
        public const int VOLATILE = 62;
        public const int UnicodeEscapeSequence = 166;
        public const int SHUASS = 105;
        public const int DEFAULT = 11;
        public const int NSAME = 79;
        public const int TAB = 133;
        public const int SHORT = 56;
        public const int INSTANCEOF = 20;
        public const int SQUOTE = 132;
        public const int DecimalLiteral = 159;
        public const int TRUE = 5;
        public const int SAME = 78;
        public const int StringLiteral = 149;
        public const int COLON = 97;
        public const int PAREXPR = 126;
        public const int NEQ = 77;
        public const int ENUM = 40;
        public const int FINALLY = 15;
        public const int HexIntegerLiteral = 161;
        public const int NBSP = 137;
        public const int SP = 136;
        public const int BLOCK = 113;
        public const int LineTerminator = 144;
        public const int NEG = 124;
        public const int ASSIGN = 98;
        public const int INTERFACE = 49;
        public const int DIV = 109;
        public const int SEMIC = 70;
        public const int CR = 141;
        public const int LONG = 50;
        public const int EXTENDS = 42;
        public const int PUBLIC = 55;
        public const int BSLASH = 130;
        public const int LF = 140;

        public ES3Parser(ITokenStream input)
            : this(input, new RecognizerSharedState())
        {
        }

        public ES3Parser(ITokenStream input, RecognizerSharedState state)
            : base(input, state)
        {
            InitializeCyclicDFAs();
            TemplateLib = new StringTemplateGroup("ES3YUITestParserTemplates", typeof(AngleBracketTemplateLexer));
        }

        public StringTemplateGroup TemplateLib { get; set; }

        /// <summary> Allows convenient multi-value initialization:
        ///  "new STAttrMap().Add(...).Add(...)"
        /// </summary>
        protected class STAttrMap : Hashtable
        {
            public STAttrMap Add(string attrName, object value)
            {
                base.Add(attrName, value);
                return this;
            }

            public STAttrMap Add(string attrName, int value)
            {
                base.Add(attrName, value);
                return this;
            }
        }

        public override string GrammarFileName
        {
            get { return "C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g"; }
        }

        public bool Verbose { get; set; }

        private bool isLeftHandSideAssign(IRuleReturnScope lhs, IList<object> cached)
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

        private string wrapInBraces(IToken start, IToken stop, ITokenStream tokens)
        {
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

        private static string ToObjectLiteral<T>(IList<T> list, bool numbers)
        {
            var builder = new StringBuilder();
            builder.Append("{");
            for (var i = 0; i < list.Count; i++)
            {

                if (i > 0)
                {
                    builder.Append(",");
                }

                if (numbers)
                {
                    builder.Append('"');
                    builder.Append(list[i]);
                    builder.Append("\":0");
                }
                else
                {
                    builder.Append(list[i]);
                    builder.Append(":0");
                }
            }
            builder.Append("}");
            return builder.ToString();
        }

        private static bool IsLeftHandSideExpression(IRuleReturnScope lhs)
        {
            if (lhs.Tree == null) // e.g. during backtracking
            {
                return true;
            }

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

        private bool IsLeftHandSideIn(RuleReturnScope lhs, IList<object> cached)
        {
            if (cached[0] != null)
            {
                return (bool)cached[0];
            }

            var result = IsLeftHandSideExpression(lhs) && (input.LA(1) == IN);
            cached[0] = result;
            return result;
        }

        private void PromoteEol(ParserRuleReturnScope rule)
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
                for (var ix = lt.TokenIndex - 1; ix > 0; ix--)
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


        public class token_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "token"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:580:1: token : ( reservedWord | Identifier | punctuator | numericLiteral | StringLiteral );
        public token_return token() // throws RecognitionException [1]
        {
            var retval = new token_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:581:2: ( reservedWord | Identifier | punctuator | numericLiteral | StringLiteral )
                var alt1 = 5;
                switch (input.LA(1))
                {
                    case NULL:
                    case TRUE:
                    case FALSE:
                    case BREAK:
                    case CASE:
                    case CATCH:
                    case CONTINUE:
                    case DEFAULT:
                    case DELETE:
                    case DO:
                    case ELSE:
                    case FINALLY:
                    case FOR:
                    case FUNCTION:
                    case IF:
                    case IN:
                    case INSTANCEOF:
                    case NEW:
                    case RETURN:
                    case SWITCH:
                    case THIS:
                    case THROW:
                    case TRY:
                    case TYPEOF:
                    case VAR:
                    case VOID:
                    case WHILE:
                    case WITH:
                    case ABSTRACT:
                    case BOOLEAN:
                    case BYTE:
                    case CHAR:
                    case CLASS:
                    case CONST:
                    case DEBUGGER:
                    case DOUBLE:
                    case ENUM:
                    case EXPORT:
                    case EXTENDS:
                    case FINAL:
                    case FLOAT:
                    case GOTO:
                    case IMPLEMENTS:
                    case IMPORT:
                    case INT:
                    case INTERFACE:
                    case LONG:
                    case NATIVE:
                    case PACKAGE:
                    case PRIVATE:
                    case PROTECTED:
                    case PUBLIC:
                    case SHORT:
                    case STATIC:
                    case SUPER:
                    case SYNCHRONIZED:
                    case THROWS:
                    case TRANSIENT:
                    case VOLATILE:
                        {
                            alt1 = 1;
                        }
                        break;
                    case Identifier:
                        {
                            alt1 = 2;
                        }
                        break;
                    case LBRACE:
                    case RBRACE:
                    case LPAREN:
                    case RPAREN:
                    case LBRACK:
                    case RBRACK:
                    case DOT:
                    case SEMIC:
                    case COMMA:
                    case LT:
                    case GT:
                    case LTE:
                    case GTE:
                    case EQ:
                    case NEQ:
                    case SAME:
                    case NSAME:
                    case ADD:
                    case SUB:
                    case MUL:
                    case MOD:
                    case INC:
                    case DEC:
                    case SHL:
                    case SHR:
                    case SHU:
                    case AND:
                    case OR:
                    case XOR:
                    case NOT:
                    case INV:
                    case LAND:
                    case LOR:
                    case QUE:
                    case COLON:
                    case ASSIGN:
                    case ADDASS:
                    case SUBASS:
                    case MULASS:
                    case MODASS:
                    case SHLASS:
                    case SHRASS:
                    case SHUASS:
                    case ANDASS:
                    case ORASS:
                    case XORASS:
                    case DIV:
                    case DIVASS:
                        {
                            alt1 = 3;
                        }
                        break;
                    case DecimalLiteral:
                    case OctalIntegerLiteral:
                    case HexIntegerLiteral:
                        {
                            alt1 = 4;
                        }
                        break;
                    case StringLiteral:
                        {
                            alt1 = 5;
                        }
                        break;
                    default:
                        throw new NoViableAltException("", 1, 0, input);
                }

                switch (alt1)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:581:4: reservedWord
                        {
                            PushFollow(FOLLOW_reservedWord_in_token1762);
                            ReservedWord();
                            state.followingStackPointer--;
                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:582:4: Identifier
                        {
                            Match(input, Identifier, FOLLOW_Identifier_in_token1767);
                        }
                        break;
                    case 3:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:583:4: punctuator
                        {
                            PushFollow(FOLLOW_punctuator_in_token1772);
                            punctuator();
                            state.followingStackPointer--;
                        }
                        break;
                    case 4:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:584:4: numericLiteral
                        {
                            PushFollow(FOLLOW_numericLiteral_in_token1777);
                            numericLiteral();
                            state.followingStackPointer--;
                        }
                        break;
                    case 5:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:585:4: StringLiteral
                        {
                            Match(input, StringLiteral, FOLLOW_StringLiteral_in_token1782);
                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            return retval;
        }

        // $ANTLR end "token"
        public class reservedWord_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "reservedWord"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:590:1: reservedWord : ( keyword | futureReservedWord | NULL | booleanLiteral );
        public reservedWord_return ReservedWord() // throws RecognitionException [1]
        {
            var retval = new reservedWord_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:591:2: ( keyword | futureReservedWord | NULL | booleanLiteral )
                var alt2 = 4;
                switch (input.LA(1))
                {
                    case BREAK:
                    case CASE:
                    case CATCH:
                    case CONTINUE:
                    case DEFAULT:
                    case DELETE:
                    case DO:
                    case ELSE:
                    case FINALLY:
                    case FOR:
                    case FUNCTION:
                    case IF:
                    case IN:
                    case INSTANCEOF:
                    case NEW:
                    case RETURN:
                    case SWITCH:
                    case THIS:
                    case THROW:
                    case TRY:
                    case TYPEOF:
                    case VAR:
                    case VOID:
                    case WHILE:
                    case WITH:
                        {
                            alt2 = 1;
                        }
                        break;
                    case ABSTRACT:
                    case BOOLEAN:
                    case BYTE:
                    case CHAR:
                    case CLASS:
                    case CONST:
                    case DEBUGGER:
                    case DOUBLE:
                    case ENUM:
                    case EXPORT:
                    case EXTENDS:
                    case FINAL:
                    case FLOAT:
                    case GOTO:
                    case IMPLEMENTS:
                    case IMPORT:
                    case INT:
                    case INTERFACE:
                    case LONG:
                    case NATIVE:
                    case PACKAGE:
                    case PRIVATE:
                    case PROTECTED:
                    case PUBLIC:
                    case SHORT:
                    case STATIC:
                    case SUPER:
                    case SYNCHRONIZED:
                    case THROWS:
                    case TRANSIENT:
                    case VOLATILE:
                        {
                            alt2 = 2;
                        }
                        break;
                    case NULL:
                        {
                            alt2 = 3;
                        }
                        break;
                    case TRUE:
                    case FALSE:
                        {
                            alt2 = 4;
                        }
                        break;
                    default:
                        throw new NoViableAltException("", 2, 0, input);
                }

                switch (alt2)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:591:4: keyword
                        {
                            PushFollow(FOLLOW_keyword_in_reservedWord1795);
                            keyword();
                            state.followingStackPointer--;


                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:592:4: futureReservedWord
                        {
                            PushFollow(FOLLOW_futureReservedWord_in_reservedWord1800);
                            FutureReservedWord();
                            state.followingStackPointer--;


                        }
                        break;
                    case 3:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:593:4: NULL
                        {
                            Match(input, NULL, FOLLOW_NULL_in_reservedWord1805);

                        }
                        break;
                    case 4:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:594:4: booleanLiteral
                        {
                            PushFollow(FOLLOW_booleanLiteral_in_reservedWord1810);
                            booleanLiteral();
                            state.followingStackPointer--;


                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "reservedWord"
        public class keyword_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "keyword"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:601:1: keyword : ( BREAK | CASE | CATCH | CONTINUE | DEFAULT | DELETE | DO | ELSE | FINALLY | FOR | FUNCTION | IF | IN | INSTANCEOF | NEW | RETURN | SWITCH | THIS | THROW | TRY | TYPEOF | VAR | VOID | WHILE | WITH );
        public keyword_return keyword() // throws RecognitionException [1]
        {
            var retval = new keyword_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:602:2: ( BREAK | CASE | CATCH | CONTINUE | DEFAULT | DELETE | DO | ELSE | FINALLY | FOR | FUNCTION | IF | IN | INSTANCEOF | NEW | RETURN | SWITCH | THIS | THROW | TRY | TYPEOF | VAR | VOID | WHILE | WITH )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:
                {
                    if ((input.LA(1) >= BREAK && input.LA(1) <= WITH))
                    {
                        input.Consume();
                        state.errorRecovery = false;
                    }
                    else
                    {
                        throw new MismatchedSetException(null, input);
                    }
                }

                retval.Stop = input.LT(-1);
            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "keyword"
        public class futureReservedWord_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "futureReservedWord"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:633:1: futureReservedWord : ( ABSTRACT | BOOLEAN | BYTE | CHAR | CLASS | CONST | DEBUGGER | DOUBLE | ENUM | EXPORT | EXTENDS | FINAL | FLOAT | GOTO | IMPLEMENTS | IMPORT | INT | INTERFACE | LONG | NATIVE | PACKAGE | PRIVATE | PROTECTED | PUBLIC | SHORT | STATIC | SUPER | SYNCHRONIZED | THROWS | TRANSIENT | VOLATILE );
        public futureReservedWord_return FutureReservedWord() // throws RecognitionException [1]
        {
            var retval = new futureReservedWord_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:634:2: ( ABSTRACT | BOOLEAN | BYTE | CHAR | CLASS | CONST | DEBUGGER | DOUBLE | ENUM | EXPORT | EXTENDS | FINAL | FLOAT | GOTO | IMPLEMENTS | IMPORT | INT | INTERFACE | LONG | NATIVE | PACKAGE | PRIVATE | PROTECTED | PUBLIC | SHORT | STATIC | SUPER | SYNCHRONIZED | THROWS | TRANSIENT | VOLATILE )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:
                {
                    if ((input.LA(1) >= ABSTRACT && input.LA(1) <= VOLATILE))
                    {
                        input.Consume();
                        state.errorRecovery = false;
                    }
                    else
                    {
                        throw new MismatchedSetException(null, input);
                    }
                }

                retval.Stop = input.LT(-1);
            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "futureReservedWord"
        public class punctuator_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "punctuator"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:711:1: punctuator : ( LBRACE | RBRACE | LPAREN | RPAREN | LBRACK | RBRACK | DOT | SEMIC | COMMA | LT | GT | LTE | GTE | EQ | NEQ | SAME | NSAME | ADD | SUB | MUL | MOD | INC | DEC | SHL | SHR | SHU | AND | OR | XOR | NOT | INV | LAND | LOR | QUE | COLON | ASSIGN | ADDASS | SUBASS | MULASS | MODASS | SHLASS | SHRASS | SHUASS | ANDASS | ORASS | XORASS | DIV | DIVASS );
        public punctuator_return punctuator() // throws RecognitionException [1]
        {
            var retval = new punctuator_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:712:2: ( LBRACE | RBRACE | LPAREN | RPAREN | LBRACK | RBRACK | DOT | SEMIC | COMMA | LT | GT | LTE | GTE | EQ | NEQ | SAME | NSAME | ADD | SUB | MUL | MOD | INC | DEC | SHL | SHR | SHU | AND | OR | XOR | NOT | INV | LAND | LOR | QUE | COLON | ASSIGN | ADDASS | SUBASS | MULASS | MODASS | SHLASS | SHRASS | SHUASS | ANDASS | ORASS | XORASS | DIV | DIVASS )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:
                {
                    if ((input.LA(1) >= LBRACE && input.LA(1) <= DIVASS))
                    {
                        input.Consume();
                        state.errorRecovery = false;
                    }
                    else
                    {
                        throw new MismatchedSetException(null, input);
                    }
                }

                retval.Stop = input.LT(-1);
            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "punctuator"
        public class literal_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "literal"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:766:1: literal : ( NULL | booleanLiteral | numericLiteral | StringLiteral | RegularExpressionLiteral );
        public literal_return literal() // throws RecognitionException [1]
        {
            var retval = new literal_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:767:2: ( NULL | booleanLiteral | numericLiteral | StringLiteral | RegularExpressionLiteral )
                var alt3 = 5;
                switch (input.LA(1))
                {
                    case NULL:
                        {
                            alt3 = 1;
                        }
                        break;
                    case TRUE:
                    case FALSE:
                        {
                            alt3 = 2;
                        }
                        break;
                    case DecimalLiteral:
                    case OctalIntegerLiteral:
                    case HexIntegerLiteral:
                        {
                            alt3 = 3;
                        }
                        break;
                    case StringLiteral:
                        {
                            alt3 = 4;
                        }
                        break;
                    case RegularExpressionLiteral:
                        {
                            alt3 = 5;
                        }
                        break;
                    default:
                        throw new NoViableAltException("", 3, 0, input);
                }

                switch (alt3)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:767:4: NULL
                        {
                            Match(input, NULL, FOLLOW_NULL_in_literal2491);
                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:768:4: booleanLiteral
                        {
                            PushFollow(FOLLOW_booleanLiteral_in_literal2496);
                            booleanLiteral();
                            state.followingStackPointer--;
                        }
                        break;
                    case 3:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:769:4: numericLiteral
                        {
                            PushFollow(FOLLOW_numericLiteral_in_literal2501);
                            numericLiteral();
                            state.followingStackPointer--;
                        }
                        break;
                    case 4:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:770:4: StringLiteral
                        {
                            Match(input, StringLiteral, FOLLOW_StringLiteral_in_literal2506);
                        }
                        break;
                    case 5:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:771:4: RegularExpressionLiteral
                        {
                            Match(input, RegularExpressionLiteral, FOLLOW_RegularExpressionLiteral_in_literal2511);
                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "literal"
        public class booleanLiteral_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "booleanLiteral"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:774:1: booleanLiteral : ( TRUE | FALSE );
        public booleanLiteral_return booleanLiteral() // throws RecognitionException [1]
        {
            var retval = new booleanLiteral_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:775:2: ( TRUE | FALSE )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:
                {
                    if ((input.LA(1) >= TRUE && input.LA(1) <= FALSE))
                    {
                        input.Consume();
                        state.errorRecovery = false;
                    }
                    else
                    {
                        throw new MismatchedSetException(null, input);
                    }
                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "booleanLiteral"

        public class numericLiteral_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "numericLiteral"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:821:1: numericLiteral : ( DecimalLiteral | OctalIntegerLiteral | HexIntegerLiteral );
        public numericLiteral_return numericLiteral() // throws RecognitionException [1]
        {
            var retval = new numericLiteral_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:822:2: ( DecimalLiteral | OctalIntegerLiteral | HexIntegerLiteral )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:
                {
                    if ((input.LA(1) >= DecimalLiteral && input.LA(1) <= HexIntegerLiteral))
                    {
                        input.Consume();
                        state.errorRecovery = false;
                    }
                    else
                    {
                        throw new MismatchedSetException(null, input);
                    }
                }

                retval.Stop = input.LT(-1);
            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "numericLiteral"

        public class primaryExpression_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "primaryExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:909:1: primaryExpression : ( THIS | Identifier | literal | arrayLiteral | objectLiteral | lpar= LPAREN expression RPAREN );
        public primaryExpression_return primaryExpression() // throws RecognitionException [1]
        {
            var retval = new primaryExpression_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:910:2: ( THIS | Identifier | literal | arrayLiteral | objectLiteral | lpar= LPAREN expression RPAREN )
                var alt4 = 6;
                switch (input.LA(1))
                {
                    case THIS:
                        {
                            alt4 = 1;
                        }
                        break;
                    case Identifier:
                        {
                            alt4 = 2;
                        }
                        break;
                    case NULL:
                    case TRUE:
                    case FALSE:
                    case StringLiteral:
                    case RegularExpressionLiteral:
                    case DecimalLiteral:
                    case OctalIntegerLiteral:
                    case HexIntegerLiteral:
                        {
                            alt4 = 3;
                        }
                        break;
                    case LBRACK:
                        {
                            alt4 = 4;
                        }
                        break;
                    case LBRACE:
                        {
                            alt4 = 5;
                        }
                        break;
                    case LPAREN:
                        {
                            alt4 = 6;
                        }
                        break;
                    default:
                        throw new NoViableAltException("", 4, 0, input);
                }

                switch (alt4)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:910:4: THIS
                        {
                            Match(input, THIS, FOLLOW_THIS_in_primaryExpression3124);
                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:911:4: Identifier
                        {
                            Match(input, Identifier, FOLLOW_Identifier_in_primaryExpression3129);
                        }
                        break;
                    case 3:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:912:4: literal
                        {
                            PushFollow(FOLLOW_literal_in_primaryExpression3134);
                            literal();
                            state.followingStackPointer--;
                        }
                        break;
                    case 4:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:913:4: arrayLiteral
                        {
                            PushFollow(FOLLOW_arrayLiteral_in_primaryExpression3139);
                            arrayLiteral();
                            state.followingStackPointer--;
                        }
                        break;
                    case 5:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:914:4: objectLiteral
                        {
                            PushFollow(FOLLOW_objectLiteral_in_primaryExpression3144);
                            objectLiteral();
                            state.followingStackPointer--;
                        }
                        break;
                    case 6:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:915:4: lpar= LPAREN expression RPAREN
                        {
                            var lpar = (IToken)Match(input, LPAREN, FOLLOW_LPAREN_in_primaryExpression3151);
                            PushFollow(FOLLOW_expression_in_primaryExpression3153);
                            expression();
                            state.followingStackPointer--;

                            Match(input, RPAREN, FOLLOW_RPAREN_in_primaryExpression3155);
                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "primaryExpression"

        public class arrayLiteral_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "arrayLiteral"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:921:1: arrayLiteral : lb= LBRACK ( arrayItem ( COMMA ( arrayItem )? )* )? RBRACK ;
        public arrayLiteral_return arrayLiteral() // throws RecognitionException [1]
        {
            var retval = new arrayLiteral_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:922:2: (lb= LBRACK ( arrayItem ( COMMA ( arrayItem )? )* )? RBRACK )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:922:4: lb= LBRACK ( arrayItem ( COMMA ( arrayItem )? )* )? RBRACK
                {
                    var lb = (IToken)Match(input, LBRACK, FOLLOW_LBRACK_in_arrayLiteral3171);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:922:14: ( arrayItem ( COMMA ( arrayItem )? )* )?
                    var alt7 = 2;
                    var LA7_0 = input.LA(1);

                    if (((LA7_0 >= NULL && LA7_0 <= FALSE) || LA7_0 == DELETE || LA7_0 == FUNCTION || LA7_0 == NEW ||
                         LA7_0 == THIS || LA7_0 == TYPEOF || LA7_0 == VOID || LA7_0 == LBRACE || LA7_0 == LPAREN ||
                         LA7_0 == LBRACK || LA7_0 == COMMA || (LA7_0 >= ADD && LA7_0 <= SUB) ||
                         (LA7_0 >= INC && LA7_0 <= DEC) || (LA7_0 >= NOT && LA7_0 <= INV) ||
                         (LA7_0 >= Identifier && LA7_0 <= StringLiteral) || LA7_0 == RegularExpressionLiteral ||
                         (LA7_0 >= DecimalLiteral && LA7_0 <= HexIntegerLiteral)))
                    {
                        alt7 = 1;
                    }
                    else if ((LA7_0 == RBRACK))
                    {
                        var LA7_2 = input.LA(2);

                        if (((input.LA(1) == COMMA)))
                        {
                            alt7 = 1;
                        }
                    }
                    switch (alt7)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:922:16: arrayItem ( COMMA ( arrayItem )? )*
                            {
                                PushFollow(FOLLOW_arrayItem_in_arrayLiteral3175);
                                arrayItem();
                                state.followingStackPointer--;

                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:922:26: ( COMMA ( arrayItem )? )*
                                do
                                {
                                    var alt6 = 2;
                                    var LA6_0 = input.LA(1);

                                    if ((LA6_0 == COMMA))
                                    {
                                        alt6 = 1;
                                    }


                                    switch (alt6)
                                    {
                                        case 1:
                                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:922:28: COMMA ( arrayItem )?
                                            {
                                                Match(input, COMMA, FOLLOW_COMMA_in_arrayLiteral3179);
                                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:922:34: ( arrayItem )?
                                                var alt5 = 2;
                                                switch (input.LA(1))
                                                {
                                                    case NULL:
                                                    case TRUE:
                                                    case FALSE:
                                                    case DELETE:
                                                    case FUNCTION:
                                                    case NEW:
                                                    case THIS:
                                                    case TYPEOF:
                                                    case VOID:
                                                    case LBRACE:
                                                    case LPAREN:
                                                    case LBRACK:
                                                    case ADD:
                                                    case SUB:
                                                    case INC:
                                                    case DEC:
                                                    case NOT:
                                                    case INV:
                                                    case Identifier:
                                                    case StringLiteral:
                                                    case RegularExpressionLiteral:
                                                    case DecimalLiteral:
                                                    case OctalIntegerLiteral:
                                                    case HexIntegerLiteral:
                                                        {
                                                            alt5 = 1;
                                                        }
                                                        break;
                                                    case RBRACK:
                                                        {
                                                            var LA5_2 = input.LA(2);

                                                            if (((input.LA(1) == COMMA)))
                                                            {
                                                                alt5 = 1;
                                                            }
                                                        }
                                                        break;
                                                    case COMMA:
                                                        {
                                                            var LA5_3 = input.LA(2);

                                                            if (((input.LA(1) == COMMA)))
                                                            {
                                                                alt5 = 1;
                                                            }
                                                        }
                                                        break;
                                                }

                                                switch (alt5)
                                                {
                                                    case 1:
                                                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:922:34: arrayItem
                                                        {
                                                            PushFollow(FOLLOW_arrayItem_in_arrayLiteral3181);
                                                            arrayItem();
                                                            state.followingStackPointer--;
                                                        }
                                                        break;
                                                }
                                            }
                                            break;

                                        default:
                                            goto loop6;
                                    }
                                } while (true);

                            loop6:
                                ; // Stops C# compiler whining that label 'loop6' has no statements

                            }
                            break;
                    }

                    Match(input, RBRACK, FOLLOW_RBRACK_in_arrayLiteral3190);
                }

                retval.Stop = input.LT(-1);
            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "arrayLiteral"

        public class arrayItem_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "arrayItem"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:926:1: arrayItem : (expr= assignmentExpression | {...}?) ;
        public arrayItem_return arrayItem() // throws RecognitionException [1]
        {
            var retval = new arrayItem_return { Start = input.LT(1) };

            var expr = default(assignmentExpression_return);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:927:2: ( (expr= assignmentExpression | {...}?) )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:927:4: (expr= assignmentExpression | {...}?)
                {
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:927:4: (expr= assignmentExpression | {...}?)
                    var alt8 = 2;
                    var LA8_0 = input.LA(1);

                    if (((LA8_0 >= NULL && LA8_0 <= FALSE) || LA8_0 == DELETE || LA8_0 == FUNCTION || LA8_0 == NEW ||
                         LA8_0 == THIS || LA8_0 == TYPEOF || LA8_0 == VOID || LA8_0 == LBRACE || LA8_0 == LPAREN ||
                         LA8_0 == LBRACK || (LA8_0 >= ADD && LA8_0 <= SUB) || (LA8_0 >= INC && LA8_0 <= DEC) ||
                         (LA8_0 >= NOT && LA8_0 <= INV) || (LA8_0 >= Identifier && LA8_0 <= StringLiteral) ||
                         LA8_0 == RegularExpressionLiteral || (LA8_0 >= DecimalLiteral && LA8_0 <= HexIntegerLiteral)))
                    {
                        alt8 = 1;
                    }
                    else if ((LA8_0 == RBRACK || LA8_0 == COMMA))
                    {
                        alt8 = 2;
                    }
                    else
                    {
                        throw new NoViableAltException("", 8, 0, input);
                    }
                    switch (alt8)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:927:6: expr= assignmentExpression
                            {
                                PushFollow(FOLLOW_assignmentExpression_in_arrayItem3207);
                                expr = assignmentExpression();
                                state.followingStackPointer--;
                            }
                            break;
                        case 2:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:927:34: {...}?
                            {
                                if (input.LA(1) != COMMA)
                                {
                                    throw new FailedPredicateException(input, "arrayItem", " input.LA(1) == COMMA ");
                                }
                            }
                            break;
                    }
                }

                retval.Stop = input.LT(-1);
            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "arrayItem"

        public class objectLiteral_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "objectLiteral"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:931:1: objectLiteral : lb= LBRACE ( nameValuePair ( COMMA nameValuePair )* )? RBRACE ;
        public objectLiteral_return objectLiteral() // throws RecognitionException [1]
        {
            var retval = new objectLiteral_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:932:2: (lb= LBRACE ( nameValuePair ( COMMA nameValuePair )* )? RBRACE )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:932:4: lb= LBRACE ( nameValuePair ( COMMA nameValuePair )* )? RBRACE
                {
                    var lb = (IToken)Match(input, LBRACE, FOLLOW_LBRACE_in_objectLiteral3228);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:932:14: ( nameValuePair ( COMMA nameValuePair )* )?
                    var alt10 = 2;
                    var LA10_0 = input.LA(1);

                    if (((LA10_0 >= Identifier && LA10_0 <= StringLiteral) ||
                         (LA10_0 >= DecimalLiteral && LA10_0 <= HexIntegerLiteral)))
                    {
                        alt10 = 1;
                    }
                    switch (alt10)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:932:16: nameValuePair ( COMMA nameValuePair )*
                            {
                                PushFollow(FOLLOW_nameValuePair_in_objectLiteral3232);
                                nameValuePair();
                                state.followingStackPointer--;

                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:932:30: ( COMMA nameValuePair )*
                                do
                                {
                                    var alt9 = 2;
                                    var LA9_0 = input.LA(1);

                                    if ((LA9_0 == COMMA))
                                    {
                                        alt9 = 1;
                                    }

                                    switch (alt9)
                                    {
                                        case 1:
                                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:932:32: COMMA nameValuePair
                                            {
                                                Match(input, COMMA, FOLLOW_COMMA_in_objectLiteral3236);
                                                PushFollow(FOLLOW_nameValuePair_in_objectLiteral3238);
                                                nameValuePair();
                                                state.followingStackPointer--;
                                            }
                                            break;

                                        default:
                                            goto loop9;
                                    }
                                } while (true);

                            loop9:
                                ; // Stops C# compiler whining that label 'loop9' has no statements

                            }
                            break;
                    }

                    Match(input, RBRACE, FOLLOW_RBRACE_in_objectLiteral3246);
                }

                retval.Stop = input.LT(-1);
            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "objectLiteral"

        public class nameValuePair_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "nameValuePair"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:940:1: nameValuePair : propertyName COLON assignmentExpression ;
        public nameValuePair_return nameValuePair() // throws RecognitionException [1]
        {
            var retval = new nameValuePair_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:941:2: ( propertyName COLON assignmentExpression )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:941:4: propertyName COLON assignmentExpression
                {
                    PushFollow(FOLLOW_propertyName_in_nameValuePair3262);
                    propertyName();
                    state.followingStackPointer--;

                    Match(input, COLON, FOLLOW_COLON_in_nameValuePair3264);
                    PushFollow(FOLLOW_assignmentExpression_in_nameValuePair3266);
                    assignmentExpression();
                    state.followingStackPointer--;
                }

                retval.Stop = input.LT(-1);
            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "nameValuePair"

        public class propertyName_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "propertyName"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:945:1: propertyName : ( Identifier | StringLiteral | numericLiteral );
        public propertyName_return propertyName() // throws RecognitionException [1]
        {
            var retval = new propertyName_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:946:2: ( Identifier | StringLiteral | numericLiteral )
                var alt11 = 3;
                switch (input.LA(1))
                {
                    case Identifier:
                        {
                            alt11 = 1;
                        }
                        break;
                    case StringLiteral:
                        {
                            alt11 = 2;
                        }
                        break;
                    case DecimalLiteral:
                    case OctalIntegerLiteral:
                    case HexIntegerLiteral:
                        {
                            alt11 = 3;
                        }
                        break;
                    default:
                        throw new NoViableAltException("", 11, 0, input);
                }

                switch (alt11)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:946:4: Identifier
                        {
                            Match(input, Identifier, FOLLOW_Identifier_in_propertyName3279);
                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:947:4: StringLiteral
                        {
                            Match(input, StringLiteral, FOLLOW_StringLiteral_in_propertyName3284);
                        }
                        break;
                    case 3:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:948:4: numericLiteral
                        {
                            PushFollow(FOLLOW_numericLiteral_in_propertyName3289);
                            numericLiteral();
                            state.followingStackPointer--;
                        }
                        break;
                }
                retval.Stop = input.LT(-1);
            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "propertyName"

        public class memberExpression_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "memberExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:960:1: memberExpression : ( primaryExpression | functionExpression | newExpression );
        public ES3Parser.memberExpression_return memberExpression() // throws RecognitionException [1]
        {
            ES3Parser.memberExpression_return retval = new ES3Parser.memberExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:961:2: ( primaryExpression | functionExpression | newExpression )
                int alt12 = 3;
                switch (input.LA(1))
                {
                    case NULL:
                    case TRUE:
                    case FALSE:
                    case THIS:
                    case LBRACE:
                    case LPAREN:
                    case LBRACK:
                    case Identifier:
                    case StringLiteral:
                    case RegularExpressionLiteral:
                    case DecimalLiteral:
                    case OctalIntegerLiteral:
                    case HexIntegerLiteral:
                        {
                            alt12 = 1;
                        }
                        break;
                    case FUNCTION:
                        {
                            alt12 = 2;
                        }
                        break;
                    case NEW:
                        {
                            alt12 = 3;
                        }
                        break;
                    default:
                        NoViableAltException nvae_d12s0 =
                            new NoViableAltException("", 12, 0, input);

                        throw nvae_d12s0;
                }

                switch (alt12)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:961:4: primaryExpression
                        {
                            PushFollow(FOLLOW_primaryExpression_in_memberExpression3307);
                            primaryExpression();
                            state.followingStackPointer--;


                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:962:4: functionExpression
                        {
                            PushFollow(FOLLOW_functionExpression_in_memberExpression3312);
                            functionExpression();
                            state.followingStackPointer--;


                        }
                        break;
                    case 3:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:963:4: newExpression
                        {
                            PushFollow(FOLLOW_newExpression_in_memberExpression3317);
                            newExpression();
                            state.followingStackPointer--;


                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "memberExpression"

        public class newExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "newExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:966:1: newExpression : ( NEW primaryExpression | NEW functionExpression );
        public ES3Parser.newExpression_return newExpression() // throws RecognitionException [1]
        {
            ES3Parser.newExpression_return retval = new ES3Parser.newExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:967:2: ( NEW primaryExpression | NEW functionExpression )
                int alt13 = 2;
                int LA13_0 = input.LA(1);

                if ((LA13_0 == NEW))
                {
                    int LA13_1 = input.LA(2);

                    if (((LA13_1 >= NULL && LA13_1 <= FALSE) || LA13_1 == THIS || LA13_1 == LBRACE || LA13_1 == LPAREN ||
                         LA13_1 == LBRACK || (LA13_1 >= Identifier && LA13_1 <= StringLiteral) ||
                         LA13_1 == RegularExpressionLiteral || (LA13_1 >= DecimalLiteral && LA13_1 <= HexIntegerLiteral)))
                    {
                        alt13 = 1;
                    }
                    else if ((LA13_1 == FUNCTION))
                    {
                        alt13 = 2;
                    }
                    else
                    {
                        NoViableAltException nvae_d13s1 =
                            new NoViableAltException("", 13, 1, input);

                        throw nvae_d13s1;
                    }
                }
                else
                {
                    NoViableAltException nvae_d13s0 =
                        new NoViableAltException("", 13, 0, input);

                    throw nvae_d13s0;
                }
                switch (alt13)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:967:4: NEW primaryExpression
                        {
                            Match(input, NEW, FOLLOW_NEW_in_newExpression3328);
                            PushFollow(FOLLOW_primaryExpression_in_newExpression3330);
                            primaryExpression();
                            state.followingStackPointer--;


                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:968:11: NEW functionExpression
                        {
                            Match(input, NEW, FOLLOW_NEW_in_newExpression3342);
                            PushFollow(FOLLOW_functionExpression_in_newExpression3344);
                            functionExpression();
                            state.followingStackPointer--;


                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "newExpression"

        public class arguments_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "arguments"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:972:1: arguments : LPAREN ( assignmentExpression ( COMMA assignmentExpression )* )? RPAREN ;
        public ES3Parser.arguments_return arguments() // throws RecognitionException [1]
        {
            ES3Parser.arguments_return retval = new ES3Parser.arguments_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:973:2: ( LPAREN ( assignmentExpression ( COMMA assignmentExpression )* )? RPAREN )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:973:4: LPAREN ( assignmentExpression ( COMMA assignmentExpression )* )? RPAREN
                {
                    Match(input, LPAREN, FOLLOW_LPAREN_in_arguments3360);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:973:11: ( assignmentExpression ( COMMA assignmentExpression )* )?
                    int alt15 = 2;
                    int LA15_0 = input.LA(1);

                    if (((LA15_0 >= NULL && LA15_0 <= FALSE) || LA15_0 == DELETE || LA15_0 == FUNCTION || LA15_0 == NEW ||
                         LA15_0 == THIS || LA15_0 == TYPEOF || LA15_0 == VOID || LA15_0 == LBRACE || LA15_0 == LPAREN ||
                         LA15_0 == LBRACK || (LA15_0 >= ADD && LA15_0 <= SUB) || (LA15_0 >= INC && LA15_0 <= DEC) ||
                         (LA15_0 >= NOT && LA15_0 <= INV) || (LA15_0 >= Identifier && LA15_0 <= StringLiteral) ||
                         LA15_0 == RegularExpressionLiteral || (LA15_0 >= DecimalLiteral && LA15_0 <= HexIntegerLiteral)))
                    {
                        alt15 = 1;
                    }
                    switch (alt15)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:973:13: assignmentExpression ( COMMA assignmentExpression )*
                            {
                                PushFollow(FOLLOW_assignmentExpression_in_arguments3364);
                                assignmentExpression();
                                state.followingStackPointer--;

                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:973:34: ( COMMA assignmentExpression )*
                                do
                                {
                                    int alt14 = 2;
                                    int LA14_0 = input.LA(1);

                                    if ((LA14_0 == COMMA))
                                    {
                                        alt14 = 1;
                                    }


                                    switch (alt14)
                                    {
                                        case 1:
                                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:973:36: COMMA assignmentExpression
                                            {
                                                Match(input, COMMA, FOLLOW_COMMA_in_arguments3368);
                                                PushFollow(FOLLOW_assignmentExpression_in_arguments3370);
                                                assignmentExpression();
                                                state.followingStackPointer--;


                                            }
                                            break;

                                        default:
                                            goto loop14;
                                    }
                                } while (true);

                            loop14:
                                ; // Stops C# compiler whining that label 'loop14' has no statements


                            }
                            break;

                    }

                    Match(input, RPAREN, FOLLOW_RPAREN_in_arguments3378);

                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "arguments"

        public class leftHandSideExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "leftHandSideExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:977:1: leftHandSideExpression : ( memberExpression ) ( arguments | LBRACK expression RBRACK | DOT Identifier )* ;
        public ES3Parser.leftHandSideExpression_return leftHandSideExpression()
        // throws RecognitionException [1]
        {
            ES3Parser.leftHandSideExpression_return retval = new ES3Parser.leftHandSideExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:978:2: ( ( memberExpression ) ( arguments | LBRACK expression RBRACK | DOT Identifier )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:979:2: ( memberExpression ) ( arguments | LBRACK expression RBRACK | DOT Identifier )*
                {
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:979:2: ( memberExpression )
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:980:3: memberExpression
                    {
                        PushFollow(FOLLOW_memberExpression_in_leftHandSideExpression3397);
                        memberExpression();
                        state.followingStackPointer--;


                    }

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:982:2: ( arguments | LBRACK expression RBRACK | DOT Identifier )*
                    do
                    {
                        int alt16 = 4;
                        switch (input.LA(1))
                        {
                            case LPAREN:
                                {
                                    alt16 = 1;
                                }
                                break;
                            case LBRACK:
                                {
                                    alt16 = 2;
                                }
                                break;
                            case DOT:
                                {
                                    alt16 = 3;
                                }
                                break;

                        }

                        switch (alt16)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:983:3: arguments
                                {
                                    PushFollow(FOLLOW_arguments_in_leftHandSideExpression3410);
                                    arguments();
                                    state.followingStackPointer--;


                                }
                                break;
                            case 2:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:984:5: LBRACK expression RBRACK
                                {
                                    Match(input, LBRACK, FOLLOW_LBRACK_in_leftHandSideExpression3419);
                                    PushFollow(FOLLOW_expression_in_leftHandSideExpression3421);
                                    expression();
                                    state.followingStackPointer--;

                                    Match(input, RBRACK, FOLLOW_RBRACK_in_leftHandSideExpression3423);

                                }
                                break;
                            case 3:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:985:5: DOT Identifier
                                {
                                    Match(input, DOT, FOLLOW_DOT_in_leftHandSideExpression3430);
                                    Match(input, Identifier, FOLLOW_Identifier_in_leftHandSideExpression3432);

                                }
                                break;

                            default:
                                goto loop16;
                        }
                    } while (true);

                loop16:
                    ; // Stops C# compiler whining that label 'loop16' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "leftHandSideExpression"

        public class postfixExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "postfixExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:999:1: postfixExpression : leftHandSideExpression ( postfixOperator )? ;
        public ES3Parser.postfixExpression_return postfixExpression() // throws RecognitionException [1]
        {
            ES3Parser.postfixExpression_return retval = new ES3Parser.postfixExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1000:2: ( leftHandSideExpression ( postfixOperator )? )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1000:4: leftHandSideExpression ( postfixOperator )?
                {
                    PushFollow(FOLLOW_leftHandSideExpression_in_postfixExpression3455);
                    leftHandSideExpression();
                    state.followingStackPointer--;

                    if (input.LA(1) == INC || input.LA(1) == DEC) PromoteEol(null);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1000:95: ( postfixOperator )?
                    int alt17 = 2;
                    int LA17_0 = input.LA(1);

                    if (((LA17_0 >= INC && LA17_0 <= DEC)))
                    {
                        alt17 = 1;
                    }
                    switch (alt17)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1000:97: postfixOperator
                            {
                                PushFollow(FOLLOW_postfixOperator_in_postfixExpression3461);
                                postfixOperator();
                                state.followingStackPointer--;


                            }
                            break;

                    }


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "postfixExpression"

        public class postfixOperator_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "postfixOperator"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1003:1: postfixOperator : (op= INC | op= DEC );
        public postfixOperator_return postfixOperator() // throws RecognitionException [1]
        {
            var retval = new postfixOperator_return();
            retval.Start = input.LT(1);

            IToken op = null;

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1004:2: (op= INC | op= DEC )
                int alt18 = 2;
                int LA18_0 = input.LA(1);

                if ((LA18_0 == INC))
                {
                    alt18 = 1;
                }
                else if ((LA18_0 == DEC))
                {
                    alt18 = 2;
                }
                else
                {
                    var nvae_d18s0 = new NoViableAltException("", 18, 0, input);

                    throw nvae_d18s0;
                }
                switch (alt18)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1004:4: op= INC
                        {
                            op = (IToken)Match(input, INC, FOLLOW_INC_in_postfixOperator3478);
                            op.Type = PINC;

                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1005:4: op= DEC
                        {
                            op = (IToken)Match(input, DEC, FOLLOW_DEC_in_postfixOperator3487);
                            op.Type = PDEC;
                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "postfixOperator"

        public class unaryExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "unaryExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1012:1: unaryExpression : ( postfixExpression | unaryOperator unaryExpression );
        public unaryExpression_return unaryExpression() // throws RecognitionException [1]
        {
            var retval = new unaryExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1013:2: ( postfixExpression | unaryOperator unaryExpression )
                var alt19 = 2;
                var LA19_0 = input.LA(1);

                if (((LA19_0 >= NULL && LA19_0 <= FALSE) || LA19_0 == FUNCTION || LA19_0 == NEW || LA19_0 == THIS ||
                     LA19_0 == LBRACE || LA19_0 == LPAREN || LA19_0 == LBRACK ||
                     (LA19_0 >= Identifier && LA19_0 <= StringLiteral) || LA19_0 == RegularExpressionLiteral ||
                     (LA19_0 >= DecimalLiteral && LA19_0 <= HexIntegerLiteral)))
                {
                    alt19 = 1;
                }
                else if ((LA19_0 == DELETE || LA19_0 == TYPEOF || LA19_0 == VOID || (LA19_0 >= ADD && LA19_0 <= SUB) ||
                          (LA19_0 >= INC && LA19_0 <= DEC) || (LA19_0 >= NOT && LA19_0 <= INV)))
                {
                    alt19 = 2;
                }
                else
                {
                    var nvae_d19s0 = new NoViableAltException("", 19, 0, input);

                    throw nvae_d19s0;
                }
                switch (alt19)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1013:4: postfixExpression
                        {
                            PushFollow(FOLLOW_postfixExpression_in_unaryExpression3504);
                            postfixExpression();
                            state.followingStackPointer--;


                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1014:4: unaryOperator unaryExpression
                        {
                            PushFollow(FOLLOW_unaryOperator_in_unaryExpression3509);
                            unaryOperator();
                            state.followingStackPointer--;

                            PushFollow(FOLLOW_unaryExpression_in_unaryExpression3511);
                            unaryExpression();
                            state.followingStackPointer--;


                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            return retval;
        }

        // $ANTLR end "unaryExpression"

        public class unaryOperator_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "unaryOperator"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1017:1: unaryOperator : ( DELETE | VOID | TYPEOF | INC | DEC | op= ADD | op= SUB | INV | NOT );
        public unaryOperator_return unaryOperator() // throws RecognitionException [1]
        {
            var retval = new unaryOperator_return();
            retval.Start = input.LT(1);

            IToken op = null;

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1018:2: ( DELETE | VOID | TYPEOF | INC | DEC | op= ADD | op= SUB | INV | NOT )
                int alt20 = 9;
                switch (input.LA(1))
                {
                    case DELETE:
                        {
                            alt20 = 1;
                        }
                        break;
                    case VOID:
                        {
                            alt20 = 2;
                        }
                        break;
                    case TYPEOF:
                        {
                            alt20 = 3;
                        }
                        break;
                    case INC:
                        {
                            alt20 = 4;
                        }
                        break;
                    case DEC:
                        {
                            alt20 = 5;
                        }
                        break;
                    case ADD:
                        {
                            alt20 = 6;
                        }
                        break;
                    case SUB:
                        {
                            alt20 = 7;
                        }
                        break;
                    case INV:
                        {
                            alt20 = 8;
                        }
                        break;
                    case NOT:
                        {
                            alt20 = 9;
                        }
                        break;
                    default:
                        var nvae_d20s0 = new NoViableAltException("", 20, 0, input);

                        throw nvae_d20s0;
                }

                switch (alt20)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1018:4: DELETE
                        {
                            Match(input, DELETE, FOLLOW_DELETE_in_unaryOperator3523);

                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1019:4: VOID
                        {
                            Match(input, VOID, FOLLOW_VOID_in_unaryOperator3528);

                        }
                        break;
                    case 3:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1020:4: TYPEOF
                        {
                            Match(input, TYPEOF, FOLLOW_TYPEOF_in_unaryOperator3533);

                        }
                        break;
                    case 4:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1021:4: INC
                        {
                            Match(input, INC, FOLLOW_INC_in_unaryOperator3538);

                        }
                        break;
                    case 5:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1022:4: DEC
                        {
                            Match(input, DEC, FOLLOW_DEC_in_unaryOperator3543);

                        }
                        break;
                    case 6:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1023:4: op= ADD
                        {
                            op = (IToken)Match(input, ADD, FOLLOW_ADD_in_unaryOperator3550);
                            op.Type = POS;

                        }
                        break;
                    case 7:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1024:4: op= SUB
                        {
                            op = (IToken)Match(input, SUB, FOLLOW_SUB_in_unaryOperator3559);
                            op.Type = NEG;

                        }
                        break;
                    case 8:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1025:4: INV
                        {
                            Match(input, INV, FOLLOW_INV_in_unaryOperator3566);

                        }
                        break;
                    case 9:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1026:4: NOT
                        {
                            Match(input, NOT, FOLLOW_NOT_in_unaryOperator3571);

                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            return retval;
        }

        // $ANTLR end "unaryOperator"

        public class multiplicativeExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "multiplicativeExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1033:1: multiplicativeExpression : unaryExpression ( ( MUL | DIV | MOD ) unaryExpression )* ;
        public multiplicativeExpression_return multiplicativeExpression()
        // throws RecognitionException [1]
        {
            var retval = new multiplicativeExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1034:2: ( unaryExpression ( ( MUL | DIV | MOD ) unaryExpression )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1034:4: unaryExpression ( ( MUL | DIV | MOD ) unaryExpression )*
                {
                    PushFollow(FOLLOW_unaryExpression_in_multiplicativeExpression3586);
                    unaryExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1034:20: ( ( MUL | DIV | MOD ) unaryExpression )*
                    do
                    {
                        var alt21 = 2;
                        var LA21_0 = input.LA(1);

                        if (((LA21_0 >= MUL && LA21_0 <= MOD) || LA21_0 == DIV))
                        {
                            alt21 = 1;
                        }


                        switch (alt21)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1034:22: ( MUL | DIV | MOD ) unaryExpression
                                {
                                    if ((input.LA(1) >= MUL && input.LA(1) <= MOD) || input.LA(1) == DIV)
                                    {
                                        input.Consume();
                                        state.errorRecovery = false;
                                    }
                                    else
                                    {
                                        var mse = new MismatchedSetException(null, input);
                                        throw mse;
                                    }

                                    PushFollow(FOLLOW_unaryExpression_in_multiplicativeExpression3604);
                                    unaryExpression();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop21;
                        }
                    } while (true);

                loop21:
                    ; // Stops C# compiler whining that label 'loop21' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            return retval;
        }

        // $ANTLR end "multiplicativeExpression"

        public class additiveExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "additiveExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1041:1: additiveExpression : multiplicativeExpression ( ( ADD | SUB ) multiplicativeExpression )* ;
        public ES3Parser.additiveExpression_return additiveExpression() // throws RecognitionException [1]
        {
            ES3Parser.additiveExpression_return retval = new ES3Parser.additiveExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1042:2: ( multiplicativeExpression ( ( ADD | SUB ) multiplicativeExpression )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1042:4: multiplicativeExpression ( ( ADD | SUB ) multiplicativeExpression )*
                {
                    PushFollow(FOLLOW_multiplicativeExpression_in_additiveExpression3622);
                    multiplicativeExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1042:29: ( ( ADD | SUB ) multiplicativeExpression )*
                    do
                    {
                        int alt22 = 2;
                        int LA22_0 = input.LA(1);

                        if (((LA22_0 >= ADD && LA22_0 <= SUB)))
                        {
                            alt22 = 1;
                        }


                        switch (alt22)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1042:31: ( ADD | SUB ) multiplicativeExpression
                                {
                                    if ((input.LA(1) >= ADD && input.LA(1) <= SUB))
                                    {
                                        input.Consume();
                                        state.errorRecovery = false;
                                    }
                                    else
                                    {
                                        MismatchedSetException mse = new MismatchedSetException(null, input);
                                        throw mse;
                                    }

                                    PushFollow(FOLLOW_multiplicativeExpression_in_additiveExpression3636);
                                    multiplicativeExpression();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop22;
                        }
                    } while (true);

                loop22:
                    ; // Stops C# compiler whining that label 'loop22' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "additiveExpression"

        public class shiftExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "shiftExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1049:1: shiftExpression : additiveExpression ( ( SHL | SHR | SHU ) additiveExpression )* ;
        public ES3Parser.shiftExpression_return shiftExpression() // throws RecognitionException [1]
        {
            ES3Parser.shiftExpression_return retval = new ES3Parser.shiftExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1050:2: ( additiveExpression ( ( SHL | SHR | SHU ) additiveExpression )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1050:4: additiveExpression ( ( SHL | SHR | SHU ) additiveExpression )*
                {
                    PushFollow(FOLLOW_additiveExpression_in_shiftExpression3655);
                    additiveExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1050:23: ( ( SHL | SHR | SHU ) additiveExpression )*
                    do
                    {
                        int alt23 = 2;
                        int LA23_0 = input.LA(1);

                        if (((LA23_0 >= SHL && LA23_0 <= SHU)))
                        {
                            alt23 = 1;
                        }


                        switch (alt23)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1050:25: ( SHL | SHR | SHU ) additiveExpression
                                {
                                    if ((input.LA(1) >= SHL && input.LA(1) <= SHU))
                                    {
                                        input.Consume();
                                        state.errorRecovery = false;
                                    }
                                    else
                                    {
                                        MismatchedSetException mse = new MismatchedSetException(null, input);
                                        throw mse;
                                    }

                                    PushFollow(FOLLOW_additiveExpression_in_shiftExpression3673);
                                    additiveExpression();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop23;
                        }
                    } while (true);

                loop23:
                    ; // Stops C# compiler whining that label 'loop23' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "shiftExpression"

        public class relationalExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "relationalExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1057:1: relationalExpression : shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF | IN ) shiftExpression )* ;
        public ES3Parser.relationalExpression_return relationalExpression() // throws RecognitionException [1]
        {
            ES3Parser.relationalExpression_return retval = new ES3Parser.relationalExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1058:2: ( shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF | IN ) shiftExpression )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1058:4: shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF | IN ) shiftExpression )*
                {
                    PushFollow(FOLLOW_shiftExpression_in_relationalExpression3692);
                    shiftExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1058:20: ( ( LT | GT | LTE | GTE | INSTANCEOF | IN ) shiftExpression )*
                    do
                    {
                        int alt24 = 2;
                        int LA24_0 = input.LA(1);

                        if (((LA24_0 >= IN && LA24_0 <= INSTANCEOF) || (LA24_0 >= LT && LA24_0 <= GTE)))
                        {
                            alt24 = 1;
                        }


                        switch (alt24)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1058:22: ( LT | GT | LTE | GTE | INSTANCEOF | IN ) shiftExpression
                                {
                                    if ((input.LA(1) >= IN && input.LA(1) <= INSTANCEOF) ||
                                        (input.LA(1) >= LT && input.LA(1) <= GTE))
                                    {
                                        input.Consume();
                                        state.errorRecovery = false;
                                    }
                                    else
                                    {
                                        MismatchedSetException mse = new MismatchedSetException(null, input);
                                        throw mse;
                                    }

                                    PushFollow(FOLLOW_shiftExpression_in_relationalExpression3722);
                                    shiftExpression();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop24;
                        }
                    } while (true);

                loop24:
                    ; // Stops C# compiler whining that label 'loop24' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "relationalExpression"

        public class relationalExpressionNoIn_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "relationalExpressionNoIn"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1061:1: relationalExpressionNoIn : shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF ) shiftExpression )* ;
        public ES3Parser.relationalExpressionNoIn_return relationalExpressionNoIn()
        // throws RecognitionException [1]
        {
            ES3Parser.relationalExpressionNoIn_return retval =
                new ES3Parser.relationalExpressionNoIn_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1062:2: ( shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF ) shiftExpression )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1062:4: shiftExpression ( ( LT | GT | LTE | GTE | INSTANCEOF ) shiftExpression )*
                {
                    PushFollow(FOLLOW_shiftExpression_in_relationalExpressionNoIn3736);
                    shiftExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1062:20: ( ( LT | GT | LTE | GTE | INSTANCEOF ) shiftExpression )*
                    do
                    {
                        int alt25 = 2;
                        int LA25_0 = input.LA(1);

                        if ((LA25_0 == INSTANCEOF || (LA25_0 >= LT && LA25_0 <= GTE)))
                        {
                            alt25 = 1;
                        }


                        switch (alt25)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1062:22: ( LT | GT | LTE | GTE | INSTANCEOF ) shiftExpression
                                {
                                    if (input.LA(1) == INSTANCEOF || (input.LA(1) >= LT && input.LA(1) <= GTE))
                                    {
                                        input.Consume();
                                        state.errorRecovery = false;
                                    }
                                    else
                                    {
                                        MismatchedSetException mse = new MismatchedSetException(null, input);
                                        throw mse;
                                    }

                                    PushFollow(FOLLOW_shiftExpression_in_relationalExpressionNoIn3762);
                                    shiftExpression();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop25;
                        }
                    } while (true);

                loop25:
                    ; // Stops C# compiler whining that label 'loop25' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "relationalExpressionNoIn"

        public class equalityExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "equalityExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1069:1: equalityExpression : relationalExpression ( ( EQ | NEQ | SAME | NSAME ) relationalExpression )* ;
        public ES3Parser.equalityExpression_return equalityExpression() // throws RecognitionException [1]
        {
            ES3Parser.equalityExpression_return retval = new ES3Parser.equalityExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1070:2: ( relationalExpression ( ( EQ | NEQ | SAME | NSAME ) relationalExpression )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1070:4: relationalExpression ( ( EQ | NEQ | SAME | NSAME ) relationalExpression )*
                {
                    PushFollow(FOLLOW_relationalExpression_in_equalityExpression3781);
                    relationalExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1070:25: ( ( EQ | NEQ | SAME | NSAME ) relationalExpression )*
                    do
                    {
                        int alt26 = 2;
                        int LA26_0 = input.LA(1);

                        if (((LA26_0 >= EQ && LA26_0 <= NSAME)))
                        {
                            alt26 = 1;
                        }


                        switch (alt26)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1070:27: ( EQ | NEQ | SAME | NSAME ) relationalExpression
                                {
                                    if ((input.LA(1) >= EQ && input.LA(1) <= NSAME))
                                    {
                                        input.Consume();
                                        state.errorRecovery = false;
                                    }
                                    else
                                    {
                                        MismatchedSetException mse = new MismatchedSetException(null, input);
                                        throw mse;
                                    }

                                    PushFollow(FOLLOW_relationalExpression_in_equalityExpression3803);
                                    relationalExpression();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop26;
                        }
                    } while (true);

                loop26:
                    ; // Stops C# compiler whining that label 'loop26' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "equalityExpression"

        public class equalityExpressionNoIn_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "equalityExpressionNoIn"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1073:1: equalityExpressionNoIn : relationalExpressionNoIn ( ( EQ | NEQ | SAME | NSAME ) relationalExpressionNoIn )* ;
        public ES3Parser.equalityExpressionNoIn_return equalityExpressionNoIn()
        // throws RecognitionException [1]
        {
            ES3Parser.equalityExpressionNoIn_return retval = new ES3Parser.equalityExpressionNoIn_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1074:2: ( relationalExpressionNoIn ( ( EQ | NEQ | SAME | NSAME ) relationalExpressionNoIn )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1074:4: relationalExpressionNoIn ( ( EQ | NEQ | SAME | NSAME ) relationalExpressionNoIn )*
                {
                    PushFollow(FOLLOW_relationalExpressionNoIn_in_equalityExpressionNoIn3817);
                    relationalExpressionNoIn();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1074:29: ( ( EQ | NEQ | SAME | NSAME ) relationalExpressionNoIn )*
                    do
                    {
                        int alt27 = 2;
                        int LA27_0 = input.LA(1);

                        if (((LA27_0 >= EQ && LA27_0 <= NSAME)))
                        {
                            alt27 = 1;
                        }


                        switch (alt27)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1074:31: ( EQ | NEQ | SAME | NSAME ) relationalExpressionNoIn
                                {
                                    if ((input.LA(1) >= EQ && input.LA(1) <= NSAME))
                                    {
                                        input.Consume();
                                        state.errorRecovery = false;
                                    }
                                    else
                                    {
                                        MismatchedSetException mse = new MismatchedSetException(null, input);
                                        throw mse;
                                    }

                                    PushFollow(FOLLOW_relationalExpressionNoIn_in_equalityExpressionNoIn3839);
                                    relationalExpressionNoIn();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop27;
                        }
                    } while (true);

                loop27:
                    ; // Stops C# compiler whining that label 'loop27' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "equalityExpressionNoIn"

        public class bitwiseANDExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "bitwiseANDExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1081:1: bitwiseANDExpression : equalityExpression ( AND equalityExpression )* ;
        public ES3Parser.bitwiseANDExpression_return bitwiseANDExpression() // throws RecognitionException [1]
        {
            ES3Parser.bitwiseANDExpression_return retval = new ES3Parser.bitwiseANDExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1082:2: ( equalityExpression ( AND equalityExpression )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1082:4: equalityExpression ( AND equalityExpression )*
                {
                    PushFollow(FOLLOW_equalityExpression_in_bitwiseANDExpression3859);
                    equalityExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1082:23: ( AND equalityExpression )*
                    do
                    {
                        int alt28 = 2;
                        int LA28_0 = input.LA(1);

                        if ((LA28_0 == AND))
                        {
                            alt28 = 1;
                        }


                        switch (alt28)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1082:25: AND equalityExpression
                                {
                                    Match(input, AND, FOLLOW_AND_in_bitwiseANDExpression3863);
                                    PushFollow(FOLLOW_equalityExpression_in_bitwiseANDExpression3865);
                                    equalityExpression();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop28;
                        }
                    } while (true);

                loop28:
                    ; // Stops C# compiler whining that label 'loop28' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "bitwiseANDExpression"

        public class bitwiseANDExpressionNoIn_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "bitwiseANDExpressionNoIn"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1085:1: bitwiseANDExpressionNoIn : equalityExpressionNoIn ( AND equalityExpressionNoIn )* ;
        public ES3Parser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn()
        // throws RecognitionException [1]
        {
            ES3Parser.bitwiseANDExpressionNoIn_return retval =
                new ES3Parser.bitwiseANDExpressionNoIn_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1086:2: ( equalityExpressionNoIn ( AND equalityExpressionNoIn )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1086:4: equalityExpressionNoIn ( AND equalityExpressionNoIn )*
                {
                    PushFollow(FOLLOW_equalityExpressionNoIn_in_bitwiseANDExpressionNoIn3879);
                    equalityExpressionNoIn();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1086:27: ( AND equalityExpressionNoIn )*
                    do
                    {
                        int alt29 = 2;
                        int LA29_0 = input.LA(1);

                        if ((LA29_0 == AND))
                        {
                            alt29 = 1;
                        }


                        switch (alt29)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1086:29: AND equalityExpressionNoIn
                                {
                                    Match(input, AND, FOLLOW_AND_in_bitwiseANDExpressionNoIn3883);
                                    PushFollow(FOLLOW_equalityExpressionNoIn_in_bitwiseANDExpressionNoIn3885);
                                    equalityExpressionNoIn();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop29;
                        }
                    } while (true);

                loop29:
                    ; // Stops C# compiler whining that label 'loop29' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "bitwiseANDExpressionNoIn"

        public class bitwiseXORExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "bitwiseXORExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1089:1: bitwiseXORExpression : bitwiseANDExpression ( XOR bitwiseANDExpression )* ;
        public ES3Parser.bitwiseXORExpression_return bitwiseXORExpression() // throws RecognitionException [1]
        {
            ES3Parser.bitwiseXORExpression_return retval = new ES3Parser.bitwiseXORExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1090:2: ( bitwiseANDExpression ( XOR bitwiseANDExpression )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1090:4: bitwiseANDExpression ( XOR bitwiseANDExpression )*
                {
                    PushFollow(FOLLOW_bitwiseANDExpression_in_bitwiseXORExpression3901);
                    bitwiseANDExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1090:25: ( XOR bitwiseANDExpression )*
                    do
                    {
                        int alt30 = 2;
                        int LA30_0 = input.LA(1);

                        if ((LA30_0 == XOR))
                        {
                            alt30 = 1;
                        }


                        switch (alt30)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1090:27: XOR bitwiseANDExpression
                                {
                                    Match(input, XOR, FOLLOW_XOR_in_bitwiseXORExpression3905);
                                    PushFollow(FOLLOW_bitwiseANDExpression_in_bitwiseXORExpression3907);
                                    bitwiseANDExpression();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop30;
                        }
                    } while (true);

                loop30:
                    ; // Stops C# compiler whining that label 'loop30' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "bitwiseXORExpression"

        public class bitwiseXORExpressionNoIn_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "bitwiseXORExpressionNoIn"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1093:1: bitwiseXORExpressionNoIn : bitwiseANDExpressionNoIn ( XOR bitwiseANDExpressionNoIn )* ;
        public ES3Parser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn()
        // throws RecognitionException [1]
        {
            ES3Parser.bitwiseXORExpressionNoIn_return retval =
                new ES3Parser.bitwiseXORExpressionNoIn_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1094:2: ( bitwiseANDExpressionNoIn ( XOR bitwiseANDExpressionNoIn )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1094:4: bitwiseANDExpressionNoIn ( XOR bitwiseANDExpressionNoIn )*
                {
                    PushFollow(FOLLOW_bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn3923);
                    bitwiseANDExpressionNoIn();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1094:29: ( XOR bitwiseANDExpressionNoIn )*
                    do
                    {
                        int alt31 = 2;
                        int LA31_0 = input.LA(1);

                        if ((LA31_0 == XOR))
                        {
                            alt31 = 1;
                        }


                        switch (alt31)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1094:31: XOR bitwiseANDExpressionNoIn
                                {
                                    Match(input, XOR, FOLLOW_XOR_in_bitwiseXORExpressionNoIn3927);
                                    PushFollow(FOLLOW_bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn3929);
                                    bitwiseANDExpressionNoIn();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop31;
                        }
                    } while (true);

                loop31:
                    ; // Stops C# compiler whining that label 'loop31' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "bitwiseXORExpressionNoIn"

        public class bitwiseORExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "bitwiseORExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1097:1: bitwiseORExpression : bitwiseXORExpression ( OR bitwiseXORExpression )* ;
        public ES3Parser.bitwiseORExpression_return bitwiseORExpression() // throws RecognitionException [1]
        {
            ES3Parser.bitwiseORExpression_return retval = new ES3Parser.bitwiseORExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1098:2: ( bitwiseXORExpression ( OR bitwiseXORExpression )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1098:4: bitwiseXORExpression ( OR bitwiseXORExpression )*
                {
                    PushFollow(FOLLOW_bitwiseXORExpression_in_bitwiseORExpression3944);
                    bitwiseXORExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1098:25: ( OR bitwiseXORExpression )*
                    do
                    {
                        int alt32 = 2;
                        int LA32_0 = input.LA(1);

                        if ((LA32_0 == OR))
                        {
                            alt32 = 1;
                        }


                        switch (alt32)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1098:27: OR bitwiseXORExpression
                                {
                                    Match(input, OR, FOLLOW_OR_in_bitwiseORExpression3948);
                                    PushFollow(FOLLOW_bitwiseXORExpression_in_bitwiseORExpression3950);
                                    bitwiseXORExpression();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop32;
                        }
                    } while (true);

                loop32:
                    ; // Stops C# compiler whining that label 'loop32' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "bitwiseORExpression"

        public class bitwiseORExpressionNoIn_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "bitwiseORExpressionNoIn"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1101:1: bitwiseORExpressionNoIn : bitwiseXORExpressionNoIn ( OR bitwiseXORExpressionNoIn )* ;
        public ES3Parser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn()
        // throws RecognitionException [1]
        {
            ES3Parser.bitwiseORExpressionNoIn_return retval =
                new ES3Parser.bitwiseORExpressionNoIn_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1102:2: ( bitwiseXORExpressionNoIn ( OR bitwiseXORExpressionNoIn )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1102:4: bitwiseXORExpressionNoIn ( OR bitwiseXORExpressionNoIn )*
                {
                    PushFollow(FOLLOW_bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn3965);
                    bitwiseXORExpressionNoIn();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1102:29: ( OR bitwiseXORExpressionNoIn )*
                    do
                    {
                        int alt33 = 2;
                        int LA33_0 = input.LA(1);

                        if ((LA33_0 == OR))
                        {
                            alt33 = 1;
                        }


                        switch (alt33)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1102:31: OR bitwiseXORExpressionNoIn
                                {
                                    Match(input, OR, FOLLOW_OR_in_bitwiseORExpressionNoIn3969);
                                    PushFollow(FOLLOW_bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn3971);
                                    bitwiseXORExpressionNoIn();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop33;
                        }
                    } while (true);

                loop33:
                    ; // Stops C# compiler whining that label 'loop33' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "bitwiseORExpressionNoIn"

        public class logicalANDExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "logicalANDExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1109:1: logicalANDExpression : bitwiseORExpression ( LAND bitwiseORExpression )* ;
        public ES3Parser.logicalANDExpression_return logicalANDExpression() // throws RecognitionException [1]
        {
            ES3Parser.logicalANDExpression_return retval = new ES3Parser.logicalANDExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1110:2: ( bitwiseORExpression ( LAND bitwiseORExpression )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1110:4: bitwiseORExpression ( LAND bitwiseORExpression )*
                {
                    PushFollow(FOLLOW_bitwiseORExpression_in_logicalANDExpression3990);
                    bitwiseORExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1110:24: ( LAND bitwiseORExpression )*
                    do
                    {
                        int alt34 = 2;
                        int LA34_0 = input.LA(1);

                        if ((LA34_0 == LAND))
                        {
                            alt34 = 1;
                        }


                        switch (alt34)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1110:26: LAND bitwiseORExpression
                                {
                                    Match(input, LAND, FOLLOW_LAND_in_logicalANDExpression3994);
                                    PushFollow(FOLLOW_bitwiseORExpression_in_logicalANDExpression3996);
                                    bitwiseORExpression();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop34;
                        }
                    } while (true);

                loop34:
                    ; // Stops C# compiler whining that label 'loop34' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "logicalANDExpression"

        public class logicalANDExpressionNoIn_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "logicalANDExpressionNoIn"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1113:1: logicalANDExpressionNoIn : bitwiseORExpressionNoIn ( LAND bitwiseORExpressionNoIn )* ;
        public ES3Parser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn()
        // throws RecognitionException [1]
        {
            ES3Parser.logicalANDExpressionNoIn_return retval =
                new ES3Parser.logicalANDExpressionNoIn_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1114:2: ( bitwiseORExpressionNoIn ( LAND bitwiseORExpressionNoIn )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1114:4: bitwiseORExpressionNoIn ( LAND bitwiseORExpressionNoIn )*
                {
                    PushFollow(FOLLOW_bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4010);
                    bitwiseORExpressionNoIn();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1114:28: ( LAND bitwiseORExpressionNoIn )*
                    do
                    {
                        int alt35 = 2;
                        int LA35_0 = input.LA(1);

                        if ((LA35_0 == LAND))
                        {
                            alt35 = 1;
                        }


                        switch (alt35)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1114:30: LAND bitwiseORExpressionNoIn
                                {
                                    Match(input, LAND, FOLLOW_LAND_in_logicalANDExpressionNoIn4014);
                                    PushFollow(FOLLOW_bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4016);
                                    bitwiseORExpressionNoIn();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop35;
                        }
                    } while (true);

                loop35:
                    ; // Stops C# compiler whining that label 'loop35' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "logicalANDExpressionNoIn"

        public class logicalORExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "logicalORExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1117:1: logicalORExpression : logicalANDExpression ( LOR logicalANDExpression )* ;
        public ES3Parser.logicalORExpression_return logicalORExpression() // throws RecognitionException [1]
        {
            ES3Parser.logicalORExpression_return retval = new ES3Parser.logicalORExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1118:2: ( logicalANDExpression ( LOR logicalANDExpression )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1118:4: logicalANDExpression ( LOR logicalANDExpression )*
                {
                    PushFollow(FOLLOW_logicalANDExpression_in_logicalORExpression4031);
                    logicalANDExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1118:25: ( LOR logicalANDExpression )*
                    do
                    {
                        int alt36 = 2;
                        int LA36_0 = input.LA(1);

                        if ((LA36_0 == LOR))
                        {
                            alt36 = 1;
                        }


                        switch (alt36)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1118:27: LOR logicalANDExpression
                                {
                                    Match(input, LOR, FOLLOW_LOR_in_logicalORExpression4035);
                                    PushFollow(FOLLOW_logicalANDExpression_in_logicalORExpression4037);
                                    logicalANDExpression();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop36;
                        }
                    } while (true);

                loop36:
                    ; // Stops C# compiler whining that label 'loop36' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "logicalORExpression"

        public class logicalORExpressionNoIn_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "logicalORExpressionNoIn"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1121:1: logicalORExpressionNoIn : logicalANDExpressionNoIn ( LOR logicalANDExpressionNoIn )* ;
        public ES3Parser.logicalORExpressionNoIn_return logicalORExpressionNoIn()
        // throws RecognitionException [1]
        {
            ES3Parser.logicalORExpressionNoIn_return retval =
                new ES3Parser.logicalORExpressionNoIn_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1122:2: ( logicalANDExpressionNoIn ( LOR logicalANDExpressionNoIn )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1122:4: logicalANDExpressionNoIn ( LOR logicalANDExpressionNoIn )*
                {
                    PushFollow(FOLLOW_logicalANDExpressionNoIn_in_logicalORExpressionNoIn4052);
                    logicalANDExpressionNoIn();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1122:29: ( LOR logicalANDExpressionNoIn )*
                    do
                    {
                        int alt37 = 2;
                        int LA37_0 = input.LA(1);

                        if ((LA37_0 == LOR))
                        {
                            alt37 = 1;
                        }


                        switch (alt37)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1122:31: LOR logicalANDExpressionNoIn
                                {
                                    Match(input, LOR, FOLLOW_LOR_in_logicalORExpressionNoIn4056);
                                    PushFollow(FOLLOW_logicalANDExpressionNoIn_in_logicalORExpressionNoIn4058);
                                    logicalANDExpressionNoIn();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop37;
                        }
                    } while (true);

                loop37:
                    ; // Stops C# compiler whining that label 'loop37' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "logicalORExpressionNoIn"

        public class conditionalExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "conditionalExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1129:1: conditionalExpression : logicalORExpression ( QUE assignmentExpression COLON assignmentExpression )? ;
        public ES3Parser.conditionalExpression_return conditionalExpression() // throws RecognitionException [1]
        {
            ES3Parser.conditionalExpression_return retval = new ES3Parser.conditionalExpression_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1130:2: ( logicalORExpression ( QUE assignmentExpression COLON assignmentExpression )? )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1130:4: logicalORExpression ( QUE assignmentExpression COLON assignmentExpression )?
                {
                    PushFollow(FOLLOW_logicalORExpression_in_conditionalExpression4077);
                    logicalORExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1130:24: ( QUE assignmentExpression COLON assignmentExpression )?
                    int alt38 = 2;
                    int LA38_0 = input.LA(1);

                    if ((LA38_0 == QUE))
                    {
                        alt38 = 1;
                    }
                    switch (alt38)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1130:26: QUE assignmentExpression COLON assignmentExpression
                            {
                                Match(input, QUE, FOLLOW_QUE_in_conditionalExpression4081);
                                PushFollow(FOLLOW_assignmentExpression_in_conditionalExpression4083);
                                assignmentExpression();
                                state.followingStackPointer--;

                                Match(input, COLON, FOLLOW_COLON_in_conditionalExpression4085);
                                PushFollow(FOLLOW_assignmentExpression_in_conditionalExpression4087);
                                assignmentExpression();
                                state.followingStackPointer--;


                            }
                            break;

                    }


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "conditionalExpression"

        public class conditionalExpressionNoIn_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "conditionalExpressionNoIn"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1133:1: conditionalExpressionNoIn : logicalORExpressionNoIn ( QUE assignmentExpressionNoIn COLON assignmentExpressionNoIn )? ;
        public ES3Parser.conditionalExpressionNoIn_return conditionalExpressionNoIn()
        // throws RecognitionException [1]
        {
            ES3Parser.conditionalExpressionNoIn_return retval =
                new ES3Parser.conditionalExpressionNoIn_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1134:2: ( logicalORExpressionNoIn ( QUE assignmentExpressionNoIn COLON assignmentExpressionNoIn )? )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1134:4: logicalORExpressionNoIn ( QUE assignmentExpressionNoIn COLON assignmentExpressionNoIn )?
                {
                    PushFollow(FOLLOW_logicalORExpressionNoIn_in_conditionalExpressionNoIn4101);
                    logicalORExpressionNoIn();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1134:28: ( QUE assignmentExpressionNoIn COLON assignmentExpressionNoIn )?
                    int alt39 = 2;
                    int LA39_0 = input.LA(1);

                    if ((LA39_0 == QUE))
                    {
                        alt39 = 1;
                    }
                    switch (alt39)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1134:30: QUE assignmentExpressionNoIn COLON assignmentExpressionNoIn
                            {
                                Match(input, QUE, FOLLOW_QUE_in_conditionalExpressionNoIn4105);
                                PushFollow(FOLLOW_assignmentExpressionNoIn_in_conditionalExpressionNoIn4107);
                                assignmentExpressionNoIn();
                                state.followingStackPointer--;

                                Match(input, COLON, FOLLOW_COLON_in_conditionalExpressionNoIn4109);
                                PushFollow(FOLLOW_assignmentExpressionNoIn_in_conditionalExpressionNoIn4111);
                                assignmentExpressionNoIn();
                                state.followingStackPointer--;


                            }
                            break;

                    }


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "conditionalExpressionNoIn"

        public class assignmentExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "assignmentExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1163:1: assignmentExpression : lhs= conditionalExpression ({...}? assignmentOperator assignmentExpression )? ;
        public ES3Parser.assignmentExpression_return assignmentExpression() // throws RecognitionException [1]
        {
            ES3Parser.assignmentExpression_return retval = new ES3Parser.assignmentExpression_return();
            retval.Start = input.LT(1);

            ES3Parser.conditionalExpression_return lhs = default(ES3Parser.conditionalExpression_return);



            Object[] isLhs = new Object[1];

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1168:2: (lhs= conditionalExpression ({...}? assignmentOperator assignmentExpression )? )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1168:4: lhs= conditionalExpression ({...}? assignmentOperator assignmentExpression )?
                {
                    PushFollow(FOLLOW_conditionalExpression_in_assignmentExpression4139);
                    lhs = conditionalExpression();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1169:2: ({...}? assignmentOperator assignmentExpression )?
                    int alt40 = 2;
                    int LA40_0 = input.LA(1);

                    if (((LA40_0 >= ASSIGN && LA40_0 <= XORASS) || LA40_0 == DIVASS))
                    {
                        int LA40_1 = input.LA(2);

                        if (((isLeftHandSideAssign(lhs, isLhs))))
                        {
                            alt40 = 1;
                        }
                    }
                    switch (alt40)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1169:4: {...}? assignmentOperator assignmentExpression
                            {
                                if (!((isLeftHandSideAssign(lhs, isLhs))))
                                {
                                    throw new FailedPredicateException(input, "assignmentExpression",
                                                                       " isLeftHandSideAssign(lhs, isLhs) ");
                                }
                                PushFollow(FOLLOW_assignmentOperator_in_assignmentExpression4146);
                                assignmentOperator();
                                state.followingStackPointer--;

                                PushFollow(FOLLOW_assignmentExpression_in_assignmentExpression4148);
                                assignmentExpression();
                                state.followingStackPointer--;


                            }
                            break;

                    }


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "assignmentExpression"

        public class assignmentOperator_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "assignmentOperator"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1172:1: assignmentOperator : ( ASSIGN | MULASS | DIVASS | MODASS | ADDASS | SUBASS | SHLASS | SHRASS | SHUASS | ANDASS | XORASS | ORASS );
        public ES3Parser.assignmentOperator_return assignmentOperator() // throws RecognitionException [1]
        {
            ES3Parser.assignmentOperator_return retval = new ES3Parser.assignmentOperator_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1173:2: ( ASSIGN | MULASS | DIVASS | MODASS | ADDASS | SUBASS | SHLASS | SHRASS | SHUASS | ANDASS | XORASS | ORASS )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:
                {
                    if ((input.LA(1) >= ASSIGN && input.LA(1) <= XORASS) || input.LA(1) == DIVASS)
                    {
                        input.Consume();
                        state.errorRecovery = false;
                    }
                    else
                    {
                        MismatchedSetException mse = new MismatchedSetException(null, input);
                        throw mse;
                    }


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "assignmentOperator"

        public class assignmentExpressionNoIn_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "assignmentExpressionNoIn"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1176:1: assignmentExpressionNoIn : lhs= conditionalExpressionNoIn ({...}? assignmentOperator assignmentExpressionNoIn )? ;
        public ES3Parser.assignmentExpressionNoIn_return assignmentExpressionNoIn()
        // throws RecognitionException [1]
        {
            ES3Parser.assignmentExpressionNoIn_return retval =
                new ES3Parser.assignmentExpressionNoIn_return();
            retval.Start = input.LT(1);

            ES3Parser.conditionalExpressionNoIn_return lhs =
                default(ES3Parser.conditionalExpressionNoIn_return);



            Object[] isLhs = new Object[1];

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1181:2: (lhs= conditionalExpressionNoIn ({...}? assignmentOperator assignmentExpressionNoIn )? )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1181:4: lhs= conditionalExpressionNoIn ({...}? assignmentOperator assignmentExpressionNoIn )?
                {
                    PushFollow(FOLLOW_conditionalExpressionNoIn_in_assignmentExpressionNoIn4225);
                    lhs = conditionalExpressionNoIn();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1182:2: ({...}? assignmentOperator assignmentExpressionNoIn )?
                    int alt41 = 2;
                    int LA41_0 = input.LA(1);

                    if (((LA41_0 >= ASSIGN && LA41_0 <= XORASS) || LA41_0 == DIVASS))
                    {
                        int LA41_1 = input.LA(2);

                        if (((isLeftHandSideAssign(lhs, isLhs))))
                        {
                            alt41 = 1;
                        }
                    }
                    switch (alt41)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1182:4: {...}? assignmentOperator assignmentExpressionNoIn
                            {
                                if (!((isLeftHandSideAssign(lhs, isLhs))))
                                {
                                    throw new FailedPredicateException(input, "assignmentExpressionNoIn",
                                                                       " isLeftHandSideAssign(lhs, isLhs) ");
                                }
                                PushFollow(FOLLOW_assignmentOperator_in_assignmentExpressionNoIn4232);
                                assignmentOperator();
                                state.followingStackPointer--;

                                PushFollow(FOLLOW_assignmentExpressionNoIn_in_assignmentExpressionNoIn4234);
                                assignmentExpressionNoIn();
                                state.followingStackPointer--;


                            }
                            break;

                    }


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "assignmentExpressionNoIn"

        public class expression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "expression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1189:1: expression : exprs+= assignmentExpression ( COMMA exprs+= assignmentExpression )* ;
        public ES3Parser.expression_return expression() // throws RecognitionException [1]
        {
            ES3Parser.expression_return retval = new ES3Parser.expression_return();
            retval.Start = input.LT(1);

            IList list_exprs = null;
            ES3Parser.assignmentExpression_return exprs = default(ES3Parser.assignmentExpression_return);
            exprs = null;
            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1190:2: (exprs+= assignmentExpression ( COMMA exprs+= assignmentExpression )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1190:4: exprs+= assignmentExpression ( COMMA exprs+= assignmentExpression )*
                {
                    PushFollow(FOLLOW_assignmentExpression_in_expression4256);
                    exprs = assignmentExpression();
                    state.followingStackPointer--;

                    if (list_exprs == null) list_exprs = new ArrayList();
                    list_exprs.Add(exprs.Template);

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1190:32: ( COMMA exprs+= assignmentExpression )*
                    do
                    {
                        int alt42 = 2;
                        int LA42_0 = input.LA(1);

                        if ((LA42_0 == COMMA))
                        {
                            alt42 = 1;
                        }


                        switch (alt42)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1190:34: COMMA exprs+= assignmentExpression
                                {
                                    Match(input, COMMA, FOLLOW_COMMA_in_expression4260);
                                    PushFollow(FOLLOW_assignmentExpression_in_expression4264);
                                    exprs = assignmentExpression();
                                    state.followingStackPointer--;

                                    if (list_exprs == null) list_exprs = new ArrayList();
                                    list_exprs.Add(exprs.Template);


                                }
                                break;

                            default:
                                goto loop42;
                        }
                    } while (true);

                loop42:
                    ; // Stops C# compiler whining that label 'loop42' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "expression"

        public class expressionNoIn_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "expressionNoIn"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1195:1: expressionNoIn : exprs+= assignmentExpressionNoIn ( COMMA exprs+= assignmentExpressionNoIn )* ;
        public ES3Parser.expressionNoIn_return expressionNoIn() // throws RecognitionException [1]
        {
            ES3Parser.expressionNoIn_return retval = new ES3Parser.expressionNoIn_return();
            retval.Start = input.LT(1);

            IList list_exprs = null;
            ES3Parser.assignmentExpressionNoIn_return exprs =
                default(ES3Parser.assignmentExpressionNoIn_return);
            exprs = null;
            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1196:2: (exprs+= assignmentExpressionNoIn ( COMMA exprs+= assignmentExpressionNoIn )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1196:4: exprs+= assignmentExpressionNoIn ( COMMA exprs+= assignmentExpressionNoIn )*
                {
                    PushFollow(FOLLOW_assignmentExpressionNoIn_in_expressionNoIn4284);
                    exprs = assignmentExpressionNoIn();
                    state.followingStackPointer--;

                    if (list_exprs == null) list_exprs = new ArrayList();
                    list_exprs.Add(exprs.Template);

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1196:36: ( COMMA exprs+= assignmentExpressionNoIn )*
                    do
                    {
                        int alt43 = 2;
                        int LA43_0 = input.LA(1);

                        if ((LA43_0 == COMMA))
                        {
                            alt43 = 1;
                        }


                        switch (alt43)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1196:38: COMMA exprs+= assignmentExpressionNoIn
                                {
                                    Match(input, COMMA, FOLLOW_COMMA_in_expressionNoIn4288);
                                    PushFollow(FOLLOW_assignmentExpressionNoIn_in_expressionNoIn4292);
                                    exprs = assignmentExpressionNoIn();
                                    state.followingStackPointer--;

                                    if (list_exprs == null) list_exprs = new ArrayList();
                                    list_exprs.Add(exprs.Template);


                                }
                                break;

                            default:
                                goto loop43;
                        }
                    } while (true);

                loop43:
                    ; // Stops C# compiler whining that label 'loop43' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "expressionNoIn"

        public class semic_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "semic"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1223:1: semic : ( SEMIC | EOF | RBRACE | EOL | MultiLineComment );
        public semic_return semic() // throws RecognitionException [1]
        {
            var retval = new semic_return();
            retval.Start = input.LT(1);


            // Mark current position so we can unconsume a RBRACE.
            int marker = input.Mark();
            // Promote EOL if appropriate	
            PromoteEol(retval);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1231:2: ( SEMIC | EOF | RBRACE | EOL | MultiLineComment )
                int alt44 = 5;
                switch (input.LA(1))
                {
                    case SEMIC:
                        {
                            alt44 = 1;
                        }
                        break;
                    case EOF:
                        {
                            alt44 = 2;
                        }
                        break;
                    case RBRACE:
                        {
                            alt44 = 3;
                        }
                        break;
                    case EOL:
                        {
                            alt44 = 4;
                        }
                        break;
                    case MultiLineComment:
                        {
                            alt44 = 5;
                        }
                        break;
                    default:
                        NoViableAltException nvae_d44s0 =
                            new NoViableAltException("", 44, 0, input);

                        throw nvae_d44s0;
                }

                switch (alt44)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1231:4: SEMIC
                        {
                            Match(input, SEMIC, FOLLOW_SEMIC_in_semic4326);

                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1232:4: EOF
                        {
                            Match(input, EOF, FOLLOW_EOF_in_semic4331);

                        }
                        break;
                    case 3:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1233:4: RBRACE
                        {
                            Match(input, RBRACE, FOLLOW_RBRACE_in_semic4336);
                            input.Rewind(marker);

                        }
                        break;
                    case 4:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1234:4: EOL
                        {
                            Match(input, EOL, FOLLOW_EOL_in_semic4343);

                        }
                        break;
                    case 5:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1234:10: MultiLineComment
                        {
                            Match(input, MultiLineComment, FOLLOW_MultiLineComment_in_semic4347);

                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            return retval;
        }

        // $ANTLR end "semic"

        protected class statement_scope
        {
            protected internal bool isBlock;
        }

        protected Stack statement_stack = new Stack();

        public class statement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "statement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1242:1: statement options {k=1; } : ({...}? block | statementTail ) -> {instrument && !$statement::isBlock}? cover_line(src=$program::namecode=$textline=$start.getLine()) -> ignore(code=$text);
        public statement_return statement() // throws RecognitionException [1]
        {
            statement_stack.Push(new statement_scope());
            var retval = new statement_return();
            retval.Start = input.LT(1);

            var instrument = false;

            if (((IToken)retval.Start).Line > ((program_scope)program_stack.Peek()).stopLine)
            {
                ((program_scope)program_stack.Peek()).stopLine = ((IToken)retval.Start).Line;
                instrument = true;
            }

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1266:2: ( ({...}? block | statementTail ) -> {instrument && !$statement::isBlock}? cover_line(src=$program::namecode=$textline=$start.getLine()) -> ignore(code=$text))
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1266:4: ({...}? block | statementTail )
                {
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1266:4: ({...}? block | statementTail )
                    int alt45 = 2;
                    alt45 = dfa45.Predict(input);
                    switch (alt45)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1266:5: {...}? block
                            {
                                if (!((((statement_scope)statement_stack.Peek()).isBlock = input.LA(1) == LBRACE)))
                                {
                                    throw new FailedPredicateException(input, "statement",
                                                                       " $statement::isBlock = input.LA(1) == LBRACE ");
                                }
                                PushFollow(FOLLOW_block_in_statement4390);
                                block();
                                state.followingStackPointer--;


                            }
                            break;
                        case 2:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1266:62: statementTail
                            {
                                PushFollow(FOLLOW_statementTail_in_statement4394);
                                statementTail();
                                state.followingStackPointer--;


                            }
                            break;

                    }



                    // TEMPLATE REWRITE
                    // 1267:4: -> {instrument && !$statement::isBlock}? cover_line(src=$program::namecode=$textline=$start.getLine())
                    if (instrument && !((statement_scope)statement_stack.Peek()).isBlock)
                    {
                        retval.ST = TemplateLib.GetInstanceOf("cover_line", new STAttrMap().Add("src", ((program_scope)program_stack.Peek()).name)
                                                                             .Add("code", input.ToString((IToken)retval.Start, input.LT(-1)))
                                                                             .Add("line", ((IToken)retval.Start).Line));
                    }
                    else // 1268:4: -> ignore(code=$text)
                    {
                        retval.ST = TemplateLib.GetInstanceOf("ignore", new STAttrMap().Add("code", input.ToString((IToken)retval.Start, input.LT(-1))));
                    }

                    ((TokenRewriteStream)input).Replace(
                        ((IToken)retval.Start).TokenIndex,
                        input.LT(-1).TokenIndex,
                        retval.ST);
                }

                retval.Stop = input.LT(-1);


                if (instrument && !((statement_scope)statement_stack.Peek()).isBlock)
                {
                    ((program_scope)program_stack.Peek()).executableLines.Add(((IToken)retval.Start).Line);
                }
                if (Verbose)
                {
                    Console.WriteLine("\n[INFO] Instrumenting statement on line {0}", +((IToken)retval.Start).Line);
                }

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
                statement_stack.Pop();
            }
            return retval;
        }

        // $ANTLR end "statement"

        public class statementTail_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "statementTail"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1271:1: statementTail : ( variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );
        public ES3Parser.statementTail_return statementTail() // throws RecognitionException [1]
        {
            ES3Parser.statementTail_return retval = new ES3Parser.statementTail_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1272:2: ( variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement )
                int alt46 = 13;
                alt46 = dfa46.Predict(input);
                switch (alt46)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1272:4: variableStatement
                        {
                            PushFollow(FOLLOW_variableStatement_in_statementTail4442);
                            variableStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1273:4: emptyStatement
                        {
                            PushFollow(FOLLOW_emptyStatement_in_statementTail4447);
                            emptyStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 3:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1274:4: expressionStatement
                        {
                            PushFollow(FOLLOW_expressionStatement_in_statementTail4452);
                            expressionStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 4:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1275:4: ifStatement
                        {
                            PushFollow(FOLLOW_ifStatement_in_statementTail4457);
                            ifStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 5:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1276:4: iterationStatement
                        {
                            PushFollow(FOLLOW_iterationStatement_in_statementTail4462);
                            iterationStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 6:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1277:4: continueStatement
                        {
                            PushFollow(FOLLOW_continueStatement_in_statementTail4467);
                            continueStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 7:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1278:4: breakStatement
                        {
                            PushFollow(FOLLOW_breakStatement_in_statementTail4472);
                            breakStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 8:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1279:4: returnStatement
                        {
                            PushFollow(FOLLOW_returnStatement_in_statementTail4477);
                            returnStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 9:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1280:4: withStatement
                        {
                            PushFollow(FOLLOW_withStatement_in_statementTail4482);
                            withStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 10:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1281:4: labelledStatement
                        {
                            PushFollow(FOLLOW_labelledStatement_in_statementTail4487);
                            labelledStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 11:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1282:4: switchStatement
                        {
                            PushFollow(FOLLOW_switchStatement_in_statementTail4492);
                            switchStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 12:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1283:4: throwStatement
                        {
                            PushFollow(FOLLOW_throwStatement_in_statementTail4497);
                            throwStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 13:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1284:4: tryStatement
                        {
                            PushFollow(FOLLOW_tryStatement_in_statementTail4502);
                            tryStatement();
                            state.followingStackPointer--;


                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "statementTail"

        public class block_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "block"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1289:1: block : lb= LBRACE ( statement )* RBRACE ;
        public ES3Parser.block_return block() // throws RecognitionException [1]
        {
            ES3Parser.block_return retval = new ES3Parser.block_return();
            retval.Start = input.LT(1);

            IToken lb = null;

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1290:2: (lb= LBRACE ( statement )* RBRACE )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1290:4: lb= LBRACE ( statement )* RBRACE
                {
                    lb = (IToken)Match(input, LBRACE, FOLLOW_LBRACE_in_block4517);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1290:14: ( statement )*
                    do
                    {
                        int alt47 = 2;
                        int LA47_0 = input.LA(1);

                        if (((LA47_0 >= NULL && LA47_0 <= BREAK) || LA47_0 == CONTINUE ||
                             (LA47_0 >= DELETE && LA47_0 <= DO) || (LA47_0 >= FOR && LA47_0 <= IF) ||
                             (LA47_0 >= NEW && LA47_0 <= WITH) || LA47_0 == LBRACE || LA47_0 == LPAREN ||
                             LA47_0 == LBRACK || LA47_0 == SEMIC || (LA47_0 >= ADD && LA47_0 <= SUB) ||
                             (LA47_0 >= INC && LA47_0 <= DEC) || (LA47_0 >= NOT && LA47_0 <= INV) ||
                             (LA47_0 >= Identifier && LA47_0 <= StringLiteral) || LA47_0 == RegularExpressionLiteral ||
                             (LA47_0 >= DecimalLiteral && LA47_0 <= HexIntegerLiteral)))
                        {
                            alt47 = 1;
                        }


                        switch (alt47)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1290:14: statement
                                {
                                    PushFollow(FOLLOW_statement_in_block4519);
                                    statement();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop47;
                        }
                    } while (true);

                loop47:
                    ; // Stops C# compiler whining that label 'loop47' has no statements

                    Match(input, RBRACE, FOLLOW_RBRACE_in_block4522);

                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "block"

        public class variableStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "variableStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1298:1: variableStatement : VAR variableDeclaration ( COMMA variableDeclaration )* semic ;
        public ES3Parser.variableStatement_return variableStatement() // throws RecognitionException [1]
        {
            ES3Parser.variableStatement_return retval = new ES3Parser.variableStatement_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1299:2: ( VAR variableDeclaration ( COMMA variableDeclaration )* semic )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1299:4: VAR variableDeclaration ( COMMA variableDeclaration )* semic
                {
                    Match(input, VAR, FOLLOW_VAR_in_variableStatement4540);
                    PushFollow(FOLLOW_variableDeclaration_in_variableStatement4542);
                    variableDeclaration();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1299:28: ( COMMA variableDeclaration )*
                    do
                    {
                        int alt48 = 2;
                        int LA48_0 = input.LA(1);

                        if ((LA48_0 == COMMA))
                        {
                            alt48 = 1;
                        }


                        switch (alt48)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1299:30: COMMA variableDeclaration
                                {
                                    Match(input, COMMA, FOLLOW_COMMA_in_variableStatement4546);
                                    PushFollow(FOLLOW_variableDeclaration_in_variableStatement4548);
                                    variableDeclaration();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop48;
                        }
                    } while (true);

                loop48:
                    ; // Stops C# compiler whining that label 'loop48' has no statements

                    PushFollow(FOLLOW_semic_in_variableStatement4553);
                    semic();
                    state.followingStackPointer--;


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "variableStatement"

        public class variableDeclaration_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "variableDeclaration"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1303:1: variableDeclaration : Identifier ( ASSIGN assignmentExpression )? ;
        public ES3Parser.variableDeclaration_return variableDeclaration() // throws RecognitionException [1]
        {
            ES3Parser.variableDeclaration_return retval = new ES3Parser.variableDeclaration_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1304:2: ( Identifier ( ASSIGN assignmentExpression )? )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1304:4: Identifier ( ASSIGN assignmentExpression )?
                {
                    Match(input, Identifier, FOLLOW_Identifier_in_variableDeclaration4566);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1304:15: ( ASSIGN assignmentExpression )?
                    int alt49 = 2;
                    int LA49_0 = input.LA(1);

                    if ((LA49_0 == ASSIGN))
                    {
                        alt49 = 1;
                    }
                    switch (alt49)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1304:17: ASSIGN assignmentExpression
                            {
                                Match(input, ASSIGN, FOLLOW_ASSIGN_in_variableDeclaration4570);
                                PushFollow(FOLLOW_assignmentExpression_in_variableDeclaration4572);
                                assignmentExpression();
                                state.followingStackPointer--;


                            }
                            break;

                    }


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "variableDeclaration"

        public class variableDeclarationNoIn_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "variableDeclarationNoIn"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1307:1: variableDeclarationNoIn : Identifier ( ASSIGN assignmentExpressionNoIn )? ;
        public ES3Parser.variableDeclarationNoIn_return variableDeclarationNoIn()
        // throws RecognitionException [1]
        {
            ES3Parser.variableDeclarationNoIn_return retval =
                new ES3Parser.variableDeclarationNoIn_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1308:2: ( Identifier ( ASSIGN assignmentExpressionNoIn )? )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1308:4: Identifier ( ASSIGN assignmentExpressionNoIn )?
                {
                    Match(input, Identifier, FOLLOW_Identifier_in_variableDeclarationNoIn4587);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1308:15: ( ASSIGN assignmentExpressionNoIn )?
                    int alt50 = 2;
                    int LA50_0 = input.LA(1);

                    if ((LA50_0 == ASSIGN))
                    {
                        alt50 = 1;
                    }
                    switch (alt50)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1308:17: ASSIGN assignmentExpressionNoIn
                            {
                                Match(input, ASSIGN, FOLLOW_ASSIGN_in_variableDeclarationNoIn4591);
                                PushFollow(FOLLOW_assignmentExpressionNoIn_in_variableDeclarationNoIn4593);
                                assignmentExpressionNoIn();
                                state.followingStackPointer--;


                            }
                            break;

                    }


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "variableDeclarationNoIn"

        public class emptyStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "emptyStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1315:1: emptyStatement : SEMIC ;
        public ES3Parser.emptyStatement_return emptyStatement() // throws RecognitionException [1]
        {
            ES3Parser.emptyStatement_return retval = new ES3Parser.emptyStatement_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1316:2: ( SEMIC )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1316:4: SEMIC
                {
                    Match(input, SEMIC, FOLLOW_SEMIC_in_emptyStatement4612);

                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "emptyStatement"

        public class expressionStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "expressionStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1329:1: expressionStatement : expression semic ;
        public ES3Parser.expressionStatement_return expressionStatement() // throws RecognitionException [1]
        {
            ES3Parser.expressionStatement_return retval = new ES3Parser.expressionStatement_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1330:2: ( expression semic )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1330:4: expression semic
                {
                    PushFollow(FOLLOW_expression_in_expressionStatement4630);
                    expression();
                    state.followingStackPointer--;

                    PushFollow(FOLLOW_semic_in_expressionStatement4632);
                    semic();
                    state.followingStackPointer--;


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "expressionStatement"

        public class ifStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "ifStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1338:1: ifStatement : IF LPAREN expression RPAREN statement ({...}? elseStatement )? -> template(p=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)body=wrapInBraces($statement.start, $statement.stop, input)elseClause=\r\n\t $elseStatement.stop != null ? input.toString($statement.stop.getTokenIndex()+1, $elseStatement.stop.getTokenIndex() ) : null) \"<p><body><elseClause>\";
        public ES3Parser.ifStatement_return ifStatement() // throws RecognitionException [1]
        {
            ES3Parser.ifStatement_return retval = new ES3Parser.ifStatement_return();
            retval.Start = input.LT(1);

            ES3Parser.statement_return statement1 = default(ES3Parser.statement_return);

            ES3Parser.elseStatement_return elseStatement2 = default(ES3Parser.elseStatement_return);


            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1340:2: ( IF LPAREN expression RPAREN statement ({...}? elseStatement )? -> template(p=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)body=wrapInBraces($statement.start, $statement.stop, input)elseClause=\r\n\t $elseStatement.stop != null ? input.toString($statement.stop.getTokenIndex()+1, $elseStatement.stop.getTokenIndex() ) : null) \"<p><body><elseClause>\")
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1340:4: IF LPAREN expression RPAREN statement ({...}? elseStatement )?
                {
                    Match(input, IF, FOLLOW_IF_in_ifStatement4650);
                    Match(input, LPAREN, FOLLOW_LPAREN_in_ifStatement4652);
                    PushFollow(FOLLOW_expression_in_ifStatement4654);
                    expression();
                    state.followingStackPointer--;

                    Match(input, RPAREN, FOLLOW_RPAREN_in_ifStatement4656);
                    PushFollow(FOLLOW_statement_in_ifStatement4658);
                    statement1 = statement();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1340:42: ({...}? elseStatement )?
                    int alt51 = 2;
                    int LA51_0 = input.LA(1);

                    if ((LA51_0 == ELSE))
                    {
                        int LA51_1 = input.LA(2);

                        if (((input.LA(1) == ELSE)))
                        {
                            alt51 = 1;
                        }
                    }
                    switch (alt51)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1340:44: {...}? elseStatement
                            {
                                if (!((input.LA(1) == ELSE)))
                                {
                                    throw new FailedPredicateException(input, "ifStatement", " input.LA(1) == ELSE ");
                                }
                                PushFollow(FOLLOW_elseStatement_in_ifStatement4664);
                                elseStatement2 = elseStatement();
                                state.followingStackPointer--;


                            }
                            break;

                    }



                    // TEMPLATE REWRITE
                    // 1342:2: -> template(p=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)body=wrapInBraces($statement.start, $statement.stop, input)elseClause=\r\n\t $elseStatement.stop != null ? input.toString($statement.stop.getTokenIndex()+1, $elseStatement.stop.getTokenIndex() ) : null) \"<p><body><elseClause>\"
                    {
                        retval.ST = new StringTemplate(TemplateLib, "<p><body><elseClause>",
                                                       new STAttrMap().Add("p",
                                                                           input.ToString(
                                                                               ((IToken)retval.Start).TokenIndex,
                                                                               ((statement1 != null)
                                                                                    ? ((IToken)statement1.Start)
                                                                                    : null).TokenIndex - 1))
                                                                      .Add("body",
                                                                           wrapInBraces(
                                                                               ((statement1 != null)
                                                                                    ? ((IToken)statement1.Start)
                                                                                    : null),
                                                                               ((statement1 != null)
                                                                                    ? ((IToken)statement1.Stop)
                                                                                    : null), input))
                                                                      .Add("elseClause",
                                                                           ((elseStatement2 != null)
                                                                                ? ((IToken)elseStatement2.Stop)
                                                                                : null) != null
                                                                               ? input.ToString(
                                                                                   ((statement1 != null)
                                                                                        ? ((IToken)statement1.Stop)
                                                                                        : null).TokenIndex + 1,
                                                                                   ((elseStatement2 != null)
                                                                                        ? ((IToken)elseStatement2.Stop)
                                                                                        : null).TokenIndex)
                                                                               : null));
                    }

                    ((TokenRewriteStream)input).Replace(
                        ((IToken)retval.Start).TokenIndex,
                        input.LT(-1).TokenIndex,
                        retval.ST);
                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "ifStatement"

        public class elseStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "elseStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1348:1: elseStatement : ELSE statement -> template(prefix=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)) \"<prefix><stmt>\";
        public ES3Parser.elseStatement_return elseStatement() // throws RecognitionException [1]
        {
            ES3Parser.elseStatement_return retval = new ES3Parser.elseStatement_return();
            retval.Start = input.LT(1);

            ES3Parser.statement_return statement3 = default(ES3Parser.statement_return);


            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1349:2: ( ELSE statement -> template(prefix=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)) \"<prefix><stmt>\")
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1349:4: ELSE statement
                {
                    Match(input, ELSE, FOLLOW_ELSE_in_elseStatement4736);
                    PushFollow(FOLLOW_statement_in_elseStatement4738);
                    statement3 = statement();
                    state.followingStackPointer--;



                    // TEMPLATE REWRITE
                    // 1350:2: -> template(prefix=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)) \"<prefix><stmt>\"
                    {
                        retval.ST = new StringTemplate(TemplateLib, "<prefix><stmt>",
                                                       new STAttrMap().Add("prefix", input.ToString(((IToken)retval.Start).TokenIndex, ((statement3 != null) ? ((IToken)statement3.Start) : null).TokenIndex - 1))
                                                                      .Add("stmt", wrapInBraces(((statement3 != null) ? ((IToken)statement3.Start) : null), ((statement3 != null) ? ((IToken)statement3.Stop) : null), input)));
                    }

                    ((TokenRewriteStream)input).Replace(
                        ((IToken)retval.Start).TokenIndex,
                        input.LT(-1).TokenIndex,
                        retval.ST);
                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "elseStatement"

        public class iterationStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "iterationStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1357:1: iterationStatement : ( doStatement | whileStatement | forStatement );
        public ES3Parser.iterationStatement_return iterationStatement() // throws RecognitionException [1]
        {
            ES3Parser.iterationStatement_return retval = new ES3Parser.iterationStatement_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1358:2: ( doStatement | whileStatement | forStatement )
                int alt52 = 3;
                switch (input.LA(1))
                {
                    case DO:
                        {
                            alt52 = 1;
                        }
                        break;
                    case WHILE:
                        {
                            alt52 = 2;
                        }
                        break;
                    case FOR:
                        {
                            alt52 = 3;
                        }
                        break;
                    default:
                        NoViableAltException nvae_d52s0 =
                            new NoViableAltException("", 52, 0, input);

                        throw nvae_d52s0;
                }

                switch (alt52)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1358:4: doStatement
                        {
                            PushFollow(FOLLOW_doStatement_in_iterationStatement4775);
                            doStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1359:4: whileStatement
                        {
                            PushFollow(FOLLOW_whileStatement_in_iterationStatement4780);
                            whileStatement();
                            state.followingStackPointer--;


                        }
                        break;
                    case 3:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1360:4: forStatement
                        {
                            PushFollow(FOLLOW_forStatement_in_iterationStatement4785);
                            forStatement();
                            state.followingStackPointer--;


                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "iterationStatement"

        public class doStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "doStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1363:1: doStatement : DO statement WHILE LPAREN expression RPAREN semic -> template(pre=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)post=input.toString($WHILE, $RPAREN)end=$semic.text) \"<pre><stmt><post><end>\";
        public ES3Parser.doStatement_return doStatement() // throws RecognitionException [1]
        {
            ES3Parser.doStatement_return retval = new ES3Parser.doStatement_return();
            retval.Start = input.LT(1);

            IToken WHILE5 = null;
            IToken RPAREN6 = null;
            ES3Parser.statement_return statement4 = default(ES3Parser.statement_return);

            ES3Parser.semic_return semic7 = default(ES3Parser.semic_return);


            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1364:2: ( DO statement WHILE LPAREN expression RPAREN semic -> template(pre=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)post=input.toString($WHILE, $RPAREN)end=$semic.text) \"<pre><stmt><post><end>\")
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1364:4: DO statement WHILE LPAREN expression RPAREN semic
                {
                    Match(input, DO, FOLLOW_DO_in_doStatement4797);
                    PushFollow(FOLLOW_statement_in_doStatement4799);
                    statement4 = statement();
                    state.followingStackPointer--;

                    WHILE5 = (IToken)Match(input, WHILE, FOLLOW_WHILE_in_doStatement4801);
                    Match(input, LPAREN, FOLLOW_LPAREN_in_doStatement4803);
                    PushFollow(FOLLOW_expression_in_doStatement4805);
                    expression();
                    state.followingStackPointer--;

                    RPAREN6 = (IToken)Match(input, RPAREN, FOLLOW_RPAREN_in_doStatement4807);
                    PushFollow(FOLLOW_semic_in_doStatement4809);
                    semic7 = semic();
                    state.followingStackPointer--;



                    // TEMPLATE REWRITE
                    // 1365:2: -> template(pre=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)post=input.toString($WHILE, $RPAREN)end=$semic.text) \"<pre><stmt><post><end>\"
                    {
                        retval.ST = new StringTemplate(TemplateLib, "<pre><stmt><post><end>",
                                                       new STAttrMap().Add("pre",
                                                                           input.ToString(
                                                                               ((IToken)retval.Start).TokenIndex,
                                                                               ((statement4 != null)
                                                                                    ? ((IToken)statement4.Start)
                                                                                    : null).TokenIndex - 1))
                                                                      .Add("stmt",
                                                                           wrapInBraces(
                                                                               ((statement4 != null)
                                                                                    ? ((IToken)statement4.Start)
                                                                                    : null),
                                                                               ((statement4 != null)
                                                                                    ? ((IToken)statement4.Stop)
                                                                                    : null), input))
                                                                      .Add("post", input.ToString(WHILE5, RPAREN6))
                                                                      .Add("end",
                                                                           ((semic7 != null)
                                                                                ? input.ToString(
                                                                                    (IToken)(semic7.Start),
                                                                                    (IToken)(semic7.Stop))
                                                                                : null)));
                    }

                    ((TokenRewriteStream)input).Replace(
                        ((IToken)retval.Start).TokenIndex,
                        input.LT(-1).TokenIndex,
                        retval.ST);
                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "doStatement"

        public class whileStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "whileStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1371:1: whileStatement : WHILE LPAREN expression RPAREN statement -> template(pre=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)) \"<pre><stmt>\";
        public ES3Parser.whileStatement_return whileStatement() // throws RecognitionException [1]
        {
            ES3Parser.whileStatement_return retval = new ES3Parser.whileStatement_return();
            retval.Start = input.LT(1);

            ES3Parser.statement_return statement8 = default(ES3Parser.statement_return);


            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1372:2: ( WHILE LPAREN expression RPAREN statement -> template(pre=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)) \"<pre><stmt>\")
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1372:4: WHILE LPAREN expression RPAREN statement
                {
                    Match(input, WHILE, FOLLOW_WHILE_in_whileStatement4895);
                    Match(input, LPAREN, FOLLOW_LPAREN_in_whileStatement4897);
                    PushFollow(FOLLOW_expression_in_whileStatement4899);
                    expression();
                    state.followingStackPointer--;

                    Match(input, RPAREN, FOLLOW_RPAREN_in_whileStatement4901);
                    PushFollow(FOLLOW_statement_in_whileStatement4903);
                    statement8 = statement();
                    state.followingStackPointer--;



                    // TEMPLATE REWRITE
                    // 1373:2: -> template(pre=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)) \"<pre><stmt>\"
                    {
                        retval.ST = new StringTemplate(TemplateLib, "<pre><stmt>",
                                                       new STAttrMap().Add("pre",
                                                                           input.ToString(
                                                                               ((IToken)retval.Start).TokenIndex,
                                                                               ((statement8 != null)
                                                                                    ? ((IToken)statement8.Start)
                                                                                    : null).TokenIndex - 1))
                                                                      .Add("stmt",
                                                                           wrapInBraces(
                                                                               ((statement8 != null)
                                                                                    ? ((IToken)statement8.Start)
                                                                                    : null),
                                                                               ((statement8 != null)
                                                                                    ? ((IToken)statement8.Stop)
                                                                                    : null), input)));
                    }

                    ((TokenRewriteStream)input).Replace(
                        ((IToken)retval.Start).TokenIndex,
                        input.LT(-1).TokenIndex,
                        retval.ST);
                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "whileStatement"

        public class forStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "forStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1419:1: forStatement : FOR LPAREN forControl RPAREN statement -> template(pre=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)) \"<pre><stmt>\";
        public ES3Parser.forStatement_return forStatement() // throws RecognitionException [1]
        {
            ES3Parser.forStatement_return retval = new ES3Parser.forStatement_return();
            retval.Start = input.LT(1);

            ES3Parser.statement_return statement9 = default(ES3Parser.statement_return);


            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1420:2: ( FOR LPAREN forControl RPAREN statement -> template(pre=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)) \"<pre><stmt>\")
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1420:4: FOR LPAREN forControl RPAREN statement
                {
                    Match(input, FOR, FOLLOW_FOR_in_forStatement4964);
                    Match(input, LPAREN, FOLLOW_LPAREN_in_forStatement4966);
                    PushFollow(FOLLOW_forControl_in_forStatement4968);
                    forControl();
                    state.followingStackPointer--;

                    Match(input, RPAREN, FOLLOW_RPAREN_in_forStatement4970);
                    PushFollow(FOLLOW_statement_in_forStatement4972);
                    statement9 = statement();
                    state.followingStackPointer--;



                    // TEMPLATE REWRITE
                    // 1421:2: -> template(pre=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)) \"<pre><stmt>\"
                    {
                        retval.ST = new StringTemplate(TemplateLib, "<pre><stmt>",
                                                       new STAttrMap().Add("pre",
                                                                           input.ToString(
                                                                               ((IToken)retval.Start).TokenIndex,
                                                                               ((statement9 != null)
                                                                                    ? ((IToken)statement9.Start)
                                                                                    : null).TokenIndex - 1))
                                                                      .Add("stmt",
                                                                           wrapInBraces(
                                                                               ((statement9 != null)
                                                                                    ? ((IToken)statement9.Start)
                                                                                    : null),
                                                                               ((statement9 != null)
                                                                                    ? ((IToken)statement9.Stop)
                                                                                    : null), input)));
                    }

                    ((TokenRewriteStream)input).Replace(
                        ((IToken)retval.Start).TokenIndex,
                        input.LT(-1).TokenIndex,
                        retval.ST);
                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "forStatement"

        public class forControl_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "forControl"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1426:1: forControl : ( forControlVar | forControlExpression | forControlSemic );
        public ES3Parser.forControl_return forControl() // throws RecognitionException [1]
        {
            ES3Parser.forControl_return retval = new ES3Parser.forControl_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1427:2: ( forControlVar | forControlExpression | forControlSemic )
                int alt53 = 3;
                switch (input.LA(1))
                {
                    case VAR:
                        {
                            alt53 = 1;
                        }
                        break;
                    case NULL:
                    case TRUE:
                    case FALSE:
                    case DELETE:
                    case FUNCTION:
                    case NEW:
                    case THIS:
                    case TYPEOF:
                    case VOID:
                    case LBRACE:
                    case LPAREN:
                    case LBRACK:
                    case ADD:
                    case SUB:
                    case INC:
                    case DEC:
                    case NOT:
                    case INV:
                    case Identifier:
                    case StringLiteral:
                    case RegularExpressionLiteral:
                    case DecimalLiteral:
                    case OctalIntegerLiteral:
                    case HexIntegerLiteral:
                        {
                            alt53 = 2;
                        }
                        break;
                    case SEMIC:
                        {
                            alt53 = 3;
                        }
                        break;
                    default:
                        NoViableAltException nvae_d53s0 =
                            new NoViableAltException("", 53, 0, input);

                        throw nvae_d53s0;
                }

                switch (alt53)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1427:4: forControlVar
                        {
                            PushFollow(FOLLOW_forControlVar_in_forControl5031);
                            forControlVar();
                            state.followingStackPointer--;


                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1428:4: forControlExpression
                        {
                            PushFollow(FOLLOW_forControlExpression_in_forControl5036);
                            forControlExpression();
                            state.followingStackPointer--;


                        }
                        break;
                    case 3:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1429:4: forControlSemic
                        {
                            PushFollow(FOLLOW_forControlSemic_in_forControl5041);
                            forControlSemic();
                            state.followingStackPointer--;


                        }
                        break;

                }
                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "forControl"

        public class forControlVar_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "forControlVar"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1432:1: forControlVar : VAR variableDeclarationNoIn ( ( IN expression ) | ( ( COMMA variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )? ) ) ;
        public ES3Parser.forControlVar_return forControlVar() // throws RecognitionException [1]
        {
            ES3Parser.forControlVar_return retval = new ES3Parser.forControlVar_return();
            retval.Start = input.LT(1);

            ES3Parser.expression_return ex1 = default(ES3Parser.expression_return);

            ES3Parser.expression_return ex2 = default(ES3Parser.expression_return);


            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1433:2: ( VAR variableDeclarationNoIn ( ( IN expression ) | ( ( COMMA variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )? ) ) )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1433:4: VAR variableDeclarationNoIn ( ( IN expression ) | ( ( COMMA variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )? ) )
                {
                    Match(input, VAR, FOLLOW_VAR_in_forControlVar5052);
                    PushFollow(FOLLOW_variableDeclarationNoIn_in_forControlVar5054);
                    variableDeclarationNoIn();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1434:2: ( ( IN expression ) | ( ( COMMA variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )? ) )
                    int alt57 = 2;
                    int LA57_0 = input.LA(1);

                    if ((LA57_0 == IN))
                    {
                        alt57 = 1;
                    }
                    else if (((LA57_0 >= SEMIC && LA57_0 <= COMMA)))
                    {
                        alt57 = 2;
                    }
                    else
                    {
                        NoViableAltException nvae_d57s0 =
                            new NoViableAltException("", 57, 0, input);

                        throw nvae_d57s0;
                    }
                    switch (alt57)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1435:3: ( IN expression )
                            {
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1435:3: ( IN expression )
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1436:4: IN expression
                                {
                                    Match(input, IN, FOLLOW_IN_in_forControlVar5066);
                                    PushFollow(FOLLOW_expression_in_forControlVar5068);
                                    expression();
                                    state.followingStackPointer--;


                                }


                            }
                            break;
                        case 2:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1440:3: ( ( COMMA variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )? )
                            {
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1440:3: ( ( COMMA variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )? )
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1441:4: ( COMMA variableDeclarationNoIn )* SEMIC (ex1= expression )? SEMIC (ex2= expression )?
                                {
                                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1441:4: ( COMMA variableDeclarationNoIn )*
                                    do
                                    {
                                        int alt54 = 2;
                                        int LA54_0 = input.LA(1);

                                        if ((LA54_0 == COMMA))
                                        {
                                            alt54 = 1;
                                        }


                                        switch (alt54)
                                        {
                                            case 1:
                                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1441:6: COMMA variableDeclarationNoIn
                                                {
                                                    Match(input, COMMA, FOLLOW_COMMA_in_forControlVar5091);
                                                    PushFollow(FOLLOW_variableDeclarationNoIn_in_forControlVar5093);
                                                    variableDeclarationNoIn();
                                                    state.followingStackPointer--;


                                                }
                                                break;

                                            default:
                                                goto loop54;
                                        }
                                    } while (true);

                                loop54:
                                    ; // Stops C# compiler whining that label 'loop54' has no statements

                                    Match(input, SEMIC, FOLLOW_SEMIC_in_forControlVar5098);
                                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1441:48: (ex1= expression )?
                                    int alt55 = 2;
                                    int LA55_0 = input.LA(1);

                                    if (((LA55_0 >= NULL && LA55_0 <= FALSE) || LA55_0 == DELETE || LA55_0 == FUNCTION ||
                                         LA55_0 == NEW || LA55_0 == THIS || LA55_0 == TYPEOF || LA55_0 == VOID ||
                                         LA55_0 == LBRACE || LA55_0 == LPAREN || LA55_0 == LBRACK ||
                                         (LA55_0 >= ADD && LA55_0 <= SUB) || (LA55_0 >= INC && LA55_0 <= DEC) ||
                                         (LA55_0 >= NOT && LA55_0 <= INV) ||
                                         (LA55_0 >= Identifier && LA55_0 <= StringLiteral) ||
                                         LA55_0 == RegularExpressionLiteral ||
                                         (LA55_0 >= DecimalLiteral && LA55_0 <= HexIntegerLiteral)))
                                    {
                                        alt55 = 1;
                                    }
                                    switch (alt55)
                                    {
                                        case 1:
                                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1441:48: ex1= expression
                                            {
                                                PushFollow(FOLLOW_expression_in_forControlVar5102);
                                                ex1 = expression();
                                                state.followingStackPointer--;


                                            }
                                            break;

                                    }

                                    Match(input, SEMIC, FOLLOW_SEMIC_in_forControlVar5105);
                                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1441:70: (ex2= expression )?
                                    int alt56 = 2;
                                    int LA56_0 = input.LA(1);

                                    if (((LA56_0 >= NULL && LA56_0 <= FALSE) || LA56_0 == DELETE || LA56_0 == FUNCTION ||
                                         LA56_0 == NEW || LA56_0 == THIS || LA56_0 == TYPEOF || LA56_0 == VOID ||
                                         LA56_0 == LBRACE || LA56_0 == LPAREN || LA56_0 == LBRACK ||
                                         (LA56_0 >= ADD && LA56_0 <= SUB) || (LA56_0 >= INC && LA56_0 <= DEC) ||
                                         (LA56_0 >= NOT && LA56_0 <= INV) ||
                                         (LA56_0 >= Identifier && LA56_0 <= StringLiteral) ||
                                         LA56_0 == RegularExpressionLiteral ||
                                         (LA56_0 >= DecimalLiteral && LA56_0 <= HexIntegerLiteral)))
                                    {
                                        alt56 = 1;
                                    }
                                    switch (alt56)
                                    {
                                        case 1:
                                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1441:70: ex2= expression
                                            {
                                                PushFollow(FOLLOW_expression_in_forControlVar5109);
                                                ex2 = expression();
                                                state.followingStackPointer--;


                                            }
                                            break;

                                    }


                                }


                            }
                            break;

                    }


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "forControlVar"

        public class forControlExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "forControlExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1447:1: forControlExpression : ex1= expressionNoIn ({...}? ( IN ex2= expression ) | ( SEMIC (ex2= expression )? SEMIC (ex3= expression )? ) ) ;
        public ES3Parser.forControlExpression_return forControlExpression() // throws RecognitionException [1]
        {
            ES3Parser.forControlExpression_return retval = new ES3Parser.forControlExpression_return();
            retval.Start = input.LT(1);

            ES3Parser.expressionNoIn_return ex1 = default(ES3Parser.expressionNoIn_return);

            ES3Parser.expression_return ex2 = default(ES3Parser.expression_return);

            ES3Parser.expression_return ex3 = default(ES3Parser.expression_return);



            Object[] isLhs = new Object[1];

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1452:2: (ex1= expressionNoIn ({...}? ( IN ex2= expression ) | ( SEMIC (ex2= expression )? SEMIC (ex3= expression )? ) ) )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1452:4: ex1= expressionNoIn ({...}? ( IN ex2= expression ) | ( SEMIC (ex2= expression )? SEMIC (ex3= expression )? ) )
                {
                    PushFollow(FOLLOW_expressionNoIn_in_forControlExpression5139);
                    ex1 = expressionNoIn();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1453:2: ({...}? ( IN ex2= expression ) | ( SEMIC (ex2= expression )? SEMIC (ex3= expression )? ) )
                    int alt60 = 2;
                    int LA60_0 = input.LA(1);

                    if ((LA60_0 == IN))
                    {
                        alt60 = 1;
                    }
                    else if ((LA60_0 == SEMIC))
                    {
                        alt60 = 2;
                    }
                    else
                    {
                        NoViableAltException nvae_d60s0 =
                            new NoViableAltException("", 60, 0, input);

                        throw nvae_d60s0;
                    }
                    switch (alt60)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1454:3: {...}? ( IN ex2= expression )
                            {
                                if (!((IsLeftHandSideIn(ex1, isLhs))))
                                {
                                    throw new FailedPredicateException(input, "forControlExpression",
                                                                       " isLeftHandSideIn(ex1, isLhs) ");
                                }
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1454:37: ( IN ex2= expression )
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1455:4: IN ex2= expression
                                {
                                    Match(input, IN, FOLLOW_IN_in_forControlExpression5154);
                                    PushFollow(FOLLOW_expression_in_forControlExpression5158);
                                    ex2 = expression();
                                    state.followingStackPointer--;


                                }


                            }
                            break;
                        case 2:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1459:3: ( SEMIC (ex2= expression )? SEMIC (ex3= expression )? )
                            {
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1459:3: ( SEMIC (ex2= expression )? SEMIC (ex3= expression )? )
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1460:4: SEMIC (ex2= expression )? SEMIC (ex3= expression )?
                                {
                                    Match(input, SEMIC, FOLLOW_SEMIC_in_forControlExpression5179);
                                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1460:13: (ex2= expression )?
                                    int alt58 = 2;
                                    int LA58_0 = input.LA(1);

                                    if (((LA58_0 >= NULL && LA58_0 <= FALSE) || LA58_0 == DELETE || LA58_0 == FUNCTION ||
                                         LA58_0 == NEW || LA58_0 == THIS || LA58_0 == TYPEOF || LA58_0 == VOID ||
                                         LA58_0 == LBRACE || LA58_0 == LPAREN || LA58_0 == LBRACK ||
                                         (LA58_0 >= ADD && LA58_0 <= SUB) || (LA58_0 >= INC && LA58_0 <= DEC) ||
                                         (LA58_0 >= NOT && LA58_0 <= INV) ||
                                         (LA58_0 >= Identifier && LA58_0 <= StringLiteral) ||
                                         LA58_0 == RegularExpressionLiteral ||
                                         (LA58_0 >= DecimalLiteral && LA58_0 <= HexIntegerLiteral)))
                                    {
                                        alt58 = 1;
                                    }
                                    switch (alt58)
                                    {
                                        case 1:
                                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1460:13: ex2= expression
                                            {
                                                PushFollow(FOLLOW_expression_in_forControlExpression5183);
                                                ex2 = expression();
                                                state.followingStackPointer--;


                                            }
                                            break;

                                    }

                                    Match(input, SEMIC, FOLLOW_SEMIC_in_forControlExpression5186);
                                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1460:35: (ex3= expression )?
                                    int alt59 = 2;
                                    int LA59_0 = input.LA(1);

                                    if (((LA59_0 >= NULL && LA59_0 <= FALSE) || LA59_0 == DELETE || LA59_0 == FUNCTION ||
                                         LA59_0 == NEW || LA59_0 == THIS || LA59_0 == TYPEOF || LA59_0 == VOID ||
                                         LA59_0 == LBRACE || LA59_0 == LPAREN || LA59_0 == LBRACK ||
                                         (LA59_0 >= ADD && LA59_0 <= SUB) || (LA59_0 >= INC && LA59_0 <= DEC) ||
                                         (LA59_0 >= NOT && LA59_0 <= INV) ||
                                         (LA59_0 >= Identifier && LA59_0 <= StringLiteral) ||
                                         LA59_0 == RegularExpressionLiteral ||
                                         (LA59_0 >= DecimalLiteral && LA59_0 <= HexIntegerLiteral)))
                                    {
                                        alt59 = 1;
                                    }
                                    switch (alt59)
                                    {
                                        case 1:
                                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1460:35: ex3= expression
                                            {
                                                PushFollow(FOLLOW_expression_in_forControlExpression5190);
                                                ex3 = expression();
                                                state.followingStackPointer--;


                                            }
                                            break;

                                    }


                                }


                            }
                            break;

                    }


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "forControlExpression"

        public class forControlSemic_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "forControlSemic"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1466:1: forControlSemic : SEMIC (ex1= expression )? SEMIC (ex2= expression )? ;
        public ES3Parser.forControlSemic_return forControlSemic() // throws RecognitionException [1]
        {
            ES3Parser.forControlSemic_return retval = new ES3Parser.forControlSemic_return();
            retval.Start = input.LT(1);

            ES3Parser.expression_return ex1 = default(ES3Parser.expression_return);

            ES3Parser.expression_return ex2 = default(ES3Parser.expression_return);


            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1467:2: ( SEMIC (ex1= expression )? SEMIC (ex2= expression )? )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1467:4: SEMIC (ex1= expression )? SEMIC (ex2= expression )?
                {
                    Match(input, SEMIC, FOLLOW_SEMIC_in_forControlSemic5213);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1467:13: (ex1= expression )?
                    int alt61 = 2;
                    int LA61_0 = input.LA(1);

                    if (((LA61_0 >= NULL && LA61_0 <= FALSE) || LA61_0 == DELETE || LA61_0 == FUNCTION || LA61_0 == NEW ||
                         LA61_0 == THIS || LA61_0 == TYPEOF || LA61_0 == VOID || LA61_0 == LBRACE || LA61_0 == LPAREN ||
                         LA61_0 == LBRACK || (LA61_0 >= ADD && LA61_0 <= SUB) || (LA61_0 >= INC && LA61_0 <= DEC) ||
                         (LA61_0 >= NOT && LA61_0 <= INV) || (LA61_0 >= Identifier && LA61_0 <= StringLiteral) ||
                         LA61_0 == RegularExpressionLiteral || (LA61_0 >= DecimalLiteral && LA61_0 <= HexIntegerLiteral)))
                    {
                        alt61 = 1;
                    }
                    switch (alt61)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1467:13: ex1= expression
                            {
                                PushFollow(FOLLOW_expression_in_forControlSemic5217);
                                ex1 = expression();
                                state.followingStackPointer--;


                            }
                            break;

                    }

                    Match(input, SEMIC, FOLLOW_SEMIC_in_forControlSemic5220);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1467:35: (ex2= expression )?
                    int alt62 = 2;
                    int LA62_0 = input.LA(1);

                    if (((LA62_0 >= NULL && LA62_0 <= FALSE) || LA62_0 == DELETE || LA62_0 == FUNCTION || LA62_0 == NEW ||
                         LA62_0 == THIS || LA62_0 == TYPEOF || LA62_0 == VOID || LA62_0 == LBRACE || LA62_0 == LPAREN ||
                         LA62_0 == LBRACK || (LA62_0 >= ADD && LA62_0 <= SUB) || (LA62_0 >= INC && LA62_0 <= DEC) ||
                         (LA62_0 >= NOT && LA62_0 <= INV) || (LA62_0 >= Identifier && LA62_0 <= StringLiteral) ||
                         LA62_0 == RegularExpressionLiteral || (LA62_0 >= DecimalLiteral && LA62_0 <= HexIntegerLiteral)))
                    {
                        alt62 = 1;
                    }
                    switch (alt62)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1467:35: ex2= expression
                            {
                                PushFollow(FOLLOW_expression_in_forControlSemic5224);
                                ex2 = expression();
                                state.followingStackPointer--;


                            }
                            break;

                    }


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "forControlSemic"

        public class continueStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "continueStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1480:1: continueStatement : CONTINUE ( Identifier )? semic ;
        public ES3Parser.continueStatement_return continueStatement() // throws RecognitionException [1]
        {
            ES3Parser.continueStatement_return retval = new ES3Parser.continueStatement_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1481:2: ( CONTINUE ( Identifier )? semic )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1481:4: CONTINUE ( Identifier )? semic
                {
                    Match(input, CONTINUE, FOLLOW_CONTINUE_in_continueStatement5245);
                    if (input.LA(1) == Identifier) PromoteEol(null);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1481:66: ( Identifier )?
                    int alt63 = 2;
                    int LA63_0 = input.LA(1);

                    if ((LA63_0 == Identifier))
                    {
                        alt63 = 1;
                    }
                    switch (alt63)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1481:66: Identifier
                            {
                                Match(input, Identifier, FOLLOW_Identifier_in_continueStatement5249);

                            }
                            break;

                    }

                    PushFollow(FOLLOW_semic_in_continueStatement5252);
                    semic();
                    state.followingStackPointer--;


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "continueStatement"

        public class breakStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "breakStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1493:1: breakStatement : BREAK ( Identifier )? semic ;
        public ES3Parser.breakStatement_return breakStatement() // throws RecognitionException [1]
        {
            ES3Parser.breakStatement_return retval = new ES3Parser.breakStatement_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1494:2: ( BREAK ( Identifier )? semic )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1494:4: BREAK ( Identifier )? semic
                {
                    Match(input, BREAK, FOLLOW_BREAK_in_breakStatement5270);
                    if (input.LA(1) == Identifier) PromoteEol(null);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1494:63: ( Identifier )?
                    int alt64 = 2;
                    int LA64_0 = input.LA(1);

                    if ((LA64_0 == Identifier))
                    {
                        alt64 = 1;
                    }
                    switch (alt64)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1494:63: Identifier
                            {
                                Match(input, Identifier, FOLLOW_Identifier_in_breakStatement5274);

                            }
                            break;

                    }

                    PushFollow(FOLLOW_semic_in_breakStatement5277);
                    semic();
                    state.followingStackPointer--;


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "breakStatement"

        public class returnStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "returnStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1514:1: returnStatement : RETURN ( expression )? semic ;
        public ES3Parser.returnStatement_return returnStatement() // throws RecognitionException [1]
        {
            ES3Parser.returnStatement_return retval = new ES3Parser.returnStatement_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1515:2: ( RETURN ( expression )? semic )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1515:4: RETURN ( expression )? semic
                {
                    Match(input, RETURN, FOLLOW_RETURN_in_returnStatement5295);
                    PromoteEol(null);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1515:33: ( expression )?
                    int alt65 = 2;
                    int LA65_0 = input.LA(1);

                    if (((LA65_0 >= NULL && LA65_0 <= FALSE) || LA65_0 == DELETE || LA65_0 == FUNCTION || LA65_0 == NEW ||
                         LA65_0 == THIS || LA65_0 == TYPEOF || LA65_0 == VOID || LA65_0 == LBRACE || LA65_0 == LPAREN ||
                         LA65_0 == LBRACK || (LA65_0 >= ADD && LA65_0 <= SUB) || (LA65_0 >= INC && LA65_0 <= DEC) ||
                         (LA65_0 >= NOT && LA65_0 <= INV) || (LA65_0 >= Identifier && LA65_0 <= StringLiteral) ||
                         LA65_0 == RegularExpressionLiteral || (LA65_0 >= DecimalLiteral && LA65_0 <= HexIntegerLiteral)))
                    {
                        alt65 = 1;
                    }
                    switch (alt65)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1515:33: expression
                            {
                                PushFollow(FOLLOW_expression_in_returnStatement5299);
                                expression();
                                state.followingStackPointer--;


                            }
                            break;

                    }

                    PushFollow(FOLLOW_semic_in_returnStatement5302);
                    semic();
                    state.followingStackPointer--;


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "returnStatement"

        public class withStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "withStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1522:1: withStatement : WITH LPAREN expression RPAREN statement -> template(pre=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)) \"<pre><stmt>\";
        public ES3Parser.withStatement_return withStatement() // throws RecognitionException [1]
        {
            ES3Parser.withStatement_return retval = new ES3Parser.withStatement_return();
            retval.Start = input.LT(1);

            ES3Parser.statement_return statement10 = default(ES3Parser.statement_return);


            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1523:2: ( WITH LPAREN expression RPAREN statement -> template(pre=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)) \"<pre><stmt>\")
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1523:4: WITH LPAREN expression RPAREN statement
                {
                    Match(input, WITH, FOLLOW_WITH_in_withStatement5318);
                    Match(input, LPAREN, FOLLOW_LPAREN_in_withStatement5320);
                    PushFollow(FOLLOW_expression_in_withStatement5322);
                    expression();
                    state.followingStackPointer--;

                    Match(input, RPAREN, FOLLOW_RPAREN_in_withStatement5324);
                    PushFollow(FOLLOW_statement_in_withStatement5326);
                    statement10 = statement();
                    state.followingStackPointer--;



                    // TEMPLATE REWRITE
                    // 1524:2: -> template(pre=input.toString($start.getTokenIndex(), $statement.start.getTokenIndex() - 1)stmt=wrapInBraces($statement.start, $statement.stop, input)) \"<pre><stmt>\"
                    {
                        retval.ST = new StringTemplate(TemplateLib, "<pre><stmt>",
                                                       new STAttrMap().Add("pre",
                                                                           input.ToString(
                                                                               ((IToken)retval.Start).TokenIndex,
                                                                               ((statement10 != null)
                                                                                    ? ((IToken)statement10.Start)
                                                                                    : null).TokenIndex - 1))
                                                                      .Add("stmt",
                                                                           wrapInBraces(
                                                                               ((statement10 != null)
                                                                                    ? ((IToken)statement10.Start)
                                                                                    : null),
                                                                               ((statement10 != null)
                                                                                    ? ((IToken)statement10.Stop)
                                                                                    : null), input)));
                    }

                    ((TokenRewriteStream)input).Replace(
                        ((IToken)retval.Start).TokenIndex,
                        input.LT(-1).TokenIndex,
                        retval.ST);
                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "withStatement"

        public class switchStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "switchStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1533:1: switchStatement : SWITCH LPAREN expression RPAREN LBRACE ({...}? => defaultClause | caseClause )* RBRACE ;
        public ES3Parser.switchStatement_return switchStatement() // throws RecognitionException [1]
        {
            ES3Parser.switchStatement_return retval = new ES3Parser.switchStatement_return();
            retval.Start = input.LT(1);


            int defaultClauseCount = 0;

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1538:2: ( SWITCH LPAREN expression RPAREN LBRACE ({...}? => defaultClause | caseClause )* RBRACE )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1538:4: SWITCH LPAREN expression RPAREN LBRACE ({...}? => defaultClause | caseClause )* RBRACE
                {
                    Match(input, SWITCH, FOLLOW_SWITCH_in_switchStatement5395);
                    Match(input, LPAREN, FOLLOW_LPAREN_in_switchStatement5397);
                    PushFollow(FOLLOW_expression_in_switchStatement5399);
                    expression();
                    state.followingStackPointer--;

                    Match(input, RPAREN, FOLLOW_RPAREN_in_switchStatement5401);
                    Match(input, LBRACE, FOLLOW_LBRACE_in_switchStatement5403);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1538:43: ({...}? => defaultClause | caseClause )*
                    do
                    {
                        int alt66 = 3;
                        int LA66_0 = input.LA(1);

                        if ((LA66_0 == DEFAULT) && ((defaultClauseCount == 0)))
                        {
                            alt66 = 1;
                        }
                        else if ((LA66_0 == CASE))
                        {
                            alt66 = 2;
                        }


                        switch (alt66)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1538:45: {...}? => defaultClause
                                {
                                    if (!((defaultClauseCount == 0)))
                                    {
                                        throw new FailedPredicateException(input, "switchStatement",
                                                                           " defaultClauseCount == 0 ");
                                    }
                                    PushFollow(FOLLOW_defaultClause_in_switchStatement5410);
                                    defaultClause();
                                    state.followingStackPointer--;

                                    defaultClauseCount++;

                                }
                                break;
                            case 2:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1538:118: caseClause
                                {
                                    PushFollow(FOLLOW_caseClause_in_switchStatement5416);
                                    caseClause();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop66;
                        }
                    } while (true);

                loop66:
                    ; // Stops C# compiler whining that label 'loop66' has no statements

                    Match(input, RBRACE, FOLLOW_RBRACE_in_switchStatement5421);

                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "switchStatement"

        public class caseClause_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "caseClause"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1542:1: caseClause : CASE expression COLON ( statement )* ;
        public ES3Parser.caseClause_return caseClause() // throws RecognitionException [1]
        {
            ES3Parser.caseClause_return retval = new ES3Parser.caseClause_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1543:2: ( CASE expression COLON ( statement )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1543:4: CASE expression COLON ( statement )*
                {
                    Match(input, CASE, FOLLOW_CASE_in_caseClause5434);
                    PushFollow(FOLLOW_expression_in_caseClause5436);
                    expression();
                    state.followingStackPointer--;

                    Match(input, COLON, FOLLOW_COLON_in_caseClause5438);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1543:26: ( statement )*
                    do
                    {
                        int alt67 = 2;
                        int LA67_0 = input.LA(1);

                        if (((LA67_0 >= NULL && LA67_0 <= BREAK) || LA67_0 == CONTINUE ||
                             (LA67_0 >= DELETE && LA67_0 <= DO) || (LA67_0 >= FOR && LA67_0 <= IF) ||
                             (LA67_0 >= NEW && LA67_0 <= WITH) || LA67_0 == LBRACE || LA67_0 == LPAREN ||
                             LA67_0 == LBRACK || LA67_0 == SEMIC || (LA67_0 >= ADD && LA67_0 <= SUB) ||
                             (LA67_0 >= INC && LA67_0 <= DEC) || (LA67_0 >= NOT && LA67_0 <= INV) ||
                             (LA67_0 >= Identifier && LA67_0 <= StringLiteral) || LA67_0 == RegularExpressionLiteral ||
                             (LA67_0 >= DecimalLiteral && LA67_0 <= HexIntegerLiteral)))
                        {
                            alt67 = 1;
                        }


                        switch (alt67)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1543:26: statement
                                {
                                    PushFollow(FOLLOW_statement_in_caseClause5440);
                                    statement();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop67;
                        }
                    } while (true);

                loop67:
                    ; // Stops C# compiler whining that label 'loop67' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "caseClause"

        public class defaultClause_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "defaultClause"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1546:1: defaultClause : DEFAULT COLON ( statement )* ;
        public ES3Parser.defaultClause_return defaultClause() // throws RecognitionException [1]
        {
            ES3Parser.defaultClause_return retval = new ES3Parser.defaultClause_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1547:2: ( DEFAULT COLON ( statement )* )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1547:4: DEFAULT COLON ( statement )*
                {
                    Match(input, DEFAULT, FOLLOW_DEFAULT_in_defaultClause5453);
                    Match(input, COLON, FOLLOW_COLON_in_defaultClause5455);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1547:18: ( statement )*
                    do
                    {
                        int alt68 = 2;
                        int LA68_0 = input.LA(1);

                        if (((LA68_0 >= NULL && LA68_0 <= BREAK) || LA68_0 == CONTINUE ||
                             (LA68_0 >= DELETE && LA68_0 <= DO) || (LA68_0 >= FOR && LA68_0 <= IF) ||
                             (LA68_0 >= NEW && LA68_0 <= WITH) || LA68_0 == LBRACE || LA68_0 == LPAREN ||
                             LA68_0 == LBRACK || LA68_0 == SEMIC || (LA68_0 >= ADD && LA68_0 <= SUB) ||
                             (LA68_0 >= INC && LA68_0 <= DEC) || (LA68_0 >= NOT && LA68_0 <= INV) ||
                             (LA68_0 >= Identifier && LA68_0 <= StringLiteral) || LA68_0 == RegularExpressionLiteral ||
                             (LA68_0 >= DecimalLiteral && LA68_0 <= HexIntegerLiteral)))
                        {
                            alt68 = 1;
                        }


                        switch (alt68)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1547:18: statement
                                {
                                    PushFollow(FOLLOW_statement_in_defaultClause5457);
                                    statement();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop68;
                        }
                    } while (true);

                loop68:
                    ; // Stops C# compiler whining that label 'loop68' has no statements


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "defaultClause"

        public class labelledStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "labelledStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1554:1: labelledStatement : Identifier COLON statement ;
        public ES3Parser.labelledStatement_return labelledStatement() // throws RecognitionException [1]
        {
            ES3Parser.labelledStatement_return retval = new ES3Parser.labelledStatement_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1555:2: ( Identifier COLON statement )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1555:4: Identifier COLON statement
                {
                    Match(input, Identifier, FOLLOW_Identifier_in_labelledStatement5474);
                    Match(input, COLON, FOLLOW_COLON_in_labelledStatement5476);
                    PushFollow(FOLLOW_statement_in_labelledStatement5478);
                    statement();
                    state.followingStackPointer--;


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "labelledStatement"

        public class throwStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "throwStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1578:1: throwStatement : THROW expression semic ;
        public ES3Parser.throwStatement_return throwStatement() // throws RecognitionException [1]
        {
            ES3Parser.throwStatement_return retval = new ES3Parser.throwStatement_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1579:2: ( THROW expression semic )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1579:4: THROW expression semic
                {
                    Match(input, THROW, FOLLOW_THROW_in_throwStatement5498);
                    PromoteEol(null);
                    PushFollow(FOLLOW_expression_in_throwStatement5502);
                    expression();
                    state.followingStackPointer--;

                    PushFollow(FOLLOW_semic_in_throwStatement5504);
                    semic();
                    state.followingStackPointer--;


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "throwStatement"

        public class tryStatement_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "tryStatement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1586:1: tryStatement : TRY block ( catchClause ( finallyClause )? | finallyClause ) ;
        public ES3Parser.tryStatement_return tryStatement() // throws RecognitionException [1]
        {
            ES3Parser.tryStatement_return retval = new ES3Parser.tryStatement_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1587:2: ( TRY block ( catchClause ( finallyClause )? | finallyClause ) )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1587:4: TRY block ( catchClause ( finallyClause )? | finallyClause )
                {
                    Match(input, TRY, FOLLOW_TRY_in_tryStatement5520);
                    PushFollow(FOLLOW_block_in_tryStatement5522);
                    block();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1587:14: ( catchClause ( finallyClause )? | finallyClause )
                    int alt70 = 2;
                    int LA70_0 = input.LA(1);

                    if ((LA70_0 == CATCH))
                    {
                        alt70 = 1;
                    }
                    else if ((LA70_0 == FINALLY))
                    {
                        alt70 = 2;
                    }
                    else
                    {
                        NoViableAltException nvae_d70s0 =
                            new NoViableAltException("", 70, 0, input);

                        throw nvae_d70s0;
                    }
                    switch (alt70)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1587:16: catchClause ( finallyClause )?
                            {
                                PushFollow(FOLLOW_catchClause_in_tryStatement5526);
                                catchClause();
                                state.followingStackPointer--;

                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1587:28: ( finallyClause )?
                                int alt69 = 2;
                                int LA69_0 = input.LA(1);

                                if ((LA69_0 == FINALLY))
                                {
                                    alt69 = 1;
                                }
                                switch (alt69)
                                {
                                    case 1:
                                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1587:28: finallyClause
                                        {
                                            PushFollow(FOLLOW_finallyClause_in_tryStatement5528);
                                            finallyClause();
                                            state.followingStackPointer--;


                                        }
                                        break;

                                }


                            }
                            break;
                        case 2:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1587:45: finallyClause
                            {
                                PushFollow(FOLLOW_finallyClause_in_tryStatement5533);
                                finallyClause();
                                state.followingStackPointer--;


                            }
                            break;

                    }


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "tryStatement"

        public class catchClause_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "catchClause"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1590:1: catchClause : CATCH LPAREN Identifier RPAREN block ;
        public ES3Parser.catchClause_return catchClause() // throws RecognitionException [1]
        {
            ES3Parser.catchClause_return retval = new ES3Parser.catchClause_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1591:2: ( CATCH LPAREN Identifier RPAREN block )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1591:4: CATCH LPAREN Identifier RPAREN block
                {
                    Match(input, CATCH, FOLLOW_CATCH_in_catchClause5547);
                    Match(input, LPAREN, FOLLOW_LPAREN_in_catchClause5549);
                    Match(input, Identifier, FOLLOW_Identifier_in_catchClause5551);
                    Match(input, RPAREN, FOLLOW_RPAREN_in_catchClause5553);
                    PushFollow(FOLLOW_block_in_catchClause5555);
                    block();
                    state.followingStackPointer--;


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "catchClause"

        public class finallyClause_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "finallyClause"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1594:1: finallyClause : FINALLY block ;
        public ES3Parser.finallyClause_return finallyClause() // throws RecognitionException [1]
        {
            ES3Parser.finallyClause_return retval = new ES3Parser.finallyClause_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1595:2: ( FINALLY block )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1595:4: FINALLY block
                {
                    Match(input, FINALLY, FOLLOW_FINALLY_in_finallyClause5567);
                    PushFollow(FOLLOW_block_in_finallyClause5569);
                    block();
                    state.followingStackPointer--;


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            return retval;
        }

        // $ANTLR end "finallyClause"

        protected class functionDeclaration_scope
        {
            protected internal string funcName;
            protected internal int funcLine;
        }

        protected Stack functionDeclaration_stack = new Stack();

        public class functionDeclaration_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "functionDeclaration"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1609:1: functionDeclaration : FUNCTION name= Identifier formalParameterList functionDeclarationBody -> {instrument}? cover_line(src=$program::namecode=$textline=$start.getLine()) -> ignore(code=$text);
        public functionDeclaration_return functionDeclaration() // throws RecognitionException [1]
        {
            functionDeclaration_stack.Push(new functionDeclaration_scope());
            var retval = new functionDeclaration_return();
            retval.Start = input.LT(1);

            IToken name = null;



            var instrument = false;
            if (((IToken)retval.Start).Line > ((program_scope)program_stack.Peek()).stopLine)
            {
                ((program_scope)program_stack.Peek()).executableLines.Add(((IToken)retval.Start).Line);
                ((program_scope)program_stack.Peek()).stopLine = ((IToken)retval.Start).Line;
                instrument = true;
            }
            ((functionDeclaration_scope)functionDeclaration_stack.Peek()).funcLine = ((IToken)retval.Start).Line;

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1631:2: ( FUNCTION name= Identifier formalParameterList functionDeclarationBody -> {instrument}? cover_line(src=$program::namecode=$textline=$start.getLine()) -> ignore(code=$text))
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1631:4: FUNCTION name= Identifier formalParameterList functionDeclarationBody
                {
                    Match(input, FUNCTION, FOLLOW_FUNCTION_in_functionDeclaration5605);
                    name = (IToken)Match(input, Identifier, FOLLOW_Identifier_in_functionDeclaration5609);
                    ((functionDeclaration_scope)functionDeclaration_stack.Peek()).funcName = ((name != null)
                                                                                                   ? name.Text
                                                                                                   : null);
                    PushFollow(FOLLOW_formalParameterList_in_functionDeclaration5613);
                    formalParameterList();
                    state.followingStackPointer--;

                    PushFollow(FOLLOW_functionDeclarationBody_in_functionDeclaration5615);
                    functionDeclarationBody();
                    state.followingStackPointer--;



                    // TEMPLATE REWRITE
                    // 1632:4: -> {instrument}? cover_line(src=$program::namecode=$textline=$start.getLine())
                    if (instrument)
                    {
                        retval.ST = TemplateLib.GetInstanceOf("cover_line",
                                                              new STAttrMap().Add("src",
                                                                                  ((program_scope)program_stack.Peek())
                                                                                      .name)
                                                                             .Add("code",
                                                                                  input.ToString((IToken)retval.Start,
                                                                                                 input.LT(-1)))
                                                                             .Add("line",
                                                                                  ((IToken)retval.Start).Line));
                    }
                    else // 1633:4: -> ignore(code=$text)
                    {
                        retval.ST = TemplateLib.GetInstanceOf("ignore",
                                                              new STAttrMap().Add("code",
                                                                                  input.ToString((IToken)retval.Start,
                                                                                                 input.LT(-1))));
                    }

                    ((TokenRewriteStream)input).Replace(
                        ((IToken)retval.Start).TokenIndex,
                        input.LT(-1).TokenIndex,
                        retval.ST);
                }

                retval.Stop = input.LT(-1);


                ((program_scope)program_stack.Peek()).functions.Add("\"" +
                                                                     ((functionDeclaration_scope)
                                                                      functionDeclaration_stack.Peek()).funcName + ":" +
                                                                     ((IToken)retval.Start).Line + "\"");
                if (Verbose)
                {
                    Console.WriteLine("\n[INFO] Instrumenting function " +
                                       ((functionDeclaration_scope)functionDeclaration_stack.Peek()).funcName +
                                       " on line " + ((IToken)retval.Start).Line);
                }

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
                functionDeclaration_stack.Pop();
            }
            return retval;
        }

        // $ANTLR end "functionDeclaration"

        protected class functionExpression_scope
        {
            protected internal string funcName;
            protected internal int funcLine;
        }

        protected Stack functionExpression_stack = new Stack();

        public class functionExpression_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "functionExpression"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1636:1: functionExpression : FUNCTION ( Identifier )? formalParameterList functionExpressionBody ;
        public ES3Parser.functionExpression_return functionExpression() // throws RecognitionException [1]
        {
            functionExpression_stack.Push(new functionExpression_scope());
            ES3Parser.functionExpression_return retval = new ES3Parser.functionExpression_return();
            retval.Start = input.LT(1);


            ((functionExpression_scope)functionExpression_stack.Peek()).funcLine = ((IToken)retval.Start).Line;

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
            int lastTT = input.LA(-1); //look for = or :
            int nextTT = input.LA(2); //look for an identifer

            if (nextTT == Identifier)
            {
                ((functionExpression_scope)functionExpression_stack.Peek()).funcName = input.LT(2).Text;
            }
            else if (lastTT == COLON || lastTT == ASSIGN)
            {
                ((functionExpression_scope)functionExpression_stack.Peek()).funcName =
                    input.LT(-2).Text.Replace("\"", "\\\"").Replace("'", "\\'");

                //TODO: Continue walking back in case the identifier is object.name
                //right now, I end up just with name.
            }
            else
            {
                ((functionExpression_scope)functionExpression_stack.Peek()).funcName = "(anonymous " +
                                                                                        (++
                                                                                         ((program_scope)
                                                                                          program_stack.Peek())
                                                                                             .anonymousFunctionCount) +
                                                                                        ")";
            }


            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1675:2: ( FUNCTION ( Identifier )? formalParameterList functionExpressionBody )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1675:4: FUNCTION ( Identifier )? formalParameterList functionExpressionBody
                {
                    Match(input, FUNCTION, FOLLOW_FUNCTION_in_functionExpression5670);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1675:13: ( Identifier )?
                    int alt71 = 2;
                    int LA71_0 = input.LA(1);

                    if ((LA71_0 == Identifier))
                    {
                        alt71 = 1;
                    }
                    switch (alt71)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1675:13: Identifier
                            {
                                Match(input, Identifier, FOLLOW_Identifier_in_functionExpression5672);

                            }
                            break;

                    }

                    PushFollow(FOLLOW_formalParameterList_in_functionExpression5675);
                    formalParameterList();
                    state.followingStackPointer--;

                    PushFollow(FOLLOW_functionExpressionBody_in_functionExpression5677);
                    functionExpressionBody();
                    state.followingStackPointer--;


                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
                functionExpression_stack.Pop();
            }
            return retval;
        }

        // $ANTLR end "functionExpression"

        public class formalParameterList_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "formalParameterList"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1678:1: formalParameterList : LPAREN ( Identifier ( COMMA Identifier )* )? RPAREN ;
        public ES3Parser.formalParameterList_return formalParameterList() // throws RecognitionException [1]
        {
            ES3Parser.formalParameterList_return retval = new ES3Parser.formalParameterList_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1679:2: ( LPAREN ( Identifier ( COMMA Identifier )* )? RPAREN )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1679:4: LPAREN ( Identifier ( COMMA Identifier )* )? RPAREN
                {
                    Match(input, LPAREN, FOLLOW_LPAREN_in_formalParameterList5688);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1679:11: ( Identifier ( COMMA Identifier )* )?
                    int alt73 = 2;
                    int LA73_0 = input.LA(1);

                    if ((LA73_0 == Identifier))
                    {
                        alt73 = 1;
                    }
                    switch (alt73)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1679:13: Identifier ( COMMA Identifier )*
                            {
                                Match(input, Identifier, FOLLOW_Identifier_in_formalParameterList5692);
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1679:24: ( COMMA Identifier )*
                                do
                                {
                                    int alt72 = 2;
                                    int LA72_0 = input.LA(1);

                                    if ((LA72_0 == COMMA))
                                    {
                                        alt72 = 1;
                                    }


                                    switch (alt72)
                                    {
                                        case 1:
                                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1679:26: COMMA Identifier
                                            {
                                                Match(input, COMMA, FOLLOW_COMMA_in_formalParameterList5696);
                                                Match(input, Identifier, FOLLOW_Identifier_in_formalParameterList5698);

                                            }
                                            break;

                                        default:
                                            goto loop72;
                                    }
                                } while (true);

                            loop72:
                                ; // Stops C# compiler whining that label 'loop72' has no statements


                            }
                            break;

                    }

                    Match(input, RPAREN, FOLLOW_RPAREN_in_formalParameterList5706);

                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "formalParameterList"

        public class functionDeclarationBody_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "functionDeclarationBody"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1682:1: functionDeclarationBody : lb= LBRACE ( functionDeclarationBodyWithoutBraces )? RBRACE ;
        public ES3Parser.functionDeclarationBody_return functionDeclarationBody()
        // throws RecognitionException [1]
        {
            ES3Parser.functionDeclarationBody_return retval =
                new ES3Parser.functionDeclarationBody_return();
            retval.Start = input.LT(1);

            IToken lb = null;

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1683:2: (lb= LBRACE ( functionDeclarationBodyWithoutBraces )? RBRACE )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1683:4: lb= LBRACE ( functionDeclarationBodyWithoutBraces )? RBRACE
                {
                    lb = (IToken)Match(input, LBRACE, FOLLOW_LBRACE_in_functionDeclarationBody5719);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1683:14: ( functionDeclarationBodyWithoutBraces )?
                    int alt74 = 2;
                    int LA74_0 = input.LA(1);

                    if (((LA74_0 >= NULL && LA74_0 <= BREAK) || LA74_0 == CONTINUE || (LA74_0 >= DELETE && LA74_0 <= DO) ||
                         (LA74_0 >= FOR && LA74_0 <= IF) || (LA74_0 >= NEW && LA74_0 <= WITH) || LA74_0 == LBRACE ||
                         LA74_0 == LPAREN || LA74_0 == LBRACK || LA74_0 == SEMIC || (LA74_0 >= ADD && LA74_0 <= SUB) ||
                         (LA74_0 >= INC && LA74_0 <= DEC) || (LA74_0 >= NOT && LA74_0 <= INV) ||
                         (LA74_0 >= Identifier && LA74_0 <= StringLiteral) || LA74_0 == RegularExpressionLiteral ||
                         (LA74_0 >= DecimalLiteral && LA74_0 <= HexIntegerLiteral)))
                    {
                        alt74 = 1;
                    }
                    switch (alt74)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1683:14: functionDeclarationBodyWithoutBraces
                            {
                                PushFollow(FOLLOW_functionDeclarationBodyWithoutBraces_in_functionDeclarationBody5721);
                                functionDeclarationBodyWithoutBraces();
                                state.followingStackPointer--;


                            }
                            break;

                    }

                    Match(input, RBRACE, FOLLOW_RBRACE_in_functionDeclarationBody5724);

                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "functionDeclarationBody"

        public class functionExpressionBody_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "functionExpressionBody"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1686:1: functionExpressionBody : lb= LBRACE ( functionExpressionBodyWithoutBraces )? RBRACE ;
        public ES3Parser.functionExpressionBody_return functionExpressionBody()
        // throws RecognitionException [1]
        {
            ES3Parser.functionExpressionBody_return retval = new ES3Parser.functionExpressionBody_return();
            retval.Start = input.LT(1);

            IToken lb = null;

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1687:2: (lb= LBRACE ( functionExpressionBodyWithoutBraces )? RBRACE )
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1687:4: lb= LBRACE ( functionExpressionBodyWithoutBraces )? RBRACE
                {
                    lb = (IToken)Match(input, LBRACE, FOLLOW_LBRACE_in_functionExpressionBody5737);
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1687:14: ( functionExpressionBodyWithoutBraces )?
                    int alt75 = 2;
                    int LA75_0 = input.LA(1);

                    if (((LA75_0 >= NULL && LA75_0 <= BREAK) || LA75_0 == CONTINUE || (LA75_0 >= DELETE && LA75_0 <= DO) ||
                         (LA75_0 >= FOR && LA75_0 <= IF) || (LA75_0 >= NEW && LA75_0 <= WITH) || LA75_0 == LBRACE ||
                         LA75_0 == LPAREN || LA75_0 == LBRACK || LA75_0 == SEMIC || (LA75_0 >= ADD && LA75_0 <= SUB) ||
                         (LA75_0 >= INC && LA75_0 <= DEC) || (LA75_0 >= NOT && LA75_0 <= INV) ||
                         (LA75_0 >= Identifier && LA75_0 <= StringLiteral) || LA75_0 == RegularExpressionLiteral ||
                         (LA75_0 >= DecimalLiteral && LA75_0 <= HexIntegerLiteral)))
                    {
                        alt75 = 1;
                    }
                    switch (alt75)
                    {
                        case 1:
                            // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1687:14: functionExpressionBodyWithoutBraces
                            {
                                PushFollow(FOLLOW_functionExpressionBodyWithoutBraces_in_functionExpressionBody5739);
                                functionExpressionBodyWithoutBraces();
                                state.followingStackPointer--;


                            }
                            break;

                    }

                    Match(input, RBRACE, FOLLOW_RBRACE_in_functionExpressionBody5742);

                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "functionExpressionBody"

        public class functionExpressionBodyWithoutBraces_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "functionExpressionBodyWithoutBraces"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1691:1: functionExpressionBodyWithoutBraces : sourceElement ( sourceElement )* -> {$functionExpression::funcName!=null}? cover_func(src=$program::namecode=$textname=$functionExpression::funcNameline=$functionExpression::funcLine) -> cover_func(src=$program::namecode=$textname=$functionDeclaration::funcNameline=$functionDeclaration::funcLine);
        public ES3Parser.functionExpressionBodyWithoutBraces_return functionExpressionBodyWithoutBraces()
        // throws RecognitionException [1]
        {
            ES3Parser.functionExpressionBodyWithoutBraces_return retval =
                new ES3Parser.functionExpressionBodyWithoutBraces_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1702:2: ( sourceElement ( sourceElement )* -> {$functionExpression::funcName!=null}? cover_func(src=$program::namecode=$textname=$functionExpression::funcNameline=$functionExpression::funcLine) -> cover_func(src=$program::namecode=$textname=$functionDeclaration::funcNameline=$functionDeclaration::funcLine))
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1702:4: sourceElement ( sourceElement )*
                {
                    PushFollow(FOLLOW_sourceElement_in_functionExpressionBodyWithoutBraces5759);
                    sourceElement();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1702:18: ( sourceElement )*
                    do
                    {
                        int alt76 = 2;
                        int LA76_0 = input.LA(1);

                        if (((LA76_0 >= NULL && LA76_0 <= BREAK) || LA76_0 == CONTINUE ||
                             (LA76_0 >= DELETE && LA76_0 <= DO) || (LA76_0 >= FOR && LA76_0 <= IF) ||
                             (LA76_0 >= NEW && LA76_0 <= WITH) || LA76_0 == LBRACE || LA76_0 == LPAREN ||
                             LA76_0 == LBRACK || LA76_0 == SEMIC || (LA76_0 >= ADD && LA76_0 <= SUB) ||
                             (LA76_0 >= INC && LA76_0 <= DEC) || (LA76_0 >= NOT && LA76_0 <= INV) ||
                             (LA76_0 >= Identifier && LA76_0 <= StringLiteral) || LA76_0 == RegularExpressionLiteral ||
                             (LA76_0 >= DecimalLiteral && LA76_0 <= HexIntegerLiteral)))
                        {
                            alt76 = 1;
                        }


                        switch (alt76)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1702:18: sourceElement
                                {
                                    PushFollow(FOLLOW_sourceElement_in_functionExpressionBodyWithoutBraces5761);
                                    sourceElement();
                                    state.followingStackPointer--;


                                }
                                break;

                            default:
                                goto loop76;
                        }
                    } while (true);

                loop76:
                    ; // Stops C# compiler whining that label 'loop76' has no statements






                    // TEMPLATE REWRITE
                    // 1706:2: -> {$functionExpression::funcName!=null}? cover_func(src=$program::namecode=$textname=$functionExpression::funcNameline=$functionExpression::funcLine)
                    if (((functionExpression_scope)functionExpression_stack.Peek()).funcName != null)
                    {
                        retval.ST = TemplateLib.GetInstanceOf("cover_func",
                                                              new STAttrMap().Add("src",
                                                                                  ((program_scope)program_stack.Peek())
                                                                                      .name)
                                                                             .Add("code",
                                                                                  input.ToString((IToken)retval.Start,
                                                                                                 input.LT(-1)))
                                                                             .Add("name",
                                                                                  ((functionExpression_scope)
                                                                                   functionExpression_stack.Peek())
                                                                                      .funcName)
                                                                             .Add("line",
                                                                                  ((functionExpression_scope)
                                                                                   functionExpression_stack.Peek())
                                                                                      .funcLine));
                    }
                    else
                    // 1707:2: -> cover_func(src=$program::namecode=$textname=$functionDeclaration::funcNameline=$functionDeclaration::funcLine)
                    {
                        retval.ST = TemplateLib.GetInstanceOf("cover_func",
                                                              new STAttrMap().Add("src",
                                                                                  ((program_scope)program_stack.Peek())
                                                                                      .name)
                                                                             .Add("code",
                                                                                  input.ToString((IToken)retval.Start,
                                                                                                 input.LT(-1)))
                                                                             .Add("name",
                                                                                  ((functionDeclaration_scope)
                                                                                   functionDeclaration_stack.Peek())
                                                                                      .funcName)
                                                                             .Add("line",
                                                                                  ((functionDeclaration_scope)
                                                                                   functionDeclaration_stack.Peek())
                                                                                      .funcLine));
                    }

                    ((TokenRewriteStream)input).Replace(
                        ((IToken)retval.Start).TokenIndex,
                        input.LT(-1).TokenIndex,
                        retval.ST);
                }

                retval.Stop = input.LT(-1);


                //favor the function expression's declared name, otherwise assign an anonymous function name
                ((program_scope)program_stack.Peek()).functions.Add("\"" +
                                                                     ((functionExpression_scope)
                                                                      functionExpression_stack.Peek()).funcName + ":" +
                                                                     ((functionExpression_scope)
                                                                      functionExpression_stack.Peek()).funcLine + "\"");

                if (Verbose)
                {
                    Console.WriteLine("\n[INFO] Instrumenting function expression '" +
                                       ((functionExpression_scope)functionExpression_stack.Peek()).funcName +
                                       "' on line " +
                                       ((functionExpression_scope)functionExpression_stack.Peek()).funcLine);

                }


            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
            }
            return retval;
        }

        // $ANTLR end "functionExpressionBodyWithoutBraces"

        public class functionDeclarationBodyWithoutBraces_return : ParserRuleReturnScope
        {
            private StringTemplate st;

            public StringTemplate ST
            {
                get { return st; }
                set { st = value; }
            }

            public override object Template
            {
                get { return st; }
            }

            public override string ToString()
            {
                return (st == null) ? null : st.ToString();
            }
        };

        // $ANTLR start "functionDeclarationBodyWithoutBraces"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1710:1: functionDeclarationBodyWithoutBraces : sourceElement ( sourceElement )* -> cover_func(src=$program::namecode=$textname=$functionDeclaration::funcNameline=$functionDeclaration::funcLine);
        public functionDeclarationBodyWithoutBraces_return functionDeclarationBodyWithoutBraces()
        // throws RecognitionException [1]
        {
            var retval = new functionDeclarationBodyWithoutBraces_return();
            retval.Start = input.LT(1);

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1711:2: ( sourceElement ( sourceElement )* -> cover_func(src=$program::namecode=$textname=$functionDeclaration::funcNameline=$functionDeclaration::funcLine))
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1711:4: sourceElement ( sourceElement )*
                {
                    PushFollow(FOLLOW_sourceElement_in_functionDeclarationBodyWithoutBraces5828);
                    sourceElement();
                    state.followingStackPointer--;

                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1711:18: ( sourceElement )*
                    do
                    {
                        var alt77 = 2;
                        var LA77_0 = input.LA(1);

                        if (((LA77_0 >= NULL && LA77_0 <= BREAK) || LA77_0 == CONTINUE ||
                             (LA77_0 >= DELETE && LA77_0 <= DO) || (LA77_0 >= FOR && LA77_0 <= IF) ||
                             (LA77_0 >= NEW && LA77_0 <= WITH) || LA77_0 == LBRACE || LA77_0 == LPAREN ||
                             LA77_0 == LBRACK || LA77_0 == SEMIC || (LA77_0 >= ADD && LA77_0 <= SUB) ||
                             (LA77_0 >= INC && LA77_0 <= DEC) || (LA77_0 >= NOT && LA77_0 <= INV) ||
                             (LA77_0 >= Identifier && LA77_0 <= StringLiteral) || LA77_0 == RegularExpressionLiteral ||
                             (LA77_0 >= DecimalLiteral && LA77_0 <= HexIntegerLiteral)))
                        {
                            alt77 = 1;
                        }

                        switch (alt77)
                        {
                            case 1:
                                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1711:18: sourceElement
                                {
                                    PushFollow(FOLLOW_sourceElement_in_functionDeclarationBodyWithoutBraces5830);
                                    sourceElement();
                                    state.followingStackPointer--;
                                }
                                break;

                            default:
                                goto loop77;
                        }
                    } while (true);

                loop77:
                    ; // Stops C# compiler whining that label 'loop77' has no statements

                    // TEMPLATE REWRITE
                    // 1712:2: -> cover_func(src=$program::namecode=$textname=$functionDeclaration::funcNameline=$functionDeclaration::funcLine)
                    {
                        retval.ST = TemplateLib.GetInstanceOf("cover_func",
                                                              new STAttrMap().Add("src", ((program_scope)program_stack.Peek()).name)
                                                                             .Add("code", input.ToString((IToken)retval.Start, input.LT(-1)))
                                                                             .Add("name", ((functionDeclaration_scope)functionDeclaration_stack.Peek()).funcName)
                                                                             .Add("line", ((functionDeclaration_scope)functionDeclaration_stack.Peek()).funcLine));
                    }

                    ((TokenRewriteStream)input).Replace(((IToken)retval.Start).TokenIndex, input.LT(-1).TokenIndex, retval.ST);
                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "functionDeclarationBodyWithoutBraces"

        protected class program_scope
        {
            protected internal List<int> executableLines;
            protected internal List<string> functions;
            protected internal int stopLine;
            protected internal string name;
            protected internal int anonymousFunctionCount;
        }

        protected Stack program_stack = new Stack();

        public class program_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "program"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1719:1: program : ( ( sourceElement )* ) -> cover_file(src=$program::namecode=$textlines=toObjectLiteral($program::executableLines, true)funcs=toObjectLiteral($program::functions, false)lineCount=$program::executableLines.size()funcCount=$program::functions.size());
        public program_return program() // throws RecognitionException [1]
        {
            program_stack.Push(new program_scope());
            var retval = new program_return { Start = input.LT(1) };

            ((program_scope)program_stack.Peek()).executableLines = new List<int>();
            ((program_scope)program_stack.Peek()).functions = new List<string>();
            ((program_scope)program_stack.Peek()).stopLine = 0;
            ((program_scope)program_stack.Peek()).name = SourceName;
            ((program_scope)program_stack.Peek()).anonymousFunctionCount = 0;

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1734:2: ( ( ( sourceElement )* ) -> cover_file(src=$program::namecode=$textlines=toObjectLiteral($program::executableLines, true)funcs=toObjectLiteral($program::functions, false)lineCount=$program::executableLines.size()funcCount=$program::functions.size()))
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1734:4: ( ( sourceElement )* )
                {
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1734:4: ( ( sourceElement )* )
                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1734:5: ( sourceElement )*
                    {
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1734:5: ( sourceElement )*
                        do
                        {
                            int alt78 = 2;
                            int LA78_0 = input.LA(1);

                            if (((LA78_0 >= NULL && LA78_0 <= BREAK) || LA78_0 == CONTINUE ||
                                 (LA78_0 >= DELETE && LA78_0 <= DO) || (LA78_0 >= FOR && LA78_0 <= IF) ||
                                 (LA78_0 >= NEW && LA78_0 <= WITH) || LA78_0 == LBRACE || LA78_0 == LPAREN ||
                                 LA78_0 == LBRACK || LA78_0 == SEMIC || (LA78_0 >= ADD && LA78_0 <= SUB) ||
                                 (LA78_0 >= INC && LA78_0 <= DEC) || (LA78_0 >= NOT && LA78_0 <= INV) ||
                                 (LA78_0 >= Identifier && LA78_0 <= StringLiteral) || LA78_0 == RegularExpressionLiteral ||
                                 (LA78_0 >= DecimalLiteral && LA78_0 <= HexIntegerLiteral)))
                            {
                                alt78 = 1;
                            }


                            switch (alt78)
                            {
                                case 1:
                                    // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1734:5: sourceElement
                                    {
                                        PushFollow(FOLLOW_sourceElement_in_program5882);
                                        sourceElement();
                                        state.followingStackPointer--;
                                    }
                                    break;

                                default:
                                    goto loop78;
                            }
                        } while (true);

                    loop78:
                        ; // Stops C# compiler whining that label 'loop78' has no statements

                    }

                    ((program_scope)program_stack.Peek()).executableLines.Sort();

                    // TEMPLATE REWRITE
                    // 1735:2: -> cover_file(src=$program::namecode=$textlines=toObjectLiteral($program::executableLines, true)funcs=toObjectLiteral($program::functions, false)lineCount=$program::executableLines.size()funcCount=$program::functions.size())
                    {
                        retval.ST = TemplateLib.GetInstanceOf("cover_file",
                                                              new STAttrMap().Add("src", ((program_scope)program_stack.Peek()).name)
                                                                             .Add("code", input.ToString((IToken)retval.Start, input.LT(-1)))
                                                                             .Add("lines", ToObjectLiteral(((program_scope)program_stack.Peek()).executableLines, true))
                                                                             .Add("funcs", ToObjectLiteral(((program_scope)program_stack.Peek()).functions, false))
                                                                             .Add("lineCount", ((program_scope)program_stack.Peek()).executableLines.Count)
                                                                             .Add("funcCount", ((program_scope)program_stack.Peek()).functions.Count));
                    }

                    ((TokenRewriteStream)input).Replace(
                        ((IToken)retval.Start).TokenIndex,
                        input.LT(-1).TokenIndex,
                        retval.ST);
                }

                retval.Stop = input.LT(-1);

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
                program_stack.Pop();
            }
            return retval;
        }

        // $ANTLR end "program"

        public class sourceElement_return : ParserRuleReturnScope
        {
            public StringTemplate ST { get; set; }

            public override object Template
            {
                get { return ST; }
            }

            public override string ToString()
            {
                return (ST == null) ? null : ST.ToString();
            }
        };

        // $ANTLR start "sourceElement"
        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1743:1: sourceElement options {k=1; } : ({...}? functionDeclaration | statement );
        public sourceElement_return sourceElement() // throws RecognitionException [1]
        {
            var retval = new sourceElement_return { Start = input.LT(1) };

            try
            {
                // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1748:2: ({...}? functionDeclaration | statement )
                var alt79 = 2;
                alt79 = dfa79.Predict(input);
                switch (alt79)
                {
                    case 1:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1748:4: {...}? functionDeclaration
                        {
                            if (input.LA(1) != FUNCTION)
                            {
                                throw new FailedPredicateException(input, "sourceElement", " input.LA(1) == FUNCTION ");
                            }
                            PushFollow(FOLLOW_functionDeclaration_in_sourceElement5953);
                            functionDeclaration();
                            state.followingStackPointer--;
                        }
                        break;
                    case 2:
                        // C:\\Personal\\yuitest\\java\\src\\com\\yahoo\\platform\\yuitest\\coverage\\grammar\\ES3YUITest.g:1749:4: statement
                        {
                            PushFollow(FOLLOW_statement_in_sourceElement5958);
                            statement();
                            state.followingStackPointer--;
                        }
                        break;
                }
                retval.Stop = input.LT(-1);
            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }

            return retval;
        }

        // $ANTLR end "sourceElement"

        // Delegated rules
        protected DFA45 dfa45;
        protected DFA46 dfa46;
        protected DFA79 dfa79;

        private void InitializeCyclicDFAs()
        {
            dfa45 = new DFA45(this);
            dfa46 = new DFA46(this);
            dfa79 = new DFA79(this);
            dfa45.specialStateTransitionHandler = DFA45_SpecialStateTransition;

            dfa79.specialStateTransitionHandler = DFA79_SpecialStateTransition;
        }

        private const string DFA45_eotS =
            "\x24\uffff";

        private const string DFA45_eofS =
            "\x24\uffff";

        private const string DFA45_minS =
            "\x01\x04\x01\x00\x22\uffff";

        private const string DFA45_maxS =
            "\x01\u00a1\x01\x00\x22\uffff";

        private const string DFA45_acceptS =
            "\x02\uffff\x01\x02\x20\uffff\x01\x01";

        private const string DFA45_specialS =
            "\x01\uffff\x01\x00\x22\uffff}>";

        private static readonly string[] DFA45_transitionS =
            {
                "\x04\x02\x02\uffff\x01\x02\x01\uffff\x02\x02\x02\uffff\x03" +
                "\x02\x02\uffff\x0b\x02\x1f\uffff\x01\x01\x01\uffff\x01\x02\x01" +
                "\uffff\x01\x02\x02\uffff\x01\x02\x09\uffff\x02\x02\x02\uffff" +
                "\x02\x02\x06\uffff\x02\x02\x36\uffff\x02\x02\x05\uffff\x01\x02" +
                "\x03\uffff\x03\x02",
                "\x01\uffff",
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
                ""
            };

        private static readonly short[] DFA45_eot = DFA.UnpackEncodedString(DFA45_eotS);
        private static readonly short[] DFA45_eof = DFA.UnpackEncodedString(DFA45_eofS);
        private static readonly char[] DFA45_min = DFA.UnpackEncodedStringToUnsignedChars(DFA45_minS);
        private static readonly char[] DFA45_max = DFA.UnpackEncodedStringToUnsignedChars(DFA45_maxS);
        private static readonly short[] DFA45_accept = DFA.UnpackEncodedString(DFA45_acceptS);
        private static readonly short[] DFA45_special = DFA.UnpackEncodedString(DFA45_specialS);
        private static readonly short[][] DFA45_transition = UnpackEncodedStringArray(DFA45_transitionS);

        protected class DFA45 : DFA
        {
            public DFA45(BaseRecognizer recognizer)
            {
                this.recognizer = recognizer;
                decisionNumber = 45;
                eot = DFA45_eot;
                eof = DFA45_eof;
                min = DFA45_min;
                max = DFA45_max;
                accept = DFA45_accept;
                special = DFA45_special;
                transition = DFA45_transition;

            }

            public override string Description
            {
                get { return "1266:4: ({...}? block | statementTail )"; }
            }

        }


        protected internal int DFA45_SpecialStateTransition(DFA dfa, int s, IIntStream _input)
        //throws NoViableAltException
        {
            var input = (ITokenStream)_input;
            var _s = s;
            switch (s)
            {
                case 0:
                    var LA45_1 = input.LA(1);
                    var index45_1 = input.Index;
                    input.Rewind();
                    s = -1;
                    if (((((statement_scope)statement_stack.Peek()).isBlock = input.LA(1) == LBRACE)))
                    {
                        s = 35;
                    }

                    else if ((true))
                    {
                        s = 2;
                    }


                    input.Seek(index45_1);
                    if (s >= 0) return s;
                    break;
            }
            var nvae45 = new NoViableAltException(dfa.Description, 45, _s, input);
            dfa.Error(nvae45);
            throw nvae45;
        }

        private const string DFA46_eotS =
            "\x0f\uffff";

        private const string DFA46_eofS =
            "\x04\uffff\x01\x03\x0a\uffff";

        private const string DFA46_minS =
            "\x01\x04\x03\uffff\x01\x13\x0a\uffff";

        private const string DFA46_maxS =
            "\x01\u00a1\x03\uffff\x01\u0092\x0a\uffff";

        private const string DFA46_acceptS =
            "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\uffff\x01\x04\x01\x05\x01" +
            "\x06\x01\x07\x01\x08\x01\x09\x01\x0b\x01\x0c\x01\x0d\x01\x0a";

        private const string DFA46_specialS =
            "\x0f\uffff}>";

        private static readonly string[] DFA46_transitionS =
            {
                "\x03\x03\x01\x08\x02\uffff\x01\x07\x01\uffff\x01\x03\x01\x06" +
                "\x02\uffff\x01\x06\x01\x03\x01\x05\x02\uffff\x01\x03\x01\x09" +
                "\x01\x0b\x01\x03\x01\x0c\x01\x0d\x01\x03\x01\x01\x01\x03\x01" +
                "\x06\x01\x0a\x1f\uffff\x01\x03\x01\uffff\x01\x03\x01\uffff\x01" +
                "\x03\x02\uffff\x01\x02\x09\uffff\x02\x03\x02\uffff\x02\x03\x06" +
                "\uffff\x02\x03\x36\uffff\x01\x04\x01\x03\x05\uffff\x01\x03\x03" +
                "\uffff\x03\x03",
                "",
                "",
                "",
                "\x02\x03\x2b\uffff\x02\x03\x01\uffff\x01\x03\x01\uffff\x17" +
                "\x03\x02\uffff\x03\x03\x01\x0e\x0d\x03\x22\uffff\x02\x03",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                ""
            };

        private static readonly short[] DFA46_eot = DFA.UnpackEncodedString(DFA46_eotS);
        private static readonly short[] DFA46_eof = DFA.UnpackEncodedString(DFA46_eofS);
        private static readonly char[] DFA46_min = DFA.UnpackEncodedStringToUnsignedChars(DFA46_minS);
        private static readonly char[] DFA46_max = DFA.UnpackEncodedStringToUnsignedChars(DFA46_maxS);
        private static readonly short[] DFA46_accept = DFA.UnpackEncodedString(DFA46_acceptS);
        private static readonly short[] DFA46_special = DFA.UnpackEncodedString(DFA46_specialS);
        private static readonly short[][] DFA46_transition = UnpackEncodedStringArray(DFA46_transitionS);

        protected class DFA46 : DFA
        {
            public DFA46(BaseRecognizer recognizer)
            {
                this.recognizer = recognizer;
                decisionNumber = 46;
                eot = DFA46_eot;
                eof = DFA46_eof;
                min = DFA46_min;
                max = DFA46_max;
                accept = DFA46_accept;
                special = DFA46_special;
                transition = DFA46_transition;
            }

            public override string Description
            {
                get
                {
                    return
                        "1271:1: statementTail : ( variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );";
                }
            }
        }

        private const string DFA79_eotS =
            "\x24\uffff";

        private const string DFA79_eofS =
            "\x24\uffff";

        private const string DFA79_minS =
            "\x01\x04\x01\x00\x22\uffff";

        private const string DFA79_maxS =
            "\x01\u00a1\x01\x00\x22\uffff";

        private const string DFA79_acceptS =
            "\x02\uffff\x01\x02\x20\uffff\x01\x01";

        private const string DFA79_specialS =
            "\x01\uffff\x01\x00\x22\uffff}>";

        private static readonly string[] DFA79_transitionS =
            {
                "\x04\x02\x02\uffff\x01\x02\x01\uffff\x02\x02\x02\uffff\x01" +
                "\x02\x01\x01\x01\x02\x02\uffff\x0b\x02\x1f\uffff\x01\x02\x01" +
                "\uffff\x01\x02\x01\uffff\x01\x02\x02\uffff\x01\x02\x09\uffff" +
                "\x02\x02\x02\uffff\x02\x02\x06\uffff\x02\x02\x36\uffff\x02\x02" +
                "\x05\uffff\x01\x02\x03\uffff\x03\x02",
                "\x01\uffff",
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
                ""
            };

        private static short[][] UnpackEncodedStringArray(string[] encodedStrings)
        {
            short[][] array = new short[encodedStrings.Length][];
            for (int i = 0; i < encodedStrings.Length; i++)
            {
                array[i] = DFA.UnpackEncodedString(encodedStrings[i]);
            }
            return array;
        }

        private static readonly short[] DFA79_eot = DFA.UnpackEncodedString(DFA79_eotS);
        private static readonly short[] DFA79_eof = DFA.UnpackEncodedString(DFA79_eofS);
        private static readonly char[] DFA79_min = DFA.UnpackEncodedStringToUnsignedChars(DFA79_minS);
        private static readonly char[] DFA79_max = DFA.UnpackEncodedStringToUnsignedChars(DFA79_maxS);
        private static readonly short[] DFA79_accept = DFA.UnpackEncodedString(DFA79_acceptS);
        private static readonly short[] DFA79_special = DFA.UnpackEncodedString(DFA79_specialS);
        private static readonly short[][] DFA79_transition = UnpackEncodedStringArray(DFA79_transitionS);

        protected class DFA79 : DFA
        {
            public DFA79(BaseRecognizer recognizer)
            {
                this.recognizer = recognizer;
                decisionNumber = 79;
                eot = DFA79_eot;
                eof = DFA79_eof;
                min = DFA79_min;
                max = DFA79_max;
                accept = DFA79_accept;
                special = DFA79_special;
                transition = DFA79_transition;

            }

            public override string Description
            {
                get { return "1743:1: sourceElement options {k=1; } : ({...}? functionDeclaration | statement );"; }
            }
        }

        protected internal int DFA79_SpecialStateTransition(DFA dfa, int s, IIntStream _input)
        //throws NoViableAltException
        {
            var input = (ITokenStream)_input;
            var _s = s;
            switch (s)
            {
                case 0:
                    var LA79_1 = input.LA(1);
                    var index79_1 = input.Index;
                    input.Rewind();
                    s = -1;
                    if (((input.LA(1) == FUNCTION)))
                    {
                        s = 35;
                    }
                    else if ((true))
                    {
                        s = 2;
                    }

                    input.Seek(index79_1);
                    if (s >= 0) return s;
                    break;
            }

            var nvae79 = new NoViableAltException(dfa.Description, 79, _s, input);
            dfa.Error(nvae79);
            throw nvae79;
        }

        public static readonly BitSet FOLLOW_reservedWord_in_token1762 = new BitSet(new[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_Identifier_in_token1767 = new BitSet(new[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_punctuator_in_token1772 = new BitSet(new[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_numericLiteral_in_token1777 = new BitSet(new ulong[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_StringLiteral_in_token1782 = new BitSet(new ulong[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_keyword_in_reservedWord1795 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_futureReservedWord_in_reservedWord1800 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_NULL_in_reservedWord1805 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_booleanLiteral_in_reservedWord1810 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_set_in_keyword0 = new BitSet(new ulong[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_set_in_futureReservedWord0 = new BitSet(new ulong[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_set_in_punctuator0 = new BitSet(new ulong[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_NULL_in_literal2491 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_booleanLiteral_in_literal2496 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_numericLiteral_in_literal2501 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_StringLiteral_in_literal2506 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_RegularExpressionLiteral_in_literal2511 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_set_in_booleanLiteral0 = new BitSet(new[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_set_in_numericLiteral0 = new BitSet(new[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_THIS_in_primaryExpression3124 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_Identifier_in_primaryExpression3129 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_literal_in_primaryExpression3134 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_arrayLiteral_in_primaryExpression3139 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_objectLiteral_in_primaryExpression3144 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LPAREN_in_primaryExpression3151 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_primaryExpression3153 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000004UL });

        public static readonly BitSet FOLLOW_RPAREN_in_primaryExpression3155 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LBRACK_in_arrayLiteral3171 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033009AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_arrayItem_in_arrayLiteral3175 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000090UL });

        public static readonly BitSet FOLLOW_COMMA_in_arrayLiteral3179 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033009AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_arrayItem_in_arrayLiteral3181 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000090UL });

        public static readonly BitSet FOLLOW_RBRACK_in_arrayLiteral3190 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_assignmentExpression_in_arrayItem3207 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LBRACE_in_objectLiteral3228 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000001UL, 0x0000000380300000UL });

        public static readonly BitSet FOLLOW_nameValuePair_in_objectLiteral3232 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000081UL });

        public static readonly BitSet FOLLOW_COMMA_in_objectLiteral3236 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000000UL, 0x0000000380300000UL });

        public static readonly BitSet FOLLOW_nameValuePair_in_objectLiteral3238 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000081UL });

        public static readonly BitSet FOLLOW_RBRACE_in_objectLiteral3246 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_propertyName_in_nameValuePair3262 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000200000000UL });

        public static readonly BitSet FOLLOW_COLON_in_nameValuePair3264 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpression_in_nameValuePair3266 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_Identifier_in_propertyName3279 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_StringLiteral_in_propertyName3284 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_numericLiteral_in_propertyName3289 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_primaryExpression_in_memberExpression3307 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_functionExpression_in_memberExpression3312 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_newExpression_in_memberExpression3317 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_NEW_in_newExpression3328 =
            new BitSet(new ulong[] { 0x8000000001000070UL, 0x000000000000000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_primaryExpression_in_newExpression3330 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_NEW_in_newExpression3342 = new BitSet(new ulong[] { 0x0000000000020000UL });

        public static readonly BitSet FOLLOW_functionExpression_in_newExpression3344 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LPAREN_in_arguments3360 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000EUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpression_in_arguments3364 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000084UL });

        public static readonly BitSet FOLLOW_COMMA_in_arguments3368 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpression_in_arguments3370 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000084UL });

        public static readonly BitSet FOLLOW_RPAREN_in_arguments3378 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_memberExpression_in_leftHandSideExpression3397 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x000000000000002AUL });

        public static readonly BitSet FOLLOW_arguments_in_leftHandSideExpression3410 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x000000000000002AUL });

        public static readonly BitSet FOLLOW_LBRACK_in_leftHandSideExpression3419 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_leftHandSideExpression3421 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000010UL });

        public static readonly BitSet FOLLOW_RBRACK_in_leftHandSideExpression3423 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x000000000000002AUL });

        public static readonly BitSet FOLLOW_DOT_in_leftHandSideExpression3430 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000000UL, 0x0000000000100000UL });

        public static readonly BitSet FOLLOW_Identifier_in_leftHandSideExpression3432 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x000000000000002AUL });

        public static readonly BitSet FOLLOW_leftHandSideExpression_in_postfixExpression3455 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000000300000UL });

        public static readonly BitSet FOLLOW_postfixOperator_in_postfixExpression3461 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_INC_in_postfixOperator3478 = new BitSet(new[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_DEC_in_postfixOperator3487 = new BitSet(new[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_postfixExpression_in_unaryExpression3504 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_unaryOperator_in_unaryExpression3509 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_unaryExpression_in_unaryExpression3511 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_DELETE_in_unaryOperator3523 = new BitSet(new ulong[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_VOID_in_unaryOperator3528 = new BitSet(new ulong[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_TYPEOF_in_unaryOperator3533 = new BitSet(new ulong[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_INC_in_unaryOperator3538 = new BitSet(new[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_DEC_in_unaryOperator3543 = new BitSet(new[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_ADD_in_unaryOperator3550 = new BitSet(new[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_SUB_in_unaryOperator3559 = new BitSet(new[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_INV_in_unaryOperator3566 = new BitSet(new[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_NOT_in_unaryOperator3571 = new BitSet(new[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_unaryExpression_in_multiplicativeExpression3586 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x00002000000C0000UL });

        public static readonly BitSet FOLLOW_set_in_multiplicativeExpression3590 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_unaryExpression_in_multiplicativeExpression3604 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x00002000000C0000UL });

        public static readonly BitSet FOLLOW_multiplicativeExpression_in_additiveExpression3622 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000000030000UL });

        public static readonly BitSet FOLLOW_set_in_additiveExpression3626 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_multiplicativeExpression_in_additiveExpression3636 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000000030000UL });

        public static readonly BitSet FOLLOW_additiveExpression_in_shiftExpression3655 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000001C00000UL });

        public static readonly BitSet FOLLOW_set_in_shiftExpression3659 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_additiveExpression_in_shiftExpression3673 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000001C00000UL });

        public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpression3692 =
            new BitSet(new ulong[] { 0x0000000000180002UL, 0x0000000000000F00UL });

        public static readonly BitSet FOLLOW_set_in_relationalExpression3696 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpression3722 =
            new BitSet(new ulong[] { 0x0000000000180002UL, 0x0000000000000F00UL });

        public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpressionNoIn3736 =
            new BitSet(new ulong[] { 0x0000000000100002UL, 0x0000000000000F00UL });

        public static readonly BitSet FOLLOW_set_in_relationalExpressionNoIn3740 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpressionNoIn3762 =
            new BitSet(new ulong[] { 0x0000000000100002UL, 0x0000000000000F00UL });

        public static readonly BitSet FOLLOW_relationalExpression_in_equalityExpression3781 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x000000000000F000UL });

        public static readonly BitSet FOLLOW_set_in_equalityExpression3785 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_relationalExpression_in_equalityExpression3803 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x000000000000F000UL });

        public static readonly BitSet FOLLOW_relationalExpressionNoIn_in_equalityExpressionNoIn3817 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x000000000000F000UL });

        public static readonly BitSet FOLLOW_set_in_equalityExpressionNoIn3821 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_relationalExpressionNoIn_in_equalityExpressionNoIn3839 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x000000000000F000UL });

        public static readonly BitSet FOLLOW_equalityExpression_in_bitwiseANDExpression3859 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000002000000UL });

        public static readonly BitSet FOLLOW_AND_in_bitwiseANDExpression3863 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_equalityExpression_in_bitwiseANDExpression3865 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000002000000UL });

        public static readonly BitSet FOLLOW_equalityExpressionNoIn_in_bitwiseANDExpressionNoIn3879 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000002000000UL });

        public static readonly BitSet FOLLOW_AND_in_bitwiseANDExpressionNoIn3883 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_equalityExpressionNoIn_in_bitwiseANDExpressionNoIn3885 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000002000000UL });

        public static readonly BitSet FOLLOW_bitwiseANDExpression_in_bitwiseXORExpression3901 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000008000000UL });

        public static readonly BitSet FOLLOW_XOR_in_bitwiseXORExpression3905 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_bitwiseANDExpression_in_bitwiseXORExpression3907 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000008000000UL });

        public static readonly BitSet FOLLOW_bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn3923 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000008000000UL });

        public static readonly BitSet FOLLOW_XOR_in_bitwiseXORExpressionNoIn3927 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn3929 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000008000000UL });

        public static readonly BitSet FOLLOW_bitwiseXORExpression_in_bitwiseORExpression3944 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000004000000UL });

        public static readonly BitSet FOLLOW_OR_in_bitwiseORExpression3948 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_bitwiseXORExpression_in_bitwiseORExpression3950 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000004000000UL });

        public static readonly BitSet FOLLOW_bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn3965 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000004000000UL });

        public static readonly BitSet FOLLOW_OR_in_bitwiseORExpressionNoIn3969 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn3971 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000004000000UL });

        public static readonly BitSet FOLLOW_bitwiseORExpression_in_logicalANDExpression3990 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000040000000UL });

        public static readonly BitSet FOLLOW_LAND_in_logicalANDExpression3994 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_bitwiseORExpression_in_logicalANDExpression3996 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000040000000UL });

        public static readonly BitSet FOLLOW_bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4010 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000040000000UL });

        public static readonly BitSet FOLLOW_LAND_in_logicalANDExpressionNoIn4014 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4016 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000040000000UL });

        public static readonly BitSet FOLLOW_logicalANDExpression_in_logicalORExpression4031 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000080000000UL });

        public static readonly BitSet FOLLOW_LOR_in_logicalORExpression4035 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_logicalANDExpression_in_logicalORExpression4037 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000080000000UL });

        public static readonly BitSet FOLLOW_logicalANDExpressionNoIn_in_logicalORExpressionNoIn4052 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000080000000UL });

        public static readonly BitSet FOLLOW_LOR_in_logicalORExpressionNoIn4056 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_logicalANDExpressionNoIn_in_logicalORExpressionNoIn4058 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000080000000UL });

        public static readonly BitSet FOLLOW_logicalORExpression_in_conditionalExpression4077 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000100000000UL });

        public static readonly BitSet FOLLOW_QUE_in_conditionalExpression4081 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpression_in_conditionalExpression4083 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000200000000UL });

        public static readonly BitSet FOLLOW_COLON_in_conditionalExpression4085 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpression_in_conditionalExpression4087 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_logicalORExpressionNoIn_in_conditionalExpressionNoIn4101 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000100000000UL });

        public static readonly BitSet FOLLOW_QUE_in_conditionalExpressionNoIn4105 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_conditionalExpressionNoIn4107 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000200000000UL });

        public static readonly BitSet FOLLOW_COLON_in_conditionalExpressionNoIn4109 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_conditionalExpressionNoIn4111 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_conditionalExpression_in_assignmentExpression4139 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x00005FFC00000000UL });

        public static readonly BitSet FOLLOW_assignmentOperator_in_assignmentExpression4146 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpression_in_assignmentExpression4148 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_set_in_assignmentOperator0 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_conditionalExpressionNoIn_in_assignmentExpressionNoIn4225 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x00005FFC00000000UL });

        public static readonly BitSet FOLLOW_assignmentOperator_in_assignmentExpressionNoIn4232 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_assignmentExpressionNoIn4234 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_assignmentExpression_in_expression4256 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000000000080UL });

        public static readonly BitSet FOLLOW_COMMA_in_expression4260 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpression_in_expression4264 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000000000080UL });

        public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_expressionNoIn4284 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000000000080UL });

        public static readonly BitSet FOLLOW_COMMA_in_expressionNoIn4288 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_expressionNoIn4292 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000000000080UL });

        public static readonly BitSet FOLLOW_SEMIC_in_semic4326 = new BitSet(new ulong[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_EOF_in_semic4331 = new BitSet(new ulong[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_RBRACE_in_semic4336 = new BitSet(new ulong[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_EOL_in_semic4343 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_MultiLineComment_in_semic4347 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_block_in_statement4390 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_statementTail_in_statement4394 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_variableStatement_in_statementTail4442 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_emptyStatement_in_statementTail4447 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_expressionStatement_in_statementTail4452 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_ifStatement_in_statementTail4457 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_iterationStatement_in_statementTail4462 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_continueStatement_in_statementTail4467 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_breakStatement_in_statementTail4472 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_returnStatement_in_statementTail4477 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_withStatement_in_statementTail4482 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_labelledStatement_in_statementTail4487 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_switchStatement_in_statementTail4492 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_throwStatement_in_statementTail4497 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_tryStatement_in_statementTail4502 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LBRACE_in_block4517 =
            new BitSet(new ulong[] { 0x80000000FFE734F0UL, 0x000000003033004BUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_statement_in_block4519 =
            new BitSet(new ulong[] { 0x80000000FFE734F0UL, 0x000000003033004BUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_RBRACE_in_block4522 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_VAR_in_variableStatement4540 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000000UL, 0x0000000000100000UL });

        public static readonly BitSet FOLLOW_variableDeclaration_in_variableStatement4542 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x00000000000000C1UL, 0x0000000000060000UL });

        public static readonly BitSet FOLLOW_COMMA_in_variableStatement4546 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000000UL, 0x0000000000100000UL });

        public static readonly BitSet FOLLOW_variableDeclaration_in_variableStatement4548 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x00000000000000C1UL, 0x0000000000060000UL });

        public static readonly BitSet FOLLOW_semic_in_variableStatement4553 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_Identifier_in_variableDeclaration4566 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000400000000UL });

        public static readonly BitSet FOLLOW_ASSIGN_in_variableDeclaration4570 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpression_in_variableDeclaration4572 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_Identifier_in_variableDeclarationNoIn4587 =
            new BitSet(new ulong[] { 0x0000000000000002UL, 0x0000000400000000UL });

        public static readonly BitSet FOLLOW_ASSIGN_in_variableDeclarationNoIn4591 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_variableDeclarationNoIn4593 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_SEMIC_in_emptyStatement4612 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_expression_in_expressionStatement4630 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x00000000000000C1UL, 0x0000000000060000UL });

        public static readonly BitSet FOLLOW_semic_in_expressionStatement4632 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_IF_in_ifStatement4650 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LPAREN_in_ifStatement4652 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_ifStatement4654 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000004UL });

        public static readonly BitSet FOLLOW_RPAREN_in_ifStatement4656 =
            new BitSet(new ulong[] { 0x80000000FFE734F0UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_statement_in_ifStatement4658 =
            new BitSet(new ulong[] { 0x0000000000004002UL });

        public static readonly BitSet FOLLOW_elseStatement_in_ifStatement4664 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_ELSE_in_elseStatement4736 =
            new BitSet(new ulong[] { 0x80000000FFE734F0UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_statement_in_elseStatement4738 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_doStatement_in_iterationStatement4775 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_whileStatement_in_iterationStatement4780 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_forStatement_in_iterationStatement4785 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_DO_in_doStatement4797 =
            new BitSet(new ulong[] { 0x80000000FFE734F0UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_statement_in_doStatement4799 =
            new BitSet(new ulong[] { 0x0000000040000000UL });

        public static readonly BitSet FOLLOW_WHILE_in_doStatement4801 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LPAREN_in_doStatement4803 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_doStatement4805 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000004UL });

        public static readonly BitSet FOLLOW_RPAREN_in_doStatement4807 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x00000000000000C1UL, 0x0000000000060000UL });

        public static readonly BitSet FOLLOW_semic_in_doStatement4809 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_WHILE_in_whileStatement4895 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LPAREN_in_whileStatement4897 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_whileStatement4899 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000004UL });

        public static readonly BitSet FOLLOW_RPAREN_in_whileStatement4901 =
            new BitSet(new ulong[] { 0x80000000FFE734F0UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_statement_in_whileStatement4903 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_FOR_in_forStatement4964 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LPAREN_in_forStatement4966 =
            new BitSet(new ulong[] { 0x8000000039221070UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_forControl_in_forStatement4968 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000004UL });

        public static readonly BitSet FOLLOW_RPAREN_in_forStatement4970 =
            new BitSet(new ulong[] { 0x80000000FFE734F0UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_statement_in_forStatement4972 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_forControlVar_in_forControl5031 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_forControlExpression_in_forControl5036 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_forControlSemic_in_forControl5041 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_VAR_in_forControlVar5052 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000000UL, 0x0000000000100000UL });

        public static readonly BitSet FOLLOW_variableDeclarationNoIn_in_forControlVar5054 =
            new BitSet(new ulong[] { 0x0000000000080000UL, 0x00000000000000C0UL });

        public static readonly BitSet FOLLOW_IN_in_forControlVar5066 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_forControlVar5068 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_COMMA_in_forControlVar5091 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000000UL, 0x0000000000100000UL });

        public static readonly BitSet FOLLOW_variableDeclarationNoIn_in_forControlVar5093 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x00000000000000C0UL });

        public static readonly BitSet FOLLOW_SEMIC_in_forControlVar5098 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_forControlVar5102 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000040UL });

        public static readonly BitSet FOLLOW_SEMIC_in_forControlVar5105 =
            new BitSet(new ulong[] { 0x8000000029221072UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_forControlVar5109 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_expressionNoIn_in_forControlExpression5139 =
            new BitSet(new ulong[] { 0x0000000000080000UL, 0x0000000000000040UL });

        public static readonly BitSet FOLLOW_IN_in_forControlExpression5154 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_forControlExpression5158 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_SEMIC_in_forControlExpression5179 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_forControlExpression5183 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000040UL });

        public static readonly BitSet FOLLOW_SEMIC_in_forControlExpression5186 =
            new BitSet(new ulong[] { 0x8000000029221072UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_forControlExpression5190 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_SEMIC_in_forControlSemic5213 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_forControlSemic5217 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000040UL });

        public static readonly BitSet FOLLOW_SEMIC_in_forControlSemic5220 =
            new BitSet(new ulong[] { 0x8000000029221072UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_forControlSemic5224 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_CONTINUE_in_continueStatement5245 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x00000000000000C1UL, 0x0000000000160000UL });

        public static readonly BitSet FOLLOW_Identifier_in_continueStatement5249 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x00000000000000C1UL, 0x0000000000060000UL });

        public static readonly BitSet FOLLOW_semic_in_continueStatement5252 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_BREAK_in_breakStatement5270 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x00000000000000C1UL, 0x0000000000160000UL });

        public static readonly BitSet FOLLOW_Identifier_in_breakStatement5274 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x00000000000000C1UL, 0x0000000000060000UL });

        public static readonly BitSet FOLLOW_semic_in_breakStatement5277 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_RETURN_in_returnStatement5295 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x00000000303300CBUL, 0x0000000388360000UL });

        public static readonly BitSet FOLLOW_expression_in_returnStatement5299 =
            new BitSet(new[] { 0x0000000000000000UL, 0x00000000000000C1UL, 0x0000000000060000UL });

        public static readonly BitSet FOLLOW_semic_in_returnStatement5302 =
            new BitSet(new[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_WITH_in_withStatement5318 =
            new BitSet(new[] { 0x0000000000000000UL, 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LPAREN_in_withStatement5320 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_withStatement5322 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000004UL });

        public static readonly BitSet FOLLOW_RPAREN_in_withStatement5324 =
            new BitSet(new ulong[] { 0x80000000FFE734F0UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_statement_in_withStatement5326 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_SWITCH_in_switchStatement5395 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LPAREN_in_switchStatement5397 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_switchStatement5399 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000004UL });

        public static readonly BitSet FOLLOW_RPAREN_in_switchStatement5401 =
            new BitSet(new ulong[] { 0x8000000000000000UL });

        public static readonly BitSet FOLLOW_LBRACE_in_switchStatement5403 =
            new BitSet(new ulong[] { 0x0000000000000900UL, 0x0000000000000001UL });

        public static readonly BitSet FOLLOW_defaultClause_in_switchStatement5410 =
            new BitSet(new ulong[] { 0x0000000000000900UL, 0x0000000000000001UL });

        public static readonly BitSet FOLLOW_caseClause_in_switchStatement5416 =
            new BitSet(new ulong[] { 0x0000000000000900UL, 0x0000000000000001UL });

        public static readonly BitSet FOLLOW_RBRACE_in_switchStatement5421 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_CASE_in_caseClause5434 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_caseClause5436 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000200000000UL });

        public static readonly BitSet FOLLOW_COLON_in_caseClause5438 =
            new BitSet(new ulong[] { 0x80000000FFE734F2UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_statement_in_caseClause5440 =
            new BitSet(new ulong[] { 0x80000000FFE734F2UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_DEFAULT_in_defaultClause5453 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000200000000UL });

        public static readonly BitSet FOLLOW_COLON_in_defaultClause5455 =
            new BitSet(new ulong[] { 0x80000000FFE734F2UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_statement_in_defaultClause5457 =
            new BitSet(new ulong[] { 0x80000000FFE734F2UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_Identifier_in_labelledStatement5474 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000200000000UL });

        public static readonly BitSet FOLLOW_COLON_in_labelledStatement5476 =
            new BitSet(new ulong[] { 0x80000000FFE734F0UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_statement_in_labelledStatement5478 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_THROW_in_throwStatement5498 =
            new BitSet(new ulong[] { 0x8000000029221070UL, 0x000000003033000AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_expression_in_throwStatement5502 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x00000000000000C1UL, 0x0000000000060000UL });

        public static readonly BitSet FOLLOW_semic_in_throwStatement5504 = new BitSet(new ulong[] { 0x0000000000000002UL });
        public static readonly BitSet FOLLOW_TRY_in_tryStatement5520 = new BitSet(new ulong[] { 0x8000000000000000UL });
        public static readonly BitSet FOLLOW_block_in_tryStatement5522 = new BitSet(new ulong[] { 0x0000000000008200UL });

        public static readonly BitSet FOLLOW_catchClause_in_tryStatement5526 =
            new BitSet(new ulong[] { 0x0000000000008202UL });

        public static readonly BitSet FOLLOW_finallyClause_in_tryStatement5528 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_finallyClause_in_tryStatement5533 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_CATCH_in_catchClause5547 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LPAREN_in_catchClause5549 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000000UL, 0x0000000000100000UL });

        public static readonly BitSet FOLLOW_Identifier_in_catchClause5551 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000004UL });

        public static readonly BitSet FOLLOW_RPAREN_in_catchClause5553 = new BitSet(new ulong[] { 0x8000000000000000UL });
        public static readonly BitSet FOLLOW_block_in_catchClause5555 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_FINALLY_in_finallyClause5567 =
            new BitSet(new ulong[] { 0x8000000000000000UL });

        public static readonly BitSet FOLLOW_block_in_finallyClause5569 = new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_FUNCTION_in_functionDeclaration5605 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000000UL, 0x0000000000100000UL });

        public static readonly BitSet FOLLOW_Identifier_in_functionDeclaration5609 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_formalParameterList_in_functionDeclaration5613 =
            new BitSet(new ulong[] { 0x8000000000000000UL });

        public static readonly BitSet FOLLOW_functionDeclarationBody_in_functionDeclaration5615 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_FUNCTION_in_functionExpression5670 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000002UL, 0x0000000000100000UL });

        public static readonly BitSet FOLLOW_Identifier_in_functionExpression5672 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_formalParameterList_in_functionExpression5675 =
            new BitSet(new ulong[] { 0x8000000000000000UL });

        public static readonly BitSet FOLLOW_functionExpressionBody_in_functionExpression5677 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LPAREN_in_formalParameterList5688 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000004UL, 0x0000000000100000UL });

        public static readonly BitSet FOLLOW_Identifier_in_formalParameterList5692 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000084UL });

        public static readonly BitSet FOLLOW_COMMA_in_formalParameterList5696 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000000UL, 0x0000000000100000UL });

        public static readonly BitSet FOLLOW_Identifier_in_formalParameterList5698 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000084UL });

        public static readonly BitSet FOLLOW_RPAREN_in_formalParameterList5706 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LBRACE_in_functionDeclarationBody5719 =
            new BitSet(new ulong[] { 0x80000000FFE734F0UL, 0x000000003033004BUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_functionDeclarationBodyWithoutBraces_in_functionDeclarationBody5721 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000001UL });

        public static readonly BitSet FOLLOW_RBRACE_in_functionDeclarationBody5724 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_LBRACE_in_functionExpressionBody5737 =
            new BitSet(new ulong[] { 0x80000000FFE734F0UL, 0x000000003033004BUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_functionExpressionBodyWithoutBraces_in_functionExpressionBody5739 =
            new BitSet(new ulong[] { 0x0000000000000000UL, 0x0000000000000001UL });

        public static readonly BitSet FOLLOW_RBRACE_in_functionExpressionBody5742 =
            new BitSet(new ulong[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_sourceElement_in_functionExpressionBodyWithoutBraces5759 =
            new BitSet(new ulong[] { 0x80000000FFE734F2UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_sourceElement_in_functionExpressionBodyWithoutBraces5761 =
            new BitSet(new ulong[] { 0x80000000FFE734F2UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_sourceElement_in_functionDeclarationBodyWithoutBraces5828 =
            new BitSet(new ulong[] { 0x80000000FFE734F2UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_sourceElement_in_functionDeclarationBodyWithoutBraces5830 =
            new BitSet(new[] { 0x80000000FFE734F2UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_sourceElement_in_program5882 =
            new BitSet(new[] { 0x80000000FFE734F2UL, 0x000000003033004AUL, 0x0000000388300000UL });

        public static readonly BitSet FOLLOW_functionDeclaration_in_sourceElement5953 =
            new BitSet(new[] { 0x0000000000000002UL });

        public static readonly BitSet FOLLOW_statement_in_sourceElement5958 =
            new BitSet(new[] { 0x0000000000000002UL });

    }
}