using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace GreymanRaffleWinnerSelector
{
    public static class CollectionExtensions
    {

        public static void Shuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        //public static void Shuffle<T>(this IList<T> list)
        //{
        //    var provider = new RNGCryptoServiceProvider();
        //    var n = list.Count;
        //    while (n > 1)
        //    {
        //        var box = new byte[1];
        //        do provider.GetBytes(box);
        //        while (!(box[0] < n * (byte.MaxValue / n)));
        //        var k = box[0] % n;
        //        n--;
        //        var value = list[k];
        //        list[k] = list[n];
        //        list[n] = value;
        //    }
        //}

        public static T SelectRandom<T>(this IList<T> list)
        {
            var provider = new RNGCryptoServiceProvider();
            var p = new byte[1];
            do provider.GetBytes(p);
            while (p[0] == 255);
            return list[p[0] % list.Count];
        }
    }
}