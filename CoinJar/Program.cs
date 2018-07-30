using CoinJar.Coins;
using CoinJar.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinJar
{
    class Program
    {
        static void Main(string[] args)
        {
            ICoinFactory factory = null;
            CoinJar coinJar = new CoinJar();
            string coinType = string.Empty;

            do
            {
                Console.WriteLine("Valid Coin Types: [cent/penny, nickel, dime, quarter, halfdollar, dollar]");
                Console.WriteLine("Enter Coin Type (q to quit):");
                coinType = Console.ReadLine();
                switch (coinType.ToLower())
                {
                    case "cent":
                    case "penny":
                        factory = new PennyFactory();
                        break;
                    case "nickel":
                        factory = new NickelFactory();
                        break;
                    case "dime":
                        factory = new DimeFactory();
                        break;
                    case "quarter":
                        factory = new QuarterFactory();
                        break;
                    case "halfdollar":
                        factory = new HalfDollarFactory();
                        break;
                    case "dollar":
                        factory = new DollarFactory();
                        break;
                    default:
                        Console.WriteLine("Invalid Coin Type");
                        factory = null;
                        break;
                }

                if (factory != null)
                {
                    try
                    {
                        coinJar.AddCoin(factory.GetCoin());
                        Console.WriteLine("Coin added!");
                    }
                    catch(JarFullException ex)
                    {
                        Console.WriteLine($"** {ex.Message} **");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                }
                Console.WriteLine($"Total Amount: {coinJar.TotalAmount}");
            } while (coinType.ToLower() != "q");
        }
    }
}
