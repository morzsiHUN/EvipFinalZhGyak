using System.Windows.Input;

namespace EvipFinalZhGyak
{
    public partial class MainPage : ContentPage
    {
        public DataModel dataModel;
        //public ICommand searchCommand { get; set; }
        //public ICommand TestCommand { get; set; }

        public readonly BindableProperty MyCommandProperty = 
        BindableProperty.Create(nameof(MyCommand), typeof(ICommand), typeof(MainPage));

        public ICommand MyCommand
        {
            get => (ICommand)GetValue(MyCommandProperty);
            set => SetValue(MyCommandProperty, value);
        }

        public MainPage()
        {
            dataModel = new DataModel();
            InitializeComponent();
            //BindingContext = dataModel;
            dataModel.Cars.Add(new Car("asd","asd",21));
            dataModel.Cars.Add(new Car("asd2", "asd2", 212));

            //TestCommand = new Command(() => SearchButton_Clicked());
            MyCommand = new Command(SearchButton_Clicked);
        }

        public void SearchButton_Clicked()
        {
            System.Diagnostics.Debug.WriteLine("SearchButton_Clicked method is called");
        }
    }
}