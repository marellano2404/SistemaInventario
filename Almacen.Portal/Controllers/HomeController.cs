using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Almacen.Portal.Helpers;
using Almacen.Portal.Models;

namespace Almacen.Portal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult _menuPartial()
        {
            return PartialView();
        }
        public IActionResult _Loading()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AutentificarUser([FromBody] LoginViewModel Usuarioview)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    StringContent content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(Usuarioview), System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage result = httpClient.PostAsync($"{GlobalConfig.ApisUrl}Seguridad/AutenticarUsuario", content).Result;

                    string resultContent = result.Content.ReadAsStringAsync().Result;

                    var token = Newtonsoft.Json.JsonConvert.DeserializeObject<JWTViewModel>(resultContent);

                    if (token.RFC != "Credenciales no válidas")
                    {
                        AuthenticationProperties options = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            IsPersistent = true,
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(120)
                        };
                        var claims = new[]
                        {
                            new Claim("AcessToken", token.Token),
                            new Claim(ClaimTypes.Name, token.RFC)
                        };
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
                        claimsPrincipal.AddIdentity(new ClaimsIdentity(claims, "Password"));

                        await HttpContext.SignInAsync(claimsPrincipal, options);
                    }
                    return Ok(token);
                }
                catch (Exception ex)
                {
                    return Ok(ex.Message);
                }
            }
        }
        /// <summary>
        /// Cierra sesión del usuario autenticado.
        /// </summary>
        /// <returns>Objeto con el resultado de la operación realizada.</returns>
        [Authorize]
        [HttpGet]
        public IActionResult CerrarSesion()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }
    }
}
