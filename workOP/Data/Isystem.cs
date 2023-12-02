using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workOP.Data
{
    public interface Isystem
    {
        List<Debtor> GetData();
        void DisplaySubBank();
        void SaveDebtor();
    }
}
