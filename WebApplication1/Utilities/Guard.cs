namespace CouchbaseWebService.Web.Utilities
{
    public static class Guard
    {
        /// <summary>
        /// Determines whether [is null or default] [the specified value].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsNullOrDefault<T>(this T value) where T : class
        {
            bool result = value == null || value.Equals(default(T));
            return result;
        }
    }
}