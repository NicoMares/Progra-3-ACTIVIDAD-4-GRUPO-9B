using Logica.Logica;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Actividad3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            L_Voucher l_Voucher = new L_Voucher();
            string codigo = txtCodigo.Text;

            try
            {
                if (l_Voucher.ExisteVoucher(codigo))
                {
                    if (l_Voucher.VoucherVigente(codigo))
                    {
                        Session["codigoVoucher"] = codigo;
                        Response.Redirect("ChooseItemSite.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("ErrorSite.aspx?error=voucher_canjeado", false);
                    }

                }
                else
                {

                    Response.Redirect("ErrorSite.aspx?error=voucher_inexistente", false);

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}