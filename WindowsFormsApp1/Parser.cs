
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

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
        SYMBOL_EOF = 0, // (EOF)
        SYMBOL_ERROR = 1, // (Error)
        SYMBOL_WHITESPACE = 2, // Whitespace
        SYMBOL_MINUS = 3, // '-'
        SYMBOL_LPAREN = 4, // '('
        SYMBOL_RPAREN = 5, // ')'
        SYMBOL_COMMA = 6, // ','
        SYMBOL_COLON = 7, // ':'
        SYMBOL_COLONEQ = 8, // ':='
        SYMBOL_SEMI = 9, // ';'
        SYMBOL__ = 10, // '_'
        SYMBOL_PIPEPIPE = 11, // '||'
        SYMBOL_PLUS = 12, // '+'
        SYMBOL_LT = 13, // '<'
        SYMBOL_GT = 14, // '>'
        SYMBOL_BEGIN = 15, // begin
        SYMBOL_DECLARE = 16, // declare
        SYMBOL_DO = 17, // do
        SYMBOL_ELSE = 18, // else
        SYMBOL_END = 19, // end
        SYMBOL_FI = 20, // fi
        SYMBOL_FOR = 21, // for
        SYMBOL_IF = 22, // if
        SYMBOL_LETTER = 23, // letter
        SYMBOL_NATURAL = 24, // natural
        SYMBOL_OD = 25, // od
        SYMBOL_QUOTE = 26, // quote
        SYMBOL_THE = 27, // the
        SYMBOL_THEN = 28, // then
        SYMBOL_TYPE = 29, // type
        SYMBOL_WHILE = 30, // while
        SYMBOL_ASSIGN = 31, // <assign>
        SYMBOL_CONC = 32, // <conc>
        SYMBOL_DECLARATIONS = 33, // <declarations>
        SYMBOL_DECLARE2 = 34, // <declare>
        SYMBOL_EXP = 35, // <exp>
        SYMBOL_FEWER = 36, // <fewer>
        SYMBOL_FOR2 = 37, // <for>
        SYMBOL_FOR_DATA = 38, // <for_data>
        SYMBOL_HIGHER = 39, // <higher>
        SYMBOL_ID = 40, // <id>
        SYMBOL_ID_CONT = 41, // <id_cont>
        SYMBOL_IF2 = 42, // <if>
        SYMBOL_IF_ELSE = 43, // <if_else>
        SYMBOL_LITERAL = 44, // <literal>
        SYMBOL_MINUS2 = 45, // <minus>
        SYMBOL_PICOBEGIN = 46, // <picoBegin>
        SYMBOL_PLUS2 = 47, // <plus>
        SYMBOL_PRIMARY = 48, // <primary>
        SYMBOL_SERIES = 49, // <series>
        SYMBOL_STRING_CONSTANT = 50, // <string_constant>
        SYMBOL_STRING_DATA = 51, // <string_data>
        SYMBOL_STRING_ESCAPE = 52, // <string_escape>
        SYMBOL_WHILE2 = 53  // <while>
    };

    enum RuleConstants : int
    {
        RULE_ID_LETTER = 0, // <id> ::= letter <id_cont>
        RULE_ID_CONT_LETTER = 1, // <id_cont> ::= letter <id_cont>
        RULE_ID_CONT_NATURAL = 2, // <id_cont> ::= natural <id_cont>
        RULE_ID_CONT__ = 3, // <id_cont> ::= '_' <id_cont>
        RULE_ID_CONT = 4, // <id_cont> ::= 
        RULE_LITERAL_LPAREN = 5, // <literal> ::= '('
        RULE_LITERAL_RPAREN = 6, // <literal> ::= ')'
        RULE_LITERAL_PLUS = 7, // <literal> ::= '+'
        RULE_LITERAL_MINUS = 8, // <literal> ::= '-'
        RULE_LITERAL_SEMI = 9, // <literal> ::= ';'
        RULE_LITERAL_PIPEPIPE = 10, // <literal> ::= '||'
        RULE_LITERAL_COLON = 11, // <literal> ::= ':'
        RULE_LITERAL_COLONEQ = 12, // <literal> ::= ':='
        RULE_STRING_ESCAPE_DECLARE = 13, // <string_escape> ::= declare
        RULE_STRING_ESCAPE_IF = 14, // <string_escape> ::= if
        RULE_STRING_ESCAPE_THE = 15, // <string_escape> ::= the
        RULE_STRING_ESCAPE_ELSE = 16, // <string_escape> ::= else
        RULE_STRING_ESCAPE_FI = 17, // <string_escape> ::= fi
        RULE_STRING_ESCAPE_FOR = 18, // <string_escape> ::= for
        RULE_STRING_ESCAPE_DO = 19, // <string_escape> ::= do
        RULE_STRING_ESCAPE_OD = 20, // <string_escape> ::= od
        RULE_STRING_ESCAPE_BEGIN = 21, // <string_escape> ::= begin
        RULE_STRING_ESCAPE_END = 22, // <string_escape> ::= end
        RULE_STRING_ESCAPE_WHILE = 23, // <string_escape> ::= while
        RULE_STRING_DATA_NATURAL = 24, // <string_data> ::= natural <string_data>
        RULE_STRING_DATA_LETTER = 25, // <string_data> ::= letter <string_data>
        RULE_STRING_DATA = 26, // <string_data> ::= <literal> <string_data>
        RULE_STRING_DATA2 = 27, // <string_data> ::= <string_escape> <string_data>
        RULE_STRING_DATA3 = 28, // <string_data> ::= 
        RULE_STRING_CONSTANT_QUOTE_QUOTE = 29, // <string_constant> ::= quote <string_data> quote
        RULE_PLUS_PLUS = 30, // <plus> ::= <exp> '+' <primary>
        RULE_MINUS_MINUS = 31, // <minus> ::= <exp> '-' <primary>
        RULE_CONC_PIPEPIPE = 32, // <conc> ::= <exp> '||' <primary>
        RULE_FEWER_LT = 33, // <fewer> ::= <exp> '<' <primary>
        RULE_HIGHER_GT = 34, // <higher> ::= <exp> '>' <primary>
        RULE_ASSIGN_COLONEQ = 35, // <assign> ::= <id> ':=' <exp>
        RULE_DECLARATIONS_COLON_TYPE_COMMA = 36, // <declarations> ::= <id> ':' type ',' <declarations>
        RULE_DECLARATIONS_COLON_TYPE = 37, // <declarations> ::= <id> ':' type
        RULE_DECLARE_DECLARE_SEMI = 38, // <declare> ::= declare <declarations> ';'
        RULE_EXP = 39, // <exp> ::= <primary>
        RULE_EXP2 = 40, // <exp> ::= <plus>
        RULE_EXP3 = 41, // <exp> ::= <minus>
        RULE_EXP4 = 42, // <exp> ::= <conc>
        RULE_EXP5 = 43, // <exp> ::= <fewer>
        RULE_EXP6 = 44, // <exp> ::= <higher>
        RULE_PRIMARY = 45, // <primary> ::= <id>
        RULE_PRIMARY_NATURAL = 46, // <primary> ::= natural
        RULE_PRIMARY2 = 47, // <primary> ::= <string_constant>
        RULE_PRIMARY_LPAREN_RPAREN = 48, // <primary> ::= '(' <exp> ')'
        RULE_IF_IF_THEN = 49, // <if> ::= if <exp> then <series> <if_else>
        RULE_IF_ELSE_ELSE_FI = 50, // <if_else> ::= else <series> fi
        RULE_IF_ELSE_FI = 51, // <if_else> ::= fi
        RULE_FOR_DATA = 52, // <for_data> ::= <exp>
        RULE_FOR_DATA2 = 53, // <for_data> ::= <assign>
        RULE_FOR_FOR_SEMI_SEMI_DO_OD = 54, // <for> ::= for <for_data> ';' <for_data> ';' <for_data> do <series> od
        RULE_WHILE_WHILE_DO_OD = 55, // <while> ::= while <exp> do <series> od
        RULE_SERIES_SEMI = 56, // <series> ::= <assign> ';' <series>
        RULE_SERIES = 57, // <series> ::= <if> <series>
        RULE_SERIES2 = 58, // <series> ::= <for> <series>
        RULE_SERIES3 = 59, // <series> ::= <while> <series>
        RULE_SERIES4 = 60, // <series> ::= 
        RULE_PICOBEGIN_BEGIN_END = 61  // <picoBegin> ::= begin <declare> <series> end
    };

    public class MyParser
    {
        private LALRParser parser;

        //Send errors to GUI
        ListBox lstErrors;
        //Show C code
        RichTextBox c_code;
        
        //Detect if it is being parsed with sucess
        private bool parsingStatus;
        #region Detecting Data Types And generating the Converting PICO into C code
        //Detect Variables
        private string currentSection;
        //Register Of all Declared variables
        private LinkedList<string> declaredVariables;
        //Variable Type Check Cache
        private LinkedList<string> variableCheckCache;
        #endregion

        public MyParser(string filename, ListBox lstErrors, RichTextBox c_code)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            Init(stream);
            stream.Close();

            this.lstErrors = lstErrors;
            this.c_code = c_code;
            this.parsingStatus = true;

            this.currentSection = "";
            #region Start everything related to data type verification and C code converter
            declaredVariables = new LinkedList<string>();
            variableCheckCache = new LinkedList<string>();
            #endregion
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
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
            parsingStatus = true;
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
                case (int)SymbolConstants.SYMBOL_EOF:
                    //(EOF)
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ERROR:
                    //(Error)
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE:
                    //Whitespace
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_MINUS:
                    //'-'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LPAREN:
                    //'('
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_RPAREN:
                    //')'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COMMA:
                    //','
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COLON:
                    //':'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_COLONEQ:
                    //':='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SEMI:
                    //';'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL__:
                    //'_'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PIPEPIPE:
                    //'||'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PLUS:
                    //'+'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LT:
                    //'<'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_GT:
                    //'>'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_BEGIN:
                    //begin
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DECLARE:
                    //declare
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DO:
                    //do
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ELSE:
                    //else
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_END:
                    //end
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FI:
                    //fi
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FOR:
                    //for
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IF:
                    //if
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LETTER:
                    //letter
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NATURAL:
                    //natural
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_OD:
                    //od
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_QUOTE:
                    //quote
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_THE:
                    //the
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_THEN:
                    //then
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TYPE:
                    //type
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHILE:
                    //while
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN:
                    //<assign>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_CONC:
                    //<conc>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DECLARATIONS:
                    //<declarations>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DECLARE2:
                    //<declare>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EXP:
                    //<exp>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FEWER:
                    //<fewer>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FOR2:
                    //<for>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FOR_DATA:
                    //<for_data>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_HIGHER:
                    //<higher>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ID:
                    //<id>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ID_CONT:
                    //<id_cont>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IF2:
                    //<if>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IF_ELSE:
                    //<if_else>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LITERAL:
                    //<literal>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_MINUS2:
                    //<minus>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PICOBEGIN:
                    //<picoBegin>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PLUS2:
                    //<plus>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PRIMARY:
                    //<primary>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SERIES:
                    //<series>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STRING_CONSTANT:
                    //<string_constant>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STRING_DATA:
                    //<string_data>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STRING_ESCAPE:
                    //<string_escape>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHILE2:
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
                case (int)RuleConstants.RULE_ID_LETTER:
                    //<id> ::= letter <id_cont>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ID_CONT_LETTER:
                    //<id_cont> ::= letter <id_cont>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ID_CONT_NATURAL:
                    //<id_cont> ::= natural <id_cont>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ID_CONT__:
                    //<id_cont> ::= '_' <id_cont>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ID_CONT:
                    //<id_cont> ::= 
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LITERAL_LPAREN:
                    //<literal> ::= '('
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LITERAL_RPAREN:
                    //<literal> ::= ')'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LITERAL_PLUS:
                    //<literal> ::= '+'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LITERAL_MINUS:
                    //<literal> ::= '-'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LITERAL_SEMI:
                    //<literal> ::= ';'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LITERAL_PIPEPIPE:
                    //<literal> ::= '||'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LITERAL_COLON:
                    //<literal> ::= ':'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_LITERAL_COLONEQ:
                    //<literal> ::= ':='
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_ESCAPE_DECLARE:
                    //<string_escape> ::= declare
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_ESCAPE_IF:
                    //<string_escape> ::= if
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_ESCAPE_THE:
                    //<string_escape> ::= the
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_ESCAPE_ELSE:
                    //<string_escape> ::= else
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_ESCAPE_FI:
                    //<string_escape> ::= fi
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_ESCAPE_FOR:
                    //<string_escape> ::= for
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_ESCAPE_DO:
                    //<string_escape> ::= do
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_ESCAPE_OD:
                    //<string_escape> ::= od
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_ESCAPE_BEGIN:
                    //<string_escape> ::= begin
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_ESCAPE_END:
                    //<string_escape> ::= end
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_ESCAPE_WHILE:
                    //<string_escape> ::= while
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_DATA_NATURAL:
                    //<string_data> ::= natural <string_data>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_DATA_LETTER:
                    //<string_data> ::= letter <string_data>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_DATA:
                    //<string_data> ::= <literal> <string_data>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_DATA2:
                    //<string_data> ::= <string_escape> <string_data>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_DATA3:
                    //<string_data> ::= 
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STRING_CONSTANT_QUOTE_QUOTE:
                    //<string_constant> ::= quote <string_data> quote
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PLUS_PLUS:
                    //<plus> ::= <exp> '+' <primary>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_MINUS_MINUS:
                    //<minus> ::= <exp> '-' <primary>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_CONC_PIPEPIPE:
                    //<conc> ::= <exp> '||' <primary>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FEWER_LT:
                    //<fewer> ::= <exp> '<' <primary>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_HIGHER_GT:
                    //<higher> ::= <exp> '>' <primary>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ASSIGN_COLONEQ:
                    //<assign> ::= <id> ':=' <exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_DECLARATIONS_COLON_TYPE_COMMA:
                    //<declarations> ::= <id> ':' type ',' <declarations>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_DECLARATIONS_COLON_TYPE:
                    //<declarations> ::= <id> ':' type
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_DECLARE_DECLARE_SEMI:
                    //<declare> ::= declare <declarations> ';'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXP:
                    //<exp> ::= <primary>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXP2:
                    //<exp> ::= <plus>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXP3:
                    //<exp> ::= <minus>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXP4:
                    //<exp> ::= <conc>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXP5:
                    //<exp> ::= <fewer>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXP6:
                    //<exp> ::= <higher>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PRIMARY:
                    //<primary> ::= <id>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PRIMARY_NATURAL:
                    //<primary> ::= natural
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PRIMARY2:
                    //<primary> ::= <string_constant>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PRIMARY_LPAREN_RPAREN:
                    //<primary> ::= '(' <exp> ')'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_IF_IF_THEN:
                    //<if> ::= if <exp> then <series> <if_else>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_IF_ELSE_ELSE_FI:
                    //<if_else> ::= else <series> fi
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_IF_ELSE_FI:
                    //<if_else> ::= fi
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FOR_DATA:
                    //<for_data> ::= <exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FOR_DATA2:
                    //<for_data> ::= <assign>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FOR_FOR_SEMI_SEMI_DO_OD:
                    //<for> ::= for <for_data> ';' <for_data> ';' <for_data> do <series> od
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_WHILE_WHILE_DO_OD:
                    //<while> ::= while <exp> do <series> od
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_SERIES_SEMI:
                    //<series> ::= <assign> ';' <series>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_SERIES:
                    //<series> ::= <if> <series>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_SERIES2:
                    //<series> ::= <for> <series>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_SERIES3:
                    //<series> ::= <while> <series>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_SERIES4:
                    //<series> ::= 
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_PICOBEGIN_BEGIN_END:
                    //<picoBegin> ::= begin <declare> <series> end
                    //todo: Create a new object using the stored tokens.
                    return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            string message = "No errors found!";
            if (parsingStatus)
                lstErrors.Items.Add(message);
            else
                c_code.Text = "";
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            string currentToken = args.Token.ToString();
            string message = "TokenRead: " + currentToken + "\r\n\r\n";
            args.Continue = true;
            //Debug Only
            //System.Windows.Forms.MessageBox.Show(message);

            //Cases para o For, If, e o While devem de nao fazer nada quando detetam o estado "assign". 
            //Esses cases devem considerar o que está no <string_escape> como não fazendo parte da sintaxe do PICO
            switch (currentToken)
            {
                #region Begin,End
                case "begin":
                    c_code.Text += "#include <stdio.h>\r\n int main () {\r\n";
                    break;
                case "end":
                    c_code.Text += "    return 0;\r\n}\r\n";
                    break;
                #endregion
                case "if":
                    if (String.Equals(currentSection.Split(' ')[0], ""))
                    {
                        //Enter If Header
                        currentSection = "if";
                        //Debug Only
                        //System.Windows.Forms.MessageBox.Show("Entered If Header!");

                        c_code.Text += "if( ";

                    }
                    break;
                case "then":
                    if (String.Equals(currentSection.Split(' ')[0], "if"))
                    {
                        string firstVariableType = variableCheckCache.First.Value.ToString();
                        bool allVariableSameType = true;
                        foreach (string ptr in variableCheckCache)
                        {
                            if (!String.Equals(firstVariableType, ptr))
                            {
                                allVariableSameType = false;
                                break;
                            }
                        }
                        if (!allVariableSameType)
                        {
                            //Debug Only
                            //System.Windows.Forms.MessageBox.Show("Variables are not the same type!");
                            lstErrors.Items.Add("Cannot convert natural type to string or vice versa.");
                            parsingStatus = false;
                            c_code.Text = "";
                        }

                        //Exit If Header
                        variableCheckCache = new LinkedList<string>();
                        currentSection = "";

                        c_code.Text += " ) {\r\n";
                        //Debug Only
                        //System.Windows.Forms.MessageBox.Show("Exit If Header!");
                    }
                    break;
                case "else":
                    c_code.Text += " } else {\r\n";
                    break;
                case "fi":
                    c_code.Text += " }\r\n";
                    break;

                case "for":
                    if (String.Equals(currentSection.Split(' ')[0], ""))
                    {
                        //Enter for header
                        currentSection = "for";
                        //Debug Only
                        //System.Windows.Forms.MessageBox.Show("Entered For Header!");

                        c_code.Text += "for( ";

                    }
                    break;
                case "while":
                    if (String.Equals(currentSection.Split(' ')[0], ""))
                    {
                        //Enter while Header
                        currentSection = "while";
                        //Debug Only
                        //System.Windows.Forms.MessageBox.Show("Entered While Header!");
                        c_code.Text += "while( ";

                    }
                    break;
                #region For and While Common Part
                case "do":
                    if (String.Equals(currentSection.Split(' ')[0], "for"))
                    {
                        string firstVariableType = variableCheckCache.First.Value.ToString();
                        bool allVariableSameType = true;
                        foreach (string ptr in variableCheckCache)
                        {
                            if (!String.Equals(firstVariableType, ptr))
                            {
                                allVariableSameType = false;
                                break;
                            }
                        }
                        if (!allVariableSameType)
                        {
                            //Debug Only
                            //System.Windows.Forms.MessageBox.Show("Variables are not the same type!");
                            lstErrors.Items.Add("Cannot convert natural type to string or vice versa.");
                            parsingStatus = false;
                            c_code.Text = "";
                        }

                        //Exit For Header
                        variableCheckCache = new LinkedList<string>();
                        //Debug Only
                        //System.Windows.Forms.MessageBox.Show("Exit For Header!");

                        c_code.Text += " ){ \r\n";
                        currentSection = "";
                    }
                    else
                    if (String.Equals(currentSection.Split(' ')[0], "while"))
                    {
                        string firstVariableType = variableCheckCache.First.Value.ToString();
                        bool allVariableSameType = true;
                        foreach (string ptr in variableCheckCache)
                        {
                            if (!String.Equals(firstVariableType, ptr))
                            {
                                allVariableSameType = false;
                                break;
                            }
                        }
                        if (!allVariableSameType)
                        {
                            //Debug Only
                            //System.Windows.Forms.MessageBox.Show("Variables are not the same type!");
                            lstErrors.Items.Add("Cannot convert natural type to string or vice versa.");
                            parsingStatus = false;
                            c_code.Text = "";
                        }

                        //Exit While Header
                        variableCheckCache = new LinkedList<string>();
                        //Debug Only
                        //System.Windows.Forms.MessageBox.Show("Exit While Header!");
                        c_code.Text += " ){ \r\n";
                        currentSection = "";
                    }
                    break;
                case "od":

                    c_code.Text += " }\r\n";
                    break;
                #endregion
                case "\"":
                    //Enter String Parsing
                    if (String.Equals(currentSection, "assign") || String.Equals(currentSection, "if") || String.Equals(currentSection, "while") || String.Equals(currentSection, "for"))
                    {
                        //Enter String Constant
                        currentSection += " string";
                        //Debug Only
                        //System.Windows.Forms.MessageBox.Show("Entered String Constant!");
                        c_code.Text += "\" ";
                    }
                    else
                    {
                        //Exit String Parsing
                        if (String.Equals(currentSection, "assign string") || String.Equals(currentSection, "if string") || String.Equals(currentSection, "while string") || String.Equals(currentSection, "for string"))
                        {


                            //Exit String Constant
                            currentSection = currentSection.Split(' ')[0];
                            //Debug Only
                            //System.Windows.Forms.MessageBox.Show("Exit String Constant!");
                            c_code.Text += " \"\r\n";
                        }
                    }
                    break;
                case "declare":
                    if (!String.Equals(currentSection.Split(' ')[0], "declare") && !String.Equals(currentSection.Split(' ')[0], "assign"))
                    {
                        //Enter Declare
                        currentSection = "declare";
                        //Debug Only
                        //System.Windows.Forms.MessageBox.Show("Entered Declare!");
                    }
                    break;
                case "natural":
                    if (String.Equals(currentSection.Split(' ')[0], "declare"))
                    {
                        //Debug Only
                        //System.Windows.Forms.MessageBox.Show("Variable "+ declaredVariables.Last.Value.ToString()+" (natural) added to declared list");
                        declaredVariables.Last.Value = declaredVariables.Last.Value.ToString() + " natural";
                        c_code.Text += "int " + declaredVariables.Last.Value.Split(' ')[0].ToString() + " = (int*) malloc(sizeof(int));\r\n";
                    }
                    break;
                case "string":
                    if (String.Equals(currentSection.Split(' ')[0], "declare"))
                    {
                        //Debug Only
                        //System.Windows.Forms.MessageBox.Show("Variable " + declaredVariables.Last.Value.ToString() + " (natural) added to declared list");
                        declaredVariables.Last.Value = declaredVariables.Last.Value.ToString() + " string";
                        c_code.Text += "char *" + declaredVariables.Last.Value.Split(' ')[0].ToString() + " = (char*) malloc(sizeof(char)*1000*3);\r\n";
                    }
                    break;
                case ",":
                    //Parsed a declare variable
                    //Debug Only
                    //System.Windows.Forms.MessageBox.Show("Parsed a declared variable!");
                    break;
                case ";":
                    switch (currentSection)
                    {
                        case "declare":
                            if (String.Equals(currentSection.Split(' ')[0], "declare"))
                            {


                                //Exit declare
                                //Debug Only
                                //System.Windows.Forms.MessageBox.Show("Exit Declare!");
                                currentSection = "";
                            }
                            break;
                        case "assign":
                            if (String.Equals(currentSection.Split(' ')[0], "assign"))
                            {
                                string firstVariableType = variableCheckCache.First.Value.ToString();
                                bool allVariableSameType = true;
                                foreach (string ptr in variableCheckCache)
                                {
                                    if (!String.Equals(firstVariableType, ptr))
                                    {
                                        allVariableSameType = false;
                                        //Debug Only
                                        //System.Windows.Forms.MessageBox.Show("Original: "+firstVariableType + " DIf: " + ptr + "!");
                                        break;
                                    }
                                }
                                if (!allVariableSameType)
                                {
                                    //Debug Only
                                    //System.Windows.Forms.MessageBox.Show("Variables are not the same type!");
                                    lstErrors.Items.Add("Cannot convert natural type to string or vice versa.");
                                    parsingStatus = false;
                                    c_code.Text = "";
                                }
                                else
                                {
                                    c_code.Text += ";\r\n";
                                }

                                //Exit assign
                                //Debug Only
                                //System.Windows.Forms.MessageBox.Show("Exit Assign!");
                                currentSection = "";
                                variableCheckCache = new LinkedList<string>();
                            }
                            break;
                        case "for":
                            if (String.Equals(currentSection.Split(' ')[0], "for"))
                            {
                                string firstVariableType = variableCheckCache.First.Value.ToString();
                                bool allVariableSameType = true;
                                foreach (string ptr in variableCheckCache)
                                {
                                    if (!String.Equals(firstVariableType, ptr))
                                    {
                                        allVariableSameType = false;
                                        break;
                                    }
                                }
                                if (!allVariableSameType)
                                {
                                    //Debug Only
                                    //System.Windows.Forms.MessageBox.Show("Variables are not the same type!");
                                    lstErrors.Items.Add("Cannot convert natural type to string or vice versa.");
                                    parsingStatus = false;
                                    c_code.Text = "";
                                }

                                //Parsed a For Header Camp
                                variableCheckCache = new LinkedList<string>();
                                //Debug Only
                                //System.Windows.Forms.MessageBox.Show("Parsed a for header camp!");

                                c_code.Text += " ; ";

                            }
                            break;
                        default:
                            if (currentSection.Contains(" string"))
                            {
                                c_code.Text += " ; ";
                            }
                            break;
                    }
                    break;
                case ":":
                    if (currentSection.Contains(" string"))
                    {
                        c_code.Text += " : ";
                    }
                    break;

                case ":=":
                    c_code.Text += " = ";
                    break;
                case "+":
                    c_code.Text += " + ";
                    break;
                case "-":
                    c_code.Text += " - ";
                    break;
                case "||":
                    c_code.Text += " || ";
                    break;
                case "<":
                    c_code.Text += " < ";
                    break;
                case ">":
                    c_code.Text += " > ";
                    break;
                case "==":
                //break;
                case "(EOF)":
                    //Finished Parsing!
                    break;
                default:
                    if (String.Equals(currentSection.Split(' ')[0], ""))
                    {
                        //Entered Assign Header

                        c_code.Text += currentToken;
                        currentSection = "assign";
                        //Debug Only
                        //System.Windows.Forms.MessageBox.Show("Entered Assign!");
                        if (!variableExists(currentToken))
                        {
                            lstErrors.Items.Add(currentToken + " is not declared");
                            variableCheckCache.AddLast("notDeclared");
                            parsingStatus = false;
                            break;
                        }
                        else
                        {
                            variableCheckCache.AddLast(getVariableType(currentToken));
                        }
                    }
                    else
                    if (String.Equals(currentSection, "assign string") || String.Equals(currentSection, "if string") || String.Equals(currentSection, "for string") || String.Equals(currentSection, "while string"))
                    {
                        variableCheckCache.AddLast("string");
                        c_code.Text += currentToken + " ";
                    }
                    else
                    if (String.Equals(currentSection, "assign") || String.Equals(currentSection, "if") || String.Equals(currentSection, "for") || String.Equals(currentSection, "while"))
                    {
                        //Check if it is a number
                        if (isStringDigitsOnly(currentToken))
                        {
                            variableCheckCache.AddLast("natural");
                            c_code.Text += currentToken;
                        }
                        else
                        if (!variableExists(currentToken))
                        {
                            lstErrors.Items.Add(currentToken + " is not declared");
                            variableCheckCache.AddLast("notDeclared");
                            break;
                        }
                        else
                        if (variableExists(currentToken))
                        {
                            variableCheckCache.AddLast(getVariableType(currentToken));
                            c_code.Text += currentToken;
                        }

                    }
                    if (String.Equals(currentSection.Split(' ')[0], "declare"))
                    {
                        declaredVariables.AddLast(currentToken);
                    }
                    break;
            }
            //Debug Only
            //lstErrors.Items.Add(message);


        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
            string message = "Reduce: " + args.Token.ToString() + "\r\n\r\n";
            //lstTree.AppendText(message);
            args.Continue = true;
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '" + args.Token.ToString() + "' in line : " + args.Token.Location.LineNr;
            lstErrors.Items.Add(message);
            args.Continue = true;
            //Disable C parsing
            parsingStatus = false;
            c_code.Text = "";
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Syntax Error: '" + args.UnexpectedToken.ToString() + "' in line : " + args.UnexpectedToken.Location.LineNr;
            lstErrors.Items.Add(message);
            string message2 = "Expected Token : '" + args.ExpectedTokens.ToString() + "'";
            lstErrors.Items.Add(message2);
            //Continue to parse the rest
            args.Continue = ContinueMode.Stop;
            //Disable C parsing
            parsingStatus = false;
            c_code.Text = "";
        }

        //Check If String contains only numbers
        private static bool isStringDigitsOnly(string str)
        {
            return str.All(c => c >= '0' && c <= '9') && !string.IsNullOrEmpty(str);
        }
        //Checks If Variable Exists
        private bool variableExists(string variableName)
        {
            if (String.Equals(getVariableType(variableName), ""))
                return false;
            else
                return true;
        }
        //returns "" if variable does not exist. If exists variable, returns its type
        private string getVariableType(string variableName)
        {
            string resp = "";
            foreach (string ptr in declaredVariables)
            {
                if (String.Equals(variableName, ptr.ToString().Split(' ')[0]))
                {
                    resp = ptr.ToString().Split(' ')[1];
                    break;
                }
            }
            return resp;
        }
    }
}
