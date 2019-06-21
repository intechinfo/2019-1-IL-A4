using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Analyzer
{
    public abstract class NodeVisitor
    {
        public void VisitNode( Node n ) => n.Accept( this );

        public virtual void Visit( BinaryNode n )
        {
            VisitNode( n.Left );
            VisitNode( n.Right );
        }

        public virtual void Visit( ConstantNode n )
        {
        }

        public virtual void Visit( ErrorNode n )
        {
        }

        public virtual void Visit( IfNode n )
        {
            VisitNode( n.Condition );
            VisitNode( n.WhenTrue );
            if( n.WhenFalse != null ) VisitNode( n.WhenFalse );
        }

        public virtual void Visit( UnaryNode n )
        {
            VisitNode( n.Operand );
        }

    }
}
