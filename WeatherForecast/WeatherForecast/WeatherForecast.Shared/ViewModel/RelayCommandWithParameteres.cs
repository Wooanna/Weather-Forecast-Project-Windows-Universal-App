using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WeatherForecast.ViewModel
{
   public class RelayCommandWithParameteres : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;
       
       public RelayCommandWithParameteres(Action execute, Func<bool> canExecute = null) {
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
               return this.canExecute();
           
           }
       }

       public event EventHandler CanExecuteChanged;

       public void Execute(object parameter)
       {
           this.execute();
       }
    }
}
