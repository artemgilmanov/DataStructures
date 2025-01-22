namespace Array;

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

    int[] array_2 = RemoveDuplicates([0, 0, 1, 1, 1, 2, 2, 3, 3, 4]);

    foreach (var item in array_2)
    {
      Console.Write(item + " ");
    }
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
