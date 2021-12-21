using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_funcionarios
{
  [Table("funcionarios")]
  public class Funcionario
  {
    [Key]
    public long id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    public string nome { get; set; }

    [Required(ErrorMessage = "O sobrenome é obrigatório")]
    public string sobrenome { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    public string email { get; set; }

    [Required(ErrorMessage = "O gênero é obrigatório")]
    public char genero { get; set; }

    [Required(ErrorMessage = "A cidade é obrigatória")]
    public string cidade { get; set; }

    [Required(ErrorMessage = "O país é obrigatório")]
    public string pais { get; set; }

    public string empresa { get; set; }
    public float salario { get; set; }
  }
}