using System;

namespace SearchForKeywords
{
    public static class ExtensionMethods
    {
        public static string[] ToStringArray(this string line)
        {
            string[] arrayWords = line.Split(' ');
            //string[] arrayWords = new string[0];
            //int count = 0;
            //for (int i = 0; i < tempArrayWords.Length; i++)
            //{
            //    if (tempArrayWords[i] != "")
            //    {
            //        Array.Resize(ref arrayWords, arrayWords.Length + 1);
            //        arrayWords[count] = tempArrayWords[i];
            //        count++;
            //    }
            //}
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
