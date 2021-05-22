using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWeb
{
  public partial class Reporte : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        CargarReporte();  
      }
    }
    private void CargarReporte()
    {
      List<Modelos.Dto.DtoReporte> dtoReportes = new List<Modelos.Dto.DtoReporte>();
      dtoReportes = new AccesoDatos.DtoPersonalizado().SelectReporte();


      DataTable dtImagenes = new DataTable();
      DataTable dtServicios = new DataTable();
      rvReporte.LocalReport.Refresh();
      rvReporte.LocalReport.DataSources.Clear();
      rvReporte.LocalReport.EnableExternalImages = true;
      rvReporte.ProcessingMode = ProcessingMode.Local;
      rvReporte.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/" + Path.Combine("Reports", "ReporteAsistencia.rdlc"));

     // dtLogo = Util.Settings.GetLogo(HttpContext.Current.Server.MapPath("~/" + Path.Combine("Images", "logo_repcon.png")));
     // byte[] imagenCheck = Util.Settings.GetImagen(HttpContext.Current.Server.MapPath("~/" + Path.Combine("Images", "check_blue.png")));

      dtServicios.Columns.Add("identificacion", typeof(string));
      dtServicios.Columns.Add("nombres", typeof(string));
      dtServicios.Columns.Add("fecha", typeof(string));
      dtServicios.Columns.Add("hora", typeof(string));
      dtServicios.Columns.Add("tipo", typeof(string));
      dtServicios.Columns.Add("ubicacionReferencial", typeof(string));
      dtServicios.Columns.Add("departamento", typeof(string));
      dtServicios.Columns.Add("foto", typeof(byte[]));
      dtServicios.Columns.Add("latlng", typeof(string));




      foreach (var item in dtoReportes)
      {
        dtServicios.Rows.Add(item.identificacion,
          item.nombres,
          item.fecha,
          item.hora,
          item.tipo,
          item.ubicacionReferencial,
          item.departamento,
          item.foto,
          item.latlng
          );
      }

      ReportDataSource rdsTareas = new ReportDataSource("dsReporte", dtServicios);

      var parameters = new List<ReportParameter>();

      //parameters.Add(new ReportParameter("varCode", reportActivity.activity.Id.ToString()));
      
      rvReporte.LocalReport.DataSources.Add(rdsTareas);
      rvReporte.LocalReport.SetParameters(parameters);

      rvReporte.LocalReport.Refresh();

    }
  }
}