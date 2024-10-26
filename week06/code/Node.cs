public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value) // node = {value , Left , Right}
    {
        // TODO Start Problem 1

        if (value < Data) //less than
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if(value > Data)// greater than
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }else{ //if equal to
            //nothing
        }

    }

    public bool Contains(int value)// node = {value , Left , Right}
    {
        if (value < Data) //less than
        {
            // check to the left
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else if(value > Data)// greater than
        {
            // cheeck to the right
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }else{ //if equal to
            return true;
        }
        
    }

    public int GetHeight() // first call start at 0
    {
        
        var leftCount = Left?.GetHeight() ?? 0; //if left exists get that value, otherwise 0
        var rightCount = Right?.GetHeight() ?? 0; //if right exists get that value, otherwise 0

        if (leftCount <= rightCount){// when counts on both sides the same or right is bigger
            return rightCount + 1; //count current node and amount on right and return
        }else{ //when count on left is bigger
            return leftCount + 1;
        }

    }
}