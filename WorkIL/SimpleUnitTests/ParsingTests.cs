using FluentAssertions;
using ITI.Analyzer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleUnitTests
{
    public class ParsingTests
    {
        [TestCase( "3+5", "(Plus 3 5)" )]
        [TestCase( "3-5+2", "(Plus (Minus 3 5) 2)" )]
        [TestCase( "3+-5-4", "(Minus (Plus 3 (Minus 5)) 4)" )]
        public void parsing_simple_expression( string toParse, string toString )
        {
            var a = new SimpleAnalyzer();
            a.Parse( toParse ).ToString().Should().Be( toString );
        }
    }
}
