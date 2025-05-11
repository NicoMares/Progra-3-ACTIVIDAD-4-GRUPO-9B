<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChooseItemSite.aspx.cs" Inherits="Actividad3.ChooseItemSite" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container mt-4">
        <div class="row justify-content-start">
      
            

<asp:Repeater ID="rptArticulos" runat="server">
    <ItemTemplate>
        <div class="col-auto mb-4">
            <div class="card" style="width: 18rem;">
                <img src="<%# Eval("ImagenUrl.ImagenUrl") %>" class="card-img-top" alt="..." 
                     style="width: 100%; max-height: 200px; height: auto; object-fit: contain;">
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
