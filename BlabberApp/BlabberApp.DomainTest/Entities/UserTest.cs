using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestSetGetEmail_Success()
        {
            // Arrange
            User harness = new User(); 
            string expected = "foobar@example.com";
            harness.ChangeEmail("foobar@example.com");
            // Act
            string actual = harness.Email; // Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());
        }
        [TestMethod]
        public void TestSetGetEmail_Fail00()
        {
            // Arrange
            User harness = new User(); 
            var expected = "Foobar is invalid";
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("Foobar"));
            // Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }
        [TestMethod]
        public void TestSetGetEmail_Fail01()
        {
            // Arrange
            User harness = new User(); 
            var expected = "example.com is invalid";
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("example.com"));
            // Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }
        [TestMethod]
        public void TestSetGetEmail_Fail02()
        {
            // Arrange
            User harness = new User(); 
            var expected = "foobar.example is invalid";
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("foobar.example"));
            // Assert
            Assert.AreEqual(expected, ex.Message.ToString());
        }
        [TestMethod]
        public void TestId()
        {
            // Arrange
            User harness = new User();
            Guid expected = harness.Id;
            // Act
            Guid actual = harness.Id;
            // Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, harness.Id is Guid);
        }

        [TestMethod]
         public void TestChangeExistingUserEmail()
         {
             User _user = new User("foobar@example.com");
             string newEmail = "barfoo@example.com";
             _user.ChangeEmail(newEmail);
            Assert.AreEqual(newEmail, _user.Email);
         }

        [TestMethod]
        public void TestDates()
        {
            User _user1 = new User("foobar@example.com");
            User _user2 = new User("barfoo@example.com");
            Assert.AreNotEqual(_user1.RegisterDTTM, _user2.RegisterDTTM);
        } 
    }
}