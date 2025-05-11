<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChooseItemSite.aspx.cs" Inherits="Actividad3.ChooseItemSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container mt-4">
        <div class="row justify-content-start">
            <% Entidades.E_Articulo aux = null; %> 


            <% foreach (Entidades.E_Articulo art in listaArticulos) { %>
                <% if (aux == null || aux.IdArt != art.IdArt) { %> 
                    <div class="col-auto mb-4">
                        <div class="card" style="width: 18rem;">
                            <img src="<%: art.ImagenUrl.ImagenUrl %>" class="card-img-top" alt="..." style="width: 100%; max-height: 200px; height: auto; object-fit: contain;">
                            <div class="card-body">
                                <h5 class="card-title"><%: art.Nombre %></h5>
                                <p class="card-text"><%: art.Descripcion %></p>
                                <asp:Button ID="btnElegirPremio" runat="server" CssClass="btn btn-primary" Text="Elegir premio" OnClick="btnElegirPremio_Click" CommandArgument='<%: art.IdArt %>' />
                            </div>
                        </div>
                       
                    </div>
                <% } %>
                <% aux = art; %> 
            <% } %>
        </div>
    </div>

       
</asp:Content>
