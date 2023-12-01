using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvipFinalZhGyak
{
    public class DataModel : INotifyPropertyChanged
    {
        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set
            {
                SetPropertyValue(ref _brand, value, nameof(Brand));
            }
        }
        private int _maxPrice;
        public int MaxPrice
        {
            get { return _maxPrice; }
            set
            {
                SetPropertyValue(ref _maxPrice, value, nameof(MaxPrice));
            }
        }
        private string _selectedType;
        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                SetPropertyValue(ref _selectedType, value, nameof(SelectedType));
            }
        }
        private int _days;
        public int Days
        {
            get { return _days; }
            set
            {
                SetPropertyValue(ref _days, value, nameof(Days));
            }
        }

        public string Summary
        {
            get
            {
                return $"{Brand} típusú {SelectedType} autó, összesen {Days} napra, maximum {MaxPrice} Ft";
            }
        }

        public ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //Felhasználói felület értesítése a változásról --> frissítés
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Kód ismétlés elkerülése
        protected virtual void SetPropertyValue<T>(ref T field, T value, string propertyName)
        {
            field = value;
            OnPropertyChanged(propertyName);
            OnPropertyChanged(nameof(Summary));
        }

        public DataModel()
        {
            //test car data
            Cars = new ObservableCollection<Car>
            {
                new Car("Toyota", "kicsi", 2449),
                new Car("BMW", "nagy", 1500)
            };
        }

        public async void Search()
        { 
            List<Car> allCar  = new List<Car>()
            {
                new Car("Toyota Yaris", "kicsi", 2449),
                new Car("Volvo v60", "kombi", 9000),
                new Car("Volvo v90", "kombi", 1000),
                new Car("Opel Astra", "kicsi", 500),
                new Car("Peugeot Boxer", "nagy", 7000),
                new Car("Nissan Cube", "kicsi", 4200),
                new Car("Ford Focus", "kicsi", 1000),
                new Car("Wolsvagen Golf", "kicsi", 3000),
                new Car("BMW X6", "nagy", 5000),
            };

            List<Car> filteredCars = allCar.Where(car => car.Name.Contains(Brand) && car.Type == SelectedType && car.Price <= MaxPrice).ToList();

            Cars.Clear();

            foreach (var car in filteredCars)
            {
                Cars.Add(car);
                Task.Delay(1000).Wait();
            }
        }
    }
}
