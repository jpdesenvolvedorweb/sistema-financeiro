using Model.Entity;
using Model.Neg;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaFinanceiro.Controllers
{
    public class CategoryController : Controller
    {

        CategoryNeg objCategoryNeg;

        public CategoryController()
        {
            objCategoryNeg = new CategoryNeg();
        }

        // GET: Category
        public ActionResult Index()
        {
            Category objCategory = new Category();
            List<Category> list = objCategoryNeg.findAll();
            MessageErrorServer(objCategory);
            return View(list);
        }

        // GET: Category/Details/5
        public ActionResult Details(string id)
        {
            Category objCategory = new Category(id);
            objCategoryNeg.find(objCategory);
            return View(objCategory);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            MessageInitialRegister();
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category objCategory)
        {
            MessageInitialRegister();
            objCategoryNeg.create(objCategory);
            MessageErrorRegister(objCategory);
            return View("Create");

        }

        // GET: Category/Edit/5
        public ActionResult Edit(string id)
        {
            MessageInitialUpdate();
            Category objCategory = new Category(id);
            objCategoryNeg.find(objCategory);
            return View(objCategory);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category objCategory)
        {
            MessageInitialUpdate();
            objCategoryNeg.update(objCategory);
            MessageErrorUpdate(objCategory);
            return View();
        }

        // GET: Category/Delete/5
        public ActionResult Delete(string id)
        {
            MessageInitialDelete();
            Category objCategory = new Category(id);
            objCategoryNeg.find(objCategory);
            return View(objCategory);
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category objCategory)
        {
            MessageInitialDelete();
            objCategoryNeg.delete(objCategory);
            ShowMessageDelete(objCategory);
            return View();
        }

        private void MessageErrorRegister(Category objCategory)
        {
            switch (objCategory.State)
            {
                case 1000:
                    ViewBag.MessageError = "Erro!!! Revise a instrução de inserir";
                    break;

                case 10:
                    ViewBag.MessageError = "Insira o código da categoria";
                    break;

                case 1:
                    ViewBag.MessageError = "O código não pode ter mais de 5 números";
                    break;

                case 20:
                    ViewBag.MessageError = "Insira o nome da categoria";
                    break;

                case 2:
                    ViewBag.MessageError = "Não insira mais de 30 caracteres no campo nome";
                    break;

                case 30:
                    ViewBag.MessageError = "Insira a descrição da categoria";
                    break;

                case 3:
                    ViewBag.MessageError = "Não é permitido mais de 30 caracteres no campo categoria";
                    break;

                case 8:
                    ViewBag.MessageError = "Categoria ( " + objCategory.IdCategory + " ) já está registrado no sistema";
                    break;

                case 16:
                    ViewBag.MessageError = "Categoria ( " + objCategory.Name + " ) está registrado no sistema";
                    break;

                case 99:
                    ViewBag.MessageSucess = "Categoria ( " + objCategory.IdCategory + " ) foi inserida no sistema";
                    break;
            }
        }

        private void MessageErrorUpdate(Category objCategory)
        {
            switch (objCategory.State)
            {
                case 1000:
                    ViewBag.MessageError = "Erro!!! Revise a instrução de inserir";
                    break;

                case 10:
                    ViewBag.MessageError = "Insira o código da categoria";
                    break;

                case 1:
                    ViewBag.MessageError = "O código não pode ter mais de 5 números";
                    break;

                case 20:
                    ViewBag.MessageError = "Insira o nome da categoria";
                    break;

                case 2:
                    ViewBag.MessageError = "Não insira mais de 30 caracteres no campo nome";
                    break;

                case 30:
                    ViewBag.MessageError = "Insira a descrição da categoria";
                    break;

                case 3:
                    ViewBag.MessageError = "Não é permitido mais de 30 caracteres no campo categoria";
                    break;

                case 16:
                    ViewBag.MessageError = "Categoria ( " + objCategory.Name + " ) está registrado no sistema";
                    break;

                case 99:
                    ViewBag.MessageSucess = "Dados da categoria ( " + objCategory.IdCategory + " ) foram modificados";
                    break;
            }
        }

        private void ShowMessageDelete(Category objCategory)
        {
            switch (objCategory.State)
            {
                case 1000:
                    ViewBag.MessageError = "Error!!! Revise a instrução de excluir";
                    break;

                case 1:
                    ViewBag.MessageError = "Cetegoria ( " + objCategory.IdCategory + " ) não está mais no sistema! ";
                    break;

                case 33:
                    ViewBag.MessageError = "Categoria: ( " + objCategory.Name + " ) já foi eliminada";
                    break;

                case 34:
                    ViewBag.MessageError = "Não se pode excluir a categoria ( " + objCategory.Name + " ) tem produtos associados";
                    break;

                case 99:
                    ViewBag.MessageSucess = "Categoria ( " + objCategory.Name + " ) foi excluida!!!";
                    break;

                default:
                    ViewBag.MessageError = "===Deu Erro ???===";
                    break;
            }
        }


        private void MessageInitialDelete()
        {
            ViewBag.MessageInitialDelete = "Formulário de Deleção";
        }

        private void MessageInitialRegister()
        {
            ViewBag.MessageBegin = "Insira os dados e clique em Salvar";
        }

        private void MessageInitialUpdate()
        {
            ViewBag.MessageInitialUpdate = "Insira os dados para alterar a categoria";
        }

        private void MessageErrorServer(Category objCategory)
        {
            if (objCategory.State == 1000)
            {
                ViewBag.MessageError = "ERRO DE SERVIDOR DE SQL SERVER";
            }
        }
    }
}
