using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMovil.WebService
{
  public class Usuario
  {
    public HttpClient Client = new HttpClient();
    public Usuario()
    {
      Client = new Base().Client;
    }
    public async Task<Modelos.Usuario> Login(string identificacion)
    {
      Modelos.Usuario Json = new Modelos.Usuario();

      try
      {
        var Uri = Util.Constantes.rutaAPI + "worktime_service/api/usuario/ObtenerUsuario" + "?identificacion=" + identificacion;
        HttpResponseMessage Response = await Client.GetAsync(Uri);
        string PlacesJson = Response.Content.ReadAsStringAsync().Result;
        if (PlacesJson.Length > 0)
        {
          Json = JsonConvert.DeserializeObject<Modelos.Usuario>(PlacesJson);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      
      return Json;
    }
  }
}
