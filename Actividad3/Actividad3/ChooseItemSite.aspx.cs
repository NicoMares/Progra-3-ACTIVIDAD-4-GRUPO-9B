﻿using Entidades;
using Logica;
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
    }
}