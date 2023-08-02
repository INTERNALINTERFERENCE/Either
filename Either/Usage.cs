using System.Collections.Concurrent;
using System.Globalization;

namespace Either
{
    internal class Usage
    {
        private record CacheKey(
            Either<TestTypeFirst, TestTypeSecond> Type,
            CultureInfo Culture);

        private ConcurrentDictionary<CacheKey, string> _cache = new();

        public string Use(
            Either<TestTypeFirst, TestTypeSecond> type,
            CultureInfo culture)
        {
            return type.Match(
                ifA: cfs => _cache.GetOrAdd(
                   new(cfs, culture),
                   _ => Use(cfs, culture)),
                ifB: cf => _cache.GetOrAdd(
                   new(cf, culture),
                   _ => Use(cf, culture)));
        }

        private string Use(
            TestTypeFirst type,
            CultureInfo culture) =>
            throw new NotImplementedException();

        private string Use(
            TestTypeSecond type,
            CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
