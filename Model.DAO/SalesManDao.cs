using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class SalesManDao : Intermediate<SalesMan>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand command;
        private SqlDataReader reader;

        public SalesManDao()
        {
            objConexaoDB = ConexaoDB.knowState();
        }

        public void Create(SalesMan obj)
        {
            string create = @"INSERT INTO salesman VALUES(@IDSALESMAN, @NAME, @CPF, @TELEPHONE, @ADDRESS)";

            try
            {
                command = new SqlCommand(create, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDSALESMAN", obj.IdSalesMan);
                command.Parameters.AddWithValue("@NAME", obj.Name);
                command.Parameters.AddWithValue("@CPF", obj.Cpf);
                command.Parameters.AddWithValue("@TELEPHONE", obj.Telephone);
                command.Parameters.AddWithValue("@ADDRESS", obj.Address);
                objConexaoDB.getCon().Open();
                command.ExecuteNonQuery();
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
        }

        public void Delete(SalesMan obj)
        {
            string delete = @"DELETE FROM salesman WHERE idSalesman = @IDSALESMAN";

            try
            {
                command = new SqlCommand(delete, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDSALESMAN", obj.IdSalesMan);
                objConexaoDB.getCon().Open();
                command.ExecuteNonQuery();
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

        public bool Find(SalesMan obj)
        {
            bool registers;

            string find = @"SELECT * FROM salesman (NOLOCK) WHERE idSalesman = @IDSALESMAN";

            try
            {
                command = new SqlCommand(find, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDSALESMAN", obj.IdSalesMan);
                objConexaoDB.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    obj.Name = reader[1].ToString();
                    obj.Cpf = reader[2].ToString();
                    obj.Telephone = reader[3].ToString();
                    obj.Address = reader[4].ToString();
                    obj.State = 99;
                }
                else
                {
                    obj.State = 1;
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

            return registers;

        }

        public List<SalesMan> FindAll()
        {
            string findAll = "SELECT * FROM salesman (NOLOCK) ORDER BY name ASC";
            List<SalesMan> list = new List<SalesMan>();

            try
            {
                command = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SalesMan salesMan = new SalesMan();
                    salesMan.IdSalesMan = reader[0].ToString();
                    salesMan.Name = reader[1].ToString();
                    salesMan.Cpf = reader[2].ToString();
                    salesMan.Telephone = reader[3].ToString();
                    salesMan.Address = reader[4].ToString();
                    list.Add(salesMan);
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
            return list;
        }

        public void Update(SalesMan obj)
        {
            string update = "UPDATE salesman SET name= @NAME, telephone= @TELEPHONE, cpf= @CPF, address= @ADDRESS WHERE idSalesman= @IDSALESMAN";

            try
            {
                command = new SqlCommand(update, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@NAME", obj.Name);
                command.Parameters.AddWithValue("@CPF", obj.Cpf);
                command.Parameters.AddWithValue("@TELEPHONE", obj.Telephone);
                command.Parameters.AddWithValue("@ADDRESS", obj.Address);
                command.Parameters.AddWithValue("@IDSALESMAN", obj.IdSalesMan);
                objConexaoDB.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                obj.State = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }
    }
}
