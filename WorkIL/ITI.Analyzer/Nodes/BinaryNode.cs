using ITI.Tokenizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Analyzer
{
    public class BinaryNode : Node
    {
        public BinaryNode( TokenType type, Node left, Node right )
        {
            Type = type;
            Left = left ?? throw new ArgumentNullException( nameof( left ) );
            Right = right ?? throw new ArgumentNullException( nameof( right ) );
        }

        public TokenType Type { get; }

        public Node Left { get; }

        public Node Right { get; }
    }
}
