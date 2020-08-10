using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiAspNetEF.Data;
using apiAspNetEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiAspNetEF.Controllers {
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase {
             
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context) {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context, //Recebe do serviço um DataContext pra ser injetado
            [FromBody] Category model) { //Recebe uma categoria do corpo da requisiçao
            if (ModelState.IsValid) { //valindando a categoria
                context.Categories.Add(model); // Add a categorie a model
                await context.SaveChangesAsync();
                return model;
            } else {
                return BadRequest(ModelState);//Retorna os erros
            }
        }
    }
}
