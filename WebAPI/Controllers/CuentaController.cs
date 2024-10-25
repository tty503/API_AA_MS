using Application.CuentaApp;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CuentaController : MyControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Cuenta>>> GetAll()
        {
            return await mediator.Send(new Consulta.ListaCuentas());
        }
    }
}
