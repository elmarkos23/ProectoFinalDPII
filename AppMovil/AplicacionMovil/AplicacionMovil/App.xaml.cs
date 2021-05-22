using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicacionMovil
{
  public partial class App : Application
  {
    public static string MensajeInternet = "Revisa tu conexión de internet!";
    public static string MensajeError = "=( Intenta de nuevo";
    public static Modelos.Usuario usuarioLogin { get; set; } = new Modelos.Usuario();
    public static string lat;
    public static string lng;
    public static string ubiGeo { get; set; }
    public App()
    {
      InitializeComponent();

      MainPage = new NavigationPage(new Login());
    }
    protected override void OnStart()
    {
      Geolocalizacion();
    }

    protected override void OnSleep()
    {
      
    }

    protected override void OnResume()
    {
      Geolocalizacion();
    }
    public static bool Internet()
    {
      var current = Connectivity.NetworkAccess;

      if (current == NetworkAccess.Internet)
        return true;
      else
        return false;
    }
    public static async void Geolocalizacion()
    {
      List<string> datos = new List<string>();
      try
      {
        var location = await Xamarin.Essentials.Geolocation.GetLocationAsync(new GeolocationRequest() { DesiredAccuracy = GeolocationAccuracy.Medium, Timeout = TimeSpan.FromSeconds(10) });

        var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);

        if (location != null && placemarks != null)
        {
          lat = location.Latitude.ToString().Replace(",", ".");
          lng = location.Longitude.ToString().Replace(",", ".");
          ubiGeo = placemarks?.FirstOrDefault().FeatureName + " " + placemarks.FirstOrDefault().Locality + " " + placemarks.FirstOrDefault().SubLocality;
        }
       
      }
      catch (FeatureNotSupportedException fnsEx)
      {
        // Handle not supported on device exception
      }
      catch (FeatureNotEnabledException fneEx)
      {
        // Handle not enabled on device exception
      }
      catch (PermissionException pEx)
      {
        // Handle permission exception
      }
      catch (Exception ex)
      {
        // Unable to get location
      }
      
    }
  }
}
