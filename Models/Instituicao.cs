using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Instituicao
    {
        [Key]
        public int InstituicaoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        public virtual ICollection<Departamento>? Departamentos { get; set; }
    }
}
