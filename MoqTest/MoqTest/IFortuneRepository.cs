using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTest
{
    public interface IFortuneRepository
    {
        string[] GetFortunes(string type);
        string[] GetTypes();
    }
}
