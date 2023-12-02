namespace work2.system
{
    public class SubBank : Debtor
    {
        // id subBank = ประเทศ-ธนาคาร-จังหวัด-อำเภอ
        // id; Rate
        public SubBank()
        {
            Debtor_List = new();
        }
        public List<Debtor> Debtor_List { get; set; }
        public string SubBank_Id { get; set; }
        public int SubBank_Province { get; set; } // จังหวัด
        public int SubBank_District { get; set; } // อำเภอ
        public double SubBank_InterestRate { get; set; }
    }
}
