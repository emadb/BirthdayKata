using System;
using System.Collections;
using DotNetLombardia.BirthdayKata;
using NUnit.Framework;

namespace BirthdayKata.Tests
{
    [TestFixture]
    public class BirthdayCheckerFixture
    {
        private BirthdayChecker bc;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            bc = new BirthdayChecker();
        }


        [Test]
        public void Verify_IsHerBirthday_ShouldReturnTrue()
        {
            DateTime today = DateTime.Today;
            //Act 
            var result = bc.Verify(today.Month, today.Day);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Verify_IsNotHerBirthday_ShouldReturnFalse()
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);

            //Act 
            var result = bc.Verify(yesterday.Month, yesterday.Day);

            // Assert
            Assert.IsFalse(result);
        } 
    }
}