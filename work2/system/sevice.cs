using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work2.system
{
    public class sevice : Isevice
    {

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
