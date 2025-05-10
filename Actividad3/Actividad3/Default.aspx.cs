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

            string codigo = txtCodigo.Text;

            try
            {


                Response.Redirect("ChooseItemSite.aspx");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}