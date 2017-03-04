using System;
using UnityEngine;

internal interface InputHandler
{
    bool Left();
    bool Right();
    bool Shoot();
}

// Use rewired for steam controller
public class Player1InputHandler : InputHandler
{
    public Player1InputHandler()
    {
    }

    bool InputHandler.Left()
    {
        return Input.GetKeyUp(KeyCode.A);
    }

    bool InputHandler.Right()
    {
        return Input.GetKeyUp(KeyCode.D);
    }

    bool InputHandler.Shoot()
    {
        return Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W);
    }
}

public class Player2InputHandler : InputHandler
{
    public Player2InputHandler()
    {
    }

    bool InputHandler.Left()
    {
        return Input.GetKeyUp(KeyCode.LeftArrow);
    }

    bool InputHandler.Right()
    {
        return Input.GetKeyUp(KeyCode.RightArrow);
    }

    bool InputHandler.Shoot()
    {
        return Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow);
    }
}