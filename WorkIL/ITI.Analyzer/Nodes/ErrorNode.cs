using ITI.Tokenizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Analyzer
{
    public class ErrorNode : Node
    {
        public ErrorNode( string message )
        {
            if( string.IsNullOrWhiteSpace( message ) )
            {
                throw new ArgumentNullException( nameof( message ) );
            }
            Message = message;
        }

        public string Message { get; }

        public override string ToString() => $"Error: {Message}";

        internal override void Accept( NodeVisitor v ) => v.Visit( this );

        internal override Node Accept( MutationVisitor v ) => v.Visit( this );
    }
}
