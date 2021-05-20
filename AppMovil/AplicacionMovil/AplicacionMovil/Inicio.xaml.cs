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
  public partial class Inicio : ContentPage
  {
    public Inicio()
    {
      InitializeComponent();
    }
    protected override void OnAppearing()
    {
      base.OnAppearing();
      //your code here;
      lblUsuario.Text = "¡Hola!. "+App.usuarioLogin.nombres +" "+App.usuarioLogin.apellidos;
    }
    private async void btnCerrar_Clicked(object sender, EventArgs e)
    {
      var answer = await DisplayAlert("Pregunta", "Quieres cerrar la sesión", "Si", "No");
      if (answer.Equals(true))
      {
        Preferences.Set("user", "");
        Preferences.Set("login", false);
        App.Current.MainPage = new NavigationPage(new MainPage());
      }
    }

    private async void btnEntrada_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new Registro());
    }

    private async void btnSalida_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new Registro());
    }
  }
}