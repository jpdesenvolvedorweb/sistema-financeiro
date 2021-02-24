using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class SaleDao : SaleRepository 
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand command;
        private SqlDataReader reader;

        public SaleDao()
        {
             objConexaoDB =  ConexaoDB.knowState();
        }

        public string Create(Sale obj)
        {
            string idSale = "";
            string script = @"INSERT INTO sale(total,idClient,idSaleman,date,rate) VALUES (@TOTAL, @IDCLIENT, @IDSALESMAN, @DATA, @RATE)";

            try
            {
                command = new SqlCommand(script, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@TOTAL", obj.Total);
                command.Parameters.AddWithValue("@IDCLIENT", obj.IdClient);
                command.Parameters.AddWithValue("@IDSALESMAN", obj.IdSalesMan);
                command.Parameters.AddWithValue("@DATA", obj.Data);
                command.Parameters.AddWithValue("@RATE", obj.Rate);

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

            return idSale;
        }

        public void Delete(Sale obj)
        {
            string script = @"DELETE FROM sale WHERE idSale= @IDSALE";

            try
            {
                command = new  SqlCommand(script, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDSALE", obj.IdSale);

                objConexaoDB.getCon().Open();
                command.ExecuteNonQuery();

            }
            catch(Exception)
            {
                obj.State = 1;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool Find(Sale obj)
        {
            bool register;

            string script = @"SELECT * FROM sale (NOLOCK) WHERE idSale= @IDSALE";

            try
            {
                command = new SqlCommand(script, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDSALE", obj.IdSale);
                objConexaoDB.getCon().Open();
                reader =  command.ExecuteReader();
                register = reader.Read();

                if (register)
                {
                    obj.Total = Convert.ToDouble(reader["total"].ToString());
                    obj.IdClient = Convert.ToInt64(reader["idClient"].ToString());
                    obj.IdSalesMan = reader["idSalesMan"].ToString();
                    obj.Data = reader["data"].ToString();
                    obj.Rate = Convert.ToDouble(reader["rate"].ToString());
                    obj.State = 99;

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return register;
        }

        public List<Sale> FindAll()
        {
            string script = @"SELECT * FROM sale (NOLOCK) ORDER BY idSale ASC";
            List<Sale> list = new List<Sale>();

            try
            {
                command = new SqlCommand(script, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read()) {

                    Sale sale = new Sale();
                    sale.IdSale = Convert.ToInt64(reader["idSale"].ToString());
                    sale.Total = Convert.ToDouble(reader["total"].ToString());
                    sale.IdClient = Convert.ToInt64(reader["idClient"].ToString());
                    sale.IdSalesMan = reader["idSalesMan"].ToString();
                    sale.Data = reader["data"].ToString();
                    sale.Rate = Convert.ToDouble(reader["rate"].ToString());

                    list.Add(sale);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
            return list;
        }

        public void Update(Sale obj)
        {
            string script = @"UPDATE sale SET total = @TOTAL, idClient = @IDCLIENT, idSalesMan = @IDSALESMAN, rate = @RATE WHERE idSale = @IDSALE";
            
            try
            {
                command = new SqlCommand(script, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@TOTAL", obj.Total);
                command.Parameters.AddWithValue("@IDCLIENT", obj.IdClient);
                command.Parameters.AddWithValue("@IDSALESMAN", obj.IdSalesMan);
                command.Parameters.AddWithValue("@RATE", obj.Rate);
                command.Parameters.AddWithValue("@IDSALE", obj.IdSale);
                objConexaoDB.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                obj.State = 1000;
                return;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
    }
}
