using Dapper;
using HandleBudgets2.Models;
using HandleBudgets2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HandleBudgets2.Controllers
{
    public class AccountTypesController : Controller
    {
        private readonly string connectionString;
        private readonly IRepositoryAccountTypes repositoryAccountTypes;

        //temporal
        public AccountTypesController(IRepositoryAccountTypes repositoryAccountTypes)
        {
            this.repositoryAccountTypes = repositoryAccountTypes;
        }
        public IActionResult Create()
        {
                return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AccountType accountType)
        {
            if (!ModelState.IsValid)
            {
                return View(accountType);
            }

            accountType.UserId = 1;

            var existsAccountType = await repositoryAccountTypes.Exists(accountType.Name, accountType.UserId);

            if (existsAccountType)
            {
                ModelState.AddModelError(nameof(accountType.Name), $"El nombre {accountType.Name} ya existe");
                return View(accountType);
            }

            await repositoryAccountTypes.Create(accountType);
            return View();
        }

        public async Task<IActionResult> VerifyExistAccountType(string name)
        {
            var existsAccountType = await repositoryAccountTypes.Exists(name, 1);
            if (existsAccountType)
            {
                return Json($"El nombre {name} ya existe wachin.");
            }
            return Json(true);
        }
    }
}
