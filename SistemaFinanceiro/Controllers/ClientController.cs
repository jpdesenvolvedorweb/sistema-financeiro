using Model.Entity;
using Model.Neg;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaFinanceiro.Controllers
{
    public class ClientController : Controller
    {
        ClientNeg objClientNeg;

        public ClientController()
        {
            objClientNeg = new ClientNeg();
        }

        //MOSTRAR OS CLIENTES
        // GET: Client
        public ActionResult Index()
        {
            List<Client> list = objClientNeg.findAll();
            return View(list);
        }

        // GET: Client/Details/5
        public ActionResult Details(long id)
        {
            Client objClient = new Client(id);
            objClientNeg.find(objClient);

            return View(objClient);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            messageStartRegister();
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client objClient)
        {
            messageStartRegister();
            objClientNeg.create(objClient);
            MessageErrorRegister(objClient);
            ModelState.Clear();
            return View("Create");

        }

        // GET: Client/Edit/5
        public ActionResult Edit(long id)
        {
            messageInitialUpdate();
            Client objClient = new Client(id);
            objClientNeg.find(objClient);
            return View(objClient);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(Client objClient)
        {
            messageInitialUpdate();
            objClientNeg.update(objClient);
            messageErrorUpdate(objClient);
            return View();
        }

        //GET: Client/SearchClients
        public ActionResult SearchClients()
        {
            List<Client> list = objClientNeg.findAll();
            return View(list);
        }

        //POST: Client/SearchClients
        [HttpPost]
        public ActionResult SearchClients(string txtname, string txtcpf, long txtclient = -1)
        {
            if(txtname == "")
            {
                txtname = "-1";
            }
            if(txtcpf == "")
            {
                txtcpf = "-1";
            }

            if (txtname == "-1" && txtcpf == "-1" && txtclient == -1)
            {
                messageSeachClients();
            }

            Client objClient = new Client();
            objClient.Name = txtname;
            objClient.IdClient = txtclient;
            objClient.Cpf = txtcpf;

            List<Client> client = objClientNeg.findAllClients(objClient);
            return View(client);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(long id)
        {
            messageInitialEliminate();
            Client objClient = new Client(id);
            objClientNeg.find(objClient);
            return View(objClient);
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(Client objClient)
        {
            messageInitialEliminate();
            objClientNeg.delete(objClient);
            showMessageEliminate(objClient);
            Client objClient2 = new Client();
            return View(objClient2);
        }

        //mensagem de erro
        public void MessageErrorRegister(Client objClient)
        {
            switch (objClient.State)
            {
                case 1000: //campo cpf com letras
                    ViewBag.MessageError = "Erro CPF, não insira Letras";
                    break;

                case 20: //campo nome vazio
                    ViewBag.MessageError = "Insira Nome do Cliente";
                    break;

                case 2: //erro de nome
                    ViewBag.MessageError = "O nome não pode ter mais de 30 caracteres";
                    break;

                case 50: //campo cpf vazio
                    ViewBag.MessageError = "Insira CPF do Cliente";
                    break;

                case 250: //campo cpf vazio
                    ViewBag.MessageError = "O CPF tem que ter 11 numeros, apenas numeros";
                    break;

                case 60: //endereco vazio
                    ViewBag.MessageError = "Insira endereço do Cliente";
                    break;

                case 6: //erro de endereço
                    ViewBag.MessageError = "Campo endereço não pode ter mais de 50 caracteres";
                    break;

                case 70: //campo telefone vazio
                    ViewBag.MessageError = "Insira o telefone do cliente";
                    break;

                case 7: //campo telefone vazio
                    ViewBag.MessageError = "O telefone tem que ter de 8 a 15 digitos";
                    break;

                case 8: //erro de duplicidade
                    ViewBag.MessageError = "Cliente ( " + objClient.IdClient + " ) já está registrado no sistema";
                    break;

                case 9: //erro de duplicidade
                    ViewBag.MessageError = "Número de CPF ( " + objClient.Cpf + " ) já está registrado no sistema";
                    break;

                case 99: //Cliente Salvo com Sucesso
                    ViewBag.MessageSucess = "Cliente ( " + objClient.Name + " ) foi inserido no sistema";
                    break;
            }
        }

        public void messageErrorUpdate(Client obClient)
        {
            switch (obClient.State)
            {
                case 1000:
                    ViewBag.MessageError = "Erro CPF, não insira Letras";
                    break;

                case 20: 
                    ViewBag.MessageError = "Insira Nome do Cliente";
                    break;

                case 50:
                    ViewBag.MessageError = "Insira CPF do Cliente";
                    break;

                case 250:
                    ViewBag.MessageError = "O CPF tem que ter 11 numeros, apenas numeros";
                    break;

                case 60:
                    ViewBag.MessageError = "Insira endereço do Cliente";
                    break;

                case 6:
                    ViewBag.MessageError = "Campo endereço não pode ter mais de 50 caracteres";
                    break;

                case 70:
                    ViewBag.MessageError = "Insira o telefone do Cliente";
                    break;

                case 7:
                    ViewBag.MessageError = "O telefone tem que ter 8 a 15 digitos";
                    break;

                case 99:
                    ViewBag.MessageError = "Dados do Cliente ( " + obClient.IdClient + " ) foi atualizado";
                    break;
            }
        }

        public void showMessageEliminate(Client objClient)
        {
            switch (objClient.State)
            {
                case 1:
                    ViewBag.MessageError = "Cliente ( " + objClient.IdClient + "Não ";
                    break;

                case 33:
                    ViewBag.MessageError = "Cliente: ( " + objClient.Name + " ) já foi excluído";
                    break;

                case 34:
                    ViewBag.MessageError = "Não se pode apagar o Cliente ( " + objClient.Name + " ) Tem vendas relacionadas ao cliente!!!";
                    break;

                case 99:
                    ViewBag.MessageError = "Cliente ( " + objClient.Name + ") Foi Excluido!!!";
                    break;

                default:
                    ViewBag.MessageError = "===Deu Erro ???===";
                    break;
            }
        }

        public void messageInitialUpdate()
        {
            ViewBag.messageInitialUpdate = "Formulário para atualizar dados do cliente";
        }

        public void messageStartRegister()
        {
            ViewBag.MessageBegin = "Insira os dados do Cliente e clique em salvar";
        }

        public void messageInitialEliminate()
        {
            ViewBag.MessageInitialEliminate = "Formulário de Exclusão";
        }

        public void messageSeachClients()
        {
            ViewBag.MessageEmpty = "Deve ser digitado algum campo";
        }

    }
}
