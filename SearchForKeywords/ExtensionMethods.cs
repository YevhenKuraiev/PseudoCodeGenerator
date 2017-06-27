namespace SearchForKeywords
{
    public static class ExtensionMethods
    {
        public static string[] ToStringArray(this string line)
        {
            string[] arrayWords = line.Split(' ');
            return arrayWords;
        }

        public static string StringArrayToString(this string[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] + ' ';
            }
            return result;
        }
    }
}
