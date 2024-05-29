using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using oechsle.MODELO;
using oechsle.CONTROLADOR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace oechsle.API_CLIENTES
{
    [Produces("application/json")]
    [Route("api/Clientes")]
    public class UserController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public UserController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        [HttpGet]
        [Route("GetClientes")]
        public IActionResult GetClientes(Int id, int operacion)
        {
            //Si operacion es 0 devolvera lo siguiente segun el valor del id
            
            //Si id es 0 devolvera toda la lista de clientes
            //Si id es diferente de 0 devolvera el cliente segun el id encontrado

            //Si operacion es 1 devolvera los 3 clientes con mayor edad
            
            var data = oechsle.CONTROLADOR.DA_CLIENTES.ListarClientes(id,operacion);
            return Ok(data);
        }

        [HttpPost]
        [Route("SaveClientes")]
        public IActionResult SaveClientes(Int id,int nombre, string apellidos,date fecha_nac)
        {
            string msg = ''
            var data = oechsle.CONTROLADOR.DA_CLIENTES.RegistrarClientes(id,nombre,apellidos,fecha_nac);
            if (data == "0")
            {
                    msg = "Cliente registrado correctamente.";
            }
            else if (data == "1")
            {
                    msg = "Cliente ya existe.";
            }
            return Ok(msg);
        }
    }
}