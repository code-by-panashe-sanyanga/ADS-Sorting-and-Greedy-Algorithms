using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx3
{
    // Main program for Assessed Exercise 3.

    // This class handles user interaction and demonstrates

    // QuickSort and a greedy algorithm using a menu system.

    internal class Program
    {
        // Stores all aid items added by the user during the program run.

        static List<AidItem> aidItems = new List<AidItem>();

        // Entry point of the program.

        // Displays a menu and continues running until the user exits.

        static void Main(string[] args)
        {


            //Create a Menu driven interface here so a user can interact with your implementations

            //I.e. while(true){
            // print to user - "Select an option"
            // "1. Demo sort..."
            // "2. Add item for greedy algorithm... ect
            //}

            //You won't need to create either of the utils classes, both use static methods.

            //I.e. 
            //SortUtils.InsertSort();
            //GreedyUtils.GetGreedyManifesto();

            // Keep showing the menu until the user chooses option 6.

            while (true)
            {
                Console.WriteLine("Assessed Exercise 3 Menu");
                Console.WriteLine("1. Demo QuickSort with integers");
                Console.WriteLine("2. Demo QuickSort with strings");
                Console.WriteLine("3. Add new AidItem");
                Console.WriteLine("4. View all AidItems");
                Console.WriteLine("5. Execute greedy algorithm");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                // Read the user's menu choice.

                string choice = Console.ReadLine();
                Console.WriteLine();

                // Call the relevant method based on the user's input.

                switch (choice)
                {
                    case "1":
                        DemoQuickSortIntegers();
                        break;

                    case "2":
                        DemoQuickSortStrings();
                        break;

                    case "3":
                        AddAidItem();
                        break;

                    case "4":
                        ViewAllAidItems();
                        break;

                    case "5":
                        ExecuteGreedyAlgorithm();
                        break;

                    case "6":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }

                // Pause before returning to the menu.

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // This method demonstrates the QuickSort algorithm using integers.
        // The user enters numbers which are then sorted and displayed.

        static void DemoQuickSortIntegers()
        {
            Console.WriteLine("QuickSort Demo - Integers");
            Console.WriteLine("Enter integers separated by spaces:");

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("No input provided.");
                return;
            }

            string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[parts.Length];

            try
            {
                for (int i = 0; i < parts.Length; i++)
                {
                    numbers[i] = int.Parse(parts[i]);
                }

                Console.WriteLine("\nOriginal array:");
                foreach (int num in numbers)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();

                SortUtils.QuickSortGen(numbers);

                Console.WriteLine("\nSorted array:");
                foreach (int num in numbers)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid integers only.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // This method demonstrates the QuickSort algorithm using strings.
        // Words entered by the user are sorted alphabetically.

        static void DemoQuickSortStrings()
        {
            Console.WriteLine("QuickSort Demo - Strings");
            Console.WriteLine("Enter strings separated by spaces:");

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("No input provided.");
                return;
            }

            string[] strings = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("\nOriginal array:");
            foreach (string str in strings)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();

            SortUtils.QuickSortGen(strings);

            Console.WriteLine("\nSorted array:");
            foreach (string str in strings)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
        }

        // This method allows the user to add a new AidItem.
        // Input is validated to ensure values are within the allowed ranges.

        static void AddAidItem()
        {
            Console.WriteLine("Add New AidItem");
            Console.Write("Enter item name: ");

            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Error: Name cannot be empty.");
                return;
            }

            Console.Write("Enter weight (1-50 kg): ");
            string weightInput = Console.ReadLine();
            int weight;

            if (!int.TryParse(weightInput, out weight))
            {
                Console.WriteLine("Error: Weight must be a valid integer.");
                return;
            }

            if (weight < 1 || weight > 50)
            {
                Console.WriteLine("Error: Weight must be between 1 and 50 kg.");
                return;
            }

            Console.Write("Enter priority (1-10): ");
            string priorityInput = Console.ReadLine();
            int priority;

            if (!int.TryParse(priorityInput, out priority))
            {
                Console.WriteLine("Error: Priority must be a valid integer.");
                return;
            }

            if (priority < 1 || priority > 10)
            {
                Console.WriteLine("Error: Priority must be between 1 and 10.");
                return;
            }

            AidItem newItem = new AidItem(name, weight, priority);
            aidItems.Add(newItem);

            Console.WriteLine($"AidItem added successfully: {newItem}");
        }

        // This method displays all AidItems currently stored.
        // If no items exist, a message is shown instead.

        static void ViewAllAidItems()
        {
            Console.WriteLine("All AidItems:");
            Console.WriteLine("-------------");

            if (aidItems.Count == 0)
            {
                Console.WriteLine("No items have been added yet.");
                return;
            }

            foreach (AidItem item in aidItems)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nTotal items: {aidItems.Count}");
        }

        // This method runs the greedy algorithm to select the best set of AidItems.
        // It selects items without exceeding the drone weight limit.

        static void ExecuteGreedyAlgorithm()
        {
            Console.WriteLine("Greedy Algorithm - Drone Loadout Selection");
            Console.WriteLine("-------------------------------------------");

            if (aidItems.Count == 0)
            {
                Console.WriteLine("No items available. Please add some AidItems first.");
                return;
            }

            double weightLimit = 75.0;

            List<AidItem> selected = GreedyUtils.GetGreedyOptimTasks(aidItems, weightLimit);

            Console.WriteLine($"Weight limit: {weightLimit} kg");
            Console.WriteLine("\nSelected items:");

            if (selected.Count == 0)
            {
                Console.WriteLine("No items could be selected.");
                return;
            }

            int totalWeight = 0;
            int totalPriority = 0;

            // Display selected items and calculate totals.

            foreach (AidItem item in selected)
            {
                Console.WriteLine($"  {item}");
                totalWeight += item.Weight;
                totalPriority += item.Priority;
            }

            Console.WriteLine($"\nTotal weight: {totalWeight} kg");
            Console.WriteLine($"Total priority: {totalPriority}");
            Console.WriteLine($"Remaining capacity: {weightLimit - totalWeight} kg");
        }
    }
}
