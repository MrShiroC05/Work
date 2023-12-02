namespace work2.system
{
    public class Bank : SubBank
    {
        //ประเทศ-ธนาคาร; ชื่อธนาคาร; จำนวนสาขาย่อย; ยอดเงินสะสม; ผลกำไร
        public Bank(string idBank) 
        {
            GetInfoBank(idBank, out int NumSubBank);
            SubBank_List = new();
            GetListSubtor(NumSubBank);
        }
        private Data D = new Data();
        List<SubBank> SubBank_List {  get; set; }
        public string Bank_ID { get; set; }
        public string Bank_Name { get; set; }
        public  int Bank_Type { get; set; }
        public int Bank_country { get; set; }
        private double Bank_AccumulatedBalance { get; set;}
        internal double Bank_Profit { get; set; }
        private void GetInfoBank(string idBank, out int NumSubBank)
        {
            using (StreamReader R = new(@"C:\Users\HP\Documents\workChill\OOP\Main\work2\Data\Bank.txt"))
            {
                int Q = 0;
                while (!R.EndOfStream)
                {
                    string[] Data = R.ReadLine().Split("; ");
                    if (Data.Length == 5 && Data[0] == Bank_ID)
                    {
                        Bank_Name = D.BankName[int.Parse(Data[1])];
                        Bank_Type = D.type(int.Parse(Data[1]));
                        Bank_AccumulatedBalance = double.Parse(Data[3]);
                        Q = int.Parse(Data[2]);
                        Bank_Profit = double.Parse(Data[4]);
                    }
                }
                NumSubBank = Q;
            }
        }
        private void GetListSubtor(int Q)
        {

        }
    }
}
