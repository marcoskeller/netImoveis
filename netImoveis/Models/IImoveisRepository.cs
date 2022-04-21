
using System.Collections.Generic;
using System.Threading.Tasks;

namespace netImoveis.Models
{
    public interface IImoveisRepository
    {
        Task<IEnumerable<Imoveis>> List();
    }
}
