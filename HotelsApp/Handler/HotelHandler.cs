using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsApp.Facade;
using HotelsApp.Model;
using HotelsApp.ViewModel;
using JulMar.Core.Extensions;

namespace HotelsApp.Handler
{
    public class HotelHandler
    {
        private HotelViewModel hotelViewModel { get; }
        public HotelHandler(HotelViewModel hotelViewModel)
        {
            this.hotelViewModel = hotelViewModel;
        }

        /// <summary>
        /// method that will create a new hotel by calling the facade layer
        /// </summary>
        public async void CreateHotel()
        {
            await HotelFacade.CreateHotel(hotelViewModel.MyNewHotel);
            GetHotelsAsync();
            //List<Hotel> hotels = await HotelFacade.GetHotelsAsync();
            //hotelViewModel.HotelsList.Clear();
            //hotelViewModel.HotelsList.AddRange(hotels);
            hotelViewModel.MyNewHotel = new Hotel();
        }

        /// <summary>
        /// Get the Hotels from the Facade layer
        /// </summary>
        public async void GetHotelsAsync()
        {

            //for (int i = 0; i < 2000; i++)
            //{
                List<Hotel> hotels = await HotelFacade.GetHotelsAsync();
                hotelViewModel.HotelsList.Clear();
                hotelViewModel.HotelsList.AddRange(hotels);

            //}
        }


        public async void DeleteHotel()
        {
            await  HotelFacade.DeleteHotel(hotelViewModel.SelectedHotel);
            hotelViewModel.HotelsList.Remove(hotelViewModel.SelectedHotel);
        }

    }
}
