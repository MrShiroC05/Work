using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test.system
{
    public class Service : IService
    {
        private Calculation Calculation = new Calculation();
        public Service() 
        {
            bank = new();
        }
        private Bank bank {  get; set; }
        public void Display()
        {
            foreach (var bank in bank.GetList())
            {
                var a = bank.GetDebtorList();
                Calculation.Cal(bank.DebtorsList, bank.getrate(),
                    /*Sum*/ out double Smore, out double Sinterest, out double Sbcf,
                    /*avd*/ out double Amore, out double Ainterest, out double Abcf,
                    /*sd*/ out double SDmore, out double SDinterest, out double SDbcf);
                Console.WriteLine($"================================================================================================================\n" +
                    $"ID : ...{bank.IdSubBank,5}... " +
                    $"\nProvince : {((bank.Province < province.Length) ?province[bank.Province] : "Orther")} District : {bank.District}\n");
                Console.WriteLine("     I D      |     Name      |   Balance     |    Payment    |     more      |" +
                    "    interest   | Balance carried forward\n================================================================================================================");
                foreach(var debtor in bank.DebtorsList)
                {
                    Calculation.Cal(debtor, bank.getrate(),out double interest, out double bcf);
                    Console.WriteLine($" {debtor.DebtorId}  |{debtor.DebtorName,15}|" +
                        $"{debtor.Balance.ToString("#,##0.00"),15}|{debtor.Payment.ToString("#,##0.00"),15}|{debtor.More.ToString("#,##0.00"),15}" +
                        $"|{interest.ToString("#,##0.00"),15}|" +
                        $"{bcf.ToString("#,##0.00"),15}");
                    
                }
                Console.WriteLine($"{"",30}Sum{"",29}|{Smore.ToString("#,##0.00"),15}|" +
                    $"{Sinterest.ToString("#,##0.00"),15}|" +
                    $"{Sbcf.ToString("#,##0.00"),15}");
                Console.WriteLine($"{"",28}Average{"",27}|{Amore.ToString("#,##0.00"),15}|" +
                    $"{Ainterest.ToString("#,##0.00"),15}|" +
                    $"{Abcf.ToString("#,##0.00"),15}");
                Console.WriteLine($"{"",22}Standard Deviation{"",22}|{SDmore.ToString("#,##0.00"),15}|" +
                    $"{SDinterest.ToString("#,##0.00"),15}|" +
                    $"{SDbcf.ToString("#,##0.00"),15}\n================================================================================================================");
            }
            Console.WriteLine($"Bank's Name : ...{bank.BankName}...   Country : {Country[bank.Country-1]} " +
                $"Amount : ...{bank.getAmount().ToString("#,##0.00")}... Lucre : {bank.getlucre().ToString("#,##0.00")}");
        }
        public void Save()
        {
            bank.Save();
        }
        private string[] province =
        {
            "Bangkok", "Kamphaeng Phet", "Chai Nat", "Nakhon Nayok", "Nakhon Pathom",
            "Nakhon Sawan", "Nonthaburi", "Pathum Thani", "Phra Nakhon Si Ayutthaya", "Phichit",
            "Phitsanulok", "Phetchabun", "Lopburi", "Samut Prakan", "Samut Songkhram",
            "Samut Sakhon", "Sing Buri", "Sukhothai", "Suphan Buri", "Saraburi",
            "Ang Thong", "Uthai Thani", "Chanthaburi", "Chachoengsao", "Chonburi",
            "Trat", "Prachinburi", "Rayong", "Sa Kaeo", "Kanchanaburi",
            "Tak", "Prachuap Khiri Khan", "Phetchaburi", "Ratchaburi", "Krabi",
            "Chumphon", "Trang", "Nakhon Si Thammarat", "Narathiwat", "Pattani",
            "Phang Nga", "Phatthalung", "Phuket", "Ranong", "Satun",
            "Songkhla", "Surat Thani", "Yala"
        };
        private string[] Country = { "ThaiLand", "Orther"};
    }
}
