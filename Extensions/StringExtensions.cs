namespace Equals_Api.Extensions
{
    public static class StringExtensions
    {
        public static bool ThereIs(this string str, string searchText)
        {
            int index = str.IndexOf(searchText);
            return index != -1;
        }
    }
}
