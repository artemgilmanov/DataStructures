﻿namespace Array;

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

    /*
     * Given an array nums of integers, return how many of them contain an even number of digits.
     * 
     * Example 1:
     * Input: nums = [12,345,2,6,7896]
     * Output: 2
     * 
     * Explanation: 
     * 12 contains 2 digits (even number of digits). 
     * 345 contains 3 digits (odd number of digits). 
     * 2 contains 1 digit (odd number of digits). 
     * 6 contains 1 digit (odd number of digits). 
     * 7896 contains 4 digits (even number of digits). 
     * Therefore only 12 and 7896 contain an even number of digits.
     */

    Console.WriteLine();

    int result_4 = FindNumbersWithEvenNumberOfDigits([12, 345, 2, 6, 7896]);

  }

  private static int FindNumbersWithEvenNumberOfDigits(int[] value)
  {
    int count = 0;
    for (int i = 0; i < value.Length; i++)
    {
      int digits = 0;
      
      while (value[i] >0)
      {
        value[i] /= 10;
        digits++;
      }

      if (digits % 2 == 0)
      {
        count++;
      }
    }
    return count;
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

      return max;
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
