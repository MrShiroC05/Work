
namespace Test.system
{
    public class Calculation
    { 
        public void Cal(List<Debtor> debtors, double Rate,/*Sum*/ out double Smore, out double Sinterest, out double Sbcf,
            /*avd*/ out double Amore, out double Ainterest, out double Abcf,
            /*sd*/ out double SDmore, out double SDinterest, out double SDbcf
            ) // Calculation
        {
            // Sum
            double more, interest, bcf;
            Smore = debtors.Sum(x => x.More);
            Sinterest = debtors.Sum(x => (x.Balance - x.Payment) * Rate);
            Sbcf = debtors.Sum(x => x.Balance - x.Payment + ((x.Balance - x.Payment) * Rate) + x.More);
            // AVG
            more = Amore = debtors.Average(x => x.More);
            interest = Ainterest = debtors.Average(x => (x.Balance - x.Payment) * Rate);
            bcf = Abcf = debtors.Average(x => x.Balance - x.Payment + ((x.Balance - x.Payment) * Rate) + x.More);
            // Sd
            SDmore = Math.Sqrt(debtors.Sum(x => Math.Pow((x.More - more), 2)) / (debtors.Count - 1));
            SDinterest = Math.Sqrt(debtors.Sum(x => Math.Pow((((x.Balance - x.Payment)) * Rate), 2) / debtors.Count - 1));
            SDbcf = Math.Sqrt(debtors.Sum(x => Math.Pow(x.Balance - x.Payment + (((x.Balance - x.Payment) * Rate) + x.More) - bcf, 2)) / debtors.Count - 1);
            //
        }
        public void Cal(Debtor debtor,double Rate, out double interest, out double bcf)
        {
            var i = interest = (debtor.Balance - debtor.Payment) * Rate;
            bcf = debtor.Balance - debtor.Payment + i + debtor.More;
        }
    }
}
