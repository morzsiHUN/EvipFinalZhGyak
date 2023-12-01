using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvipFinalZhGyak
{
    public class SearchCommand : ICommand
    {
        private DataModel dataModel;

        public SearchCommand(DataModel dataModel)
        {
            this.dataModel = dataModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (dataModel.Brand == "" || dataModel.SelectedType == "")
            {
                return false;
            }
            return true;
        }

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
            dataModel.Search();
            }
        }
    }
}
