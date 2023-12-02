namespace work3.Data
{
    public class Bank : SubBank
    {
        public Bank() => SubBanks = new();
        public List<SubBank> SubBanks { get; set; }
        public int ID_Bank { get; set; }
        public string Name_Bank { get; set; }
        public string Country_Bank { get; set; }
        public int Type_Bank { get; set; }
        private double Amount_Bank { get; set; }
        internal double lucre { get; set; }

    }
}
