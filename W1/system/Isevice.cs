using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work2.system
{
    public interface Isevice
    {
        void LoadData();
        void SaveData();
        void DisplayList();
        void NewDebtor();
        void EditDebtor();
        void DeleteDebtor();
    }
}
