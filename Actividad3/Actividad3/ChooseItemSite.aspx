<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChooseItemSite.aspx.cs" Inherits="Actividad3.ChooseItemSite" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Asegurate de incluir CSS y JS de Bootstrap 5 -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row justify-content-start">
            <asp:Repeater ID="rptArticulos" runat="server">
                <ItemTemplate>
                    <div class="col-auto mb-4">
                        <div class="card" style="width: 18rem;">

                          
                            <div id="carousel<%# Eval("IdArt") %>" class="carousel slide" data-bs-ride="carousel">
                                <div class="carousel-inner">
                                    <asp:Repeater ID="rptImagenes" runat="server">
                                        <ItemTemplate>
                                            <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                                <img src='<%# Eval("ImagenUrl") %>' class="d-block w-100" alt="Imagen del artículo" style="max-height: 200px; object-fit: contain;">
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Eval("IdArt") %>" data-bs-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Anterior</span>
                                </button>
                                <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Eval("IdArt") %>" data-bs-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Siguiente</span>
                                </button>
                            </div>

                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <asp:Button ID="btnElegirPremio" runat="server" CssClass="btn btn-primary"
                                    Text="Elegir premio" OnClick="btnElegirPremio_Click"
                                    CommandArgument='<%# Eval("IdArt") %>' />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>