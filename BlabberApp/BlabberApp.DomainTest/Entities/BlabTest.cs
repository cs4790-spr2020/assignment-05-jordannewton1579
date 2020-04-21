using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BlabTest
    {       
        private Blab harness;
        public BlabTest() 
        {
            harness = new Blab();
        }

        [TestMethod]
        public void TestSetGetMessage()
        {
            // Arrange
            string expected = "This is some test"; 
            harness.Message = "This is some test";
            // Act
            string actual = harness.Message;
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestId()
        {
            // Arrange
            Guid expected = harness.Id;
            // Act
            Guid actual = harness.Id;
            // Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, harness.Id is Guid);
        }
        
        [TestMethod]
        public void TestDTTM()
        {
            // Arrange
            Blab Expected = new Blab();
            // Act
            Blab Actual = new Blab();
            // Assert
            Assert.AreEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }

        [TestMethod]
        public void TestSetGetUser()
        {
            // Arrange
            User user = new User();
            harness.User = user;
            // Act
            User actual = harness.User;
            User expected = user;
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestCreateBlabWithoutUser()
        {
            Blab newBlab = new Blab(message);
            Assert.AreEqual(message, newBlab.Message);
        }

        [TestMethod]
        public void TestDates()
        {  
            Blab actual = new Blab();
            Blab expected = new Blab();
            Assert.AreNotEqual(actual.DateTime, expected.DateTime);
        }
    }
}
