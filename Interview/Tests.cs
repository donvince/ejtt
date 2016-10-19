using System.Diagnostics;
using System.Linq;
using System;
using NUnit.Framework;
using Interview;

namespace Interview
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestSave()
        {
            IRepository<DataItem> repo = new InMemoryRepository<DataItem>();
            var dataItem = new DataItem(id: 1) { Name = "TestSave" };
            repo.Save(dataItem);
        }

        [Test]
        public void TestFindById()
        {
            IRepository<DataItem> repo = new InMemoryRepository<DataItem>();
            var dataItem = new DataItem(id: 1) { Name = "TestSave" };
            repo.Save(dataItem);
            var result = repo.FindById(1);
            Assert.AreEqual(dataItem, result);
        }
    }
}