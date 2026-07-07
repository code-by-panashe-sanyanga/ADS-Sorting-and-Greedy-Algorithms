using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx3
{
    // This class contains methods used to analyse
    // the time complexity of different algorithms.
    class ComplexityFunctions
    {
        //Big O calculation for Assessed Exercise 3A

        //Hints : 
        //Use lecture materials from Week 6B to aid with calculations.

        //See ExampleQuestion() to see a suggested format for showing your
        // working out and final answer, both of which must be shown with correct
        // answers for full marks.

        // Example method used to demonstrate
        // how to calculate Big O time complexity.
        public void ExampleQuestion()
        {
            //F.C
            // Fixed cost operation.
            // Runs once regardless of input size.
            Console.WriteLine("Enter a number 1:");          // 1
            // Reading and parsing input is also fixed cost.
            int num1 = Int32.Parse(Console.ReadLine());      // 1

            // Second input is also a fixed cost operation.
            Console.WriteLine("Enter a number 2:");          // 1
            int num2 = Int32.Parse(Console.ReadLine());      // 1

            // Loop runs based on the value of num2.
            // Condition is checked n + 1 times.
            for (int i = 1; i <= num2; i++)                  // n + 1
            {
                // Loop body runs once per iteration.
                Console.WriteLine(num1.ToString() + " X "
                    + i.ToString() + " = " + (num1 * i));   // n
            }

            // Final output and input are fixed cost.
            Console.WriteLine("End of program...");         // 1
            Console.ReadLine();                             // 1

            // Working out

            // 7 + 2n - All fixed costs and loop operations added together
            // 2n - Constant values removed
            // n - Coefficient removed
            // O(n) - Final time complexity
        }

        // Algorithm1 demonstrates a nested loop structure.
        public void Algorithm1()
        {
            int n = Int32.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            for (int i = 0; i < n; i++)
            {
                numbers.Add(i * 2);
            }
            int total = 0;
            // Outer loop runs n times.
            for (int i = 0; i < n; i++)
            {
                // Inner loop runs from i to n,
                // increasing total number of operations.
                for (int j = i; j < n; j++)
                {
                    if (numbers[j] % 3 == 0)
                      total += numbers[j];  
                }
            }
            // Output the final result.

            Console.WriteLine("Total: " + total);          // 1

            // Time complexity explanation:

            // First loop runs n times

            // Nested loops result in roughly n squared operations

            // Overall time complexity is O(n²)

            //Working out
            // Fixed costs: 1 (read n) + 1 (create list) + 1 (total = 0) + 1 (output) = 4
            // First loop: (n+1) condition checks + n executions = 2n + 1
            // Outer loop of nested loops: (n+1) condition checks
            // Inner loop: when i=0, j runs n times; i=1, j runs (n-1) times; ... i=(n-1), j runs 1 time
            // Total inner loop iterations: n + (n-1) + ... + 1 = n(n+1)/2
            // Inner loop condition checks: for each i, (n-i+1) checks = sum from i=0 to n-1 of (n-i+1) = n(n+1)/2 + n
            // Body of inner loop (if statement): n(n+1)/2 times
            // Worst case body execution (total +=): n(n+1)/2 times
            // Total: 4 + (2n + 1) + (n+1) + (n(n+1)/2 + n) + n(n+1)/2 + n(n+1)/2
            // Total: 4 + 2n + 1 + n + 1 + n(n+1)/2 + n + n(n+1)/2 + n(n+1)/2
            // Total: 6 + 4n + (3/2)n(n+1)
            // Total: 6 + 4n + (3/2)n² + (3/2)n
            // Total: (3/2)n² + (11/2)n + 6
            // Dominant term: (3/2)n²
            // After removing constants and coefficients: n²
            // O(n²)  Final answer

        }

        // Algorithm2 counts how many prime numbers
        // exist up to the value n.
        public void Algorithm2()
        {

            int n = Int32.Parse(Console.ReadLine());
            int primeCount = 0;

            for (int i = 2; i <= n; i++)
            {
                bool isPrime = true;
                int j = 2;
                while (j * j <= i)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    j++;
                }
                if (isPrime)
                    primeCount++;
                
            }
            // Display the result.

            Console.WriteLine("Number of primes up to " + n + ": " + primeCount);  // 1

            // Time complexity explanation:

            // Outer loop runs n times

            // Inner loop runs up to sqrt(n)

            // Overall time complexity is O(n√n)

            //Working out
            // Outer loop runs from i=2 to i=n, so that's n-1 iterations
            // For each iteration of i, the inner while loop runs while j*j <= i
            // This means j goes from 2 up to sqrt(i), so the loop runs approximately sqrt(i) times
            // For i=2, j runs from 2 to sqrt(2) ≈ 1.4, so about 1 iteration
            // For i=3, j runs from 2 to sqrt(3) ≈ 1.7, so about 1 iteration
            // For i=4, j runs from 2 to sqrt(4) = 2, so about 1 iteration
            // For i=n, j runs from 2 to sqrt(n), so about sqrt(n) iterations
            // Total inner loop iterations: sum from i=2 to n of sqrt(i)
            // This sum is approximately the integral of sqrt(x) from 2 to n
            // Integral of sqrt(x) = (2/3)x^(3/2)
            // Evaluating from 2 to n: (2/3)n^(3/2) - (2/3)*2^(3/2) ≈ (2/3)n^(3/2)
            // Constants and linear terms: 1 + 1 + (n-1) + (n-1) + (n-1) + 1 = 3n - 1
            // Dominant term is approximately (2/3)n^(3/2)
            // After removing constants and coefficients: n^(3/2)
            // O(n√n) or O(n^(3/2))  Final answer

        }
    }
}
