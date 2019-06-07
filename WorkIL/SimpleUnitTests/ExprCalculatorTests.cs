using FluentAssertions;
using ITI.Tokenizer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleUnitTests
{
    [TestFixture]
    public class ExprCalculatorTests
    {
        [TestCase( "3*5", 3.0 * 5 )]
        [TestCase( "3+5", 3.0 + 5 )]
        [TestCase( " 3  *  (  2  +  2  )  ", 3.0 * (2+2) )]
        [TestCase( "3 + 5 * 125 / 7 - 6 + 10", 3.0 + 5 * 125 / 7.0 - 6 + 10 )]
        [TestCase( "7 - 6 + 10", 7.0 - 6 + 10 )]
        [TestCase( "7 * -(5+2*3)", 7.0 * -(5 + 2 * 3.0) )]
        public void test_calculator( string expression, double expected )
        {
            ExprCalculator.Compute( expression ).Should().Be( expected );
        }
    }
}
