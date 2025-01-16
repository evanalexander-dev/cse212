/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Check Queue sizing
        // Expected Result: size <= 0 means queue is size 10, and if size > 0 then queue should be provided size
        Console.WriteLine("Test 1");

        var csInvalidSize1 = new CustomerService(0);
        var csInvalidSize2 = new CustomerService(-1);
        var csInvalidSize3 = new CustomerService(-16);

        Console.WriteLine($"Invalid 1 (0): {csInvalidSize1}");
        Console.WriteLine($"Invalid 2 (-1): {csInvalidSize2}");
        Console.WriteLine($"Invalid 3 (-16): {csInvalidSize3}");

        var csSize1 = new CustomerService(3);
        var csSize2 = new CustomerService(12);
        var csSize3 = new CustomerService(16);

        Console.WriteLine($"Valid 1 (3): {csSize1}");
        Console.WriteLine($"Valid 2 (12): {csSize2}");
        Console.WriteLine($"Valid 3 (16): {csSize3}");

        // Defect(s) Found: N/A

        Console.WriteLine("=================");

        // Test 2
        // Scenario: add customer to the queue, and then serve them
        // Expected Result: Customer gets added, then removed and returned correctly
        Console.WriteLine("Test 2");

        var cs1Customer = new CustomerService(1);
        cs1Customer.AddNewCustomer();
        cs1Customer.ServeCustomer();

        // Defect(s) Found: ServeCustomer needs to remove from the queue AFTER getting the value

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Queue is already full when adding another customer
        // Expected Result: error message is displayed
        Console.WriteLine("Test 3");

        var csFull = new CustomerService(3);
        csFull.AddNewCustomer();
        csFull.AddNewCustomer();
        csFull.AddNewCustomer();
        csFull.AddNewCustomer();

        // Defect(s) Found: AddNewCustomer needs >= instead of just >

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Queue is empty, and trying to serve another customer (as well as making sure the queue is the right order)
        // Expected Result: Error message is displayed. Order is correct
        Console.WriteLine("Test 4");

        var csEmpty = new CustomerService(3);
        csEmpty.AddNewCustomer();
        csEmpty.AddNewCustomer();
        csEmpty.AddNewCustomer();
        csEmpty.ServeCustomer();
        csEmpty.ServeCustomer();
        csEmpty.ServeCustomer();
        csEmpty.ServeCustomer();

        // Defect(s) Found: Needs to check length and display a proper error message

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers Available.");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}