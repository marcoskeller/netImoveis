using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using netImoveis.Models;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using _Imoveis = netImoveis.Models.Imoveis;

namespace netImoveis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImoveisUseCase _imoveisUseCase;


        public HomeController(IImoveisUseCase imoveisUseCase, ILogger<HomeController> logger)
        {
            _imoveisUseCase = imoveisUseCase;
            _logger = logger;

        }

        //public HomeController(IImoveisUseCase imoveisUseCase)
        //{
        //    _imoveisUseCase = imoveisUseCase;
        //}

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        public IActionResult SobreNos()
        {
            return View();
        }

        //[HttpGet]
        //public async  IActionResult BuscarImoveis()
        //{
        //    return View();
        //}


        [HttpGet]
        [Route("imoveis")]
        public IActionResult ExibicaoImoveis(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(_Imoveis[]))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ErrorViewModel))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorViewModel))]
        public async Task<IActionResult> ListaImoveis()
        {
            var response = await _imoveisUseCase.Execute();
            return ((IActionResult)response);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
