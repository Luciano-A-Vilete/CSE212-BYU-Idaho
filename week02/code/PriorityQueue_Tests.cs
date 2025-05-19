using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: Exception is thrown with message "The queue is empty."
    // Defect(s) Found: None
    public void Test_Dequeue_EmptyQueue_ThrowsException()
    {
        var queue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Enqueue one item and Dequeue it
    // Expected Result: That item is returned
    // Defect(s) Found: None
    public void Test_SingleEnqueueDequeue()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("apple", 5);
        var result = queue.Dequeue();

        Assert.AreEqual("apple", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities
    // Expected Result: Highest priority item is removed
    // Defect(s) Found: None
    public void Test_HighestPriorityDequeued()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("apple", 5);
        queue.Enqueue("banana", 7);
        queue.Enqueue("carrot", 6);

        var result = queue.Dequeue();
        Assert.AreEqual("banana", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with same priority
    // Expected Result: The first one (FIFO) is dequeued
    // Defect(s) Found: Original code dequeued last one (LIFO)
    public void Test_SamePriority_FIFOOrder()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("apple", 5);
        queue.Enqueue("banana", 5);
        queue.Enqueue("carrot", 5);

        var result = queue.Dequeue();
        Assert.AreEqual("apple", result);
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities and verify correct sequence
    // Expected Result: Order of dequeues: tomato, carrot, apple
    // Defect(s) Found: None
    public void Test_MixedPrioritiesSequence()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("apple", 1);     // lowest
        queue.Enqueue("banana", 2);
        queue.Enqueue("carrot", 3);    // middle
        queue.Enqueue("tomato", 4);    // highest

        Assert.AreEqual("tomato", queue.Dequeue());  // 4
        Assert.AreEqual("carrot", queue.Dequeue());  // 3
        Assert.AreEqual("banana", queue.Dequeue());  // 2
        Assert.AreEqual("apple", queue.Dequeue());   // 1
    }
}
