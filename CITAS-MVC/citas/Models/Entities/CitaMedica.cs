﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace citas.Models.Entities
{
    public class CitaMedica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(1000)]
        public string Notas { get; set; }
        public string Titulo { get; set; }
        [StringLength(500)]
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }

        [JsonIgnore]
        public Guid PacienteId { get; set; }
        [ForeignKey(nameof(PacienteId))]
        public virtual Paciente? PacienteNav { get; set; }
    }
}
