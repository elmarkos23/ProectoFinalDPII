<%@ Page Title="Reporte" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="AplicacionWeb.Reporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br />
    <div class="panel panel-warning">
  <div class="panel-heading">
    <h3 class="panel-title">Reporte de Asistencia</h3>
  </div>
  <div class="panel-body">
    <div></div>
      <hr />
      <rsweb:ReportViewer ID="rvReporte" runat="server" Width="100%" Height="400"></rsweb:ReportViewer>
  </div>
</div>
</asp:Content>
