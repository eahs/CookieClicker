using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CookieClicker
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private int count = 0;


        public int Count
        {
            set
            {
                count++;
                OnPropertyChanged("Count");
                OnPropertyChanged("Message");
            }
            get
            {
                return count;
            }
        }

        public string Message
        {
            get
            {
                return $"You have {count} cookies!";
            }
        }

        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = this;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            PressCookie();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            PressCookie();
        }

        private async void PressCookie()
        {
            Count++;
            //MyLabel.Text = "Cookie Pressed " + count + " Times!";

            await Cookie.ScaleTo(1.2, 125U, Easing.CubicInOut);
            await Cookie.ScaleTo(1.0, 125U, Easing.CubicInOut);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
