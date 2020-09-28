using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CookieClicker
{
    public partial class MainPage : ContentPage
    {
        private int count = 0;

        public MainPage()
        {
            InitializeComponent();
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
            count++;
            MyLabel.Text = "Cookie Pressed " + count + " Times!";

            await Cookie.ScaleTo(1.2, 125U, Easing.CubicInOut);
            await Cookie.ScaleTo(1.0, 125U, Easing.CubicInOut);
        }
    }
}
