using Model.Dao;
using Model.Entity;
using Model.Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
   public class ClientDao : Intermediate<Client>
    {

        private ConexaoDB con;
        private SqlCommand command;
        private SqlDataReader reader;

        public ClientDao()
        {
            con = ConexaoDB.knowState();
        }

        public void Create1(Client client)
        {
            string script = @"INSERT INTO client(name, address, telephone, cpf) 
                              VALUES (@NAME, @ADDRESS, @TELEPHONE, @CPF)";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@NAME", client.Name);
                command.Parameters.AddWithValue("@ADDRESS", client.Address);
                command.Parameters.AddWithValue("@TELEPHONE", client.Telephone);
                command.Parameters.AddWithValue("@CPF", client.Cpf);
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

        public void Create(Client client)
        {
            string script = " sp_client_adc @NAME, @ADDRESS, @TELEPHONE, @CPF";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@NAME", client.Name);
                command.Parameters.AddWithValue("@ADDRESS", client.Address);
                command.Parameters.AddWithValue("@TELEPHONE", client.Telephone);
                command.Parameters.AddWithValue("@CPF", client.Cpf);
                
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

        public void Delete(Client client)
        {
            string script = @"DELETE FROM client WHERE idClient = @IDCLIENT";
            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDCLIENT", client.IdClient);
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

        public bool Find(Client client)
        {
            bool registers = true;

            string script = @"SELECT * FROM client(NOLOCK) WHERE idClient = @IDCLIENT";
            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDCLIENT", client.IdClient);
                con.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    client.Name = reader["name"].ToString();
                    client.Address = reader["address"].ToString();
                    client.Telephone = reader["telephone"].ToString();
                    client.Cpf = reader["cpf"].ToString();
                    client.State = 99;
                }
                else
                {
                    client.State = 1;
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

        public List<Client> FindAll()
        {
            List<Client> listClients = new List<Client>();
            string script = @"SELECT * FROM client(NOLOCK) ORDER BY idClient ASC";
            try
            {
                command = new SqlCommand(script, con.getCon());
                con.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Client client = new Client();
                    client.IdClient = Convert.ToInt64(reader["idClient"].ToString());
                    client.Name = reader["name"].ToString();
                    client.Address = reader["address"].ToString();
                    client.Telephone = reader["telephone"].ToString();
                    client.Cpf = reader["cpf"].ToString();
                    listClients.Add(client);
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

            return listClients;
        }

        public void Update(Client client)
        {
            string script = @"UPDATE client SET name= @NAME, 
                                                address= @ADDRESS, 
                                                telephone= @TELEPHONE, 
                                                cpf= @CPF 
                              WHERE idClient = @IDCLIENT";
            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@NAME", client.Name);
                command.Parameters.AddWithValue("@ADDRESS", client.Address);
                command.Parameters.AddWithValue("@TELEPHONE", client.Telephone);
                command.Parameters.AddWithValue("@CPF", client.Cpf);
                command.Parameters.AddWithValue("@IDCLIENT", client.IdClient);
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

        //OTHER ADDITIONAL IMPLEMENTATIONS
        public bool FindCustumerByCpf(Client client)
        {
            bool registers = true;
            string script = "SELECT * FROM client (NOLOCK) WHERE cpf = @CPF";
            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@CPF", client.Cpf);
                con.getCon().Open();

                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    client.Name = reader["name"].ToString();
                    client.Address = reader["address"].ToString();
                    client.Telephone = reader["telephone"].ToString();
                    client.Cpf = reader["cpf"].ToString();

                    client.State = 99;
                }
                else
                {
                    client.State = 1;
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

        public List<Client> FindAllClient(Client client)
        {
            List<Client> listClients = new List<Client>();
            string script = @"SELECT * FROM client (NOLOCK)
                              WHERE name LIKE '%' + @NAME + '%' OR cpf = @CPF OR idClient = @IDCLIENT";
            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@NAME", client.Name);
                command.Parameters.AddWithValue("@CPF", client.Cpf);
                command.Parameters.AddWithValue("@IDCLIENT", client.IdClient);
                con.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    client.IdClient = Convert.ToInt64(reader["idClient"].ToString());
                    client.Name = reader["name"].ToString();
                    client.Address = reader["address"].ToString();
                    client.Telephone = reader["telephone"].ToString();
                    client.Cpf = reader["cpf"].ToString();
                    listClients.Add(client);

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
            return listClients;
        }
    }
}
