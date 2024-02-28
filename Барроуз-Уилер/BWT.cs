using System;
using System.Linq;

public class BWT
{
    public static int CompareShifts(string input, int index1, int index2)
    {
        // change C# version to use ranges ???
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

    public static string InverseBWT(string input, int endPosition)
    {
        int[] count = new int[256];
        for (int i = 0; i < input.Length; ++i)
        {
            ++count[input[i]];
        }

        int sum = 0;
        for (int i = 0; i < 256; ++i)
        {
            sum += count[i];
            count[i] = sum - count[i];
        }

        int[] positions = new int[input.Length];
        for (int i = 0; i < input.Length; ++i)
        {
            positions[count[input[i]]] = i;
            ++count[input[i]];
        }

        char[] result = new char[input.Length];
        int index = positions[endPosition];
        for (int i = 0; i < input.Length; ++i)
        {
            result[i] = input[index];
            index = positions[index];
        }

        return new string(result);
    }
}