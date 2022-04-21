using System.Collections.Generic;
using System.Threading.Tasks;

namespace netImoveis.Models
{
    public interface IImoveisUseCase
    {
        Task<IEnumerable<Imoveis>> Execute();
    }
}
