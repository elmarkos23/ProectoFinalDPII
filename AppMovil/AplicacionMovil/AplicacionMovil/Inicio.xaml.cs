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
    public int idAsistencia = 0;
    List<Modelos.Dto.DtoRegistro> listaAsitencia = new List<Modelos.Dto.DtoRegistro>();
    public string tipo = string.Empty;
    public Inicio()
    {
      InitializeComponent();
    }
    protected override void OnAppearing()
    {
      base.OnAppearing();
      //your code here;
      lblUsuario.Text = "¡Hola!. "+App.usuarioLogin.nombres +" "+App.usuarioLogin.apellidos;
      Cargar();
    }
    private async void Cargar()
    {
      listaAsitencia = await new WebService.Registro().Consultar(App.usuarioLogin.identificacion);
      if (listaAsitencia.Count == 0)
      {
        btnRegistro.ImageSource = "login";
        btnRegistro.Text = "Registrar Entrada";
        btnRegistro.BackgroundColor = Color.LightGreen;
        tipo = "I";
      }
      else if (listaAsitencia.Count == 1)
      {
        idAsistencia = listaAsitencia.First().idAsistencia;
        lblMensaje.Text = "Usted registro su entrada a: "+listaAsitencia.First().hora.ToString();
        btnRegistro.ImageSource = "logout";
        btnRegistro.Text = "Registrar Salida";
        btnRegistro.BackgroundColor = Color.Coral;
        tipo = "O";
      }
      else
      {
        btnRegistro.IsVisible = false;
        lblUsuario.Text = "Usted ya registro su asistencia del día";
      }
      

    }
    private async void btnCerrar_Clicked(object sender, EventArgs e)
    {
      var answer = await DisplayAlert("Pregunta", "Quieres cerrar la sesión", "Si", "No");
      if (answer.Equals(true))
      {
        Preferences.Set("user", "");
        Preferences.Set("login", false);
        App.Current.MainPage = new NavigationPage(new Login());
      }
    }

    private async void btnRegistro_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new Registro(tipo,idAsistencia));
    }
  }
}