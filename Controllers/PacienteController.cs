using BackEndPacientes.Dominio;
using BackEndPacientes.Negocio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPacientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private IDataApi DataApi;
            
        public PacienteController()
        {
            DataApi = new DataApi();      
        }

        [HttpGet ("Ver todos los pacientes")]
        public IActionResult GetPacientes()
        {
            return Ok(DataApi.GetPacientes());
        }

        
        [HttpPost ("Agregar paciente")]
        public IActionResult PostPaciente(Paciente paciente)
        {
           try
            {
                if (paciente == null)
                    return BadRequest("Faltan datos para poder registrar el paciente!");
                if (DataApi.InsertarPacientes(paciente))
                    return Ok("El paciente fue registrado con exito!");
                else
                    return Ok("El paciente no pudo ser registrado!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        [HttpPut("Modificar pacientes")]
        public IActionResult PutPaciente (Paciente paciente)
        {
            try
            {
                if (paciente == null)
                    return BadRequest("Los datos ingresados no pertenecen a un paciente registrado");

                if (DataApi.UpdatePacientes(paciente))
                    return Ok("El paciente pudo ser ediado con exito!");
                else
                    return Ok("El paciente no pudo ser modificado");
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        [HttpDelete("Eliminar pacientes")]
        public IActionResult DeletePaciente(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Ingrese el codigo del paciente que quiere eliminar");

                if (DataApi.DeletePacientes(id))
                    return Ok("El paciente fue eliminada con exito!");
                else
                    return Ok("El paciente no pudo ser eliminada");

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
