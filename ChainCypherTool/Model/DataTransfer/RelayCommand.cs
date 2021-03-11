using System;
using System.Windows.Input;

namespace ChainCypherTool.Model.DataTransfer
{
    internal class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action execute = null;
        private readonly Predicate<bool> canExecute = null;

        public RelayCommand(Action execute) : this(execute, null) { }

        public RelayCommand(Action execute, Predicate<bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null;
        }

        public void Execute(object parameter = null)
        {
            execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
