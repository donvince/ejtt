using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Interview
{
    [TestFixture]
    public class Tests
    {
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

        [Test]
        public void TestMissingItemFindById()
        {
            IRepository<DataItem> repo = new InMemoryRepository<DataItem>();
            var result = repo.FindById(5);
            Assert.IsNull(result, "Assumed behaviour of returning (null) in case of item not found not evident.");
        }

        [Test]
        [ExpectedException(
            ExpectedException = typeof(KeyNotFoundException), 
            UserMessage = "Assumed behaviour of throwing an exception in case of item not found not evident.")]
        public void TestDeleteNonExistentItem()
        {
            IRepository<DataItem> repo = new InMemoryRepository<DataItem>();
            repo.Delete(6);
        }
    }
}