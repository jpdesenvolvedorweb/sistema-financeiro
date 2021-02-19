using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Neg
{
    public class ProductNeg
    {
        private ProductDao objProductDao;

        public ProductNeg()
        {
            objProductDao = new ProductDao();
        }

        public void Create(Product product)
        {
            bool verification = true;

            string idProduct = product.IdProduct;
            if (idProduct == null || idProduct.Trim().Equals(""))
            {
                product.State = 10;
                return;
            }
            else
            {
                idProduct = product.IdProduct.Trim();
                verification = idProduct.Length > 0 && idProduct.Length <= 5;
                if (!verification)
                {
                    product.State = 1;
                    return;
                }
            }

            string name = product.Name;
            if (name == null || name.Trim().Equals(""))
            {
                product.State = 20;
                return;
            }
            else
            {
                name = product.Name.Trim();
                verification = name.Length > 0 && name.Length <= 30;
                if (!verification)
                {
                    product.State = 2;
                    return;
                }
            }

            string unitPrice = product.UnitPrice.ToString();
            double unitPri = 0;
            if (unitPrice == null || unitPrice.Trim().Equals(""))
            {
                product.State = 30;
                return;
            }
            else
            {
                try
                {
                    unitPri = Convert.ToDouble(product.UnitPrice);
                    verification = unitPri > 0 && unitPri <= 9999999;
                    if (!verification)
                    {
                        product.State = 3;
                        return;
                    }
                }
                catch (Exception)
                {
                    product.State = 300;
                    return;
                }
            }

            string idCategory = product.IdCategory;
            if (idCategory == null || idCategory.Trim().Equals(""))
            {
                product.State = 40;
                return;
            }
            else
            {
                idCategory = product.IdCategory.Trim();
                verification = idCategory.Length > 0 && idCategory.Length <= 30;
                if (!verification)
                {
                    product.State = 4;
                    return;
                }
            }

            Product productAux = new Product();
            productAux.IdProduct = product.IdProduct;
            verification = !objProductDao.Find(productAux);
            if (!verification)
            {
                product.State = 5;
                return;
            }

            objProductDao.Create(product);
            product.State = 99;
            return;
        }

        public void Update(Product product)
        {

            bool verification = true;

            string name = product.Name;
            if (name == null || name.Trim().Equals(""))
            {
                product.State = 20;
                return;
            }
            else
            {
                name = product.Name.Trim();
                verification = name.Length > 0 && name.Length <= 50;
                if (!verification)
                {
                    product.State = 2;
                    return;
                }
            }

            string unitPrice = product.UnitPrice.ToString();
            double unitPri = 0;
            if (unitPrice == null || unitPrice.Trim().Equals(""))
            {
                product.State = 30;
                return;
            }
            else
            {
                try
                {
                    unitPri = Convert.ToDouble(product.UnitPrice);
                    verification = unitPri > 0 && unitPri < 999999;
                    if (!verification)
                    {
                        product.State = 3;
                        return;
                    }
                }
                catch (Exception)
                {
                    product.State = 300;
                    return;
                }
            }

            string idCategory = product.IdCategory;
            if (idCategory == null || idCategory.Trim().Equals(""))
            {
                product.State = 40;
                return;
            }
            else
            {
                idCategory = product.IdCategory.Trim();
                verification = idCategory.Length > 0 && idCategory.Length <= 5;
                if (!verification)
                {
                    product.State = 4;
                    return;
                }
            }

            /*
            Product productAux = new Product();
            productAux.IdProduct = product.IdProduct;
            verification = !objProductDao.Find(productAux);
            if (!verification)
            {
                product.State = 33;
                return;
            }
            */

            objProductDao.Update(product);
            product.State = 99;
            return;
        }

        public void Delete(Product product)
        {
            bool verification = true;
            Product productAux = new Product();
            productAux.IdProduct = product.IdProduct;
            verification = objProductDao.Find(productAux);
            if (!verification)
            {
                product.State = 33;
                return;
            }

            objProductDao.Delete(product);
            product.State = 99;
            return;
        }

        public bool Find(Product product)
        {
            return objProductDao.Find(product);
        }

        public List<Product> FindAll()
        {
            return objProductDao.FindAll();
        }

        public List<Product> FindAllCat(Product product)
        {
            return objProductDao.FindAllCat(product);
        }

    }
}
