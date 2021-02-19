using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class ProductDao : Intermediate<Product>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand command;
        private SqlDataReader reader;

        public ProductDao()
        {
            objConexaoDB = ConexaoDB.knowState();
        }

        public void Create(Product obj)
        {
            string create = @"INSERT INTO product VALUES(@IDPRODUCT, @NAME, @UNITPRICE, @IDCATEGORY)";

            try
            {
                command = new SqlCommand(create, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDPRODUCT", obj.IdProduct);
                command.Parameters.AddWithValue("@NAME", obj.Name);
                command.Parameters.AddWithValue("@UNITPRICE", obj.UnitPrice);
                command.Parameters.AddWithValue("@IDCATEGORY", obj.IdCategory);
                objConexaoDB.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                obj.State = 1000;
                return;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void Delete(Product obj)
        {
            string delete = @"DELETE FROM product WHERE idProduct = @IDPRODUCT";

            try
            {
                command = new SqlCommand(delete,objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDPRODUCT", obj.IdProduct);
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

        public bool Find(Product obj)
        {
            bool registers = true;
            string find = "SELECT * FROM product (NOLOCK) WHERE idProduct = @IDPRODUCT";

            try
            {
                command = new SqlCommand(find, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDPRODUCT", obj.IdProduct);
                objConexaoDB.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    obj.Name = reader[1].ToString();
                    obj.UnitPrice = Convert.ToDouble(reader[2].ToString());
                    obj.IdCategory = reader[3].ToString();
                    obj.State = 99;
                }
                else
                {
                    obj.State = 1;
                }
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

            return registers;
        }

        public bool FindCat(Product obj)
        {
            bool registers = true;
            string find = "SELECT * FROM product (NOLOCK) WHERE idCategory = @IDCATEGORY";

            try
            {
                command = new SqlCommand(find, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDCATEGORY", obj.IdCategory);
                objConexaoDB.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    obj.IdProduct = reader[0].ToString();
                    obj.Name = reader[1].ToString();
                    obj.UnitPrice = Convert.ToDouble(reader[2].ToString());
                    obj.IdCategory = reader[3].ToString();
                    obj.State = 99;
                }
                else
                {
                    obj.State = 1;
                }
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

            return registers;
        }

        public List<Product> FindAll()
        {
            string findAll = "SELECT * FROM product(NOLOCK) ORDER BY name ASC";
            List<Product> list = new List<Product>();

            try
            {
                command = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.IdProduct = reader[0].ToString();
                    product.Name = reader[1].ToString();
                    product.UnitPrice = Convert.ToDouble(reader[2].ToString());
                    product.IdCategory = reader[3].ToString();

                    list.Add(product);
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

        public List<Product> FindAllCat(Product obj)
        {
            string findAll = "SELECT * FROM product (NOLOCK) WHERE idCategory = @IDCATEGORY"; 
            List<Product> list = new List<Product>();

            try
            {
                command = new SqlCommand(findAll, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@IDCATEGORY", obj.IdCategory);
                objConexaoDB.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product productAux = new Product();
                    productAux.IdProduct = reader[0].ToString();
                    productAux.Name = reader[1].ToString();
                    productAux.UnitPrice = Convert.ToDouble(reader[2].ToString());
                    productAux.IdCategory = reader[3].ToString();

                    list.Add(productAux);
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

        public void Update(Product obj)
        {
            string update = @"UPDATE product SET name = @NAME, unitPrice= @UNITPRICE, idCategory= @IDCATEGORY WHERE idProduct= @IDPRODUCT";

            try
            {
                command = new SqlCommand(update, objConexaoDB.getCon());
                command.Parameters.AddWithValue("@NAME", obj.Name);
                command.Parameters.AddWithValue("@UNITPRICE", obj.UnitPrice);
                command.Parameters.AddWithValue("@IDCATEGORY", obj.IdCategory);
                command.Parameters.AddWithValue("@IDPRODUCT", obj.IdProduct);
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
