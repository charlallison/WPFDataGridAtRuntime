using System;
using System.Windows.Input;

namespace WorkingWithWPFDataGrid.Command {
    public class CommandImpl : ICommand {

        public CommandImpl(Action action) {
            this.action = action;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            action.Invoke();
        }

        public event EventHandler CanExecuteChanged;
        private Action action;
    }
}
