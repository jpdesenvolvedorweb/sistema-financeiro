using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Neg
{
    public class CategoryNeg
    {
        private CategoryDao objCategoryDao;
        private ProductDao objProductDao;

        public CategoryNeg()
        {
            objCategoryDao = new CategoryDao();
            objProductDao = new ProductDao();
        }

        public void create(Category objCategory)
        {
            Category objCategoryAux = new Category();
            bool verification = true;

            string code = objCategory.IdCategory;
            if (code == null || code.Trim().Equals(""))
            {
                objCategory.State = 10;
                return;
            }
            else
            {
                code = objCategory.IdCategory.Trim();
                verification = code.Length > 0 && code.Length <= 5;
                if (!verification)
                {
                    objCategory.State = 1;
                    return;
                }
            }

            string name = objCategory.Name;
            if (name == null || name.Equals(""))
            {
                objCategory.State = 20;
                return;
            }
            else
            {
                name = objCategory.Name.Trim();
                verification = name.Length > 0 && name.Length <= 30;
                if (!verification)
                {
                    objCategory.State = 2;
                    return;
                }
            }

            string description = objCategory.Description;
            if (description == null || description.Trim().Equals(""))
            {
                objCategory.State = 30;
                return;
            }
            else
            {
                description = objCategory.Description.Trim();
                verification = description.Length > 0 && description.Length <= 50;
                if (!verification)
                {
                    objCategory.State = 3;
                    return;
                }
            }

            
            objCategoryAux.IdCategory = objCategory.IdCategory;
            verification = !objCategoryDao.Find(objCategoryAux);
            if (!verification)
            {
                objCategory.State = 8;
                return;
            }

            //verificar o nome
            objCategoryAux.Name = objCategory.Name;
            verification = !objCategoryDao.FindCat(objCategoryAux);
            if (!verification)
            {
                objCategory.State = 16;
                return;
            }

            objCategory.State = 99;
            objCategoryDao.Create(objCategory);
            return;
        }

        public void update(Category objCategory)
        {
            Category objCategoryAux = new Category();
            bool verification = true;


            string name = objCategory.Name;
            if (name == null || name.Trim().Equals(""))
            {
                objCategory.State = 20;
                return;
            }
            else
            {
                name = objCategory.Name.Trim();
                verification = name.Length > 0 && name.Length <= 30;
                if (!verification)
                {
                    objCategory.State = 2;
                    return;
                }
            }

            string description = objCategory.Description;
            if (description == null || description.Trim().Equals(""))
            {
                objCategory.State = 30;
                return;
            }
            else
            {
                description = objCategory.Description.Trim();
                verification = description.Length > 0 && description.Length <= 50;
                if (!verification)
                {
                    objCategory.State = 3;
                    return;
                }
            }

            objCategoryAux.Name = objCategory.Name;
            verification = !objCategoryDao.FindCat(objCategoryAux);
            if (!verification)
            {
                objCategory.State = 16;
                return;
            }

            objCategory.State = 99;
            objCategoryDao.Update(objCategory);
            return;
        }

        public void delete(Category objCategory)
        {
            bool verification = true;

            Category objCategoryAux = new Category();
            objCategoryAux.IdCategory = objCategory.IdCategory;
            verification = objCategoryDao.Find(objCategoryAux);
            if (!verification)
            {
                objCategory.State = 33;
                return;
            }

            Product objProduct = new Product();
            objProduct.IdCategory = objCategory.IdCategory;
            verification = !objProductDao.FindCat(objProduct);
            if (!verification)
            {
                objCategory.State = 34;
                return;
            }

            objCategory.State = 99;
            objCategoryDao.Delete(objCategory);
            return;
        }

        public bool find(Category objCategory)
        {
            return objCategoryDao.Find(objCategory);
        }

        public List<Category> findAll()
        {
            return objCategoryDao.FindAll();
        }
    }
}
