using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_InMemory_UnitTests 
    {
        private User _user;
        private UserAdapter _harness = new UserAdapter(new InMemory());
        private readonly string _email = "foobar@example.com";

        [TestInitialize]
        public void Setup()
        {
            _user = new User(_email);
        }
        
        [TestCleanup]
        public void TearDown()
        {
            //User user = new User(_email);
            _harness.Remove(_user);
        }

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetUser()
        {
            //Arrange
            _user.RegisterDTTM = DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            //Act
            _harness.Add(_user);
            User actual = _harness.GetById(_user.Id);
            //Assert
            Assert.AreEqual(_user.Id, actual.Id);
        }

                [TestMethod]
        public void TestGetUserByID()
        {
            userAdapterHarness.Add(newUser);
            User expectedUser = userAdapterHarness.GetById(newUser.Id);
            Assert.AreEqual(newUser.Id, expectedUser.Id);
        }

        [TestMethod]
        public void TestGetUserByEmail()
        {
            userAdapterHarness.Add(newUser);
            Assert.AreEqual(newUser, userAdapterHarness.GetUserByEmail(userEmail));
        }

        [TestMethod]
        public void TestDelete()
        {
            userAdapterHarness.Add(newUser);
            userAdapterHarness.Delete(newUser);
            CollectionAssert.DoesNotContain((ArrayList)userAdapterHarness.GetAll(), newUser.Id);
        }

        [TestMethod]
        public void TestGetBlabsByUserEmail()
        {
            blabAdapterHarness.Add(newBlab);
            ArrayList listBlabs = (ArrayList)blabAdapterHarness.GetByEmail(newUser.Email);
            CollectionAssert.Contains(listBlabs, newBlab);
        }

        [TestMethod]
        public void TestUserUpdate()
        {
            //Arrange
            _user.RegisterDTTM = DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            string updatedEmail = "updatedEmail@test.com";
            _harness.Add(_user);
            //Act
            _user.ChangeEmail(updatedEmail);
            _harness.Update(_user);

            //Assert
            Assert.AreEqual(_user.Email, updatedEmail);
        }
        
        [TestMethod]
        public void TestAddAndGetAll()
        {
            //Arrange
            _user.RegisterDTTM = DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            _harness.Add(_user);
            //Act
            ArrayList users = (ArrayList)_harness.GetAll();
            User actual = (User)users[0];

            //Assert
            Assert.AreEqual(_user.Id.ToString(), actual.Id.ToString());
        }
    }
}
