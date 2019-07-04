using ITI.Analyzer;
using ITI.Tokenizer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SimpleUnitTests
{
    class OptimizationVisitor : MutationVisitor
    {
        public override Node Visit( UnaryNode n )
        {
            Debug.Assert( n.Type == TokenType.Minus );

            var oV = VisitNode( n.Operand );
            if( oV is ConstantNode cN )
            {
                return new ConstantNode( -cN.Value );
            }
            return oV == n.Operand ? n : new UnaryNode( n.Type, oV );
        }

        public override Node Visit( BinaryNode n )
        {
            var lV = VisitNode( n.Left );
            var rV = VisitNode( n.Right );

            ConstantNode rC = rV as ConstantNode;
            ConstantNode lC = lV as ConstantNode;

            if( rC != null && lC != null )
            {
                switch( n.Type )
                {
                    case TokenType.Div: return new ConstantNode( lC.Value / rC.Value );
                    case TokenType.Minus: return new ConstantNode( lC.Value - rC.Value );
                    case TokenType.Plus: return new ConstantNode( lC.Value + rC.Value );
                    case TokenType.Mult: return new ConstantNode( lC.Value * rC.Value );
                    default: throw new NotSupportedException();
                }
            }
            if( n.Type == TokenType.Minus )
            {
                if( rV is UnaryNode rMV )
                {
                    return new BinaryNode( TokenType.Plus, lV, rMV.Operand );
                }
                if( rC != null )
                {
                    return new BinaryNode( TokenType.Plus, lV, new ConstantNode( -rC.Value ) );
                }
            }
            if( n.Type == TokenType.Div )
            {
                if( lV.ToString() == rV.ToString() ) return new ConstantNode( 1.0 );
            }
            return lV == n.Left && rV == n.Right ? n : new BinaryNode( n.Type, lV, rV );
        }

        public override Node Visit( IfNode n )
        {
            var cV = VisitNode( n.Condition );
            var tV = VisitNode( n.WhenTrue );
            var fV = n.WhenFalse != null ? VisitNode( n.WhenFalse ) : null;

            if( cV is ConstantNode cVC )
            {
                return cVC.Value > 0 ? tV : fV; 
            }
            return cV == n.Condition && tV == n.WhenTrue && fV == n.WhenFalse
                        ? n
                        : new IfNode( cV, tV, fV );
        }

    }
}
