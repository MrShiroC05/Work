using workOP.Data;
system system = new();

system.DisplaySubBank();




Random r = new Random();

void reSet_SubBack()
{
    double[] Rate = { 0.01, 0.02, 0.5 };
    using (StreamWriter W = new(@"C:\Users\HP\Documents\workChill\OOP\Main\workOP\Data\SubBank.txt"))
    {
        for (int i = 1; i < 11; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                // Province-District-[bunSub]; District's name; [อัตราดอกเบี้ย]
                W.WriteLine($"01-{i.ToString("00")}-{j.ToString("00")}; District {j}; {Math.Round((r.NextDouble()/10),2)}");
            }
        }
    }
}
void reSet_Debtor()
{
    Thailand t = new Thailand();
    double[] Rate = { 0.01, 0.02, 0.5 };
    using (StreamWriter W = new(@"C:\Users\HP\Documents\workChill\OOP\Main\workOP\Data\Debtor.txt"))
        for (int i = 1; i < t.bankName.Length; i++)
        {
            // [ประเทศ]-[ธนาคาร]-[จังหวัด]-[อำเภอ]-[คนที่ i]; [ชื่อ]; [ยอดยกมา]; [ยอดชำระ]; [ซื้อเพิ่ม]
            int J = r.Next(10);
            for (int j = 1; j < 4; j++)
            {
                int U = r.Next(10);
                for (int u = 0; u < U; u++)
                {
                    for (int v = 0; v < 10;v++)
                    {
                        int a = r.Next(5000, 200000);
                        int T = r.Next(t.bankName.Length);
                        W.WriteLine($"01-{i.ToString("00")}-{j.ToString("00")}-{u.ToString("00")}-{v.ToString("000")}; User-{i.ToString() + j.ToString() + u.ToString()}; {a.ToString("###0.00")}; {r.Next(a)}; {r.Next(a)}");
                    }
                }
            }

        }
}

