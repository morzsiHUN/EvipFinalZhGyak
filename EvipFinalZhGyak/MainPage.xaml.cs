using System.Collections.ObjectModel;

namespace EvipFinalZhGyak
{
    public partial class MainPage : ContentPage
    {
        public DataModel dataModel;

        public MainPage()
        {
            dataModel = new DataModel();
            InitializeComponent();
            //BindingContext = dataModel;
            dataModel.Cars.Add(new Car("asd","asd",21));
            dataModel.Cars.Add(new Car("asd2", "asd2", 212));

        }
    }
}