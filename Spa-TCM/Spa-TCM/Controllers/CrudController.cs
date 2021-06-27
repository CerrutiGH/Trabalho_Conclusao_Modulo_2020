using Spa_TCM.connection;
using Spa_TCM.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Spa_TCM.Controllers
{
    public class CrudController : Controller
    {
        FuncionarioData f = new FuncionarioData();
        Acoes acoes = new Acoes();

        // GET: Crud

        public ActionResult ListarFuncionario()
        {
            var ExibirFun = new Acoes();
            var AllFun = ExibirFun.ListarFuncionario();
            return View(AllFun);
        }

        public ActionResult CadastroFun()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroFun(FuncionarioData cadastro)
        {
            if (ModelState.IsValid)
            {
                acoes.CadastroFuncionario(cadastro);
                return RedirectToAction("ListarFuncionario", "Crud");
            }
            return View(cadastro);
        }





        public ActionResult EditFun()
        {
            return View();
        }

        public ActionResult UpdateFuncionario(FuncionarioData f, int id)
        {
            id = Convert.ToInt32(Request.Url.Segments.Last());
            acoes.UpdateFuncionario(f, id);
            return RedirectToAction("ListarFuncionario", "Crud");
        }




        public ActionResult DeleteFun(FuncionarioData f, int id)
        {
            id = Convert.ToInt32(Request.Url.Segments.Last());
            acoes.DeleteFuncionario(f, id);
            return RedirectToAction("ListarFuncionario", "Crud");
        }



        public ActionResult RegistrarReserva()
        {
            return View();
        }



        [HttpPost]
        public ActionResult RegistrarReserva(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                acoes.MarcarReserva(reserva);
                return RedirectToAction("ListarReservas", "Crud");
            }
            return View();
        }


        public ActionResult ListarReservas()
        {
            var ExibirRes = new Acoes();
            var AllRes = ExibirRes.ListarReservas();
            return View(AllRes);
        }



        public ActionResult EditReserva()
        {
            return View();
        }

        public ActionResult UpdateReserva(Reserva r, int id)
        {
            id = Convert.ToInt32(Request.Url.Segments.Last());
            acoes.UpdateReservas(r, id);
            return RedirectToAction("ListarReservas", "Crud");
        }




        public ActionResult DeleteReserva(Reserva r, int id)
        {
            id = Convert.ToInt32(Request.Url.Segments.Last());
            acoes.DeleteReserva(r, id);
            return RedirectToAction("ListarReservas", "Crud");
        }



        public ActionResult MenuPrincipal(FuncionarioData f)
        {
            ViewBag.IsAdm = true;


            acoes.TestarUsuario(f);
            if (f.CARGO_FUN != null)
            {
                Session["CargoAcesso"] = f.CARGO_FUN;
            }
            return View();
        }


        /*
        public ActionResult ValidarEmailUnico(string Email)
        {
            var emailDisponivel = CadastroFun.Usuarios.Where(u => u.Email == Email).Count() == 0;
            return Json(emailDisponivel, JsonRequestBehavior.AllowGet);
        }
        */
    }



}

