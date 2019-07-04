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
        readonly Func<string, double?> _variables;

        public ComputeVisitor()
            : this( name => null )
        {
        }

        public ComputeVisitor( Dictionary<string, double> variables )
            : this( name => variables.TryGetValue( name, out var v )
                                    ? (double?)v
                                    : null )
        {
        }

        public ComputeVisitor( Func<string, double?> variables )
        {
            _variables = variables;
        }

        public double Result => _result;

        public override void Visit( ConstantNode n )
        {
            _result = n.Value;
        }

        public override void Visit( IdentifierNode n )
        {
            double? val = _variables( n.Identifier );
            if( val == null ) _result = Double.NaN;
            else _result = val.Value;
            base.Visit( n );
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
