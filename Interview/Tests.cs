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
            var dataItem = new DataItem(id: 2) { Name = "TestFindById" };
            repo.Save(dataItem);
            var result = repo.FindById(2);
            Assert.AreEqual(dataItem, result);
        }

        [Test]
        public void TestDelete()
        {
            IRepository<DataItem> repo = new InMemoryRepository<DataItem>();
            var dataItem = new DataItem(id: 3) { Name = "TestDelete" };
            repo.Save(dataItem);
            repo.Delete(dataItem.Id);
        }

        [Test]
        public void TestAll()
        {
            IRepository<DataItem> repo = new InMemoryRepository<DataItem>();
            var dataItem = new DataItem(id: 4) { Name = "TestAll" };
            repo.Save(dataItem);
            var result = repo.All();
            Assert.AreEqual(1, result.Count());
        }
    }
}