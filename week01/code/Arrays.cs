public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Create a new array to hold the multiples
        double[] multiples = new double[length];

        // Initialize the first element with the starting number
        multiples[0] = number;

        // Fill the rest of the array with the other multiples, using a for loop
        for (int i = 1; i < length; i++) {
            // Each multiple is the previous multiple plus the starting number
            multiples[i] = multiples[i - 1] + number;
        }

        // Return the array of multiples
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount) {
        // Divide the list into 2 parts
        // Get the index of where to split
        var splitIndex = data.Count - amount;
        // Get the part to rotate (the back end of the list)
        var rotated = data.Skip(splitIndex).ToList();
        // Get whatever is the remaining part (whatever we didn't take off the front end of the list)
        var left = data.Take(splitIndex).ToList();

        // Rebuild the list, in rotated order
        data.Clear();
        data.AddRange(rotated);
        data.AddRange(left);
    }
}
