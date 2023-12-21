using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.UnitTests
{
    [TestClass]
    public class CalculatorTest
    {
            private Calculator _calculator;

            //Test initialize
            [TestInitialize]
            public void Init()
            {
                _calculator = new Calculator();
            }

            [TestMethod]
            [DataRow(1, 2, 3)]
            [DataRow(2, 2, 4)]
            [DataRow(3, 2, 5)]
            public void Addition_RetourneLaSommeDesArguments(int numberOne, int numberTwo, int expectedResult)
            {
                //Arrange
                //Act
                var result = _calculator.Add(numberOne, numberTwo);

                //Assert
                Assert.AreEqual(expectedResult, result);
            }

            [TestMethod]
            [DataRow(1, 2, -1)]
            [DataRow(2, 2, 0)]
            [DataRow(3, 2, 1)]
            public void Soustraction_RetourneLaSoustractionDesArguments(int numberOne, int numberTwo, int expectedResult)
            {
                var result = _calculator.Substract(numberOne, numberTwo);
                Assert.AreEqual(expectedResult, result);
            }

            [TestMethod]
            [DataRow(1, 2, 2)]
            [DataRow(2, 2, 4)]
            [DataRow(3, 2, 6)]
            public void Multiplication_RetourneLeProduitDesArguments(int numberOne, int numberTwo, int expectedResult)
            {
                var result = _calculator.Multiply(numberOne, numberTwo);

                Assert.AreEqual(expectedResult, result);
            }

            [TestMethod]
            [DataRow(1, 2, 0.5f)]
            [DataRow(2, 2, 1f)]
            [DataRow(3, 2, 1.5f)]
            public void Division_RetourneLeRésultatDeLaDivision(int numberOne, int numberTwo, float expectedResult)
            {
                var result = _calculator.Divide(numberOne, numberTwo);

                Assert.AreEqual(expectedResult, result);
            }

            [TestMethod]
            [DataRow(1, 0)]
            [DataRow(2, 0)]
            [DataRow(3, 0)]
            public void Division_AvecZéroCommeSecondArgument_LanceUneArgumentException(int numberOne, int numberTwo)
            {
                Assert.ThrowsException<ArgumentException>(() => _calculator.Divide(numberOne, numberTwo));
            }
        }
    }
