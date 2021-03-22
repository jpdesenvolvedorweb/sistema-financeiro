using Model.Dao;
using Model.Entity;
using Model.Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class ProductDao : Intermediate<Product>
    {
        private ConexaoDB con;
        private SqlCommand command;
        private SqlDataReader reader;

        public ProductDao()
        {
            con = ConexaoDB.knowState();
        }

        public void Create(Product product)
        {
            string script = @"INSERT INTO product VALUES(@IDPRODUCT, @NAME, @UNITPRICE, @IDCATEGORY)";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDPRODUCT", product.IdProduct);
                command.Parameters.AddWithValue("@NAME", product.Name);
                command.Parameters.AddWithValue("@UNITPRICE", product.UnitPrice);
                command.Parameters.AddWithValue("@IDCATEGORY", product.IdCategory);
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

        public void Delete(Product product)
        {
            string script = @"DELETE FROM product WHERE idProduct = @IDPRODUCT";

            try
            {
                command = new SqlCommand(script,con.getCon());
                command.Parameters.AddWithValue("@IDPRODUCT", product.IdProduct);
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

        public bool Find(Product product)
        {
            bool registers = true;
            string script = "SELECT * FROM product (NOLOCK) WHERE idProduct = @IDPRODUCT";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDPRODUCT", product.IdProduct);
                con.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    product.Name = reader["name"].ToString();
                    product.UnitPrice = Convert.ToDouble(reader["unitPrice"].ToString());
                    product.IdCategory = reader["idCategory"].ToString();
                    product.State = 99;
                }
                else
                {
                    product.State = 1;
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

        public bool FindCat(Product product)
        {
            bool registers = true;
            string script = "SELECT * FROM product (NOLOCK) WHERE idCategory = @IDCATEGORY";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDCATEGORY", product.IdCategory);
                con.getCon().Open();
                reader = command.ExecuteReader();
                registers = reader.Read();
                if (registers)
                {
                    product.IdProduct = reader["idProduct"].ToString();
                    product.Name = reader["name"].ToString();
                    product.UnitPrice = Convert.ToDouble(reader["unitPrice"].ToString());
                    product.IdCategory = reader["idCategory"].ToString();
                    product.State = 99;
                }
                else
                {
                    product.State = 1;
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

        public List<Product> FindAll()
        {
            List<Product> list = new List<Product>();
            string script = "SELECT * FROM product(NOLOCK) ORDER BY name ASC";
 
            try
            {
                command = new SqlCommand(script, con.getCon());
                con.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.IdProduct = reader["idProduct"].ToString();
                    product.Name = reader["name"].ToString();
                    product.UnitPrice = Convert.ToDouble(reader["unitPrice"].ToString());
                    product.IdCategory = reader["idCategory"].ToString();
                    list.Add(product);
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

        public List<Product> FindAllCat(Product product)
        {
            List<Product> list = new List<Product>();
            string script = "SELECT * FROM product (NOLOCK) WHERE idCategory = @IDCATEGORY"; 

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@IDCATEGORY", product.IdCategory);
                con.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product.IdProduct = reader["idProduct"].ToString();
                    product.Name = reader["name"].ToString();
                    product.UnitPrice = Convert.ToDouble(reader["unitPrice"].ToString());
                    product.IdCategory = reader["idCategory"].ToString();

                    list.Add(product);
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

        public void Update(Product product)
        {
            string script = @"UPDATE product SET name = @NAME, unitPrice= @UNITPRICE, idCategory= @IDCATEGORY WHERE idProduct= @IDPRODUCT";

            try
            {
                command = new SqlCommand(script, con.getCon());
                command.Parameters.AddWithValue("@NAME", product.Name);
                command.Parameters.AddWithValue("@UNITPRICE", product.UnitPrice);
                command.Parameters.AddWithValue("@IDCATEGORY", product.IdCategory);
                command.Parameters.AddWithValue("@IDPRODUCT", product.IdProduct);
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

        #region "Listar Produto completo"

        public List<ProductList> findAllProducts()
        {
            List<ProductList> list = new List<ProductList>();
            string script = @"SELECT P.idProduct AS idProduct,
                                     P.name AS nameProduct,
                                     P.unitPrice AS unitPrice,
                                     C.name AS nomeCategory
                             FROM product P
                             INNER JOIN category C ON C.idCategory = P.idCategory 
                             ORDER BY C.name";
            try
            {
                command = new SqlCommand(script, con.getCon());
                con.getCon().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProductList product = new ProductList();
                    product.IdProduct = reader["idProduct"].ToString();
                    product.Name = reader["nameProduct"].ToString();
                    product.UnitPrice = Convert.ToDouble(reader["unitPrice"].ToString());
                    product.NameProduct = reader["nomeCategory"].ToString();
                    list.Add(product);
                }
            }
            catch(Exception erro)
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
        #endregion
    }
}
