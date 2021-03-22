using Model.DAO;
using Model.Entity;
using Model.Entity.Exceptions;
using System;
using System.Collections.Generic;

namespace Model.Neg
{
    public class SaleNeg
    {
        private SaleDao saleDao;

        public SaleNeg()
        {
            saleDao = new SaleDao();
        }

        public void create(Sale sale)
        {
            bool verification = true;
            try
            {
                string total = sale.Total.ToString();
                double totalAux = 0;

                if (string.IsNullOrWhiteSpace(total))
                    throw new Exception("A venda necessita de um valor total valido!!!");

                totalAux = Convert.ToDouble(sale.Total);

                verification = totalAux > 0 && totalAux <= 999999999;
                if (!verification)
                    throw new Exception("O número total é maior que o esperado!!!");

                string date = sale.Data.ToString();
                if (string.IsNullOrWhiteSpace(date))
                    throw new Exception("Informe por favor uma data válida!!!");

                date = sale.Data.Trim();
                verification = date.Length == 10;
                if (!verification)
                    throw new Exception("O tamanho da data deve ter 10 caracteres!!!");

                saleDao.Create(sale);
                sale.State = 99;
                return;
            }
            catch (Exception erro)
            {
                Message.MessageError(erro.Message);
            }

        }

        public void update(Sale sale)
        {
            bool verification = true;
            try
            {
                string total = sale.Total.ToString();
                double totalAux = 0;

                if (string.IsNullOrWhiteSpace(total))
                    throw new Exception("A venda necessita de um valor total valido!!!");

                totalAux = Convert.ToDouble(sale.Total);

                verification = totalAux > 0 && totalAux <= 999999999;
                if (!verification)
                    throw new Exception("O número total é maior que o esperado!!!");

                string date = sale.Data.ToString();
                if (string.IsNullOrWhiteSpace(date))
                    throw new Exception("Informe por favor uma data válida!!!");

                date = sale.Data.Trim();
                verification = date.Length == 10;
                if (!verification)
                    throw new Exception("O tamanho da data deve ter 10 caracteres!!!");

                saleDao.Update(sale);
                sale.State = 99;
                return;
            }
            catch (Exception erro)
            {
                Message.MessageError(erro.Message);
            }
        }

        public void delete(Sale sale)
        {
            bool verification = true;

            try
            {
                Sale saleAux = new Sale(sale.IdSale);
                verification = saleDao.Find(saleAux);
                if (!verification)
                    throw new Exception("A venda " + sale.IdSale + " já foi deletada do sistema!!!");

                saleDao.Delete(sale);
                sale.State = 99;
            }
            catch (Exception erro)
            {
                Message.MessageError(erro.Message);
            }
        }

        public bool Find(Sale sale)
        {
            return saleDao.Find(sale);
        }

        public List<Sale> FindAll()
        {
            return saleDao.FindAll();
        }
    }
}
