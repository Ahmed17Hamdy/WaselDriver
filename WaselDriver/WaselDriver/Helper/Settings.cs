using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WaselDriver.Helper
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        private const string LastEmailSettingsKey = "last_email_key";
        private static readonly string SettingsDefault = string.Empty;
        public static string LastUsedEmail
        {
            get
            =>
                 AppSettings.GetValueOrDefault(LastEmailSettingsKey, SettingsDefault);


            set
            =>
                AppSettings.AddOrUpdateValue(LastEmailSettingsKey, value);

        }
        private const string LastUserStatusSettingsKey = "last_userstatus_key";
        private static readonly string SettingsStatus = string.Empty;
        public static string LastUserStatus
        {
            get
            =>
                 AppSettings.GetValueOrDefault(LastUserStatusSettingsKey, SettingsStatus);


            set
            =>
                AppSettings.AddOrUpdateValue(LastUserStatusSettingsKey, value);

        }

        private const string LastSignalIDSettingKey = "last_email_key";
        private static readonly string SignalID = string.Empty;
        public static string LastSignalID
        {
            get
            =>
                 AppSettings.GetValueOrDefault(LastSignalIDSettingKey, SignalID);


            set
            =>
                AppSettings.AddOrUpdateValue(LastSignalIDSettingKey, value);

        }

        //private const string LastServiceSettingsKey = "last_service_key";
        //private static readonly string ServiceSettingsDefault = string.Empty;
        //public static string LastUsedService
        //{
        //    get
        //    =>
        //         AppSettings.GetValueOrDefault(LastServiceSettingsKey, ServiceSettingsDefault);


        //    set
        //    =>
        //        AppSettings.AddOrUpdateValue(LastServiceSettingsKey, value);

        //}

        private const string LastRoleSettingsKey = "last_role_key";
        private static readonly int SettingsRole = 0;
        public static int LastUseeRole
        {
            get
            =>
                 AppSettings.GetValueOrDefault(LastRoleSettingsKey, SettingsRole);


            set
            =>
                AppSettings.AddOrUpdateValue(LastRoleSettingsKey, value);

        }

        private const string LastGravity = "last_Gravity_key";
        private static readonly string GravitySettings = string.Empty;
        public static string LastUserGravity
        {
            get
            =>
                 AppSettings.GetValueOrDefault(LastGravity, GravitySettings);


            set
            =>
                AppSettings.AddOrUpdateValue(LastGravity, value);

        }

        private const string LastUserHash = "User_Hash";
        private static readonly string UserHashDefault = string.Empty;
        public static string UserHash
        {
            get
            =>
                 AppSettings.GetValueOrDefault(LastUserHash, UserHashDefault);


            set
            =>
                AppSettings.AddOrUpdateValue(LastUserHash, value);

        }

        private const string LastUserFirebaseToken = "Firebase_Token";
        private static readonly string LastFirebaseToken = string.Empty;
        public static string UserFirebaseToken
        {
            get
            =>
                 AppSettings.GetValueOrDefault(LastUserFirebaseToken, LastFirebaseToken);


            set
            =>
                AppSettings.AddOrUpdateValue(LastUserFirebaseToken, value);

        }


        private const string PublicParamter = "PublicParamter";
        private static readonly string ParamSettings = string.Empty;
        public static string LastPublicParamter
        {
            get
            =>
                 AppSettings.GetValueOrDefault(PublicParamter, ParamSettings);


            set
            =>
                AppSettings.AddOrUpdateValue(PublicParamter, value);

        }

        private const string SecondParamter = "SecondParamter";
        private static readonly string SecondSettings = string.Empty;
        public static string LastSecondParamter
        {
            get
            =>
                 AppSettings.GetValueOrDefault(SecondParamter, SecondSettings);


            set
            =>
                AppSettings.AddOrUpdateValue(SecondParamter, value);

        }


        private const string LastIDSettingsKey = "last_ID_key";
        private static readonly int SettingsIDDefault = 0;
        public static int LastUsedID
        {
            get => AppSettings.GetValueOrDefault(LastIDSettingsKey, SettingsIDDefault);
            set => AppSettings.AddOrUpdateValue(LastIDSettingsKey, value);

        }

        private const string LastServiceID = "last_ID_key";
        private static readonly int SettingsServiceID = 0;
        public static int LastServeceIDParam
        {
            get => AppSettings.GetValueOrDefault(LastServiceID, SettingsServiceID);
            set => AppSettings.AddOrUpdateValue(LastServiceID, value);

        }

        private const string _countryID = "last_Country";
        private static readonly int SettingsCountriesDefault = 0;
        public static int LastCountry
        {
            get => AppSettings.GetValueOrDefault(_countryID, SettingsCountriesDefault);
            set => AppSettings.AddOrUpdateValue(_countryID, value);

        }

        private const string _cityID = "last_City";
        private static readonly int SettingsCityDefault = 0;
        public static int LastCity
        {
            get => AppSettings.GetValueOrDefault(_cityID, SettingsCityDefault);
            set => AppSettings.AddOrUpdateValue(_cityID, value);

        }

    }
}
