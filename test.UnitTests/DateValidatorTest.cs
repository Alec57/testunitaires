using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.UnitTests
{
    [TestClass]
    public class DateValidatorTests
    {
        // Tests pour CheckNumberOfDashes
        [TestMethod]
        public void CheckNumberOfDashes_WithCorrectInput_ShouldReturnTrue()
        {
            var dateValidator = new DateValidator("20-12-2023");
            Assert.IsTrue(dateValidator.CheckNumberOfDashes());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckNumberOfDashes_WithIncorrectInput_ShouldThrowException()
        {
            var dateValidator = new DateValidator("20--12--2023");
            dateValidator.CheckNumberOfDashes();
        }

        // Tests pour CheckAllNumbersAreIntegers
        [TestMethod]
        public void CheckAllNumbersAreIntegers_WithCorrectInput_ShouldReturnTrue()
        {
            var dateValidator = new DateValidator("20-12-2023");
            Assert.IsTrue(dateValidator.CheckAllNumbersAreIntegers());
        }

        [TestMethod]
        public void CheckAllNumbersAreIntegers_WithIncorrectInput_ShouldReturnFalse()
        {
            var dateValidator = new DateValidator("20-xx-2023");
            Assert.IsFalse(dateValidator.CheckAllNumbersAreIntegers());
        }

        // Test pour ThrowExceptionIfNumbersAreNotIntegers
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void ThrowExceptionIfNumbersAreNotIntegers_WithIncorrectInput_ShouldThrowException()
        {
            var dateValidator = new DateValidator("dd-mm-yyyy");
            dateValidator.ThrowExceptionIfNumbersAreNotIntegers();
        }
    }
}

