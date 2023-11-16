using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Teste1.Models;

namespace Teste1.Controllers
{
    public class LoginsController : Controller
    {
        private readonly Repositories.ADO.SQLServer.EventPlanDAO repository;

        public LoginsController(IConfiguration configuration)
        {
            this.repository = new Repositories.ADO.SQLServer.EventPlanDAO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
        }

        // GET: Login
        [HttpGet]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Perfil()
        {
            return View("Perfil");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Pessoa pessoa)
        {
            try
            {
                this.repository.comparacao(pessoa);
                return RedirectToAction(nameof(Perfil));
            }
            catch
            {
                return View();
            }
        }



        // GET: Login/Cadastro
        [HttpGet]
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }


        // POST: Login/Cadastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(Pessoa pessoa)
        {
            try
            {
                this.repository.add(pessoa);
                return RedirectToAction(nameof(Perfil));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult AlterarSenha()
        {
            return View("UpdateSenha");
        }


        // POST: Login/Cadastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AlterarSenha(Pessoa pessoa)
        {
            try
            {
                this.repository.updateSenha(pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    this.repository.deleteUser(id);
        //    return RedirectToAction(nameof(Index));
        //}




    }
}


    

