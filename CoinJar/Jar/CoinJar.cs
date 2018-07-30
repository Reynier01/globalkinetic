using CoinJar.Coins;
using CoinJar.Exceptions;
using CoinJar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinJar
{
    /// <summary>
    /// Class that represents a coin jar
    /// </summary>
    public class CoinJar : ICoinJar
    {
        /// <summary>
        /// Constant Max Fluid Volume
        /// </summary>
        private const decimal MAX_FLUID_VOLUME = 42;

        /// <summary>
        /// Current volume in jar
        /// </summary>
        private decimal currentVolume = 0;

        /// <summary>
        /// Current monetary value in jar
        /// </summary>
        private decimal currentAmount = 0;

        /// <summary>
        /// The total monetary amount of coin jar
        /// </summary>
        public decimal TotalAmount => currentAmount;

        /// <summary>
        /// Attempt to add coin to jar by comparing 
        /// volume of coin and available space
        /// </summary>
        /// <param name="coin">Coin of type ICoin</param>
        public void AddCoin(ICoin coin)
        {
            if (!(coin is Penny) && !(coin is Nickel) && !(coin is Dime) && !(coin is Quarter) && !(coin is HalfDollar) && !(coin is Dollar))
                throw new ArgumentOutOfRangeException("coin", "'coin' parameter is not the correct type");

            // This check does not take in consideration any space between coins
            if (coin.Volume + currentVolume > MAX_FLUID_VOLUME)
                throw new JarFullException("Jar is full");

            currentVolume += coin.Volume;
            currentAmount += coin.Amount;
        }

        /// <summary>
        /// Reset CoinJar
        /// </summary>
        public void Reset()
        {
            currentAmount = 0;
            currentVolume = 0;
        }
    }
}
