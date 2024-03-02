using System.ComponentModel.DataAnnotations;

namespace WebAgendamento.Model
{
    public class CadastroServico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tipo Serviço Obrigatorio")]
        public string TipoServico { get; set; }

        [Required(ErrorMessage = "Valor Obrigatorio")]
        public decimal Valor { get; set; }


    }
}
