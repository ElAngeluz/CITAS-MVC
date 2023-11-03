using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace citas.Models.Entities
{
    public abstract class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Cedula { get; set; }
        [StringLength(25)]
        public string Nombres { get; set; }
        [StringLength(25)]
        public string ApellidoMaterno { get; set; }
        [StringLength(25)]
        public string ApellidoPaterno { get; set; }
        [StringLength(250)]
        public string Direccion { get; set; }
        [StringLength(15)]
        public string Telefono { get; set; }
        [StringLength(5)]
        public string Tipo_Identidad { get; set; }
        [StringLength(5)]
        public string Tipo_Sangre { get; set; }
    }
}
