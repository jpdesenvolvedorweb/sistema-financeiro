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
            string create = "INSERT INTO category VALUES('" + obj.IdCategory + "','" + obj.Name + "', '" + obj.Description + "')";

            try
            {
                command = new SqlCommand(create, objConexaoDb.getCon());
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
            string delete = "DELETE FROM category WHERE idCategory = '" + obj.IdCategory + "'";

            try
            {
                command = new SqlCommand(delete, objConexaoDb.getCon());
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

            string find = "SELECT * FROM category WHERE idCategory = '" + obj.IdCategory + "' ";

            try
            {
                command = new SqlCommand(find, objConexaoDb.getCon());
                objConexaoDb.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    obj.Name = reader[1].ToString();
                    obj.Description = reader[2].ToString();

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

            string find = "SELECT * FROM category WHERE name = '" + obj.Name + "' ";

            try
            {
                command = new SqlCommand(find, objConexaoDb.getCon());
                objConexaoDb.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    obj.Name = reader[1].ToString();
                    obj.Description = reader[2].ToString();

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
            string findAll = "SELECT * FROM category ORDER BY name ASC";

            try
            {
                command = new SqlCommand(findAll, objConexaoDb.getCon());
                objConexaoDb.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category obj = new Category();
                    obj.IdCategory = reader[0].ToString();
                    obj.Name = reader[1].ToString();
                    obj.Description = reader[2].ToString();

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
            string update = "update category set name= '" + obj.Name + "', description= '" + obj.Description + "' where idCategory= '" + obj.IdCategory + "'";

            try
            {
                command = new SqlCommand(update, objConexaoDb.getCon());
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
