using System.Linq;

namespace CountingSort
{
    public class CountingSorter
    {
        public void Sort(int[] arr)
        {
            int max = arr.Max();

            int[] counts = new int[max + 1];
            int[] output = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                counts[arr[i]]++;
            }

            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] += counts[i - 1];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                output[counts[arr[i]] - 1] = arr[i];
                counts[arr[i]]--;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = output[i];
            }
        }
    }
}