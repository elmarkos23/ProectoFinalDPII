using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AplicacionMovil
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Registro : ContentPage
  {
    public string tipo { get; set; }
    public byte[] foto { get; set; }
    Modelos.Asistencia miAsistencia = new Modelos.Asistencia();
    public Registro(string _tipo,int idAsistencia)
    {
      InitializeComponent();
      var pin = new Pin
      {
        Type = PinType.Generic,
        Position = new Position(double.Parse(App.lat, System.Globalization.CultureInfo.InvariantCulture), double.Parse(App.lng, System.Globalization.CultureInfo.InvariantCulture)),
        Label = App.usuarioLogin.nombres + " " + App.usuarioLogin.apellidos,
        Address = App.ubiGeo
      };

      myMapa.Pins.Add(pin);
      myMapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(double.Parse(App.lat, System.Globalization.CultureInfo.InvariantCulture), double.Parse(App.lng, System.Globalization.CultureInfo.InvariantCulture)), Distance.FromKilometers(1)));
      this.tipo = _tipo;
      miAsistencia.id = idAsistencia;
      this.Title = _tipo.Equals("I") ? "Registrar Entrada" : "Registrar Salida";
      this.IconImageSource = tipo.Equals("I") ? "login" : "logout";
      btnTomarFoto.Clicked += async (sender, args) =>
      {
        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
        {
          await DisplayAlert("Mensaje Cámara", "Cierra la aplicación y revisar los permisos de esta aplicación de forma manual en ajustes de tu smartphone.!", "OK");
          return;
        }

        var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
        {
          Directory = "Worktime",
          SaveToAlbum = true,
          CompressionQuality = 75,
          CustomPhotoSize = 50,
          PhotoSize = PhotoSize.Medium,
          MaxWidthHeight = 500,
          AllowCropping = true,
          DefaultCamera = CameraDevice.Front
        });

        if (file == null)
          return;

        foto = File.ReadAllBytes(file.Path);

        imgFoto.Source = ImageSource.FromStream(() =>
        {
          var stream = file.GetStream();
          file.Dispose();
          return stream;
        });
      };
    }

    private async void btnRegistro_Clicked(object sender, EventArgs e)
    {
      var answer = await DisplayAlert("Pregunta", "¿Quieres Guardar?", "Si", "No");
      if (answer.Equals(true))
      {
        Modelos.Dto.DtoAsistencia dtoAsistencia = new Modelos.Dto.DtoAsistencia();
        if (tipo.Equals("I"))
        {
          dtoAsistencia.asistencia.idUsuario = App.usuarioLogin.id;
          dtoAsistencia.asistencia.estado = true;
          dtoAsistencia.asistenciaDetalle.tipo = this.tipo;
          dtoAsistencia.asistenciaDetalle.ubicacion = App.lat + "," + App.lng;
          dtoAsistencia.asistenciaDetalle.ubicacionReferencial = App.ubiGeo;
          dtoAsistencia.asistenciaDetalle.foto = this.foto;
        }
        else
        {
          dtoAsistencia.asistencia.id = miAsistencia.id;
          dtoAsistencia.asistenciaDetalle.idAsistencia = miAsistencia.id;
          dtoAsistencia.asistencia.idUsuario = App.usuarioLogin.id;
          dtoAsistencia.asistencia.estado = true;
          dtoAsistencia.asistenciaDetalle.tipo = this.tipo;
          dtoAsistencia.asistenciaDetalle.ubicacion = App.lat + "," + App.lng;
          dtoAsistencia.asistenciaDetalle.ubicacionReferencial = App.ubiGeo;
          dtoAsistencia.asistenciaDetalle.foto = this.foto;
        }

        bool estado = new WebService.Registro().Insert(dtoAsistencia);
        if (estado)
        {
          await Navigation.PopAsync();
        }
        else
        {
          await DisplayAlert("Error", "=( Intenta de nuevo!", "OK");
        }
      }
    }
  }
}