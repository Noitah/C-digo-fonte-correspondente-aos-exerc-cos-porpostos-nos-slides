using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [DisplayName("Instituição")]
        public int InstituicaoID { get; set; }

        public Instituicao? Instituicao { get; set; }

        public virtual ICollection<Curso>? Cursos { get; set; }
    }
}
