//using ITI.Tokenizer;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ITI.Analyzer
//{
//    public class WhileNode : Node
//    {
//        public WhileNode( Node condition, Node block )
//        {
//            Condition = condition;
//            Block = block;
//        }

//        public Node Condition { get; }

//        public Node Block { get; }

//        public override string ToString() => $"while({Condition}° {{{Block}}})";

//        internal override void Accept( NodeVisitor v ) => v.Visit( this );
//    }
//}
