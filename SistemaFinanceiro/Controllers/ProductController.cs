using Model.Entity;
using Model.Neg;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace SistemaFinanceiro.Controllers
{
    public class ProductController : Controller
    {
        private ProductNeg objProductNeg;

        public ProductController()
        {
            objProductNeg = new ProductNeg();
        }

        // GET: Product
        public ActionResult Index()
        {
            CategoryNeg objCategoryNeg = new CategoryNeg();
            List<Category> data = objCategoryNeg.findAll();
            SelectList list = new SelectList(data, "idCategory", "name");
            ViewBag.ListCategories = list;

            List<Product> listProduct = objProductNeg.FindAll();
            return View(listProduct);
        }

        // GET: Product/Details/5
        public ActionResult Details(string id)
        {
            Product product = new Product(id);
            objProductNeg.Find(product);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            CategoryNeg objCategoryNeg = new CategoryNeg();
            List<Category> data = objCategoryNeg.findAll();
            SelectList list = new SelectList(data, "idCategory", "name");
            ViewBag.ListCategories = list;
            MessageStartRegister();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            MessageStartRegister();

            CategoryNeg objCategoryNeg = new CategoryNeg();
            List<Category> data = objCategoryNeg.findAll();

            SelectList list = new SelectList(data, "idCategory", "name");
            ViewBag.ListCategories = list;

            objProductNeg.Create(product);
            MessageErrorRegister(product);

            return View("Create");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
            MessageInitialUpdate();
            CategoryNeg categoryNeg = new CategoryNeg();
            List<Category> data = categoryNeg.findAll();

            SelectList list = new SelectList(data, "idCategory", "name");
            ViewBag.ListCategories = list;
            Product product = new Product(id);
            objProductNeg.Find(product);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            MessageInitialUpdate();
            CategoryNeg categoryNeg = new CategoryNeg();
            List<Category> data = categoryNeg.findAll();
            SelectList list = new SelectList(data, "idCategory", "name");
            ViewBag.ListCategories = list;

            objProductNeg.Update(product);
            MessageErrorUpdate(product);
            return View();
        }

        // GET: Product/Delete/5
        public ActionResult Delete(string id)
        {
            MessageInitialEliminate();
            CategoryNeg categoryNeg = new CategoryNeg();
            List<Category> data = categoryNeg.findAll();
            SelectList list = new SelectList(data, "idCategory", "name");
            ViewBag.ListCategories = list;

            Product product = new Product(id);
            objProductNeg.Find(product);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            MessageInitialEliminate();
            CategoryNeg categoryNeg = new CategoryNeg();
            List<Category> data = categoryNeg.findAll();
            SelectList list = new SelectList(data, "idCategory", "name");
            ViewBag.ListCategories = list;

            objProductNeg.Delete(product);
            MessageErrorDelete(product);
            return View();

        }

        private void MessageErrorRegister(Product product)
        {
            switch (product.State)
            {
                case 1000:
                    ViewBag.MessageError = "Erro!!! Revise a instrução de Inserir";
                    break;

                case 10:
                    ViewBag.MessageError = "Digite o código do produto";
                    break;

                case 1:
                    ViewBag.MessageError = "Apenas 5 digitos para o código";
                    break;

                case 20:
                    ViewBag.MessageError = "Digite o nome do produto";
                    break;

                case 2:
                    ViewBag.MessageError = "Digite um nome até 30 caracteres";
                    break;

                case 30:
                    ViewBag.MessageError = "Digite o preço do produto";
                    break;

                case 3:
                    ViewBag.MessageError = "Preço unitário inválido";
                    break;

                case 300:
                    ViewBag.MessageError = "Preço unitário inválido";
                    break;

                case 40:
                    ViewBag.MessageError = "Categoria vazia";
                    break;

                case 4:
                    ViewBag.MessageError = "Categoria invalida";
                    break;

                case 5:
                    ViewBag.MessageError = "Produto ( " + product.IdProduct + " ) já está inserido no Sistema";
                    break;

                case 99:
                    ViewBag.MessageSucess = "Produto ( " + product.Name + " ) foi registrado no Sistema";
                    break;
            }

        }

        private void MessageErrorUpdate(Product product)
        {
            switch (product.State)
            {
               case 1000:
                    ViewBag.MessageError = "Erro!!! Revise a instrução de Inserir";
                    break;

                case 20:
                    ViewBag.MessageError = "Insira o nome do Produto";
                    break;

                case 2:
                    ViewBag.MessageError = "Digite um nome até 30 caracteres";
                    break;

                case 30:
                    ViewBag.MessageError = "Insira preço do Produto";
                    break;

                case 3:
                    ViewBag.MessageError = "Preço Unitário Inválido";
                    break;

                case 300:
                    ViewBag.MessageError = "Preço Unitário Inválido";
                    break;

                case 40:
                    ViewBag.MessageError = "Categoria Vazia";
                    break;

                case 4:
                    ViewBag.MessageError = "Categoria Inválida";
                    break;

                case 99:
                    ViewBag.MessageSucess = "Dados do Produto (" + product.IdProduct + ")  foram modificados ";
                    break;
            }
        }

        private void MessageErrorDelete(Product product)
        {
            switch (product.State)
            {
                case 1000:
                    ViewBag.MessageError = "Erro!!! Revise a instrução de Inserir";
                    break;

                case 1:
                    ViewBag.MessageError = "O Produto: (" + product.IdProduct + ") Não existe no Sistema";
                    break;

                case 33:
                    ViewBag.MessageError = "O Produto: (" + product.Name + ") Já foi excluido";
                    break;

                case 34:
                    ViewBag.MessageError = "Não se pode excluir o Produto (" +  product.Name + ") por ter vendas relacionadas!!!";
                    break;

                case 99:
                    ViewBag.MessageSucess = "Produto (" + product.Name + ") foi excluido!!!";
                    break;

                default:
                    ViewBag.MessageError = "===???===";
                    break;
            }
        }

        private void MessageStartRegister()
        {
            ViewBag.MessageBegin = "Insira os dados do Produto e clique em salvar";
        }

        private void MessageInitialUpdate()
        {
            ViewBag.MessageInitialUpdate = "Formulário para atualizar os dados do Produto";
        }

        private void MessageInitialEliminate()
        {
            ViewBag.MessageInitialEliminate = "Formulário de Exclusão";
        }
    }
}
