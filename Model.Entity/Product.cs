using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Product
    {
        private string idProduct;
        private string name;
        private double unitPrice;
        private int state;
        private string idCategory;


        public Product()
        {

        }

        public Product(string idProduct)
        {
            this.idProduct = idProduct;
        }

        public Product(string idProduct, string name, double unitPrice, string idCategory)
        {
            this.idProduct = idProduct;
            this.name = name;
            this.unitPrice = unitPrice;
            this.idCategory = idCategory;
        }

        [Display(Name = "Código")]
        public string IdProduct
        {
            get => idProduct;
            set => idProduct = value;
        }

        [Display(Name = "Nome")]
        public string Name
        {
            get => name;
            set => name = value;
        }

        [Display(Name = "Preço Unitário")]
        public double UnitPrice
        {
            get => unitPrice;
            set => unitPrice = value;
        }

        [Display(Name = "Categoria")]
        public string IdCategory
        {
            get => idCategory;
            set => idCategory = value;
        }

        public int State
        {
            get => state;
            set => state = value;
        }

    }
}
