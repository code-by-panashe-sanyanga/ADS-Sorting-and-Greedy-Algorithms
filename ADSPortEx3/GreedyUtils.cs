using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx3
{
    // Utility class for the greedy algorithm used in Assessed Exercise 3.

    // This class selects aid items based on priority while staying within a weight limit.

    class GreedyUtils
    {
        //Greedy algorithm implementation for Assessed Exercise 3

        //Hints : 
        //Use lecture materials from Week 8 to aid with implementation.

        // Applies a greedy approach to select the most suitable AidItems.

        // Items are sorted first, then added in order until the weight limit is reached.

        public static List<AidItem> GetGreedyOptimTasks(List<AidItem> items, double limit)
        {
            // If the list is null or empty, return an empty result.

            if (items == null || items.Count == 0)
                return new List<AidItem>();

            // Create a copy of the list so the original data is not changed.

            List<AidItem> sortedItems = new List<AidItem>(items);

            // Convert the list to an array so it can be sorted using QuickSort.

            AidItem[] itemsArray = sortedItems.ToArray();

            // Sort items based on their comparison logic.

            SortUtils.QuickSortGen(itemsArray);

            // Convert the sorted array back into a list.

            sortedItems = new List<AidItem>(itemsArray);

            // Stores the selected items that fit within the weight limit.

            List<AidItem> selected = new List<AidItem>();

            // Tracks the current total weight of selected items.

            double totalWeight = 0;

            // Loop through the sorted items and add them while space remains.

            foreach (AidItem item in sortedItems)
            {
                // Check if adding the item would exceed the weight limit.

                if (totalWeight + item.Weight <= limit)
                {
                    selected.Add(item);
                    totalWeight += item.Weight;
                }
            }

            // Return the final list of selected items.

            return selected;
        }

    }
}
