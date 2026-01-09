using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them.
    // Expected Result: Items should be dequeued in order of highest priority: High, Medium, Low
    // Defect(s) Found: 
    // 1. Loop condition uses (index < _queue.Count - 1) which skips the last element in the queue.
    // 2. Dequeue() doesn't remove the item from the queue after finding it.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority and dequeue them.
    // Expected Result: Items with same priority should be dequeued in FIFO order: First, Second, Third
    // Defect(s) Found: 
    // 1. Uses >= instead of > when comparing priorities, which causes the LAST item with the highest 
    //    priority to be selected instead of the FIRST (violates FIFO requirement).
    // 2. Same defects as TestPriorityQueue_1.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities, where multiple items have the same high priority.
    // Expected Result: Among items with same highest priority, the first one enqueued should be dequeued first (FIFO).
    // Defect(s) Found: Same defects as TestPriorityQueue_1 and TestPriorityQueue_2.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("HighFirst", 5);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("HighSecond", 5);

        Assert.AreEqual("HighFirst", priorityQueue.Dequeue());
        Assert.AreEqual("HighSecond", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - this requirement is correctly implemented.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue a single item and dequeue it.
    // Expected Result: The single item should be dequeued successfully.
    // Defect(s) Found: Missing _queue.RemoveAt() - item is not removed from queue.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("OnlyItem", 3);

        Assert.AreEqual("OnlyItem", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items in reverse priority order.
    // Expected Result: Items should still be dequeued by highest priority first.
    // Defect(s) Found: Same defects as TestPriorityQueue_1.
    public void TestPriorityQueue_ReversePriorityOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("Low", 1);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Complex scenario with multiple priorities and multiple items at same priority.
    // Expected Result: Dequeue in priority order, with FIFO for same priorities.
    // Defect(s) Found: Same defects as TestPriorityQueue_1 and TestPriorityQueue_2.
    public void TestPriorityQueue_ComplexScenario()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 4);
        priorityQueue.Enqueue("C", 4);
        priorityQueue.Enqueue("D", 1);
        priorityQueue.Enqueue("E", 4);
        priorityQueue.Enqueue("F", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // First item with priority 4
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Second item with priority 4
        Assert.AreEqual("E", priorityQueue.Dequeue()); // Third item with priority 4
        Assert.AreEqual("F", priorityQueue.Dequeue()); // Priority 3
        Assert.AreEqual("A", priorityQueue.Dequeue()); // Priority 2
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Priority 1
    }
}