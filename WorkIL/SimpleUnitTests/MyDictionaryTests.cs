using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using ITI.Collections;

namespace SimpleUnitTests
{
    public class MyDictionaryTests
    {
        [Test]
        public void simple_dictionary()
        {
            var d = new MyDictionary<int, string>();
            // Assert.That( d.Count == 0 );
            // Assert.That( d.Count, Is.EqualTo( 0 ) );
            d.Count.Should().Be( 0 );
            d.Add( 3, "Three" );
            d[4] = "Four";

            d.Invoking( x => x.Add( 4, "Four bis" ) )
               .Should().Throw<Exception>();

            d.Invoking( x => d[3] = "Three bis" )
               .Should().NotThrow();

        }
    }
}
