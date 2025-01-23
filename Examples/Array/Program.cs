namespace Array;

using System;

internal class Program
{
  static void Main(string[] args)
  {
    /*
     * Given an Array of integers, return an Array where every element at an even-indexed position is squared.
     * 
     * Input: array = [9, -2, -9, 11, 56, -12, -3]
     * Output: [81, -2, 81, 11, 3136, -12, 9]
     */

    int[] result_1 = SquareEven([9, -2, -9, 11, 56, -12, -3]);

    foreach (int item in result_1)
    {
      Console.Write(item + " ");
    }


    /*
     * Given a sorted array, remove the duplicates such that each element appears only once.
     * 
     * Input: array = [1, 1, 2]
     * Output: [1, 2]
     * 
     * Input: array = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4]
     * Output: [0, 1, 2, 3, 4]
     */

    Console.WriteLine();

    int[] result_2 = RemoveDuplicates([0, 0, 1, 1, 1, 2, 2, 3, 3, 4]);

    foreach (var item in result_2)
    {
      Console.Write(item + " ");
    }

    /*
     * Given a binary array nums, return the maximum number of consecutive 1's in the array.
     * Input: nums = [1,1,0,1,1,1]
     * Output: 3
     * Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
     */

    Console.WriteLine();

    int result_3 = FindMaxConsecutiveOnes([1, 0, 1, 1, 0, 1]);

    Console.Write(result_3);

  }

  private static int FindMaxConsecutiveOnes(int[] value)
  {
    int max = 0;
    int result = 0;

    for (int i = 0; i < value.Length; i++)
    {
      if (value[i] == 1)
      {
        result++;
        if (result > max)
        {
          max = result;
        }
      }
      else
      {
        result = 0;
      }
    }

      return result;
  }

  internal static int[] SquareEven(int[] array)
  {
    if(array == null)
    {
      return array;
    }

    for(int i = 0; i<array.Length; i+=2)
    {
      array[i] *= array[i];
    }

    return array;
  }

  internal static int[] RemoveDuplicates (int[] array)
  {
    if(array == null)
    {
      return array;
    }

    int writePointer = 1;

    for (int readPointer = 1; readPointer < array.Length; readPointer++)
    {
      if (array[readPointer] != array[readPointer - 1])
      {
        array[writePointer] = array[readPointer];
        writePointer++;
      }
    }

    return array;
  }
}
