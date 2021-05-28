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
    
    public static bool VerificaCedula(char[] validarCedula)
    {
      int aux = 0, par = 0, impar = 0, verifi;
      for (int i = 0; i < 9; i += 2)
      {
        aux = 2 * int.Parse(validarCedula[i].ToString());
        if (aux > 9)
          aux -= 9;
        par += aux;
      }
      for (int i = 1; i < 9; i += 2)
      {
        impar += int.Parse(validarCedula[i].ToString());
      }

      aux = par + impar;
      if (aux % 10 != 0)
      {
        verifi = 10 - (aux % 10);
      }
      else
        verifi = 0;
      if (verifi == int.Parse(validarCedula[9].ToString()))
        return true;
      else
        return false;
    }

    private bool Validar()
    {
      bool resultado=true;
      if (new AccesoDatos.Usuario().ObtenerUsuario(txtIdentificacion.Text) != null)
      {
        resultado = false;
        lblMensaje.Text = "Usuario ya existe!";
      }
      if(ddlTipoIdentificacion.SelectedValue.Equals("CED"))
      {
        if (!VerificaCedula(txtIdentificacion.Text.ToArray()))
        {
          resultado = false;
          lblMensaje.Text = "No es una cedula correcta";
        }
      }
      return resultado;
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
      lblMensaje.Text = String.Empty;
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
        if (Validar())
        {
          new AccesoDatos.Usuario().Insert(usuario);
          Response.Redirect("Usuarios");
        }
      }
      else
      {
        new AccesoDatos.Usuario().Update(usuario);
        Response.Redirect("Usuarios");
      }
      
    }
  }
}