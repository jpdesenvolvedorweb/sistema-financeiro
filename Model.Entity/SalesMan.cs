namespace Model.Entity
{
    public class SalesMan : Person
    {
        private string idSalesMan;

        public SalesMan()
        {
        }
        public SalesMan(string idSalesMan)
        {
            this.idSalesMan = idSalesMan;
        }

        public SalesMan(string idSalesMan, string name, string cpf, string address, string telephone, int state)
            :base(name, cpf,address,telephone,state)
        {
            this.idSalesMan = idSalesMan;
        }

        public string IdSalesMan
        {
            get => idSalesMan;
            set => idSalesMan = value;
        }
    }
}
