using Microsoft.VisualStudio.TestTools.UnitTesting;
using HFC_Comic_LINQ;
using System.Collections.Generic;
using System.Linq;

namespace HFC_Comic_UnitTests
{
    [TestClass]
    public class ComicAnalyserTests
    {
        IEnumerable<Comic> testComics = new[]
        {
            new Comic(){ Issue = 1, Name = "Issue One"},
            new Comic(){ Issue = 2, Name = "Issue Two"},
            new Comic(){ Issue = 3, Name = "Issue Three"},
        };




        [TestMethod]
        public void ComicAnalyser_Should_Group_Comics()
        {
            var prices = new Dictionary<int, decimal>()
            {
                {1, 20m },
                {2, 10m },
                {3, 1000m },
            };

            var groups = ComicAnalyser.GroupComicsByPrice(testComics, prices);

            Assert.AreEqual(2, groups.Count());
            Assert.AreEqual(PriceRange.Cheap, groups.First().Key);
            Assert.AreEqual(2, groups.First().First().Issue);
            Assert.AreEqual("Issue Two", groups.First().First().Name);

        }
    }
}
