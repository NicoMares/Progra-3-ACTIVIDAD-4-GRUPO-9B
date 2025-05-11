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
                        
            listaArticulos = l_articulo.Listar();

        }

        protected void btnElegirPremio_Click(object sender, EventArgs e)
        {
            string codigo = Request.QueryString["codigo"];
            int idArt = int.Parse(((Button)sender).CommandArgument);
            L_Voucher logica = new L_Voucher();
            if(logica.ArticuloVinculadoAVoucher(idArt))
            Response.Redirect("RegisterSite.aspx?id=" + idArt);
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Este premio ya fue canjeado');", true);
            }
        }












    }
}