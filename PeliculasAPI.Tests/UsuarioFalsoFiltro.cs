using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace PeliculasAPI.Tests
{
    public class UsuarioFalsoFiltro : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Email, "example@hotmail.com"),
                new Claim(ClaimTypes.Name, "example@hotmail.com"),
                new Claim(ClaimTypes.NameIdentifier, "5e8b75cf-6c6b-4c89-84e5-008558094386")
            }, "prueba"));

            await next();
        }
    }
}
