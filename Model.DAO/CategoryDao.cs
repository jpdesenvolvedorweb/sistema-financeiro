using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class CategoryDao : Intermediate<Category>
    {
        private ConexaoDB objConexaoDb;
        private SqlCommand command;
        private SqlDataReader reader;

        public CategoryDao()
        {
            objConexaoDb = ConexaoDB.knowState();
        }

        public void Create(Category obj)
        {
            string create = @"INSERT INTO category VALUES(@IDCATEGORY, @NAME, @DESCRIPTION)";

            try
            {
                command = new SqlCommand(create, objConexaoDb.getCon());
                command.Parameters.AddWithValue("@IDCATEGORY",obj.IdCategory);
                command.Parameters.AddWithValue("@NAME", obj.Name);
                command.Parameters.AddWithValue("@DESCRIPTION", obj.Description);
                objConexaoDb.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                obj.State = 1000;
            }
            finally
            {
                objConexaoDb.getCon().Close();
                objConexaoDb.CloseDB();
            }
        }

        public void Delete(Category obj)
        {
            string delete = @"DELETE FROM category WHERE idCategory = @IDCATEGORY";

            try
            {
                command = new SqlCommand(delete, objConexaoDb.getCon());
                command.Parameters.AddWithValue("@IDCATEGORY", obj.IdCategory);
                objConexaoDb.getCon().Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                obj.State = 1000;
            }
            finally
            {
                objConexaoDb.getCon().Close();
                objConexaoDb.CloseDB();
            }
        }

        public bool Find(Category obj)
        {
            bool registers;

            string find = @"SELECT * FROM category(NOLOCK) WHERE idCategory = @IDCATEGORY";

            try
            {
                command = new SqlCommand(find, objConexaoDb.getCon());
                command.Parameters.AddWithValue("@IDCATEGORY",obj.IdCategory);
                objConexaoDb.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    obj.Name = reader["name"].ToString();
                    obj.Description = reader["description"].ToString();

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
                objConexaoDb.getCon().Close();
                objConexaoDb.CloseDB();
            }

            return registers;
        }

        //Find com nome da categoria
        public bool FindCat(Category obj)
        {
            bool registers;

            string find = @"SELECT * FROM category(NOLOCK) WHERE name = @NAME ";

            try
            {
                command = new SqlCommand(find, objConexaoDb.getCon());
                command.Parameters.AddWithValue("@NAME", obj.Name);
                objConexaoDb.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    obj.Name = reader["name"].ToString();
                    obj.Description = reader["description"].ToString();

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
                objConexaoDb.getCon().Close();
                objConexaoDb.CloseDB();
            }

            return registers;
        }

        public List<Category> FindAll()
        {
            List<Category> listCategories = new List<Category>();
            string findAll = "SELECT * FROM category(NOLOCK) ORDER BY name ASC";

            try
            {
                command = new SqlCommand(findAll, objConexaoDb.getCon());
                objConexaoDb.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category obj = new Category();
                    obj.IdCategory = reader["idCategory"].ToString();
                    obj.Name = reader["name"].ToString();
                    obj.Description = reader["description"].ToString();

                    listCategories.Add(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexaoDb.getCon().Close();
                objConexaoDb.CloseDB();
            }
            return listCategories;
        }

        public void Update(Category obj)
        {
            string update = @"UPDATE category SET name= @NAME, description= @DESCRIPTION WHERE idCategory = @IDCATEGORY";

            try
            {
                command = new SqlCommand(update, objConexaoDb.getCon());
                command.Parameters.AddWithValue("@NAME", obj.Name);
                command.Parameters.AddWithValue("@DESCRIPTION", obj.Description);
                command.Parameters.AddWithValue("@IDCATEGORY", obj.IdCategory);
                objConexaoDb.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                obj.State = 1000;
            }
            finally
            {
                objConexaoDb.getCon().Close();
                objConexaoDb.CloseDB();
            }
        }
    }
}
