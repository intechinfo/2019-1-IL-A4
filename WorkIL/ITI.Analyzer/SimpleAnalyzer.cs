using ITI.Tokenizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Analyzer
{
    public class SimpleAnalyzer
    {

        public Node Parse( string expression )
        {
            var t = new StringTokenizer( expression );
            // With this tokenizer, head must be forwarded at first.
            return t.GetNextToken() == TokenType.EndOfInput
                        ? null
                        : Parse( t );
        }

        public Node Parse( StringTokenizer t )
        {
            return new ErrorNode( "Not implemented :)" );
        }


    }
}
