using JustWeather.Behavor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JustWeather.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private ICommand refreshPosCommand;
        //private ICommand refreshPageCommand;

        //private void HandleRefreshPageCommand(object parameter)
        //{
           
        //}

        //public ICommand RefreshPage
        //{
        //    get
        //    {
        //        if (this.refreshPageCommand == null)
        //        {
        //            this.refreshPageCommand = new DelegateCommand<object>(this.HandleRefreshPageCommand)
        //        }
        //        return this.refreshPageCommand;
        //    }
        //}

        public ICommand RefreshPos
        {
            get
            {
                if (this.refreshPosCommand == null)
                {
                    this.refreshPosCommand = new DelegateCommand<object>(this.HandleRefreshPosCommand);
                }
                return this.refreshPosCommand;
            }
        }

        private void HandleRefreshPosCommand(object parameter)
        {
            var helper = new Helpers();
            helper.RefreshCoordinates();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void SetObservableValues<T>(
            ObservableCollection<T> observables,
            IEnumerable<T> values)
        {
            if (observables != values)
            {
                observables.Clear();
                foreach (var value in values)
                {
                    observables.Add(value);
                }
            }
        }

        public void Navigate(Type sourcePageType)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePageType);
        }

        public void Navigate(Type sourcePageType, object parameter)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePageType, parameter);
        }

        public void GoBack()
        {
            ((Frame)Window.Current.Content).GoBack();
        }
    }
}
