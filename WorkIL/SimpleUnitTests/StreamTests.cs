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
            using( var o = new FileStream( origin, FileMode.Open, FileAccess.Read ) )
            using( var t = new FileStream( target, FileMode.Create, FileAccess.Write ) )
            {
                byte[] buffer = new byte[4096];
                int len;
                do
                {
                    len = o.Read( buffer, 0, buffer.Length );
                    t.Write( buffer, 0, len );
                }
                while( len == buffer.Length );
            }
        }


        [Test]
        public void krabouille_works()
        {
            var origin = ThisFilePath();
            var crypted = origin + ".krab";
            var restored = crypted + ".clear";

            DoKrabouille( origin, crypted, "Secret..." );

            File.ReadAllBytes( origin )
                .SequenceEqual( File.ReadAllBytes( crypted ) )
                .Should().BeFalse();

            DoUnkrabouille( crypted, restored, "Secret..." );

            File.ReadAllBytes( origin )
                .SequenceEqual( File.ReadAllBytes( restored ) )
                .Should().BeTrue();
        }

        [Test]
        public void krabouille_requires_the_passphrase()
        {
            var origin = ThisFilePath();
            var crypted = origin + ".krab";
            var failed = crypted + ".failed";

            DoKrabouille( origin, crypted, "Secret1" );

            File.ReadAllBytes( origin )
                .SequenceEqual( File.ReadAllBytes( crypted ) )
                .Should().BeFalse();

            DoUnkrabouille( crypted, failed, "Secret2" );

            File.ReadAllBytes( origin )
                .SequenceEqual( File.ReadAllBytes( failed ) )
                .Should().BeFalse();
        }


        void DoKrabouille( string origin, string crypted, string passPhrase )
        {
            throw new NotImplementedException();
        }

        void DoUnkrabouille( string crypted, string restored, string passPhrase )
        {
            throw new NotImplementedException();
        }
    }
}
