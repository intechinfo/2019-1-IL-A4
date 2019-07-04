using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Analyzer
{
    public class IdentifierNode : Node
    {
        public IdentifierNode( string identifier )
        {
            Identifier = identifier;
        }

        public string Identifier { get; }

        public override string ToString() => Identifier;

        internal override void Accept( NodeVisitor v ) => v.Visit( this );

         internal override Node Accept( MutationVisitor v ) => v.Visit( this );
   }
}
