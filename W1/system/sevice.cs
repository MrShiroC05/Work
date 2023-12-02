using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work2.system
{
    public class sevice : Isevice
    {
        private string File = @"C:\Users\HP\Documents\workChill\OOP\Main\W1\Data\";
        public void DeleteDebtor()
        {
            throw new NotImplementedException();
        }

        public void DisplayList()
        {
            throw new NotImplementedException();
        }

        public void EditDebtor()
        {
            throw new NotImplementedException();
        }

        public void LoadData()
        {
            throw new NotImplementedException();
        }

        public void NewDebtor()
        {
            throw new NotImplementedException();
        }

        public void SaveData()
        {
            using (var sw = new StreamWriter(File + "Dabtor.txt"))
                for (int B = 1; B < 2; B++)
                {
                    for (int SB = 1; SB < 3; SB++)
                    {
                        var r = new Random();
                        var d = r.Next(10);
                        for (int D = 1; D < d; D++)
                        {
                            int Borrowed = r.Next(2, 10) * 1000 ;

                            // ID; Name; Borrowed; Pay; More;
                            // ID : [Bank]-[SubBank]-[type]-[]-[Dubtor] 
                            sw.WriteLine($"01-{B.ToString("00")}-{SB.ToString("00")}-{r.Next(3).ToString("0")}-{r.Next(5).ToString("00")}-{D.ToString("0000")}; Name{D}; {Borrowed}; {r.Next(Borrowed)}; {r.Next(Borrowed)}");
                        }
                    }
                }
        }
    }
    public class Data
    {
        public string[] BankName =
        {
            "Bank 1", "Bank Bank", "Bank knab", "Bank kok"
        };
        public int type(int name)
        {
            return name switch
            {
                1 => 1,
                2 => 2,
                3 => 2,
                _ => 3,
            };
        }
    }
}
