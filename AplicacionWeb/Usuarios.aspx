<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="AplicacionWeb.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Lista de Usuarios</h3>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon">Buscar</span>
                    <input type="text" class="form-control">
                    <span class="input-group-btn">
                        <button class="btn btn-primary" type="button">Buscar</button>
                        <button class="btn btn-success" type="button">Agregar</button>
                    </span>
                </div>
            </div>
            <asp:Panel runat="server" ScrollBars="Vertical"> 
                <asp:GridView runat="server" ID="gvDatos" CssClass="table">
                    <Columns>
                        <asp:ButtonField HeaderText="Editar" CommandName="Editar" Text="<span class='glyphicon glyphicon-pencil' aria-hidden='true'></span>" ControlStyle-CssClass="btn btn-primary btn-sm" ItemStyle-Width="40" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>


        </div>
    </div>
</asp:Content>
