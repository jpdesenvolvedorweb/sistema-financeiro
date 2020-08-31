using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Client
    {
        private long idClient;
        private string name;
        private string cpf;
        private string address;
        private string telephone;
        private int state;

        public Client()
        {
        }

        public Client(long idClient)
        {
            this.IdClient = idClient;
        }

        public Client(long idClient, string name, string cpf, string address, string telephone, int state)
        {
            this.IdClient = idClient;
            this.name = name;
            this.Cpf = cpf;
            this.Address = address;
            this.telephone = telephone;
            this.state = state;
        }

        public long IdClient
        {
            get => idClient;
            set => idClient = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Cpf
        {
            get => cpf;
            set => cpf = value;
        }
        public string Address
        {
            get => address;
            set => address = value;
        }
        public string Telephone
        {
            get => telephone;
            set => telephone = value;
        }
        public int State
        {
            get => state;
            set => state = value;
        }
    }
}
