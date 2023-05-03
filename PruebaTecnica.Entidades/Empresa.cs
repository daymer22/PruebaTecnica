﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Entidades
{
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }

        [Required]
        [MaxLength(50), MinLength(5)]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "int(12)")]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(25), MinLength(5)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(11), MinLength(6)]
        public string Telefono { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string Ciudad { get; set; }

        [Required]
        [MaxLength(20), MinLength(5)]
        public string Departamento { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public DateTime FechaModificacion{ get; set; }
    }
}