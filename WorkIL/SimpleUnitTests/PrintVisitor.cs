using ITI.Analyzer;
using ITI.Tokenizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleUnitTests
{
    public class PrintVisitor : NodeVisitor
    {
        StringBuilder _buffer = new StringBuilder();

        public string Result => _buffer.ToString();

        public override void Visit( BinaryNode n )
        {
            _buffer.Append( '(' );
            VisitNode( n.Left );
            _buffer.Append( ' ' );
            switch( n.Type )
            {
                case TokenType.Div: _buffer.Append( '/' ); break;
                case TokenType.Minus: _buffer.Append( '-' ); break;
                case TokenType.Plus: _buffer.Append( '+' ); break;
                case TokenType.Mult: _buffer.Append( '*' ); break;
                default: throw new NotSupportedException();
            }
            _buffer.Append( ' ' );
            VisitNode( n.Right );
            _buffer.Append( ')' );
        }

        public override void Visit( ConstantNode n )
        {
            _buffer.Append( n.Value );
        }

        public override void Visit( IdentifierNode n )
        {
            _buffer.Append( n.Identifier );
        }

        public override void Visit( IfNode n )
        {
            _buffer.Append( " (" );
            VisitNode( n.Condition );
            _buffer.Append( " ? " );
            VisitNode( n.WhenTrue );
            _buffer.Append( " : " );
            VisitNode( n.WhenFalse );
            _buffer.Append( ") " );
        }

        public override void Visit( UnaryNode n )
        {
            _buffer.Append( '(' );
            switch( n.Type )
            {
                case TokenType.Minus: _buffer.Append( '-' ); break;
                case TokenType.Plus: _buffer.Append( '+' ); break;
                default: throw new NotSupportedException();
            }
            VisitNode( n.Operand );
            _buffer.Append( ')' );
        }

        public override string ToString() => _buffer.ToString();

    }
}
