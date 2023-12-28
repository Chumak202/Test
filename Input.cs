using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Input
{
    private static byte dir;
    public static void Press(Direction dir)
    {
        Input.dir |= (byte)dir;
    }
    public static void Release(Direction dir)
    {
        Input.dir &= (byte)~(int)dir;
    }
    // pressed = true, released = false
    public static bool GetState(Direction direction)
    {
        return (Input.dir & (byte)direction) != 0;
    }
}

public enum Direction { Up = 8, Down = 1, Left = 2, Right = 4 }

public readonly struct Tile
{
    public int X { get; }
    public int Y { get; }

    public Tile(int x, int y) { X = x; Y = y; }
}


class Program
{
    static PlayerMovement player;
    private static void TestEquality(Direction direction, int x, int y)
    {
        player.Update();

        if (player.Direction != direction)
        {
            throw new Exception($"Wrong direction! Should be {direction}, but was {player.Direction}");
        }
        if (x != player.Position.X)
        {
            throw new Exception($"Wrong position! Should be {x}, but was {player.Position.X}");
        }
        if (y != player.Position.Y)
        {
            throw new Exception($"Wrong position! Should be {y}, but was {player.Position.Y}");
        }
    }
    public static void Main()
    {
        player = new PlayerMovement(0, 0);
        Input.Press(Direction.Down);

        TestEquality(Direction.Down, 0, 0);
        TestEquality(Direction.Down, 0, -1);
        TestEquality(Direction.Down, 0, -2);

        Input.Press(Direction.Left);
        Input.Press(Direction.Right);

        TestEquality(Direction.Left, 0, -2);
        TestEquality(Direction.Left, -1, -2);

        Input.Release(Direction.Left);

        TestEquality(Direction.Right, -1, -2);

        Input.Release(Direction.Right);

        TestEquality(Direction.Down, -1, -2);
        TestEquality(Direction.Down, -1, -3);

        Input.Release(Direction.Down);

        TestEquality(Direction.Down, -1, -3);
    }
}
