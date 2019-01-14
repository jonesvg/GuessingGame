using System;
using GuessingGame_Jones.Controlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessingGame_Test
{
    [TestClass]
    public class clsControlTest
    {
        private clsControl newControl;
        [TestMethod]
        public void GetQuestionByIndexTest()
        {
            newControl = new clsControl();

            string expected = "Live in water";

            clsQuestion result = newControl.GetQuestionByIndex(0);

            Assert.AreEqual(result.Characteristic, expected, "The questions are no Equals");
        }

        [TestMethod]
        public void SetQuestionInRoot()
        {
            clsQuestion newQuestion = new clsQuestion("Touro", "Tem Chifre", false);

            newControl = new clsControl();

            newControl.PlaceQuestionInRoot(newQuestion);

            string expected = "Monkey";

            clsQuestion result = newControl.GetQuestionByIndex(newControl.lstRootQuestion.Count - 1);

            Assert.AreEqual(result.AnimalName, expected, "The questions are no Equals");

            expected = "Touro";
            result = newControl.GetQuestionByIndex(newControl.lstRootQuestion.Count - 2);

            Assert.AreEqual(result.AnimalName, expected, "The questions are no Equals");
        }

        [TestMethod]
        public void SawIfTheLastQuestionInRootIsMonkey()
        {
            newControl = new clsControl();

            string expected = "Monkey";

            clsQuestion result = newControl.GetQuestionByIndex(newControl.lstRootQuestion.Count - 1);

            Assert.AreEqual(result.AnimalName, expected, "The questions are no Equals");
        }
    }
}
