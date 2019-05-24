using FluentAssertions;
using ITI.Tokenizer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleUnitTests
{
    [TestFixture]
    public class TokenizerTests
    {
        [Test]
        public void simple_tokens()
        {
            StringTokenizer t = new StringTokenizer( "2 + 96" );
            t.Match( TokenType.None ).Should().BeTrue();
            t.MatchInteger( out var i ).Should().BeTrue(); i.Should().Be( 2 );
            t.Match( TokenType.Plus ).Should().BeTrue();
            t.MatchInteger( out i ).Should().BeTrue(); i.Should().Be( 96 );
        }

        [TestCase( ",::;", "Comma,DoubleColon,SemiColon" )]
        [TestCase( ",,[", "Comma,Comma,OpenSquare" )]
        [TestCase( ":::", "DoubleColon,Colon" )]
        [TestCase( "4,8,32", "Number,Comma,Number,Comma,Number" )]
        public void terminals( string toParse, string expected )
        {
            StringTokenizer.Parse( toParse )
                    .SequenceEqual( expected.Split( ',' ).Select( Enum.Parse<TokenType> ) )
                    .Should().BeTrue();
        }

    }
}
