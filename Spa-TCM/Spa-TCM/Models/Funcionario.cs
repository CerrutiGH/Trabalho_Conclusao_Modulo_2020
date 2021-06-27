using System.ComponentModel.DataAnnotations;

namespace Spa_TCM.Models
{
    public class FuncionarioData
    {
        public int COD_FUN { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string NOME_FUN { get; set; }

        [Required(ErrorMessage = "Informe o seu email", AllowEmptyStrings = false)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido")]
        [Display(Name = "Email")]
        public string EMAIL_FUN { get; set; }


        [Required(ErrorMessage = "A senha do usuário é obrigatória", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 4)]
        [Display(Name = "Senha")]
        public string SENHA_FUN { get; set; }

        [Display(Name = "Idade")]
        [Range(18, 100, ErrorMessage = "Você deve ter mais de 18 anos.")]
        public string IDADE_FUN { get; set; }

        //[Required]
        //[RegularExpression(@"/^[0-9]{3}.?[0-9]{3}.?[0-9]{3}-?[0-9]{2}/", ErrorMessage = "Insira um CPF válido.")]
        [Display(Name = "CPF")]
        public string CPF_FUN { get; set; }

        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\((?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "Insira um telefone válido")]
        [Required(ErrorMessage = "Telefone deve seguir o formato \"(DD) XXXXX-XXXX\" ", AllowEmptyStrings = false)]
        [Display(Name = "Telefone")]
        public string TELEFONE_FUN { get; set; }


        //[Required(ErrorMessage = "O nome do RG é obrigatório")]
        //[RegularExpression(@"/^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\-[0-9]{1}$/", ErrorMessage = "Insira um RG válido.")]
        [Display(Name = "RG")]
        public string RG_FUN { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        [Display(Name = "Cidade")]
        public string CIDADE_FUN { get; set; }

        [Required(ErrorMessage = "O Cargo é obrigatório")]
        [Display(Name = "Cargo")]
        public string CARGO_FUN { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "Insira um CEP válido.")]
        [Display(Name = "CEP")]
        public string CEP_FUN { get; set; }



    }





}