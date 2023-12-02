namespace work2.system
{
    public class Bank : SubBank
    {
        //ประเทศ-ธนาคาร; ชื่อธนาคาร; จำนวนสาขาย่อย; ยอดเงินสะสม; ผลกำไร
        public Bank() 
        {

        }
        private Data D = new Data();
        List<SubBank> SubBank_List {  get; set; }
        public string Bank_ID { get; set; }
        public string Bank_Name { get; set; }
        public  int Bank_Type { get; set; }
        public int Bank_country { get; set; }
        private double Bank_AccumulatedBalance { get; set;}
        internal double Bank_Profit { get; set; }
    }
}
