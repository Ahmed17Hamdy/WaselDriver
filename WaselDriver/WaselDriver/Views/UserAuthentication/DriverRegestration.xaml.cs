﻿using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WaselDriver.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaselDriver.Views.UserAuthentication
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DriverRegestration : ContentPage
	{
        private MediaFile ProfilePic, NationalImg1, NationalImg2, DriverLicImg, CarLicImg, CarImg;
        int userId;
        public DriverRegestration (int id)
		{
			InitializeComponent ();
		}
        private async void Regbtn_Clicked(object sender, EventArgs e)
        {
            StringContent user_id = new StringContent(userId.ToString());   
            StringContent car_model_id = new StringContent(3.ToString());
            var content = new MultipartFormDataContent();
            content.Add(user_id, "user_id");
            content.Add(car_model_id, "car_model_id");
            content.Add(new StreamContent(ProfilePic.GetStream()), "personal_image", $"{ProfilePic.Path}");
            content.Add(new StreamContent(NationalImg1.GetStream()), "national_id_front", $"{NationalImg1.Path}");
            content.Add(new StreamContent(NationalImg2.GetStream()), "national_id_behind", $"{NationalImg2.Path}");
            content.Add(new StreamContent(DriverLicImg.GetStream()), "driving_license", $"{DriverLicImg.Path}");
            content.Add(new StreamContent(CarLicImg.GetStream()), "car_license", $"{CarLicImg.Path}");
            content.Add(new StreamContent(CarImg.GetStream()), "car_img", $"{CarImg.Path}");
            var httpClient = new HttpClient();
            try
            {
                var httpResponseMessage = await httpClient.PostAsync("http://wassel.alsalil.net/api/driverRegister", content);
                var serverResponse = httpResponseMessage.Content.ReadAsStringAsync().Result.ToString();
                var json = JsonConvert.DeserializeObject<Response<string, string>>(serverResponse);
                await DisplayAlert("", json.message, "موافق");
            }
            catch (Exception)
            {
                await DisplayAlert("خطأ", "خطأ بالإتصال بالإنترنت من فضلك حاول في وقت لاحق !!", "موافق");
            }
        }
        private async void ProfileImg_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("خطأ", "لم يتم إلتقاط صور", "موافق");
                return;
            }
            ProfilePic = await CrossMedia.Current.PickPhotoAsync();
            if (ProfilePic == null)
                return;

            ProfImgSource.Source = ImageSource.FromStream(() =>
            {
                return ProfilePic.GetStream();
            });
        }
        private async void NationalFront_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("خطأ", "لم يتم إلتقاط صور", "موافق");
                return;
            }
            NationalImg1 = await CrossMedia.Current.PickPhotoAsync();
            if (NationalImg1 == null)
                return;

            NatFrontImgSource.Source = ImageSource.FromStream(() =>
            {
                return NationalImg1.GetStream();
            });
        }
        private async void NationalBack_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("خطأ", "لم يتم إلتقاط صور", "موافق");
                return;
            }
            NationalImg2 = await CrossMedia.Current.PickPhotoAsync();
            if (NationalImg2 == null)
                return;

            NatBackImgSource.Source = ImageSource.FromStream(() =>
            {
                return NationalImg2.GetStream();
            });
        }
        private async void CarLicImg_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("خطأ", "لم يتم إلتقاط صور", "موافق");
                return;
            }
            CarLicImg = await CrossMedia.Current.PickPhotoAsync();
            if (CarLicImg == null)
                return;

            CarLicImgSource.Source = ImageSource.FromStream(() =>
            {
                return CarLicImg.GetStream();
            });
        }
        private async void DriverLicImg_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("خطأ", "لم يتم إلتقاط صور", "موافق");
                return;
            }
            DriverLicImg = await CrossMedia.Current.PickPhotoAsync();
            if (DriverLicImg == null)
                return;

            DriverLicImgSource.Source = ImageSource.FromStream(() =>
            {
                return DriverLicImg.GetStream();
            });
        }
        private async void CarImg_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("خطأ", "لم يتم إلتقاط صور", "موافق");
                return;
            }
            CarImg = await CrossMedia.Current.PickPhotoAsync();
            if (CarImg == null)
                return;

            CarImgSource.Source = ImageSource.FromStream(() =>
            {
                return CarImg.GetStream();
            });
        }
    }
}