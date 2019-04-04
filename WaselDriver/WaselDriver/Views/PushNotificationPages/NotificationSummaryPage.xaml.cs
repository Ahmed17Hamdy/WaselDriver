using Newtonsoft.Json;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaselDriver.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WaselDriver.Helper;
using System.Net.Http;
using WaselDriver.Views.OrderPage;
using TK.CustomMap.Overlays;
using TK.CustomMap;

namespace WaselDriver.Views.PushNotificationPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotificationSummaryPage : ContentPage
	{
        private ObservableCollection<TKRoute> routes;
        private ObservableCollection<TKCustomMapPin> pins;
        private MapSpan bounds;

        public NotificationSummaryPage (string labelText)
		{
			InitializeComponent ();
            var Req = JsonConvert.DeserializeObject<DelivaryObject>(labelText);
            userNamelbl.Text = Req.driver_id;
            GetAddressFrom(Req.latfrom, Req.lngfrom);
            GetAddressTo(Req.latto, Req.lngto);
          
        }

        private async void GetAddressFrom(string latfrom , string lngfrom)
        {
            var addresses = await Geocoding.GetPlacemarksAsync(Convert.ToDouble(latfrom), Convert.ToDouble(lngfrom));
            var placemark = addresses?.FirstOrDefault();
            if (placemark != null)
            {
                if (addresses.FirstOrDefault().Thoroughfare != null)
                {
                    var loc = addresses.FirstOrDefault();
                    AddressFromlbl.Text = loc.Thoroughfare.ToString() + " , " + loc.AdminArea + " , " + loc.CountryName;
                    Settings.Latfrom = latfrom;
                    Settings.Lngfrom = lngfrom;
                    Settings.PlaceFrom = AddressFromlbl.Text;
                }
                else
                {
                    AddressFromlbl.Text = AppResources.LocationNotFound;
                }
            }
            else
            {
                AddressFromlbl.Text = AppResources.LocationNotFound;
            }
        }
        private async void GetAddressTo(string latto, string lngto)
        {
            var addresses = await Geocoding.GetPlacemarksAsync(Convert.ToDouble(latto), Convert.ToDouble(lngto));
            var placemark = addresses?.FirstOrDefault();
            if (placemark != null)
            {
                if (addresses.FirstOrDefault().Thoroughfare != null)
                {
                    var loc = addresses.FirstOrDefault();
                    AddressTolbl.Text = loc.Thoroughfare.ToString() + " , " + loc.AdminArea + " , " + loc.CountryName;
                    Settings.Latto = latto;
                    Settings.Lngto = lngto;
                    Settings.PlaceFrom = AddressTolbl.Text;
                }
                else
                {
                    AddressTolbl.Text = AppResources.LocationNotFound;
                }
            }
            else
            {
                AddressTolbl.Text = AppResources.LocationNotFound;
            }
        }

        private async void Acceptbtn_Clicked(object sender, EventArgs e)
        {
            TirhalOrder order = new TirhalOrder
            {
                latfrom = Settings.Latfrom,
                lngfrom = Settings.Lngfrom,
                user_id = Settings.LastUsedID.ToString(),
            //    driver_id = Settings.LastUsedDriverID.ToString(),
             //   car_model_id = Settings.LastUsedCarModel.ToString(),

                latto = Settings.Latto,
                lngto = Settings.Lngto,
            };
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("user_id", order.user_id.ToString());
            values.Add("driver_id", order.driver_id);
            values.Add("latfrom", order.latfrom);
            values.Add("lngfrom", order.lngfrom);
            values.Add("done", order.done.ToString());
            values.Add("latto", order.latto);
            values.Add("lngto", order.lngto);
            values.Add("car_model", order.car_model_id);
            values.Add("created_at", order.created_at);
            string content = JsonConvert.SerializeObject(values);
            var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.PostAsync("http://wassel.alsalil.net/api/addtirhalorder", new StringContent(content, Encoding.UTF8, "text/json"));
                var serverResponse = response.Content.ReadAsStringAsync().Result.ToString();
                var json = JsonConvert.DeserializeObject<Response<TirhalOrder, string>>(serverResponse);
                if (json.success == false)
                {
                    Active.IsRunning = false;
                    await DisplayAlert(AppResources.Error, json.message, AppResources.Ok);
                }
                else
                {
                    Active.IsRunning = false;
        //            await DisplayAlert(AppResources.OrderSuccess, json.message, AppResources.Ok);
                    Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new OrdersPage());
                }
            }
            catch (Exception)
            {
                Active.IsRunning = false;
                await DisplayAlert(AppResources.ErrorMessage, AppResources.ErrorMessage, AppResources.Ok);
            }
        }
    }
}