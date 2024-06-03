using HandleBudgets2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HandleBudgets2.Controllers
{
    public class AccountTypesController : Controller
    {
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
