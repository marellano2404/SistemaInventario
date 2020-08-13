﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Core.Models
{
    [Table("HistorialUsuarios", Schema = "Seguridad")]
    public partial class HistorialUsuarios
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? IdUsuario { get; set; }
        public int? Entradas { get; set; }
        [StringLength(150)]
        public string Describe { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaHora { get; set; }
        public bool? Validado { get; set; }
    }
}
