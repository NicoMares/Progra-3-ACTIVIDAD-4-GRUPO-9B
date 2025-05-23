using Entidades;
using Logica;
using Logica.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Actividad3
{
    public partial class ChooseItemSite : System.Web.UI.Page
    {
        public List<E_Articulo> listaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                L_Articulo l_articulo = new L_Articulo();
                L_Voucher voucher = new L_Voucher();

                listaArticulos = l_articulo.Listar();

                List<E_Articulo> listaFiltrada = listaArticulos
                    .Where(a => !voucher.ArticuloVinculadoAVoucher(a.IdArt))
                    .GroupBy(a => a.IdArt)
                    .Select(g => g.First())
                    .ToList();

                rptArticulos.ItemDataBound += rptArticulos_ItemDataBound;

                rptArticulos.DataSource = listaFiltrada;
                rptArticulos.DataBind();

                if (listaFiltrada.Count == 0)
                {
                    Response.Redirect("ErrorSite.aspx?error=sin_articulos", false);
                }
            }
        }

        protected void rptArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                E_Articulo articulo = (E_Articulo)e.Item.DataItem;
                var rptImagenes = (Repeater)e.Item.FindControl("rptImagenes");

                if (rptImagenes != null)
                {
                    L_Imagen l_imagen = new L_Imagen();
                    List<E_Imagen> listaImagenes = l_imagen.ListarImagenesPorID(articulo.IdArt);
                    rptImagenes.DataSource = listaImagenes;
                    rptImagenes.DataBind();
                }
            }
        }

        protected void btnElegirPremio_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null && int.TryParse(btn.CommandArgument, out int idArt))
            {
                L_Voucher logica = new L_Voucher();

                if (!logica.ArticuloVinculadoAVoucher(idArt))
                {
                    Session["IdArticulo"] = idArt;
                    Response.Redirect("RegisterSite.aspx?id=" + idArt);
                }
                else
                {
                    Response.Redirect("ErrorSite.aspx?error=articulo_canjeado", false);
                }
            }
            else
            {
                Response.Redirect("ErrorSite.aspx?error=error_articulo", false);
            }
        }
    }
}