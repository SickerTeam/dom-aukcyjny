
using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    public class MigrationsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MigrationsController(DatabaseContext context)
        {
            _context = context;
        }

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