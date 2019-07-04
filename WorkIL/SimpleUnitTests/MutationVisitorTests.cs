using FluentAssertions;
using ITI.Analyzer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleUnitTests
{
    public class MutationVisitorTests
    {
        [TestCase( "3+7-(9*-12+3)", 3 - 7 + (-9 * -12 - 3) )]
        [TestCase( "3*x+12", Double.NaN )]
        public void PlusMinusInvertMutator_in_action( string input, double result )
        {
            var n = new SimpleAnalyzer().Parse( input );

            var mp = new PlusMinusInvertMutator();
            var nV = mp.VisitNode( n );

            var computer = new ComputeVisitor();
            computer.VisitNode( nV );
            computer.Result.Should().Be( result );
        }


    }

}

