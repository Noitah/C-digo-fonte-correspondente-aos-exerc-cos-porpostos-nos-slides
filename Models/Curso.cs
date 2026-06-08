using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Curso
    {
        [Key]
        public int CursoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Carga Horária")]
        public int CargaHoraria { get; set; }

        [DisplayName("Departamento")]
        public int DepartamentoID { get; set; }

        public Departamento? Departamento { get; set; }
    }
}
