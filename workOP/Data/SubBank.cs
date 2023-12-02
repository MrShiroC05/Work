namespace workOP.Data
{
    public class SubBank : Bank
    {
        public string IdSubBank { get; set; } // Sub's ID //
        public int District { get; set;} // Sub's อำเถอ //
        public int Province { get; set; } // Sub's จังหวัด //
        protected double Rate { get; set; } // อัตราดอกเบี้ย
        public void FidRateSubBank(string IdsubBank)
        {
            
            using (StreamReader r = new(@"C:\Users\HP\Documents\workChill\OOP\Main\workOP\Data\SubBank.txt"))
            {
                while (!r.EndOfStream)
                {
                    string[] data = r.ReadLine().Split("; ");
                    if (data[0] == IdsubBank)
                    { 
                        Rate = double.Parse(data[2]);
                    }
                }
            }
        }
    }
}

