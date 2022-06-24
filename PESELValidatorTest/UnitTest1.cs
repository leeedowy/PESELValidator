using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PESELValidator;

namespace PESELValidatorTest
{
    [TestClass]
    public class PeselWalidatorTest
    {
        PESELWalidator walidator;

        [TestInitialize]
        public void PrzygotujWalidator()
        {
            walidator = new PESELWalidator();
        }

        [TestMethod]
        public void TestCzyWalidatorObliczaPoprawnaSumaKontrolna()
        {
            walidator.WczytajPesel("90012617859");
            int result = walidator.SumaKontrolna();
            Assert.AreEqual(131, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCzyWalidatorSprawdzaNumer_Bledny()
        {
            walidator.WczytajPesel("092857538479238475");
            bool wrong = walidator.SprawdzPesel();
            Assert.IsFalse(wrong);
        }

        [TestMethod]
        public void TestCzyWalidatorSprawdzaNumer_Poprawny()
        {
            walidator.WczytajPesel("65091994896");
            bool correct = walidator.SprawdzPesel();
            Assert.IsTrue(correct);
        }

        [TestMethod]
        public void TestCzyWalidatorZwracaPoprawnaDateUrodzenia_XXIWiek()
        {
            walidator.WczytajPesel("19213164425");
            bool correct = walidator.SprawdzPesel();
            Assert.IsTrue(correct);
            string dob = walidator.DataUrodzenia();
            Assert.AreEqual("2019-01-31", dob);
        }

        [TestMethod]
        public void TestCzyWalidatorZwracaPoprawnaDateUrodzenia_XXWiek()
        {
            walidator.WczytajPesel("06090275117");
            bool correct = walidator.SprawdzPesel();
            Assert.IsTrue(correct);
            string dob = walidator.DataUrodzenia();
            Assert.AreEqual("1906-09-02", dob);
        }

        [TestMethod]
        public void TestCzyWalidatorZwracaPoprawnaPlec_Meska()
        {
            walidator.WczytajPesel("88080453699");
            bool correct = walidator.SprawdzPesel();
            Assert.IsTrue(correct);
            string sex = walidator.Plec();
            Assert.AreEqual("m", sex);
        }

        [TestMethod]
        public void TestCzyWalidatorZwracaPoprawnaPlec_Zenska()
        {
            walidator.WczytajPesel("70030738422");
            bool correct = walidator.SprawdzPesel();
            Assert.IsTrue(correct);
            string sex = walidator.Plec();
            Assert.AreEqual("k", sex);
        }
    }
}
