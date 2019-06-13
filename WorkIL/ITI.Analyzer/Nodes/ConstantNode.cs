using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Analyzer
{
    public class ConstantNode : Node
    {
        public ConstantNode( double value )
        {
            Value = value;
        }

        public double Value { get; }

        public override string ToString() => Value.ToString();
    }
}
