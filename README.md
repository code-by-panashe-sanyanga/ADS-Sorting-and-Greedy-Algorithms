# ADS Assessed Exercise 3 — Complexity, Sorting & Greedy Algorithms

**Module:** Algorithms and Data Structures (ADS)
**Author:** [Panashe Sanyanga](https://github.com/code-by-panashe-sanyanga)
**Language:** C# (.NET Framework)

> **Note:** This is a **re-upload** of my university assessed coursework so it lives on my personal GitHub profile alongside my other work.

---

## Algorithms covered

This exercise brings together three algorithm topics:

1. **Big-O time complexity analysis** — working out the running time of sample algorithms step by step.
2. **QuickSort** — a generic, recursive, divide-and-conquer sorting algorithm.
3. **Greedy algorithm** — a knapsack-style selection that picks items by priority-to-weight ratio under a weight limit.

## What the program does

It models a **humanitarian aid packing** problem. Each aid item has a name, weight, and priority. The greedy algorithm sorts items by their priority-to-weight ratio (using the QuickSort implementation) and packs the most valuable items that fit within a weight limit.

## The three parts

### 3A — Complexity analysis (`ComplexityFunctions.cs`)
Contains worked Big-O calculations with the full working shown in comments:

| Method | Complexity | Reason |
|--------|-----------|--------|
| `ExampleQuestion` | O(n) | single loop over input |
| `Algorithm1` | O(n²) | nested loops |
| `Algorithm2` | O(n√n) | outer loop n, inner loop up to √n (prime check) |

### 3B — Generic QuickSort (`SortUtils.cs`)
Starts from a non-generic integer QuickSort and generalises it to `QuickSortGen<T>` for any `IComparable` type, using recursion and pivot partitioning. Average case **O(n log n)**, worst case O(n²).

### 3C — Greedy selection (`GreedyUtils.cs`)
`GetGreedyOptimTasks` sorts the aid items (via `QuickSortGen`) by priority ratio, then greedily adds items while they fit under the weight limit — combining the sorting and greedy topics into one solution.

## Project structure

```
ADSPortEx3/
├── ComplexityFunctions.cs   # 3A: Big-O worked examples
├── SortUtils.cs             # 3B: generic QuickSort
├── GreedyUtils.cs           # 3C: greedy item selection
├── AidItem.cs               # Data model: name, weight, priority, ratio (IComparable)
├── Program.cs               # Console harness
├── App.config
└── Properties/AssemblyInfo.cs
ADSPortEx3.sln
```

## File breakdown

- **`ComplexityFunctions.cs`** — sample algorithms annotated with fixed-cost/loop-cost working and the final Big-O answer.
- **`SortUtils.cs`** — both the original integer QuickSort and the generic `QuickSortGen<T>` version with its recursive partitioning.
- **`GreedyUtils.cs`** — the greedy packing logic that reuses QuickSort to order items first.
- **`AidItem.cs`** — the item being packed; `CompareTo` sorts by priority-to-weight ratio (descending), which drives the greedy choice.
- **`Program.cs`** — runs the parts and prints the selected items.

## How to run it

**Visual Studio**

1. Open `ADSPortEx3.sln`.
2. Press **F5** or **Ctrl+F5**.

**Command line**

```bash
msbuild ADSPortEx3.sln
ADSPortEx3\bin\Debug\ADSPortEx3.exe
```

## Key takeaways

- How to count operations and reduce them to Big-O notation.
- Making an algorithm generic with `IComparable` so it works for any comparable type.
- How a greedy strategy uses a sort step to make locally optimal choices — and that greedy is not always globally optimal for the 0/1 knapsack.
