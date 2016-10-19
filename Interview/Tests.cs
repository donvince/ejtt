using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Interview
{
    [TestFixture]
    public class Tests
    {
        private IRepository<DataItem> repo;

        [SetUp]
        public void SetUp()
        {
            repo = new InMemoryRepository<DataItem>();
        }
        
        [Test]
        public void TestFindById()
        {
            var dataItem = new DataItem(id: 2) { Name = "TestFindById" };
            repo.Save(dataItem);
            var result = repo.FindById(dataItem.Id);
            Assert.AreEqual(dataItem, result);
        }

        [Test]
        public void TestDelete()
        {
            var dataItem = new DataItem(id: 3) { Name = "TestDelete" };
            repo.Save(dataItem);
            repo.Delete(dataItem.Id);
        }

        [Test]
        public void TestAllWithOneItem()
        {
            var dataItem = new DataItem(id: 4) { Name = "TestAll" };
            repo.Save(dataItem);
            var result = repo.All();
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void TestAllWithZeroItems()
        {
            var result = repo.All();
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void TestMissingItemFindById()
        {
            var result = repo.FindById(5);
            Assert.IsNull(result, "Assumed behaviour of returning (null) in case of item not found not evident.");
        }

        [Test]
        [ExpectedException(
            ExpectedException = typeof(KeyNotFoundException),
            UserMessage = "Assumed behaviour of throwing an exception in case of item not found not evident.")]
        public void TestDeleteNonExistentItem()
        {
            repo.Delete(6);
        }

        [Test]
        public void TestMultipleEntries()
        {
            var dataItem1 = new DataItem(id: 1) { Name = "TestMultipleEntries(1)" };
            var dataItem2 = new DataItem(id: "1") { Name = "TestMultipleEntries('1')" };
            var dataItem3 = new DataItem(id: "One") { Name = "TestMultipleEntries(One)" };
            var dataItem4 = new DataItem(id: "Two") { Name = "TestMultipleEntries(Two)" };

            repo.Save(dataItem1);
            repo.Save(dataItem2);
            repo.Save(dataItem3);
            repo.Save(dataItem4);

            var result1 = repo.FindById(dataItem1.Id);
            Assert.AreEqual(dataItem1, result1);
            var result2 = repo.FindById(dataItem2.Id);
            Assert.AreEqual(dataItem2, result2);
            var result3 = repo.FindById(dataItem3.Id);
            Assert.AreEqual(dataItem3, result3);
            var result4 = repo.FindById(dataItem4.Id);
            Assert.AreEqual(dataItem4, result4);
        }

        [Test]
        public void TestUpdate()
        {
            var dataItem1 = new DataItem(id: 7) { Name = "TestUpdate(Before)" };
            var dataItem2 = new DataItem(id: 7) { Name = "TestUpdate(After)" };
            repo.Save(dataItem1);
            repo.Save(dataItem2);
            var result = repo.FindById(7);
            Assert.AreEqual(dataItem2, result);
        }

        [Test]
        public void TestMutateItemAfterSaving()
        {
            var dataItem = new DataItem(id: 8) { Name = "TestMutateItemAfterSaving(Before)" };
            repo.Save(dataItem);
            dataItem.Name = "TestMutateItemAfterSaving(After)";
            var result = repo.FindById(dataItem.Id);
            Assert.AreEqual(dataItem, result);
        }
    }
}