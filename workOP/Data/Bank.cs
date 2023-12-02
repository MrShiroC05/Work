namespace workOP.Data
{
    public class Bank 
    {
        public string BankID { get; set; } //
        public string BankName { get; set; }//
        public int Type { get; set; } //
        public int Country { get; set; } //
        private double Amount { get; set; }
        internal double lucre { get; set; }
    }
}
