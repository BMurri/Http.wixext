// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolsetTest.Http
{
    using System.Linq;
    using WixBuildTools.TestSupport;
    using WixToolset.Core.TestPackage;
    using WixToolset.Http;
    using Xunit;

    public class HttpExtensionFixture
    {
        [Fact]
        public void CanBuildUsingUrlReservation()
        {
            var folder = TestData.Get(@"TestData\UsingUrlReservation");
            var build = new Builder(folder, typeof(HttpExtensionFactory), new[] { folder });

            var results = build.BuildAndQuery(Build, "WixHttpUrlAce", "WixHttpUrlReservation");
            Assert.Equal(new[]
            {
                "WixHttpUrlAce:aceu5os2gQoblRmzwjt85LQf997uD4\turlO23FkY2xzEY54lY6E6sXFW6glXc\tNT SERVICE\\TestService\t268435456",
                "WixHttpUrlReservation:urlO23FkY2xzEY54lY6E6sXFW6glXc\t0\t\thttp://+:80/vroot/\tfilF5_pLhBuF5b4N9XEo52g_hUM5Lo",
            }, results);
        }

        private static void Build(string[] args)
        {
            var result = WixRunner.Execute(args)
                                  .AssertSuccess();
        }
    }
}
