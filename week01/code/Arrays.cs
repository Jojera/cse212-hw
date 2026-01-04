public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    

    /// Plam for the MultipleOf function
    // Step 1: Decide what the function should return → an array of doubles.
    // Step 2: Create a new array of size 'length' to hold the multiples.
    // Step 3: Use a loop that runs from 0 up to length-1.
    // Step 4: For each position i in the array, calculate (number * (i+1)).
    //      Example: if number=3 and i=0 → 3*1=3, i=1 → 3*2=6, etc.
    // Step 5: Store the result in the array at index i.
    // Step 6: After the loop finishes, return the array.
    public static double[] MultiplesOf(double number, int length)
    {
        // Create an array to hold the multiples
        double[] multiples = new double[length];

        // Fill the array with multiples of 'number'
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        // Return the completed array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    

    ///Plan for the RotateListRight function
    // Step 1: Understand the goal → rotate the list to the right by 'amount'.
    // Step 2: Example: data={1,2,3,4,5,6,7,8,9}, amount=3 → result={7,8,9,1,2,3,4,5,6}.
    // Step 3: Calculate the split point: data.Count - amount.
    //         This tells us where to cut the list into two parts.
    // Step 4: Use GetRange to slice the list into two parts:
    //         - The last 'amount' elements (right side).
    //         - The first part (remaining elements).
    // Step 5: Clear the original list (or rebuild it).
    // Step 6: Add the right-side slice first, then add the left-side slice.
    // Step 7: The list is now rotated in place.
    public static void RotateListRight(List<int> data, int amount)
    {
        // Find the split point
        int splitIndex = data.Count - amount;

        // Slice the list into two parts
        List<int> rightPart = data.GetRange(splitIndex, amount);
        List<int> leftPart = data.GetRange(0, splitIndex);

        // Clear the original list and rebuild it
        data.Clear();
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
