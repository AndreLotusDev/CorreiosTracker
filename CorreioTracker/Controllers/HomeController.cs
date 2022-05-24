using CorreioTracker.DomainModels;
using CorreioTracker.Models;
using CorreioTracker.Repository.Areas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace CorreioTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TrackingConsult(TrackingModel model)
        {
            model.Codigo = model.Codigo?.Trim();

            try
            {
                var html = await FormataCorreios(model.Codigo);

                if (string.IsNullOrEmpty(html))
                    return BadRequest();

                return Ok(html);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        private async Task<string> FormataCorreios(string code)
        {
            HttpClient request = new HttpClient();
            request.Timeout = TimeSpan.FromMilliseconds(10000);

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, $"https://www2.correios.com.br/sistemas/rastreamento/ctrl/ctrlRastreamento.cfm?");

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("acao", "track"),
                new KeyValuePair<string, string>("objetos", code)
            });

            message.Content = formContent;

            var response = await request.PostAsync(message.RequestUri, message.Content);

            var htmlContent = await response.Content.ReadAsStringAsync();
            
            //Formatacao
            int earlyPosition = htmlContent.IndexOf(@"<table class=""listEvent sro"">");
            htmlContent = htmlContent.Substring(earlyPosition, htmlContent.Length - earlyPosition);
            int finalPosition = htmlContent.IndexOf("Nova Consulta");

            htmlContent = htmlContent.Remove(finalPosition, htmlContent.Length - finalPosition);

            return htmlContent;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
