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
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('El voucher ya fue canjeado');", true);
                    }

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('El voucher no existe');", true);

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}