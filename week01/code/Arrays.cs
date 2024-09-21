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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        
        var multiples = new double[length];//create array length of abount of numbers wanted
        for(int i = 0; i< length; i++){//DO A loop equal to number length
            multiples[i] = number * (i + 1);//each loop set number index to number * iteration of loop
            Console.WriteLine(multiples);
        }
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

    
        amount = amount % data.Count;// first modulo amount by number of items in list to account for full cycles
        
        var movingNums = data.GetRange(data.Count-amount , amount); // get the last 'amount' of elements and store them
        
        data.InsertRange(0, movingNums); // after add those numbers at the end of list
    
        // Step 5: Remove the last 'amount' of elements from the list (which are now duplicated at the start)
        data.RemoveRange(data.Count - amount, amount);// lastly remove the items that were copied from the front of the list
        
        Console.WriteLine("Data List = "+ data); // print for fun


    }
}
