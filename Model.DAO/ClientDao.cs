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
            string create = @"INSERT INTO client(name, address, telephone, cpf) VALUES (@NAME, @ADDRESS, @TELEPHONE, @CPF)";

            try
            {
                command = new SqlCommand(create, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@NAME", obj.Name);
                command.Parameters.AddWithValue("@ADDRESS", obj.Address);
                command.Parameters.AddWithValue("@TELEPHONE", obj.Telephone);
                command.Parameters.AddWithValue("@CPF", obj.Cpf);
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
            string delete = @"DELETE FROM client WHERE idClient = @IDCLIENT";
            try
            {
                command = new SqlCommand(delete, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDCLIENT", obj.IdClient);
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

            string find = @"SELECT * FROM client(NOLOCK) WHERE idClient = @IDCLIENT";
            try
            {
                command = new SqlCommand(find, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDCLIENT", obj.IdClient);
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
            string findAll = @"SELECT * FROM client(NOLOCK) ORDER BY idClient ASC";
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
            string update = @"UPDATE client SET name= @NAME, address= @ADDRESS, telephone= @TELEPHONE, cpf= @CPF WHERE idClient = @IDCLIENT";
            try
            {
                command = new SqlCommand(update, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@NAME", obj.Name);
                command.Parameters.AddWithValue("@ADDRESS", obj.Address);
                command.Parameters.AddWithValue("@TELEPHONE", obj.Telephone);
                command.Parameters.AddWithValue("@CPF", obj.Cpf);
                command.Parameters.AddWithValue("@IDCLIENT", obj.IdClient);
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
            string find = "SELECT * FROM client (NOLOCK) WHERE cpf = @CPF";
            try
            {
                command = new SqlCommand(find, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@CPF", obj.Cpf);
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
            string findAll = "SELECT * FROM client (NOLOCK) WHERE name LIKE '% @NAME %' OR cpf LIKE '% @CPF %' OR idClient LIKE  '% @IDCLIENT %'";
            try
            {
                command = new SqlCommand(findAll, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@NAME", obj.Name);
                command.Parameters.AddWithValue("@CPF", obj.Cpf);
                command.Parameters.AddWithValue("@IDCLIENT", obj.IdClient);
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
