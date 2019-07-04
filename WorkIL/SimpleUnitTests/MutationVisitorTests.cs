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

        [TestCase( "1 + 2 + x", "(3 + x)" )]
        [TestCase( "x + 1 + 2", "(x + 3)" )]
        [TestCase( "10 + 4 - 7 * (3 + 5)", "-42" )]
        [TestCase( "x - -4", "(x + 4)" )]
        [TestCase( "x - -(1 + y)", "(x + (1 + y))" )]
        [TestCase( "50 + 6 + x / x", "57" )]
        [TestCase( "(10 + 2 + x + y) / (12 + x + y)", "1" )]
        public void optimizer_in_action( string input, string optimPrint )
        {
            var n = new SimpleAnalyzer().Parse( input );

            var optim = new OptimizationVisitor().VisitNode( n );

            var printer = new PrintVisitor();
            printer.VisitNode( optim );
            printer.ToString().Should().Be( optimPrint );
        }


    }

}

