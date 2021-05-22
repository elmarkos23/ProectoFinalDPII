using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMovil.WebService
{
    public class Registro
  {
    public HttpClient Client = new HttpClient();
    public Registro()
    {
      Client = new Base().Client;
    }
    public bool Insert(Modelos.Dto.DtoAsistencia registro)
    {
      var data = JsonConvert.SerializeObject(registro);
      var content = new StringContent(data, Encoding.UTF8, "application/json");
      var response = Client.PostAsync(Util.Constantes.rutaAPI + "worktime_service/api/Asistencia/insert", content).Result;
      if (response.IsSuccessStatusCode)
      {
        bool resultado = Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
        return resultado;
      }
      else
      {
        return false;
      }
    }
    public async Task<List<Modelos.Dto.DtoRegistro>> Consultar(string identificacion)
    {
      List<Modelos.Dto.DtoRegistro> Json = new List<Modelos.Dto.DtoRegistro>();

      try
      {
        var Uri = Util.Constantes.rutaAPI + "worktime_service/api/asistencia/ObtenerAsistencia" + "?identificacion=" + identificacion;
        HttpResponseMessage Response = await Client.GetAsync(Uri);
        string PlacesJson = Response.Content.ReadAsStringAsync().Result;
        if (PlacesJson.Length > 0)
        {
          Json = JsonConvert.DeserializeObject<List<Modelos.Dto.DtoRegistro>>(PlacesJson);
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

