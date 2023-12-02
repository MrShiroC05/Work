namespace work2.system
{
    public class SubBank : Debtor
    {
        // id subBank = ประเทศ-ธนาคาร-จังหวัด-อำเภอ
        // id; Rate
        public SubBank(string Bank_ID)
        {
            Debtor_List = new();
            SubBank_Id = Bank_ID;
            DebtorList();
        }
        public List<Debtor> Debtor_List { get; set; }
        public string SubBank_Id { get; set; }
        public int SubBank_Province { get; set; } // จังหวัด
        public int SubBank_District { get; set; } // อำเภอ
        public double SubBank_InterestRate { get; set; }
        private void DebtorList()
        {
            using (StreamReader R = new(@"C:\Users\HP\Documents\workChill\OOP\Main\work2\Data\Debtor.txt"))
            {
                while (!R.EndOfStream)
                {
                    //ประเทศ-ธนาคาร-จังหวัด-อำเภอ-ตนที่; ชื่อคนกู้; จำนวนเงิยบกมา; ยอกชำระ; ยอดซื้อเพิ่ม;
                    string[] Data = R.ReadLine().Split("; ");

                    string[] IdToInfo = Data[0].Split("-");
                    if (Data.Length == 5 && IdToInfo.Length == 5 && $"{IdToInfo[0]}-{IdToInfo[1]}-{IdToInfo[2]}-{IdToInfo[3]}" == SubBank_Id) 
                    {
                        // Add Data SubBak's Debtor
                        Debtor_List.Add(new Debtor
                        {
                            Debtor_ID = Data[0],
                            Debtor_Name = Data[1],
                            Debtor_Borrowed = double.Parse(Data[2]),
                            Debtor_Payment = double.Parse(Data[3]),
                            Debtor_PayMore = double.Parse(Data[4]),
                        });
                    }
                }
            }
        }
        public List<Debtor> SubBank_Debtor()
        {
            return Debtor_List;
        }
    }
}
