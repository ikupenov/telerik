using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();

        //Get Numbers From Array - 1
        if (numbers.Length % 2 == 1)
        {
            for (int left = 0; left <= numbers.Length / 2; left ++)
            {
                leftList.Add(numbers[left]);
            }

            for (int right = numbers.Length / 2 + 1; right < numbers.Length; right++)
            {
                rightList.Add(numbers[right]);
            }
        }

        else if (numbers.Length % 2 == 0)
        {
            for (int left = 0; left < numbers.Length / 2; left++)
            {
                leftList.Add(numbers[left]);
            }

            for (int right = numbers.Length / 2; right < numbers.Length; right++)
            {
                rightList.Add(numbers[right]);
            }
        }
        //-------------------------------------GNFA-1

        int minNumber = int.MaxValue;
        int counter = 0;

        //Fill Lists
        for (int i = 0; i < leftList.Count; i++)
        {
            for (int j = 0; j < leftList.Count; j++)
            {
                if (leftList[j] < minNumber)
                {
                    minNumber = leftList[j];
                }
            }

            numbers[counter] = minNumber;

            int index = leftList.IndexOf(minNumber);
            leftList[index] = int.MaxValue;

            minNumber = int.MaxValue;
            counter++;
        }

        for (int i = 0; i < rightList.Count; i++)
        {
            for (int j = 0; j < rightList.Count; j++)
            {
                if (rightList[j] < minNumber)
                {
                    minNumber = rightList[j];
                }
            }

            numbers[counter] = minNumber;

            int index = rightList.IndexOf(minNumber);
            rightList[index] = int.MaxValue;

            minNumber = int.MaxValue;
            counter++;
        }
        //-------------------------------------Fill Lists

        //Get Numbers From Array - 2
        leftList.Clear();
        rightList.Clear();

        if (numbers.Length % 2 == 1)
        {
            for (int left = 0; left <= numbers.Length / 2; left++)
            {
                leftList.Add(numbers[left]);
            }

            for (int right = numbers.Length / 2 + 1; right < numbers.Length; right++)
            {
                rightList.Add(numbers[right]);
            }
        }

        else if (numbers.Length % 2 == 0)
        {
            for (int left = 0; left < numbers.Length / 2; left++)
            {
                leftList.Add(numbers[left]);
            }

            for (int right = numbers.Length / 2; right < numbers.Length; right++)
            {
                rightList.Add(numbers[right]);
            }
        }
        //-------------------------------------GNFA-2

        minNumber = int.MaxValue;
        counter = 0;

        int leftCounter = 0;
        int rightCounter = 0;

        while (leftCounter < leftList.Count && rightCounter < rightList.Count)
        {
            if (leftList[leftCounter] <= rightList[rightCounter])
            {
                numbers[counter] = leftList[leftCounter];
                leftCounter++;
            }

            else if (rightList[rightCounter] < leftList[leftCounter])
            {
                numbers[counter] = rightList[rightCounter];
                rightCounter++;
            }

            counter++;
        }


        if (leftCounter == leftList.Count && rightCounter < rightList.Count)
        {
            for (int i = rightCounter; i < rightList.Count; i++)
            {
                int rightMin = int.MaxValue;

                for (int j = rightCounter; j < rightList.Count; j++)
                {
                    if (rightList[j] < rightMin)
                    {
                        rightMin = rightList[j];
                    }
                }

                numbers[counter] = rightMin;

                int index = rightList.IndexOf(rightMin);

                rightList[index] = int.MaxValue;
                counter++;
            }
        }

        else if (rightCounter == rightList.Count && leftCounter < leftList.Count)
        {
            for (int i = leftCounter; i < leftList.Count; i++)
            {
                int leftMin = int.MaxValue;

                for (int j = leftCounter; j < leftList.Count; j++)
                {
                    if (leftList[j] < leftMin)
                    {
                        leftMin = leftList[j];
                    }
                }

                numbers[counter] = leftMin;

                int index = leftList.IndexOf(leftMin);

                leftList[index] = int.MaxValue;
                counter++;
            }
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}