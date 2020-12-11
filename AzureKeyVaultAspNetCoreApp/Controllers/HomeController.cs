using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using AzureKeyVaultAspNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AzureKeyVaultAspNetCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                string keyVaultUri = "https://my-key-vault-20201211.vault.azure.net/";
                SecretClient client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());

                string secret = client.GetSecretAsync("secretColour", "3da1dc6d45ca4777b7a212921aed0d88").Result.Value.Value;
                ViewBag.secretColour = secret;

            }
            catch (Exception ex)
            {
                throw ex; 
            }


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
