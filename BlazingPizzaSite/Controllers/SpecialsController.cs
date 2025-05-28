using BlazingPizza.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Controllers
{
    [Route("api/specials")]
    [ApiController]
    public class SpecialsController : ControllerBase
    {
        private readonly PizzaStoreContext db;

        public SpecialsController(PizzaStoreContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecialsAsync()
        {
            return (await db.Specials.ToListAsync()).OrderByDescending(x => x.Name).ToList();
        } 
    }
}
