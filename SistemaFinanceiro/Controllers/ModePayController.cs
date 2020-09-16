using Model.Entity;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaFinanceiro.Controllers
{
    public class ModePayController : Controller
    {
        private ModePayNeg objModePayNeg;

        public ModePayController()
        {
            objModePayNeg = new ModePayNeg();
        }

        // GET: ModePay
        public ActionResult Index()
        {
            List<ModePay> list = new List<ModePay>();
            list = objModePayNeg.FindAll();
            return View(list);
        }

        // GET: ModePay/Details/5
        public ActionResult Details(int id)
        {
            ModePay objModePay = new ModePay(id);
            objModePayNeg.Find(objModePay);
            return View(objModePay);
        }

        // GET: ModePay/Create
        public ActionResult Create()
        {
            MessageStartRegister();
            return View();
        }

        // POST: ModePay/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModePay objModePay)
        {
            MessageStartRegister();
            objModePayNeg.Create(objModePay);
            MessageErrorRegister(objModePay);
            return View();
        }

        // GET: ModePay/Edit/5
        public ActionResult Edit(int id)
        {
            MessageInitialUpdate();
            ModePay objModePay = new ModePay(id);
            objModePayNeg.Find(objModePay);
            return View(objModePay);
        }

        // POST: ModePay/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModePay objModePay)
        {
            MessageInitialUpdate();
            objModePayNeg.Update(objModePay);
            MessageErrorUpdate(objModePay);
            return View();
        }

        // GET: ModePay/Delete/5
        public ActionResult Delete(int id)
        {
            MessageInitialEliminate();
            ModePay objModePay = new ModePay(id);
            objModePayNeg.Find(objModePay);
            return View(objModePay);
        }

        // POST: ModePay/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ModePay objModePay)
        {
            MessageInitialEliminate();
            objModePayNeg.Delete(objModePay);
            MessageErrorEliminate(objModePay);
            return View();
        }

        public void MessageErrorRegister(ModePay objModePay)
        {
            switch (objModePay.State)
            {
                case 20:
                    ViewBag.MessageError = "Insira o modo de pagamento";
                    break;

                case 2:
                    ViewBag.MessageError = "Só é permitido até 30 caracteres";
                    break;

                case 30:
                    ViewBag.MessageError = "Insira os outros detalhes do Modo de Pagamento";
                    break;

                case 3:
                    ViewBag.MessageError = "Só é permitido até 30 caracteres";
                    break;

                case 99:
                    ViewBag.MessageSucess = "O modo de pagamento ( " + objModePay.Name + " ) foi cadastrado com sucesso";
                    break;
            }
        }

        public void MessageErrorUpdate(ModePay objModePay)
        {
            switch (objModePay.State)
            {
                case 20:
                    ViewBag.MessageError = "Insira o Modo de Pagamento";
                    break;

                case 2:
                    ViewBag.MessageError = "Só é permitido até 30 caracteres";
                    break;

                case 30:
                    ViewBag.MessageError = "Insira os outros detalhes do Modo de Pagamento";
                    break;

                case 3:
                    ViewBag.MessageError = "Só é permitido até 30 caracteres";
                    break;

                case 99:
                    ViewBag.MessageSucess = "O modo de pagamento ( " + objModePay.Name + " ) foi atualizado com sucesso";
                    break;

            }
        }

        public void MessageErrorEliminate(ModePay objModePay)
        {
            switch (objModePay.State)
            {
                case 1:
                    ViewBag.MessageError = "Modo de Pagamento ( " + objModePay.IdModePay + " não existente ";
                    break;

                case 33:
                    ViewBag.MessageError = "Modo de Pagamento: ( " + objModePay.Name + " ) já foi excluído";
                    break;

                case 99:
                    ViewBag.MessageSucess = "Modo de Pagamento ( " + objModePay.Name + ") Foi Excluido!!!";
                    break;

                default:
                    ViewBag.MessageError = "===Deu Erro ???===";
                    break;
            }

        }

        public void MessageStartRegister()
        {
            ViewBag.MessageBegin = "Insira os dados do Modo de Pagamento e clique em Salvar";
        }

        public void MessageInitialUpdate()
        {
            ViewBag.MessageInitialUpdate = "Formulário para atualizar dados dos Modos de Pagamento"; 
        }

        public void MessageInitialEliminate()
        {
            ViewBag.MessageInitialEliminate = "Formulário de Exclusão";
        }
    }
}
