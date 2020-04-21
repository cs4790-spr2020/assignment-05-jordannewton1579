using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_MySql_UnitTests
    {
        private BlabAdapter _harness;

        [TestInitialize]
        public void Setup()
        {
            _harness = new BlabAdapter(new MySqlBlab());
            _harness.RemoveAll();
        }
        [TestCleanup]
        public void TearDown()
        {
            _harness.RemoveAll();
        }

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetBlab()
        {
            //Arrange
            string email = "fooabar@example.com";
            User mockUser = new User(email);
            Blab blab = new Blab("Let the blabs begin...", mockUser);
            //Act
            _harness.Add(blab);
            ArrayList actual = (ArrayList)_harness.GetByUserId(email);
            //Assert
            Assert.AreEqual(1, actual.Count);
        }

                [TestMethod]
        public void TestUpdateBlab()
        {
            //Arrange
            Blab blab = new Blab("Now is the time for, blabs...", _user);
            string updatedMessage = "This is an updated blab...";
            //Act
            _harness.Add(blab);
            blab.Message = updatedMessage;
            _harness.Update(blab);
            _harness.GetById(blab.Id);
            //Assert
            Assert.AreEqual(updatedMessage, blab.Message);
            _harness.Remove(blab);
        }

                [TestMethod]
        public void TestAddGetById()
        {
            adapter.Add(newBlab);
            Blab actual = adapter.GetById(newBlab);
            Assert.AreEqual(newBlab.Id, actual.Id);
        }

        [TestMethod]
        public void TestAddAndReadAll()
        {
            adapter.Add(newBlab);
            var BlabList = (ArrayList)adapter.GetAll();
            foreach(Blab blab in BlabList){
                if(blab == newBlab)
                {
                    Assert.AreEqual(blab.Id, newBlab.Id);
                }
            }
        }

        [TestMethod]
        public void TestGetBlabsByEmail()
        {
            adapter.Add(newBlab);
            ArrayList blabList = (ArrayList)adapter.GetByEmail(userEmail);
            foreach(Blab blab in blabList)
            {
                if(blab == newBlab)
                {
                    Assert.AreEqual(blab.Id, newBlab.Id);
                }
            }
        }

        [TestMethod]
        public void TestEmptyGetAll()
        {
            //Arrange
            ArrayList blabs = (ArrayList)_harness.GetAll();
            //Act
            int expected = 0;
            int actual = blabs.Count;
            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}
