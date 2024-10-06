/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // Get the current position
        var currentPosition = (_currX, _currY);

        // Check if the current position exists in the maze map
        if (!_mazeMap.ContainsKey(currentPosition))
        {
            throw new InvalidOperationException("Current position is out of bounds.");
        }

        // Get the valid directions for the current position
        var directions = _mazeMap[currentPosition];

        // Check if we can move left (index 0 corresponds to left)
        if (!directions[0]) // directions[0] is for left
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Move left: decrement currX
        _currX -= 1;
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // Get the current position
        var currentPosition = (_currX, _currY);

        // Check if the current position exists in the maze map
        if (!_mazeMap.ContainsKey(currentPosition))
        {
            throw new InvalidOperationException("Current position is out of bounds.");
        }

        // Get the valid directions for the current position
        var directions = _mazeMap[currentPosition];

        // Check if we can move left (index 0 corresponds to left)
        if (!directions[1]) // directions[1] is for right
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Move right: increment currX
        _currX += 1;
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // Get the current position
        var currentPosition = (_currX, _currY);

        // Check if the current position exists in the maze map
        if (!_mazeMap.ContainsKey(currentPosition))
        {
            throw new InvalidOperationException("Current position is out of bounds.");
        }

        // Get the valid directions for the current position
        var directions = _mazeMap[currentPosition];

        // Check if we can move left (index 0 corresponds to left)
        if (!directions[2]) // directions[2] is for up
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Move up: decrement currY
        _currY -= 1;
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // Get the current position
        var currentPosition = (_currX, _currY);

        // Check if the current position exists in the maze map
        if (!_mazeMap.ContainsKey(currentPosition))
        {
            throw new InvalidOperationException("Current position is out of bounds.");
        }

        // Get the valid directions for the current position
        var directions = _mazeMap[currentPosition];

        // Check if we can move left (index 0 corresponds to left)
        if (!directions[3]) // directions[3] is for down
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Move Down: decrement currY
        _currY += 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}