using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinJar.Interfaces
{
    public interface ICoin
    {
        decimal Amount { get; }
        decimal Volume { get; }    }
}
