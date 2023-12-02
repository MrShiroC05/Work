namespace Test.system
{
    public class Bank : SubBank
    {
        public Bank()
        {
            subBanks = new();
            GetDataBank();
            infoBank();
            Amount = subBanks.Sum(p => p.GetDebtorList().Sum(x => x.Balance - x.Payment + ((x.Balance - x.Payment) * Rate) + x.More));
        }
        public List<SubBank> subBanks { get; set; }
        public string BankID { get; set; } 
        public string BankName { get; set; }
        public int Type { get; set; } 
        public int Country { get; set; } 
        private double Amount { get; set; }
        internal double lucre { get; set; }
        private void infoBank()
        {
            SubBank S = new();
            using (StreamReader R = new(@"C:\Users\HP\Documents\workChill\OOP\Main\Test\data\subBank.txt"))
                while(!R.EndOfStream)
                {
                    string[] data = R.ReadLine().Split("; ");
                    data[0].Remove(5,4);
                    if (data[0].Remove(5, 4) == BankID)
                    {
                        subBanks.Add(new SubBank
                        {
                            IdSubBank = data[0],
                            Province = int.Parse(data[1]),
                            District = int.Parse(data[2]),
                            DebtorsList = GenarateDebtor(data[0])
                        }) ;
                    }
                }
            //Random R = new();
            //for (int i = 0; i < 4; i++) // จังหวัด
            //{
            //    for (int j = 0; j < 4; j++) // อำเภอ
            //    {
            //        string id = $"{BankID}-{Country.ToString("00")}-{i}-{j}";
            //        subBanks.Add(new SubBank
            //        {
            //            IdSubBank = id,
            //            Province = R.Next(77),
            //            District = R.Next(10),

            //            DebtorsList = S.GenarateDebtor(5, id)
            //        });
            //    }
            //}

        }
        public void Save()
        {
            string file = @"C:\Users\HP\Documents\workChill\OOP\Main\Test\data\";
            List<Debtor> D = new();
            using (StreamWriter Sb = new(file + "subBank.txt"))
                foreach (SubBank sb in subBanks)
                {
                    Sb.WriteLine($"{sb.IdSubBank}; {sb.Province}; {sb.District}; 0.0{Rate}");

                    foreach (Debtor d in sb.DebtorsList)
                    {
                        D.Add(new Debtor
                        {
                            DebtorId = d.DebtorId,
                            DebtorName = d.DebtorName,
                            Balance = d.Balance,
                            Payment = d.Payment,
                            More = d.More,
                            BankDebtor = d.BankDebtor,
                        });
                    }
                }
            using (StreamWriter Dw = new(file + "debtor.txt"))
                foreach (var d in D)
                {
                    Dw.WriteLine($"{d.DebtorId}; {d.DebtorName}; {d.Balance}; {d.Payment}; {d.More}; {d.BankDebtor}");
                }
        }
        public List<SubBank> GetList()
        {
            return subBanks;
        }
        public double getAmount()
        {
            return Amount;
        }
        public double getlucre()
        {
            
            lucre = Amount - subBanks.Sum(p => p.GetDebtorList().Sum(p => p.Balance));
            return lucre;
        }
        public void GetDataBank()
        {
            string[] data = new StreamReader(@"C:\Users\HP\Documents\workChill\OOP\Main\Test\data\bank.txt").ReadLine().Split("; ");
            if (data.Length == 3)
            {
                BankID = data[0];
                BankName = data[1];
                Country = int.Parse(data[2]);
            }
        }
    }
}
