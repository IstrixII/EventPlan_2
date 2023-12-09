using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Teste1.Models;
using Teste1.Views.Logins;

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
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Perfil()
        {
            return View("Perfil");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Login(Pessoa pessoa)
        //{
        //    try
        //    {
        //        this.repository.comparacao(pessoa);
        //        return RedirectToAction(nameof(Perfil));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}



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
            if (pessoa.Senha != pessoa.ConfirmacaoSenha)
            {
                ModelState.AddModelError("ConfirmacaoSenha", "A senha e a confirmação de senha não correspondem.");
                return View();
            }
            if (this.repository.EmailExists(pessoa.Email))
            {
                ModelState.AddModelError("Email", "O email já está cadastrado.");
                return View();
            }
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

        //[HttpPost]
        //public IActionResult Login(Models.LoginModel loginModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Pessoa pessoa = GetPessoaByEmail(loginModel.Email);

        //        if (pessoa != null && pessoa.Senha == loginModel.Senha)
        //        {
        //            HttpContext.Session.SetInt32("UserId", pessoa.Id_pessoa);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            // Display invalid login error message
        //            ViewBag.ErrorMessage = "Email ou Senha invalidos";
        //        }
        //    }

        //    return View(loginModel);
        //}







    }
}


    

