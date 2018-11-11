using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries;

namespace Logic
{
    
    public interface IWypelnianie  
    {

        void Wypelnij(ref DataContext contex);
    }
}
