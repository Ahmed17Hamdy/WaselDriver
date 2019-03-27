using Com.OneSignal;
using System;
using WaselDriver.Views.UserAuthentication;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WaselDriver
{
    public partial class App : Application
    {
        private int id;

        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
            OneSignal.Current.StartInit("1126a3d0-1d80-42ee-94db-d0449ac0a62c").EndInit();
            

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
