using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicacionMovil
{
  public partial class App : Application
  {
    public static string MensajeInternet = "Revisa tu conexión de internet!";
    public static string MensajeError = string.Empty;
    public static Modelos.Usuario usuarioLogin { get; set; } = new Modelos.Usuario();
    public App()
    {
      InitializeComponent();

      MainPage = new NavigationPage(new MainPage());
    }
    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
    public static bool Internet()
    {
      var current = Connectivity.NetworkAccess;

      if (current == NetworkAccess.Internet)
        return true;
      else
        return false;
    }
  }
}
