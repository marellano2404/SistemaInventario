﻿using Microsoft.Extensions.DependencyInjection;
//using Almacen.Core.Models.EmpresaEGM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.Core.Helpers
{
    /// <summary>
    /// Clase usada para inicializar valores default en la base de datos.
    /// </summary>
    public static class DatabaseInitializer
    {
        /// <summary>
        /// Inicializa los registros default en la base de datos.
        /// </summary>
        /// <param name="serviceProvider">IServiceProvider</param>
        public static void Inicializar(IServiceProvider serviceProvider)
        {
            //var context = serviceProvider.GetRequiredService<SIADbContext>();
            //context.Database.EnsureCreated();


            //context.SaveChanges();
        }
    }
}
