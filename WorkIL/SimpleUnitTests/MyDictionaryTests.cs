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
        public void simple_dictionary_add_and_indexer()
        {
            var d = new MyDictionary<int, string>();
            // Assert.That( d.Count == 0 );
            // Assert.That( d.Count, Is.EqualTo( 0 ) );
            d.Count.Should().Be( 0 );
            d.Add( 3, "Three" );
            d.Count.Should().Be( 1 );
            d[4] = "Four";
            d.Count.Should().Be( 2 );

            d.Invoking( x => x.Add( 4, "Four bis" ) )
               .Should().Throw<Exception>();

            d.Invoking( sut => Console.WriteLine( sut[3712] ) )
                .Should().Throw<KeyNotFoundException>();

            d.Invoking( x => d[3] = "Three bis" )
               .Should().NotThrow();

            d.Count.Should().Be( 2 );
        }

        [Test]
        public void simple_dictionary_add_and_remove()
        {
            var d = new MyDictionary<string, int>();
            d.Add( "One", 1 );
            d.Add( "Two", 2 );
            d.Add( "Three", 3 );
            d.Count.Should().Be( 3 );

            d.Remove( "Two" );
            d.Count.Should().Be( 1 );
            d.Invoking( sut => sut.Remove( "Two" ) )
                .Should().Throw<KeyNotFoundException>();
        }
    }
}
