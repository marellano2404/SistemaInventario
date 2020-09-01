using Almacen.Core.BL.SalidasAlmacen.Interfaces;
using Almacen.Core.Models;
using Almacen.Core.ViewModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Almacen.Core.BL.SalidasAlmacen.Services
{
    public class SalidasAlmacenService : ISalidasAlmacen
    {
        public async Task<ArticulosInventarioVM> BuscarArticuloInventario(string tipo, string valor)
        {
            using (var Conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                var resultado = new ArticulosInventarioVM();
                try
                {
                    var comando = new SqlCommand();
                    comando.Connection = Conexion;
                    comando.CommandText = "[Almacen].[BuscarArticuloInventario]";
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    /*Agregando los parametros*/
                    comando.Parameters.AddWithValue("@Valor", valor.Trim());
                    comando.Parameters.AddWithValue("@TipoBusqueda", tipo.Trim());

                    Conexion.Open();
                    var Lectura = await comando.ExecuteReaderAsync();
                    if (Lectura.HasRows)
                    {
                        while (Lectura.Read())
                        {
                            resultado.IdInventario = Lectura.GetGuid(0);
                            resultado.IdArticulo = Lectura.GetGuid(1);
                            resultado.ClaveProducto = Lectura.GetString(2);
                            resultado.CodigoBarras = Lectura.GetString(3);
                            resultado.Descripcion = Lectura.GetString(4);
                            resultado.Detalles = Lectura.GetString(5);                            
                            resultado.FechaCaducidad = Lectura.GetDateTime(6);
                            resultado.TipoCatalogo = Lectura.GetString(7);
                            resultado.ExistenciasUnidad = Lectura.GetInt32(8);
                            resultado.Cantidad = Lectura.GetInt32(9);
                            resultado.ClaveInventario = Lectura.GetString(10);
                            resultado.Estado = Lectura.GetString(11);
                        }
                    }
                    Conexion.Close();
                    return resultado;

                }
                catch (Exception e)
                {
                    var m = e.Message.ToString();
                    throw e;
                }
            }
        }

        public async Task<bool> CerrarSalidaAlmacen(Guid idSalida)
        {
            using (var conexion = new InventarioDbContext())
            {
                var resul = new ResultViewModel();
                var consulta = await (from e in conexion.SalidasAlmacen where e.Id == idSalida select e).FirstOrDefaultAsync();
                if (consulta != null)
                {
                    consulta.Estatus = 1;
                    return await conexion.SaveChangesAsync() > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<ResultViewModel> DelDetalleSalidaAlmacen(Guid idDetalleSalidaAlmacen)
        {
            using (var Conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                string Tipo = "EliminarArticulo";
                var resultado = new ResultViewModel();
                try
                {
                    var comando = new SqlCommand();
                    comando.Connection = Conexion;
                    comando.CommandText = "Almacen.DetallesSalidasAlmacen";
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    /*Agregando los parametros*/
                    comando.Parameters.AddWithValue("@Opcion", Tipo);
                    comando.Parameters.AddWithValue("@Id", idDetalleSalidaAlmacen);
                    Conexion.Open();
                    var Lectura = await comando.ExecuteReaderAsync();
                    if (Lectura.HasRows)
                    {
                        while (Lectura.Read())
                        {
                            resultado.Exito = Lectura.GetBoolean(0);
                            resultado.Mensaje = Lectura.GetString(1);
                        }
                    }
                    Conexion.Close();
                    return resultado;

                }
                catch (Exception e)
                {
                    var m = e.Message.ToString();
                    return resultado;
                }
            }
        }

        public async Task<List<DetalleSalidaViewModel>> GetDetalleSalidaAlmacen(string folio)
        {
            using (var Conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                var listaEntradas = new List<DetalleSalidaViewModel>();
                try
                {
                    var comando = new SqlCommand();
                    comando.Connection = Conexion;
                    comando.CommandText = "[Almacen].[GetDetallesSalidasAlmacen]";
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    /*Agregando los parametros*/
                    comando.Parameters.AddWithValue("@Folio", folio.Trim());

                    Conexion.Open();
                    var Lectura = await comando.ExecuteReaderAsync();
                    if (Lectura.HasRows)
                    {
                        while (Lectura.Read())
                        {
                            DetalleSalidaViewModel resultado = new DetalleSalidaViewModel();
                            resultado.ClaveProducto = Lectura.GetString(0);
                            resultado.CodigoBarras = Lectura.GetString(1);
                            resultado.Descripcion = Lectura.GetString(2);
                            resultado.Cantidad = Lectura.GetInt32(3);
                            resultado.Detalles = Lectura.GetString(4);
                            resultado.Unidad = Lectura.GetString(5);
                            resultado.FechaCaducidad = Lectura.GetDateTime(6);
                            resultado.TipoCatalogo = Lectura.GetString(7);
                            resultado.ExistenciasUnidad = Lectura.GetInt32(8);
                            resultado.Estado = Lectura.GetInt32(9);
                            resultado.IdSalidaAlmacen = Lectura.GetGuid(10);
                            listaEntradas.Add(resultado);
                        }
                    }
                    Conexion.Close();
                    return listaEntradas;

                }
                catch (Exception e)
                {
                    var m = e.Message.ToString();
                    throw e;
                }
            }
        }

        public async Task<List<SalidasAlmacenViewModel>> GetSalidasAlmacen(int estado)
        {
            using (var Conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                var listaEntradas = new List<SalidasAlmacenViewModel>();
                try
                {
                    var comando = new SqlCommand();
                    comando.Connection = Conexion;
                    comando.CommandText = "[Almacen].[GetSalidasAlmacen]";
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    /*Agregando los parametros*/
                    comando.Parameters.AddWithValue("@Estado", estado);
                    comando.Parameters.AddWithValue("@IdSalida", null);

                    Conexion.Open();
                    var Lectura = await comando.ExecuteReaderAsync();
                    if (Lectura.HasRows)
                    {
                        while (Lectura.Read())
                        {
                            SalidasAlmacenViewModel resultado = new SalidasAlmacenViewModel();
                            resultado.Id = Lectura.GetGuid(0);
                            resultado.Folio = Lectura.GetString(1);
                            resultado.FechaCaptura = Lectura.GetDateTime(2);
                            resultado.FechaSalida = Lectura.GetDateTime(3);
                            resultado.Farmacia = Lectura.GetString(4);
                            resultado.Almacen = Lectura.GetString(5);
                            resultado.Responsable = Lectura.GetString(6);
                            resultado.Exito = true;
                            resultado.Mensaje = "";
                            listaEntradas.Add(resultado);
                        }
                    }
                    Conexion.Close();
                    return listaEntradas;

                }
                catch (Exception e)
                {
                    var m = e.Message.ToString();
                    throw e;
                }
            }
        }

        public async Task<ResultViewModel> PutDetalleSalidaAlmacen(ArticuloSalidaAlmacenVM articuloSalidaAlmacen)
        {
            using (var Conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                string Tipo = "AgregarArticulo";
                var resultado = new ResultViewModel();
                try
                {
                    var comando = new SqlCommand();
                    comando.Connection = Conexion;
                    comando.CommandText = "Almacen.DetallesSalidasAlmacen";
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    /*Agregando los parametros*/
                    comando.Parameters.AddWithValue("@Opcion", Tipo);
                    comando.Parameters.AddWithValue("@IdSalidaAlmacen", articuloSalidaAlmacen.IdSalidaAlmacen);
                    comando.Parameters.AddWithValue("@IdInventario", articuloSalidaAlmacen.IdInventario);
                    comando.Parameters.AddWithValue("@IdArticulo", articuloSalidaAlmacen.IdArticulo);
                    comando.Parameters.AddWithValue("@Cantidad", articuloSalidaAlmacen.CantidadSalida);
                    comando.Parameters.AddWithValue("@TipoUnidad", articuloSalidaAlmacen.TipoUnidad);
                    Conexion.Open();
                    var Lectura = await comando.ExecuteReaderAsync();
                    if (Lectura.HasRows)
                    {
                        while (Lectura.Read())
                        {
                            resultado.Exito = Lectura.GetBoolean(0);
                            resultado.Mensaje = Lectura.GetString(1);
                        }
                    }
                    Conexion.Close();
                    return resultado;

                }
                catch (Exception e)
                {
                    var m = e.Message.ToString();
                    return resultado;
                }
            }
        }
    }
}
