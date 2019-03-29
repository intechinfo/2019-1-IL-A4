using ITI.Collections;
using NUnit.Framework;
using System;

namespace SimpleUnitTests
{
    public class MyListTests
    {
        [Test]
        public void one_can_append_a_lot_of_item_in_a_list()
        {
            // Arrange
            var sut = new MyList<int>();
            // Act
            for( int i = 0; i < 3712; ++i )
            {
                sut.Add( i );
            }
            // Assert
            for( int i = 0; i < 3712; ++i )
            {
                Assert.That( sut[i] == i );
            }
        }

        [Test]
        public void one_can_append_a_lot_of_item_in_a_list_with_ref()
        {
            // Arrange
            var sut = new MyList<string>();
            // Act
            for( int i = 0; i < 3712; ++i )
            {
                sut.Add( $"String n°{i}" );
            }
            // Assert
            for( int i = 0; i < 3712; ++i )
            {
                Assert.That( sut[i] == $"String n°{i}" );
            }
            sut.Clear();
            Assert.Throws<IndexOutOfRangeException>( () => Console.Write( sut[0] ) );
        }

        [Test]
        public void I_can_foreach_on_my_list()
        {
            var sut = new MyList<object>();
            sut.Add( 9 );
            sut.Add( "kilo" );
            sut.Add( 234.67 );

            foreach( var item in sut )
            {
                Assert.That( item.Equals( 9 ) || item.Equals( "kilo" ) || item.Equals( 234.67 ) );
            }

        }
    }
}
