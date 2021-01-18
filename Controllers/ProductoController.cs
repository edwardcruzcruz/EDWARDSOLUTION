using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDWARDSOLUTIONApi.Contexts;
using EDWARDSOLUTIONApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDWARDSOLUTIONApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDBContext context;

        public  ProductoController(AppDBContext context)
        {
            this.context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return context.Producto.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(string id)
        {
            var producto = context.Producto.FirstOrDefault(p=>p.pro_codigo==id);
            return producto;
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            try
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Producto producto)
        {
            if(producto.pro_codigo == id)
            {
                context.Entry(producto).State = EntityState.Modified;
                context.SaveChanges();
                return Ok(); 
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var producto = context.Producto.FirstOrDefault(p => p.pro_codigo == id);
            if(producto != null){
                context.Producto.Remove(producto);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
