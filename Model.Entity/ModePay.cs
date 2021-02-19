using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class ModePay
    {
        private int idModePay;
        private string name;
        private string otherDetails;
        private int state;

        public ModePay()
        {

        }

        public ModePay(int idModePay)
        {
            this.idModePay = idModePay;
        }

        public ModePay(int idModePay, string name, string otherDetails, int state)
        {
            this.idModePay = idModePay;
            this.name = name;
            this.otherDetails = otherDetails;
            this.state = state;
        }

        [Display(Name = "Código")]
        public int IdModePay
        {
            get => idModePay;
            set => idModePay = value;
        }

        [Display(Name = "Nome")]
        public string Name
        {
            get => name;
            set => name = value;
        }

        [Display(Name = "Outros Detalhes")]
        public string OtherDetails
        {
            get => otherDetails;
            set => otherDetails = value;
        }

        public int State
        {
            get => state;
            set => state = value;
        }
    }
}
