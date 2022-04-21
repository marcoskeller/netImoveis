using System.Collections.Generic;
using _Imoveis = netImoveis.Models.Imoveis;

namespace netImoveis.Models
{
    public class ExibicaoImoveisViewModel
    {
        public List<dynamic> ListaImoveis { get; set; }

        public ExibicaoImoveisViewModel()
        {
            ListaImoveis = new List<dynamic>();
        }
    }
}
