using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static string[] ReplaceFor(this string[] array, string keyword)
        {
            int indexReplaceFor = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == keyword)
                {
                    array[i] = "ДЛЯ";
                    indexReplaceFor++;
                    for (int j = ++i; j < array.Length; j++)
                    {
                        int index = 0;
                        int indexOpen = 0;
                        int indexClose = 0;
                        if (array[j].Contains("{") && index == 0 && indexReplaceFor == 1)
                        {
                            array[j] = "ЦИКЛ\n";
                            index++;
                            indexReplaceFor--;
                            indexOpen++;
                            continue;
                        }
                        else if (array[j].Contains("{") && index != 0)
                        {
                            index++;
                            indexOpen++;
                            continue;
                        }
                        else if (array[j].Contains("}") && index != 0)
                        {
                            index--;
                            indexClose++;
                            continue;
                        }
                        else if (array[j].Contains("}") && index == 0 && indexOpen == indexClose)
                        {
                            array[j] = "КЦИКЛ\n";
                            i++;
                            break;
                        }
                    }
                }
            }
            return array;
        }
    }
}
