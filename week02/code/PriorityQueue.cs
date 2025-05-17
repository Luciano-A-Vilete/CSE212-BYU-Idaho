using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.
    /// The node is always added to the back of the queue regardless of the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Remove and return the value with the highest priority.
    /// In case of tie, the one that appeared last is removed (LIFO for same priority).
    /// </summary>
    /// <returns>The value with the highest priority</returns>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority
        var highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++) // FIXED: loop should go to Count, not Count - 1
        {
            if (_queue[index].Priority >= _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Remove and return the item with the highest priority
        var item = _queue[highPriorityIndex];
        _queue.RemoveAt(highPriorityIndex); // FIXED: properly remove the item
        return item.Value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
