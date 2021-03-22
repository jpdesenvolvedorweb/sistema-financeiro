using Model.Dao;
using Model.Entity;
using Model.Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class SaleDao : SaleRepository 
    {
        private ConexaoDB con;
        private SqlCommand command;
        private SqlDataReader reader;

        public SaleDao()
        {
             con =  ConexaoDB.knowState();
        }

        public string Create(Sale sale)
        {
            string idSale = "";
            string script = @"INSERT INTO sale(total,idClient,idSaleman,date,rate) 
                              VALUES (@TOTAL, @IDCLIENT, @IDSALESMAN, @DATA, @RATE)";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@TOTAL", sale.Total);
                command.Parameters.AddWithValue("@IDCLIENT", sale.IdClient);
                command.Parameters.AddWithValue("@IDSALESMAN", sale.IdSalesMan);
                command.Parameters.AddWithValue("@DATA", sale.Data);
                command.Parameters.AddWithValue("@RATE", sale.Rate);

                con.getCon().Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                    idSale = reader["idSale"].ToString();

            }
            catch (Exception erro)
            {
                Message.MessageError(erro.Message);
            }
            finally
            {
                con.getCon().Close();
                con.CloseDB();
            }

            return idSale;
        }

        public void Delete(Sale sale)
        {
            string script = @"DELETE FROM sale WHERE idSale= @IDSALE";

            try
            {
                command = new  SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDSALE", sale.IdSale);

                con.getCon().Open();
                command.ExecuteNonQuery();

            }
            catch(Exception erro)
            {
                Message.MessageError(erro.Message);
            }
            finally
            {
                con.getCon().Close();
                con.CloseDB();
            }
        }

        public bool Find(Sale sale)
        {
            bool register = true;

            string script = @"SELECT * FROM sale (NOLOCK) WHERE idSale= @IDSALE";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDSALE", sale.IdSale);
                con.getCon().Open();
                reader =  command.ExecuteReader();
                register = reader.Read();

                if (register)
                {
                    sale.Total = Convert.ToDouble(reader["total"].ToString());
                    sale.IdClient = Convert.ToInt64(reader["idClient"].ToString());
                    sale.IdSalesMan = reader["idSalesMan"].ToString();
                    sale.Data = reader["data"].ToString();
                    sale.Rate = Convert.ToDouble(reader["rate"].ToString());
                    sale.State = 99;

                }
            }
            catch (Exception erro)
            {
                Message.MessageError(erro.Message);
            }
            finally
            {
                con.getCon().Close();
                con.CloseDB();
            }

            return register;
        }

        public List<Sale> FindAll()
        {
            string script = @"SELECT * FROM sale (NOLOCK) ORDER BY idSale ASC";
            List<Sale> list = new List<Sale>();

            try
            {
                command = new SqlCommand(script, con.getCon());
                con.getCon().Open();
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
            catch (Exception erro)
            {
                Message.MessageError(erro.Message);
            }
            finally
            {
                con.getCon().Close();
                con.CloseDB();
            }
            return list;
        }

        public List<Sale> FindAllClient(Sale sale)
        {
            List<Sale> list = new List<Sale>();
            string script = @"SELECT * FROM sale(NOLOCK) WHERE idClient = @IDCLIENT";

            try
            {
                using (con.getCon())
                {
                    command = new SqlCommand(script, con.getCon());
                    command.Parameters.AddWithValue("@IDCLIENT", sale.IdClient);
                    con.getCon().Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        sale.IdSale = Convert.ToInt64(reader["idSale"].ToString());
                        sale.Total = Convert.ToDouble(reader["total"].ToString());
                        sale.IdClient = Convert.ToInt64(reader["idClient"].ToString());
                        sale.IdSalesMan = reader["idSaleman"].ToString();
                        sale.Data = reader["date"].ToString();
                        sale.Rate = Convert.ToDouble(reader["rate"].ToString());
                       // sale.IdSale = reader[].ToString();
                        list.Add(sale);
                    }
                }
            }
            catch (Exception erro)
            {
                Message.MessageError(erro.Message);
            }

            return list;
        }

        public void Update(Sale sale)
        {
            string script = @"UPDATE sale SET total = @TOTAL, 
                                              idClient = @IDCLIENT, 
                                              idSalesMan = @IDSALESMAN, 
                                              rate = @RATE 
                              WHERE idSale = @IDSALE";
            
            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@TOTAL", sale.Total);
                command.Parameters.AddWithValue("@IDCLIENT", sale.IdClient);
                command.Parameters.AddWithValue("@IDSALESMAN", sale.IdSalesMan);
                command.Parameters.AddWithValue("@RATE", sale.Rate);
                command.Parameters.AddWithValue("@IDSALE", sale.IdSale);
                con.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                Message.MessageError(erro.Message);
            }
            finally
            {
                con.getCon().Close();
                con.CloseDB();
            }
        }
    }
}
