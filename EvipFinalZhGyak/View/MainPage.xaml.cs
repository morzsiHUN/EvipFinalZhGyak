using EvipFinalZhGyak.Model;
using EvipFinalZhGyak.ViewModel;

namespace EvipFinalZhGyak
{
    public partial class MainPage : ContentPage
    {
        public DataModel dataModel;
        public SearchCommand MySearchCommand { get; set; }

        public MainPage()
        {
            dataModel = new DataModel();
            MySearchCommand = new SearchCommand(dataModel);
            InitializeComponent();
            LeftGrid.BindingContext = dataModel;
            RightCollection.BindingContext = dataModel;
        }
    }
}