using ITI.Collections;
using NUnit.Framework;

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
    }
}
