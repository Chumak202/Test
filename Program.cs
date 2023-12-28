using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using static Program;


public class PlayerMovement
{
    private bool isUp;
    private bool isDown;
    private bool isLeft;
    private bool isRight;
    private List<int> steps = new List<int>();
    int _x = 0;
    int _y = 0;
    public Tile Position { get; private set; }
    public Direction Direction { get; private set; }

    public PlayerMovement(int x, int y)
    {
        int _x = 0;
        if (steps.Count != 0)
        {
            Update();
            List<int> step = new List<int>();
            if (isRight && !steps.Contains(6)) step.Add(6);

            if (isLeft && !steps.Contains(4)) step.Add(4);

            if (isDown && !steps.Contains(2)) step.Add(2);

            if (isUp && !steps.Contains(8)) step.Add(8);

            foreach (int i in step)
            {
                if (step.Contains(steps[steps.Count -1]))
                {
                    if(steps.Count - 1 == 8)
                    {
                        _y += 1;
                    }
                    if (steps.Count - 1 == 2)
                    {
                        _y -= 1;
                    }
                    if(steps.Count - 1 == 4)
                    {
                        _x -= 1;
                    }
                    if (steps.Count - 1 == 6)
                    {
                        _x += 1;
                    }
                }
                else
                {
                    steps = step;
                }

            }
        }
        else
        {
            try
            {
                Update();

                if (isRight) steps.Add(6);

                if (isLeft) steps.Add(4);

                if (isDown) steps.Add(2);

                if (isUp) steps.Add(8);

            }
            catch (Exception)
            {

                Console.WriteLine("Ошибка");
            }
        }
    }

    public void Update()
    {
        isUp = Input.GetState(Direction.Up);
        isDown = Input.GetState(Direction.Down);
        isLeft = Input.GetState(Direction.Left);
        isRight = Input.GetState(Direction.Right);

    }
}
