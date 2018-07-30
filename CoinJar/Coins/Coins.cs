using CoinJar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinJar.Coins
{
    /// <summary>
    /// Immutable Coin DTO
    /// </summary>
    public abstract class Coin : ICoin
    {
        private readonly decimal amount;
        private readonly decimal volume;
        public Coin(decimal amount, decimal volume)
        {
            this.amount = amount;
            this.volume = volume;
        }

        /// <summary>
        /// Monetary value of coin
        /// </summary>
        public decimal Amount => amount;

        /// <summary>
        /// Volume of coin
        /// </summary>
        public decimal Volume => volume;
    }

    /// <summary>
    /// Penny Coin Object
    /// </summary>
    public class Penny : Coin
    {
        public Penny() : base(0.01M, 0.0881849M) { }
    }

    /// <summary>
    /// Nickel Coin Object
    /// </summary>
    public class Nickel : Coin
    {
        public Nickel() : base(0.05M, 0.17637M) { }
    }


    /// <summary>
    /// Dime Coin Object
    /// </summary>
    public class Dime : Coin
    {
        public Dime() : base(0.10M, 0.080001346M) {  }
    }

    /// <summary>
    /// Quarter Coin Object
    /// </summary>
    public class Quarter : Coin
    {
        public Quarter() : base(0.25M, 0.2000034M) { }
    }

    /// <summary>
    /// HalfDollar Coin Object
    /// </summary>
    public class HalfDollar : Coin
    {
        public HalfDollar() : base(0.50M, 0.40000673M) { }
    }

    /// <summary>
    /// Dollar Coin Object
    /// </summary>
    public class Dollar : Coin
    {
        public Dollar() : base(1.00M, 0.285719M) { }
    }
}
