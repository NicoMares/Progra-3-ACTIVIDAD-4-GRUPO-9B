using Entidades;
using Logica;
using Logica.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Actividad3
{
    public partial class ChooseItemSite : System.Web.UI.Page
    {
        public List<E_Articulo> listaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            L_Articulo l_articulo = new L_Articulo(); 
            L_Voucher voucher = new L_Voucher();
            listaArticulos = l_articulo.Listar();

           
      List<Entidades.E_Articulo> listaFiltrada = listaArticulos
    .Where(a => !(voucher.ArticuloVinculadoAVoucher(a.IdArt))) 
    .GroupBy(a => a.IdArt) 
    .Select(g => g.First()) 
    .ToList();


            rptArticulos.DataSource = listaArticulos;
            rptArticulos.DataBind();
        }

        protected void btnElegirPremio_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;

            if (btn != null)
            {
                
                if (int.TryParse(btn.CommandArgument, out int idArt))
                {
                 
                    L_Voucher logica = new L_Voucher();
                    if (!(logica.ArticuloVinculadoAVoucher(idArt)))
                    {
                        Response.Redirect("RegisterSite.aspx?id=" + idArt);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
                            "alert('Este premio ya fue canjeado');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup",
                        "alert('Error al procesar el premio.');", true);
                }
            }


        }












    }
}