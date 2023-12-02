namespace work3.Data
{
    public class SubBank : Debtor
    {
        public SubBank() => Debtors = new();
        public List<Debtor> Debtors { get; set; }
        public string ID_SubBank { get; set; }
        public string Province_SubBank { get; set; }
        public int County_SubBank { get; set; }
        protected double Rate_SubBank { get; set; }
    }
}
