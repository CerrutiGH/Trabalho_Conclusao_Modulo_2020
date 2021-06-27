using Spa_TCM.connection;
using Spa_TCM.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace Spa_TCM.Controllers
{
    public class HomeController : Controller
    {
        Acoes acoes = new Acoes();

        // GET: Home
        public ActionResult OnePage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult OnePage(Cliente cadastro)
        {
            if (ModelState.IsValid)
            {
                acoes.CadastroCliente(cadastro);
                return Redirect("~/Home/OnePage");
            }

            return View(cadastro);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarUsuario(FuncionarioData f)
        {
            //ENVIANDO OS DADOS DO FORM PARA SEREM CHECADOS NO BANCO
            acoes.TestarUsuario(f);

            if (f.EMAIL_FUN != null && f.SENHA_FUN != null && f.CARGO_FUN != null)
            {
                FormsAuthentication.SetAuthCookie(f.EMAIL_FUN, false);

                Session["EmailLogado"] = f.EMAIL_FUN.ToString();
                Session["SenhaLogada"] = f.SENHA_FUN.ToString();


                return RedirectToAction("MenuPrincipal", "Crud");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Logout()
        {
            Session["EmailLogado"] = null;
            return RedirectToAction("Login", "Home");
        }




    }
}