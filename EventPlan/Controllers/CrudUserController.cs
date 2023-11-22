using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Teste1.Models;

namespace Teste1.Controllers
{
    public class CrudUserController : Controller
    {
        private readonly Repositories.ADO.SQLServer.EventPlanDAO repository;

        public CrudUserController(IConfiguration configuration)
        {
            this.repository = new Repositories.ADO.SQLServer.EventPlanDAO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(this.repository.getAll());
        }



        [HttpGet]
        public IActionResult Edit(int idPessoa)
        {
            return View(this.repository.getByIdPessoa(idPessoa));
        }

        // POST : CarrosController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int idPessoa, Pessoa pessoa)
        {
            try
            {
                this.repository.updatePessoa(idPessoa, pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
