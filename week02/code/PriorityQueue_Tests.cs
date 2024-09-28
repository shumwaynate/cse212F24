using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue a single item and dequeue it.
    // Expected Result: The item "Task 1" should be returned.
    // Defect(s) Found: None in this case; the behavior is as expected.
    public void TestPriorityQueue_EnqueueDequeueSingle()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task 1", 1);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Task 1", result);
        // Attempting to dequeue again should throw an exception
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities.
    // Expected Result: "Task 2" (highest priority) should be dequeued first,
    // followed by "Task 3" and then "Task 1".
    // Defect(s) Found: 
    // - The original code does not correctly identify the highest priority item due to incorrect loop limits.
    // - The loop incorrectly checks until `_queue.Count - 1`, missing the last item in the queue.
    public void TestPriorityQueue_EnqueueMultipleDifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task 1", 1);
        priorityQueue.Enqueue("Task 2", 3);
        priorityQueue.Enqueue("Task 3", 2);

        Assert.AreEqual("Task 2", priorityQueue.Dequeue()); // Highest priority
        Assert.AreEqual("Task 3", priorityQueue.Dequeue()); // Next highest
        Assert.AreEqual("Task 1", priorityQueue.Dequeue()); // Last
        // Attempting to dequeue from an empty queue should throw an exception
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority.
    // Expected Result: "Task 1" should be dequeued first, followed by "Task 2".
    // Defect(s) Found: 
    // - The original code fails to remove the item with the highest priority from the queue, leading to incorrect behavior.
    // - If multiple items have the same priority, the FIFO ordering is not preserved in the current implementation.
    public void TestPriorityQueue_EnqueueSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task 1", 5);
        priorityQueue.Enqueue("Task 2", 5);
        priorityQueue.Enqueue("Task 3", 3);

        Assert.AreEqual("Task 1", priorityQueue.Dequeue()); // FIFO for highest priority
        Assert.AreEqual("Task 2", priorityQueue.Dequeue()); // Next
        Assert.AreEqual("Task 3", priorityQueue.Dequeue()); // Last
        // Attempting to dequeue from an empty queue should throw an exception
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: An exception should be thrown.
    // Defect(s) Found: None in this case; the behavior is as expected.
    public void TestPriorityQueue_EmptyDequeue()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    // Additional test cases can be added below as needed.
}
