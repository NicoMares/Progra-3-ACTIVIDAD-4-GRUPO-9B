﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace Entidades
{
    public class E_Articulo
    {
        public int  IdArt { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public E_Marca Marca { get; set; }
        public E_Categoria Categoria { get; set; }
        public E_Imagen ImagenUrl { get; set; }



    }
}
