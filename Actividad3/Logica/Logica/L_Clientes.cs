using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Logica
{
    public class L_Clientes
    {
        public bool ExisteDni(string DNI)
        {
            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("SELECT COUNT(*) FROM Clientes WHERE Documento = @Documento");
                conexion.SetParametros("@Documento", DNI);

                conexion.Ejecutar();

                if (conexion.Lector.Read())
                {
                    int cantidad = Convert.ToInt32(conexion.Lector[0]);
                    if (cantidad > 0)
                        return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }


    


    
        public E_Clientes BuscarClientePorDni(string DNI)
        {
            ConexionSql conexion = new ConexionSql();
            E_Clientes cliente = null;

            try
            {
                
                conexion.Consulta("SELECT Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @Documento");
                conexion.SetParametros("@Documento", DNI);

                conexion.Ejecutar();

                if (conexion.Lector.Read())  
                {
                  
                    cliente = new E_Clientes()
                    {
                        Documento = conexion.Lector["Documento"].ToString(),
                        Nombre = conexion.Lector["Nombre"].ToString(),
                        Apellido = conexion.Lector["Apellido"].ToString(),
                        Email = conexion.Lector["Email"].ToString(),
                        Direccion = conexion.Lector["Direccion"].ToString(),
                        Ciudad = conexion.Lector["Ciudad"].ToString(),
                        CP = Convert.ToInt32(conexion.Lector["CP"])
                    };
                }

                return cliente;  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();  
            }
        }
    }





}
