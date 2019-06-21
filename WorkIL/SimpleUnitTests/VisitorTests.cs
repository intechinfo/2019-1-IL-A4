using FluentAssertions;
using ITI.Analyzer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleUnitTests
{
    public class VisitorTests
    {
        [Test]
        public void print_visitor_in_action()
        {
            var n = new SimpleAnalyzer().Parse( "3+7-4+1?8:9" );
            var v = new PrintVisitor();
            v.VisitNode( n );
            v.Result.Should().Be( " ((((3 + 7) - 4) + 1) ? 8 : 9) " );
        }
    }
}
