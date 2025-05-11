public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(3, 5) will result in: {3, 6, 9, 12, 15}.
    /// 
    /// Plan:
    /// 1. Create an array of doubles with the size given by 'length'.
    /// 2. Loop from 0 to length-1:
    ///    - For each position i, calculate the multiple as: number * (i + 1)
    ///      (We use i+1 because we want to start with the 'number' itself, not 0).
    ///    - Assign this value to the array at position i.
    /// 3. Return the filled array.
    /// </summary>
    /// <returns>Array of doubles that are the multiples of the supplied number.</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of size 'length'.
        double[] multiples = new double[length];

        // Step 2: Loop through each index in the array.
        for (int i = 0; i < length; i++)
        {
            // Calculate the multiple for this index.
            // (i + 1) ensures we start multiplying from 1, 2, 3, ... up to 'length'.
            multiples[i] = number * (i + 1);
        }

        // Step 3: Return the array filled with the multiples.
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after 
    /// the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// This function modifies the existing list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Find the number of elements in the list.
        int n = data.Count;

        // Step 2: Get the sublist containing the last 'amount' elements.
        // The GetRange method returns a new list containing these elements.
        List<int> subList = data.GetRange(n - amount, amount);

        // Step 3: Remove the last 'amount' elements from the original list.
        data.RemoveRange(n - amount, amount);

        // Step 4: Insert the sublist at the beginning of the original list.
        // The InsertRange method adds the entire sublist at the specified index.
        data.InsertRange(0, subList);
    }
}
