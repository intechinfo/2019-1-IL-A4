using ITI.Tokenizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Analyzer
{
    public class IfNode : Node
    {
        public IfNode( Node condition, Node whenTrue, Node whenFalse )
        {
            Condition = condition ?? throw new ArgumentNullException( nameof( condition ) );
            WhenTrue = whenTrue ?? throw new ArgumentNullException( nameof( whenTrue ) );
            WhenFalse = whenFalse ?? throw new ArgumentNullException( nameof( whenFalse) );
        }

        public Node Condition { get; }

        public Node WhenTrue { get; }

        public Node WhenFalse { get; }

        public override string ToString() => $"({Condition} ? {WhenTrue} : {WhenFalse})";

        internal override void Accept( NodeVisitor v ) => v.Visit( this );

        internal override Node Accept( MutationVisitor v ) => v.Visit( this );

    }
}
