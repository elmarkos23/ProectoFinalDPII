using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWeb
{
  public partial class Usuario : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        CargarInformacion();
        int id = Convert.ToInt32(Session["idUsuario"]);
        if (id > 0)
        {
          Modelos.Usuario customer = new AccesoDatos.Usuario().SelectFirst(id);
          lblID.Text = customer.id.ToString();
          txtNombres.Text = customer.nombres.ToString();
          txtApellidos.Text = customer.apellidos;
          txtIdentificacion.Text = customer.identificacion;
          ddlDepartamento.SelectedValue = customer.idDepartamento.ToString();
          ddlGenero.SelectedValue = customer.genero;
          ddlTipoIdentificacion.SelectedValue = customer.tipoIdentificacion;
          chkEstado.Checked = customer.estado;
        }
        else
        {
          lblID.Text = "0";
        }
      }
    }
    private void CargarInformacion()
    {
      List<Modelos.Departamento> departamentos = new List<Modelos.Departamento>();
      departamentos = new AccesoDatos.Departamento().Select();
      ddlDepartamento.DataSource = departamentos;
      ddlDepartamento.DataBind();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
      Modelos.Usuario usuario = new Modelos.Usuario
      {
        id = Convert.ToInt32(lblID.Text),
        nombres = txtNombres.Text.Trim(),
        apellidos = txtApellidos.Text.Trim(),
        genero = ddlGenero.SelectedValue.ToString(),
        idDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue),
        identificacion = txtIdentificacion.Text,
        tipoIdentificacion = ddlTipoIdentificacion.SelectedValue.ToString(),
        estado = chkEstado.Checked
      };
      if (usuario.id == 0)
      {
        new AccesoDatos.Usuario().Insert(usuario);
      }
      else
      {
        new AccesoDatos.Usuario().Update(usuario);
      }
      Response.Redirect("Usuarios");
    }
  }
}