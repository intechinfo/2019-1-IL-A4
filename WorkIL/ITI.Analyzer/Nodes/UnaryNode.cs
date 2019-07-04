using ITI.Tokenizer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ITI.Analyzer
{
    public class UnaryNode : Node
    {
        public UnaryNode( TokenType type, Node operand )
        {
            Debug.Assert( type == TokenType.Minus );
            Type = type;
            Operand = operand ?? throw new ArgumentNullException( nameof( operand ) );
        }

        public TokenType Type { get; }

        public Node Operand { get; }

        public override string ToString() => $"({Type} {Operand})";

        internal override void Accept( NodeVisitor v ) => v.Visit( this );

        internal override Node Accept( MutationVisitor v ) => v.Visit( this );


    }
}
