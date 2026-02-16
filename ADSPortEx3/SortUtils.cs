using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx3
{
    //Generic QuickSort implementation for Assessed Exercise 3

    //Hints : 
    //Use lecture materials from Week 7 to aid with implementation.

    //Use the provided QuickSort function as a starting point for
    // adjusting the functionality to make it generic. Make use of IComparable
    // as you have done during other structure implementations

    //Your implemented function can be utilised as part EX.3C

    class SortUtils
    {
        // Swaps two integer values.

        // Used by the non generic QuickSort method.

        static void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        static public void QuickSort(int[] items, int left, int right)
        {
            int i, j;
            i = left; j = right;
            int pivot = items[left];

            while (i <= j)
            {
                for (; (items[i] < pivot) && (i < right); i++) ;
                for (; (pivot < items[j]) && (j > left); j--) ;

                if (i <= j)
                    swap(ref items[i++], ref items[j--]);
            }

        if (left < j) QuickSort(items, left, j);
        if (i < right) QuickSort(items, i, right);
    }

    // Generic swap method used by the generic QuickSort.

    static void swapGen<T>(ref T x, ref T y)
    {
        T temp = x;
        x = y;
        y = temp;
    }

    // Generic QuickSort entry method.

    // Works with any type that implements IComparable.

    static public void QuickSortGen<T>(T[] a) where T : IComparable
    {
        // No sorting needed for null or single element arrays.

        if (a == null || a.Length <= 1)
            return;

        // Call the recursive sorting method.

        QuickSortGenRecursive(a, 0, a.Length - 1);
    }

    // Recursive generic QuickSort method.

    // Sorts elements between the left and right indexes.

    static void QuickSortGenRecursive<T>(T[] items, int left, int right) where T : IComparable
    {
        int i, j;
        i = left;
        j = right;

        // Choose the first element as the pivot.

        T pivot = items[left];

        // Partition the array using comparisons.

        while (i <= j)
        {
            // Move i forward while item is less than the pivot.

            while (items[i].CompareTo(pivot) < 0 && i < right)
                i++;

            // Move j backward while item is greater than the pivot.

            while (pivot.CompareTo(items[j]) < 0 && j > left)
                j--;

            // Swap items when the indexes meet.

            if (i <= j)
                swapGen(ref items[i++], ref items[j--]);
        }

        // Recursively sort the left section.

        if (left < j)
            QuickSortGenRecursive(items, left, j);

        // Recursively sort the right section.

        if (i < right)
            QuickSortGenRecursive(items, i, right);
    }


    }
}
