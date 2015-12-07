using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelsApp.Facade;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestLibrary2
{
    [TestClass]
    public class UnitTestFacade
    {
        [TestMethod]
        public void TestFacade()
        {



            var result = HotelFacade.GetHotels();
            var countBefore = result.Count;

            //var resultPost = new HotelFacade().Post( hotelobj)

            var resultafterPost = HotelFacade.GetHotels();
            var countAfter = result.Count;

            Assert.AreEqual(countBefore+1, countAfter);

            Assert.IsFalse(true);



        }
    }
}
