using Newtonsoft.Json;
using System;
using System.Net.Http;
using TK.CustomMap;
using WaselDriver.Helper;
using WaselDriver.Models;
using WaselDriver.Views.OrderPage;
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

        private async  void  UserLocationChanged(object sender, TK.CustomMap.TKGenericEventArgs<TK.CustomMap.Position> e)
        {
            var x = e.Value.Latitude;
            var y = e.Value.Longitude;
           if(Settings.LastLat != x.ToString() || Settings.LastLng != y.ToString())
            {
                if (Settings.LastUserStatus != "0")
                {
                    Settings.LastLat = x.ToString();
                    Settings.LastLng = y.ToString();
                    try
                    {
                        var CurrentLocation = new Position(x, y);
                        if (CurrentLocation != null)
                        {
                            StringContent user_id = new StringContent(Settings.LastUsedID.ToString());
                            StringContent lat = new StringContent(Settings.LastLat);
                            StringContent lng = new StringContent(Settings.LastLng);
                            var Content = new MultipartFormDataContent();
                            Content.Add(user_id, "user_id");
                            Content.Add(lat, "lat");
                            Content.Add(lng, "lng");
                            var httpClient = new HttpClient();
                            try
                            {
                                var httpResponseMessage = await httpClient.PostAsync("http://wassel.alsalil.net/api/updatelocal", Content);
                                var serverResponse = httpResponseMessage.Content.ReadAsStringAsync().Result.ToString();
                                var json = JsonConvert.DeserializeObject<Response<string, string>>(serverResponse);

                            }
                            catch (Exception)
                            {
                                //  Active.IsRunning = false;
                                await DisplayAlert(AppResources.Error, AppResources.ErrorMessage, AppResources.Ok);
                            }
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
                else
                {
                    await DisplayAlert(AppResources.Error, AppResources.UserStatues, AppResources.Ok);
                }
            }          
           
       
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Settings.LastUserStatus!="1")
            {
                await Navigation.PushModalAsync(new OrdersPage());
            }
            else
            {
                await DisplayAlert(AppResources.Error, AppResources.UserStatues, AppResources.Ok);
            }
        }
    }
}
