using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AplicacionMovil
{
  public partial class MainPage : ContentPage
  {

    public MainPage()
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
