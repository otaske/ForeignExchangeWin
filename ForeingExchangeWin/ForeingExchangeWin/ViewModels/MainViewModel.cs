namespace ForeingExchangeWin.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using System;
    using System.ComponentModel;

    public class MainViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        string _dollars;
        string _euros;
        string _pounds;
        #endregion

        #region Properties
        public string Pesos
        {
            get;
            set;
        }
        public string Dollars
        {
            get
            {
                return _dollars;
            }
            set
            {
                if (value != _dollars)
                {
                    _dollars = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dollars)));
                }
            }
        }
        public string Euros
        {
            get
            {
                return _euros;
            }
            set
            {
                if (value != _euros)
                {
                    _euros = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Euros)));
                }
            }
        }
        public string Pounds
        {
            get
            {
                return _pounds;
            }
            set
            {
                if (value != _pounds)
                {
                    _pounds = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pounds)));
                }
            }
        }
        #endregion
        #region Constructor
        public MainViewModel()
        {
        }

        #endregion

        #region Commands
        public ICommand ConvertCommand
        {
            get { return new RelayCommand(Convert); }
        }

        async void Convert()
        {
            if (string.IsNullOrEmpty(Pesos))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a value in pesos..", "Accept");
                return;
            }

            decimal pesos = 0;
            if (!decimal.TryParse(Pesos, out pesos))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a value numeric in pesos..", "Accept");
                Pesos = null;
                return;
            }

            var dollars = pesos / 2976.19048M;
            var euros = pesos / 3517.96131M;
            var pounds = pesos / 3848.21429M;

            Dollars = string.Format("{0:C2}", dollars);
            Euros = string.Format("{0:C2}", euros);
            Pounds = string.Format("{0:C2}", pounds);
        }
        #endregion
    }
}
