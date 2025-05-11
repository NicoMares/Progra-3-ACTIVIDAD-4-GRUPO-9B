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
        E_Clientes aux = new E_Clientes();
        L_Clientes aux2 = new L_Clientes();
        protected void Page_Load(object sender, EventArgs e)
        {

            lblStatusMessage.Visible = false;
            lblStatusMessage.Text = string.Empty;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

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

                    lblStatusMessage.Text = "Participante no encontrado. Por favor, ingrese sus datos.";
                    lblStatusMessage.CssClass = "alert alert-warning";
                    lblStatusMessage.Visible = true;

                    txtNombre.Enabled = true;
                    txtApellido.Enabled = true;
                    txtEmail.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtCiudad.Enabled = true;
                    txtCP.Enabled = true;

                    btnGuardar.Visible = true;
                    btnParticipar.Visible = false;
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

                    txtNombre.Enabled = true;
                    txtApellido.Enabled = true;
                    txtEmail.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtCiudad.Enabled = true;
                    txtCP.Enabled = true;

                    lblStatusMessage.Text = "¡Participante encontrado!";
                    lblStatusMessage.CssClass = "alert alert-success";  // Estilo para mensaje de éxito
                    lblStatusMessage.Visible = true;

                    // Mostrar el botón de "Participar" y ocultar el de "Guardar"
                    btnGuardar.Visible = false;
                    btnParticipar.Visible = true;

                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.CssClass = "alert alert-danger mt-3";
            lblError.Visible = false;

            string dni = txtDNI.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string email = txtEmail.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();
            string cp = txtCP.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                lblError.Text = "El nombre no puede estar vacío.";
                lblError.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(apellido))
            {
                lblError.Text = "El apellido no puede estar vacío.";
                lblError.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
            {
                lblError.Text = "El email no es válido.";
                lblError.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(direccion))
            {
                lblError.Text = "La dirección no puede estar vacía.";
                lblError.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(ciudad))
            {
                lblError.Text = "La ciudad no puede estar vacía.";
                lblError.Visible = true;
                return;
            }

            if (!int.TryParse(cp, out int codigoPostal) || codigoPostal <= 0)
            {
                lblError.Text = "El código postal debe ser un número válido mayor que 0.";
                lblError.Visible = true;
                return;
            }


            aux.Nombre = nombre;
            aux.Documento = dni;
            aux.Apellido = apellido;
            aux.Email = email;
            aux.Direccion = direccion;
            aux.Ciudad = ciudad;
            aux.CP = codigoPostal;

            if (aux2.AgregarCliente(aux))

            {
                lblError.CssClass = "alert alert-success mt-3";
                
                lblError.Visible = true;

                ProcesarCanje();
            }
            else
            {
                lblError.Text = "Hubo un error al agregar el cliente. Intente nuevamente.";
                lblError.Visible = true;
            }


        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            ProcesarCanje();
        }

        private void ProcesarCanje()
        {
            L_Voucher lVoucher = new L_Voucher();
            L_Clientes lCliente = new L_Clientes();

            string codigoVoucher = Session["codigoVoucher"] as string;
            object idArticuloObj = Session["IdArticulo"];
            string dni = txtDNI.Text.Trim();

            if (string.IsNullOrEmpty(codigoVoucher) || idArticuloObj == null)
            {
                Response.Redirect("ErrorSite.aspx?error=session_invalida", false);
                return;
            }

            int idArticulo = (int)idArticuloObj;
            E_Clientes cliente = lCliente.BuscarClientePorDni(dni);

            if (cliente == null)
            {
                Response.Redirect("ErrorSite.aspx?error=cliente_no_encontrado", false);
                return;
            }

            E_Vouchers voucherActualizado = new E_Vouchers
            {
                CodigoVoucher = codigoVoucher,
                IdCliente = cliente.id,
                FechaCanje = DateTime.Now,
                IdArticulo = idArticulo
            };

            bool exito = lVoucher.RegistrarCanje(voucherActualizado);

            if (exito)
            {
                Response.Redirect("success.aspx", false);
            }
            else
            {
                Response.Redirect("ErrorSite.aspx?error=error_al_guardar");
            }
        }



    }
}