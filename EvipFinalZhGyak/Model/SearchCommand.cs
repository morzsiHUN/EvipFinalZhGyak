using System.Windows.Input;
using EvipFinalZhGyak.ViewModel;

namespace EvipFinalZhGyak.Model
{
    public class SearchCommand : ICommand
    {
        private readonly DataModel dataModel;

        public SearchCommand(DataModel dataModel)
        {
            this.dataModel = dataModel;
            this.dataModel.PropertyChanged += (sender, args) =>
            {
                this.CanExecuteChanged?.Invoke(this, new System.EventArgs());
            };
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (dataModel.Brand == "" || dataModel.Brand == null || dataModel.SelectedType == "" || dataModel.SelectedType == null)
            {
                return false;
            }
            return true;
        }

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                await Task.Run(() => dataModel.Search());
            }
        }
    }
}
