using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.CustomLINQExtenstionMethod_19
{
    public static class Extensions
    { 
        private static Random random = new Random();
        public static void Print<T>(this IEnumerable<T> source, string title)
        {
            if (source == null)
                return;
            Console.WriteLine();
            Console.WriteLine("┌───────────────────────────────────────────────────────┐");
            Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
            Console.WriteLine("└───────────────────────────────────────────────────────┘");
            Console.WriteLine();
            foreach (var item in source)
            {
                if (typeof(T).IsValueType)
                    Console.Write($" {item} "); // 1, 2, 3
                else
                    Console.WriteLine(item);
            } 
        }

        public static IEnumerable<Tsource> Paginate<Tsource>(this IEnumerable<Tsource> source, int page = 1, int size = 10)
        {
            if (source is null)
                throw new NullReferenceException(nameof(source));
            if (page <= 0)
                throw new Exception(nameof(page));
            if (size <= 0)
                throw new Exception(nameof(source));
            if (!source.Any())
                return Enumerable.Empty<Tsource>();
            return source.Skip((page - 1) * size).Take(size);

        }
        public static IEnumerable<Tsource> WhereWithPaginate<Tsource>(this IEnumerable<Tsource> source, Func<Tsource, bool> predicate, int page = 1, int size= 10)
        {
            if (source is null)
                throw new NullReferenceException(nameof(source));
            if (!source.Any())
                return Enumerable.Empty<Tsource>();
            var filter = Enumerable.Where(source, predicate);
            return Paginate(filter, page, size);

        }
        public static Tsource RondomT<Tsource>(this IEnumerable<Tsource> source)
        {
            if (source is null)
                throw new NullReferenceException(nameof(source));
            if (!source.Any())
                return default;
            return source.ElementAt(random.Next(0, source.Count()));
        }
       

    }
}
