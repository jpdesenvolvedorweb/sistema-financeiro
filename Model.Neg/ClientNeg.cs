using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Neg 
{
    public class ClientNeg
    {
        private ClientDao objClientDao;

        public ClientNeg()
        {
            objClientDao = new ClientDao();
        }

        public void create(Client objClient)
        {
            bool verification = true;

            string name = objClient.Name;
            if(name == null)
            {
                objClient.State = 20;
                return;
            }
            else
            {
                name = objClient.Name.Trim();
                verification = name.Length > 0 && name.Length <= 30;
                if (!verification)
                {
                    objClient.State = 2;
                    return;
                }
            }
            //end validar nome

            //inicio da validação do cpf
            string cpf = objClient.Cpf;
            if (cpf == null)
            {
                objClient.State = 50;
                return;
            }
            else
            {
                cpf = objClient.Cpf.Trim();
                verification = cpf.Length <= 12 && cpf.Length > 10;
                if (!verification)
                {
                    objClient.State = 250;
                    return;
                }

            }

            //fim da validãção do cpf

            //begin validar endereco retorna estado=6
            string address = objClient.Address;
            if(address == null)
            {
                objClient.State = 60;
                return;
            }
            else
            {
                address = objClient.Address.Trim();
                verification = address.Length > 0 && address.Length <= 50;
                if (!verification)
                {
                    objClient.State = 6;
                    return;
                }
            }
            //end validar endereco

            //begin validar telefone retorna estado=7
            string telephone = objClient.Telephone;
            if(telephone == null)
            {
                objClient.State = 70;
                return;
            }
            else
            {
                telephone = objClient.Telephone.Trim();
                verification = telephone.Length > 7 && telephone.Length <= 15;
                if (!verification)
                {
                    objClient.State = 7;
                    return;
                }
            }
            //end validar telefone

            //begin verificar duplicidade retorna estado= 8
            Client objClientAux = new Client();
            objClientAux.IdClient = objClient.IdClient;
            verification = !objClientDao.Find(objClientAux);
            if (!verification)
            {
                objClient.State = 8;
                return;
            }
            //end validar duplicidade

            //begin verificar duplicidade cpf retorna estado=8
            Client objClient1 = new Client();
            objClient1.Cpf = objClient.Cpf;
            verification = !objClientDao.FindCustumerByCpf(objClient1);
            if (!verification)
            {
                objClient.State = 9;
                return;
            }
            //end validar duplicidade cpf

            //se não tem erro
            objClient.State = 99;
            objClientDao.Create1(objClient);
            return;
        }

        public void update(Client objClient)
        {
            bool verification = true;
            //begin validar codigo retorna estado = 1
            string code = objClient.IdClient.ToString();
           // long id = 0;
            if (code == null)
            {
                objClient.State = 10;
                return;
            }
            else
            {
                try
                {
                   // id = Convert.ToInt64(objClient.IdClient);
                    verification = code.Length > 0 && code.Length < 999999;

                    if (!verification)
                    {
                        objClient.State = 1;
                        return;
                    }
                }
                catch (Exception)
                {
                    objClient.State = 100;
                    return;
                }
            }
            //end validar codigo

            //begin validar nome retorna estado=2
            string name = objClient.Name;
            if(name == null)
            {
                objClient.State = 20;
                return;
            }
            else
            {
                name = objClient.Name.Trim();
                verification = name.Length > 0 && name.Length <= 30;
                if (!verification)
                {
                    objClient.State = 2;
                    return;
                }
            }
            //end validar nome

            //inicio da validação do cpf
            string cpf = objClient.Cpf;
            if (cpf == null)
            {
                objClient.State = 50;
                return;
            }
            else
            {
                cpf = objClient.Cpf.Trim();
                verification = cpf.Length > 10 && cpf.Length < 12;
                if (!verification)
                {
                    objClient.State = 250;
                    return;
                }
            }

            //begin validar endereço retorna estado=6
            string address = objClient.Address;
            if(address == null)
            {
                objClient.State = 60;
                return;
            }
            else
            {
                address = objClient.Address.Trim();
                verification = address.Length > 0 && address.Length <= 50;
                if (!verification)
                {
                    objClient.State = 6;
                    return;
                }
            }
            //end validar endereco

            //begin validar telefone retorna estado=7
            string telephone = objClient.Telephone;
            if(telephone == null)
            {
                objClient.State = 70;
                return;
            }
            else
            {
                telephone = objClient.Telephone.Trim();
                verification = telephone.Length > 0 && telephone.Length <= 15;
                if (!verification)
                {
                    objClient.State = 7;
                    return;
                }
            }
            //end validar telefone

            //se nao tem erro
            objClient.State = 99;
            objClientDao.Update(objClient);
            return;
        }

        public void delete(Client objClient)
        {
            bool verification = true;
            //verificando se existe
            Client objClientAux = new Client();
            objClientAux.IdClient = objClient.IdClient;
            verification = objClientDao.Find(objClientAux);
            if (!verification)
            {
                objClient.State = 33;
                return;
            }

            objClient.State = 99;
            objClientDao.Delete(objClient);
            return;
        }

        public bool find(Client objClient)
        {
            return objClientDao.Find(objClient);
        }

        public List<Client> findAll()
        {
            return objClientDao.FindAll();
        }

        public List<Client> findAllClients(Client objClient)
        {
            return objClientDao.FindAllClient(objClient);
        }
    }
}
