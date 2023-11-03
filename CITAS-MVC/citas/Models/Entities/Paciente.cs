using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace citas.Models.Entities
{
    public class Paciente : Persona
    {
        public string CodigoPaciente { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(AlergiaPaciente.PacienteNav))]
        public ICollection<AlergiaPaciente>? AlegiasPacienteNav { get; set; }
    }
}
