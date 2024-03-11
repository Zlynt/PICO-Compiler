/*
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                            =  0, // (EOF)
        SYMBOL_ERROR                          =  1, // (Error)
        SYMBOL_WHITESPACE                     =  2, // Whitespace
        SYMBOL_MINUS                          =  3, // '-'
        SYMBOL_QUOTE                          =  4, // '"'
        SYMBOL_LPAREN                         =  5, // '('
        SYMBOL_RPAREN                         =  6, // ')'
        SYMBOL_COMMA                          =  7, // ','
        SYMBOL_COLON                          =  8, // ':'
        SYMBOL_COLONEQ                        =  9, // ':='
        SYMBOL_SEMI                           = 10, // ';'
        SYMBOL_PIPEPIPE                       = 11, // '||'
        SYMBOL_PLUS                           = 12, // '+'
        SYMBOL_0                              = 13, // '0'
        SYMBOL_1                              = 14, // '1'
        SYMBOL_2                              = 15, // '2'
        SYMBOL_3                              = 16, // '3'
        SYMBOL_4                              = 17, // '4'
        SYMBOL_5                              = 18, // '5'
        SYMBOL_6                              = 19, // '6'
        SYMBOL_7                              = 20, // '7'
        SYMBOL_8                              = 21, // '8'
        SYMBOL_9                              = 22, // '9'
        SYMBOL_A                              = 23, // a
        SYMBOL_B                              = 24, // b
        SYMBOL_BEGIN                          = 25, // begin
        SYMBOL_C                              = 26, // c
        SYMBOL_D                              = 27, // d
        SYMBOL_DECLARE                        = 28, // declare
        SYMBOL_DO                             = 29, // do
        SYMBOL_E                              = 30, // e
        SYMBOL_ELSE                           = 31, // else
        SYMBOL_END                            = 32, // end
        SYMBOL_F                              = 33, // f
        SYMBOL_FI                             = 34, // fi
        SYMBOL_FOR                            = 35, // for
        SYMBOL_G                              = 36, // g
        SYMBOL_H                              = 37, // h
        SYMBOL_I                              = 38, // i
        SYMBOL_IF                             = 39, // if
        SYMBOL_J                              = 40, // j
        SYMBOL_K                              = 41, // k
        SYMBOL_L                              = 42, // l
        SYMBOL_M                              = 43, // m
        SYMBOL_N                              = 44, // n
        SYMBOL_NATURAL                        = 45, // natural
        SYMBOL_O                              = 46, // o
        SYMBOL_OD                             = 47, // od
        SYMBOL_P                              = 48, // p
        SYMBOL_Q                              = 49, // q
        SYMBOL_R                              = 50, // r
        SYMBOL_S                              = 51, // s
        SYMBOL_STRING                         = 52, // string
        SYMBOL_T                              = 53, // t
        SYMBOL_THEN                           = 54, // then
        SYMBOL_U                              = 55, // u
        SYMBOL_V                              = 56, // v
        SYMBOL_W                              = 57, // w
        SYMBOL_WHILE                          = 58, // while
        SYMBOL_X                              = 59, // x
        SYMBOL_Y                              = 60, // y
        SYMBOL_Z                              = 61, // z
        SYMBOL_ANYMINUSCHARMINUSBUTMINUSQUOTE = 62, // <any-char-but-quote>
        SYMBOL_ASSIGN                         = 63, // <assign>
        SYMBOL_CONC                           = 64, // <conc>
        SYMBOL_DECLS                          = 65, // <decls>
        SYMBOL_DIGIT                          = 66, // <digit>
        SYMBOL_DIGITS                         = 67, // <digits>
        SYMBOL_EMPTY                          = 68, // <empty>
        SYMBOL_ESTADOMINUSINT                 = 69, // <estado-int>
        SYMBOL_EXP                            = 70, // <exp>
        SYMBOL_FOR2                           = 71, // <for>
        SYMBOL_ID                             = 72, // <id>
        SYMBOL_IDMINUSCHAR                    = 73, // <id-char>
        SYMBOL_IDMINUSCHARS                   = 74, // <id-chars>
        SYMBOL_IDMINUSTYPEMINUSLIST           = 75, // <id-type-list>
        SYMBOL_IDMINUSTYPEMINUSLISTMINUSPARTE = 76, // <id-type-list-parte>
        SYMBOL_IF2                            = 77, // <if>
        SYMBOL_IFMINUSTHENMINUSELSE           = 78, // <if-then-else>
        SYMBOL_LETTER                         = 79, // <letter>
        SYMBOL_LITERAL                        = 80, // <literal>
        SYMBOL_MINUS2                         = 81, // <minus>
        SYMBOL_NATURALMINUSCONSTANT           = 82, // <natural-constant>
        SYMBOL_PICOMINUSPROGRAM               = 83, // <pico-program>
        SYMBOL_PLUS2                          = 84, // <plus>
        SYMBOL_PRIMARY                        = 85, // <primary>
        SYMBOL_QUOTE2                         = 86, // <quote>
        SYMBOL_SERIES                         = 87, // <series>
        SYMBOL_STAT                           = 88, // <stat>
        SYMBOL_STRINGMINUSCONSTANT            = 89, // <string-constant>
        SYMBOL_STRINGMINUSTAIL                = 90, // <string-tail>
        SYMBOL_TYPE                           = 91, // <type>
        SYMBOL_WHILE2                         = 92  // <while>
    };

    enum RuleConstants : int
    {
        RULE_LITERAL_LPAREN             =  0, // <literal> ::= '('
        RULE_LITERAL_RPAREN             =  1, // <literal> ::= ')'
        RULE_LITERAL_PLUS               =  2, // <literal> ::= '+'
        RULE_LITERAL_MINUS              =  3, // <literal> ::= '-'
        RULE_LITERAL_SEMI               =  4, // <literal> ::= ';'
        RULE_LITERAL_PIPEPIPE           =  5, // <literal> ::= '||'
        RULE_LITERAL_COLON              =  6, // <literal> ::= ':'
        RULE_LITERAL_COLONEQ            =  7, // <literal> ::= ':='
        RULE_DIGIT_0                    =  8, // <digit> ::= '0'
        RULE_DIGIT_1                    =  9, // <digit> ::= '1'
        RULE_DIGIT_2                    = 10, // <digit> ::= '2'
        RULE_DIGIT_3                    = 11, // <digit> ::= '3'
        RULE_DIGIT_4                    = 12, // <digit> ::= '4'
        RULE_DIGIT_5                    = 13, // <digit> ::= '5'
        RULE_DIGIT_6                    = 14, // <digit> ::= '6'
        RULE_DIGIT_7                    = 15, // <digit> ::= '7'
        RULE_DIGIT_8                    = 16, // <digit> ::= '8'
        RULE_DIGIT_9                    = 17, // <digit> ::= '9'
        RULE_LETTER_A                   = 18, // <letter> ::= a
        RULE_LETTER_B                   = 19, // <letter> ::= b
        RULE_LETTER_C                   = 20, // <letter> ::= c
        RULE_LETTER_D                   = 21, // <letter> ::= d
        RULE_LETTER_E                   = 22, // <letter> ::= e
        RULE_LETTER_F                   = 23, // <letter> ::= f
        RULE_LETTER_G                   = 24, // <letter> ::= g
        RULE_LETTER_H                   = 25, // <letter> ::= h
        RULE_LETTER_I                   = 26, // <letter> ::= i
        RULE_LETTER_J                   = 27, // <letter> ::= j
        RULE_LETTER_L                   = 28, // <letter> ::= l
        RULE_LETTER_M                   = 29, // <letter> ::= m
        RULE_LETTER_N                   = 30, // <letter> ::= n
        RULE_LETTER_O                   = 31, // <letter> ::= o
        RULE_LETTER_P                   = 32, // <letter> ::= p
        RULE_LETTER_Q                   = 33, // <letter> ::= q
        RULE_LETTER_R                   = 34, // <letter> ::= r
        RULE_LETTER_S                   = 35, // <letter> ::= s
        RULE_LETTER_T                   = 36, // <letter> ::= t
        RULE_LETTER_U                   = 37, // <letter> ::= u
        RULE_LETTER_V                   = 38, // <letter> ::= v
        RULE_LETTER_X                   = 39, // <letter> ::= x
        RULE_LETTER_Z                   = 40, // <letter> ::= z
        RULE_LETTER_Y                   = 41, // <letter> ::= y
        RULE_LETTER_W                   = 42, // <letter> ::= w
        RULE_LETTER_K                   = 43, // <letter> ::= k
        RULE_EMPTY                      = 44, // <empty> ::= 
        RULE_QUOTE_QUOTE                = 45, // <quote> ::= '"'
        RULE_TYPE_NATURAL               = 46, // <type> ::= natural
        RULE_TYPE_STRING                = 47, // <type> ::= string
        RULE_IDCHAR                     = 48, // <id-char> ::= <letter>
        RULE_IDCHAR2                    = 49, // <id-char> ::= <digit>
        RULE_IDCHARS                    = 50, // <id-chars> ::= <id-char> <id-chars>
        RULE_IDCHARS2                   = 51, // <id-chars> ::= <empty>
        RULE_ID                         = 52, // <id> ::= <letter> <id-chars>
        RULE_DIGITS                     = 53, // <digits> ::= <digit> <digits>
        RULE_DIGITS2                    = 54, // <digits> ::= <empty>
        RULE_NATURALCONSTANT            = 55, // <natural-constant> ::= <digit> <digits>
        RULE_ANYCHARBUTQUOTE            = 56, // <any-char-but-quote> ::= <letter>
        RULE_ANYCHARBUTQUOTE2           = 57, // <any-char-but-quote> ::= <digit>
        RULE_ANYCHARBUTQUOTE3           = 58, // <any-char-but-quote> ::= <literal>
        RULE_STRINGTAIL                 = 59, // <string-tail> ::= <any-char-but-quote> <string-tail>
        RULE_STRINGTAIL2                = 60, // <string-tail> ::= <quote>
        RULE_STRINGCONSTANT             = 61, // <string-constant> ::= <quote> <string-tail>
        RULE_PRIMARY                    = 62, // <primary> ::= <id>
        RULE_PRIMARY2                   = 63, // <primary> ::= <natural-constant>
        RULE_PRIMARY3                   = 64, // <primary> ::= <string-constant>
        RULE_PRIMARY_LPAREN_RPAREN      = 65, // <primary> ::= '(' <exp> ')'
        RULE_PLUS_PLUS                  = 66, // <plus> ::= <exp> '+' <primary>
        RULE_EXP                        = 67, // <exp> ::= <primary>
        RULE_EXP2                       = 68, // <exp> ::= <plus>
        RULE_EXP3                       = 69, // <exp> ::= <minus>
        RULE_EXP4                       = 70, // <exp> ::= <conc>
        RULE_ASSIGN_COLONEQ             = 71, // <assign> ::= <id> ':=' <exp>
        RULE_CONC_PIPEPIPE              = 72, // <conc> ::= <exp> '||' <primary>
        RULE_MINUS_MINUS                = 73, // <minus> ::= <exp> '-' <primary>
        RULE_ESTADOINT                  = 74, // <estado-int> ::= <empty>
        RULE_ESTADOINT_SEMI             = 75, // <estado-int> ::= ';' <series>
        RULE_SERIES                     = 76, // <series> ::= <empty>
        RULE_SERIES2                    = 77, // <series> ::= <stat> <estado-int>
        RULE_WHILE_WHILE_DO_OD          = 78, // <while> ::= while <exp> do <series> od
        RULE_STAT                       = 79, // <stat> ::= <assign>
        RULE_STAT2                      = 80, // <stat> ::= <if>
        RULE_STAT3                      = 81, // <stat> ::= <if-then-else>
        RULE_STAT4                      = 82, // <stat> ::= <while>
        RULE_STAT5                      = 83, // <stat> ::= <for>
        RULE_FOR_FOR_SEMI_SEMI_DO_OD    = 84, // <for> ::= for <exp> ';' <exp> ';' <exp> do <series> od
        RULE_IFTHENELSE_IF_THEN_ELSE_FI = 85, // <if-then-else> ::= if <exp> then <series> else <series> fi
        RULE_IF_IF_THEN_FI              = 86, // <if> ::= if <exp> then <series> fi
        RULE_IDTYPELISTPARTE            = 87, // <id-type-list-parte> ::= <empty>
        RULE_IDTYPELISTPARTE_COMMA      = 88, // <id-type-list-parte> ::= ',' <id-type-list>
        RULE_IDTYPELIST_COLON           = 89, // <id-type-list> ::= <id> ':' <type> <id-type-list-parte>
        RULE_DECLS_DECLARE_SEMI         = 90, // <decls> ::= declare <id-type-list> ';'
        RULE_PICOPROGRAM_BEGIN_END      = 91  // <pico-program> ::= begin <decls> <series> end
    };

    public class MyParser2
    {
        private LALRParser parser;
        ListBox lstErrors;
        RichTextBox lstTree;

        public MyParser2(string filename, ListBox lstErrors, RichTextBox lstTree)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();

            this.lstErrors = lstErrors;
            this.lstTree = lstTree;
        }

        public MyParser2(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser2(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnAccept += new LALRParser.AcceptHandler(AcceptEvent);
            parser.OnReduce += new LALRParser.ReduceHandler(ReduceEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUOTE :
                //'"'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLONEQ :
                //':='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEPIPE :
                //'||'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_0 :
                //'0'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_1 :
                //'1'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_2 :
                //'2'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_3 :
                //'3'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_4 :
                //'4'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_5 :
                //'5'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_6 :
                //'6'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_7 :
                //'7'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_8 :
                //'8'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_9 :
                //'9'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_A :
                //a
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_B :
                //b
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BEGIN :
                //begin
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_C :
                //c
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_D :
                //d
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARE :
                //declare
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_E :
                //e
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //end
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_F :
                //f
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FI :
                //fi
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_G :
                //g
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_H :
                //h
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_I :
                //i
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_J :
                //j
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_K :
                //k
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_L :
                //l
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_M :
                //m
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_N :
                //n
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NATURAL :
                //natural
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_O :
                //o
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OD :
                //od
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_P :
                //p
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_Q :
                //q
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_R :
                //r
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_S :
                //s
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_T :
                //t
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THEN :
                //then
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_U :
                //u
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_V :
                //v
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_W :
                //w
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_X :
                //x
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_Y :
                //y
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_Z :
                //z
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ANYMINUSCHARMINUSBUTMINUSQUOTE :
                //<any-char-but-quote>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONC :
                //<conc>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLS :
                //<decls>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGITS :
                //<digits>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EMPTY :
                //<empty>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ESTADOMINUSINT :
                //<estado-int>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR2 :
                //<for>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDMINUSCHAR :
                //<id-char>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDMINUSCHARS :
                //<id-chars>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDMINUSTYPEMINUSLIST :
                //<id-type-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDMINUSTYPEMINUSLISTMINUSPARTE :
                //<id-type-list-parte>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF2 :
                //<if>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFMINUSTHENMINUSELSE :
                //<if-then-else>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LETTER :
                //<letter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LITERAL :
                //<literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS2 :
                //<minus>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NATURALMINUSCONSTANT :
                //<natural-constant>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PICOMINUSPROGRAM :
                //<pico-program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS2 :
                //<plus>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARY :
                //<primary>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUOTE2 :
                //<quote>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SERIES :
                //<series>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STAT :
                //<stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGMINUSCONSTANT :
                //<string-constant>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGMINUSTAIL :
                //<string-tail>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE2 :
                //<while>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_LITERAL_LPAREN :
                //<literal> ::= '('
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_RPAREN :
                //<literal> ::= ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_PLUS :
                //<literal> ::= '+'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_MINUS :
                //<literal> ::= '-'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_SEMI :
                //<literal> ::= ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_PIPEPIPE :
                //<literal> ::= '||'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_COLON :
                //<literal> ::= ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_COLONEQ :
                //<literal> ::= ':='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_0 :
                //<digit> ::= '0'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_1 :
                //<digit> ::= '1'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_2 :
                //<digit> ::= '2'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_3 :
                //<digit> ::= '3'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_4 :
                //<digit> ::= '4'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_5 :
                //<digit> ::= '5'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_6 :
                //<digit> ::= '6'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_7 :
                //<digit> ::= '7'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_8 :
                //<digit> ::= '8'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_9 :
                //<digit> ::= '9'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_A :
                //<letter> ::= a
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_B :
                //<letter> ::= b
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_C :
                //<letter> ::= c
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_D :
                //<letter> ::= d
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_E :
                //<letter> ::= e
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_F :
                //<letter> ::= f
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_G :
                //<letter> ::= g
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_H :
                //<letter> ::= h
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_I :
                //<letter> ::= i
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_J :
                //<letter> ::= j
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_L :
                //<letter> ::= l
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_M :
                //<letter> ::= m
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_N :
                //<letter> ::= n
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_O :
                //<letter> ::= o
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_P :
                //<letter> ::= p
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_Q :
                //<letter> ::= q
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_R :
                //<letter> ::= r
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_S :
                //<letter> ::= s
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_T :
                //<letter> ::= t
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_U :
                //<letter> ::= u
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_V :
                //<letter> ::= v
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_X :
                //<letter> ::= x
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_Z :
                //<letter> ::= z
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_Y :
                //<letter> ::= y
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_W :
                //<letter> ::= w
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LETTER_K :
                //<letter> ::= k
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EMPTY :
                //<empty> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_QUOTE_QUOTE :
                //<quote> ::= '"'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_NATURAL :
                //<type> ::= natural
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_STRING :
                //<type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IDCHAR :
                //<id-char> ::= <letter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IDCHAR2 :
                //<id-char> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IDCHARS :
                //<id-chars> ::= <id-char> <id-chars>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IDCHARS2 :
                //<id-chars> ::= <empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID :
                //<id> ::= <letter> <id-chars>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGITS :
                //<digits> ::= <digit> <digits>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGITS2 :
                //<digits> ::= <empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NATURALCONSTANT :
                //<natural-constant> ::= <digit> <digits>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ANYCHARBUTQUOTE :
                //<any-char-but-quote> ::= <letter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ANYCHARBUTQUOTE2 :
                //<any-char-but-quote> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ANYCHARBUTQUOTE3 :
                //<any-char-but-quote> ::= <literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STRINGTAIL :
                //<string-tail> ::= <any-char-but-quote> <string-tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STRINGTAIL2 :
                //<string-tail> ::= <quote>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STRINGCONSTANT :
                //<string-constant> ::= <quote> <string-tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY :
                //<primary> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY2 :
                //<primary> ::= <natural-constant>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY3 :
                //<primary> ::= <string-constant>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY_LPAREN_RPAREN :
                //<primary> ::= '(' <exp> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PLUS_PLUS :
                //<plus> ::= <exp> '+' <primary>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <primary>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <plus>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP3 :
                //<exp> ::= <minus>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP4 :
                //<exp> ::= <conc>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_COLONEQ :
                //<assign> ::= <id> ':=' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONC_PIPEPIPE :
                //<conc> ::= <exp> '||' <primary>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MINUS_MINUS :
                //<minus> ::= <exp> '-' <primary>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ESTADOINT :
                //<estado-int> ::= <empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ESTADOINT_SEMI :
                //<estado-int> ::= ';' <series>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SERIES :
                //<series> ::= <empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SERIES2 :
                //<series> ::= <stat> <estado-int>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_WHILE_DO_OD :
                //<while> ::= while <exp> do <series> od
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT :
                //<stat> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT2 :
                //<stat> ::= <if>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT3 :
                //<stat> ::= <if-then-else>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT4 :
                //<stat> ::= <while>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT5 :
                //<stat> ::= <for>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_FOR_SEMI_SEMI_DO_OD :
                //<for> ::= for <exp> ';' <exp> ';' <exp> do <series> od
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFTHENELSE_IF_THEN_ELSE_FI :
                //<if-then-else> ::= if <exp> then <series> else <series> fi
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_IF_THEN_FI :
                //<if> ::= if <exp> then <series> fi
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IDTYPELISTPARTE :
                //<id-type-list-parte> ::= <empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IDTYPELISTPARTE_COMMA :
                //<id-type-list-parte> ::= ',' <id-type-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IDTYPELIST_COLON :
                //<id-type-list> ::= <id> ':' <type> <id-type-list-parte>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLS_DECLARE_SEMI :
                //<decls> ::= declare <id-type-list> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PICOPROGRAM_BEGIN_END :
                //<pico-program> ::= begin <decls> <series> end
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            //Por nestas coisas a tradução para C

            string message = "Tree: " + args.Token.ToString() + "\r\n\r\n";
            lstTree.AppendText(message);
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            string message = "TokenRead: " + args.Token.ToString() + "\r\n\r\n";
            //lstTree.AppendText(message);
            args.Continue = true;
        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
            string message = "Reduce: " + args.Token.ToString()+ "\r\n\r\n";
            //lstTree.AppendText(message);
            args.Continue = true;
            
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"' in line : "+args.Token.Location.LineNr;
            lstErrors.Items.Add(message);
            args.Continue = true;
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            //Antes era Parse error caused by token , agora é Syntax Error
            string message = "Syntax Error: '" + args.UnexpectedToken.ToString()+"' in line : "+ args.UnexpectedToken.Location.LineNr;
            lstErrors.Items.Add(message);
            string message2 = "Expected Token : '" + args.ExpectedTokens.ToString() + "'";
            lstErrors.Items.Add(message2);
            args.Continue = ContinueMode.Stop;
            //todo: Report message to UI?
        }

    }
}
*/