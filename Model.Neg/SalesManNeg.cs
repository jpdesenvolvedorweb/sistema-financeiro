using Model.DAO;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class SalesManNeg
    {
        private SalesManDao objSalesManDao;

        public SalesManNeg()
        {
            objSalesManDao = new SalesManDao();
        }

        public void create(SalesMan objSalesMan)
        {
            SalesMan objSalesManAux = new SalesMan();
            bool verification = true;

            string code = objSalesMan.IdSalesMan;
            if (code == null)
            {
                objSalesMan.State = 10;
                return;
            }
            else
            {
                code = objSalesMan.IdSalesMan.Trim();
                verification = code.Length > 0 && code.Length <= 5;
                if (!verification)
                {
                    objSalesMan.State = 1;
                    return;
                }

            }

            string name = objSalesMan.Name;
            if (name == null)
            {
                objSalesMan.State = 20;
                return;
            }
            else
            {
                name = objSalesMan.Name.Trim();
                verification = name.Length > 0 && name.Length <= 30;
                if (!verification)
                {
                    objSalesMan.State = 2;
                    return;
                }
            }

            string cpf = objSalesMan.Cpf;
            if (cpf == null)
            {
                objSalesMan.State = 30;
                return;
            }
            else
            {
                cpf = objSalesMan.Cpf.Trim();
                verification = cpf.Length > 10 && cpf.Length <= 11;
                if (!verification)
                {
                    objSalesMan.State = 3;
                    return;
                }
            }

            string telephone = objSalesMan.Telephone;
            if (telephone == null)
            {
                objSalesMan.State = 40;
                return;
            }
            else
            {
                telephone = objSalesMan.Telephone.Trim();
                verification = telephone.Length > 9 && telephone.Length <= 15;
                if (!verification)
                {
                    objSalesMan.State = 4;
                    return;
                }
            }

            string address = objSalesMan.Address;
            if (address == null)
            {
                objSalesMan.State = 50;
                return;
            }
            else
            {
                address = objSalesMan.Address.Trim();
                verification = address.Length > 5 && address.Length <= 50;
                if (!verification)
                {
                    objSalesMan.State = 5;
                    return;
                }
            }

            objSalesManAux.IdSalesMan = objSalesMan.IdSalesMan;
            verification = !objSalesManDao.Find(objSalesManAux);
            if (!verification)
            {
                objSalesMan.State = 8;
                return;
            }

            objSalesManDao.Create(objSalesMan);
            objSalesMan.State = 99;
            return;
        }


        public void update(SalesMan objSalesMan)
        {
            bool verification = true;
            SalesMan objSalesManAux = new SalesMan();

            string name = objSalesMan.Name;
            if (name == null)
            {
                objSalesMan.State = 20;
                return;
            }
            else
            {
                name = objSalesMan.Name.Trim();
                verification = name.Length > 0 && name.Length <= 50;
                if (!verification)
                {
                    objSalesMan.State = 2;
                    return;
                }

            }

            string cpf = objSalesMan.Cpf;
            if (cpf == null)
            {
                objSalesMan.State = 30;
                return;
            }
            else
            {
                cpf = objSalesMan.Cpf.Trim();
                verification = cpf.Length > 10 && cpf.Length <= 11;
                if (!verification)
                {
                    objSalesMan.State = 3;
                    return;
                }
            }

            string telephone = objSalesMan.Telephone;
            if (telephone == null)
            {
                objSalesMan.State = 40;
                return;
            }
            else
            {
                telephone = objSalesMan.Telephone.Trim();
                verification = telephone.Length > 8 && telephone.Length <= 15;
                if (!verification)
                {
                    objSalesMan.State = 4;
                    return;
                }
            }

            string address = objSalesMan.Address;
            if (address == null)
            {
                objSalesMan.State = 50;
                return;
            }
            else
            {
                address = objSalesMan.Address.Trim();
                verification = address.Length > 0 && address.Length <= 50;
                if (!verification)
                {
                    objSalesMan.State = 5;
                    return;
                }
            }

            /*
            objSalesManAux.IdSalesMan = objSalesMan.IdSalesMan;
            verification = !objSalesManDao.Find(objSalesManAux);
            if (!verification)
            {
                objSalesMan.State = 8;
                return;
            }
            */

            objSalesManDao.Update(objSalesMan);
            objSalesMan.State = 99;
            return;

        }

        public void delete(SalesMan objSalesMan)
        {
            SalesMan objSalesManAux = new SalesMan();
            bool verification = true;

            objSalesManAux.IdSalesMan = objSalesMan.IdSalesMan;
            verification = objSalesManDao.Find(objSalesManAux);
            if (!verification)
            {
                objSalesMan.State = 33;
                return;
            }

            objSalesManDao.Delete(objSalesMan);
            objSalesMan.State = 99;
            return;
        }

        public bool find(SalesMan objSalesMan)
        {
            return objSalesManDao.Find(objSalesMan);
        }

        public List<SalesMan> findAll()
        {
            return objSalesManDao.FindAll();
        }

    }
}

