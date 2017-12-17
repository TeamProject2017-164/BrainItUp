using System.Collections.Generic;
using System;

namespace DatabaseModels.Extensions
{
    public static class CollectionExtensions
    { 
        public static IEnumerable<T> RandomizeCollection<T>(this T[] array)
        {
            Random rnd = new Random();

            for (var i = 0; i < array.Length; i++)
            {
                var j = rnd.Next(i, array.Length);
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            return array;
        }
    }
}
