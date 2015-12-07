using System;
using HotelsApp.Facade;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

           var facade = new HotelFacade();
            var result = HotelFacade.GetHotels();

            Assert.AreEqual(1,result.Count);
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void TestMethod2()
        {

            var facade = new HotelFacade();
            var result = HotelFacade.GetHotels();

            Assert.AreEqual(1, result.Count);
            Assert.IsFalse(true);
        }
    }
}
