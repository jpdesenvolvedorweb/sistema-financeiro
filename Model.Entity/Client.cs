namespace Model.Entity
{
    public class Client: Person
    {
        private long idClient;

        public Client()
        {

        }

        public Client(long idClient)
        {
            this.IdClient = idClient;
        }

        public Client(long idClient, string name, string cpf, string address, string telephone, int state)
            :base(name,cpf,address,telephone,state)
        {
            this.IdClient = idClient;
        }

        public long IdClient
        {
            get => idClient;
            set => idClient = value;
        }

    }
}
