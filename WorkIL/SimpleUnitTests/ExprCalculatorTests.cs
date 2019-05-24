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
        public void test_calculator( string expression, double expected )
        {
            ExprCalculator.Compute( expression ).Should().Be( expected );
        }
    }
}
