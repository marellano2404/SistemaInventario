using Almacen.Core.BL.Catalogos.Interface;
using Almacen.Core.ViewModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.BL.Catalogos.Services
{
    public class LaboratorioService : ILaboratorio
    {
        public async Task<List<LaboratorioViewModel>> ObtenerLaboratorios()
        {
            using (var conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                List<LaboratorioViewModel> Lista = new List<LaboratorioViewModel>();
                try
                {
                    var command = new SqlCommand();
                    command.Connection = conexion;
                    command.CommandText = "Catalogos.ObtenerLaboratorios";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OP", "ObtenerLaboratorios");
                    conexion.Open();

                    var lectura = await command.ExecuteReaderAsync();
                    if (lectura.HasRows) //que tenga renglones
                    {
                        while (lectura.Read())
                        {
                            Lista.Add(
                                new LaboratorioViewModel
                                {
                                    Id = lectura.GetInt32(0),
                                    Descripcion = lectura.GetString(1)
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
