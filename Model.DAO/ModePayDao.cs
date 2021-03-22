using Model.Dao;
using Model.Entity;
using Model.Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class ModePayDao : Intermediate<ModePay>
    {
        private ConexaoDB con;
        private SqlCommand command;
        private SqlDataReader reader;

        public ModePayDao()
        {
            con = ConexaoDB.knowState();
        }

        public void Create(ModePay modePay)
        {
            string script = @"INSERT INTO modePay (name,otherDetails) 
                              VALUES (@NAME, @OTHERDETAILS)";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@NAME", modePay.Name);
                command.Parameters.AddWithValue("@OTHERDETAILS", modePay.OtherDetails);
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

        public void Delete(ModePay modePay)
        {
            string script = @"DELETE FROM modePay WHERE idPay = @IDMODEPAY";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDMODEPAY", modePay.IdModePay);
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

        public bool Find(ModePay modePay)
        {
            bool registers = true;
            string script = @"SELECT * FROM modePay (NOLOCK) WHERE idPay = @IDMODEPAY"; 

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDMODEPAY", modePay.IdModePay);
                con.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    modePay.Name = reader["name"].ToString();
                    modePay.OtherDetails = reader["otherDetails"].ToString();
                    modePay.State = 99;
                }
                else
                {
                    modePay.State = 1;
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

        public List<ModePay> FindAll()
        {
            List<ModePay> list = new List<ModePay>();
            String script = "SELECT * FROM modePay (NOLOCK) ORDER BY name ASC";

            try
            {
                command = new SqlCommand(script, con.getCon());
                con.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ModePay modePay = new ModePay();
                    modePay.IdModePay = Convert.ToInt32(reader["idPay"].ToString());
                    modePay.Name = reader["name"].ToString();
                    modePay.OtherDetails = reader["otherDetails"].ToString();
                    list.Add(modePay);
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

        public void Update(ModePay modePay)
        {
            string script = "UPDATE modePay SET name= @NAME, otherDetails= @OTHERDETAILS WHERE idPay= @IDMODEPAY";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@NAME", modePay.Name);
                command.Parameters.AddWithValue("@OTHERDETAILS", modePay.OtherDetails);
                command.Parameters.AddWithValue("@IDMODEPAY", modePay.IdModePay);
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
