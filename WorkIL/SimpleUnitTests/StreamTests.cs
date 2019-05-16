using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using System.Runtime.CompilerServices;
using System.Text;

namespace SimpleUnitTests
{
    [TestFixture]
    public class StreamTests
    {
        static string ThisFilePath( [CallerFilePath]string p = null ) => p;

        [Test]
        public void copying_stream_to_stream()
        {
            var origin = ThisFilePath();
            var target = origin + ".bak";

            CopyFile( origin, target );

            File.ReadAllBytes( origin )
                .SequenceEqual( File.ReadAllBytes( target ) )
                .Should().BeTrue();
        }

        void CopyFile( string origin, string target )
        {

        }
    }
}
