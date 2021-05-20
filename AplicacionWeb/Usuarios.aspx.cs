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

    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      int index = Convert.ToInt32(e.CommandArgument);
      GridViewRow gvrow = gvDatos.Rows[index];
      if (e.CommandName.Equals("Editar"))
      {
        Session["idUsuario"] = Convert.ToInt32(HttpUtility.HtmlDecode(gvrow.Cells[1].Text).ToString());
        Response.Redirect("Usuario");
      }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
      Session["idUsuario"] = "0";
      Response.Redirect("Usuario");
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {

    }
  }
}