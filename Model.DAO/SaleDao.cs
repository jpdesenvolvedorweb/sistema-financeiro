using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class SaleDao : Intermediate<Sale>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand command;
        private SqlDataReader reader;

        public SaleDao()
        {
             objConexaoDB =  ConexaoDB.knowState();
        }

        public void Create(Sale obj)
        {
            string idSale = "";
            string create = "INSERT INTO sale(total,idClient,idSaleman,date,rate) VALUES ('" + obj.Total + "', '" + obj.IdClient + "', '" + obj.IdSalesMan + "' , '" + obj.Data + "', '" + obj.Data + "','" + obj.Rate + "')";

            try
            {
                command = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                reader = command.ExecuteReader();
                if (reader.Read())
                    idSale = reader[0].ToString();

            }
            catch (Exception)
            {
                obj.State = 1;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void Delete(Sale obj)
        {
            throw new NotImplementedException();
        }

        public bool Find(Sale obj)
        {
            throw new NotImplementedException();
        }

        public List<Sale> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Sale obj)
        {
            throw new NotImplementedException();
        }
    }
}
