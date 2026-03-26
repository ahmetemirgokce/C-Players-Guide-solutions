
BlockCoordinate market = new BlockCoordinate(2, 2);
BlockOffset a = new BlockOffset(1, -1);
BlockCoordinate newcoord = market + a;
Console.WriteLine($"({newcoord.Row}, {newcoord.Column})");

BlockCoordinate b = (newcoord + Direction.West) + Direction.West;
Console.WriteLine($"({b.Row}, {b.Column})");
Console.WriteLine($"({b[0]}, {b[1]})");

BlockOffset c = Direction.West;
Console.WriteLine(c);

public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate a, BlockOffset b)
        => new BlockCoordinate(a.Row + b.RowOffset, a.Column + b.ColumnOffset);
    
    public static BlockCoordinate operator +(BlockCoordinate coord, Direction direction)
    {
        return (coord, direction) switch
        {
            (BlockCoordinate p, Direction.West) { coord.Column: > 0} => new BlockCoordinate(p.Row, p.Column - 1),
            (BlockCoordinate p, Direction.East) => new BlockCoordinate(p.Row, p.Column + 1),
            (BlockCoordinate p, Direction.South) => new BlockCoordinate(p.Row + 1 , p.Column ),
            (BlockCoordinate p, Direction.North) { coord.Row: > 0} => new BlockCoordinate(p.Row - 1, p.Column),
            _ => new BlockCoordinate(coord.Row, coord.Column)
        };
    }

    public int this[int index]
    {
        get
        {
            if (index == 0) return Row;
            return Column;
        }
    }
}

public record BlockOffset(int RowOffset, int ColumnOffset)
{
    public static implicit operator BlockOffset(Direction direction)
    {
        return direction switch
        {
            Direction.West => new BlockOffset(0, -1),
            Direction.East => new BlockOffset(0, +1),
            Direction.South => new BlockOffset(+1, 0),
            Direction.North => new BlockOffset(-1, 0),
        };
    }
}
public enum Direction {North, East, South, West}
