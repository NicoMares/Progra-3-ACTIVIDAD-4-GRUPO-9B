<%@ Page Title="Promo Gana !" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Actividad3.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center mt-5 mb-5">

        <div class="row justify-content-center align-items-center">
            <div class="col-auto">

                <h4>Ingrese su codigo ! </h4>
            </div>
            <div class="col-auto">

                <asp:TextBox ID="txtCodigo" runat="server" placeholder="Cacatua08" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
                <a href="RegisterSite.aspx" >Ir al otro formulario</a>
            </div>

            <div  class="col-auto">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" type="button" CssClass="btn btn-success" />
            </div>

        </div>
    </div>

</asp:Content>
