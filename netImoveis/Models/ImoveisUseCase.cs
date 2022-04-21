using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netImoveis.Models
{
    public class ImoveisUseCase : IImoveisUseCase
    {
        private readonly ILogger<ImoveisUseCase> _logger;
        private readonly IImoveisRepository _imoveisRepository;
        

        public ImoveisUseCase(IImoveisRepository imoveisRepository, ILogger<ImoveisUseCase> logger)
        {
            _imoveisRepository = imoveisRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Imoveis>> Execute()
        {
            try
            {
                var imoveis = await _imoveisRepository.List();
                return imoveis;



            }
            catch(ValidationException e)
            {
                var errMsg = e.Message.ToArray();
                return (IEnumerable<Imoveis>)errMsg.ToList();
            }
        }
    }
}
