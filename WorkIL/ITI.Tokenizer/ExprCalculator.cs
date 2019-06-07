using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Tokenizer
{
    public static class ExprCalculator
    {
        public static double Compute( string expression )
        {
            var t = new StringTokenizer( expression );
            // With this tokenizer, head must be forwarded at first.
            return t.GetNextToken() == TokenType.EndOfInput ? 0.0 : ComputeExpression( t );
        }

        /// <summary>
        /// facteur → nombre  |  ‘(’  expression  ‘)’ 
        /// </summary>
        static double ComputeFactor( StringTokenizer t )
        {
            if( !t.MatchDouble( out var f ) )
            {
                if( !t.Match( TokenType.OpenPar ) ) throw new Exception( "Expected number or (." );
                f = ComputeExpression( t );
                if( !t.Match( TokenType.ClosePar ) ) throw new Exception( "Expected )." );
            }
            return f;
        }

        /// <summary>
        /// expression → terme  opérateur-additif  expression  |  terme 
        /// </summary>
        static double ComputeExpression( StringTokenizer t )
        {
            var expr = ComputeTerm( t );
            if( t.Match( TokenType.Plus ) ) expr += ComputeExpression( t );
            if( t.Match( TokenType.Minus ) ) expr -= ComputeExpression( t );
            return expr;
        }

        /// <summary>
        /// terme → facteur opérateur-multiplicatif  terme  |  facteur
        /// </summary>
        static double ComputeTerm( StringTokenizer t )
        {
            var fact = ComputeFactor( t );
            if( t.Match( TokenType.Mult ) ) fact *= ComputeTerm( t );
            if( t.Match( TokenType.Div ) ) fact /= ComputeTerm( t );
            return fact;
        }

    }
}
