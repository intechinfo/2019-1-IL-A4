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
            return ParseCondExpression( t );
        }

        Node ParseCondExpression( StringTokenizer t )
        {
            var condition = ParseExpression( t );
            if( t.Match( TokenType.QuestionMark ) )
            {
                var then = ParseCondExpression( t );
                if( !t.Match( TokenType.Colon ) )
                {
                    return new ErrorNode( "Expected : of ternary operator." );
                }
                var @else = ParseCondExpression( t );
                condition = new IfNode( condition, then, @else );
            }
            return condition;
        }

        Node ParseExpression( StringTokenizer t )
        {
            var expr = ParseTerm( t );
            while( t.CurrentToken == TokenType.Plus
                    || t.CurrentToken == TokenType.Minus )
            {
                expr = new BinaryNode( t.GetCurrentTypeAndForward(), expr, ParseTerm( t ) );
            }
            return expr;
        }

        Node ParseTerm( StringTokenizer t )
        {
            Node fact = ParseFactor( t );
            while( t.CurrentToken == TokenType.Mult
                    || t.CurrentToken == TokenType.Div )
            {
                fact = new BinaryNode( t.GetCurrentTypeAndForward(), fact, ParseFactor( t ) );
            }
            return fact;
        }

        Node ParseFactor( StringTokenizer t )
        {
            if( t.Match( TokenType.Minus ) )
            {
                return new UnaryNode( TokenType.Minus, ParsePositiveFactor( t ) );
            }
            return ParsePositiveFactor( t );
        }

        Node ParsePositiveFactor( StringTokenizer t )
        {
            if( t.MatchDouble( out var f ) ) return new ConstantNode( f );
            if( t.MatchIdentifier( out var id ) ) return new IdentifierNode( id );
            if( t.Match( TokenType.OpenPar ) )
            {
                Node expr = ParseCondExpression( t );
                if( !t.Match( TokenType.ClosePar ) ) return new ErrorNode( "Expected )." );
                return expr;
            }
            return new ErrorNode( "Expected ( or number." );
        }
    }
}
