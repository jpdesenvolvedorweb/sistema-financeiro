using Model.Dao;
using Model.Entity;
using Model.Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class CategoryDao : Intermediate<Category>
    {
        private ConexaoDB con;
        private SqlCommand command;
        private SqlDataReader reader;

        public CategoryDao()
        {
            con = ConexaoDB.knowState();
        }

        public void Create(Category category)
        {
            string script = @"INSERT INTO category VALUES(@IDCATEGORY, @NAME, @DESCRIPTION)";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDCATEGORY",category.IdCategory);
                command.Parameters.AddWithValue("@NAME", category.Name);
                command.Parameters.AddWithValue("@DESCRIPTION", category.Description);
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

        public void Delete(Category category)
        {
            string script = @"DELETE FROM category WHERE idCategory = @IDCATEGORY";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDCATEGORY", category.IdCategory);
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

        public bool Find(Category category)
        {
            bool registers = true;

            string script = @"SELECT * FROM category(NOLOCK) WHERE idCategory = @IDCATEGORY";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDCATEGORY",category.IdCategory);
                con.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    category.Name = reader["name"].ToString();
                    category.Description = reader["description"].ToString();

                    category.State = 99;
                }
                else
                {
                    category.State = 1;
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

        //Find com nome da categoria
        public bool FindCat(Category category)
        {
            bool registers = true;

            string script = @"SELECT * FROM category(NOLOCK) WHERE name = @NAME";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@NAME", category.Name);
                con.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    category.Name = reader["name"].ToString();
                    category.Description = reader["description"].ToString();

                    category.State = 99;
                }
                else
                {
                    category.State = 1;
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

        public List<Category> FindAll()
        {
            List<Category> listCategories = new List<Category>();
            string script = "SELECT * FROM category(NOLOCK) ORDER BY name ASC";

            try
            {
                command = new SqlCommand(script, con.getCon());
                con.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.IdCategory = reader["idCategory"].ToString();
                    category.Name = reader["name"].ToString();
                    category.Description = reader["description"].ToString();

                    listCategories.Add(category);
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
            return listCategories;
        }

        public void Update(Category category)
        {
            string script = @"UPDATE category SET name= @NAME, 
                                                  description= @DESCRIPTION 
                              WHERE idCategory = @IDCATEGORY";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@NAME", category.Name);
                command.Parameters.AddWithValue("@DESCRIPTION", category.Description);
                command.Parameters.AddWithValue("@IDCATEGORY", category.IdCategory);
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
