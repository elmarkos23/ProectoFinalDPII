using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWeb
{
  public partial class Usuarios : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        CargarInformacion();
      }
    }
    private void CargarInformacion()
    {
      List<Modelos.Dto.DtoUsuarios> dtoUsuarios = new List<Modelos.Dto.DtoUsuarios>();
      dtoUsuarios = new AccesoDatos.Usuario().ObtenerUsuarios();
      gvDatos.DataSource = dtoUsuarios;
      gvDatos.DataBind();
    }
  }
}