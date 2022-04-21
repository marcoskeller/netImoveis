using System;
using System.ComponentModel.DataAnnotations;

namespace netImoveis.Models
{
    public class Imoveis
    {
        public Guid Id { get; set; }
       
        public string TipoImovel { get; set; }
        
        public decimal ValorVenda { get; set; }
        
        public decimal ValorLocacao { get; set; }
        
        public double AreaConstruida { get; set; }

        public string Endereco { get; set; }
        
        public string Numero { get; set; }
        
        public string Complemento { get; set; }
        
        public string Bairro { get; set; }
        
        public string Cidade { get; set; }
        
        public string Estado { get; set; }
        
        public string Cep { get; set; }
    }

    public class UsuarioLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} esta em formato inválido")]
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string TipoImovel { get; set; }
    }
}




