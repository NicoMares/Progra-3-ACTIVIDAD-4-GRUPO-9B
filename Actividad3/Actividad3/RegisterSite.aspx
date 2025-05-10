<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegisterSite.aspx.cs" Inherits="Actividad3.RegisterSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5">

        
        <div class="text-center mb-4">
            <h3>Ingrese sus datos</h3>
        </div>

        
        <div class="row justify-content-center mb-4">
            <div class="col-md-auto">
                <label for="txtDNI" class="form-label">DNI</label>
                <div class="input-group">
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="12345678" />
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>

        
        <div class="row justify-content-center">
            <div class="col-md-8">

                
                <div class="row g-3 mb-3">
                    <div class="col-md-4">
                        <label for="txtNombre">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Juan" />
                    </div>
                    <div class="col-md-4">
                        <label for="txtApellido">Apellido</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Pérez" />
                    </div>
                    <div class="col-md-4">
                        <label for="txtEmail">Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="juan.perez@mail.com" />
                    </div>
                </div>

                
                <div class="row g-3 mb-4">
                    <div class="col-md-6">
                        <label for="txtDireccion">Dirección</label>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Calle Falsa 123" />
                    </div>
                    <div class="col-md-4">
                        <label for="txtCiudad">Ciudad</label>
                        <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" placeholder="Buenos Aires" />
                    </div>
                    <div class="col-md-2">
                        <label for="txtCP">Código Postal</label>
                        <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" placeholder="1602" />
                    </div>
                </div>

            
                <div class="text-center">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
