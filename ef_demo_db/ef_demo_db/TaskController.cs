using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ef_demo_db.Models;

namespace ef_demo_db
{
    public class TaskController : Controller
    {
        private readonly ef_demo_dbContext _context;

        public TaskController(ef_demo_dbContext context) {  _context = context; }

        public async Task<ActionResult> Index()
        {
            return  View(await _context.Teachers.ToListAsync());
        }
        
    }
}
