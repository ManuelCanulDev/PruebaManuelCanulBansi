using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WsApiExamen.Models;
using System.Collections.Generic;

namespace WsApiExamen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamenController : ControllerBase
    {
        // AGREGAR EXAMEN
        [HttpPost("agregar")]
        public IActionResult AgregarExamen([FromBody] Examen model)
        {
            using (var db = new ExamenContext())
            {
                try
                {
                    db.Examenes.Add(model);
                    db.SaveChanges();

                    return Ok(new
                    {
                        Exito = true,
                        DescripcionRetorno = "Registro insertado correctamente"
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        Exito = false,
                        DescripcionRetorno = ex.InnerException?.Message ?? ex.Message
                    });
                }
            }
        }

        // ACTUALIZAR EXAMEN
        [HttpPut("actualizar")]
        public IActionResult ActualizarExamen([FromBody] Examen model)
        {
            using (var db = new ExamenContext())
            {
                try
                {
                    var examen = db.Examenes.FirstOrDefault(x => x.idExamen == model.idExamen);

                    if (examen == null)
                    {
                        return NotFound(new
                        {
                            Exito = false,
                            DescripcionRetorno = "Registro no encontrado"
                        });
                    }

                    examen.Nombre = model.Nombre;
                    examen.Descripcion = model.Descripcion;

                    db.SaveChanges();

                    return Ok(new
                    {
                        Exito = true,
                        DescripcionRetorno = "Registro actualizado correctamente"
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        Exito = false,
                        DescripcionRetorno = ex.Message
                    });
                }
            }
        }

        // ELIMINAR EXAMEN
        [HttpDelete("eliminar/{id}")]
        public IActionResult EliminarExamen(int id)
        {
            using (var db = new ExamenContext())
            {
                try
                {
                    var examen = db.Examenes.FirstOrDefault(x => x.idExamen == id);

                    if (examen == null)
                    {
                        return NotFound(new
                        {
                            Exito = false,
                            DescripcionRetorno = "Registro no encontrado"
                        });
                    }

                    db.Examenes.Remove(examen);
                    db.SaveChanges();

                    return Ok(new
                    {
                        Exito = true,
                        DescripcionRetorno = "Registro eliminado correctamente"
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        Exito = false,
                        DescripcionRetorno = ex.Message
                    });
                }
            }
        }

        // CONSULTAR EXAMEN
        [HttpGet("consultar")]
        public IActionResult Consultar()
        {
            using (var db = new ExamenContext())
            {
                var data = db.Examenes.ToList();
                return Ok(data);
            }
        }
    }
}