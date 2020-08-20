using Almacen.Core.BL.Articulos.Interface;
using Almacen.Core.ViewModels;
using Almacen.Core.ViewModels.Auxiliars;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.Articulos.Services
{
    public class ArticuloService : IArticulo
    {
        public async Task<Articulo> ObtenerArticulo(string Id)
        {
            using (var conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                Articulo respuesta = new Articulo();
                try
                {
                    var command = new SqlCommand();
                    command.Connection = conexion;
                    command.CommandText = "Catalogos.ObtenerArticulos";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OP", "ObtenerArticulo");
                    command.Parameters.AddWithValue("@IdArticulo", Id);
                    conexion.Open();
                    var lectura = await command.ExecuteReaderAsync();
                    if (lectura.HasRows) //que tenga renglones
                    {
                        while (lectura.Read())
                        {
                            respuesta.Id = lectura.GetGuid(0);
                            respuesta.Descripcion = lectura.GetString(1);
                            respuesta.ClaveProducto = lectura.GetString(2);
                            respuesta.Detalles = lectura.GetString(3);
                            respuesta.Presentacion = lectura.GetString(4);
                            respuesta.Marca = lectura.GetString(5);
                            respuesta.Modelo = lectura.GetString(6);
                            respuesta.TipoMedicamento = lectura.GetInt32(7);
                            respuesta.TipoCatalogo = lectura.GetString(8);
                            respuesta.UnidadMedida = lectura.GetInt32(9);
                            respuesta.CantidadPorUnidad = lectura.GetInt32(10);
                            respuesta.CodigoBarras = lectura.GetString(11);
                            respuesta.Laboratorio = lectura.GetInt32(12);
                            respuesta.Estado = lectura.GetInt32(13);
                        }
                    }
                    conexion.Close();
                    return respuesta;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                    return respuesta;
                }
            }
        }

        public async Task<List<Articulo>> ObtenerArticulos(Pagination P)
        {
            using (var conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                List<Articulo> Lista = new List<Articulo>();
                try
                {
                    var command = new SqlCommand();
                    command.Connection = conexion;
                    command.CommandText = "Catalogos.ObtenerArticulos";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OP", "ObtenerArticulos");
                    command.Parameters.AddWithValue("@total", P.total);
                    command.Parameters.AddWithValue("@paginaActual", P.paginaActual);
                    conexion.Open();
                    var lectura = await command.ExecuteReaderAsync();
                    if (lectura.HasRows) //que tenga renglones
                    {
                        while (lectura.Read())
                        {
                            Lista.Add(
                                new ViewModels.Articulo
                                {
                                    Id = lectura.GetGuid(0),
                                    Descripcion = lectura.GetString(1),
                                    ClaveProducto = lectura.GetString(2),
                                    Detalles = lectura.GetString(3),
                                    Presentacion = lectura.GetString(4),
                                    Marca = lectura.GetString(5),
                                    Modelo = lectura.GetString(6),
                                    TipoMedicamento = lectura.GetInt32(7),
                                    TipoCatalogo = lectura.GetString(8),
                                    UnidadMedida = lectura.GetInt32(9),
                                    CantidadPorUnidad = lectura.GetInt32(10),
                                    CodigoBarras = lectura.GetString(11),
                                    Laboratorio = lectura.GetInt32(12),
                                    Estado = lectura.GetInt32(13)
                                });
                        }
                    }
                    conexion.Close();
                    return Lista;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                    return Lista;
                }
            }
        }
    }
}
