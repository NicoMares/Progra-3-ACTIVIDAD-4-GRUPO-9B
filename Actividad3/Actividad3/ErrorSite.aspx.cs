using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Actividad3
{
    public partial class ErrorSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string error = Request.QueryString["error"];
                string mensaje = "";

                switch (error)
                {
                    case "voucher_canjeado":
                        mensaje = "El voucher ya fue canjeado.";
                        break;
                    case "voucher_inexistente":
                        mensaje = "El voucher no existe.";
                        break;
                    case "error_al_guardar":
                        mensaje = "Error al registrar el canje.";
                        break;
                    case "excepcion_general":
                        mensaje = "Ocurrió un error inesperado. Intente más tarde.";
                        break;
                    case "articulo_canjeado":
                        mensaje = "El artículo ya fue canjeado con otro voucher.";
                        break;
                    case "cliente_no_encontrado":
                        mensaje = "El cliente no fue encontrado.";
                        break;
                    case "session_invalida":
                        mensaje = "La sesión ha expirado o no es válida.";
                        break;
                    case "dni_invalido":
                        mensaje = "El DNI ingresado no es válido.";
                        break;
                    case "datos_incompletos":
                        mensaje = "Faltan datos obligatorios. Complete todos los campos.";
                        break;
                    case "email_invalido":
                        mensaje = "El formato del correo electrónico es incorrecto.";
                        break;
                    case "sin_articulos":
                        mensaje = "No hay mas productos, lo sentimos.";
                        break;
                    default:
                        mensaje = "Error desconocido.";
                        break;
                }

                lblMensaje.Text = mensaje;
            }



        }
    }
}