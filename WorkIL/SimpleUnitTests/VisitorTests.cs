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
        [TestCase( "3*x+78", 987, 3.0 * 987 + 78 )]
        [TestCase( "3*(x-4/x)+(x*7)", 78, 3.0 * (78.0 - 4 / 78.0) + (78.0 * 7) )]
        public void with_x_variable( string toParse, double x, double expected )
        {
            var n = new SimpleAnalyzer().Parse( toParse );
            var v = new ComputeVisitor( name => name == "x"
                                                    ? (double?)x
                                                    : null );
            v.VisitNode( n );
            v.Result.Should().Be( expected );
        }

        [Test]
        public void print_visitor_in_action()
        {
            var n = new SimpleAnalyzer().Parse( "3+7-4+1?8:9" );
            var v = new PrintVisitor();
            v.VisitNode( n );
            v.Result.Should().Be( " ((((3 + 7) - 4) + 1) ? 8 : 9) " );
        }

        [Test]
        public void compute_visitor_in_action()
        {
            {
                var n = new SimpleAnalyzer().Parse( "3" );
                var v = new ComputeVisitor();
                v.VisitNode( n );
                v.Result.Should().Be( 3.0 );
            }
            {
                var n = new SimpleAnalyzer().Parse( "3+3" );
                var v = new ComputeVisitor();
                v.VisitNode( n );
                v.Result.Should().Be( 6.0 );
            }
            {
                var n = new SimpleAnalyzer().Parse( "3+3*9-1+3+7-4+1?8:9+3+3*9" );
                var v = new ComputeVisitor();
                v.VisitNode( n );
                v.Result.Should().Be( (3 + 3 * 9 - 1 + 3 + 7 - 4 + 1) > 0 ? 8 : 9 + 3 + 3 * 9 );
            }
        }


    }
}
