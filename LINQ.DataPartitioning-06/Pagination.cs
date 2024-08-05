using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.DataPartitioning_06
{
    public static class Pagination
    {
        
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, 
            int size = 10, int page = 1)
        {
            if (page <= 0) // makes paginate impure function but that's alright because the use give invalid info
                page = 1;
            if (size <= 0) // makes paginate impure function but that's alright because the use give invalid info
                size = 10;

            int totalSize = source.Count();
            int totalPages =(int) Math.Ceiling((decimal)totalSize / size);

            var result = source.Skip((page - 1) * size).Take(size);

            return result;
        }
    }

}
