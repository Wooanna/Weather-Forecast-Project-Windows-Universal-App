using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherForecast.ViewModel
{
    public class CommandWithParameters : ICommand
    {
         private Action<object> execute;
        private Func<object, bool> canExecute;

        public CommandWithParameters(Action<object> execute, Func<object,bool> canExecute = null)
        {
           this.execute = execute;
           this.canExecute = canExecute;
       }

       public bool CanExecute(object parameter)
       {
           if (this.canExecute == null)
           {
               return true;
           }
           else
           {
               return this.canExecute(parameter);
           
           }
       }

       public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
       {
            this.execute(parameter);
       }
    }
}
