using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicacionMovil
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Login : ContentPage
  {
    public Login()
    {
      InitializeComponent();
    }

    private async void btnIngresar_Clicked(object sender, EventArgs e)
    {
      if (!App.Internet())
      {
        await DisplayAlert("Mensaje", App.MensajeInternet, "OK");
        return;
      }
      try
      {
        Modelos.Usuario user = new Modelos.Usuario();
        user = await new WebService.Usuario().Login(txtIdentificacion.Text.Trim());
        if (user.id > 0)
        {
          if (swRecordar.IsToggled)
          {
            Preferences.Set("user", JsonConvert.SerializeObject(user));
            Preferences.Set("login", true);
          }
          else
          {
            Preferences.Set("user", string.Empty);
            Preferences.Set("login", false);
          }
          App.usuarioLogin = user;
          App.Current.MainPage = new NavigationPage(new Inicio());
        }
        else
        {

          await DisplayAlert("Mensaje", "La credenciales ingresadas son incorrectas", "OK");
        }
      }
      catch (Exception ex)
      {

        await DisplayAlert("Mensaje", App.MensajeError, "OK");
        //Crashes.TrackError(ex);
      }
      finally
      {

      }
    }
  }
}