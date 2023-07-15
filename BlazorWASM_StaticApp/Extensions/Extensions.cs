namespace BlazorWASM_StaticApp.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            var r = new Random();
            var shuffledList =
                list.
                    Select(x => new { Number = r.Next(), Item = x }).
                    OrderBy(x => x.Number).
                    Select(x => x.Item);

            return shuffledList.ToList();
        }
    }
}
