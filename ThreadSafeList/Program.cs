using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafeList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start.");
            Console.ReadLine();
            Thread[] tWrites = new Thread[1000];
            Thread[] tReads = new Thread[1000];
            // Using "lock"
            IStringCollection noLockList = new NoLockList();

            // Without using "lock" PS: See notes
            //IStringCollection noLockList = new NonLockingCollection();

            for (int i = 0; i < tWrites.Length; i++)
            {
                Thread tw = new Thread(() => noLockList.AddString(DateTime.Now.ToString()));
                Thread tr = new Thread(() =>
                {
                    noLockList.ToString();
                    Console.Write(".");
                });
                tWrites[i] = tw;
                tReads[i] = tr;
            }
            for (int i = 0; i < tWrites.Length; i++)
            {
                tWrites[i].Start();
                tReads[i].Start();
            }

            //block main thread until all other threads have ran to completion.
            for (int i = 0; i < tWrites.Length; i++)
            {
                tWrites[i].Join();
                tReads[i].Join();
            }

            Console.WriteLine();
            Console.WriteLine("** Final Items:");
            Console.WriteLine(noLockList.ToString());
            Console.ReadLine();
        }
    }

    public interface IStringCollection
    {
        void AddString(string s);
        string ToString();
    }

    public class NoLockList : IStringCollection
    {
        List<string> internalCollection = new List<string>();

        /// <summary>
        /// Add string to collection
        /// </summary>
        /// <param name="s">The value to be added to collection as string</param>
        public void AddString(string s)
        {
            // Lock the "Add" method for other threads
            lock (internalCollection)
            {
                internalCollection.Add(s);
            }
        }

        /// <summary>
        /// Override ToString method to return CSV string
        /// </summary>
        /// <returns>CSV of strings in collection</returns>
        public override string ToString()
        {
            // Needs to implement lock if another thread is changing collection
            lock (internalCollection)
            {
                return string.Join(",", internalCollection);
            }
        }
    }


    /// <summary>
    /// NOTE: ** I am not taking any credit for this as this solution was found on SO. Interesting implementation though.
    /// REF: https://stackoverflow.com/questions/10675400/threadsafe-collection-without-lock/10676552
    /// SIDE-NOTE: Maybe half a bonus point for my awesome googling skills? :-)
    /// </summary>
    public class NonLockingCollection : IStringCollection
    {
        private List<string> collection;

        public NonLockingCollection()
        {
            // Initialize global collection through a volatile write.
            Interlocked.CompareExchange(ref collection, new List<string>(), null);
        }

        public void AddString(string s)
        {
            while (true)
            {
                // Volatile read of global collection.
                var original = Interlocked.CompareExchange(ref collection, null, null);

                // Add new string to a local copy.
                var copy = original.ToList();
                copy.Add(s);

                // Swap local copy with global collection,
                // unless outraced by another thread.
                var result = Interlocked.CompareExchange(ref collection, copy, original);
                if (result == original)
                    break;
            }
        }

        public override string ToString()
        {
            // Volatile read of global collection.
            var original = Interlocked.CompareExchange(ref collection, null, null);

            // Since content of global collection will never be modified,
            // we may read it directly.
            return string.Join(",", original);
        }
    }
}
