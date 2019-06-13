using ITI.Tokenizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Analyzer
{
    public class UnaryNode : Node
    {
        public UnaryNode( TokenType type, Node operand )
        {
            Type = type;
            Operand = operand ?? throw new ArgumentNullException( nameof( operand ) );
        }

        public TokenType Type { get; }

        public Node Operand { get; }

        public override string ToString() => $"({Type} {Operand})";

    }
}
