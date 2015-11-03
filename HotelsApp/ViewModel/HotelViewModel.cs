using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelsApp.Common;
using HotelsApp.Handler;
using HotelsApp.Model;

namespace HotelsApp.ViewModel
{
   public class HotelViewModel: INotifyPropertyChanged
    {
       public HotelViewModel()
       {
            MyNewHotel = new Hotel();
            SelectedHotel = new Hotel();
            hotelHandler = new HotelHandler(this);
            createHotelCommand = new RelayCommand(hotelHandler.CreateHotel);
            HotelsList = new HotelCatalog().Hotels;

        }


       private ICommand createHotelCommand;
       private Hotel _selectedHotel;

       public ICommand CreateHotelCommand
        {
            get { return createHotelCommand; }
            set { createHotelCommand = value; }
        }

       private HotelHandler hotelHandler { get; set; }
       public  Hotel MyNewHotel { get; set; }

       public Hotel SelectedHotel
       {
           get { return _selectedHotel; }
           set
           {
               _selectedHotel = value;
                OnPropertyChanged();
            }
       }

       public ObservableCollection<Hotel> HotelsList { get; set; }



       public event PropertyChangedEventHandler PropertyChanged;

       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

       }
    }
}
