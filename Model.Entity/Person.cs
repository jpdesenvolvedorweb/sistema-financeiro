using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Person
    {
        private string name;
        private string cpf;
        private string address;
        private string telephone;
        private int state;

        public Person()
        {
        }

        public Person(string name, string cpf, string address, string telephone, int state)
        {
           
            this.name = name;
            this.Cpf = cpf;
            this.Address = address;
            this.telephone = telephone;
            this.state = state;
        }

        [Display(Name = "Nome")]
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

        [Display(Name = "Endereço")]
        public string Address
        {
            get => address;
            set => address = value;
        }

        [Display(Name = "Telefone")]
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
