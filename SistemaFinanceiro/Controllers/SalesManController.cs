using Model.Entity;
using Model.Neg;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaFinanceiro.Controllers
{
    public class SalesManController : Controller
    {
        private SalesManNeg objSalesManNeg;

        public SalesManController()
        {
            objSalesManNeg = new SalesManNeg();
        }

        // GET: SalesMan
        public ActionResult Index()
        {
            List<SalesMan> list = objSalesManNeg.findAll();
            return View(list);
        }

        // GET: SalesMan/Details/5
        public ActionResult Details(string id)
        {
            SalesMan objSalesMan = new SalesMan(id);
            objSalesManNeg.find(objSalesMan);
            return View(objSalesMan);
        }

        // GET: SalesMan/Create
        public ActionResult Create()
        {
            MessageInitialRegister();
            return View();
        }

        // POST: SalesMan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesMan objSalesMan)
        {
            MessageInitialRegister();
            objSalesManNeg.create(objSalesMan);
            MessageErroRRegisters(objSalesMan);
            ModelState.Clear();
            return View("Create");
        }

        // GET: SalesMan/Edit/5
        public ActionResult Edit(string id)
        {
            MessageInitialUpdate();
            SalesMan objSalesMan = new SalesMan(id);
            objSalesManNeg.find(objSalesMan);
            return View(objSalesMan);
        }

        // POST: SalesMan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalesMan objSalesMan)
        {
            MessageInitialUpdate();
            objSalesManNeg.update(objSalesMan);
            MessageErrorUpdate(objSalesMan);
            return View();
        }

        // GET: SalesMan/Delete/5
        public ActionResult Delete(string id)
        {
            MessageInitialEliminate();
            SalesMan objSalesMan = new SalesMan(id);
            objSalesManNeg.find(objSalesMan);
            return View(objSalesMan);
        }

        // POST: SalesMan/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SalesMan objSalesMan)
        {
            MessageInitialEliminate();
            objSalesManNeg.delete(objSalesMan);
            MessageErroREliminate(objSalesMan);
            return View();
        }

        public void MessageErroRRegisters(SalesMan objSalesMan)
        {

            switch (objSalesMan.State)
            {
                case 10://campo codigo vazio
                    ViewBag.MessageError = "Insira o código";
                    break;

                case 1://error campo codigo
                    ViewBag.MessageError = "Não se permite mais de 5 dígitos para o código";
                    break;

                case 20://campo nome vazio
                    ViewBag.MessageError = "Insira nome do Vendedor";
                    break;

                case 2://erro de nome
                    ViewBag.MessageError = "Não se permite mais de 50 digitos para nome";
                    break;

                case 30://campo cpf vazio
                    ViewBag.MessageError = "Insira CPF do Vendedor";
                    break;

                case 3://erro de cpf
                    ViewBag.MessageError = "Digite 11 digitos para o CPF";
                    break;

                case 40://campo telefone vazio
                    ViewBag.MessageError = "Insira o telefone do vendedor";
                    break;

                case 4://erro de telefone
                    ViewBag.MessageError = "Não é permitido mais que 15 caracteres para o telefone";
                    break;

                case 50://campo telefone vazio
                    ViewBag.MessageError = "Insira o endereço do vendedor";
                    break;

                case 5://erro de telefone
                    ViewBag.MessageError = "Não é permitido mais que 50 caracteres para o endereço";
                    break;

                case 8://erro de duplicidade
                    ViewBag.MessageError = "Vendedor ( " + objSalesMan.IdSalesMan + " ) já existe no Sistema";
                    break;

                case 99:// exito
                    ViewBag.MessageSucess = "Vendedor ( " + objSalesMan.IdSalesMan + " )  foi registrado no Sistema";
                    break;
            }

        }

        public void MessageErrorUpdate(SalesMan objSalesMan)
        {
            switch (objSalesMan.State)
            {
                case 10:
                    ViewBag.MessageError = "Insira o código";
                    break;

                case 1:
                    ViewBag.MessageError = "Não permite mais que 5 digitos para o código";
                    break;

                case 20:
                    ViewBag.MessageError = "Insira o nome do Vendedor";
                    break;

                case 2:
                    ViewBag.MessageError = "Não é permitido mais de 30 digitos para nome";
                    break;

                case 30:
                    ViewBag.MessageError = "Insira o cpf";
                    break;

                case 3:
                    ViewBag.MessageError = "Digite os 11 digitos para o CPF";
                    break;

                case 40:
                    ViewBag.MessageError = "Insira o número de telefone";
                    break;

                case 4:
                    ViewBag.MessageError = "Não é permitido mais que 15 caracteres no campo telefone";
                    break;

                case 50:
                    ViewBag.MessageError = "Insira o endereço";
                    break;

                case 5:
                    ViewBag.MessageError = "Não é permitido mais de 30 digitos para o endereço";
                    break;
                
                 case 8:
                     ViewBag.MessageError = "Insira o endereço";
                     break;
                  

                case 99:// exito
                    ViewBag.MessageSucess = "Vendedor ( " + objSalesMan.IdSalesMan + " )  foi alterado no Sistema";
                    break;
            }
        }

        public void MessageErroREliminate(SalesMan objSalesMan)
        {
            switch (objSalesMan.State)
            {
                case 1:
                    ViewBag.MessageError = "Vendedor ( " + objSalesMan.IdSalesMan + ") Não está registrado no sistema";
                    break;

                case 33:
                    ViewBag.MessageError = "O Vendedor: ( " + objSalesMan.Name + " ) já foi excluido";
                    break;

                case 34:
                    ViewBag.MessageError = "Não se pode apagar o vendedor ( " + objSalesMan.Name + " ) pois existe vendas assosciadas no sistema!!!";
                    break;

                case 99:
                    ViewBag.MessageSucess = "Vendedor ( " + objSalesMan.Name + ") foi excluido!!!";
                    break;

                default:
                    ViewBag.MessageError = "===???===";
                    break;
            }

        }

        public void MessageInitialRegister()
        {
            ViewBag.MessageBegin = "Insira os dados do Vendedor e clique em Salvar";
        }

        public void MessageInitialUpdate()
        {
            ViewBag.MessageInitialUpdate = "Insira os dados para Editar";
        }

        public void MessageInitialEliminate()
        {
            ViewBag.MessageInitialEliminate = "Formulário de Exclusão";
        }
    }
}
