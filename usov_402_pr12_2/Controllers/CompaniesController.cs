using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using usov_402_pr12_2.Data;

namespace usov_402_pr12_2.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }
    }
}
