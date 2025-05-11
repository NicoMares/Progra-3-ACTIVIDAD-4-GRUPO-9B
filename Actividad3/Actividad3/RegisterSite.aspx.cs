using Entidades.Entidades;
using Logica.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Actividad3
{
    public partial class RegisterSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            E_Clientes aux = new E_Clientes();
            L_Clientes aux2 = new L_Clientes();

            
            string dni = txtDNI.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Ingrese un DNI valido.');", true);

            }
            else
            {
               
                if (!aux2.ExisteDni(dni))
                {
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEmail.Text = "";
                    txtDireccion.Text = "";
                    txtCiudad.Text = "";
                    txtCP.Text = "";

                }
                else
                {
                   
                    aux = aux2.BuscarClientePorDni(dni);

                   
                    txtNombre.Text = aux.Nombre;
                    txtApellido.Text = aux.Apellido;
                    txtEmail.Text = aux.Email;
                    txtDireccion.Text = aux.Direccion;
                    txtCiudad.Text = aux.Ciudad;
                    txtCP.Text = aux.CP.ToString();

                    
                    
                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}