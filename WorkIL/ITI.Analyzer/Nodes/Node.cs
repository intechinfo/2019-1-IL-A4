using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Analyzer
{
    public abstract class Node
    {

        internal abstract void Accept( NodeVisitor v );

        internal abstract Node Accept( MutationVisitor v ); 
    }
}
