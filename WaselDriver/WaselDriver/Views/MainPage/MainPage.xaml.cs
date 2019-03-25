using System;
using TK.CustomMap;
using WaselDriver.Helper;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WaselDriver
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CheckUserStatus();
        }

        private void CheckUserStatus()
        {
            if (Settings.LastUserStatus == "0")
            {
                UserStatuslbl.IsVisible = true;
            }
            else
            {
                UserStatuslbl.IsVisible = false;
            }

        }

        private  void  UserLocationChanged(object sender, TK.CustomMap.TKGenericEventArgs<TK.CustomMap.Position> e)
        {
            var x = e.Value.Latitude;
            var y = e.Value.Longitude;
            try
            {
                var CurrentLocation = new Position(x, y);
                if(CurrentLocation== null)
                {

                }
                else
                {

                }
            }
            catch
            {

            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}
