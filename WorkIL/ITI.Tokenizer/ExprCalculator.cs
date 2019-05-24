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
            return ComputeFactor( t );
        }

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

        static double ComputeExpression( StringTokenizer t )
        {
            throw new NotImplementedException();
        }
    }
}
