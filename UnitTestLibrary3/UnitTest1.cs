using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelsApp.Facade;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestLibrary3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGetHotels()
        {
            var result = HotelFacade.GetHotels();
            var countBefore = result.Count;

            Assert.AreEqual(20,countBefore);
        }
        [TestMethod]
        public void TestPostNewHotel()
        {
            

        }

    }
}
