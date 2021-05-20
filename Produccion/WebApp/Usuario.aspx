<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="AplicacionWeb.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-success">
        <div class="panel-heading">
            <h3 class="panel-title">Datos del Usuario</h3>
        </div>
        <div class="panel-body">

            <div class="row">
                <div class="col-md-4">
                    <p>Tipo Identificacion</p>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" CssClass="form-control">
                        <asp:ListItem Text="CEDULA" Value="CED" />
                        <asp:ListItem Text="PASAPORTE" Value="PAS" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-4"></div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <p>Identificación</p>
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" /></div>
                <div class="col-md-4"></div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <p>Nombres</p>
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" /></div>
                <div class="col-md-4"></div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <p>Apellidos</p>
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" /></div>
                <div class="col-md-4"></div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <p>Genero</p>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" CssClass="form-control">
                        <asp:ListItem Text="SELECCIONE" Value="S" />
                        <asp:ListItem Text="HOMBRE" Value="H" />
                        <asp:ListItem Text="MUJER" Value="M" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-4"></div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <p>Departamento</p>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" CssClass="form-control" DataValueField="id" DataTextField="nombre">
                        <asp:ListItem Text="SELECCIONE" Value="S" />

                    </asp:DropDownList>
                </div>
                <div class="col-md-4"></div>
            </div>
            <hr />
            <a href="#" class="btn btn-success">Guardar</a>
        </div>
    </div>
</asp:Content>
