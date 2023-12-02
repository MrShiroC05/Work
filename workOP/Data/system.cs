using System.Collections.Generic;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace workOP.Data
{
    public class system : Isystem
    {
        private Thailand t = new();
        public system()
        {
            BANK = GetData();
        }
        private string file = @"C:\Users\HP\Documents\workChill\OOP\Main\workOP\Data\";
        private List<Debtor> BANK {  get; set; }
        public void DisplaySubBank()
        {
            ConsoleKey Key = ConsoleKey.A;

            // ค้นหา Id ธนาคารทั้งหมด
            var GruopBank = IDBank();

            int C = 0;
            do
            {
                Console.Clear();

                var idSubBank = IDSubBank(GruopBank[C]);
                var info = BANK.Find(p => p.BankID == GruopBank[C]);
                for (int i = 0; i < idSubBank.Count; i++)
                {
                    Console.WriteLine($"[Bank's ID : {GruopBank[C]} Bank's Name{info.BankName}]");
                    Console.WriteLine($"SubBank's ID : {idSubBank[i]}\n" +
                        $"Province : {info.Province}\n" +
                        $"District : {info.District}\n\n");
                }

                Key = Console.ReadKey().Key;
                
                if (Key == ConsoleKey.RightArrow && C < GruopBank.Count - 1)
                    C++;
                else if (Key == ConsoleKey.LeftArrow && C != 0)
                    C--;
            } while (Key != ConsoleKey.Escape);
            
        }
        public List<Debtor> GetData()
        {
            List<Debtor> bank = new();
            using (StreamReader R = new(file+"Debtor.txt"))
            {
                while (!R.EndOfStream)
                {
                    string[] dataDebtor = R.ReadLine().Split("; ") ;
                    SubBank S = new();
                    if (dataDebtor.Length == 5)
                    {
                        string[] IdToInfo = dataDebtor[0].Split("-") ;
                        // [ประเทศ]-[ธนาคาร]-[จังหวัด]-[อำเภอ]-[คนที่ i]; [ชื่อ]; [ยอดยกมา]; [ยอดชำระ]; [ซื้อเพิ่ม]
                        // 0-1-2-3-4; 1; 2; 3; 4
                        // Input Data SubBank And Bank by Debtor's Id
                        int country = int.Parse(IdToInfo[0]);
                        string idBank = $"{IdToInfo[0]}-{IdToInfo[1]}";
                        string nameBank = t.bankName[int.Parse(IdToInfo[1])];
                        int province = int.Parse(IdToInfo[2]);
                        int district = int.Parse(IdToInfo[3]);
                        string idSubBank = $"{IdToInfo[0]}-{IdToInfo[1]}-{IdToInfo[2]}-{IdToInfo[3]}";

                        int type = int.Parse(IdToInfo[1]) switch
                        {
                            1 => 0,
                            2 => 1,
                            3 => 1,
                            _ => 3
                        };


                        // Input Data Debtor
                        string debtorID = dataDebtor[0];
                        string debtorName = dataDebtor[1];
                        double debtorBalance = double.Parse(dataDebtor[2]);
                        double debtorPayment = double.Parse(dataDebtor[3]);
                        double debtorMore = double.Parse(dataDebtor[4]);

                        bank.Add(new Debtor
                        {
                            // Add Data Debtor
                            DebtorId = debtorID,
                            DebtorName = debtorName,
                            Balance = debtorBalance,
                            Payment = debtorPayment,
                            More = debtorMore,

                            // Add data SubBank
                            IdSubBank = idSubBank,
                            District = district,
                            Province = province,

                            // Add data Bank
                            BankID = idBank,
                            BankName = nameBank,
                            Type = type,
                            Country = country,


                        }) ;
                        S.FidRateSubBank(idSubBank); // Input SubBank's Rate
                        
                    }
                }
            }
            return bank;
        }
        public void List_Debtor()
        {
            foreach (var d in BANK)
            {
                Console.WriteLine($"{d.DebtorId}|{d.DebtorName}");
            }
        }
        public void SaveDebtor()
        {
            throw new NotImplementedException();
        }
        public void ShowListSubBank()
        {

        }
        public List<string> IDBank()
        {
            var a =BANK.GroupBy(item => item.BankID).Where(group => group.Count() > 1).Select(group => group.Key);
            List<string> list = new List<string>();

            foreach(var A in a)
            {
                list.Add(A);
                Console.WriteLine(A);
            }
            return list;
        }
        public List<string> IDSubBank(string IDBank)
        {
            List<string> list = new();
            var b = (BANK.FindAll(a => a.BankID == IDBank)).GroupBy(item => item.IdSubBank).Where(group => group.Count() > 1).Select(group => group.Key);
            foreach(var B in b)
            {
                list.Add(B);
            }
            return list;

        }
    }
    public class Thailand
    {
        public string[] province =
        {
            "Bangkok", "Kamphaeng Phet", "Chai Nat", "Nakhon Nayok", "Nakhon Pathom",
            "Nakhon Sawan", "Nonthaburi", "Pathum Thani", "Phra Nakhon Si Ayutthaya",
            "Phichit", "Phitsanulok", "Phetchabun", "Lopburi", "Samut Prakan", "Samut Songkhram",
            "Samut Sakhon", "Sing Buri", "Sukhothai", "Suphan Buri", "Saraburi", "Ang Thong", "Uthai Thani"
        };
        public string[] bankName = { 
            "Bank kok", "Bank P", "Bank guys", "Bank Cats", "Bank Dog" 
        };
    }
}
