using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Sale
    {
        private long idSale;
        private double total;
        private long idClient;
        private string idSalesMan;
        private string data;
        private double rate;
        private int state;

        public Sale()
        {
        }

        public Sale(long idSale)
        {
            this.idSale = idSale;
        }

        public Sale(long idSale, double total, long idClient, string idSalesMan, string data, double rate)
        {
            this.idSale = idSale;
            this.total = total;
            this.idClient = idClient;
            this.idSalesMan = idSalesMan;
            this.data = data;
            this.rate = rate;
        }

        public long IdSale
        {
            get => idSale;
            set => idSale = value;
        }

        public double Total
        {
            get => total;
            set => total = value;
        }

        [Display(Name = "Cliente")]
        public long IdClient
        {
            get => idClient;
            set => idClient = value;
        }

        [Display (Name = "Vendedor")]
        public string IdSalesMan
        {
            get => idSalesMan;
            set => idSalesMan = value;
        }

        public string Data
        {
            get => data;
            set => data = value;
        }

        [Display(Name = "Taxa")]
        public double Rate
        {
            get => rate;
            set => rate = value;
        }

        public int State
        {
            get => state;
            set => state = value;
        }
    }
}
