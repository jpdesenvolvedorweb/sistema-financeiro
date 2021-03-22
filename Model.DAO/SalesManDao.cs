using Model.Dao;
using Model.Entity;
using Model.Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class SalesManDao : Intermediate<SalesMan>
    {
        private ConexaoDB con;
        private SqlCommand command;
        private SqlDataReader reader;

        public SalesManDao()
        {
            con = ConexaoDB.knowState();
        }

        public void Create(SalesMan salesMan)
        {
            string script = @"INSERT INTO salesman VALUES(@IDSALESMAN, @NAME, @CPF, @TELEPHONE, @ADDRESS)";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDSALESMAN", salesMan.IdSalesMan);
                command.Parameters.AddWithValue("@NAME", salesMan.Name);
                command.Parameters.AddWithValue("@CPF", salesMan.Cpf);
                command.Parameters.AddWithValue("@TELEPHONE", salesMan.Telephone);
                command.Parameters.AddWithValue("@ADDRESS", salesMan.Address);
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

        public void Delete(SalesMan salesMan)
        {
            string script = @"DELETE FROM salesman WHERE idSalesman = @IDSALESMAN";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDSALESMAN", salesMan.IdSalesMan);
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

        public bool Find(SalesMan salesMan)
        {
            bool registers = true;

            string script = @"SELECT * FROM salesman (NOLOCK) WHERE idSalesman = @IDSALESMAN";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDSALESMAN", salesMan.IdSalesMan);
                con.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    salesMan.Name = reader["name"].ToString();
                    salesMan.Cpf = reader["cpf"].ToString();
                    salesMan.Telephone = reader["telephone"].ToString();
                    salesMan.Address = reader["address"].ToString();
                    salesMan.State = 99;
                }
                else
                {
                    salesMan.State = 1;
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
            return registers;
        }

        public List<SalesMan> FindAll()
        {
            List<SalesMan> list = new List<SalesMan>();
            string script = "SELECT * FROM salesman (NOLOCK) ORDER BY name ASC";

            try
            {
                command = new SqlCommand(script, con.getCon());
                con.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SalesMan salesMan = new SalesMan();
                    salesMan.IdSalesMan = reader["idSalesman"].ToString();
                    salesMan.Name = reader["name"].ToString();
                    salesMan.Cpf = reader["cpf"].ToString();
                    salesMan.Telephone = reader["telephone"].ToString();
                    salesMan.Address = reader["address"].ToString();
                    list.Add(salesMan);
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

        public void Update(SalesMan salesMan)
        {
            string script = "UPDATE salesman SET name= @NAME, telephone= @TELEPHONE, cpf= @CPF, address= @ADDRESS WHERE idSalesman= @IDSALESMAN";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@NAME", salesMan.Name);
                command.Parameters.AddWithValue("@CPF", salesMan.Cpf);
                command.Parameters.AddWithValue("@TELEPHONE", salesMan.Telephone);
                command.Parameters.AddWithValue("@ADDRESS", salesMan.Address);
                command.Parameters.AddWithValue("@IDSALESMAN", salesMan.IdSalesMan);
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
