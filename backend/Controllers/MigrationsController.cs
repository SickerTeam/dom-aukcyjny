
using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    public class MigrationsController(DatabaseContext context) : ControllerBase
    {
        private readonly DatabaseContext _context = context;

        [HttpPost("applyMigrations")]
        public IActionResult ApplyMigrations()
        {
            var migrationsApplied = _context.ApplyMigrations();

            if(migrationsApplied.Any())
            {
                var stringList = string.Join(", ", migrationsApplied);

                var message = $"Applied migrations: {stringList}";

                return Ok(message);
            }

            return Ok("No pending migrations");
        }
    }
}