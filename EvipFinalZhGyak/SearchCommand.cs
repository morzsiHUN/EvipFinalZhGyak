using System;
using System.Windows.Input;

namespace EvipFinalZhGyak
{
    public class SearchCommand : ICommand
    {
        private DataModel dataModel;
        private Action _execute;
        private Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public SearchCommand(DataModel dataModel, Action execute, Func<bool> canExecute = null)
        {
            this.dataModel = dataModel;
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            // Az itt lévő feltétel lehet, hogy módosítást igényel attól függően, hogy mik a pontos követelmények.
            // Például, ha az üres stringek elfogadhatóak, akkor ez a feltétel eltávolítható.
            if (dataModel.Brand == "" || dataModel.SelectedType == "")
            {
                return false;
            }
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                dataModel.Search();
                _execute();  // Csak akkor hívjuk meg a _execute-t, ha a CanExecute igaz.
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }
    }
}
