<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ErrorSite.aspx.cs" Inherits="Actividad3.ErrorSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center mt-5">
        <asp:Label ID="lblMensaje" runat="server" CssClass="display-4 text-danger"></asp:Label>
        <br />
        <a href="Default.aspx" class="btn btn-primary mt-4">Volver al inicio</a>
    </div>
</asp:Content>