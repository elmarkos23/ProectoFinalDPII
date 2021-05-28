<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="AplicacionWeb.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-success">
        <div class="panel-heading">
            <h3 class="panel-title">Datos del Usuario</h3>
        </div>
        <div class="panel-body">

            <div class="row">
                <div class="col-md-4">Id</div>
                <div class="col-md-4"><asp:Label runat="server" ID="lblID" Text="0" /></div>
                <div class="col-md-4"></div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <p>Tipo Identificacion</p>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddlTipoIdentificacion" CssClass="form-control">
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
                    <asp:TextBox runat="server" ID="txtIdentificacion" CssClass="form-control" />
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator runat="server" ID="rfvIdentificacion" ControlToValidate="txtIdentificacion" ErrorMessage=" * Ingrese campo" ValidationGroup="Guardar" CssClass="text text-danger" /></div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <p>Nombres</p>
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtNombres" CssClass="form-control" />
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtNombres" ErrorMessage=" * Ingrese campo" ValidationGroup="Guardar" CssClass="text text-danger" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <p>Apellidos</p>
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="txtApellidos" CssClass="form-control" />
                </div>
                <div class="col-md-4">
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtApellidos" ErrorMessage=" * Ingrese campo" ValidationGroup="Guardar" CssClass="text text-danger" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <p>Genero</p>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddlGenero" CssClass="form-control">
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
                    <asp:DropDownList runat="server" ID="ddlDepartamento" CssClass="form-control" DataValueField="id" DataTextField="nombre">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4"></div>
            </div>
            <div class="row">
                <div class="col-md-4"><p>Estado</p></div>
                <div class="col-md-4">
                    <asp:CheckBox ID="chkEstado" Text="Activo" runat="server" Checked="true" /></div>
                <div class="col-md-4"></div>
            </div>
            <hr />
            <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="Guardar" />
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </div>
</asp:Content>
