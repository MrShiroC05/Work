namespace work2.system
{
    public class Debtor
    {
        // Id Debtor ประเทศ-ธนาคาร-จังหวัด-อำเภอ-ตนที่; ชื่อคนกู้; จำนวนเงิยบกมา; ยอกชำระ; ยอดซื้อเพิ่ม;
        public Debtor() 
        {
            Debtor_ID = "none";
            Debtor_Name = "none";
            Debtor_Borrowed = 0;
            Debtor_Payment = 0;
            Debtor_PayMore = 0;
        }
        public string Debtor_ID {  get; set; }
        public string Debtor_Name { get; set; }
        public double Debtor_Borrowed { get; set; }
        public double Debtor_Payment {  get; set; }
        public double Debtor_PayMore { get; set; }
    }
}
