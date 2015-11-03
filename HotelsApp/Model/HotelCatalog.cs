using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsApp.Facade;

namespace HotelsApp.Model
{
    public class HotelCatalog
    {
        private ObservableCollection<Hotel> _hotels;
        public ObservableCollection<Hotel> Hotels
        {
            get { return _hotels; }
            set { _hotels = value; }
        }

        public HotelCatalog()
        {
            Hotels = new ObservableCollection<Hotel>(HotelFacade.GetHotels());
        }
    }
}
