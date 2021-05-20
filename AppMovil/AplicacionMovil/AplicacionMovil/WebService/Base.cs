using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AplicacionMovil.WebService
{
  public class Base
  {
    public HttpClient Client = new HttpClient();
    public HttpClient myCliente()
    {
      Client.BaseAddress = new Uri(Util.Constantes.rutaAPI);
      Client.DefaultRequestHeaders.Accept.Clear();
      Client.Timeout = TimeSpan.FromSeconds(15);
      //Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
      Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      return Client;
    }
  }
}
