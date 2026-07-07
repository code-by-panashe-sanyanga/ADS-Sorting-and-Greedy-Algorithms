using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx3
{
    //AidItem class implementation for Assessed Exercise 3

    //For use as part of EX.3C

    //Use slides from Week 8A regarding the knapsack algorithm example to aid with implementation

    class AidItem: IComparable
    {
        // Private fields storing item details.

        private string name;

        private int weight;

        private int priority;

        // Constructor used to create a new AidItem.

        public AidItem(string name, int weight, int priority)
        {
            this.name = name;
            this.weight = weight;
            this.priority = priority;
        }

        // Gets or sets the name of the aid item.

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Gets or sets the weight of the item in kilograms.

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        // Gets or sets the priority value of the item.

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        // Calculates the priority to weight ratio.

        // This value is used by the greedy algorithm.

        public double PriorityRatio
        {
            get
            {
                // Prevent division by zero.

                if (weight == 0)
                    return 0;

                return (double)priority / weight;
            }
        }

        // Compares this AidItem with another AidItem.

        // Items with a higher priority ratio are treated as higher priority.

        public int CompareTo(object obj)
        {
            // If the object is null, this item is considered greater.

            if (obj == null)
                return 1;

            AidItem other = obj as AidItem;

            // Ensure the object being compared is an AidItem.

            if (other == null)
                throw new ArgumentException("Object is not an AidItem");

            // Sort in descending order based on priority ratio.

            return other.PriorityRatio.CompareTo(this.PriorityRatio);
        }

        // Returns a readable string version of the AidItem.

        public override string ToString()
        {
            return $"Name: {name}, Weight: {weight}kg, Priority: {priority}, Ratio: {PriorityRatio:F2}";
        }
    }
}
