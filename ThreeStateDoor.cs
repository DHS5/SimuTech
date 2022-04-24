using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeStateDoor : LogicalDoor
{
    public ThreeStateDoor(string _name, int _posX, int _posY) : base(_name, _posX, _posY)
    {
        maxSources = 2;
        InitSources();
    }

    protected override void Calculate()
    {
        // Code here the calculate method of the Logical Component
        if (entries[0] == 1)
        {
            exit = entries[1];

            // Keep this line at the end to call the base method
            base.Calculate();
        }
        else if (exit != -1)
        {
            exit = -1;

            // Keep this line at the end to call the base method
            base.Calculate();
        }
    }
}
