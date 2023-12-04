using System.Windows.Input;

namespace EvipFinalZhGyak
{
    public partial class MainPage : ContentPage
    {
        public DataModel dataModel;
        public ICommand searchCommand { get; set; }
        public ICommand MyCommand { get; }


        public MainPage()
        {
            dataModel = new DataModel();
            MyCommand = new SearchCommand(dataModel,teszt);
            InitializeComponent();
            //BindingContext = dataModel;
            BindingContext = this;
            dataModel.Cars.Add(new Car("asd","asd",21));
            dataModel.Cars.Add(new Car("asd2", "asd2", 212));
        }
        private void teszt()
        {

        }
    }
}