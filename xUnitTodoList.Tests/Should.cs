using Xunit;

namespace xUnitTodoList.Tests
{
    public static class Should
    {
        public static void BeNotNull<T>(T obj)
        {
            Assert.NotNull(obj);
        }

        public static void HaveCountOf<T>(IEnumerable<T> collection, int expectedCount)
        {
            BeEqualTo(collection.Count(), expectedCount);
        }

        public static void BeNull<T>(T obj)
        {
            Assert.Null(obj);
        }

        public static void BeEqualTo<T>(T actual, T expected)
        {
            Assert.Equal(actual, expected);
        }

    }
}
