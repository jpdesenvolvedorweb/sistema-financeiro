using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class ModePayDao : Intermediate<ModePay>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand command;
        private SqlDataReader reader;

        public ModePayDao()
        {
            objConexaoDB = ConexaoDB.knowState();
        }

        public void Create(ModePay obj)
        {

            string create = @"INSERT INTO modePay (name,otherDetails) VALUES (@NAME, @OTHERDETAILS)";

            try
            {
                command = new SqlCommand(create, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@NAME", obj.Name);
                command.Parameters.AddWithValue("@OTHERDETAILS", obj.OtherDetails);
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

        public void Delete(ModePay obj)
        {
            string delete = @"DELETE FROM modePay WHERE idPay = @IDMODEPAY";

            try
            {
                command = new SqlCommand(delete, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDMODEPAY", obj.IdModePay);
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

        public bool Find(ModePay obj)
        {
            bool registers = true;
            string find = @"SELECT * FROM modePay (NOLOCK) WHERE idPay = @IDMODEPAY"; 

            try
            {
                command = new SqlCommand(find, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDMODEPAY", obj.IdModePay);
                objConexaoDB.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    obj.Name = reader["name"].ToString();
                    obj.OtherDetails = reader["otherDetails"].ToString();
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

        public List<ModePay> FindAll()
        {
            String findAll = "SELECT * FROM modePay (NOLOCK) ORDER BY name ASC";
            List<ModePay> list = new List<ModePay>();

            try
            {
                command = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ModePay objModePayAux = new ModePay();
                    objModePayAux.IdModePay = Convert.ToInt32(reader["idPay"].ToString());
                    objModePayAux.Name = reader["name"].ToString();
                    objModePayAux.OtherDetails = reader["otherDetails"].ToString();

                    list.Add(objModePayAux);
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

        public void Update(ModePay obj)
        {
            string update = "UPDATE modePay SET name= @NAME, otherDetails= @OTHERDETAILS WHERE idPay= @IDMODEPAY";

            try
            {
                command = new SqlCommand(update, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@NAME", obj.Name);
                command.Parameters.AddWithValue("@OTHERDETAILS", obj.OtherDetails);
                command.Parameters.AddWithValue("@IDMODEPAY", obj.IdModePay);
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
