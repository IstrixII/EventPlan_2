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
        public IActionResult Details(int id_pessoa)
        {
            return View(this.repository.getByIdPessoa(id_pessoa));
        }



        [HttpGet]
        public IActionResult Edit(int id_pessoa)
        {
            return View(this.repository.getByIdPessoa(id_pessoa));
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id_pessoa, Pessoa pessoa)
        {
            try
            {
                this.repository.updatePessoa(id_pessoa, pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id_pessoa)
        {
            this.repository.deleteUser(id_pessoa);
            return RedirectToAction(nameof(Index));
        }
    }
}
