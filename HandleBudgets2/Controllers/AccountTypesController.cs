using HandleBudgets2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HandleBudgets2.Controllers
{
    public class AccountTypesController : Controller
    {
        private readonly string connectionString;
        //temporal
        public AccountTypesController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AccountType accountType)
        {
            if (!ModelState.IsValid)
            {
                return View(accountType);
            }
            return View();
        }
    }
}
