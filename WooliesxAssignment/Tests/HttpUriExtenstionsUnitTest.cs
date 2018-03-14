using System;
using System.Configuration;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WooliesxAssignment.Extensions;
using WooliesxAssignment.Helpers;
using WooliesxAssignment.Models;

namespace Tests
{
    [TestFixture]
    public class HttpUriExtensionsUnitTest
    {
        [Test]
        public void
            AddQuery_AddValidQuery_Success
            ()
        {
            var result=new Uri("http://example.com/Add").AddQuery("token", "abcd");
            Assert.AreEqual(new Uri("http://example.com/Add?token=abcd"),result);
        }

        [Test]
        public void
            AddQuery_AddQueryNullName_ThrowsArgumentNullException
            ()
        {
            Assert.Throws<ArgumentNullException>(() => new Uri("http://example.com/Add").AddQuery(null, "abcd"));
        }

    }
}
