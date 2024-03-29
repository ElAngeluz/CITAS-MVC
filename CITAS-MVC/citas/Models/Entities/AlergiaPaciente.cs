﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace citas.Models.Entities
{
    public class AlergiaPaciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public Guid PacienteId { get; set; }
        [ForeignKey(nameof(PacienteId))]
        public virtual Paciente? PacienteNav { get; set; }
    }
}
