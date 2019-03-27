using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TK.CustomMap.Droid;
using Plugin.CurrentActivity;
using Com.OneSignal;

namespace WaselDriver.Droid
{
    [Activity(Label = "WaselDriver", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        readonly string[] permission =
        {
            Android.Manifest.Permission.AccessCheckinProperties,
            Android.Manifest.Permission.AccessCoarseLocation,
            Android.Manifest.Permission.AccessFineLocation,
            Android.Manifest.Permission.AccessLocationExtraCommands,
            Android.Manifest.Permission.AccessMockLocation,
            Android.Manifest.Permission.AccessNetworkState,
             Android.Manifest.Permission.WriteExternalStorage,
            Android.Manifest.Permission.ReadExternalStorage,
            Android.Manifest.Permission.Internet

        };
        const int RequestId = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            ChechSdk();
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            OneSignal.Current.StartInit("1126a3d0-1d80-42ee-94db-d0449ac0a62c").EndInit();
            TKGoogleMaps.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public void ChechSdk()
        {
            if ((int)Build.VERSION.SdkInt > 23)
            {
                RequestPermissions(permission, RequestId);
                return;
            }
            else
            {
                return;
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permission, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}