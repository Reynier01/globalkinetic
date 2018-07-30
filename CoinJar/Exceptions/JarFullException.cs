using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinJar.Exceptions
{
    /// <summary>
    /// Custom Exception for indicating that Coin Jar is full
    /// </summary>
    public class JarFullException : Exception
    {
        public JarFullException(string message)
            : base(message) { }
    }
}
