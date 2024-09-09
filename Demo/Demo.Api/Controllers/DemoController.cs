using Demo.Datos;
using Demo.Entidades.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IDemoDatos _demoDatos;

        public DemoController(IDemoDatos demoDatos )
        {
            _demoDatos = demoDatos;
        }
        [HttpPost]
        public int Nuevo(DemoEntidad demoEntidad)
        {
            return _demoDatos.Nuevo(demoEntidad);
        }
        [HttpGet]
        public List<DemoEntidad> Obtener()
        {
            return _demoDatos.Obtener();
        }
        [HttpDelete]
        public int Eliminar(int id)
        {
            return _demoDatos.Eliminar(id);
        }
    }
}
