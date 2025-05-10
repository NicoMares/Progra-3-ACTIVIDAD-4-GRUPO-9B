<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChooseItemSite.aspx.cs" Inherits="Actividad3.ChooseItemSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <% foreach (Entidades.E_Articulo art in listaArticulos)
        {
    %>
            <div class="card" style="width: 18rem;">
                <img src="<%:art.ImagenUrl.ImagenUrl%>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: art.Nombre %></h5>
                    <p class="card-text"><%:art.Descripcion %></p>
        
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
    <%   } %>
</asp:Content>
