using Model.Entity;
using Model.Neg;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaFinanceiro.Controllers
{
    public class SaleController : Controller
    {

        private ClientNeg clientNeg;
        private SaleNeg saleNeg;
        private ModePayNeg modePayNeg;
        private ProductNeg productNeg;

        public SaleController()
        {
            clientNeg = new ClientNeg();
            saleNeg = new SaleNeg();
            modePayNeg = new ModePayNeg();
            productNeg = new ProductNeg();
        }

        // GET: Sale
        public ActionResult GetCostumers()
        {
            List<Client> list = clientNeg.findAll();
            return View(list);
        }

        // POST: Sale/GetCostumers/5
        [HttpPost]
        public ActionResult GetCostumers(string txtName, string txtCpf, long txtClient = -1)
        {
            if (txtName == "")
                txtName = "-1";

            if (txtCpf == "")
                txtCpf = "-1";

            Client client = new Client();
            client.Name = txtName;
            client.Cpf = txtCpf;
            client.IdClient = txtClient;

            List<Client> list = clientNeg.findAllClient(client);
            return View(list);
        }

        public ActionResult NewSale()
        {
            carregarProdutocmb();
            carregarModoPagocmb();
            return View();
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sale/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sale/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sale/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sale/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region "Funções de Select List para novas Vendas"

        public void carregarProdutocmb()
        {
            List<Product> data = productNeg.FindAll();
            SelectList list = new SelectList(data, "idProduct", "name");
            ViewBag.ListProduct = list;
        }
        public void carregarModoPagocmb()
        {
            List<ModePay> data = modePayNeg.FindAll();
            SelectList list = new SelectList(data, "idModePay", "name");
            ViewBag.ListModePay = list;
            #endregion
        }
    }
}
