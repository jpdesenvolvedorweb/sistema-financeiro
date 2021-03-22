namespace Model.Entity
{
    public class ProductList
    {
        private string idProduct;
        private string name;
        private double unitPrice;
        private int state;
        private string nameProduct;

        public ProductList()
        {
        }

        public ProductList(string idProduct)
        {
            this.idProduct = idProduct;   
        }

        public ProductList(string idProduct, string name, double unitPrice, string nameProduct)
        {
            this.idProduct = idProduct;
            this.name = name;
            this.unitPrice = unitPrice;
            this.nameProduct = nameProduct;
        }

        public string IdProduct
        {
            get => idProduct;
            set => idProduct = value;
        }

        public string Name
        {
            get => name;
            set =>  name= value;
        }

        public double UnitPrice
        {
            get => unitPrice;
            set => unitPrice = value;
        }

        public string NameProduct
        {
            get => nameProduct;
            set => nameProduct = value;
        }

        public int State
        {
            get => state;
            set => state = value;
        }
    }
}
