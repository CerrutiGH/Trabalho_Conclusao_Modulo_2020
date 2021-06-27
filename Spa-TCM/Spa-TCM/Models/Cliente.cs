using System.ComponentModel.DataAnnotations;

namespace Spa_TCM.Models
{

    public class Cliente
    {

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o seu email", AllowEmptyStrings = false)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 4)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\((?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "Insira um telefone válido")]
        [Required(ErrorMessage = "Telefone deve seguir o formato \"(DD) XXXXX-XXXX\" ", AllowEmptyStrings = false)]
        public string Telefone { get; set; }

    }
}