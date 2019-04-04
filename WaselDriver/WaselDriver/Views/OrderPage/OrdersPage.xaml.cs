using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK.CustomMap;
using TK.CustomMap.Api.Google;
using TK.CustomMap.Overlays;
using WaselDriver.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaselDriver.Views.OrderPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrdersPage : ContentPage
	{
       List<TKRoute> routes = new List<TKRoute>();
        List<TKCustomMapPin> Pins = new List<TKCustomMapPin>();
       
        public OrdersPage ()
		{
			InitializeComponent ();
            GmsDirection.Init("AIzaSyC3HhPjcrVfeJXWnpp0uEl-rKP59C4Lit8");
            OrderMap.RouteCalculationFinished += OrderMap_RouteCalculationFinished;
            OrderMap.RouteCalculationFailed += OrderMap_RouteCalculationFailed;
            SetMyLocation();
        }

        private void OrderMap_RouteCalculationFailed(object sender, TKGenericEventArgs<TK.CustomMap.Models.TKRouteCalculationError> e)
        {
           
        }

        private void SetMyLocation()
        {
        //    MoveMapToMyLocation();
            var route = new TKRoute();
            route.TravelMode = TKRouteTravelMode.Driving;
            var myposition = new Position(37.79752, -122.40183);
            var toposition = new Position(37.776831, -122.394627);
            route.Source = myposition;
            route.Destination = toposition;
            route.Color = Color.Blue;
           
            route.LineWidth = 2;
            Pins.Add(new RoutePin
            {
                Route = route,
                IsSource = true,
                IsDraggable = true,
                Position = myposition,
                Title = "From",
                ShowCallout = true,
                DefaultPinColor = Color.Green
            });
            Pins.Add(new RoutePin
            {
                Route = route,
                IsSource = false,
                IsDraggable = true,
                Position = toposition,
                Title = "To",
                ShowCallout = true,
                DefaultPinColor = Color.Red
            });
            routes.Add(route);
            OrderMap.Routes = routes;
            OrderMap.Pins = Pins;
        }

        private void OrderMap_RouteCalculationFinished(object sender, TKGenericEventArgs<TKRoute> e)
        {
          //  OrderMap.MapRegion = route.Bounds;
        }
    }
}