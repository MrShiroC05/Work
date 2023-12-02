
namespace Test.system
{
    public class SubBank : Debtor
    {
        public List<Debtor> DebtorsList {  get; set; }
        public string IdSubBank { get; set; } // Sub's ID //
        public int District { get; set; } // Sub's อำเถอ //
        public int Province { get; set; } // Sub's จังหวัด //
        protected double Rate = 0.05;//{ get; set; } // อัตราดอกเบี้ย
        public List<Debtor> GetDebtorList() { return DebtorsList; }
        public List<Debtor> GenarateDebtor(string Id = "none")
        {
            List<Debtor> List = new List<Debtor>();
            using(StreamReader d = new(@"C:\Users\HP\Documents\workChill\OOP\Main\Test\data\debtor.txt"))
            {
                while (!d.EndOfStream)
                {
                    string[] data = d.ReadLine().Split("; ");
                    string a = data[0].Remove(9, 2);
                    if (a == Id)
                    {
                        List.Add(new Debtor
                        {
                            DebtorId = data[0],
                            DebtorName = data[1],
                            Balance = double.Parse(data[2]),
                            Payment = double.Parse(data[3]),
                            More = double.Parse(data[4]),
                        });
                    }
                }
            }
            return List;
        }
        public double getrate()
        {
            return Rate;
        }
    }
}
