<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="Actividad3.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center mt-5">
        <asp:Label ID="lblSuccess" runat="server" Text="¡Voucher canjeado exitosamente!" CssClass="alert alert-success fw-bold d-block"></asp:Label>
        <asp:Button ID="btnVolver" runat="server" Text="Volver al inicio" CssClass="btn btn-primary mt-3" PostBackUrl="~/Default.aspx" />
    </div>
</asp:Content>
