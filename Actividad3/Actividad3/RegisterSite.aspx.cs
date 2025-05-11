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
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string email = txtEmail.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();
            string cp = txtCP.Text.Trim();

            // Validaciones básicas
            if (string.IsNullOrEmpty(nombre))
            {
                
                Response.Write("El nombre no puede estar vacío.<br>");
                return;
            }

            if (string.IsNullOrEmpty(apellido))
            {
                Response.Write("El apellido no puede estar vacío.<br>");
                return;
            }

            if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
            {
                Response.Write("El email no es válido.<br>");
                return;
            }

            if (string.IsNullOrEmpty(direccion))
            {
                Response.Write("La dirección no puede estar vacía.<br>");
                return;
            }

            if (string.IsNullOrEmpty(ciudad))
            {
                Response.Write("La ciudad no puede estar vacía.<br>");
                return;
            }

            if (!int.TryParse(cp, out int codigoPostal) || codigoPostal <= 0)
            {
                Response.Write("El código postal debe ser un número válido mayor que 0.<br>");
                return;
            }

            // Si todas las validaciones pasan, podés guardar
            // aux.Nombre = nombre; etc.

            Response.Write("Datos guardados correctamente.");
            Response.Redirect("Default.aspx");
        }
    }
}