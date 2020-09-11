using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
   public class ClientDao : Intermediate<Client>
    {

        private ConexaoDB objConexaoDB;
        private SqlCommand command;
        private SqlDataReader reader;

        public ClientDao()
        {
            objConexaoDB = ConexaoDB.knowState();
        }

        public void Create1(Client obj)
        {
            string create = "insert into client(name, address, telephone, cpf) VALUES ('" + obj.Name + "', '" + obj.Address + "', '" + obj.Telephone + "', '" + obj.Cpf + "')";

            try
            {
                command = new SqlCommand(create, objConexaoDB.getCon());
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

        public void Create(Client obj)
        {
            string create = " sp_client_adc" + obj.Name + "," + obj.Address + "," + obj.Telephone + "," + obj.Cpf + "";

            try
            {
                command = new SqlCommand(create, objConexaoDB.getCon());
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

        public void Delete(Client obj)
        {
            string delete = "delete from client where idClient = '" + obj.IdClient + "'";
            try
            {
                command = new SqlCommand(delete, objConexaoDB.getCon());
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

        public bool Find(Client obj)
        {
            bool registers;

            string find = "select * from client where idClient = '" + obj.IdClient + "' ";
            try
            {
                command = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    obj.Name = reader[1].ToString();
                    obj.Address = reader[2].ToString();
                    obj.Telephone = reader[3].ToString();
                    obj.Cpf = reader[4].ToString();
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

        public List<Client> FindAll()
        {
            List<Client> listClients = new List<Client>();
            string findAll = "select * from client order by idClient asc";
            try
            {
                command = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Client obj = new Client();
                    obj.IdClient = Convert.ToInt64(reader[0].ToString());
                    obj.Name = reader[1].ToString();
                    obj.Address = reader[2].ToString();
                    obj.Telephone = reader[3].ToString();
                    obj.Cpf = reader[4].ToString();
                    listClients.Add(obj);
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

            return listClients;
        }

        public void Update(Client obj)
        {
            string update = "update client set name= '" + obj.Name + "', address= '" + obj.Address + "', telephone= '" + obj.Telephone + "', cpf= '" + obj.Cpf + "' where idClient= '" + obj.IdClient + "'";
            try
            {
                command = new SqlCommand(update, objConexaoDB.getCon());
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

        //OTHER ADDITIONAL IMPLEMENTATIONS
        public bool FindCustumerByCpf(Client obj)
        {
            bool registers;
            string find = "Select * from client where cpf = '" + obj.Cpf + "'";
            try
            {
                command = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    obj.Name = reader[1].ToString();
                    obj.Address = reader[2].ToString();
                    obj.Telephone = reader[3].ToString();
                    obj.Cpf = reader[4].ToString();

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

        public List<Client> FindAllClient(Client obj)
        {
            List<Client> listClients = new List<Client>();
            string findAll = "select * from client where name like '%" + obj.Name + "%' or cpf like '%" + obj.Cpf + "%' or idClient like  '%" + obj.IdClient + "%' ";
            try
            {
                command = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Client objClient = new Client();
                    objClient.IdClient = Convert.ToInt64(reader[0].ToString());
                    objClient.Name = reader[1].ToString();
                    objClient.Address = reader[2].ToString();
                    objClient.Telephone = reader[3].ToString();
                    objClient.Cpf = reader[4].ToString();
                    listClients.Add(objClient);

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

            return listClients;
        }
    }
}
