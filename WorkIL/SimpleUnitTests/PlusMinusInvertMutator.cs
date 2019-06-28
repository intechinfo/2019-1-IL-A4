using ITI.Analyzer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleUnitTests
{
    public class PlusMinusInvertMutator : MutationVisitor
    {
        public override Node Visit( BinaryNode n )
        {
            if( n.Type == ITI.Tokenizer.TokenType.Minus )
            {
                return new BinaryNode( ITI.Tokenizer.TokenType.Plus, VisitNode( n.Left ), VisitNode( n.Right ) );
            }
            if( n.Type == ITI.Tokenizer.TokenType.Plus )
            {
                return new BinaryNode( ITI.Tokenizer.TokenType.Minus, VisitNode( n.Left ), VisitNode( n.Right ) );
            }
            return base.Visit( n );
        }

        public override Node Visit( UnaryNode n )
        {
            if( n.Type == ITI.Tokenizer.TokenType.Minus )
            {
                return n.Operand;
            }
            if( n.Type == ITI.Tokenizer.TokenType.Plus )
            {
                return new UnaryNode( ITI.Tokenizer.TokenType.Minus, VisitNode( n.Operand ) );
            }
            return base.Visit( n );
        }
    }
}
