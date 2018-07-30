using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinJar.Coins;
using CoinJar.Interfaces;

namespace CoinJar
{
    /// <summary>
    /// Factory Interface
    /// </summary>
    interface ICoinFactory
    {
        ICoin GetCoin();
    }

    /// <summary>
    /// Penny Coin Factory
    /// </summary>
    class PennyFactory : ICoinFactory
    {
        public ICoin GetCoin() => new Penny();
    }

    /// <summary>
    /// Nickel Coin Factory
    /// </summary>
    class NickelFactory : ICoinFactory
    {
        public ICoin GetCoin() => new Nickel();
    }

    /// <summary>
    /// Dime Coin Factory
    /// </summary>
    class DimeFactory : ICoinFactory
    {
        public ICoin GetCoin() => new Dime();
    }

    /// <summary>
    /// Quarter Coin Factory
    /// </summary>
    class QuarterFactory : ICoinFactory
    {
        public ICoin GetCoin() => new Quarter();
    }

    /// <summary>
    /// Half Dollar Coin Factory
    /// </summary>
    class HalfDollarFactory : ICoinFactory
    {
        public ICoin GetCoin() => new HalfDollar();
    }

    /// <summary>
    /// Dollar Coin Factory
    /// </summary>
    class DollarFactory : ICoinFactory
    {
        public ICoin GetCoin() => new Dollar();
    }
}
