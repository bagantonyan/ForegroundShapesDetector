namespace ForegroundShapesDetector.Library.Services.Extensions
{
    public static class AsyncEnumerableExtensions
    {
        public static async Task<ICollection<T>> GetAllResultsAsync<T>(this IAsyncEnumerable<T> asyncEnumerable)
        {
            if (asyncEnumerable is null)
                throw new ArgumentNullException(nameof(asyncEnumerable));

            var list = new List<T>();

            await foreach (var item in asyncEnumerable)
            {
                list.Add(item);
            }

            return list;
        }
    }
}
