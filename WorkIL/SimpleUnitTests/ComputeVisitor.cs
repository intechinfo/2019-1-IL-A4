using ITI.Analyzer;
using ITI.Tokenizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleUnitTests
{
    public class ComputeVisitor : NodeVisitor
    {
        double _result = 3712;

        public double Result => _result;

        public override void Visit( ConstantNode n )
        {
            _result = n.Value;
        }

        public override void Visit( ErrorNode n )
        {
            _result = double.NaN;
        }

        public override void Visit( BinaryNode n )
        {
            VisitNode( n.Left );
            var left = _result;
            VisitNode( n.Right );
            switch( n.Type )
            {
                case TokenType.Div: _result = left / _result; break;
                case TokenType.Minus: _result = left - _result; break;
                case TokenType.Plus: _result = left + _result; break;
                case TokenType.Mult: _result = left * _result; ; break;
                default: throw new NotSupportedException();
            }
        }


        public override void Visit( UnaryNode n )
        {
            VisitNode( n.Operand );
            switch( n.Type )
            {
                case TokenType.Minus: _result = -_result; break;
                case TokenType.Plus: break;
                default: throw new NotSupportedException();
            }
        }

        public override void Visit( IfNode n )
        {
            VisitNode( n.Condition );
            if( _result > 0 ) VisitNode( n.WhenTrue );
            else VisitNode( n.WhenFalse );
        }

    }
}
