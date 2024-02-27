using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BWT
{
    public static int CompareShifts(string input, int index1, int index2)
    {
        string shift1 = input.Substring(index1) + input.Substring(0, index1);
        string shift2 = input.Substring(index2) + input.Substring(0, index2);

        return String.Compare(shift1, shift2);
    }

    public static (string, int) BWTransform(string input)
    {
        var suffixArray = Enumerable.Range(0, input.Length).ToArray();
        Array.Sort(suffixArray, (index1, index2) => BWT.CompareShifts(input, index1, index2));

        for (int i = 0; i < suffixArray.Length; ++i)
        {
            suffixArray[i] = i;
        }

        Array.Sort(suffixArray, (index1, index2) => BWT.CompareShifts(input, index1, index2));

        char[] resultArray = new char[input.Length];
        for (int i = 0; i < input.Length; ++i)
        {
            resultArray[i] = suffixArray[i] > 0 ? input[suffixArray[i] - 1] : input[input.Length - 1];
        }

        int endPosition = Array.IndexOf(suffixArray, 0);

        return (new string(resultArray), endPosition);
    }
}