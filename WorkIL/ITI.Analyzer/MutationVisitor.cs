using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Analyzer
{
    public abstract class MutationVisitor
    {
        public Node VisitNode( Node n ) => n.Accept( this );

        public virtual Node Visit( BinaryNode n )
        {
            var lV = VisitNode( n.Left );
            var rV = VisitNode( n.Right );
            return lV == n.Left && rV == n.Right ? n : new BinaryNode( n.Type, lV, rV );
        }

        public virtual Node Visit( ConstantNode n )
        {
            return n;
        }

        public virtual Node Visit( ErrorNode n )
        {
            return n;
        }

        public virtual Node Visit( IfNode n )
        {
            var cV = VisitNode( n.Condition );
            var tV = VisitNode( n.WhenTrue );
            var fV = n.WhenFalse != null ? VisitNode( n.WhenFalse ) : null;
            return cV == n.Condition && tV == n.WhenTrue && fV == n.WhenFalse
                        ? n
                        : new IfNode( cV, tV, fV );
        }

        public virtual Node Visit( UnaryNode n )
        {
            var oV = VisitNode( n.Operand );
            return oV == n.Operand ? n : new UnaryNode( n.Type, oV );
        }

    }
}
