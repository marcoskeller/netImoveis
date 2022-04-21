using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using netImoveis.Models;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using _Imoveis = netImoveis.Models.Imoveis;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace netImoveis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client = new HttpClient();

        //private readonly IImoveisUseCase _imoveisUseCase;


        //public HomeController(IImoveisUseCase imoveisUseCase, ILogger<HomeController> logger)
        //{
        //    _imoveisUseCase = imoveisUseCase;
        //    _logger = logger;

        //}

        //public HomeController(IImoveisUseCase imoveisUseCase)
        //{
        //    _imoveisUseCase = imoveisUseCase;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}


        public async Task<IActionResult> IndexAsync()
        {
            string url = "https://6260672292df0bc0f343f117.mockapi.io/api/teste/imoveis";
            var response = await client.GetStringAsync(url);
            var model = new ExibicaoImoveisViewModel();

            try
            {
                var imoveis = JsonConvert.DeserializeObject<List<dynamic>>(response);

                if (imoveis != null)
                {
                    model.ListaImoveis = imoveis;
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return View(model);
            
        }

        public async Task<IActionResult> SobreNosAsync()
        {
            return View();
        }

 

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
            string url = "https://6260672292df0bc0f343f117.mockapi.io/api/teste/imoveis";
            var response = await client.GetStringAsync(url);
            var model = new ExibicaoImoveisViewModel();

            try
            {             
                var imoveis = JsonConvert.DeserializeObject<List<dynamic>>(response);
                
                if (imoveis != null)
                {
                    model.ListaImoveis = imoveis;
                }
                                 
            }
            catch (Exception e)
            {
                throw e;
            }

            return View(model);
        }
    


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
