using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsApp.Facade;
using HotelsApp.ViewModel;

namespace HotelsApp.Handler
{
    public class HotelHandler
    {
        private HotelViewModel hotelViewModel { get; set; }
        public HotelHandler(HotelViewModel hotelViewModel)
        {
            this.hotelViewModel = hotelViewModel;
        }

        /// <summary>
        /// method that will create a new hotel by calling the facade layer
        /// </summary>
        public void CreateHotel()
        {

            new HotelFacade().CreateHotel(hotelViewModel.MyNewHotel);
            var hotels = HotelFacade.GetHotels();

        }

    }
}
