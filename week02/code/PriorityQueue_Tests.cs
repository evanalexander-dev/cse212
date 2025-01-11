using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests {
    [TestMethod]
    // Scenario: Create a Queue with data and priorities (including some of the same priorities)
    // First|2, Second|1, Third|2, Fourth|3
    // Expected Result: Fourth, First, Third, Second
    // Defect(s) Found: Did not get highest priority out of queue
    public void TestPriorityQueue_1() {
        var priorityQueue = new PriorityQueue();

        string[] expected = ["Fourth", "First", "Third", "Second"];

        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 1);
        priorityQueue.Enqueue("Third", 2);
        priorityQueue.Enqueue("Fourth", 3);

        for (var i = 0; i < 4; i++) {
            var data = priorityQueue.Dequeue();
            Assert.AreEqual(expected[i], data);
        }
    }

    [TestMethod]
    // Scenario: Create an empty queue and check for error
    // Expected Result: Exception thrown with correct error message.
    // Defect(s) Found: No Defect Found
    public void TestPriorityQueue_2() {
        var priorityQueue = new PriorityQueue();
        try {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e) {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException) {
            throw;
        }
        catch (Exception e) {
            Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
        }
    }

    // Add more test cases as needed below.
}