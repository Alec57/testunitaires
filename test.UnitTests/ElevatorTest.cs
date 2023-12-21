using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.UnitTests
{
    [TestClass]
    public class ElevatorTests
    {
        [TestMethod]
        public void Constructor_SetsMaxWeightAllowed()
        {
            var elevator = new Elevator(500);
            Assert.AreEqual(500, elevator.MaxWeightAllowed);
        }

        [TestMethod]
        public void Constructor_SetsCurrentWeightToZero()
        {
            var elevator = new Elevator(500);
            Assert.AreEqual(0, elevator.CurrentWeight);
        }

        [TestMethod]
        public void InUser_IncreasesCurrentWeight()
        {
            var elevator = new Elevator(500);
            var user = new Employee { Weight = 70 };
            elevator.InUser(user);
            Assert.AreEqual(70, elevator.CurrentWeight);
        }

        [TestMethod]
        public void OutUser_DecreasesCurrentWeight()
        {
            var elevator = new Elevator(500);
            var user = new Employee { Weight = 70 };
            elevator.InUser(user);
            elevator.OutUser(user);
            Assert.AreEqual(0, elevator.CurrentWeight);
        }

        [TestMethod]
        public void OutUser_DoesNotSetNegativeWeight()
        {
            var elevator = new Elevator(500);
            var user = new Employee { Weight = 70 };
            elevator.OutUser(user);
            Assert.AreEqual(0, elevator.CurrentWeight);
        }

        [TestMethod]
        public void CheckMaxWeightAllowedReached_ReturnsTrueWhenLimitReached()
        {
            var elevator = new Elevator(100);
            var user = new Employee { Weight = 100 };
            elevator.InUser(user);
            Assert.IsTrue(elevator.CheckMaxWeightAllowedReached());
        }

        [TestMethod]
        public void CheckMaxWeightAllowedReached_ReturnsFalseWhenUnderLimit()
        {
            var elevator = new Elevator(100);
            var user = new Employee { Weight = 90 };
            elevator.InUser(user);
            Assert.IsFalse(elevator.CheckMaxWeightAllowedReached());
        }

        [TestMethod]
        public void GoToVipSection_ReturnsTrueForExecutiveWithNonZeroWeight()   
        {
            var elevator = new Elevator(500);
            var executive = new Employee { IsExecutive = true, Weight = 70 };
            elevator.InUser(executive);
            Assert.IsTrue(elevator.GoToVipSection(executive));
        }

        [TestMethod]
        public void GoToVipSection_ReturnsFalseForNonExecutive()
        {
            var elevator = new Elevator(500);
            var nonExecutive = new Employee { IsExecutive = false, Weight = 70 };
            elevator.InUser(nonExecutive);
            Assert.IsFalse(elevator.GoToVipSection(nonExecutive));
        }

        [TestMethod]
        public void GoToVipSection_ReturnsFalseForZeroWeight()
        {
            var elevator = new Elevator(500);
            var executive = new Employee { IsExecutive = true, Weight = 0 };
            Assert.IsFalse(elevator.GoToVipSection(executive));
        }
    }
}




