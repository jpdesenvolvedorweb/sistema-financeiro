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

        public int IdModePay
        {
            get => idModePay;
            set => idModePay = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

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
